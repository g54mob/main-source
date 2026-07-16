using System;
using System.Linq;
using UnityEngine;

public class ModuleHarden : Module
{
	[NonSerialized]
	public bool isHardenApplied;

	[SerializeField]
	private float damageReductionPercent = 15f;

	[SerializeField]
	private float healthIncrease;

	[SerializeField]
	private float ricochetChance;

	[SerializeField]
	private float healingChance;

	[SerializeField]
	private float healingAmount;

	private float damageReductionFlat;

	public float DamageReductionPercent
	{
		get
		{
			return damageReductionPercent;
		}
		set
		{
			if (isHardenApplied)
			{
				ApplyModuleHardening(apply: false);
				damageReductionPercent = value;
				ApplyModuleHardening(apply: true);
			}
			else
			{
				damageReductionPercent = value;
			}
		}
	}

	public float DamageReductionFlat
	{
		get
		{
			return damageReductionFlat;
		}
		set
		{
			if (isHardenApplied)
			{
				ApplyModuleHardening(apply: false);
				damageReductionFlat = value;
				ApplyModuleHardening(apply: true);
			}
			else
			{
				damageReductionFlat = value;
			}
		}
	}

	public float HealthIncrease
	{
		get
		{
			return healthIncrease;
		}
		set
		{
			if (isHardenApplied)
			{
				ApplyModuleHardening(apply: false);
				healthIncrease = value;
				ApplyModuleHardening(apply: true);
			}
			else
			{
				healthIncrease = value;
			}
		}
	}

	public float RicochetChance
	{
		get
		{
			return healthIncrease;
		}
		set
		{
			if (isHardenApplied)
			{
				ApplyModuleHardening(apply: false);
				ricochetChance = value;
				ApplyModuleHardening(apply: true);
			}
			else
			{
				ricochetChance = value;
			}
		}
	}

	public float HealingChance
	{
		get
		{
			return healingChance;
		}
		set
		{
			healingChance = value;
		}
	}

	public float HealingAmount
	{
		get
		{
			return healingAmount;
		}
		set
		{
			healingAmount = value;
		}
	}

	public void SetHealingEffect(float chance, float amount)
	{
		HealingChance = chance;
		HealingAmount = amount;
	}

	private new void Awake()
	{
		base.Awake();
		base.HealthComponent.OnDeath += Break;
		base.HealthComponent.OnRes += OnFix;
	}

	public override void OnRemoveModule()
	{
		ApplyModuleHardening(apply: false);
		base.OnRemoveModule();
		base.HealthComponent.OnDeath -= Break;
		base.HealthComponent.OnRes -= OnFix;
		Train.Instance.OnNewWagonSet -= ApplyHardenToNewModules;
		Train.Instance.OnNewWagonSet -= TrackNewWagons;
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			for (int i = 0; i < moduleSlots.Length; i++)
			{
				moduleSlots[i].OnNewModuleSet -= TrackNewModulesReducedDamage;
			}
		}
	}

	protected override void SetEmpSoundChannels()
	{
	}

	public override bool CanInteract()
	{
		return false;
	}

	protected override void StartAndPostUpgrade()
	{
		ApplyModuleHardening(apply: true);
		Train.Instance.OnNewWagonSet += ApplyHardenToNewModules;
	}

	protected override void Break(HealthChangeInfo info)
	{
		base.Break(info);
		ApplyModuleHardening(apply: false);
	}

	protected override void OnFix(HealthChangeInfo info)
	{
		base.OnFix(info);
		ApplyModuleHardening(apply: true);
	}

	private void ApplyModuleHardening(bool apply)
	{
		if (apply == isHardenApplied)
		{
			return;
		}
		Module[] array = Train.Instance.Modules.Where((Module m) => m).ToArray();
		foreach (Module module in array)
		{
			if (apply)
			{
				isHardenApplied = true;
				module.HealthComponent.DamageReductionPercent += damageReductionPercent;
				module.HealthComponent.SetMaxHealth(module.HealthComponent.HealthMax + healthIncrease);
				module.HealthComponent.ricochetChance += ricochetChance;
				module.HealthComponent.DamageReductionFlat += damageReductionFlat;
				module.HealthComponent.OnDamageReduced += DamageMitigated;
			}
			else
			{
				isHardenApplied = false;
				module.HealthComponent.DamageReductionPercent -= damageReductionPercent;
				module.HealthComponent.SetMaxHealth(module.HealthComponent.HealthMax - healthIncrease);
				module.HealthComponent.ricochetChance -= ricochetChance;
				module.HealthComponent.DamageReductionFlat -= damageReductionFlat;
			}
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			wagon.SetHardening(apply);
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			foreach (ModuleSlot moduleSlot in moduleSlots)
			{
				if (apply)
				{
					moduleSlot.OnNewModuleSet += TrackNewModulesReducedDamage;
				}
				else
				{
					moduleSlot.OnNewModuleSet -= TrackNewModulesReducedDamage;
				}
			}
		}
		if (apply)
		{
			Train.Instance.OnNewWagonSet += TrackNewWagons;
		}
		else
		{
			Train.Instance.OnNewWagonSet -= TrackNewWagons;
		}
	}

	public void TrackNewModulesReducedDamage(Module module)
	{
		module.HealthComponent.OnDamageReduced += DamageMitigated;
	}

	public void TrackNewWagons(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += TrackNewModulesReducedDamage;
		}
	}

	private void ApplyHardenToNewModules(Wagon w)
	{
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			wagon.SetHardening(isHardened: true);
		}
	}
}
