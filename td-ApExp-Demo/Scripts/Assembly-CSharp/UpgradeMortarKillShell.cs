using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MortarKillShell", menuName = "Upgrade/Mortar/KillShell")]
public class UpgradeMortarKillShell : EnhancementUpgrade
{
	[SerializeField]
	private float killShellProb = 0.5f;

	private ModuleMortar mortar;

	public override void ApplyUpgrade()
	{
		ModuleMortar moduleByType = Train.Instance.GetModuleByType<ModuleMortar>();
		if ((object)moduleByType != null)
		{
			mortar = moduleByType;
			moduleByType.OnExplosionKill = (Delegates.HealthChangeHandler)Delegate.Combine(moduleByType.OnExplosionKill, new Delegates.HealthChangeHandler(OnMortarKill));
		}
	}

	private void OnMortarKill(HealthChangeInfo info)
	{
		float num = killShellProb + killShellProb * GlobalFields.Instance.LuckProb;
		if (!(UnityEngine.Random.Range(0f, 1f) > num))
		{
			mortar.SpawnProjectile(info.Target.transform.position);
		}
	}
}
