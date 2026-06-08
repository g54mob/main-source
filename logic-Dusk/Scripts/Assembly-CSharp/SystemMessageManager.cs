using System;
using System.Collections.Generic;
using UnityEngine;

public class SystemMessageManager
{
	public const int MAX_SYSTEM_MESSSAGES = 4;

	public static SystemMessageManager Instance;

	public Texture _warningImage;

	public Texture _sensorNotificationImage;

	private List<SingleSystemMessage> _messages = new List<SingleSystemMessage>();

	private DungeonManager _dungeonManager;

	private WeakReference _gameplayManagerWeakReference;

	private GUIStyle _textColorStyle;

	private List<SingleSystemMessage> _messagesToDelete = new List<SingleSystemMessage>(10);

	private GameplayManager GPManager
	{
		get
		{
			return (GameplayManager)_gameplayManagerWeakReference.Target;
		}
	}

	private SystemMessageManager()
	{
		_textColorStyle = new GUIStyle();
		_textColorStyle.font = ResourceManager.LoadAsset<Font>("Fonts/WHITRABT");
	}

	public static void Initialize()
	{
		if (Instance == null)
		{
			Instance = new SystemMessageManager();
		}
	}

	public void LoadResources()
	{
		_dungeonManager = DungeonManager.Instance;
		_gameplayManagerWeakReference = new WeakReference(GameplayManager.Instance);
		_warningImage = ResourceManager.LoadAsset<Texture>("warning-sign-md");
		_sensorNotificationImage = ResourceManager.LoadAsset<Texture>("Sensor_icon");
	}

	public static void ShowSystemMessage(string message, ConsoleMessageType type)
	{
		Instance.ShowSystemMessageInternal(message, type, SystemMessageImageType.WarningTriangle);
	}

	public static void ShowSystemMessage(string message, ConsoleMessageType type, SystemMessageImageType imageType)
	{
		Instance.ShowSystemMessageInternal(message, type, imageType);
	}

	public static void ClearAllMessages()
	{
		Instance._messages.Clear();
	}

	public void Update()
	{
		if (_messages.Count > 0)
		{
			if (!GameplayManagerGUI.Instance.enabled)
			{
				GameplayManagerGUI.Instance.Enable();
			}
			_messagesToDelete.Clear();
			foreach (SingleSystemMessage message in _messages)
			{
				message.ShowTimer -= Time.deltaTime;
				if (message.ShowTimer <= 0f)
				{
					_messagesToDelete.Add(message);
				}
			}
			_messagesToDelete.ForEach(delegate(SingleSystemMessage x)
			{
				_messages.Remove(x);
			});
		}
		else if (!GlobalSettings.GameIsOver && GameplayManagerGUI.Instance.enabled)
		{
			GameplayManagerGUI.Instance.Disable();
		}
	}

	internal void ShowSystemMessageInternal(string message, ConsoleMessageType type, SystemMessageImageType imageType)
	{
		switch (type)
		{
		case ConsoleMessageType.Warning:
		case ConsoleMessageType.JIL_Warning:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.AlertWarning);
			break;
		case ConsoleMessageType.TriggerActivatedWarning:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.SensorTriggered);
			break;
		case ConsoleMessageType.TriggerDeactivatedWarning:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.SensorUntriggered);
			break;
		case ConsoleMessageType.UpgradeStateChange:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
			break;
		case ConsoleMessageType.DisasterWarning:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.EventRadiation);
			break;
		case ConsoleMessageType.Benefit:
		case ConsoleMessageType.Notification:
		case ConsoleMessageType.JIL_Good:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.Notification);
			break;
		case ConsoleMessageType.Error:
		case ConsoleMessageType.JIL_Error:
			GameAudio.Play2DSFX(GameAudio.SoundEnum.AlertError);
			break;
		}
		SingleSystemMessage singleSystemMessage = new SingleSystemMessage();
		singleSystemMessage.ShowTimer = 2f;
		singleSystemMessage.MessageText = message;
		singleSystemMessage.SystemMessageType = type;
		singleSystemMessage.ImageType = imageType;
		singleSystemMessage.MessageTexture = GetImageForSystemMessage(imageType);
		SingleSystemMessage item = singleSystemMessage;
		while (_messages.Count >= 4)
		{
			_messages.RemoveAt(0);
		}
		_messages.Add(item);
		DungeonManager.Instance.SendConsoleMessage(message, type);
	}

	private void DrawAllSystemMessagesOnScreen()
	{
		int count = _messages.Count;
		int num = 0;
		float xPos = Screen.width / 2 - 150;
		float num2 = 20f;
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			num2 = 125f;
		}
		foreach (SingleSystemMessage message in _messages)
		{
			bool drawIcon = ++num == count;
			DrawSystemMessageOnScreen(message, xPos, num2, drawIcon);
			num2 += 28f;
		}
	}

	private void DrawSystemMessageOnScreen(SingleSystemMessage message, float xPos, float yPos, bool drawIcon)
	{
		Color color = Color.white;
		switch (message.SystemMessageType)
		{
		case ConsoleMessageType.Info:
			color = Color.white;
			break;
		case ConsoleMessageType.Warning:
		case ConsoleMessageType.UpgradeStateChange:
			color = Color.yellow;
			break;
		case ConsoleMessageType.Error:
			color = Color.red;
			break;
		case ConsoleMessageType.Notification:
			color = new Color(0.5f, 1f, 0.5f);
			break;
		case ConsoleMessageType.Benefit:
			color = Color.blue;
			break;
		}
		_textColorStyle.normal.textColor = color;
		GUI.Label(new Rect(xPos, yPos, 300f, 25f), message.MessageText, _textColorStyle);
		if (drawIcon && message.MessageTexture != null)
		{
			Color color2 = GUI.color;
			GUI.color = color;
			Rect position;
			if (GlobalSettings.cameraMode == CameraMode.Schematic)
			{
				position = GPManager.GetConsoleWindowRect();
				position.x += position.width / 2f;
				position.width /= 2f;
				position.height /= 2f;
			}
			else
			{
				position = new Rect(Screen.width / 2, 45f, 50f, 50f);
			}
			GUI.DrawTexture(position, message.MessageTexture);
			GUI.color = color2;
		}
	}

	private Texture GetImageForSystemMessage(SystemMessageImageType imageType)
	{
		switch (imageType)
		{
		case SystemMessageImageType.SensorNotify:
			return _sensorNotificationImage;
		case SystemMessageImageType.WarningTriangle:
			return _warningImage;
		default:
			return null;
		}
	}
}
