using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class RescueLandmark : TaskBase
{
	public string taskName;

	public override TaskType Type => TaskType.RescueLandmark;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Boat rescueingBoat = _assignment.Boat;
		LandmarkRescueable[] componentsInChildren = project.Target.GetComponentsInChildren<LandmarkRescueable>();
		foreach (LandmarkRescueable rescueable in componentsInChildren)
		{
			if (!rescueable.Agent || !rescueingBoat || rescueingBoat.NumberOfRemainingCrewSpots > 0)
			{
				yield return MoveAgentCoroutine(rescueable.Target);
				rescueable.StartCoroutine(rescueable.IsRescuedCoroutine(_assignment.Project, _assignment.Boat));
				_agent.UpdateActivity(Activity.Diving);
				yield return new WaitForSeconds(1f);
			}
		}
	}

	protected override void OnGUI()
	{
		Header("Rescue on landmark", 0, Color.yellow);
		EditorGUI_HelpBox("Rescues refugees from a landmark.");
	}
}
