using System;
using Unity.Netcode;

namespace Brewery.Thief
{
	[Serializable]
	public struct ThiefCampState : INetworkSerializable
	{
		public CampStatus status;

		public float regenerationEndTime;

		public int aliveDefenders;

		public float totalStolenValue;

		public int totalStolenItems;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
