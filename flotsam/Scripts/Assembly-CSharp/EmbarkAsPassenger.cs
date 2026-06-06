using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class EmbarkAsPassenger : TaskBase
{
	public string taskName;

	private Boat _boat;

	public override TaskType Type => TaskType.RescueLandmark;

	public override void Initialize(ProjectAssignment assignment)
	{
		base.Initialize(assignment);
		_boat = assignment.Project.Target.GetComponent<Boat>();
	}

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if (!(_boat == null))
		{
			_boat.ReservePassage(agent);
			yield return MoveAgentCoroutine(_boat.GetComponent<Target>().ReturnTarget());
			_boat.BoardPassenger(agent);
		}
	}

	public override void Stop()
	{
		if (_boat != null)
		{
			_boat.UnreservePassage(_assignment.Agent);
		}
	}

	protected override void OnGUI()
	{
		Header("Embark boat as passenger", 0, Color.cyan);
		EditorGUI_HelpBox("Move to then embark on the target boat as passenger.");
	}
}
