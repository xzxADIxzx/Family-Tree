using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edit : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Node.Data data;
    [SerializeField] private Node.Date edit;
    [Header("Interface")]
    [SerializeField] private InputField name;
    [SerializeField] private InputField surname;
    [SerializeField] private InputField patronymic;
    [SerializeField] private InputField year;
    [SerializeField] private Dropdown month;
    [SerializeField] private InputField day;
    [SerializeField] private Image bg;
    [SerializeField] private Text age;
    [SerializeField] private RectTransform trn;

    public void SetData(Node.Data data)
    {
        if (data.birthday.year == default) return;
        this.data = data;
        edit = data.birthday;
        name.text = data.name;
        surname.text = data.surname;
        patronymic.text = data.patronymic;
        year.text = data.birthday.year.ToString();
        month.value = data.birthday.month - 1;
        day.text = data.birthday.day.ToString();
        UpdateAge();
    }

    private void UpdateAge()
    {
        age.text = Node.GetAge(data.birthday).ToString();
        float width = age.text.Length * 6 + 10;
        trn.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        trn.localPosition = new Vector2(-40 + width / 2, -45);
    }

    private bool CheckDate(Node.Date date)
    {
        try //valid date
        {
            new DateTime(date.year, date.month, date.day);
            bg.color = new Color(1, 1, 1, .392f);
        }
        catch //invalid date
        {
            bg.color = new Color(1, 0, 0, .392f);
            return false;
        }
        return true;
    }

    public void ChangeName(string name)
    {
        data.name = name;
    }

    public void ChangeSurname(string surname)
    {
        data.surname = surname;
    }

    public void ChangePatronymic(string patronymic)
    {
        data.patronymic = patronymic;
    }

    public void ChangeYear(string year)
    {
        edit.year = Convert.ToInt32(year);
        if (!CheckDate(edit)) return; // date verification failed
        data.birthday = edit;
        UpdateAge();
    }

    public void ChangeMonth(int month)
    {
        edit.month = month + 1;
        if (!CheckDate(edit)) return; // date verification failed
        data.birthday = edit;
        UpdateAge();
    }

    public void ChangeDay(string day)
    {
        edit.day = Convert.ToInt32(day);
        if (!CheckDate(edit)) return; // date verification failed
        data.birthday = edit;
        UpdateAge();
    }

    /* call by button in edit menu*/
    public void Save()
    {
        Vars.sin.MEN.EditNode(data);
    }
}
