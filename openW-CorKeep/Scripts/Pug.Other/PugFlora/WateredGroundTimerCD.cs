using Unity.Entities;
using Unity.Mathematics;

namespace PugFlora
{
	public struct WateredGroundTimerCD : IComponentData, IQueryTypeParameter
	{
		public int2 position;

		public float timer;
	}
}
