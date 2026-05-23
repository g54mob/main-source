using Unity.Burst;
using Unity.Mathematics;

namespace Presentation.FactoryFloor.Culling.Jobs
{
	[BurstCompile]
	public struct CullableJobItem
	{
		public bool IsValid;

		public CullableSettings Settings;

		public float3 WorldPosition;

		public int IslandID;

		public float3 Bounds;
	}
}
