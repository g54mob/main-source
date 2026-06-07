using System;
using Unity.Netcode;

namespace Brewery.Bar.PhysicalServing
{
	[Serializable]
	public struct NPCDrinkAssignment : INetworkSerializable
	{
		public ulong npcNetworkId;

		public string drinkItemId;

		public string drinkDisplayName;

		public float drinkPrice;

		public bool hasMetadata;

		public int metadataTags;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
