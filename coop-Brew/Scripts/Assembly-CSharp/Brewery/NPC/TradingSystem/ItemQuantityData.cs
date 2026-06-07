using System;
using Unity.Netcode;

namespace Brewery.NPC.TradingSystem
{
	[Serializable]
	public struct ItemQuantityData : INetworkSerializable
	{
		public string itemId;

		public int quantity;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
