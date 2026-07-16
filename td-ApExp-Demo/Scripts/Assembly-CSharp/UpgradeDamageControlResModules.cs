using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlResModules", menuName = "Upgrade/DamageControl/HullRepairResModules")]
public class UpgradeDamageControlResModules : EnhancementUpgradeStats
{
	[SerializeField]
	private float moduleResHealth = 5f;

	private ModuleDamageControl dc;

	public override void ApplyUpgrade()
	{
		ModuleDamageControl moduleByType = Train.Instance.GetModuleByType<ModuleDamageControl>();
		if ((object)moduleByType != null)
		{
			dc = moduleByType;
			dc.Started += OnDCStarted;
		}
	}

	private void OnDCStarted()
	{
		Health[] array = (from m in Train.Instance.Modules
			where m
			select m.HealthComponent into h
			where h.IsDead
			select h).ToArray();
		for (int num = 0; num < array.Length; num++)
		{
			array[num].SetHealthWithInfo(new HealthChangeInfo(dc, array[num], moduleResHealth, isPercent: false, null, canRes: true, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.God));
		}
	}
}
