using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class lsat : Website
{
	[SerializeField]
	private TMP_InputField q1FirstName;

	[SerializeField]
	private TMP_InputField q1LastName;

	[SerializeField]
	private TMP_InputField q2;

	[SerializeField]
	private TMP_InputField q3;

	[SerializeField]
	private TMP_InputField q4;

	[SerializeField]
	private TMP_InputField q5;

	[SerializeField]
	private Button submitButton;

	[SerializeField]
	private GameObject notificationPrefab;

	private static string[] cachedAnswers = new string[6];

	private static GameObject failPopup;

	private static GameObject successPopup;

	protected override void Start()
	{
		base.Start();
		SetCachedAnswers();
		DelegateInputValidation(q1FirstName);
		DelegateInputValidation(q1LastName);
		DelegateInputValidation(q2);
		DelegateInputValidation(q3);
		DelegateInputValidation(q4);
		DelegateInputValidation(q5, allowSpaces: true);
		HintManager.SetHintState(6, 5);
	}

	public void SubmitAnswers()
	{
		int num = ValidateAnswer();
		if (num != 5)
		{
			LaunchFailNotificationPopup("Test Failed", $"Not everyone can be an expert!\nYou got {num}/5 questions correct.");
		}
		else
		{
			LaunchSuccessNotificationPopup("Success", "Welcome to the Lore Lovin' Merchants!\nLeave a reply on our forum to be a member.\nPassword: <b>newshirecity</b>");
		}
	}

	public void LaunchFailNotificationPopup(string toolbar, string message)
	{
		PlayWarning();
		if (failPopup == null)
		{
			failPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), toolbar, message, NotificationHandler.Icon.ERROR);
		}
		else
		{
			UIUtils.SetTextPopup(failPopup, message);
		}
		PanelManager.OpenWindow(failPopup);
	}

	public void LaunchSuccessNotificationPopup(string toolbar, string message)
	{
		SoundEffectUtils.GetNotificationPlayer().PlayLogin();
		if (successPopup == null)
		{
			successPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), toolbar, message, NotificationHandler.Icon.GENERIC_SUCCESS);
		}
		PanelManager.OpenWindow(successPopup);
	}

	public void CheckEnableSubmit()
	{
		submitButton.interactable = q1FirstName.text.Length > 0 && q1LastName.text.Length > 0 && q2.text.Length > 0 && q3.text.Length > 0 && q4.text.Length > 0 && q5.text.Length > 0;
	}

	private static char ValidateAnswerInput(char charToValidate, bool allowSpaces)
	{
		if (char.IsLetter(charToValidate) || (allowSpaces && charToValidate == ' '))
		{
			return charToValidate;
		}
		return '\0';
	}

	private static void DelegateInputValidation(TMP_InputField input, bool allowSpaces = false)
	{
		input.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(input.onValidateInput, (TMP_InputField.OnValidateInput)((string text, int charIndex, char addedChar) => ValidateAnswerInput(addedChar, allowSpaces)));
	}

	public void CacheAnswers()
	{
		cachedAnswers[0] = q1FirstName.text;
		cachedAnswers[1] = q1LastName.text;
		cachedAnswers[2] = q2.text;
		cachedAnswers[3] = q3.text;
		cachedAnswers[4] = q4.text;
		cachedAnswers[5] = q5.text;
	}

	private void SetCachedAnswers()
	{
		string text = cachedAnswers[0];
		string text2 = cachedAnswers[1];
		string text3 = cachedAnswers[2];
		string text4 = cachedAnswers[3];
		string text5 = cachedAnswers[4];
		string text6 = cachedAnswers[5];
		q1FirstName.text = text;
		q1LastName.text = text2;
		q2.text = text3;
		q3.text = text4;
		q4.text = text5;
		q5.text = text6;
	}

	private int ValidateAnswer()
	{
		int num = 0;
		if (string.Equals(q5.text.Trim(), "diddly dee", StringComparison.OrdinalIgnoreCase))
		{
			num++;
		}
		else if (LevelManager.GetCurrLevel() == 6)
		{
			HintManager.SetHintsGiven(5);
		}
		if (string.Equals(q4.text, "Corrupted", StringComparison.OrdinalIgnoreCase))
		{
			num++;
		}
		else if (LevelManager.GetCurrLevel() == 6)
		{
			HintManager.SetHintsGiven(4);
		}
		if (q3.text.IndexOf("Poison", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			num++;
		}
		else if (LevelManager.GetCurrLevel() == 6)
		{
			HintManager.SetHintsGiven(3);
		}
		if (string.Equals(q2.text, "VitJuice", StringComparison.OrdinalIgnoreCase))
		{
			num++;
		}
		else if (LevelManager.GetCurrLevel() == 6)
		{
			HintManager.SetHintsGiven(2);
		}
		if (string.Equals(q1FirstName.text, "Ford", StringComparison.OrdinalIgnoreCase) && string.Equals(q1LastName.text, "Swamp", StringComparison.OrdinalIgnoreCase))
		{
			num++;
		}
		else if (LevelManager.GetCurrLevel() == 6)
		{
			HintManager.SetHintsGiven(1);
		}
		return num;
	}
}
