using System.Collections;
using UnityEngine;

public class WorkAtBuildable : TaskBase
{
	public override TaskType Type => TaskType.WorkAtBuildable;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		IWorkPlace workPlace = project.Target.GetComponent<IWorkPlace>();
		if (workPlace == null)
		{
			Debug.LogErrorFormat("Unable to work at project target '{0}' it is not an IWorldPlace.", project.Target.name);
			yield break;
		}
		workPlace.StartWorking(agent);
		while (workPlace.IsWorking(agent))
		{
			yield return null;
		}
		agent.ReturnNavigator().AttachToTarget(project.Target.GetComponent<Construction>().Target);
		agent.UpdateActivity(Activity.Idling);
	}

	protected override void OnGUI()
	{
		Header("Work At Buildable", 0, Color.red);
		EditorGUI_HelpBox("A drifter will go to work at a Buildable that implements IWorkPlace");
	}
}
