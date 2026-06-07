using System;
using MessagePipe;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class ProfileEntry : MonoBehaviour
{
	[SerializeField]
	private Button play;

	[SerializeField]
	private Button delete;

	[SerializeField]
	private LocalizedString newGameLabel;

	[SerializeField]
	private TMP_Text text;

	private int _profile;

	private MetaFileDto _meta;

	private IDisposable _subscription;

	private string _newGameLabelText;

	public void Setup(int profile)
	{
		_profile = profile;
		try
		{
			_meta = SaveSystem.LoadMeta(profile);
		}
		catch (SaveFileException e)
		{
			ApplicationController.CorruptedProfile(e);
		}
		play.onClick.AddListener(SelectProfile);
		delete.onClick.AddListener(delegate
		{
			EventHub.Scene.Publish(new ProfileConfirmDeletion(_profile, _meta?.StudioName));
		});
		EventHub.Scene.Subscribe(HandleProfileDeleted, Array.Empty<MessageHandlerFilter<ProfileDeleted>>()).AddTo(this);
		newGameLabel.StringChanged += OnNewGameLabelChanged;
		Refresh();
	}

	private void OnDestroy()
	{
		newGameLabel.StringChanged -= OnNewGameLabelChanged;
	}

	private void OnNewGameLabelChanged(string value)
	{
		_newGameLabelText = value;
		Refresh();
	}

	private void SelectProfile()
	{
		if (_meta == null)
		{
			EventHub.Scene.Publish(new ProfileCreated(_profile));
		}
		else
		{
			EventHub.Scene.Publish(new ProfileLoaded(_profile));
		}
	}

	private void HandleProfileDeleted(ProfileDeleted ctx)
	{
		if (ctx.Profile == _profile)
		{
			_meta = null;
			Refresh();
		}
	}

	private void Refresh()
	{
		delete.gameObject.SetActive(_meta != null);
		text.SetText(_meta?.StudioName ?? _newGameLabelText);
	}
}
