using FishNet.Object.Helping;

namespace FishNet.Object
{
	internal struct RpcLinkType
	{
		public ushort LinkIndex;

		public RpcType RpcType;

		public RpcLinkType(ushort linkIndex, RpcType rpcType)
		{
			LinkIndex = 0;
			RpcType = default(RpcType);
		}
	}
}
