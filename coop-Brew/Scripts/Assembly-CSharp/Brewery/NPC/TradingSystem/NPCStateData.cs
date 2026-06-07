using System;
using Unity.Netcode;

namespace Brewery.NPC.TradingSystem
{
	[Serializable]
	public struct NPCStateData : INetworkSerializable
	{
		public string npcId;

		public TradeInstanceData[] trades;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
