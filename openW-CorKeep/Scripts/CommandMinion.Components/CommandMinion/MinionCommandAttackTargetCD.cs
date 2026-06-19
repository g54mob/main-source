using Unity.Entities;
using Unity.Mathematics;

namespace CommandMinion
{
	public struct MinionCommandAttackTargetCD : IComponentData, IQueryTypeParameter
	{
		public Entity target;

		public float2 position;

		public bool isValidTarget;
	}
}
