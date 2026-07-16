using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MortarKillScrap", menuName = "Upgrade/Mortar/KillScrap")]
public class UpgradeMortarKillScrap : EnhancementUpgrade
{
	[SerializeField]
	private float killScrap = 4f;

	public override void ApplyUpgrade()
	{
		ModuleMortar moduleByType = Train.Instance.GetModuleByType<ModuleMortar>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnExplosionKill = (Delegates.HealthChangeHandler)Delegate.Combine(moduleByType.OnExplosionKill, new Delegates.HealthChangeHandler(OnMortarKill));
		}
	}

	private void OnMortarKill(HealthChangeInfo info)
	{
		ResourceManager.Instance.Scrap.AddValue(killScrap);
	}
}
