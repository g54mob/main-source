using UnityEngine;

[CreateAssetMenu(fileName = "FactoryAmmoConsumption1", menuName = "Upgrade/Factory/AmmoConsumption1")]
public class UpgradeFactoryAmmoConsumption1 : EnhancementUpgrade
{
	[SerializeField]
	private StatusEffect statusEffectSO;

	private StatusEffect appliedStatusEffect;

	public override void ApplyUpgrade()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				ReduceConsumption(module);
			}
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnNewModuleSet += ReduceConsumption;
			}
		}
		Train.Instance.OnNewWagonSet += OnNewWagon;
	}

	public void ReduceConsumption(Module module)
	{
		StatUtils.ReduceConsumption(module, statusEffectSO);
	}

	public void OnNewWagon(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += ReduceConsumption;
		}
	}

	public void RemoveFromWagons(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += RemoveUpgrade;
		}
	}

	public void RemoveUpgrade(Module module)
	{
		module.StatsSO.RemoveStatusEffect(statusEffectSO);
	}

	public override void OnRemove()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				RemoveUpgrade(module);
			}
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnNewModuleSet += RemoveUpgrade;
			}
		}
		Train.Instance.OnNewWagonSet += RemoveFromWagons;
	}
}
