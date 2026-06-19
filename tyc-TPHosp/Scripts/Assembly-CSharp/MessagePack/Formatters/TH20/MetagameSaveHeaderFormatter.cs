using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class MetagameSaveHeaderFormatter : IMessagePackFormatter<MetagameSaveHeader>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public MetagameSaveHeaderFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "Date", 0 },
				{ "Version", 1 },
				{ "OrganisationName", 2 },
				{ "TotalStars", 3 },
				{ "TotalSilver", 4 },
				{ "TotalFoundationValue", 5 },
				{ "ThumbnailPNG", 6 },
				{ "IsSandboxUnlocked", 7 }
			};
			____stringByteKeys = new byte[8][]
			{
				MessagePackBinary.GetEncodedStringBytes("Date"),
				MessagePackBinary.GetEncodedStringBytes("Version"),
				MessagePackBinary.GetEncodedStringBytes("OrganisationName"),
				MessagePackBinary.GetEncodedStringBytes("TotalStars"),
				MessagePackBinary.GetEncodedStringBytes("TotalSilver"),
				MessagePackBinary.GetEncodedStringBytes("TotalFoundationValue"),
				MessagePackBinary.GetEncodedStringBytes("ThumbnailPNG"),
				MessagePackBinary.GetEncodedStringBytes("IsSandboxUnlocked")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, MetagameSaveHeader value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 8);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += formatterResolver.GetFormatterWithVerify<DateTime>().Serialize(ref bytes, offset, value.Date, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<VersionNumber>().Serialize(ref bytes, offset, value.Version, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.OrganisationName, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TotalStars);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TotalSilver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.TotalFoundationValue);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += formatterResolver.GetFormatterWithVerify<byte[]>().Serialize(ref bytes, offset, value.ThumbnailPNG, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[7]);
			offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsSandboxUnlocked);
			return offset - num;
		}

		public MetagameSaveHeader Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
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
			string organisationName = null;
			int totalStars = 0;
			int totalSilver = 0;
			int totalFoundationValue = 0;
			byte[] thumbnailPNG = null;
			bool isSandboxUnlocked = false;
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
					case 2:
						organisationName = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 3:
						totalStars = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 4:
						totalSilver = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 5:
						totalFoundationValue = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 6:
						thumbnailPNG = formatterResolver.GetFormatterWithVerify<byte[]>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 7:
						isSandboxUnlocked = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new MetagameSaveHeader
			{
				Date = date,
				Version = version,
				OrganisationName = organisationName,
				TotalStars = totalStars,
				TotalSilver = totalSilver,
				TotalFoundationValue = totalFoundationValue,
				ThumbnailPNG = thumbnailPNG,
				IsSandboxUnlocked = isSandboxUnlocked
			};
		}
	}
}
