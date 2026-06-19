using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class RoomTemplatesSaveHeaderFormatter : IMessagePackFormatter<RoomTemplatesSaveHeader>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public RoomTemplatesSaveHeaderFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "Date", 0 },
				{ "Version", 1 }
			};
			____stringByteKeys = new byte[2][]
			{
				MessagePackBinary.GetEncodedStringBytes("Date"),
				MessagePackBinary.GetEncodedStringBytes("Version")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, RoomTemplatesSaveHeader value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 2);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += formatterResolver.GetFormatterWithVerify<DateTime>().Serialize(ref bytes, offset, value.Date, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<VersionNumber>().Serialize(ref bytes, offset, value.Version, formatterResolver);
			return offset - num;
		}

		public RoomTemplatesSaveHeader Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			DateTime date = default(DateTime);
			VersionNumber version = null;
			for (int i = 0; i < num2; i++)
			{
				ArraySegment<byte> key = MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
				offset += readSize;
				if (!____keyMapping.TryGetValueSafe(key, out var value))
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				else
				{
					switch (value)
					{
					case 0:
						date = formatterResolver.GetFormatterWithVerify<DateTime>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 1:
						version = formatterResolver.GetFormatterWithVerify<VersionNumber>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new RoomTemplatesSaveHeader
			{
				Date = date,
				Version = version
			};
		}
	}
}
