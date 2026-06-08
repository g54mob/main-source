using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AliasUI : MonoBehaviour
{
	public static AliasUI Instance;

	public InputFieldFileEditor inputField;

	public Text buttonSaveText;

	public Text buttonValidateText;

	private bool initialFocusOnInput = true;

	private bool initialFocusOnInput2 = true;

	public bool IsShowing
	{
		get
		{
			return base.gameObject.activeSelf;
		}
	}

	private void Awake()
	{
		Instance = this;
		base.gameObject.SetActive(false);
		InputFieldFileEditor inputFieldFileEditor = inputField;
		inputFieldFileEditor.onValidateInput = (InputField.OnValidateInput)Delegate.Combine(inputFieldFileEditor.onValidateInput, new InputField.OnValidateInput(ValidateInput));
		if (!SceneLevelInput.DisableCtrlOnAlias)
		{
			buttonSaveText.text = "[CTRL + S] Save";
		}
		else
		{
			buttonSaveText.text = "[ALT + S] Save";
		}
		buttonValidateText.text = "[ALT + V] Validate";
	}

	public void Update()
	{
		if (initialFocusOnInput)
		{
			SystemEvents.Instance.eventSystem.SetSelectedGameObject(inputField.gameObject);
			inputField.ActivateInputField();
			initialFocusOnInput = false;
			initialFocusOnInput2 = true;
			inputField.MoveTextStart(false);
		}
		else if (initialFocusOnInput2)
		{
			initialFocusOnInput2 = false;
			inputField.MoveTextStart(false);
		}
	}

	public void Show()
	{
		initialFocusOnInput = true;
		base.gameObject.SetActive(true);
		string text = string.Empty;
		string[] array = File.ReadAllLines(GameFileHelper.AliasFullPath());
		if (array.Length > 0)
		{
			char[] separator = new char[1] { '=' };
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				string text2 = array[i];
				string[] array2 = text2.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				if (!string.IsNullOrEmpty(text2))
				{
					text = text + text2 + "\n";
				}
			}
		}
		inputField.enabled = true;
		inputField.text = text;
		inputField.originalText = text;
	}

	public void Hide()
	{
		base.gameObject.SetActive(false);
		base.gameObject.transform.parent.gameObject.SetActive(false);
		base.gameObject.transform.parent.gameObject.SetActive(true);
	}

	private char ValidateInput(string text, int charIndex, char addedChar)
	{
		if ((addedChar >= '0' && addedChar <= '9') || (addedChar >= 'A' && addedChar <= 'Z') || (addedChar >= 'a' && addedChar <= 'z') || addedChar == '=' || addedChar == ';' || addedChar <= ' ' || addedChar == '$' || addedChar == '(' || addedChar == ')' || addedChar == SceneLevelInput.AdditionalSupportedChar)
		{
			if ((addedChar == '=' || addedChar == ';') && (charIndex == 0 || text[charIndex - 1] == '\n'))
			{
				CommonAudioHelper.Instance.PlayErrorSound();
				return '\0';
			}
			switch (addedChar)
			{
			case '=':
			{
				int num2 = charIndex - 1;
				while (num2 >= 0 && text[num2] != '\n')
				{
					if (text[num2] == '=')
					{
						CommonAudioHelper.Instance.PlayErrorSound();
						return '\0';
					}
					num2--;
				}
				for (int i = charIndex; i < text.Length && text[i] != '\n'; i++)
				{
					if (text[i] == '=')
					{
						CommonAudioHelper.Instance.PlayErrorSound();
						return '\0';
					}
				}
				break;
			}
			case ';':
			{
				bool flag = false;
				int num = charIndex - 1;
				while (num >= 0 && text[num] != '=' && text[num] != ';')
				{
					if (text[num] == '\n' || num == 0)
					{
						CommonAudioHelper.Instance.PlayErrorSound();
						return '\0';
					}
					if (text[num] != ' ')
					{
						flag = true;
					}
					num--;
				}
				if (!flag)
				{
					CommonAudioHelper.Instance.PlayErrorSound();
					return '\0';
				}
				break;
			}
			}
			return addedChar;
		}
		CommonAudioHelper.Instance.PlayErrorSound();
		return '\0';
	}
}
