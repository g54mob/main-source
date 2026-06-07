using System;
using System.IO;
using System.Text.RegularExpressions;
using M4.Session;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TownNamingPanel : InputPanel
{
	[Header("Town Naming Panel")]
	[SerializeField]
	private string _townNameRegex = "";

	[SerializeField]
	private TMP_InputField _townNameInputField;

	[SerializeField]
	private Button _startButton;

	private PlayerRun _activeRun;

	private void OnEnable()
	{
		_activeRun = Session.Profile.ActiveRun;
		_townNameInputField.characterLimit = GameManager.Settings.DataSettings.CommunityCharacterLimit;
		if (string.IsNullOrEmpty(_activeRun.CommunityName) || Session.Profile.HasInactiveRunWithCommunityName(_activeRun.CommunityName))
		{
			RandomizeName();
		}
		else
		{
			SetText(_activeRun.CommunityName);
		}
	}

	public void UI_StartGame()
	{
		if (IsBeingEdited())
		{
			return;
		}
		GameManager.WorldMapManager.WorldMap.ActivateForwardInputWait();
		string text = _townNameInputField.text.Trim();
		if (!Session.Profile.HasInactiveRunWithCommunityName(text))
		{
			if (!_activeRun.SetCommunityName(text))
			{
				Debug.LogException(new Exception("Unable to change community name from '" + _activeRun.CommunityName + "' to '" + text + "'. It seens the active run already has saved games."));
			}
			new GameEvent(GameEventType.NewGameStart).Dispatch();
			Close();
		}
	}

	public void Sanitize(string text)
	{
		_townNameInputField.text = Regex.Replace(text, _townNameRegex, "");
	}

	public void CheckValidity(string text)
	{
		bool flag = !Session.Profile.HasInactiveRunWithCommunityName(text.Trim());
		bool flag2 = text.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
		_startButton.interactable = Application.isEditor || (flag && flag2);
	}

	public void OnCommunityNameUpdated(string text)
	{
		text = text.Trim();
		text = text.SanitizePath();
		_townNameInputField.text = text;
		_startButton.interactable = Application.isEditor || !Session.Profile.HasInactiveRunWithCommunityName(text);
	}

	public void RandomizeName()
	{
		SetText(Session.Profile.TryGetCommunityName(out var communityName) ? communityName : "You Broke our Generator");
	}
}
