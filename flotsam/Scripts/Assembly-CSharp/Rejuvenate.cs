using System;
using System.Collections;
using UnityEngine;

public class Rejuvenate : TaskBase
{
	public override TaskType Type => TaskType.Rejuvenate;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (!agent.Vitals.IsMarkedForDeath() && (bool)project.Target && project.Target.TryGetComponent<Rejuvenator>(out var rejuvenator))
		{
			rejuvenator.AddAgent(agent);
			agent.UpdateActivity(rejuvenator.Properties.Activity);
			rejuvenator.SetCurrentStage(Rejuvenator.Stage.Rejuvenating);
			yield return rejuvenator.RejuvenateCoroutine(agent);
			if (rejuvenator.RejuvenatesVital(VitalType.Rest))
			{
				new AgentEvent(GameEventType.AgentSleptInHouse, agent).Dispatch();
			}
			else
			{
				Debug.LogException(new NotImplementedException("Rejuvenator '" + rejuvenator.Buildable.Name + "' does not rejuvenate 'Rest'."));
			}
			rejuvenator.SetCurrentStage(Rejuvenator.Stage.Idle);
			rejuvenator.RemoveAgent(agent, GameManager.AgentManager.AgentParent);
			if (!agent.ReturnNavigator().AttachToTarget(rejuvenator.GetComponent<Construction>().Target))
			{
				agent.ReturnNavigator().AttachToTarget(agent.ReturnClosestWalkwayConstruction().Target);
			}
		}
	}

	protected override void OnGUI()
	{
		Header("Rejuvenate", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Rejuvenate at the project target.");
	}
}
