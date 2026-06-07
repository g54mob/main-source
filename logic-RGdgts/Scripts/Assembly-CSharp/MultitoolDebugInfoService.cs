using TMPro;
using UI.Apps;
using UnityEngine;
using UnityEngine.UI;

public class MultitoolDebugInfoService : MultitoolService
{
	public TextMeshProUGUI text;

	public Image background;

	public Color debugBgColor;

	public void SetDebugMode(string message)
	{
	}

	public void SetErrorMode(string message)
	{
	}

	public override void OnMultitoolAppStart(MultiToolAppInfo appInfo)
	{
	}
}
