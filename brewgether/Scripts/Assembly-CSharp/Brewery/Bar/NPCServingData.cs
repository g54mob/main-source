using System;
using Brewery.Core;
using Unity.Netcode;

namespace Brewery.Bar
{
	[Serializable]
	public struct NPCServingData : INetworkSerializable
	{
		public ulong npcNetworkId;

		public string npcName;

		public float waitingTime;

		public float maxWaitTime;

		public int assignedDrinkSlotIndex;

		public string assignedDrinkName;

		public float calculatedPrice;

		public string factionName;

		public int drinksConsumed;

		public int drinksGoal;

		public int drinkingStatus;

		public float restTimeRemaining;

		public BrewTag refusedTags;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
