using System.Collections;

public class Fishing : TaskBase
{
	public float Duration;

	public DrifterRigEventType AnimationEventType;

	public override TaskType Type => TaskType.Fishing;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		ItemToHaul itemToHaul;
		while (_assignment.TryReturnItemToHaul(ItemToHaul.HaulState.Pickup, out itemToHaul))
		{
			yield return MoveAgentCoroutine(itemToHaul.MoveToTarget);
			yield return itemToHaul.IncrementStateCoroutine(AnimationEventType);
		}
	}

	protected override void OnGUI()
	{
		Header("Fishing", 2, ReturnTypeColor());
		Duration = EditorGUI_FloatField("Duration", Duration);
		EditorGUI_PropertyField("AnimationEventType", "Rig Animation Event Type");
		EditorGUI_HelpBox("Fish near a school of fishes.");
	}
}
