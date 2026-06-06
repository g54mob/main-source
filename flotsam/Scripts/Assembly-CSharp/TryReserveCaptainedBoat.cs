using System.Collections;

public class TryReserveCaptainedBoat : TaskBase
{
	public override TaskType Type => TaskType.ReserveBoat;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (agent.IsCaptain)
		{
			_assignment.ReserveAgentBoat(agent);
		}
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Try Reserve captained boat", 0, ReturnTypeColor());
		EditorGUI_HelpBox("Special task that tries to 'Reserve' the agents boat when it is a captain, if not nothing happens. This task should only be used for projects that do not have a ReserveBoat task but do have a Disembark task (e.g. GotToTowm).");
	}
}
