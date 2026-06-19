using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct MoveeBigEntityCD : IComponentData, IQueryTypeParameter
	{
		public float2 target;

		public int moveTimer;
	}
}
