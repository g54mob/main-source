using System.Collections;
using UnityEngine;

public class SalvageLock : TaskBase
{
	public bool Lock;

	public override TaskType Type => TaskType.SalvageLock;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		agent.SalvageLock = Lock;
		yield break;
	}

	protected override void OnGUI()
	{
		Header("Salvage lock", 1, Color.red);
		Lock = EditorGUI_Toggle("Should the salvage be locked?", Lock);
		EditorGUI_HelpBox("Sets the 'Salvage Lock' flag on a drifter. This is a temporary solution.");
	}
}
