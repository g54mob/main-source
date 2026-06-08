using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class lzu_apply : Website
{
	[SerializeField]
	private GameObject notificationPrefab;

	[SerializeField]
	private Button applyButton;

	[SerializeField]
	private TMP_InputField firstName;

	[SerializeField]
	private TMP_InputField lastName;

	[SerializeField]
	private TMP_InputField phoneNumber;

	[SerializeField]
	private TMP_InputField address;

	[SerializeField]
	private TMP_InputField netWorth;

	[SerializeField]
	private Toggle termsConditions;

	private static GameObject notificationPopup;

	public static bool APPLIED;

	private void Awake()
	{
		APPLIED = Save.GLOBAL_SAVE.lzua;
		if (APPLIED)
		{
			SetInteractable(interactable: false);
		}
	}

	public void CheckCanApply()
	{
		applyButton.interactable = firstName.text.Length != 0 && lastName.text.Length != 0 && phoneNumber.text.Length != 0 && address.text.Length != 0 && netWorth.text.Length != 0 && termsConditions.isOn;
	}

	public void LaunchNotificationPopup()
	{
		bool num = int.Parse(netWorth.text) > 10000;
		string inputText = (num ? "Your application has been successful!\nWelcome to the 1999 class of Los Zorangeles University!\nWe will send you more information shortly." : "Thank you for your application.\nResponses will be sent in 3-5 business years.");
		if (num)
		{
			SoundEffectUtils.GetNotificationPlayer().PlayLogin();
		}
		else
		{
			SoundEffectUtils.GetNotificationPlayer().PlayWarning();
		}
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Application Submitted", inputText, NotificationHandler.Icon.GENERIC_SUCCESS);
		}
		PanelManager.OpenWindow(notificationPopup);
		APPLIED = true;
		Save.GLOBAL_SAVE.lzua = true;
		SetInteractable(interactable: false);
		Save.SaveGame();
	}

	public void SetInteractable(bool interactable)
	{
		applyButton.interactable = interactable;
		firstName.interactable = interactable;
		lastName.interactable = interactable;
		phoneNumber.interactable = interactable;
		address.interactable = interactable;
		netWorth.interactable = interactable;
		termsConditions.interactable = interactable;
	}
}
