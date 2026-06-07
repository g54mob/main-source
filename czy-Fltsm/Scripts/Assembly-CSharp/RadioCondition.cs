using System;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class RadioCondition : IScenarioTriggerableCondition
{
	[SerializeField]
	[Tooltip("The number of days the Radio must have been built")]
	private int _radioBuiltDays;

	[SerializeField]
	private int _totalDays;

	public bool IsMet()
	{
		int count = GameManager.TimeManager.Days.Count;
		int radioBuiltDay = GameManager.RadioMessagesManager.RadioBuiltDay;
		if (radioBuiltDay < 0 || count - radioBuiltDay < _radioBuiltDays)
		{
			return count >= _totalDays;
		}
		return true;
	}
}
