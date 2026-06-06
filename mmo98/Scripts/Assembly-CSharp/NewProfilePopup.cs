using System;
using MessagePipe;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewProfilePopup : Popup
{
	[SerializeField]
	private Button cancel;

	[SerializeField]
	private Button confirm;

	[SerializeField]
	private TMP_InputField studioField;

	[SerializeField]
	private Toggle tutorialEnabled;

	private int _profile;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(cancel).AddListener(OnCancel).Context(confirm)
			.AddListener(OnSubmit)
			.Context(studioField)
			.OnEndEdit(OnStudioNameChanged);
		EventHub.Scene.Subscribe(HandleProfileCreated, Array.Empty<MessageHandlerFilter<ProfileCreated>>()).AddTo(this);
	}

	private void HandleProfileCreated(ProfileCreated ctx)
	{
		_profile = ctx.Profile;
		ShowContent();
	}

	protected override void OnSubmit()
	{
		if (!string.IsNullOrEmpty(studioField.text))
		{
			Database.Load(_profile, studioField.text, tutorialEnabled.isOn);
		}
	}

	public override void ShowContent()
	{
		base.ShowContent();
		EventSystem.current.SetSelectedGameObject(studioField.gameObject);
		if (DebugMode.StudioName)
		{
			studioField.text = "Editor Studio";
			confirm.interactable = true;
		}
	}

	private void OnStudioNameChanged(string studio)
	{
		confirm.interactable = !string.IsNullOrEmpty(studio);
	}
}
