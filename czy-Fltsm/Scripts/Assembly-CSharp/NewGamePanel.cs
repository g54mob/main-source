using System;
using UnityEngine;
using UnityEngine.Events;

public class NewGamePanel : Panel
{
	[SerializeField]
	private TownheartSelector _townheartSelector;

	[SerializeField]
	private CharacterSelector _characterSelector;

	public override void Initialize()
	{
		base.gameObject.SetActive(value: true);
		GameManager.UIManager.DisableUI();
		GameManager.UIManager.PauseGame(UIState.GameTimePaused);
		if ((bool)_townheartSelector && _townheartSelector.Activate())
		{
			TownheartSelector townheartSelector = _townheartSelector;
			townheartSelector.TownheartSelected = (UnityAction)Delegate.Combine(townheartSelector.TownheartSelected, new UnityAction(OnTownheartSelected));
		}
		else
		{
			OnTownheartSelected();
		}
		CameraController.Instance.LoadPreset();
	}

	public void StartGame()
	{
		base.gameObject.SetActive(value: false);
		GameManager.UIManager.EnableUI();
		GameManager.UIManager.UnpauseGame();
		CharacterPreview[] agentPreviews = _characterSelector.AgentPreviews;
		foreach (CharacterPreview characterPreview in agentPreviews)
		{
			GameManager.AgentManager.SpawnStartingAgent(characterPreview.AgentDescriptor);
		}
		Community.PlayerCommunity?.QueueGlobalProjects(GameSettings.Instance.ProjectSettings);
		GameEventDispatcher.Dispatch(GameEventType.NewGamePanelClosed);
	}

	private void OnTownheartSelected()
	{
		if ((bool)_townheartSelector)
		{
			TownheartSelector townheartSelector = _townheartSelector;
			townheartSelector.TownheartSelected = (UnityAction)Delegate.Remove(townheartSelector.TownheartSelected, new UnityAction(OnTownheartSelected));
		}
		_characterSelector.gameObject.SetActive(value: true);
		_characterSelector.Initialize();
	}
}
