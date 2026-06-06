using System;
using System.Collections;
using UnityEngine;

public class ReserveGeneralItemsToHaul : TaskBase
{
	[SerializeField]
	private SubInventoryType _targetSubInventory;

	[SerializeField]
	private ReserveFillInventory.SortingMethod _sortingMethod;

	public override TaskType Type => TaskType.ReserveGeneralItemsToHaul;

	public override void Initialize(ProjectAssignment assignment)
	{
		base.Initialize(assignment);
		if (!_agent.Inventory.ReturnIsEmpty())
		{
			Debug.LogWarningFormat("Initializing items to transfer for agent '{0}' assigned to project '{1}' that still has items in it's inventory!", assignment.Agent.Name, assignment.Project.Properties.name);
		}
	}

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		ListPool<Item>.List list = ListPool<Item>.Get(project.GeneralItems);
		SubInventoryType subInventoryType = _targetSubInventory;
		using (list)
		{
			switch (_sortingMethod)
			{
			case ReserveFillInventory.SortingMethod.Range:
				ItemDistanceComparer.SortByShortestDistance(agent.transform.position, list);
				break;
			case ReserveFillInventory.SortingMethod.UnityNavMeshPath:
				ReserveFillInventory.SortedItemsByDistanceFromMooringpoint(agent, project, list);
				break;
			}
			foreach (Item item in list)
			{
				if (item.Project != null && item.Project != project)
				{
					continue;
				}
				item.Reserve();
				if (project.Properties.RequiresGeneralStorageSpace)
				{
					if (item.MoveToInventory != null)
					{
						if (item.Inventory != _assignment.ReturnTransitInventory())
						{
							Debug.LogException(new Exception("Cannot reserve storage space for an item that already has storage space reserved!"));
							item.UnreserveMoveToInventory();
						}
						if (item.TryGetMoveToSubInventoryType(out var subInventoryType2))
						{
							subInventoryType = subInventoryType2;
						}
						else
						{
							item.UnreserveMoveToInventory();
						}
					}
					if (item.MoveToInventory == null && !agent.Community.ReserveIncomingItems(item, subInventoryType))
					{
						continue;
					}
				}
				if (!_assignment.AddGeneralItemToHaul(item, subInventoryType))
				{
					if (project.Properties.RequiresGeneralStorageSpace)
					{
						item.UnreserveMoveToInventory();
					}
					break;
				}
			}
		}
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Reserve General Items To Haul", 2, Color.cyan);
		_targetSubInventory = (SubInventoryType)(object)EditorGUI_EnumField("Target Subinventory", _targetSubInventory);
		_sortingMethod = (ReserveFillInventory.SortingMethod)(object)EditorGUI_EnumField("Sorting Method", _sortingMethod);
		EditorGUI_HelpBox("Reserve the amount of items that fit the assignments transit inventory from this projects general list and add them as items to haul.");
	}
}
