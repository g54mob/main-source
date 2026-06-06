using System.Collections;
using UnityEngine;

public class OccupyMedPod : TaskBase
{
	public override TaskType Type => TaskType.GoToMedPod;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (project.Target.TryGetComponent<MedPod>(out var medPod) && medPod.Occupy(agent))
		{
			while (medPod.OccupyingPatient == agent)
			{
				yield return null;
			}
			if (agent.ReturnNavigator().AttachToTarget(project.Target.GetComponent<Construction>().Target))
			{
				agent.ReturnNavigator().AttachToTarget(agent.ReturnClosestWalkwayConstruction().Target);
			}
			agent.UpdateActivity(Activity.Idling);
		}
		else
		{
			Debug.LogErrorFormat("'{0}' was unable to occupy a MedPod", agent.Name);
		}
	}

	protected override void OnGUI()
	{
		Header("Occupy MedPod", 0, Color.green);
		EditorGUI_HelpBox("Occupy a MedPod that is reserved for the agent.");
	}
}
