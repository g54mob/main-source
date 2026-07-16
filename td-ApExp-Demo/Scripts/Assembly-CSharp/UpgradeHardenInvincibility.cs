using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HardenInvincibility", menuName = "Upgrade/Harden/Invincibility")]
public class UpgradeHardenInvincibility : EnhancementUpgrade
{
	private struct DamageEvent
	{
		public float amount;

		public float time;
	}

	[SerializeField]
	private float damageNeeded;

	[SerializeField]
	private float amountOfTime;

	[SerializeField]
	private float buffDuration;

	private ModuleHarden harden;

	private bool cooldown;

	private List<DamageEvent> damageHistory = new List<DamageEvent>();

	public override void ApplyUpgrade()
	{
		ModuleHarden moduleByType = Train.Instance.GetModuleByType<ModuleHarden>();
		if ((object)moduleByType != null)
		{
			harden = moduleByType;
			Train.Instance.HealthComponent.OnHealthChanged += RecordDamage;
			LevelManager.Instance.LevelStarted += delegate
			{
				cooldown = false;
			};
		}
	}

	public void RecordDamage(HealthChangeInfo info)
	{
		if (!(info.HealthChange >= 0f) && !cooldown)
		{
			damageHistory.Add(new DamageEvent
			{
				amount = Mathf.Abs(info.HealthChange),
				time = Time.time
			});
			RemoveOldEvents();
			HasTakenEnoughDamage();
		}
	}

	public void HasTakenEnoughDamage()
	{
		RemoveOldEvents();
		float num = 0f;
		foreach (DamageEvent item in damageHistory)
		{
			num += item.amount;
			if (num >= damageNeeded)
			{
				Train.Instance.HealthComponent.ApplyImmunityBuff(buffDuration);
				cooldown = true;
			}
		}
	}

	private void RemoveOldEvents()
	{
		float currentTime = Time.time;
		damageHistory.RemoveAll((DamageEvent e) => currentTime - e.time > amountOfTime);
	}
}
