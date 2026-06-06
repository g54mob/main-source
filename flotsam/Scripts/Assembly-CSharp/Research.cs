using System;
using System.Collections;

public class Research : TaskBase
{
	public override TaskType Type => TaskType.Research;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		CommunityResearch research = agent.Community.Research;
		ResearchStation station = research.ReturnClosestAvailableResearchStation(agent);
		if (station == null)
		{
			throw new NotImplementedException($"Cannot run research task for {agent.Name} as no station was available.");
		}
		CommunityResearch buildingResearch = station.Buildable.Community.Research;
		station.ReservingAgent = agent;
		Target component = station.GetComponent<Target>();
		yield return MoveAgentCoroutine(component);
		new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, DrifterAttributes.AttributeType.Research).Dispatch();
		station.StartResearch(agent);
		while (!station.Research(agent) && buildingResearch.RequiresMoreResearchStations(station) && buildingResearch.HasPointToResearch(station) && station.ReturnCanRun())
		{
			yield return null;
		}
		station.FinishResearch();
		new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, DrifterAttributes.AttributeType.Research).Dispatch();
	}

	public override void Stop()
	{
		ResearchStation researchStation = _agent.Community.Research.ReturnReservedResearchStation(_agent);
		if (researchStation != null)
		{
			researchStation.StopResearch();
		}
	}

	protected override void OnGUI()
	{
		Header("Research", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Research the current research at all stations.");
	}

	public override bool ReturnCanFinish(Project project)
	{
		return !Community.PlayerCommunity.Research.IsResearching();
	}

	public override ProjectBlocker ReturnBlockers(Project project)
	{
		ProjectBlocker projectBlocker = base.ReturnBlockers(project);
		CommunityResearch research = Community.PlayerCommunity.Research;
		if (research.CurrentResearch == null)
		{
			projectBlocker |= ProjectBlocker.NoResearch;
		}
		if (!research.HasAvailableResearchStation())
		{
			projectBlocker |= ProjectBlocker.NoResearch;
		}
		if (!research.RequiresMoreResearchStations(null))
		{
			return ProjectBlocker.BuildingNotAvailable;
		}
		if (!research.HasPointToResearch(null))
		{
			return ProjectBlocker.BuildingNotAvailable;
		}
		return projectBlocker;
	}
}
