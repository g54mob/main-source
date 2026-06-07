using Unity.Entities;
using Unity.Mathematics;

namespace DV.ECS.Components
{
	public struct PreviousFrameLocalToWorld : IComponentData
	{
		public float4x4 value;
	}
}
