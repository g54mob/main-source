using UnityEngine;
using UnityEngine.UI;

public class AutomationLog : MonoBehaviour
{
	public GUIWindow Window;

	public Text MainText;

	private int _lines;

	public void SetLog(string log)
	{
		MainText.text = log;
		_lines = log.CountLetter('\n');
	}

	public void Log(string msg)
	{
		if (_lines > 25)
		{
			MainText.text = MainText.text.Substring(0, MainText.text.LastIndexOf("\n"));
		}
		else
		{
			_lines++;
		}
		if (_lines > 1)
		{
			MainText.text = SDateTime.Now().ToVeryCompactString().FontBold() + ": " + msg + "\n" + MainText.text;
		}
		else
		{
			MainText.text = SDateTime.Now().ToVeryCompactString().FontBold() + ": " + msg;
		}
	}
}
