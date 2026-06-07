using TMPro;
using UnityEngine;

public class ChangeTextToKeybind : MonoBehaviour
{
	public bool surroundedByParentheses;

	public bool uppercase;

	public string keybindNum;

	private void OnEnable()
	{
		Refresh();
	}

	public void Refresh()
	{
		string text = PlayerPrefs.GetString("Keybind" + keybindNum);
		text = text.ToLower();
		text = text.Replace("rightbracket", "]");
		text = text.Replace("leftbracket", "]");
		text = text.Replace("backslash", "\\");
		text = text.Replace("quote", "'");
		text = text.Replace("semicolon", ";");
		text = text.Replace("comma", ",");
		text = text.Replace("period", ".");
		text = text.Replace("slash", "/");
		text = text.Replace("backquote", "`");
		text = text.Replace("minus", "-");
		text = text.Replace("equals", "=");
		text = text.Replace("rightalt", "alt");
		text = text.Replace("leftalt", "alt");
		text = text.Replace("leftalt", "alt");
		text = text.Replace("leftcontrol", "ctrl");
		text = text.Replace("rightcontrol", "ctrl");
		text = text.Replace("leftshift", "shift");
		text = text.Replace("rightshift", "shift");
		text = text.Replace("capslock", "caps");
		if (uppercase)
		{
			text = text.ToUpper();
		}
		if (surroundedByParentheses)
		{
			text = "(" + text + ")";
		}
		GetComponent<TextMeshProUGUI>().font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		GetComponent<TextMeshProUGUI>().text = text;
	}
}
