using System.Collections;
using UnityEngine;

public class WorkAtClinic : TaskBase
{
	[SerializeField]
	private Activity _activity;

	public override TaskType Type => TaskType.WorkAtClinic;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (project.Target.TryGetComponent<Clinic>(out var clinic))
		{
			clinic.Open(agent);
			while (!clinic.CanClose())
			{
				yield return null;
			}
			clinic.Close();
			if (agent.ReturnNavigator().AttachToTarget(project.Target.GetComponent<Construction>().Target))
			{
				agent.ReturnNavigator().AttachToTarget(agent.ReturnClosestWalkwayConstruction().Target);
			}
			agent.UpdateActivity(_activity);
		}
	}

	protected override void OnGUI()
	{
		Header("Work At The Clinic", 0, Color.red);
		EditorGUI_PropertyField("_activity");
		EditorGUI_HelpBox("A specialist will be at the clinic to prescribe medicine to sick drifters");
	}
}
