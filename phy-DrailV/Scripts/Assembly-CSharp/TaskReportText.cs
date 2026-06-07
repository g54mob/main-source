using TMPro;
using UnityEngine;

public class TaskReportText : MonoBehaviour
{
	public TextMeshPro taskText;

	public GameObject checkBox;

	public GameObject checkMark;

	public void Display(string text, bool taskCompleted)
	{
		taskText.text = text;
		if (taskCompleted)
		{
			checkBox.SetActive(value: true);
			checkMark.SetActive(value: true);
		}
		else
		{
			checkBox.SetActive(value: true);
			checkMark.SetActive(value: false);
		}
	}

	public void DisplayTextOnly(string text)
	{
		taskText.text = text;
		checkBox.SetActive(value: false);
		checkMark.SetActive(value: false);
	}

	public void Hide()
	{
		taskText.text = "";
		checkBox.SetActive(value: false);
		checkMark.SetActive(value: false);
	}
}
