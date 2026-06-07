using System.Collections;
using UnityEngine;

public class HaulItems : TaskBase
{
	public DrifterRigEventType AnimationEventType;

	public override TaskType Type => TaskType.HaulItems;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		yield return RunHaulStateCoroutine(agent, ItemToHaul.HaulState.Pickup, AnimationEventType);
		yield return RunHaulStateCoroutine(agent, ItemToHaul.HaulState.Transit, AnimationEventType);
	}

	protected override void OnGUI()
	{
		Header("Haul items", 1, Color.magenta);
		EditorGUI_PropertyField("AnimationEventType", "Rig Animation Event Type");
		EditorGUI_HelpBox("Hauls the items reserved by the 'Reserve Items To Haul' task");
	}
}
