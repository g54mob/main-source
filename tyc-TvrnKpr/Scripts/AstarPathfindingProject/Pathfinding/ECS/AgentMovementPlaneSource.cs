using System;
using Unity.Entities;

namespace Pathfinding.ECS
{
	[Serializable]
	public struct AgentMovementPlaneSource : ISharedComponentData, IQueryTypeParameter
	{
		public MovementPlaneSource value;
	}
}
