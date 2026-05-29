using UnityEngine;
using UnityEngine.AI;

internal static class NavMeshAgentExtensions
{
	public static bool EnsureOnNavMesh(this NavMeshAgent agent, Transform fallback, float sampleRadius = 2f)
	{
		return false;
	}

	public static void SetDestinationSafe(this NavMeshAgent agent, Transform fallback, Vector3 target, float sampleRadius = 1f)
	{
	}
}
