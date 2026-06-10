using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeEffectController : MonoBehaviour
{
	[Serializable]
	public class AppliedEffect
	{
		public UpgradesController.Upgrades disk;

		public SyncDiskPreset.Effect effect;

		public float value;
	}

	[Header("New Upgrades System")]
	public List<AppliedEffect> appliedEffects;

	private static UpgradeEffectController _instance;

	public static UpgradeEffectController Instance => null;

	public void OnInstall(UpgradesController.Upgrades disk, SyncDiskPreset.Effect effect, float value)
	{
	}

	public void OnUninstall(UpgradesController.Upgrades disk, SyncDiskPreset.Effect effect, float value)
	{
	}

	public void OnUpgrade(UpgradesController.Upgrades disk, SyncDiskPreset.UpgradeEffect effect, float value, int level)
	{
	}

	public void OnSyncDiskChange(bool forceUpdate = false)
	{
	}

	private void Awake()
	{
	}

	public float GetUpgradeEffect(SyncDiskPreset.Effect effect)
	{
		return 0f;
	}
}
