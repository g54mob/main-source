using UnityEngine;

[CreateAssetMenu(fileName = "CannonConsecutiveSide", menuName = "Upgrade/Cannon/ConsecutiveSide")]
public class UpgradeCannonConsecutiveSide : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	private ModuleCannon cannon;

	private bool isConsecutiveStreakN;

	public override void ApplyUpgrade()
	{
		ModuleCannon moduleByType = Train.Instance.GetModuleByType<ModuleCannon>();
		if ((object)moduleByType != null)
		{
			cannon = moduleByType;
		}
		cannon.cannon.OnProjectileHitEvent += OnCannonProjectileHit;
		cannon.cannon.OnProjectileSpawnEvent += OnCannonProjectileSpawn;
		cannon.cannon.OnUpgraded();
	}

	private void OnCannonProjectileHit(HealthChangeInfo info)
	{
		appliedStatusEffect = cannon.StatsSO.ApplyStatusEffect(statusEffectSO);
	}

	private void OnCannonProjectileSpawn(ProjectileSpawnEventArgs args)
	{
		bool flag = args.Direction.y > 0f;
		if (flag != isConsecutiveStreakN)
		{
			isConsecutiveStreakN = flag;
			cannon.StatsSO.RemoveStatusEffect(appliedStatusEffect);
			appliedStatusEffect = null;
		}
	}
}
