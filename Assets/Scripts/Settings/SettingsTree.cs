using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System;
using UnityEngine;

public class SettingsTree : MonoBehaviour
{
    static string path;

    public void Save(List<Node> node)
    {
        List<Node.Data> data = node.ConvertAll(new Converter<Node, Node.Data>(delegate (Node n) { return n.data; }));
        File.WriteAllText(path, JsonUtility.ToJson(new Container(data.ToArray()), true));
    }

    private async void Start()
    {
        await Task.Delay(1); // wait 1 frame
        path = Path.Combine(Application.dataPath + "/Saves", "Tree.json");
        
        if (!File.Exists(path))
            File.WriteAllText(path, JsonUtility.ToJson(new Container(Vars.sin.NDM.start), true));
        Container data = JsonUtility.FromJson<Container>(File.ReadAllText(path));
        Vars.sin.NDM.Load(data.data);
    }

    [Serializable]
    public class Container
    {
        public Node.Data[] data;

        public Container(Node.Data[] data)
        {
            this.data = data;
        }
    }
}