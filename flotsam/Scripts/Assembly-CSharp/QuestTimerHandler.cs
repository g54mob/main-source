using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class QuestTimerHandler : ILocalizationParamsManager
{
	[SerializeField]
	private GameObject _timer;

	[SerializeField]
	private Localize _timerValue;

	private int _remainingDaysCount;

	~QuestTimerHandler()
	{
		GameEventDispatcher.RemoveListener(GameEventType.DayEnded, UpdateDisplay);
	}

	public bool IsActive()
	{
		return _timer.activeSelf;
	}

	public void SetActive(bool active, int remainingDaysCount = 0)
	{
		if (active != _timer.activeSelf)
		{
			if (active)
			{
				LocalizationManager.ParamManagers.Add(this);
				_remainingDaysCount = remainingDaysCount;
				_timer.SetActive(value: true);
				GameEventDispatcher.AddListener(GameEventType.DayEnded, UpdateDisplay);
			}
			else
			{
				LocalizationManager.ParamManagers.Remove(this);
				_timer.SetActive(value: false);
				GameEventDispatcher.RemoveListener(GameEventType.DayEnded, UpdateDisplay);
			}
		}
	}

	string ILocalizationParamsManager.GetParameterValue(string Param)
	{
		if (!(Param == "DAYSREMAINING"))
		{
			if (Param == "HOURSREMAINING")
			{
				return "0";
			}
			return null;
		}
		return _remainingDaysCount.ToString();
	}

	private void UpdateDisplay(GameEvent gameEvent = null)
	{
		if (--_remainingDaysCount > 0)
		{
			_timerValue.OnLocalize(Force: true);
		}
		else
		{
			SetActive(active: false);
		}
	}
}
