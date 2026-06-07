using System;
using Pathfinding.Util;
using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	[Serializable]
	public struct AgentMovementPlane : IComponentData, IQueryTypeParameter
	{
		public NativeMovementPlane value;

		public AgentMovementPlane(quaternion rotation)
		{
			value = default(NativeMovementPlane);
		}

		public AgentMovementPlane(NativeMovementPlane plane)
		{
			value = default(NativeMovementPlane);
		}
	}
}
