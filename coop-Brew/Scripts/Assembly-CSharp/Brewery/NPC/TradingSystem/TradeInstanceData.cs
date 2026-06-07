using System;
using Unity.Netcode;

namespace Brewery.NPC.TradingSystem
{
	[Serializable]
	public struct TradeInstanceData : INetworkSerializable
	{
		public string tradeId;

		public int completionsToday;

		public float dailyMultiplier;

		public int currentMoneyRequired;

		public int currentMoneyReward;

		public ItemQuantityData[] itemQuantities;

		public string[] dailyCatalystRequirements;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
