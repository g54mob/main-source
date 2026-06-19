using Unity.Collections;
using Unity.Entities;
using Unity.NetCode;

namespace PlayerCommand
{
	public struct TextRpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public Command command;

		public Entity entity;

		public FixedString64Bytes text;

		public int rpcId;
	}
}
