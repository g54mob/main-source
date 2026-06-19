using Unity.Entities;
using Unity.Mathematics;

namespace Pug.Automation
{
	public struct MoveeCD : IComponentData, IQueryTypeParameter
	{
		public float2 position;

		public float2 target;

		public int moveTimer;
	}
}
