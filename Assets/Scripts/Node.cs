using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [Header("This")]
    [SerializeField] public Data data;
    [SerializeField] public bool isRoot;
    [Header("Objects")]
    [SerializeField] public SpriteRenderer img;
    [SerializeField] public TextMesh text;

    public void OnMouseEnter()
    {
        Vars.sin.NDM.selected = this;
    }

    public void OnMouseExit()
    {
        Vars.sin.NDM.selected = null;
    }

    public Node SetData(Data data)
    {
        text.text = data.name + " " + data.surname;
        transform.position = data.position;

        DateTime birthday = new DateTime(data.birthday.year, data.birthday.month, data.birthday.day);
        int age = DateTime.Now.Year - birthday.Year;
        if (birthday > DateTime.Now.AddYears(-age))
            age--;
        data.age = age;

        this.data = data;
        return this;
    }

    [Serializable]
    public struct Date
    {
        public int year;
        public int month;
        public int day;
    }

    [Serializable]
    public struct Data
    {
        public string name;
        public string surname;
        public string patronymic;
        [Space]
        public int age;
        public Date birthday;
        [Space]
        public Vector2 position;
    }
}
