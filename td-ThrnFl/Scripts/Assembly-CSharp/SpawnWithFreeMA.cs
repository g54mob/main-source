using UnityEngine;

public class SpawnWithFreeMA : ManualAttack, DayNightCycle.IDaytimeSensitive
{
	[SerializeField]
	private GameObject spawnHere;

	[SerializeField]
	private int consecutiveActivations = 3;

	private int activationNr;

	private bool cutCooldownNextTime;

	public override void Start()
	{
		base.Start();
		DayNightCycle.Instance.RegisterDaytimeSensitiveObject(this);
	}

	public override void HandleAttackUpdate()
	{
		if (!(inputBuffer >= 0f))
		{
			return;
		}
		if (cooldown > 0f)
		{
			if (!autoAttack && cooldown > inputBuffer)
			{
				audioManager.PlaySoundAsOneShot(caStillOnCooldown, 1f, Random.Range(1.8f, 2.2f), audioSet.mixGroupFX, 5);
				inputBuffer = -1f;
			}
			return;
		}
		inputBuffer = -1f;
		isAttacking = true;
		cooldown = cooldownTime;
		if (timedActivationPerfectly && activationNr % consecutiveActivations == 0)
		{
			cutCooldownNextTime = true;
			audioManager.PlaySoundAsOneShot(caAttackTimedPerfectly, 1f, Random.Range(0.9f, 1.1f), audioSet.mixGroupFX, 4);
		}
		Attack();
	}

	public override void Attack()
	{
		if ((bool)spawnHere)
		{
			Object.Instantiate(spawnHere, base.transform.position, spawnHere.transform.rotation);
		}
		activationNr++;
		if (activationNr % consecutiveActivations != 0)
		{
			cooldown = 0f;
		}
		else if (cutCooldownNextTime)
		{
			cooldown *= UpgradeAssassinsTraining.instance.cooldownMultiForPerfectlyTimedAttacks;
			cutCooldownNextTime = false;
		}
	}

	public void OnDawn_AfterSunrise()
	{
	}

	public void OnDawn_BeforeSunrise()
	{
	}

	public void OnDusk()
	{
		activationNr = 0;
	}

	public void OnDuskEarly()
	{
	}
}
