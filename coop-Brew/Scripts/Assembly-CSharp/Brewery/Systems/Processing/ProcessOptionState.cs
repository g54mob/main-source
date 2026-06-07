using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Systems.Processing
{
	public struct ProcessOptionState : INetworkSerializable
	{
		public FixedString64Bytes Key;

		public bool Enabled;

		public ProcessOptionState(FixedString64Bytes key, bool enabled = false)
		{
			Key = default(FixedString64Bytes);
			Enabled = false;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
