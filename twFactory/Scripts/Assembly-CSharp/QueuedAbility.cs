using System;
using UnityEngine;

[Serializable]
public struct QueuedAbility
{
	[SerializeField]
	public ActiveAbility ability;

	[SerializeField]
	public FActiveAbilityInputData inputData;

	public QueuedAbility(ActiveAbility ability, FActiveAbilityInputData inputData)
	{
		this.ability = ability;
		this.inputData = inputData;
	}
}
