using System;
using System.Collections.Generic;
using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.UI;

public class ProfilesPopup : Popup
{
	[SerializeField]
	private Button cancel;

	[SerializeField]
	private List<ProfileEntry> profiles = new List<ProfileEntry>();

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		cancel.onClick.AddListener(OnCancel);
		EventHub.Scene.Subscribe(HandleProfileLoaded, Array.Empty<MessageHandlerFilter<ProfileLoaded>>()).AddTo(this);
		for (int i = 0; i < profiles.Count; i++)
		{
			profiles[i].Setup(i);
		}
	}

	private void HandleProfileLoaded(ProfileLoaded ctx)
	{
		Database.Load(ctx.Profile);
	}
}
