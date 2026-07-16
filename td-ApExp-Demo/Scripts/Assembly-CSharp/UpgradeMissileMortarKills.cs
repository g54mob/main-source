using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MissileMortarKills", menuName = "Upgrade/Mixed/MissileMortarKills")]
public class UpgradeMissileMortarKills : EnhancementUpgrade
{
	private ModuleMissile missile;

	private ModuleMortar mortar;

	public override void ApplyUpgrade()
	{
		ModuleMissile moduleByType = Train.Instance.GetModuleByType<ModuleMissile>();
		if ((object)moduleByType != null)
		{
			missile = moduleByType;
			moduleByType.ExplosionKill += OnMissileKill;
		}
		ModuleMortar moduleByType2 = Train.Instance.GetModuleByType<ModuleMortar>();
		if ((object)moduleByType2 != null)
		{
			mortar = moduleByType2;
			moduleByType2.OnExplosionKill = (Delegates.HealthChangeHandler)Delegate.Combine(moduleByType2.OnExplosionKill, new Delegates.HealthChangeHandler(OnMortarKill));
		}
	}

	private void OnMissileKill(HealthChangeInfo info)
	{
		mortar.SpawnProjectile(info.Hit.Value.point);
	}

	private void OnMortarKill(HealthChangeInfo info)
	{
		missile.SpawnMissile();
	}
}
