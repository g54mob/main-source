using System;
using UnityEngine;

[Serializable]
public class RandomTimeBasedExitCondition : TimeBasedExitCondition
{
	public float lowTime;

	public float highTime = 1f;

	public override void ResetCondition()
	{
		base.ResetCondition();
		ChooseNewTargetTime();
	}

	private void ChooseNewTargetTime()
	{
		time = UnityEngine.Random.Range(lowTime, highTime);
	}
}
