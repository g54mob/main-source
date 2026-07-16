using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Mitigate Damage/Create New")]
public class MilestoneModuleMitigateDamage : Milestone
{
	private Module targetModule;

	[field: SerializeField]
	[field: Tooltip("If you leave this field empty (Set to None), this milestone will count damage mitigated from every available module.")]
	public EnhancementModule ModuleSO { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.ModuleMitigateDamage;
		targetModule = null;
		if (ModuleSO != null)
		{
			if (ModuleSO.ModulePrefab.GetComponent<ModuleHarden>() == null && ModuleSO.ModulePrefab.GetComponent<ModuleShield>() == null)
			{
				Debug.LogError("Selected module cannot mitigate damage.");
				return;
			}
			foreach (Module module in Train.Instance.Modules)
			{
				if ((bool)module && module.Enhancement == ModuleSO)
				{
					targetModule = module;
					module.OnMitigateDamage += AddProgress;
				}
			}
			if (!(targetModule == null))
			{
				return;
			}
			foreach (Wagon wagon in Train.Instance.Wagons)
			{
				ModuleSlot[] moduleSlots = wagon.ModuleSlots;
				for (int i = 0; i < moduleSlots.Length; i++)
				{
					moduleSlots[i].OnNewModuleSet += CheckForModule;
				}
			}
			Train.Instance.OnNewWagonSet += CheckWagon;
		}
		else
		{
			if (!(ModuleSO == null))
			{
				return;
			}
			foreach (Module module2 in Train.Instance.Modules)
			{
				if ((bool)module2)
				{
					module2.OnMitigateDamage += AddProgress;
				}
			}
			foreach (Wagon wagon2 in Train.Instance.Wagons)
			{
				ModuleSlot[] moduleSlots = wagon2.ModuleSlots;
				for (int i = 0; i < moduleSlots.Length; i++)
				{
					moduleSlots[i].OnNewModuleSet += CheckForModule;
				}
			}
			Train.Instance.OnNewWagonSet += CheckWagon;
		}
	}

	public void CheckWagon(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += CheckForModule;
		}
	}

	public void CheckForModule(Module module)
	{
		if (ModuleSO == null)
		{
			module.OnMitigateDamage += AddProgress;
		}
		else
		{
			if (!(module.Enhancement == ModuleSO))
			{
				return;
			}
			targetModule = module;
			module.OnMitigateDamage += AddProgress;
			Train.Instance.OnNewWagonSet -= CheckWagon;
			foreach (Wagon wagon in Train.Instance.Wagons)
			{
				ModuleSlot[] moduleSlots = wagon.ModuleSlots;
				for (int i = 0; i < moduleSlots.Length; i++)
				{
					moduleSlots[i].OnNewModuleSet -= CheckForModule;
				}
			}
		}
	}

	public void AddProgress(float reducedDamageAmount)
	{
		base.Progress += reducedDamageAmount;
		UpdateProgress();
		if (base.Progress >= Goal)
		{
			Complete();
		}
	}

	public override void Complete()
	{
		base.Complete();
		if (ModuleSO == null)
		{
			foreach (Wagon wagon in Train.Instance.Wagons)
			{
				ModuleSlot[] moduleSlots = wagon.ModuleSlots;
				for (int i = 0; i < moduleSlots.Length; i++)
				{
					moduleSlots[i].OnNewModuleSet -= CheckForModule;
				}
			}
			Train.Instance.OnNewWagonSet -= CheckWagon;
		}
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				module.OnMitigateDamage -= AddProgress;
			}
		}
	}
}
