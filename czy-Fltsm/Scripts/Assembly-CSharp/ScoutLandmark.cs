using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutLandmark : TaskBase
{
	public override TaskType Type => TaskType.ScoutLandmark;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Landmark component = project.Target.GetComponent<Landmark>();
		List<ITarget> waypoints = ListPool<ITarget>.Get(component.ReturnScoutTargets(agent.ReturnNavigator().Position));
		waypoints.Add(agent.Community.ReturnClosestAvailableMooringPoint(agent.transform.position).MooringTarget);
		while (0 < waypoints.Count)
		{
			yield return MoveAgentCoroutine(waypoints[0]);
			waypoints.RemoveAt(0);
		}
		ListPool<ITarget>.Add(waypoints);
	}

	protected override void OnGUI()
	{
		Header("Scout landmark", 0, Color.magenta);
		EditorGUI_HelpBox("Scout a landmark.");
	}
}
