using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Click Data")]
    [SerializeField] private Vector2 position;
    [SerializeField] private Node selected;
    [Header("Canvas")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector2 size;
    [Header("Context")]
    [SerializeField] private bool contextHidden = true;
    [SerializeField] private GameObject context;
    [SerializeField] private GameObject contextBG;
    [SerializeField] private GameObject contextNew;
    [SerializeField] private GameObject contextEdit;
    [SerializeField] private GameObject contextDelete;
    [SerializeField] private GameObject contextRevert;
    [SerializeField] private GameObject contextView;
    [Header("View")]
    [SerializeField] private bool viewHidden = true;
    [SerializeField] private GameObject view;
    [SerializeField] private GameObject viewBG;
    [SerializeField] private GameObject viewName;
    [SerializeField] private GameObject viewNameBG;
    [SerializeField] private GameObject viewSurname;
    [SerializeField] private GameObject viewSurnameBG;
    [SerializeField] private GameObject viewPatronymic;
    [SerializeField] private GameObject viewPatronymicBG;
    [SerializeField] private GameObject viewBirthday;
    [SerializeField] private GameObject viewBirthdayBG;
    [SerializeField] private GameObject viewAge;
    [SerializeField] private GameObject viewAgeBG;
    [SerializeField] private GameObject viewBackBG;
    [SerializeField] private GameObject viewEditBG;
    [Header("Edit")]
    [Header("View")]
    [SerializeField] private bool editHidden = true;
    [SerializeField] private GameObject edit;
    [SerializeField] private GameObject editBG;
    [SerializeField] private GameObject editName;
    [SerializeField] private GameObject editNameBG;
    [SerializeField] private GameObject editSurname;
    [SerializeField] private GameObject editSurnameBG;
    [SerializeField] private GameObject editPatronymic;
    [SerializeField] private GameObject editPatronymicBG;
    [SerializeField] private GameObject editYear;
    [SerializeField] private GameObject editMonth;
    [SerializeField] private GameObject editDay;
    [SerializeField] private GameObject editBirthdayBG;
    [SerializeField] private GameObject editAge;
    [SerializeField] private GameObject editAgeBG;
    [SerializeField] private GameObject editBackBG;
    [SerializeField] private GameObject editSaveBG;

    public void ShowContext(Vector2 pos, Node selected, Node.Data recent)
    {
        //if (!contextHidden) return;
        context.SetActive(true);
        context.transform.position = pos + new Vector2(40, -110) * size;
        contextEdit.GetComponent<Button>().interactable = selected != null;
        contextDelete.GetComponent<Button>().interactable = selected != null;
        contextRevert.GetComponent<Button>().interactable = recent.birthday.year != default;
        contextView.GetComponent<Button>().interactable = selected != null;
        this.position = pos;
        this.selected = selected;
        HideView(); // only 1 menu on screen
        HideEdit();
        Alpha.On(contextBG, 1, null, 0, 100);
        Alpha.On(contextNew);
        Alpha.On(contextEdit);
        Alpha.On(contextDelete);
        Alpha.On(contextRevert);
        Alpha.On(contextView);
        contextHidden = false;
    }

    public void HideContext()
    {
        if (contextHidden) return;
        Alpha.Off(contextBG, 1, delegate { context.SetActive(false); }, 100);
        Alpha.Off(contextNew);
        Alpha.Off(contextEdit);
        Alpha.Off(contextDelete);
        Alpha.Off(contextRevert);
        Alpha.Off(contextView);
        contextHidden = true;
    }

    public void ShowView()
    {
        if (!viewHidden) return;
        view.SetActive(true);
        view.transform.position = position + new Vector2(50, -95) * size;
        Vars.sin.VIW.SetData(selected.data);
        HideContext(); // only 1 menu on screen
        HideEdit();
        Alpha.On(viewBG, 1, null, 0, 100);
        Alpha.On(viewName);
        Alpha.On(viewNameBG, 1, null, 0, 100);
        Alpha.On(viewSurname);
        Alpha.On(viewSurnameBG, 1, null, 0, 100);
        Alpha.On(viewPatronymic);
        Alpha.On(viewPatronymicBG, 1, null, 0, 100);
        Alpha.On(viewBirthday);
        Alpha.On(viewBirthdayBG, 1, null, 0, 100);
        Alpha.On(viewAge);
        Alpha.On(viewAgeBG, 1, null, 0, 100);
        Alpha.On(viewBackBG, 1, null, 0, 100);
        Alpha.On(viewEditBG, 1, null, 0, 100);
        viewHidden = false;
    }

    public void HideView()
    {
        if (viewHidden) return;
        Alpha.Off(viewBG, 1, delegate { view.SetActive(false); }, 100);
        Alpha.Off(viewName);
        Alpha.Off(viewNameBG, 1, null, 100);
        Alpha.Off(viewSurname);
        Alpha.Off(viewSurnameBG, 1, null, 100);
        Alpha.Off(viewPatronymic);
        Alpha.Off(viewPatronymicBG, 1, null, 100);
        Alpha.Off(viewBirthday);
        Alpha.Off(viewBirthdayBG, 1, null, 100);
        Alpha.Off(viewAge);
        Alpha.Off(viewAgeBG, 1, null, 100);
        Alpha.Off(viewBackBG, 1, null, 100);
        Alpha.Off(viewEditBG, 1, null, 100);
        viewHidden = true;
    }

    public void ShowEdit()
    {
        if (!editHidden) return;
        edit.SetActive(true);
        edit.transform.position = position + new Vector2(50, -95) * size;
        Vars.sin.EDI.SetData(selected.data);
        HideContext(); // only 1 menu on screen
        HideView();
        Alpha.On(editBG, 1, null, 0, 100);
        Alpha.On(editName);
        Alpha.On(editNameBG, 1, null, 0, 100);
        Alpha.On(editSurname);
        Alpha.On(editSurnameBG, 1, null, 0, 100);
        Alpha.On(editPatronymic);
        Alpha.On(editPatronymicBG, 1, null, 0, 100);
        Alpha.On(editYear);
        Alpha.On(editMonth);
        Alpha.On(editDay);
        Alpha.On(editBirthdayBG, 1, null, 0, 100);
        Alpha.On(editAge);
        Alpha.On(editAgeBG, 1, null, 0, 100);
        Alpha.On(editBackBG, 1, null, 0, 100);
        Alpha.On(editSaveBG, 1, null, 0, 100);
        editHidden = false;
    }

    public void HideEdit()
    {
        if (editHidden) return;
        Alpha.Off(editBG, 1, delegate { edit.SetActive(false); }, 100);
        Alpha.Off(editName);
        Alpha.Off(editNameBG, 1, null, 100);
        Alpha.Off(editSurname);
        Alpha.Off(editSurnameBG, 1, null, 100);
        Alpha.Off(editPatronymic);
        Alpha.Off(editPatronymicBG, 1, null, 100);
        Alpha.Off(editYear);
        Alpha.Off(editMonth);
        Alpha.Off(editDay);
        Alpha.Off(editBirthdayBG, 1, null, 100);
        Alpha.Off(editAge);
        Alpha.Off(editAgeBG, 1, null, 100);
        Alpha.Off(editBackBG, 1, null, 100);
        Alpha.Off(editSaveBG, 1, null, 100);
        editHidden = true;
    }

    public void HideAll()
    {
        HideContext();
        HideView();
        HideEdit();
    }

    /* call by button in context menu*/
    public void RemoveNode()
    {
        if (selected == null) return;
        Vars.sin.NDM.Remove(selected);
    }

    /* call by edit*/
    public void EditNode(Node.Data data)
    {
        selected.SetData(data);
        HideEdit();
        Vars.sin.TRS.Save(Vars.sin.NDM.nodes);
    }

    private void Start()
    {
        size = canvas.transform.localScale;
    }
}
