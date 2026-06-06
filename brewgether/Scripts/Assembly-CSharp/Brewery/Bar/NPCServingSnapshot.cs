using System;
using System.Collections.Generic;
using Unity.Netcode;

namespace Brewery.Bar
{
	[Serializable]
	public struct NPCServingSnapshot : INetworkSerializable
	{
		public List<NPCServingData> entries;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
