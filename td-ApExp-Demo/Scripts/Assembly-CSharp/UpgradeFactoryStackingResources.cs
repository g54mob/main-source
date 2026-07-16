using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FactoryStackingResources", menuName = "Upgrade/Factory/StackingResources")]
public class UpgradeFactoryStackingResources : EnhancementUpgrade
{
	[SerializeField]
	private float resourceGainIncreasePercent;

	[NonSerialized]
	private ModuleFactory factory;

	public override void ApplyUpgrade()
	{
		factory = Train.Instance.GetModuleByType<ModuleFactory>();
		EnemyManager.Instance.EnemyEMPd += IncreaseResourceGain;
		LevelManager.Instance.LevelStarted += ResetGainModifier;
	}

	private void IncreaseResourceGain(EnemyBase enemy)
	{
		factory.gainModifier += resourceGainIncreasePercent;
	}

	private void ResetGainModifier()
	{
		factory.gainModifier = 1f;
	}
}
