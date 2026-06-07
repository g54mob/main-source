using System;
using UnityEngine;
using UnityEngine.UI;

public class InputDialog : MonoBehaviour
{
	public GUIWindow Window;

	public Text Prompt;

	public InputField InputBox;

	private Action<string> OnFinish;

	private Action OnCancel;

	public void Init(string prompt, string title, string defaultText, Action<string> onFinish, Action onCancel = null, int characterLimit = 0)
	{
		Window.NonLocTitle = title;
		Prompt.text = prompt;
		OnFinish = onFinish;
		OnCancel = onCancel;
		InputBox.characterLimit = characterLimit;
		InputBox.text = defaultText;
		InputBox.Select();
		InputBox.caretPosition = 0;
		InputBox.MoveTextEnd(true);
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.ForcePause = true;
		}
	}

	public void CloseNow(bool ok)
	{
		if (ok)
		{
			OnFinish(InputBox.text);
		}
		else if (OnCancel != null)
		{
			OnCancel();
		}
		OnCancel = null;
		if (!GameSettings.Instance.IsReferenceNull())
		{
			GameSettings.ForcePause = false;
		}
		Window.Close();
	}

	public void OnEndEdit()
	{
		if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
		{
			InputController.InputEnabled = true;
			CloseNow(true);
		}
	}
}
