using System;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Rewired;
using Steamworks;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
	protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;

	public PauseUi pauseUi;

	private void Start()
	{
		if (SteamManager.initialized)
		{
			Callback<GameOverlayActivated_t>.DispatchDelegate func = OnGameOverlayActivated;
			Callback<GameOverlayActivated_t> gameOverlayActivated = Callback<GameOverlayActivated_t>.Create(func);
			m_GameOverlayActivated = gameOverlayActivated;
		}
		Action<ControllerStatusChangedEventArgs> value = OnControllerDisconnected;
		ReInput.ControllerDisconnectedEvent += value;
	}

	private void OnDestroy()
	{
		if (m_GameOverlayActivated != null)
		{
			m_GameOverlayActivated.Dispose();
		}
		Action<ControllerStatusChangedEventArgs> value = OnControllerDisconnected;
		ReInput.ControllerDisconnectedEvent -= value;
	}

	private void OnControllerDisconnected(ControllerStatusChangedEventArgs args)
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFControlSettings cfControlSettings = config.cfControlSettings;
		if (cfControlSettings.pause_on_controller_disconnect != 0 && args.TBJGBmgQOKlmSbcCWSMuasdljEDyA == ControllerType.Joystick)
		{
			pauseUi.Pause();
		}
	}

	private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
	{
		if (pCallback.m_bActive != 0)
		{
			pauseUi.Pause();
		}
	}
}
