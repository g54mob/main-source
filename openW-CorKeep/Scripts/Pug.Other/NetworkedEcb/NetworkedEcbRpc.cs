using Pug.UnityExtensions;
using Unity.Entities;
using Unity.NetCode;

namespace NetworkedEcb
{
	public struct NetworkedEcbRpc : IRpcCommand, IComponentData, IQueryTypeParameter
	{
		public NetworkedEcbCommand command;

		public Entity entity;

		public ulong componentTypeHash;

		public FixedArray64 data;

		public int dataLength;
	}
}
