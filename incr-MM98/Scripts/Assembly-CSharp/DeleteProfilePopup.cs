using System;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class DeleteProfilePopup : Popup
{
	[SerializeField]
	private Button cancel;

	[SerializeField]
	private Button confirm;

	[SerializeField]
	private LocalizeStringHandler textHandler;

	private int _profile;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(cancel).AddListener(OnCancel).Context(confirm)
			.AddListener(OnSubmit);
		EventHub.Scene.Subscribe(HandleProfileConfirmDeletion, Array.Empty<MessageHandlerFilter<ProfileConfirmDeletion>>()).AddTo(this);
	}

	private void HandleProfileConfirmDeletion(ProfileConfirmDeletion ctx)
	{
		_profile = ctx.Profile;
		textHandler.SetValue("studioname", ctx.Studio);
		ShowContent();
	}

	protected override void OnSubmit()
	{
		base.OnSubmit();
		SaveSystem.DeleteProfile(_profile);
		EventHub.Scene.Publish(new ProfileDeleted(_profile));
		HideContent();
	}
}
