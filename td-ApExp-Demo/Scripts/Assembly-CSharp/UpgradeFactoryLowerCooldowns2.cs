using UnityEngine;

[CreateAssetMenu(fileName = "FactoryReduceCooldowns2", menuName = "Upgrade/Factory/ReduceCooldowns2")]
public class UpgradeFactoryLowerCooldowns2 : EnhancementUpgrade
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
				ReduceCooldown(module);
			}
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnNewModuleSet += ReduceCooldown;
			}
		}
		Train.Instance.OnNewWagonSet += OnNewWagon;
	}

	public void ReduceCooldown(Module module)
	{
		StatUtils.ReduceCooldown(module, statusEffectSO);
	}

	public void OnNewWagon(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += ReduceCooldown;
		}
	}
}
