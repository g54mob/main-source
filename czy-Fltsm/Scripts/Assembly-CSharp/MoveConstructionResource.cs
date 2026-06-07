using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstructionResource : TaskBase
{
	[SerializeField]
	private SubInventoryType _from = SubInventoryType.Resources;

	[SerializeField]
	private SubInventoryType _to = SubInventoryType.Composition;

	[SerializeField]
	private float _duration;

	[SerializeField]
	private GameEventType _movedEvent = GameEventType.AgentActionCompositionAdded;

	private Item _resourceToMove;

	public override TaskType Type => TaskType.CompleteComposition;

	public float Duration => _duration;

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		Inventory targetInventory = project.TargetInventory;
		if (targetInventory != null)
		{
			if (targetInventory.TryReturnFirstAvailableItem(_from, out var _))
			{
				return ProjectBlocker.None;
			}
		}
		else
		{
			project.Stop(ProjectFlags.Exception);
		}
		return ProjectBlocker.NoItemAvailable;
	}

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Navigator navigator = agent.ReturnNavigator();
		Buildable buildable = project.TargetBuildable;
		Inventory inventory = project.TargetInventory;
		Day day = GameManager.TimeManager.CurrentDay;
		navigator.UpdateTerrain(Navigator.TerrainType.Construction, overrideUpdate: true);
		if (buildable != null)
		{
			buildable.BuildSlots.Attach(agent.transform);
		}
		agent.UpdateActivity(Activity.Building);
		new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, DrifterAttributes.AttributeType.Construction).Dispatch();
		float timer = 0f;
		while (TryReturnNextResource(project, day, out _resourceToMove))
		{
			_assignment.ReserveItem(_resourceToMove);
			while (timer < _duration && project.Assignments.Count <= project.AssignmentLimit)
			{
				timer += Time.deltaTime * agent.Attributes.ReturnAttributeModifier(DrifterAttributes.AttributeType.Construction);
				yield return null;
			}
			if (_duration <= timer)
			{
				inventory.MoveToSubInventory(_resourceToMove, _to);
				timer = 0f;
			}
			_assignment.UnreserveItem(_resourceToMove);
			new AgentActionItemPropertiesEvent(_movedEvent, agent, _resourceToMove.Properties, DrifterAttributes.AttributeType.Construction).Dispatch();
		}
		if (buildable != null)
		{
			buildable.BuildSlots.Detach(GameManager.AgentManager.AgentParent);
		}
		navigator.AttachToTarget(agent.ReturnClosestConstruction(onlyFinished: true).Target, overrideCheck: true);
		new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, DrifterAttributes.AttributeType.Construction).Dispatch();
	}

	public override void Stop()
	{
		if (_resourceToMove != null)
		{
			_assignment.UnreserveItem(_resourceToMove);
		}
	}

	public override bool ReturnCanFinish(Project project)
	{
		return project.TargetInventory.ReturnIsEmpty(_from);
	}

	protected override void OnGUI()
	{
		Header("Move Construction Resource", 4, ReturnTypeColor());
		EditorGUI_PropertyField("_from");
		EditorGUI_PropertyField("_to");
		EditorGUI_PropertyField("_duration");
		EditorGUI_PropertyField("_movedEvent");
		EditorGUI_HelpBox("Complete the composition list of an inventory.");
	}

	private bool TryReturnNextResource(Project project, Day day, out Item resource)
	{
		resource = null;
		if (project.Assignments.Count > project.AssignmentLimit || day.DayTime != Day.E_DayTime.Day)
		{
			return false;
		}
		if (_assignment.ReservedItem != null)
		{
			resource = RestoreReservedItemReference(project.TargetInventory);
			return true;
		}
		return project.TargetInventory.TryReturnFirstAvailableItem(_from, out resource);
	}

	private Item RestoreReservedItemReference(Inventory inventory)
	{
		Item reservedItem = _assignment.ReservedItem;
		foreach (Item item in (IEnumerable<Item>)inventory.ReturnAllItems(_from))
		{
			if (item.Properties == reservedItem.Properties)
			{
				_assignment.UnreserveItem(reservedItem);
				return item;
			}
		}
		return reservedItem;
	}
}
