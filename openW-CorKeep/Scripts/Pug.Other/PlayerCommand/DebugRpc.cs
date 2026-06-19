using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerCommand
{
	public struct DebugRpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public DebugCommand command;

		public Entity entity0;

		public Entity entity1;

		public int int0;

		public int int1;

		public float3 position0;

		public float3 position1;

		public bool bool0;
	}
}
