using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] private Text name;
    [SerializeField] private Text surname;
    [SerializeField] private Text patronymic;
    [SerializeField] private Text birthday;
    [SerializeField] private Text age;
    [SerializeField] private RectTransform trn;

    public void SetData(Node.Data data)
    {
        if (data.birthday.year == default) return;
        name.text = data.name;
        surname.text = data.surname;
        patronymic.text = data.patronymic;
        
        birthday.text = data.birthday.year + " " + data.birthday.GetMonth() + " " + data.birthday.day;
        age.text = Node.GetAge(data.birthday).ToString();

        // adaptive size
        float width = age.text.Length * 6 + 10;
        trn.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        trn.localPosition = new Vector2(-40 + width / 2, -45);
    }
}
