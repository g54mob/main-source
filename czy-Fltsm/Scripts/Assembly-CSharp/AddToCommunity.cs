using System;
using System.Collections;
using UnityEngine;

public class AddToCommunity : TaskBase
{
	public enum AddToCommunityType
	{
		Agent = 0,
		Boat = 1
	}

	public AddToCommunityType TypeOfObjectToAdd;

	public override TaskType Type => TaskType.AddToCommunity;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		switch (TypeOfObjectToAdd)
		{
		case AddToCommunityType.Agent:
		{
			if (!agent.ReturnNavigator().IsInRange(project.Target.GetComponent<Target>()))
			{
				project.Stop(ProjectFlags.Exception);
				Debug.LogException(new Exception("'" + agent.Name + "' is not in range and could not be added to the town."));
				yield break;
			}
			if (!project.Target.GetComponent<Agent>().IsAlive)
			{
				yield break;
			}
			Agent component2 = project.Target.GetComponent<Agent>();
			Community.PlayerCommunity.AddAgent(component2);
			new AgentEvent(GameEventType.AgentRescue, component2).Dispatch();
			if (component2.Boat != null)
			{
				if (Community.PlayerCommunity.IsThereAMooringPointFree())
				{
					component2.Boat.RemoveFromCommunity();
					component2.Boat.AddToCommunity(Community.PlayerCommunity);
				}
				else
				{
					component2.Boat.Abandon(component2);
				}
			}
			agent.TryGoToTown();
			break;
		}
		case AddToCommunityType.Boat:
		{
			Boat component = project.Target.GetComponent<Boat>();
			if (component.TownMooringPoint == null)
			{
				if (!TryReturnUnlinkedMooringPoint(agent.Community, out var unlinkedMooringPoint))
				{
					_assignment.Stop(ProjectFlags.Exception);
					Debug.LogException(new Exception("'" + agent.Name + "' was unable to reclaim boat '" + component.Buildable.Name + "' because there is no mooring point available in the town."));
					yield break;
				}
				unlinkedMooringPoint.LinkBoat(component);
			}
			component.AddToCommunity(Community.PlayerCommunity);
			break;
		}
		}
		yield return null;
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		if (TypeOfObjectToAdd == AddToCommunityType.Boat && project.Target.GetComponent<Boat>().TownMooringPoint == null && !TryReturnUnlinkedMooringPoint(Community.PlayerCommunity, out var _))
		{
			return ProjectBlocker.NoAvailableMooringPointAtTarget;
		}
		return ProjectBlocker.None;
	}

	protected override void OnGUI()
	{
		Header("Add To Community", 1, ReturnTypeColor());
		TypeOfObjectToAdd = (AddToCommunityType)(object)EditorGUI_EnumField("Community Subject Type", TypeOfObjectToAdd);
		EditorGUI_HelpBox("Add the current target of the project to the player community.");
	}

	private bool TryReturnUnlinkedMooringPoint(Community community, out MooringPoint unlinkedMooringPoint)
	{
		foreach (MooringPoint item in community.ReturnAllMooringPoints())
		{
			if (item.Buildable.BuildPhase == BuildPhase.Finished && item.LinkedBoat == null)
			{
				unlinkedMooringPoint = item;
				return true;
			}
		}
		unlinkedMooringPoint = null;
		return false;
	}
}
