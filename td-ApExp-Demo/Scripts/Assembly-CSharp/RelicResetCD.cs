using UnityEngine;

[CreateAssetMenu(fileName = "RelicResetCD", menuName = "Upgrade/Relic/ResetCD")]
public class RelicResetCD : EnhancementUpgrade
{
	[SerializeField]
	private float chanceForRefund;

	public override void ApplyUpgrade()
	{
		foreach (Module module in Train.Instance.Modules)
		{
			Activate(module);
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnNewModuleSet += Activate;
			}
		}
		Train.Instance.OnNewWagonSet += OnNewWagon;
	}

	public void Activate(Module module)
	{
		module.OnActivation += delegate
		{
			FullReset(module);
		};
	}

	public void FullReset(Module module)
	{
		if (ProbUtils.CheckWithLuck(chanceForRefund))
		{
			module.RefundCooldown();
			module.RefundConsumption();
		}
	}

	public void OnNewWagon(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += Activate;
		}
	}
}
