using Unity.Entities;
using Unity.Mathematics;

namespace PugFlora
{
	public struct PugFloraBlockingCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;
	}
}
