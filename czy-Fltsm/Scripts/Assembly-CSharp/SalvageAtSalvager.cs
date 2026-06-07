using System;
using System.Collections;
using UnityEngine;

public class SalvageAtSalvager : TaskBase
{
	private Salvager _salvager;

	public override TaskType Type => TaskType.SalvageAtSalvager;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (!TryReturnTargetBuildableExtendable<Salvager>(project, out _salvager))
		{
			yield break;
		}
		AgentActionEvent.Dispatch(GameEventType.AgentActionStartedWorking, agent, _salvager.DrifterAttribute);
		AnimatorHelper.AddDirfterRigEventListener(agent, OnDrifterRigItemEvent);
		Item item;
		while (TryReturnNextItemToSalvage(project, agent, out item))
		{
			if (item.Project != null)
			{
				Debug.LogException(new Exception($"'{agent.Descriptor.Name}' is trying to salvage '{item.Properties.name}', which is already assigned to '{item.Project.Properties}'"));
			}
			_salvager.StartSalvage(item, agent);
			while (_salvager.SalvageableState == Salvager.State.Salvaging)
			{
				_salvager.Salvage(agent);
				yield return null;
			}
			if (_salvager.SalvageableState == Salvager.State.SalvagingFinished)
			{
				AnimatorHelper.SetTransitionTrigger(agent);
				yield return new WaitForSeconds(AnimatorHelper.ReturnCurrentAnimatorStateLength(agent));
			}
		}
		StopWorking(agent, _salvager);
	}

	public override void Stop()
	{
		StopWorking(_agent, _salvager);
		base.Stop();
	}

	private void StopWorking(Agent agent, Salvager salvager)
	{
		if ((bool)agent)
		{
			if ((bool)salvager && salvager.SalvagingAgent == _agent)
			{
				salvager.StopSalvage(_agent);
			}
			AnimatorHelper.RemoveDirfterRigEventListener(_agent, OnDrifterRigItemEvent);
			AgentActionEvent.Dispatch(GameEventType.AgentActionStoppedWorking, agent, _salvager.DrifterAttribute);
		}
	}

	private void OnDrifterRigItemEvent(DrifterRigItemEvent evt)
	{
		switch (evt.Id)
		{
		case DrifterRigItemEvent.ID.SetItem:
			if ((bool)_salvager && _salvager.CurrentItem != null)
			{
				evt.SetItem(_salvager.CurrentItem.ReturnSubItem().Properties);
			}
			else
			{
				Debug.LogException(new Exception("Unable to set salvager item."));
			}
			break;
		case DrifterRigItemEvent.ID.ClearItem:
			if ((bool)_salvager && _salvager.CurrentItem != null)
			{
				Item currentItem = _salvager.CurrentItem;
				_salvager.SalvageItem();
				new AgentActionItemPropertiesEvent(GameEventType.AgentActionSalvagedSalvagerItem, _agent, currentItem.Properties, _salvager.DrifterAttribute).Dispatch();
			}
			else
			{
				Debug.LogException(new Exception("Unable to clear salvager item."));
			}
			evt.ClearItem();
			break;
		}
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		if (!TryReturnTargetBuildableExtendable<Salvager>(project, out var buildableExtendable) || !buildableExtendable.IsEnabled() || !buildableExtendable.CanRun())
		{
			return ProjectBlocker.BuildingNotAvailable;
		}
		if (!buildableExtendable.TryReturnClosestAvailableItem(out var _))
		{
			return ProjectBlocker.NoItemAvailable;
		}
		return ProjectBlocker.None;
	}

	protected override void OnGUI()
	{
		Header("Salvage at Salvager", 1, Color.green);
		EditorGUI_HelpBox("Salvage an item at the salvager.");
	}

	private bool TryReturnNextItemToSalvage(Project project, Agent agent, out Item item)
	{
		item = null;
		if (_salvager.CanRun() && agent.Community.ProjectRemainsPriority(project, agent))
		{
			return _salvager.TryReturnClosestAvailableItem(out item);
		}
		return false;
	}
}
