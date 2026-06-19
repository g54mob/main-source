using TMPro;
using UnityEngine;

public class NameInput : MonoBehaviour
{
	public TMP_InputField inputRef;

	private string previousString = "";

	private string textInSound = "mainMenu_characterIn";

	private string textOutSound = "mainMenu_characterErased";

	private void OnEnable()
	{
		inputRef.Select();
	}

	public void OnValueChanged()
	{
		if (inputRef.text.Length > previousString.Length)
		{
			AudioController.Play(textInSound);
		}
		else if (inputRef.text.Length < previousString.Length)
		{
			AudioController.Play(textOutSound);
		}
		previousString = inputRef.text;
	}

	public void Lock()
	{
		inputRef.interactable = false;
	}

	public void Unlock()
	{
		inputRef.interactable = true;
	}

	public string GetInputString()
	{
		return inputRef.text;
	}

	public bool IsStringValid()
	{
		if (inputRef.text == "")
		{
			return false;
		}
		if (inputRef.text.Length < 1)
		{
			return false;
		}
		return true;
	}
}
