using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class VirtualBuilding
{
	public string name;

	public bool built;

	public bool builtReset;

	public int cost;

	public int costReset;

	public List<int> requirementIndexes = new List<int>();

	public int income;

	public int incomeReset;

	public UnityEvent callAfterIncome = new UnityEvent();

	public float priority;

	public float priorityReset;

	public bool economicBuilding;

	public int defensePower;

	public int representingLevel;

	public UnityAction ActionMillLowerIncome;

	public UnityAction ActionSetIncomToZero;

	public UnityAction ActionShrineActivate;

	public UnityAction ActionHarborIncreaseIncomeLvl1;

	public BuildSlot RepresentingBuildSlot { get; set; }

	public void Reset()
	{
		built = builtReset;
		cost = costReset;
		income = incomeReset;
		priority = priorityReset;
	}

	public bool IsBuildable(int _withBudget, List<VirtualBuilding> _virtualBuildings)
	{
		if (built)
		{
			return false;
		}
		if (cost > _withBudget)
		{
			return false;
		}
		foreach (int requirementIndex in requirementIndexes)
		{
			try
			{
				if (!_virtualBuildings[requirementIndex].built)
				{
					return false;
				}
			}
			catch
			{
				Debug.LogError("inx: " + requirementIndex + "\n_virtualBuildings.Count: " + _virtualBuildings.Count);
			}
		}
		return true;
	}

	public VirtualBuilding()
	{
		ActionMillLowerIncome = MillLowerIncome;
		ActionHarborIncreaseIncomeLvl1 = HarborIncreaseIncomeLvl1;
		ActionShrineActivate = ShrineActivate;
		ActionSetIncomToZero = SetIncomToZero;
	}

	public void MillLowerIncome()
	{
		income = Mathf.Max(1, income - 1);
	}

	public void SetIncomToZero()
	{
		income = 0;
	}

	public void ShrineActivate()
	{
		income = Mathf.Min(2, income + 1);
	}

	public void HarborIncreaseIncomeLvl1()
	{
		income = Mathf.Min(5, income + 1);
		foreach (VirtualBuilding virtualBuilding in EconomySimulator.VirtualBuildings)
		{
			if (!(virtualBuilding.name != name) && virtualBuilding.representingLevel == representingLevel + 1 && virtualBuilding.requirementIndexes.Contains(EconomySimulator.VirtualBuildings.IndexOf(this)))
			{
				virtualBuilding.income = income;
				if (virtualBuilding.income >= 4)
				{
					virtualBuilding.priority = 90f;
				}
				break;
			}
		}
	}
}
