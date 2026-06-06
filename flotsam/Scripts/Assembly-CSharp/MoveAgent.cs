using System.Collections;

public class MoveAgent : TaskBase
{
	public MoveTarget AgentMoveTarget;

	public override TaskType Type => TaskType.MoveAgent;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		ItemToHaul itemToHaul;
		ITarget target = ((!_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Pickup, out itemToHaul)) ? ReturnTarget(agent, project, AgentMoveTarget) : ReturnTarget(agent, project, AgentMoveTarget, itemToHaul.Item));
		yield return MoveAgentCoroutine(target);
	}

	protected override void OnGUI()
	{
		Header("Move agent", 1, ReturnTypeColor());
		AgentMoveTarget = (MoveTarget)(object)EditorGUI_EnumField("Agent move target", AgentMoveTarget);
		EditorGUI_HelpBox("Moves the agent to a waypoint.");
	}
}
