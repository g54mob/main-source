using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlInvincibility", menuName = "Upgrade/DamageControl/Invincibility")]
public class UpgradeDamageControlInvincibility : EnhancementUpgradeStats
{
	private struct DamageEvent
	{
		public float amount;

		public float time;

		public Module module;
	}

	[SerializeField]
	private float amountOfTimeTracked;

	[SerializeField]
	private float invincibilityDuration;

	private ModuleDamageControl dc;

	private Dictionary<Module, float> healing;

	private List<DamageEvent> damageHistory = new List<DamageEvent>();

	public override void ApplyUpgrade()
	{
		healing = new Dictionary<Module, float>();
		dc = Train.Instance.GetModuleByType<ModuleDamageControl>();
		foreach (Module module in Train.Instance.Modules)
		{
			if (!(module == null))
			{
				module.HealthComponent.OnHealthChanged += RecordDamage;
			}
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			for (int i = 0; i < moduleSlots.Length; i++)
			{
				moduleSlots[i].OnNewModuleSet += RecordNewModule;
			}
		}
		Train.Instance.OnNewWagonSet += RecordNewWagon;
		dc.healingMechanicChanged = true;
		dc.OnInteractStartEvent += Activated;
	}

	public void RecordNewModule(Module module)
	{
		module.HealthComponent.OnHealthChanged += RecordDamage;
	}

	public void RecordNewWagon(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += RecordNewModule;
		}
	}

	public void RecordDamage(HealthChangeInfo info)
	{
		if (!(info.HealthChange >= 0f) && !(info.Target.GetComponent<Module>() == null))
		{
			damageHistory.Add(new DamageEvent
			{
				amount = Mathf.Abs(info.HealthChange),
				time = Time.time,
				module = info.Target.GetComponent<Module>()
			});
			RemoveOldEvents();
		}
	}

	private void RemoveOldEvents()
	{
		float currentTime = Time.time;
		damageHistory.RemoveAll((DamageEvent e) => currentTime - e.time > amountOfTimeTracked);
	}

	public void Activated()
	{
		RemoveOldEvents();
		foreach (DamageEvent item in damageHistory)
		{
			if (healing.ContainsKey(item.module))
			{
				healing[item.module] += item.amount;
			}
			else
			{
				healing.Add(item.module, item.amount);
			}
		}
		dc.HealDamageTaken(healing);
		Train.Instance.HealthComponent.ApplyImmunityBuff(invincibilityDuration);
		healing.Clear();
	}
}
