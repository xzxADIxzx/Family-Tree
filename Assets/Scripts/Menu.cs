using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Node selected;
    [Header("Canvas")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector2 size;
    [Header("Context")]
    [SerializeField] private bool contextHidden = true;
    [SerializeField] private GameObject context;
    [SerializeField] private GameObject contextBG;
    [SerializeField] private GameObject contextNew;
    [SerializeField] private GameObject contextEdit;
    [SerializeField] private GameObject contextDelete;
    [SerializeField] private GameObject contextRevert;
    [SerializeField] private GameObject contextView;
    [Header("View")]
    [SerializeField] private bool viewHidden = true;
    [SerializeField] private GameObject view;
    [SerializeField] private GameObject viewBG;

    public void ShowContext(Vector2 pos, Node selected, Node.Data recent)
    {
        //if (!contextHidden) return;
        context.SetActive(true);
        context.transform.position = pos + new Vector2(40, -110) * size;
        contextEdit.GetComponent<Button>().interactable = selected != null;
        contextDelete.GetComponent<Button>().interactable = selected != null;
        contextRevert.GetComponent<Button>().interactable = recent.age != default;
        contextView.GetComponent<Button>().interactable = selected != null;
        this.selected = selected;
        Alpha.On(contextBG, 1, null, 0, 100);
        Alpha.On(contextNew);
        Alpha.On(contextEdit);
        Alpha.On(contextDelete);
        Alpha.On(contextRevert);
        Alpha.On(contextView);
        contextHidden = false;
    }

    public void HideContext()
    {
        if (contextHidden) return;
        Alpha.Off(contextBG, 1, delegate { context.SetActive(false); }, 100);
        Alpha.Off(contextNew);
        Alpha.Off(contextEdit);
        Alpha.Off(contextDelete);
        Alpha.Off(contextRevert);
        Alpha.Off(contextView);
        contextHidden = true;
    }

    public void RemoveNode()
    {
        if (selected == null) return;
        Vars.sin.NDM.Remove(selected);
    }

    void Start()
    {
        size = canvas.transform.localScale;
    }
}
