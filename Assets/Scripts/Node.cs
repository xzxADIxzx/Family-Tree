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

    public static int GetAge(Date date)
    {
        DateTime birthday = new DateTime(date.year, date.month, date.day);
        int age = DateTime.Now.Year - birthday.Year;
        if (birthday > DateTime.Now.AddYears(-age))
            age--;
        return age;
    }

    public Node SetData(Data data)
    {
        text.text = data.name + " " + data.surname;
        data.age = GetAge(data.birthday);
        transform.position = data.position;

        this.data = data;
        return this;
    }

    [Serializable]
    public struct Date
    {
        public int year;
        public int month;
        public int day;

        public static Dictionary<int, string> months = new Dictionary<int, string>
        {
            { 1, "JAN" },
            { 2, "FEB" },
            { 3, "MAR" },
            { 4, "APR" },
            { 5, "MAY" },
            { 6, "JUN" },
            { 7, "JUL" },
            { 8, "AUG" },
            { 9, "SEP" },
            { 10, "OCT" },
            { 11, "NOV" },
            { 12, "DEC" }
        };

        public string GetMonth()
        {
            return months[month];
        }
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
