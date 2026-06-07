using UnityEngine;
using UnityEngine.AI;

public static class PathfindingHelper
{
	public static float ReturnUnityNavMeshPathDistance(Target from, Target to)
	{
		NavMeshPath navMeshPath = new NavMeshPath();
		if (!UnityEngine.AI.NavMesh.CalculatePath(from.Position, to.Position, -1, navMeshPath) && UnityEngine.AI.NavMesh.SamplePosition(to.Position, out var hit, 3f, -1))
		{
			UnityEngine.AI.NavMesh.CalculatePath(from.Position, hit.position, -1, navMeshPath);
		}
		Vector3[] corners = navMeshPath.corners;
		float num = 0f;
		for (int i = 1; i < corners.Length; i++)
		{
			num += Vector3.Distance(corners[i], corners[i - 1]);
		}
		return num;
	}
}
