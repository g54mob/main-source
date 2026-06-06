using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class SalvageLandmark : SalvageTaskBase
{
	public string taskName;

	public override TaskType Type => TaskType.SalvageLandmark;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		int remaingItterations = ((!_assignment.ItemsToHaul.IsNullOrEmpty()) ? _assignment.ItemsToHaul.Count : 0);
		SubInventory transitInventory = _assignment.ReturnTransitInventory().ReturnInventory(SubInventoryType.Storage);
		ValidateState(agent);
		new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, Attribute).Dispatch();
		while (0 < remaingItterations && !_assignment.ItemsToHaul.IsNullOrEmpty())
		{
			ItemToHaul itemToSalvage;
			while (transitInventory.HasCapacity && _assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Pickup, out itemToSalvage))
			{
				if (CanSalvageItem(transitInventory, itemToSalvage))
				{
					yield return SalvageItem(itemToSalvage);
				}
				else if (_assignment.RemoveItemToHaul(itemToSalvage))
				{
					Debug.LogException(new Exception($"[{project.Properties}] '{agent.Descriptor.Name}' is unable to salvage item '{itemToSalvage.Item.Properties}' because it would not fit target inventory '{itemToSalvage.TargetInventory}'"));
				}
				else
				{
					Debug.LogException(new Exception($"[{project.Properties}] Unable to remove ItemToHaul that cannot be salvaged"));
				}
			}
			while (_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Transit, out itemToSalvage))
			{
				yield return MoveAgentCoroutine(itemToSalvage.MoveToTarget);
				yield return itemToSalvage.IncrementStateCoroutine(AnimationEventType);
			}
			remaingItterations--;
		}
		if (!_assignment.ItemsToHaul.IsNullOrEmpty())
		{
			Debug.LogException(new Exception($"[{project.Properties}] '{agent.Descriptor.Name}' finished SalvageLandmark task with {_assignment.ItemsToHaul.Count} remaining ItemToHaul."));
		}
		new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, Attribute).Dispatch();
	}

	protected override void OnGUI()
	{
		Header("Salvage landmark", 2, Color.green);
		EditorGUI_HelpBox("Salvage items from a landmark.");
		EditorGUI_PropertyField("AnimationEventType", "Rig Animation Event Type");
		Attribute = (DrifterAttributes.AttributeType)(object)EditorGUI_EnumField("Attribute", Attribute);
	}

	protected override void OnItemSalvaged(ItemToHaul salvagedItem)
	{
		new AgentActionItemPropertiesEvent(GameEventType.AgentActionSalvagedLandmarkItem, _assignment.Agent, salvagedItem.Item.Properties, Attribute).Dispatch();
	}

	private void ValidateState(Agent agent)
	{
		if (agent.ReturnNavigator().Terrain != Navigator.TerrainType.UnityNavMesh)
		{
			_assignment.Stop(ProjectFlags.OutOfBounds | ProjectFlags.BugFix);
		}
	}

	private bool CanSalvageItem(SubInventory transitInventory, ItemToHaul itemToHaul)
	{
		return transitInventory.Count < itemToHaul.TargetInventory.ReturnInventory(itemToHaul.TargetSubInventory).AvailableCapacity;
	}
}
