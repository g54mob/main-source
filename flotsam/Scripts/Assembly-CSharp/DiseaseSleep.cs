using System.Collections;
using UnityEngine;

public class DiseaseSleep : TaskBase
{
	public override TaskType Type => TaskType.DiseaseSleep;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Disease disease = agent.Vitals.Pollution.CurrentDisease;
		if (disease == null)
		{
			yield break;
		}
		Rejuvenator house = null;
		Target target;
		if (agent.ReservedHouse == null)
		{
			target = agent.ReturnClosestConstruction(onlyFinished: true).Target;
		}
		else
		{
			target = agent.ReservedHouse.GetComponentInChildren<Target>();
			house = agent.ReservedHouse.Rejuvenator;
		}
		yield return MoveAgentCoroutine(target);
		if (house != null)
		{
			house.AddAgent(agent);
		}
		agent.UpdateActivity(Activity.Sleeping);
		agent.WorldIconHandler.AddIcon(disease.Icon);
		while (!disease.Progress(agent, Time.deltaTime))
		{
			yield return null;
		}
		if (house != null)
		{
			house.RemoveAgent(agent, GameManager.AgentManager.AgentParent);
			if (!agent.ReturnNavigator().AttachToTarget(target))
			{
				agent.ReturnNavigator().AttachToTarget(agent.ReturnClosestWalkwayConstruction().Target);
			}
		}
		agent.WorldIconHandler.RemoveIcon(disease.Icon);
	}

	protected override void OnGUI()
	{
		Header("Disease - Sleep", 2, Color.cyan);
		EditorGUI_HelpBox("A disease that makes the drifter sleep for a while.");
	}
}
