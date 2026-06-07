using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Shop
{
	[Serializable]
	public struct DailyStockInfo : INetworkSerializable
	{
		public FixedString64Bytes itemId;

		public int remaining;

		public int maxDaily;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
