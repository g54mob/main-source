using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class CanvasScaleSetter : MonoBehaviour
{
	[SerializeField]
	private UISettings _uiSettings;

	private Canvas _canvas;

	private float _scaleModifier;

	private float _screenWidth;

	private float _screenHeight;

	private bool _updateCanvasScaleFactor;

	private void Awake()
	{
		_canvas = GetComponentInChildren<Canvas>();
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.UIScaleSettingChanged, OnSettingsEvent);
		StartCoroutine(SetCanvasScaleFromPlayerData());
	}

	private void Update()
	{
		int width = Screen.width;
		int height = Screen.height;
		if ((float)width != _screenWidth || (float)height != _screenHeight)
		{
			SetCanvasScale(_scaleModifier);
			_screenWidth = width;
			_screenHeight = height;
		}
		if (_updateCanvasScaleFactor && UpdateCanvasScaleFactor())
		{
			_updateCanvasScaleFactor = false;
		}
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.UIScaleSettingChanged, OnSettingsEvent);
	}

	private void OnSettingsEvent(GameEvent gameEvent)
	{
		if (gameEvent is SettingsEvent { EventType: GameEventType.UIScaleSettingChanged } settingsEvent)
		{
			SetCanvasScale(settingsEvent.UIScale);
		}
	}

	public void SetCanvasScale(float scaleModifier)
	{
		_scaleModifier = scaleModifier;
		_updateCanvasScaleFactor = true;
	}

	public bool UpdateCanvasScaleFactor()
	{
		if (_uiSettings == null)
		{
			_uiSettings = GameManager.Settings.UISettings;
		}
		if ((bool)_uiSettings)
		{
			_canvas.scaleFactor = _uiSettings.ReturnDefaultUIScale() * _scaleModifier;
			return true;
		}
		_canvas.scaleFactor = _scaleModifier;
		return false;
	}

	public IEnumerator SetCanvasScaleFromPlayerData()
	{
		while (!Settings.IsInitialized || _uiSettings == null)
		{
			if ((bool)GameManager.Settings)
			{
				_uiSettings = GameManager.Settings.UISettings;
			}
			yield return null;
		}
		SetCanvasScale(Settings.Instance.GraphicsPlayerData.UIScale);
	}
}
