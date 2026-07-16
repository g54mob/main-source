using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Module Used/Create New")]
public class MilestoneModuleUsed : Milestone
{
	private Module targetModule;

	[field: SerializeField]
	public EnhancementModule ModuleSO { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.ModuleUsed;
		targetModule = null;
		if (ModuleSO != null)
		{
			foreach (Module module in Train.Instance.Modules)
			{
				if ((bool)module && module.Enhancement == ModuleSO && module.CanBeActivated)
				{
					targetModule = module;
					module.GetComponent<Interactable>().OnInteractStart += AddProgress;
				}
			}
			if (!(targetModule == null))
			{
				return;
			}
			Train.Instance.OnNewWagonSet += CheckWagon;
			{
				foreach (Wagon wagon in Train.Instance.Wagons)
				{
					ModuleSlot[] moduleSlots = wagon.ModuleSlots;
					for (int i = 0; i < moduleSlots.Length; i++)
					{
						moduleSlots[i].OnNewModuleSet += CheckModule;
					}
				}
				return;
			}
		}
		if (!(ModuleSO == null))
		{
			return;
		}
		foreach (Module module2 in Train.Instance.Modules)
		{
			if ((bool)module2 && module2.CanBeActivated)
			{
				module2.GetComponent<Interactable>().OnInteractStart += AddProgress;
			}
		}
		Train.Instance.OnNewWagonSet += CheckWagon;
		foreach (Wagon wagon2 in Train.Instance.Wagons)
		{
			ModuleSlot[] moduleSlots = wagon2.ModuleSlots;
			for (int i = 0; i < moduleSlots.Length; i++)
			{
				moduleSlots[i].OnNewModuleSet += CheckModule;
			}
		}
	}

	public void AddProgress(Interactor interactor)
	{
		base.AddProgress();
	}

	public void CheckWagon(Wagon wagon)
	{
		ModuleSlot[] moduleSlots = wagon.ModuleSlots;
		for (int i = 0; i < moduleSlots.Length; i++)
		{
			moduleSlots[i].OnNewModuleSet += CheckModule;
		}
	}

	public void CheckModule(Module module)
	{
		if (ModuleSO == null && module.CanBeActivated)
		{
			module.GetComponent<Interactable>().OnInteractStart += AddProgress;
		}
		else
		{
			if (!(module.Enhancement == ModuleSO) || !module.CanBeActivated)
			{
				return;
			}
			targetModule = module;
			module.GetComponent<Interactable>().OnInteractStart += AddProgress;
			Train.Instance.OnNewWagonSet -= CheckWagon;
			foreach (Wagon wagon in Train.Instance.Wagons)
			{
				ModuleSlot[] moduleSlots = wagon.ModuleSlots;
				for (int i = 0; i < moduleSlots.Length; i++)
				{
					moduleSlots[i].OnNewModuleSet -= CheckModule;
				}
			}
		}
	}

	public override void Complete()
	{
		base.Complete();
		if (ModuleSO == null)
		{
			foreach (Module module in Train.Instance.Modules)
			{
				if ((bool)module && module.Enhancement == ModuleSO)
				{
					module.Interactable.OnInteractStart -= AddProgress;
					return;
				}
			}
			Train.Instance.OnNewWagonSet -= CheckWagon;
			{
				foreach (Wagon wagon in Train.Instance.Wagons)
				{
					ModuleSlot[] moduleSlots = wagon.ModuleSlots;
					for (int i = 0; i < moduleSlots.Length; i++)
					{
						moduleSlots[i].OnNewModuleSet -= CheckModule;
					}
				}
				return;
			}
		}
		targetModule.GetComponent<Interactable>().OnInteractStart -= AddProgress;
	}
}
