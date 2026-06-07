using System;
using UnityEngine;

[Serializable]
public struct FActiveAbilityInputData
{
	public CombatComponent target;

	public Vector3 position;

	public FActiveAbilityInputData(CombatComponent target, Vector3 position)
	{
		this.target = target;
		this.position = position;
	}
}
