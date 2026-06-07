using System.Collections;
using UnityEngine;

public class ImportUnlock : TaskBase
{
	public override TaskType Type => TaskType.ImportUnlock;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Producer component = project.Target.GetComponent<Producer>();
		if ((bool)component)
		{
			component.IsBlockedByImport = false;
		}
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Import unlock", 0, Color.green);
		EditorGUI_HelpBox("Sets the 'IsBlockedByImport' flag on a producer to false.");
	}
}
