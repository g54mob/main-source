using System;
using Unity.Entities;

namespace Pathfinding.ECS
{
	[Serializable]
	public struct AgentCylinderShape : IComponentData, IQueryTypeParameter
	{
		public float radius;

		public float height;
	}
}
