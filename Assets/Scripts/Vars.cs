using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vars : MonoBehaviour
{
    [Header("Singleton")]
    [SerializeField] public static Vars sin;
    [Header("Managers")]
    [SerializeField] public NodeManager NDM;
    [SerializeField] public ParticleManager PRM;
    [SerializeField] public SettingsTree TRS;
    [SerializeField] public Menu MEN;
    [SerializeField] public View VIW;
    [SerializeField] public Edit EDI;
    [Header("Trash")]
    [SerializeField] public Transform NDT;
    [SerializeField] public Transform PRT;

    private void Start()
    {
        sin = this;
    }
}
