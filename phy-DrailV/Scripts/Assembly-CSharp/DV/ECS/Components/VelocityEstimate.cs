using Unity.Entities;
using Unity.Mathematics;

namespace DV.ECS.Components
{
	public struct VelocityEstimate : IComponentData
	{
		public float3 globalVelocity;

		public float3 localVelocity;

		public float3 globalAngularVelocity;

		public float3 localAngularVelocity;
	}
}
