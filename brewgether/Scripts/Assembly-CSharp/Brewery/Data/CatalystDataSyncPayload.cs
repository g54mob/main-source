using System;
using Unity.Netcode;

namespace Brewery.Data
{
	[Serializable]
	public struct CatalystDataSyncPayload : INetworkSerializable
	{
		public CatalystBrewRecord newRecord;

		public CatalystPlayerStats stats;

		public bool isNewDiscovery;

		public int newDiscoveryCount;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
