using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLog : MonoBehaviour
{
	public Text logText;

	public Scrollbar textScroll;

	private List<string> Eventlog = new List<string>();

	private string text = "";

	public int maxLines = 30;

	public void AddEvent(string eventString)
	{
		Eventlog.Add(eventString);
		if (Eventlog.Count > maxLines)
		{
			Eventlog.RemoveAt(0);
		}
		text = "";
		foreach (string item in Eventlog)
		{
			text += item;
			text += "\n";
		}
		logText.text = text;
		if (Eventlog.Count >= 30)
		{
			textScroll.value = 1f - (float)Eventlog.Count / 31f;
		}
		else if (Eventlog.Count > 7)
		{
			textScroll.value = 1f - (float)Eventlog.Count / 31f + 0.1f;
		}
		_ = Eventlog.Count;
		_ = 30;
	}

	public void AddEvent(string eventString, int type)
	{
		switch (type)
		{
		case 1:
			Eventlog.Add("<color=green>" + eventString + "</color>");
			break;
		case 2:
			Eventlog.Add("<color=red>" + eventString + "</color>");
			break;
		case 3:
			Eventlog.Add("<color=blue><b>" + eventString + "</b></color>");
			break;
		default:
			Eventlog.Add(eventString);
			break;
		}
		if (Eventlog.Count > maxLines)
		{
			Eventlog.RemoveAt(0);
		}
		text = "";
		foreach (string item in Eventlog)
		{
			text += item;
			text += "\n";
		}
		logText.text = text;
		if (Eventlog.Count >= 30)
		{
			textScroll.value = 1f - (float)Eventlog.Count / 31f;
		}
		else if (Eventlog.Count > 7)
		{
			textScroll.value = 1f - (float)Eventlog.Count / 31f + 0.1f;
		}
		_ = Eventlog.Count;
		_ = 30;
	}
}
