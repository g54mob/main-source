using System;
using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public class ReserveBoat : TaskBase, IComparer<MooringPointBase>
{
	public bool ReserveMooringPointAtTarget;

	public BoatType BoatType;

	public bool ReserveProjectTarget;

	private Vector3 _agentPosition;

	public override TaskType Type => TaskType.ReserveBoat;

	public override bool DoYieldReturn => false;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (agent.IsCaptain)
		{
			yield break;
		}
		if (ReserveProjectTarget)
		{
			Boat component = project.Target.GetComponent<Boat>();
			if (component == null)
			{
				Debug.LogErrorFormat("'{0}' could not reserve boat because project target '{1}' is not a boat!", agent.Name, project.Target);
			}
			else if (component.CurrentMooringPoint == null)
			{
				Debug.LogWarningFormat("'{0}' could not reserve boat for project '{1}'!", agent.Name, project.Properties.name);
			}
			else
			{
				_assignment.ReserveBoat(component);
			}
		}
		else if (ReserveMooringPointAtTarget)
		{
			Target navigationTarget = project.NavigationTarget;
			if (navigationTarget == null)
			{
				_project.Stop(ProjectFlags.Exception);
				Debug.LogException(new Exception($"'{agent.Name}' assigned to '{_project.Properties}' was unable to reserve a boat of type '{BoatType}' because the project.NavigationTarge is NULL!"));
			}
			else if (!TryReserveEmbarkAndDisembarkMooringPoint(agent, navigationTarget))
			{
				_project.Stop(ProjectFlags.Exception);
				Debug.LogException(new Exception($"'{agent.Name}' assigned to '{_project.Properties}' was unable to reserve a boat of type '{BoatType}' because none are available in its community or was unable to reserve a mooring point at target '{navigationTarget.transform.RetrieveHierarchyString()}'"));
			}
		}
		else if (!TryReserveEmbarkMoorinPoint(agent))
		{
			_project.Stop(ProjectFlags.Exception);
			Debug.LogException(new Exception($"'{agent.Name}' assigned to '{_project.Properties}' was unable to reserve a boat of type '{BoatType}' because none are available in its community"));
		}
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		ProjectBlocker projectBlocker = ProjectBlocker.None;
		if (!ReserveProjectTarget)
		{
			if (ReserveMooringPointAtTarget)
			{
				if (!ReturnCommunityHasBoatAvailableForTarget(Community.PlayerCommunity, project.NavigationTarget))
				{
					projectBlocker |= ProjectBlocker.NoBoatAvailable;
				}
			}
			else if (!ReturnCommunityHasBoatAvailable(Community.PlayerCommunity))
			{
				projectBlocker |= ProjectBlocker.NoBoatAvailable;
			}
		}
		if (!GameManager.WorldManager.IsInBoatRadius(project.Target.transform.position))
		{
			projectBlocker |= ProjectBlocker.BoatOutOfRange;
		}
		return projectBlocker;
	}

	protected override void OnGUI()
	{
		Header("Reserve boat", 3, ReturnTypeColor());
		ReserveMooringPointAtTarget = EditorGUI_Toggle("Reserve mooring point at target?", ReserveMooringPointAtTarget);
		BoatType = (BoatType)(object)EditorGUI_EnumField("Required Boat Type", BoatType);
		ReserveProjectTarget = EditorGUI_Toggle("Reserve the project's target boat's mooring point instead of the closest mooring point.?", ReserveProjectTarget);
		EditorGUI_HelpBox("Reserves the closest available boat from a mooring point.");
	}

	public bool ReturnCommunityHasBoatAvailableForTarget(Community community, Target target)
	{
		if (target == null)
		{
			return false;
		}
		using ListPool<MooringPoint>.List list = ReturnEmbarMooringPoints(community);
		foreach (MooringPoint item in list)
		{
			if (target.TryReturnAvailableMooringPoint(item.MooredBoat, out var _))
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnCommunityHasBoatAvailable(Community community)
	{
		using ListPool<MooringPoint>.List list = ReturnEmbarMooringPoints(community);
		return 0 < list.Count;
	}

	private bool TryReserveEmbarkMoorinPoint(Agent agent)
	{
		using ListPool<MooringPoint>.List list = ReturnEmbarMooringPoints(agent.Community);
		if (0 < list.Count)
		{
			_assignment.ReserveBoat(list[0].MooredBoat);
			return true;
		}
		return false;
	}

	private bool TryReserveEmbarkAndDisembarkMooringPoint(Agent agent, Target target)
	{
		using ListPool<MooringPoint>.List list = ReturnEmbarMooringPoints(agent.Community);
		foreach (MooringPoint item in list)
		{
			if (target.TryReturnAvailableMooringPoint(item.MooredBoat, out var mooringPoint))
			{
				_assignment.ReserveBoat(item.MooredBoat);
				_assignment.ReserveDisembarkMooringPoint(mooringPoint);
				return true;
			}
		}
		return false;
	}

	private ListPool<MooringPoint>.List ReturnEmbarMooringPoints(Community community)
	{
		ListPool<MooringPoint>.List list = ListPool<MooringPoint>.Get();
		foreach (MooringPoint item in community.ReturnAllMooringPoints())
		{
			if (item.ReturnHasAvailableBoat(BoatType))
			{
				list.Add(item);
			}
		}
		if (_assignment != null)
		{
			_agentPosition = _assignment.Agent.transform.position;
			Sorting.SlowSort(list, this);
		}
		return list;
	}

	public int Compare(MooringPointBase x, MooringPointBase y)
	{
		float num = _agentPosition.DistanceToLeveledSquared(x.transform.position);
		float num2 = _agentPosition.DistanceToLeveledSquared(y.transform.position);
		return (int)(num - num2);
	}
}
