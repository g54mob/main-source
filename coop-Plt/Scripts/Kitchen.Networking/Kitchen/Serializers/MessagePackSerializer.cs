using Kitchen.Serialisation;

namespace Kitchen.Serializers
{
	public class MessagePackSerializer<T> : INetworkSerializer<T>
	{
		public byte[] Serialize(T data)
		{
			return MessagePackUtility.Serialize(data, force_compression: true);
		}

		public T Deserialize(byte[] data)
		{
			return MessagePackUtility.Deserialize<T>(data, force_compression: true);
		}
	}
}
