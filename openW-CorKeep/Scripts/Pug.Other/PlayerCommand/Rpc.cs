using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

namespace PlayerCommand
{
	public struct Rpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public Command command;

		public Entity entity0;

		public int int0;

		public int int1;

		public int int2;

		public int int3;

		public float3 position0;

		public float3 position1;

		public bool bool0;

		public float float0;
	}
}
