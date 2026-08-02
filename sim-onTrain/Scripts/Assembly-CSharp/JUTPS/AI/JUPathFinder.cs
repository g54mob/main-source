using UnityEngine;
using UnityEngine.AI;

namespace JUTPS.AI
{
	public class JUPathFinder
	{
		public static Vector3[] CalculatePath(Vector3 SourcePosition, Vector3 TargetPosition, int NavmeshArea = 1)
		{
			NavMesh.SamplePosition(SourcePosition, out var hit, 100f, NavmeshArea);
			if (!hit.hit)
			{
				Debug.LogWarning("Unable to calculate path, make sure the Navmesh in your scene is baked");
				return new Vector3[0];
			}
			NavMeshPath navMeshPath = new NavMeshPath();
			if (NavMesh.FindClosestEdge(TargetPosition, out var hit2, NavmeshArea))
			{
				NavMesh.CalculatePath(SourcePosition, hit2.position, NavmeshArea, navMeshPath);
			}
			if (navMeshPath.status == NavMeshPathStatus.PathPartial || navMeshPath.status == NavMeshPathStatus.PathInvalid)
			{
				NavMesh.SamplePosition(SourcePosition, out var hit3, 10f, NavmeshArea);
				NavMesh.SamplePosition(TargetPosition, out var hit4, 10f, NavmeshArea);
				if (!hit3.hit || !hit4.hit)
				{
					Debug.LogWarning("Could not calculate NavMesh path, invalid target/source position");
					return new Vector3[0];
				}
				NavMesh.CalculatePath(hit3.position, hit4.position, NavmeshArea, navMeshPath);
			}
			return navMeshPath.corners;
		}

		public static Vector3[] CalculatePath(Transform SourcePosition, Transform TargetPosition)
		{
			NavMeshPath navMeshPath = new NavMeshPath();
			NavMesh.CalculatePath(SourcePosition.position, TargetPosition.position, -1, navMeshPath);
			if (navMeshPath.status == NavMeshPathStatus.PathInvalid)
			{
				NavMesh.FindClosestEdge(SourcePosition.position, out var hit, -1);
				NavMesh.CalculatePath(hit.position, TargetPosition.position, -1, navMeshPath);
			}
			return navMeshPath.corners;
		}

		public static void VisualizePath(Vector3[] path)
		{
			Color white = Color.white;
			white.a = 0.2f;
			for (int i = 0; i < path.Length - 1; i++)
			{
				Debug.DrawLine(path[i], path[i] + Vector3.up * 0.1f, Color.red);
				Debug.DrawLine(path[i], path[i + 1], white);
			}
		}

		public static Vector3 GetClosestWalkablePoint(Vector3 targetPosition, float offsetDirection = 0.2f)
		{
			_ = Vector3.zero;
			NavMesh.SamplePosition(targetPosition, out var hit, 2f, -1);
			Vector3 normalized = (targetPosition - hit.position).normalized;
			return hit.position - normalized * offsetDirection;
		}
	}
}
