using System.Collections.Generic;
using System.IO;
using MLAPI.Serialization.Pooled;

namespace MLAPI.Profiling
{
	public class ProfilerTick
	{
		public readonly List<TickEvent> Events = new List<TickEvent>();

		public TickType Type;

		public int Frame;

		public int EventId;

		public uint Bytes
		{
			get
			{
				uint num = 0u;
				for (int i = 0; i < Events.Count; i++)
				{
					num += Events[i].Bytes;
				}
				return num;
			}
		}

		public void SerializeToStream(Stream stream)
		{
			using PooledBitWriter pooledBitWriter = PooledBitWriter.Get(stream);
			pooledBitWriter.WriteUInt16Packed((ushort)Events.Count);
			for (int i = 0; i < Events.Count; i++)
			{
				Events[i].SerializeToStream(stream);
			}
		}

		public static ProfilerTick FromStream(Stream stream)
		{
			ProfilerTick profilerTick = new ProfilerTick();
			using PooledBitReader pooledBitReader = PooledBitReader.Get(stream);
			ushort num = pooledBitReader.ReadUInt16Packed();
			for (int i = 0; i < num; i++)
			{
				profilerTick.Events.Add(TickEvent.FromStream(stream));
			}
			return profilerTick;
		}

		internal void EndEvent()
		{
			for (int num = Events.Count - 1; num >= 0; num--)
			{
				if (!Events[num].Closed)
				{
					Events[num].Closed = true;
					break;
				}
			}
		}

		internal void StartEvent(TickType type, uint bytes, string channelName, string messageType)
		{
			TickEvent item = new TickEvent
			{
				Bytes = bytes,
				ChannelName = (string.IsNullOrEmpty(channelName) ? "NONE" : channelName),
				MessageType = (string.IsNullOrEmpty(messageType) ? "NONE" : messageType),
				EventType = type,
				Closed = false
			};
			Events.Add(item);
		}
	}
}
