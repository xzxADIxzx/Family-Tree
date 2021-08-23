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
    [Header("Trash")]
    [SerializeField] public Transform NDT;
    [SerializeField] public Transform PRT;

    void Start()
    {
        sin = this;
    }
}
