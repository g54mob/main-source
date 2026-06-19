using System;
using UnityEngine;

[Serializable]
public class TimeBasedExitCondition : ExitConditionBase
{
	public float time = 1f;

	private float currentTime;

	public override void ResetCondition()
	{
		base.ResetCondition();
		currentTime = 0f;
	}

	public override void UpdateCondition()
	{
		base.UpdateCondition();
		currentTime += Time.deltaTime;
	}

	public override bool ConditionMet(GameObject dog)
	{
		return currentTime >= time;
	}
}
