using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableHaulGeneralItems : TaskBase
{
	public TransferTarget TargetInventory;

	public SubInventoryType InventoryList;

	public MoveItemsTarget ItemsMoveTarget;

	public bool ReserveIncoming;

	public DrifterRigEventType AnimationEventType;

	public override TaskType Type => TaskType.VariableMoveItems;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		ItemToHaul itemToHaul;
		while (_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Pickup, out itemToHaul))
		{
			yield return IncrementItemToHaulState(itemToHaul, agent);
		}
		while (TryReturnGeneralItemToHaul(agent, project.GeneralItems, out itemToHaul))
		{
			if (itemToHaul.State == ItemToHaul.HaulState.Pickup)
			{
				yield return IncrementItemToHaulState(itemToHaul, agent);
				continue;
			}
			Debug.LogErrorFormat("'{0}' added variable general item to haul '{1}' for project '{2}' which should be in 'Pickup' state but is in '{3}' state", agent.Name, itemToHaul.Item.Properties.LocalizedName, project.Properties.name, itemToHaul.State);
		}
		while (_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Transit, out itemToHaul))
		{
			yield return IncrementItemToHaulState(itemToHaul, agent);
		}
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		ProjectBlocker projectBlocker = base.ReturnBlockers(project);
		if (ReserveIncoming && !Community.PlayerCommunity.Inventory.ReturnFitsAnyItem(project.GeneralItems))
		{
			projectBlocker |= ProjectBlocker.SharableEmptyItemList;
		}
		return projectBlocker;
	}

	protected override void OnGUI()
	{
		Header("Variable Haul General Items", 5, Color.blue);
		_itemTransferDuration = EditorGUI_FloatField("Duration", _itemTransferDuration);
		TargetInventory = (TransferTarget)(object)EditorGUI_EnumField("Target inventory", TargetInventory);
		InventoryList = (SubInventoryType)(object)EditorGUI_EnumField("Target SubInventory", InventoryList);
		ReserveIncoming = EditorGUI_Toggle("Reserve incoming", ReserveIncoming);
		EditorGUI_PropertyField("AnimationEventType", "Rig Animation Event Type");
		EditorGUI_HelpBox("Moves items from the projects general items the target subinventory. The items are not prereserved but each item is reserved individually after each item has been picked up (except the first item offcourse).This is mostly usefull for producers so an agent can pickup ingredients for multiple recipes that are manually queued");
	}

	private IEnumerator IncrementItemToHaulState(ItemToHaul itemToHaul, Agent agent)
	{
		yield return MoveAgentCoroutine(itemToHaul.MoveToTarget);
		new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, DrifterAttributes.AttributeType.Athletics).Dispatch();
		yield return itemToHaul.IncrementStateCoroutine(AnimationEventType);
		new AgentActionItemPropertiesEvent(GameEventType.AgentActionItemHauled, agent, itemToHaul.Item.Properties, DrifterAttributes.AttributeType.Athletics).Dispatch();
		new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, DrifterAttributes.AttributeType.Athletics).Dispatch();
	}

	private bool TryReturnGeneralItemToHaul(Agent agent, List<Item> generalItems, out ItemToHaul itemToHaul)
	{
		int count = generalItems.Count;
		for (int i = 0; i < count; i++)
		{
			Item item = generalItems[i];
			if (ReserveIncoming && !agent.Community.ReserveIncomingItems(item, InventoryList))
			{
				continue;
			}
			if (_assignment.AddGeneralItemToHaul(out itemToHaul, item, InventoryList))
			{
				return true;
			}
			if (ReserveIncoming)
			{
				item.UnreserveMoveToInventory();
			}
			break;
		}
		itemToHaul = null;
		return false;
	}
}
