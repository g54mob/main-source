using UnityEngine;

public class GlobalFields : MonoBehaviour
{
	public static GlobalFields Instance;

	public float LuckPct { get; set; }

	public float LuckProb => LuckPct * 0.01f;

	public float AllPlayerDmgMult { get; private set; } = 1f;

	public float PlayerBurnStackAdd { get; set; }

	public float PlayerBurnDmgMult { get; set; } = 1f;

	public float PlayerBurnStackLooseChance { get; set; } = 1f;

	public float EnemyAttackSpeedSlowingDownWhenBurnPerStack { get; set; }

	public float ProjectileDamageMult { get; set; } = 1f;

	public float SunderDmgMult { get; set; } = 1.5f;

	public float WeakenDmgMult { get; set; } = 0.5f;

	public float RicochetDmgMult { get; set; } = 1f;

	public float WrapDamageMult { get; set; } = 1f;

	public float BossEmpDurationMult { get; set; } = 0.5f;

	public float ObstacleAoeDamageModifier { get; set; } = 1f;

	public float ModuleBreakDelayLB { get; set; }

	public float ModuleBreakDelayUB { get; set; }

	public float ExplosionRadiusMult { get; set; } = 1f;

	public float ExplosionDamageMult { get; set; } = 1f;

	public float RepairCostMult { get; set; } = 1f;

	public int AmountOfEnemiesOnFire { get; set; }

	public float SpeedPerEnemyOnFire { get; set; }

	public float ShieldSetsEnemyOnFireChance { get; set; }

	public float ShieldSundersEnemyChance { get; set; }

	public float TimingMinigameGainModifier { get; set; } = 1f;

	private void Awake()
	{
		Instance = this;
	}

	public void ModifyPlayerDamageMultiplier(float value)
	{
		float num = 0f;
		num = ((!(value < 1f)) ? value : (0f - value));
		AllPlayerDmgMult += num;
	}
}
