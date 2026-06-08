using System.IO;
using MLAPI.Serialization.Pooled;

namespace MLAPI.Profiling
{
	public class TickEvent
	{
		public TickType EventType;

		public uint Bytes;

		public string ChannelName;

		public string MessageType;

		public bool Closed;

		public void SerializeToStream(Stream stream)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteByte((byte)EventType);
			pooledBitWriter.WriteUInt32Packed(Bytes);
			pooledBitWriter.WriteStringPacked(ChannelName);
			pooledBitWriter.WriteStringPacked(MessageType);
			pooledBitWriter.WriteBool(Closed);
		}

		public static TickEvent FromStream(Stream stream)
		{
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			return new TickEvent
			{
				EventType = (TickType)pooledBitReader.ReadByte(),
				Bytes = pooledBitReader.ReadUInt32Packed(),
				ChannelName = pooledBitReader.ReadStringPacked().ToString(),
				MessageType = pooledBitReader.ReadStringPacked().ToString(),
				Closed = pooledBitReader.ReadBool()
			};
		}
	}
}
