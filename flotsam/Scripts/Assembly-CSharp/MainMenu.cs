using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using I2.Loc;
using M4.Session;
using PajamaLlama.Fltsm;
using PajamaLlama.Fltsm.UI;
using PajamaLlama.Plugins.Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MainMenu : MonoBehaviour
{
	[Header("Components")]
	[Tooltip("Changelog component for the main menu.")]
	[SerializeField]
	private ChangeLog _changeLog;

	[SerializeField]
	private DialogProperties _inputVersionNotifiction;

	[FormerlySerializedAs("_saveMigrationPanel")]
	[SerializeField]
	private SaveMigrationPanel _saveMigrationNotification;

	[Tooltip("Reference to the Continue button")]
	[SerializeField]
	private GameObject _continueButton;

	[SerializeField]
	private TextMeshProUGUI _continueSaveName;

	[SerializeField]
	private LocalizedString _continueSaveTerm = null;

	[SerializeField]
	private GameObject _loadButton;

	[SerializeField]
	private GameObject _debugButton;

	[Tooltip("Reference to the settings panel.")]
	[SerializeField]
	public MasterSettingsWindow SettingsPanels;

	[Header("New Game")]
	[SerializeField]
	private GameSetup _gameSetup;

	[SerializeField]
	private GameSetupPanel _gameSetupPanel;

	private FMODEvent _musicEvent;

	private FMODEvent _ambienceEvent;

	private PlayerRun _mostRecentlySavedRun;

	private Queue<Object> _notificationQueue;

	private void Awake()
	{
		_changeLog.Initialize();
		_debugButton.gameObject.SetActive(Application.isEditor);
		OnSaveUpdate();
		GameEventDispatcher.AddListener(GameEventType.SessionInitialized, OnSaveUpdate);
		GameEventDispatcher.AddListener(GameEventType.SaveAdded, OnSaveUpdate);
		GameEventDispatcher.AddListener(GameEventType.SaveRemoved, OnSaveUpdate);
		GameEventDispatcher.AddListener(GameEventType.SaveOverwritten, OnSaveUpdate);
		GameEventDispatcher.AddListener(GameEventType.SavesMigrated, OnSaveUpdate);
		GameEventDispatcher.AddListener(GameEventType.GameStartedLoading, OnGameStart);
	}

	private IEnumerator Start()
	{
		_musicEvent = new FMODEvent(GameManager.Settings.AudioSettings.MenuMusic);
		_musicEvent.Start();
		_ambienceEvent = new FMODEvent(GameManager.Settings.AudioSettings.MenuAmbience);
		_ambienceEvent.Start();
		while (Settings.Instance == null)
		{
			yield return null;
		}
		if (UserDataStore_PlayerPrefs_Versioned.HasBeenReset)
		{
			QueueNotification(_inputVersionNotifiction);
		}
		if (SaveFileMigration.ReturnRequiresMigration())
		{
			QueueNotification(_saveMigrationNotification);
		}
		if (SettingsPanels != null)
		{
			SettingsPanels.LoadSettings();
		}
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.SaveAdded, OnSaveUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.SaveRemoved, OnSaveUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.SaveOverwritten, OnSaveUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.SavesMigrated, OnSaveUpdate);
		GameEventDispatcher.RemoveListener(GameEventType.GameStartedLoading, OnGameStart);
	}

	private void OnGameStart(GameEvent e = null)
	{
		if (_musicEvent != null)
		{
			_musicEvent.Stop();
		}
		if (_ambienceEvent != null)
		{
			_ambienceEvent.Stop();
		}
		AudioManager.Play(GameManager.Settings.AudioSettings.GameStartSound);
	}

	private void OnSaveUpdate(GameEvent e = null)
	{
		bool flag = Session.Profile != null && Session.Profile.HasRuns;
		_loadButton.SetActive(flag);
		_continueButton.SetActive(flag);
		if (flag)
		{
			UpdateMostRecentSave();
		}
	}

	private void UpdateMostRecentSave()
	{
		if (Session.TryGetMostRecentlySavedRun(out _mostRecentlySavedRun))
		{
			_continueSaveName.text = Regex.Replace(_mostRecentlySavedRun.CommunityName + ": " + _continueSaveTerm, "%DAY%", _mostRecentlySavedRun.MostRecentSave.Day.ToString(), RegexOptions.IgnoreCase);
		}
	}

	public void ContinueMostRecentSave()
	{
		if (_mostRecentlySavedRun != null)
		{
			_mostRecentlySavedRun.Continue();
		}
	}

	public void StartGame(TileProperties tileProperties)
	{
		StartGame(_gameSetup);
	}

	public void StartTutorial(TileProperties tileProperties)
	{
		_gameSetup.IsTutorial = true;
		StartGame(_gameSetup);
	}

	public void StartDebug(TileProperties tileProperties)
	{
		WorldManager.SetTileProperties(tileProperties);
		Session.Profile.StartDebugRun();
	}

	public void QuitGame()
	{
		GameManager.QuitToDesktop();
	}

	private void StartGame(GameSetup gameSetup)
	{
		if (_gameSetupPanel == null || !_gameSetupPanel.Activate(gameSetup))
		{
			Session.Profile.StartRun(gameSetup);
		}
	}

	private void QueueNotification(Object notification)
	{
		if (_notificationQueue == null)
		{
			_notificationQueue = new Queue<Object>(2);
			_notificationQueue.Enqueue(notification);
			StartCoroutine(NotificationCoroutine());
		}
		else
		{
			_notificationQueue.Enqueue(notification);
		}
	}

	private IEnumerator NotificationCoroutine()
	{
		if (_notificationQueue == null)
		{
			yield break;
		}
		while (0 < _notificationQueue.Count)
		{
			Object obj = _notificationQueue.Dequeue();
			if (obj is SaveMigrationPanel saveMigrationPanel)
			{
				saveMigrationPanel.gameObject.SetActive(value: true);
				while (saveMigrationPanel.isActiveAndEnabled)
				{
					yield return null;
				}
			}
			else if (obj is DialogProperties properties)
			{
				PopUpDialog.Instance.TryOpenPopUpDialog(properties);
				while (!PopUpDialog.Instance.CanPopup)
				{
					yield return null;
				}
			}
		}
	}
}
