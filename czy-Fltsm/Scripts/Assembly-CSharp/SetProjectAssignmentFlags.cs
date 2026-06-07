using System.Collections;
using UnityEngine;

public class SetProjectAssignmentFlags : TaskBase
{
	[SerializeField]
	private ProjectAssignmentFlags _flags;

	public override TaskType Type => TaskType.SetProjectAssignmentFlags;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		_assignment.SetFlags(_flags);
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Set Project Assignment Flags.", 1, Color.red);
		EditorGUI_HelpBox("Set flags on the project assignment. This Task should also be used to clear the flags if needed.");
		EditorGUI_PropertyField("_flags", "Flags");
	}
}
