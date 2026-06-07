using UnityEngine;

public class OpenAppAdapter : MonoBehaviour
{
	[AppNameDropdown]
	public string AppName;

	public string structString;

	public AppBase appBase;

	private void OnValidate()
	{
	}

	public void OpenApp()
	{
	}

	public string Format(string input, params string[] parameters)
	{
		return null;
	}
}
