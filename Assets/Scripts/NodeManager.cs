using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [Header("Nodes")]
    [SerializeField] public List<Node> nodes;
    [SerializeField] public GameObject prefab;
    [Header("Data")]
    [SerializeField] public Node.Data recent;
    [SerializeField] public Node.Data defaul;
    [SerializeField] public Node.Data[] start;
    [Header("Input")]
    [SerializeField] public Node selected;
    [SerializeField] public Vector2 mouseR;
    [SerializeField] public Vector2 mouseM;
    [SerializeField] public float zoom = .8f;

    public void Load(Node.Data[] data)
    {
        foreach (Node.Data d in data) nodes.Add(Instantiate(prefab, Vars.sin.NDT).GetComponent<Node>().SetData(d));
        nodes[0].isRoot = true;
    }

    public void Add(Node.Data data, Vector2 pos)
    {
        data.position = pos;
        nodes.Add(Instantiate(prefab, pos, Quaternion.identity, Vars.sin.NDT).GetComponent<Node>().SetData(data));
        Vars.sin.PRM.SpawnBubbles(pos);
        Vars.sin.TRS.Save(nodes);
    }

    public void Remove(Node node)
    {
        recent = node.data; // to revert deleted node
        Destroy(node.gameObject);
        nodes.Remove(node);
        Vars.sin.TRS.Save(nodes);
    }

    /* call by button in context menu*/
    public void RevertNode()
    {
        if (recent.birthday.year == default) return; // if recent is null
        Add(recent, Camera.main.ScreenToWorldPoint(mouseR));
    }

    /* call by button in context menu*/
    public void NewNode()
    {
        Add(defaul, Camera.main.ScreenToWorldPoint(mouseR));
    }

    public void Move()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 old = Camera.main.ScreenToWorldPoint(mouseM);
        Vector3 pos = old - mouse;
        Camera.main.transform.Translate(pos);
        mouseM = Input.mousePosition;
        Vars.sin.MEN.HideAll();
    }

    public float GetZoom()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        if (wheel == 0) return this.zoom; // nothing changed
        float size = Camera.main.orthographicSize;
        float zoom = size - wheel * size * 4;
        zoom = Mathf.Clamp(zoom, .8f, 5);
        Vars.sin.MEN.HideAll();
        return zoom;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(Settings.drag))
            Vars.sin.PRM.SpawnClick(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Input.GetKeyUp(Settings.drag))
            Vars.sin.MEN.HideContext();
        if (Input.GetKeyDown(Settings.menu))
            mouseR = Input.mousePosition;
        if (Input.GetKeyUp(Settings.menu) && mouseR == (Vector2)Input.mousePosition)
            Vars.sin.MEN.ShowContext(mouseR, selected, recent);
        if (Input.GetKeyDown(Settings.move))
            mouseM = Input.mousePosition;
        if (Input.GetKey(Settings.move))
            Move();
        else
            zoom = GetZoom();
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, zoom, 15f * Time.deltaTime);
    }

    private void Start()
    {
        DateTime now = DateTime.Now;

        defaul.birthday.year = now.Year;
        defaul.birthday.month = now.Month;
        defaul.birthday.day = now.Day;

        start[0].birthday.year = now.Year;
        start[0].birthday.month = now.Month;
        start[0].birthday.day = now.Day;
    }
}
