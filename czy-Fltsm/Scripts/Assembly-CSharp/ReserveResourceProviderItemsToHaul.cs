using System.Collections;
using System.Collections.Generic;

public class ReserveResourceProviderItemsToHaul : TaskBase
{
	public override TaskType Type => TaskType.ReserveResourceProviderItemsToHaul;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		int haulingPriority = ReturnHaulingPriority(agent);
		using ListPool<ResourceProvider>.List list = ListPool<ResourceProvider>.Get();
		using ListPool<ResourceProvider>.List list2 = ListPool<ResourceProvider>.Get();
		agent.Community.Inventory.PopulateResourceProviders(agent, haulingPriority, applyCapacityPriority: true, list);
		foreach (ResourceProvider item2 in list)
		{
			item2.UpdatePriorityWithCapacity(agent, haulingPriority);
		}
		while (TryPopulatePrioritizedResourceProviders(list, list2))
		{
			foreach (ResourceProvider item3 in list2)
			{
				Item item;
				while (item3.TryReturnFirstExportableItem(out item) && agent.Community.ReserveIncomingItems(item, SubInventoryType.Storage))
				{
					if (_assignment.AddItemToHaul(item))
					{
						item.Reserve();
						continue;
					}
					item.UnreserveMoveToInventory();
					yield break;
				}
			}
			list.RemoveRange(list2);
			list2.Clear();
		}
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		if (Community.PlayerCommunity.Inventory.ReturnHasResourceProviderWithExportableItems())
		{
			return ProjectBlocker.None;
		}
		return ProjectBlocker.StorageSpace;
	}

	public override bool TryReturnAgentPriority(out int priority, Project project, Agent agent, int weight)
	{
		int haulingPriority = ReturnHaulingPriority(agent);
		using ListPool<ResourceProvider>.List list = ListPool<ResourceProvider>.Get();
		using ListPool<ResourceProvider>.List list2 = ListPool<ResourceProvider>.Get();
		agent.Community.Inventory.PopulateResourceProviders(agent, haulingPriority, applyCapacityPriority: true, list);
		foreach (ResourceProvider item in list)
		{
			item.UpdatePriority(agent, haulingPriority);
		}
		while (TryPopulatePrioritizedResourceProviders(list, list2))
		{
			foreach (ResourceProvider item2 in list2)
			{
				if (item2.HasExportableItems())
				{
					priority = item2.Priority;
					return true;
				}
			}
			list.RemoveRange(list2);
			list2.Clear();
		}
		priority = 0;
		return false;
	}

	protected override void OnGUI()
	{
		Header("Reserve Resource Provider Items To Haul", 1, ReturnTypeColor());
		EditorGUI_PropertyField("_exportInventoryFullPriority");
		EditorGUI_HelpBox("Reserve items in resource providers that are ready to be hauled to a storage.");
	}

	private AssignmentType ReturnPrioritizedAssignmentTypes(Agent agent, out AssignmentPriority priority)
	{
		AssignmentType assignmentType = AssignmentType.Hauling | agent.Community.Inventory.ReturnResourceProvidersAssignmentTypes();
		AssignmentType assignmentType2 = AssignmentType.None;
		priority = AssignmentPriority.Lowest;
		foreach (Assignment assignment in agent.Assignments)
		{
			if ((assignmentType & assignment.Type) != AssignmentType.None)
			{
				if (priority == assignment.Priority)
				{
					assignmentType2 |= assignment.Type;
				}
				else if (priority < assignment.Priority)
				{
					priority = assignment.Priority;
					assignmentType2 = assignment.Type;
				}
			}
		}
		return assignmentType2;
	}

	private int ReturnHaulingPriority(Agent agent)
	{
		if (TryReturnAssignment(out var assignment, agent, AssignmentType.Hauling))
		{
			return assignment.PriorityWeight + assignment.OrderWeightSeconday;
		}
		return 0;
	}

	private bool TryReturnAssignment(out Assignment assignment, Agent agent, AssignmentType assignmentType)
	{
		for (int i = 0; i < agent.Assignments.Count; i++)
		{
			assignment = agent.Assignments[i];
			if (assignment.Type == assignmentType)
			{
				return assignment.Priority != AssignmentPriority.None;
			}
		}
		assignment = null;
		return false;
	}

	private int ReturnResourceProviderPriority(Agent agent, ResourceProvider resourceProvider, int primaryAssignmentWeight)
	{
		int num = 0;
		int count = agent.Assignments.Count;
		while (0 < count--)
		{
			Assignment assignment = agent.Assignments[count];
			if ((assignment.Type & resourceProvider.AssignmentType) != AssignmentType.None)
			{
				int num2 = assignment.PriorityWeight + assignment.OrderWeight * primaryAssignmentWeight;
				if (num < num2)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	private bool TryReturnHaulableItem(AssignmentType assignmentType, out Item haulableItem)
	{
		haulableItem = _agent.Community.Inventory.ReturnAvailableResourceProviderItem(assignmentType);
		return haulableItem != null;
	}

	private bool TryPopulatePrioritizedResourceProviders(List<ResourceProvider> resourceProviders, List<ResourceProvider> prioritizedResourceProviders)
	{
		int num = 0;
		int count = resourceProviders.Count;
		while (0 < count--)
		{
			ResourceProvider resourceProvider = resourceProviders[count];
			int priority = resourceProvider.Priority;
			if (priority == num)
			{
				prioritizedResourceProviders.Add(resourceProvider);
			}
			else if (priority > num)
			{
				prioritizedResourceProviders.Clear();
				prioritizedResourceProviders.Add(resourceProvider);
				num = resourceProvider.Priority;
			}
		}
		return prioritizedResourceProviders.Count > 0;
	}
}
