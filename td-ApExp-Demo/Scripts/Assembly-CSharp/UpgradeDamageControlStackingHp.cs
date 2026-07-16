using UnityEngine;

[CreateAssetMenu(fileName = "DamageControlStackingHp", menuName = "Upgrade/DamageControl/StackingHp")]
public class UpgradeDamageControlStackingHp : EnhancementUpgradeStats
{
	[SerializeField]
	private float hullHpPerStack;

	private int maxAmountOfStacks;

	private int currentStacks;

	[SerializeField]
	private StatusEffect statusEffect;

	public override void ApplyUpgrade()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			OnBreak(module);
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnNewModuleSet += OnBreak;
			}
		}
		Train.Instance.OnNewWagonSet += OnNewWagon;
	}

	public void OnBreak(Module module)
	{
		module.FullyBroken += OnModuleFullyBroken;
	}

	public void OnNewWagon(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += OnBreak;
		}
	}

	public void OnModuleFullyBroken()
	{
		maxAmountOfStacks = statusEffect.maxStacks;
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				StatUtils.RaiseMaxHp(module, statusEffect);
			}
		}
		if (currentStacks != maxAmountOfStacks)
		{
			currentStacks++;
			Train.Instance.HealthComponent.RaiseMaxHealthByWithoutHeal(hullHpPerStack);
		}
	}
}
