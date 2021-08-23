#if UNITY_EDITOR
using System.IO;
using UnityEngine;
using UnityEditor;

public class SettingsClear : EditorWindow
{
    [MenuItem("Edit/Saves/Clear All")]
    public static void ClearAll()
    {
        string path = Application.dataPath + "/Saves";
        if (Directory.Exists(path))
            Directory.Delete(path, true);
        else
            Debug.LogError("The folder does not exist.");
    }

    [MenuItem("Edit/Saves/Clear Tree")]
    public static void ClearLabguage()
    {
        string path = Path.Combine(Application.dataPath + "/Saves", "Tree.json");
        if (File.Exists(path))
            File.Delete(path);
        else
            Debug.LogError("The file does not exist.");
    }
}
#endif