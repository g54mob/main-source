using System;
using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	[Serializable]
	public struct AutoRepathPolicy : IComponentData, IQueryTypeParameter
	{
		public const float Sensitivity = 10f;

		public Pathfinding.AutoRepathPolicy.Mode mode;

		private byte pathFailures;

		public float period;

		private float3 lastDestination;

		private float lastRepathTime;

		public static AutoRepathPolicy Default => default(AutoRepathPolicy);

		public AutoRepathPolicy(Pathfinding.AutoRepathPolicy policy)
		{
			mode = default(Pathfinding.AutoRepathPolicy.Mode);
			pathFailures = 0;
			period = 0f;
			lastDestination = default(float3);
			lastRepathTime = 0f;
		}

		public bool ShouldRecalculatePath(float3 position, float radius, float3 destination, float time, bool isPathStale)
		{
			return false;
		}

		public void OnPathCalculated(bool hadError)
		{
		}

		public void Reset()
		{
		}

		public void OnScheduledPathRecalculation(float3 destination, float time)
		{
		}
	}
}
