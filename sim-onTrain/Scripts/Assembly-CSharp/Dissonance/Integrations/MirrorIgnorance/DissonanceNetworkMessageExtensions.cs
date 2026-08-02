using System;
using Dissonance.Datastructures;
using Mirror;

namespace Dissonance.Integrations.MirrorIgnorance
{
	internal static class DissonanceNetworkMessageExtensions
	{
		internal const int BufferLength = 1024;

		internal static readonly ConcurrentPool<byte[]> SerializationBuffers = new ConcurrentPool<byte[]>(8, () => new byte[1024]);

		public static void Serialize([Dissonance.NotNull] this NetworkWriter writer, DissonanceNetworkMessage value)
		{
			writer.WriteUShort((ushort)value.Data.Count);
			writer.WriteBytes(value.Data.Array, value.Data.Offset, value.Data.Count);
			SerializationBuffers.Put(value.Data.Array);
		}

		public static DissonanceNetworkMessage Deserialize([Dissonance.NotNull] this NetworkReader reader)
		{
			byte[] array = SerializationBuffers.Get();
			ushort num = reader.ReadUShort();
			for (int i = 0; i < num; i++)
			{
				array[i] = reader.ReadByte();
			}
			return new DissonanceNetworkMessage(new ArraySegment<byte>(array, 0, num));
		}
	}
}
