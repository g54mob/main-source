using System;
using Unity.Netcode;

namespace Player.Customization.Sidekick
{
	[Serializable]
	public struct SidekickNetworkData : INetworkSerializable
	{
		public int version;

		public bool IsEmpty => false;

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}

		public static SidekickNetworkData Default()
		{
			return default(SidekickNetworkData);
		}

		public static string CompactJson(SidekickSaveData data)
		{
			return null;
		}
	}
}
