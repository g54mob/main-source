using System.Collections.Generic;
using UnityEngine;

public class GlobalHaulingPriorities
{
	public int Constructing { get; private set; }

	public int Cooking { get; private set; }

	public int Crafting { get; private set; }

	public int Hauling { get; private set; }

	public int Farming { get; private set; }

	public int AnimalHandling { get; private set; }

	public void Update(List<Assignment> assignments)
	{
		foreach (Assignment assignment in assignments)
		{
			switch (assignment.Type)
			{
			case AssignmentType.Constructing:
				Constructing = assignment.ResourceProviderWeight;
				break;
			case AssignmentType.Cooking:
				Cooking = assignment.ResourceProviderWeight;
				break;
			case AssignmentType.Crafting:
				Crafting = assignment.ResourceProviderWeight;
				break;
			case AssignmentType.Hauling:
				Hauling = assignment.ResourceProviderWeight;
				break;
			case AssignmentType.Farming:
				Farming = assignment.ResourceProviderWeight;
				break;
			case AssignmentType.AnimalHandling:
				AnimalHandling = assignment.ResourceProviderWeight;
				break;
			}
		}
		Constructing = Mathf.Max(Constructing, Hauling);
		Cooking = Mathf.Max(Cooking, Hauling);
		Crafting = Mathf.Max(Crafting, Hauling);
		Farming = Mathf.Max(Farming, Hauling);
		AnimalHandling = Mathf.Max(AnimalHandling, Hauling);
	}
}
