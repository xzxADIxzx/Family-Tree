using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject click;
    [SerializeField] private GameObject bubbles;
    [SerializeField] private GameObject maelstrom;

    public void SpawnClick(Vector2 pos)
    {
        Destroy(Instantiate(click, pos, Quaternion.identity, Vars.sin.PRT), 2);
    }

    public void SpawnBubbles(Vector2 pos)
    {
        Destroy(Instantiate(bubbles, pos, Quaternion.identity, Vars.sin.PRT), 3);
    }

    public void SpawnMaelstrom(Vector2 pos)
    {
        Destroy(Instantiate(maelstrom, pos, Quaternion.identity, Vars.sin.PRT), 2);
    }
}
