using System;
using System.Collections;

public class InvestigateLandmark : TaskBase
{
	public override TaskType Type => TaskType.InvestigateLandmark;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Landmark landmark = project.Target.GetComponentInParent<Landmark>();
		if (landmark == null)
		{
			throw new NotSupportedException();
		}
		landmark.Interact(agent);
		while (landmark.BeingInteractedWith)
		{
			yield return null;
		}
	}

	protected override void OnGUI()
	{
		Header("Investigate landmark", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Investigate the targeted Landmark.");
	}
}
