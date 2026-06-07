using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Shop
{
	[Serializable]
	public struct ShopSellRequest : INetworkSerializable
	{
		public FixedString64Bytes itemId;

		public int quantity;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
