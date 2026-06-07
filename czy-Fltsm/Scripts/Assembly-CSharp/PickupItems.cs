using System.Collections;
using UnityEngine;

public class PickupItems : TaskBase
{
	public DrifterRigEventType AnimationEventType;

	public override TaskType Type => TaskType.PickupItem;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		yield return RunHaulStateCoroutine(agent, ItemToHaul.HaulState.Pickup);
	}

	private IEnumerator RunHaulStateCoroutine(Agent agent, ItemToHaul.HaulState state)
	{
		ItemToHaul itemToHaul;
		while (_assignment.TryReturnItemToHaul(state, out itemToHaul))
		{
			yield return MoveAgentCoroutine(itemToHaul.MoveToTarget);
			new AgentActionEvent(GameEventType.AgentActionStartedWorking, agent, DrifterAttributes.AttributeType.Athletics).Dispatch();
			yield return itemToHaul.IncrementStateCoroutine(AnimationEventType);
			new AgentActionItemPropertiesEvent(GameEventType.AgentActionItemHauled, agent, itemToHaul.Item.Properties, DrifterAttributes.AttributeType.Athletics).Dispatch();
			new AgentActionEvent(GameEventType.AgentActionStoppedWorking, agent, DrifterAttributes.AttributeType.Athletics).Dispatch();
		}
	}

	protected override void OnGUI()
	{
		Header("Pickup Items", 1, Color.magenta);
		EditorGUI_PropertyField("AnimationEventType", "Rig Animation Event Type");
		EditorGUI_HelpBox("Picks up the items reserved by the 'Reserve Items To Haul' task");
	}
}
