using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MortarGainScrap", menuName = "Upgrade/Mortar/GainScrap")]
public class UpgradeMortarGainScrap : EnhancementUpgrade
{
	private ModuleMortar mortar;

	[SerializeField]
	private float chanceToGainScrap;

	[SerializeField]
	private float scrapGain;

	public override void ApplyUpgrade()
	{
		mortar = Train.Instance.GetModuleByType<ModuleMortar>();
		ModuleMortar moduleMortar = mortar;
		moduleMortar.OnExplosionKill = (Delegates.HealthChangeHandler)Delegate.Combine(moduleMortar.OnExplosionKill, new Delegates.HealthChangeHandler(TryGetScrap));
	}

	public void TryGetScrap(HealthChangeInfo info)
	{
		if (ProbUtils.CheckWithLuck(chanceToGainScrap))
		{
			ResourceManager.Instance.Scrap.AddValue(scrapGain);
		}
	}
}
