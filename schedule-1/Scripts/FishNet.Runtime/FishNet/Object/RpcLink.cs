using FishNet.Object.Helping;

namespace FishNet.Object
{
	internal struct RpcLink
	{
		public int ObjectId;

		public byte ComponentIndex;

		public uint RpcHash;

		public RpcType RpcType;

		public RpcLink(int objectId, byte componentIndex, uint rpcHash, RpcType rpcType)
		{
			ObjectId = 0;
			ComponentIndex = 0;
			RpcHash = 0u;
			RpcType = default(RpcType);
		}
	}
}
