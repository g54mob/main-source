using UnityEngine;

public class amphibies_membership : amphibies
{
	private static bool hasApplied;

	private static string applicationText;

	private void Awake()
	{
		if (hasApplied)
		{
			comment.text = applicationText;
			DisableInputs();
		}
	}

	public override void CheckEnableComment(string text)
	{
		commentButton.interactable = comment.text.Length > 0;
		commentText.color = (commentButton.interactable ? Color.black : ((Color)new Color32(50, 50, 50, 130)));
	}

	private void DisableInputs()
	{
		comment.interactable = false;
		commentButton.interactable = false;
		commentText.color = new Color32(50, 50, 50, 130);
	}

	public override void ShowErrorMessage()
	{
		string inputText = "You have just applied to be a member of my\n<b><i>FROG BLOG!!!!</b></i> Come back in one week to\nsee if I accepted your application";
		notifPlayer.PlayLogin();
		if (amphibies.notificationPopup == null)
		{
			amphibies.notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Application Submitted", inputText, NotificationHandler.Icon.GENERIC_SUCCESS);
		}
		PanelManager.OpenWindow(amphibies.notificationPopup);
		hasApplied = true;
		applicationText = comment.text;
		DisableInputs();
	}
}
