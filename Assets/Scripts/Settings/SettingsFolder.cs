using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SettingsFolder : MonoBehaviour
{
    static string SavePath;

    private void Start()
    {
        SavePath = Path.Combine(Application.dataPath, "Saves");
        if (!Directory.Exists(SavePath))
        	Directory.CreateDirectory(SavePath);
    }
}
