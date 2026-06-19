using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class VersionNumberFormatter : IMessagePackFormatter<VersionNumber>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public VersionNumberFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "Major", 0 },
				{ "Minor", 1 },
				{ "Patch", 2 },
				{ "PreReleaseVersion", 3 },
				{ "BuildMetadata", 4 }
			};
			____stringByteKeys = new byte[5][]
			{
				MessagePackBinary.GetEncodedStringBytes("Major"),
				MessagePackBinary.GetEncodedStringBytes("Minor"),
				MessagePackBinary.GetEncodedStringBytes("Patch"),
				MessagePackBinary.GetEncodedStringBytes("PreReleaseVersion"),
				MessagePackBinary.GetEncodedStringBytes("BuildMetadata")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, VersionNumber value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 5);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Major);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Minor);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Patch);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.PreReleaseVersion, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.BuildMetadata, formatterResolver);
			return offset - num;
		}

		public VersionNumber Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			int major = 0;
			int minor = 0;
			int patch = 0;
			string preReleaseVersion = null;
			string buildMetadata = null;
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
						major = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 1:
						minor = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 2:
						patch = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 3:
						preReleaseVersion = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 4:
						buildMetadata = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new VersionNumber
			{
				Major = major,
				Minor = minor,
				Patch = patch,
				PreReleaseVersion = preReleaseVersion,
				BuildMetadata = buildMetadata
			};
		}
	}
}
