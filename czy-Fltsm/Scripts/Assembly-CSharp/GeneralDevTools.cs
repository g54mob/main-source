using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneralDevTools : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _survivalGuideIDField;

	[SerializeField]
	private Toggle _autosaveToggle;

	[SerializeField]
	private Toggle _resourceVisualToggle;

	private static GeneralDevTools _instance;

	private static bool _disableAutosave;

	public static bool ResourceVisualsDisabled
	{
		get
		{
			if (DevTools.Unlocked && (bool)_instance && (bool)_instance._resourceVisualToggle)
			{
				return !_instance._resourceVisualToggle.isOn;
			}
			return false;
		}
	}

	public static bool DisableAutosave
	{
		get
		{
			if (DevTools.Unlocked)
			{
				return _disableAutosave;
			}
			return false;
		}
	}

	private void Awake()
	{
		GameEventDispatcher.AddListener(GameEventType.SurvivalGuidePageOpened, OnSuvivalGuidePageOpened);
		if (_resourceVisualToggle != null)
		{
			_resourceVisualToggle.onValueChanged.AddListener(OnResourceVisualsToggled);
		}
		_instance = this;
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.SurvivalGuidePageOpened, OnSuvivalGuidePageOpened);
		if (_instance == this)
		{
			_instance = null;
		}
	}

	public void SetSpeed(int speedIndex)
	{
		GameSpeedManager.SetGameSpeed((GameSpeed)speedIndex, sendEvent: false);
	}

	public void TogglePauseWater()
	{
		WaterManager.Instance.PauseWater();
	}

	public void ToggleDisableAutosave(bool disableAutosave)
	{
		_disableAutosave = disableAutosave;
	}

	public void TriggerAutosave()
	{
		Debug.LogException(new NotImplementedException());
	}

	public void SetGameTime(float time)
	{
		GameManager.TimeManager.CurrentDay.SetPercentualTime(time);
	}

	public void NextDay()
	{
		GameManager.TimeManager.NextDay();
	}

	public void ResetAchievements()
	{
	}

	private void OnSuvivalGuidePageOpened(GameEvent gameEvent)
	{
		if ((bool)_survivalGuideIDField && gameEvent is StringEvent stringEvent)
		{
			_survivalGuideIDField.text = stringEvent.Data;
		}
	}

	private void OnResourceVisualsToggled(bool value)
	{
		GameEventDispatcher.Dispatch(GameEventType.DevTools_UpdateResourceVisuals);
	}
}
