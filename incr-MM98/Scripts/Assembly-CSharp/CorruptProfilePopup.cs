using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CorruptProfilePopup : Popup
{
	[SerializeField]
	private Button discordButton;

	[SerializeField]
	private Button steamDiscussionsButton;

	[SerializeField]
	private Button profileFolderButton;

	[SerializeField]
	private Button copyStackTraceButton;

	[SerializeField]
	private TMP_Text stacktrace;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		discordButton.onClick.AddListener(ApplicationController.OpenDiscord);
		steamDiscussionsButton.onClick.AddListener(ApplicationController.OpenDiscussions);
		profileFolderButton.onClick.AddListener(delegate
		{
			Application.OpenURL(Application.persistentDataPath);
		});
		copyStackTraceButton?.onClick.AddListener(delegate
		{
			GUIUtility.systemCopyBuffer = stacktrace.text;
		});
	}

	public void ShowContentWithData(Exception exception)
	{
		ShowContent();
		stacktrace.text = exception.ToString();
		Debug.LogException(exception);
	}
}
