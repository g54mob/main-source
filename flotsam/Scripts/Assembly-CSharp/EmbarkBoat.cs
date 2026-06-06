using System;
using System.Collections;
using UnityEngine;

public class EmbarkBoat : TaskBase
{
	public bool BoatIsTarget;

	public override TaskType Type => TaskType.EmbarkBoat;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		if ((bool)_assignment.Boat && _assignment.Boat.Captain == agent)
		{
			Debug.LogException(new Exception("'" + agent.Descriptor.Name + "' is trying to embark a boat of which it already is the captain"));
		}
		else if (BoatIsTarget)
		{
			Boat boatToReclaim = project.Target.GetComponent<Boat>();
			Target component = project.Target.GetComponent<Target>();
			if (boatToReclaim == null)
			{
				Debug.LogException(new Exception($"'{agent.Name}' assigned to '{project.Properties}' is unable to reclaim a boat because the project.Target is not a boat!"));
				_project.Stop(ProjectFlags.Exception);
			}
			else
			{
				yield return MoveAgentCoroutine(component);
				boatToReclaim.BoardCaptain(agent);
			}
		}
		else if ((bool)_assignment.ReservedEmbarkMooringPoint)
		{
			MooringPointBase mooringPoint = _assignment.ReservedEmbarkMooringPoint;
			yield return MoveAgentCoroutine(mooringPoint.EmbarkTarget);
			yield return mooringPoint.EmbarkCoroutine(agent);
			_assignment.UnreserveEmbarkMooringPoint();
		}
		else
		{
			_project.Stop(ProjectFlags.Exception);
			Debug.LogException(new Exception($"'{agent.Name}' assigned to '{project.Properties}' is trying to embark a boat, but does not have an embark mooring point reserved!"));
		}
	}

	protected override void OnGUI()
	{
		Header("Embark boat", 1, ReturnTypeColor());
		BoatIsTarget = EditorGUI_Toggle("Reclaim", BoatIsTarget);
		EditorGUI_HelpBox("Moves to and embarks a boat.");
	}
}
