using System;
using Data.FactoryFloor.Resources;
using UnityEngine;

[Serializable]
public class ObjectiveTargetItem
{
	public uint Amount;

	public uint AmountStartOffset;

	public uint XpReward;

	public uint CurrencyReward;

	public NonShapeResourceDataSO CurrenyRewardResourceData;

	[Header("Demo Only:")]
	public bool Active = true;

	public uint RequiredAmount => Amount + AmountStartOffset;
}
