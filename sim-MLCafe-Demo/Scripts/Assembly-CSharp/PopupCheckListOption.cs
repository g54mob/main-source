using TMPro;
using UnityEngine;

public class PopupCheckListOption
{
	public string taskTitle;

	private bool fullfilled;

	private GameObject icon;

	private TMP_Text label;

	public PopupCheckListOption(string taskTitle)
	{
		this.taskTitle = taskTitle;
		fullfilled = false;
	}

	public void AssignUIObject(GameObject uiInstance)
	{
		label = uiInstance.GetComponent<TMP_Text>();
		label.text = taskTitle;
		icon = uiInstance.transform.Find("icon").gameObject;
		icon.SetActive(value: false);
	}

	public bool IsFinished()
	{
		return fullfilled;
	}

	public void Reset()
	{
		fullfilled = false;
	}

	public void MarkFinished()
	{
		fullfilled = true;
	}
}
