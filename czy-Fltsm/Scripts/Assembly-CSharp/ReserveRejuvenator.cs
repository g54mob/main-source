using System.Collections;

public class ReserveRejuvenator : TaskBase
{
	public override TaskType Type => TaskType.ReserveRejuvenator;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if ((bool)project.Target && project.Target.TryGetComponent<Rejuvenator>(out var component))
		{
			component.SetCurrentStage(Rejuvenator.Stage.WaitingToStart);
		}
		yield return null;
	}

	protected override void OnGUI()
	{
		Header("Reserve Rejuvenator", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Reserve the rejuvenator at the project target.");
	}
}
