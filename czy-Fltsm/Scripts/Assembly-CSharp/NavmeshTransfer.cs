using System.Collections;
using PajamaLlama.Math;
using UnityEngine;

public class NavmeshTransfer : TaskBase
{
	public override TaskType Type => TaskType.Transition;

	public override IEnumerator RunTaskCoroutine(Agent agent, Project project)
	{
		Navigator navigator = agent.ReturnNavigator(alwaysReturnDrifter: true);
		MooringPointBase mooringPoint = project.NavigationTarget.ReturnClosestMooringPoint(agent);
		if (navigator.Terrain == Navigator.TerrainType.UnityNavMesh)
		{
			yield return MoveAgentCoroutine(mooringPoint.EmbarkTarget);
			GridNode node = GameManager.GraphManager.WaterSurfaceGraph.ReturnNode(mooringPoint.MooringTarget.Position.Vector2TopDown());
			agent.ReturnNavigator(alwaysReturnDrifter: true).AttachToNode(node);
		}
		else
		{
			mooringPoint.EmbarkTarget.AttachNavigator(agent.ReturnNavigator(alwaysReturnDrifter: true));
		}
		yield return null;
	}

	protected override void OnGUI()
	{
		Header("Navmesh Transfer", 0, Color.blue);
		EditorGUI_HelpBox("Switch from or to a navmesh.");
	}
}
