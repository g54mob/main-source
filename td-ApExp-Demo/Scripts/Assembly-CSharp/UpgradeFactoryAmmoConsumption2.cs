using UnityEngine;

[CreateAssetMenu(fileName = "FactoryAmmoConsumption2", menuName = "Upgrade/Factory/AmmoConsumption2")]
public class UpgradeFactoryAmmoConsumption2 : EnhancementUpgrade
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
}
