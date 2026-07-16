using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CannonLeech", menuName = "Upgrade/Cannon/Leech")]
public class UpgradeCannonLeech : EnhancementUpgradeStats
{
	private ModuleCannon cannon;

	[SerializeField]
	private float healProb = 0.05f;

	[SerializeField]
	[Tooltip("How much damage becomes healing, e.g. 0.25 = 25% of damage heals a module.")]
	private float damageToHealNormalized = 0.25f;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			cannon = moduleByType;
			moduleByType.cannon.OnProjectileHitEvent += OnCannonProjectileHit;
			moduleByType.cannon.OnUpgraded();
		}
	}

	private void OnCannonProjectileHit(HealthChangeInfo info)
	{
		float num = healProb + healProb * GlobalFields.Instance.LuckProb;
		if (!(Random.Range(0f, 1f) > num))
		{
			float healthChange = Mathf.Abs(info.HealthChange) * damageToHealNormalized;
			Health health = (from m in Train.Instance.Modules
				where (bool)m && (bool)m.HealthComponent
				select m.HealthComponent into h
				orderby Random.value
				where !h.IsDead
				select h).FirstOrDefault();
			health?.ChangeHealthWithInfo(new HealthChangeInfo(cannon, health, healthChange, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
		}
	}
}
