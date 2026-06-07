using System;
using System.Collections;
using PajamaLlama.Debugs;
using UnityEngine;

[Serializable]
public class RescueAnimalLandmark : TaskBase
{
	public string taskName;

	public override TaskType Type => TaskType.RescueAnimalLandmark;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		project.Target.GetComponent<Landmark>();
		LandmarkRescueable[] rescueables = project.Target.GetComponentsInChildren<LandmarkRescueable>();
		if (rescueables.Length == 0)
		{
			Debugger.Warning("There is no animal to rescue.");
			yield break;
		}
		for (int i = 0; i < rescueables.Length; i++)
		{
			yield return MoveAgentCoroutine(rescueables[i].Target);
			rescueables[i].Bird.StartCoroutine(rescueables[i].IsRescuedCoroutine(project));
			agent.UpdateActivity(Activity.Diving);
			yield return new WaitForSeconds(1f);
		}
	}

	protected override void OnGUI()
	{
		Header("Rescue animal on landmark", 0, Color.green);
		EditorGUI_HelpBox("Rescues animals from a landmark.");
	}
}
