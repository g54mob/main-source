using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Disembark : TaskBase
{
	public string taskName;

	public override TaskType Type => TaskType.RescueLandmark;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		yield return new WaitWhile(() => agent.Boat.CurrentMooringPoint != null);
		yield return new WaitWhile(() => agent.Boat.CurrentMooringPoint == null);
		agent.Boat.Disembark(agent);
	}

	protected override void OnGUI()
	{
		Header("Disembark", 0, Color.cyan);
		EditorGUI_HelpBox("Disembarks once the boat is moored.");
	}
}
