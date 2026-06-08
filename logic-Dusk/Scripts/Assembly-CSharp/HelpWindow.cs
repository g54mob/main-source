using System.Collections.Generic;
using UnityEngine;

public class HelpWindow
{
	private const string COMMAND_DESC_SEPARATOR = " - ";

	private const int HORIZONTAL_MARGIN = 10;

	private const int VERTICAL_MARGIN = 5;

	private const int MIN_WIDTH = 50;

	private const int MIN_HEIGHT = 50;

	private const int WIDTH_PER_CHAR = 7;

	private const int HEIGHT_PER_CHAR = 20;

	private const int WINDOW_TITLE_HEIGHT = 15;

	public int WindowId = 112233;

	public string WindowTitle = "Game Help";

	private Dictionary<string, string> _helpTopics = new Dictionary<string, string>();

	private Rect _screenRect = new Rect(0f, 0f, 50f, 50f);

	public void AddHelpTopic(string command, string description)
	{
		if (!_helpTopics.ContainsKey(command))
		{
			_helpTopics.Add(command, description);
			CalculateHelpWindowRect();
		}
		else
		{
			Debug.Log("DUH!");
		}
	}

	public void Clear()
	{
		_helpTopics.Clear();
	}

	public void DrawHelpWindow()
	{
		_screenRect = CommonMethods.KeepWindowVisible(_screenRect);
		_screenRect = GUI.Window(WindowId, _screenRect, PrivateDrawWindow, WindowTitle);
	}

	private void CalculateHelpWindowRect()
	{
		int a = _helpTopics.Count * 20 + 10 + 15;
		int num = 0;
		foreach (KeyValuePair<string, string> helpTopic in _helpTopics)
		{
			int num2 = helpTopic.Key.Length + helpTopic.Value.Length + " - ".Length;
			int num3 = num2 * 7 + 20;
			if (num3 > num)
			{
				num = num3;
			}
		}
		a = Mathf.Max(a, 50);
		num = Mathf.Max(num, 50);
		int num4 = Screen.width - num;
		int num5 = Screen.height - a;
		_screenRect = new Rect(num4, num5, num, a);
	}

	private void PrivateDrawWindow(int id)
	{
		int num = 10;
		int num2 = 20;
		foreach (KeyValuePair<string, string> helpTopic in _helpTopics)
		{
			string text = string.Format("{0}{1}{2}", helpTopic.Key, " - ", helpTopic.Value);
			GUI.Label(new Rect(num, num2, _screenRect.width, 20f), text);
			num2 += 20;
		}
		GUI.DragWindow();
	}
}
