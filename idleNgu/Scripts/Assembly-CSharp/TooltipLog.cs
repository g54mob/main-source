using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipLog : MonoBehaviour
{
	public Text logText;

	public Scrollbar textScroll;

	private List<string> Eventlog = new List<string>();

	private string text = "";

	public int maxEvents = 30;

	public void Start()
	{
		logText.text = "No Logs yet :(";
	}

	public void AddEvent(string eventString)
	{
		Eventlog.Add(eventString);
		if (Eventlog.Count > maxEvents)
		{
			Eventlog.RemoveAt(0);
		}
		text = "";
		int num = 0;
		foreach (string item in Eventlog)
		{
			num++;
			text = text + "<b>" + num + ") </b>";
			text += item;
			text += "\n";
		}
		logText.text = text;
	}
}
