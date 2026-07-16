using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Minigames Completed/Create New")]
public class MilestoneMinigamesCompleted : Milestone
{
	private List<Module> moduleBlacklist;

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.MinigamesCompleted;
		moduleBlacklist = new List<Module>();
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module)
			{
				module.HealthComponent.OnRes += AddProgress;
				moduleBlacklist.Add(module);
			}
		}
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].OnNewModuleSet += SetModules;
			}
		}
		Train.Instance.OnNewWagonSet += SetWagons;
	}

	public void SetWagons(Wagon wagon)
	{
		ModuleSlot[] componentsInChildren = wagon.GetComponentsInChildren<ModuleSlot>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].OnNewModuleSet += SetModules;
		}
	}

	public void SetModules(Module module)
	{
		if (!moduleBlacklist.Contains(module))
		{
			module.HealthComponent.OnRes += AddProgress;
			moduleBlacklist.Add(module);
		}
	}

	public void AddProgress(HealthChangeInfo info)
	{
		base.AddProgress();
	}

	public override void Complete()
	{
		base.Complete();
		foreach (Module item in moduleBlacklist)
		{
			item.HealthComponent.OnRes -= AddProgress;
		}
		Train.Instance.OnNewWagonSet -= SetWagons;
		foreach (Wagon wagon in Train.Instance.Wagons)
		{
			ModuleSlot[] moduleSlots = wagon.ModuleSlots;
			for (int i = 0; i < moduleSlots.Length; i++)
			{
				moduleSlots[i].OnNewModuleSet -= SetModules;
			}
		}
	}
}
