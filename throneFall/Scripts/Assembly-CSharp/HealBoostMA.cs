using UnityEngine;

public class HealBoostMA : ManualAttack
{
	public float attackSpeedBoost = 20f;

	public ManualAttack manualAttackToBoost;

	public ParticleSystem boostParticles;

	public float attackSpeedDuration = 2f;

	public float healthRegenerationPerSecond = 16.66f;

	public float attackSpeedDurationWhenLowHealth = 4f;

	private float disableBoostIn;

	private float attackSpeedOriginal;

	private bool attackSpeedReduced;

	private float cooldownOnAttack;

	public override void Start()
	{
		base.Start();
	}

	public override void Attack()
	{
		if (!attackSpeedReduced)
		{
			attackSpeedOriginal = manualAttackToBoost.cooldownTime;
			manualAttackToBoost.cooldownTime /= attackSpeedBoost;
			attackSpeedReduced = true;
		}
		ParticleSystem.EmissionModule emission = boostParticles.emission;
		emission.enabled = true;
		disableBoostIn = attackSpeedDuration;
		if (hpPlayer.HpPercentage <= 0.33f)
		{
			disableBoostIn = attackSpeedDurationWhenLowHealth;
		}
		cooldownOnAttack = cooldown;
	}

	public override void Update()
	{
		base.Update();
		disableBoostIn -= Time.deltaTime;
		bool flag = hpPlayer.HpValue <= 0f;
		if (disableBoostIn > 0f && !flag)
		{
			hpPlayer.Heal(healthRegenerationPerSecond * PlayerUpgradeManager.instance.PlayerHealthRegenerationMultiplyer * Time.deltaTime);
			cooldown = cooldownOnAttack;
		}
		if ((disableBoostIn + Time.deltaTime > 0f && disableBoostIn <= Time.deltaTime) || flag)
		{
			if (attackSpeedReduced)
			{
				attackSpeedReduced = false;
				manualAttackToBoost.cooldownTime = attackSpeedOriginal;
			}
			ParticleSystem.EmissionModule emission = boostParticles.emission;
			emission.enabled = false;
		}
	}
}
