using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class amphibies : Website
{
	[SerializeField]
	protected GameObject notificationPrefab;

	[SerializeField]
	protected TMP_InputField username;

	[SerializeField]
	protected TMP_InputField password;

	[SerializeField]
	protected TMP_InputField comment;

	[SerializeField]
	protected Button commentButton;

	[SerializeField]
	protected TextMeshProUGUI commentText;

	protected static GameObject notificationPopup;

	protected override void Start()
	{
		base.Start();
		AddInputListener(username, CheckEnableComment);
		AddInputListener(password, CheckEnableComment);
		AddInputListener(comment, CheckEnableComment);
		commentButton.onClick.AddListener(ShowErrorMessage);
	}

	private void AddInputListener(TMP_InputField input, Action<string> action)
	{
		if (!(input == null))
		{
			input.onValueChanged.AddListener(CheckEnableComment);
		}
	}

	public virtual void CheckEnableComment(string text)
	{
		bool flag = username.text.Length > 0 && password.text.Length > 0;
		comment.interactable = flag;
		commentButton.interactable = comment.text.Length > 0 && flag;
		commentText.color = (commentButton.interactable ? Color.black : ((Color)new Color32(50, 50, 50, 130)));
	}

	public virtual void ShowErrorMessage()
	{
		PlayWarning();
		if (notificationPopup == null)
		{
			notificationPopup = UIUtils.LaunchTextPopup(notificationPrefab, UIUtils.FindCanvasFromChild(base.transform), "Error", "No FROG BLOG member found with\nthe given username or password.", NotificationHandler.Icon.ERROR);
		}
		PanelManager.OpenWindow(notificationPopup);
	}
}
