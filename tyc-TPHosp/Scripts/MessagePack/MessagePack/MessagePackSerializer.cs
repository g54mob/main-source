using System;
using System.Globalization;
using System.IO;
using System.Text;
using MessagePack.Formatters;
using MessagePack.Internal;
using MessagePack.Resolvers;

namespace MessagePack
{
	public static class MessagePackSerializer
	{
		private static IFormatterResolver defaultResolver;

		public static IFormatterResolver DefaultResolver
		{
			get
			{
				if (defaultResolver == null)
				{
					defaultResolver = StandardResolver.Instance;
				}
				return defaultResolver;
			}
		}

		public static bool IsInitialized => defaultResolver != null;

		public static string ToJson<T>(T obj)
		{
			return ToJson(Serialize(obj));
		}

		public static string ToJson<T>(T obj, IFormatterResolver resolver)
		{
			return ToJson(Serialize(obj, resolver));
		}

		public static string ToJson(byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			ToJsonCore(bytes, 0, stringBuilder);
			return stringBuilder.ToString();
		}

		public static byte[] FromJson(string str)
		{
			using StringReader reader = new StringReader(str);
			return FromJson(reader);
		}

		public static byte[] FromJson(TextReader reader)
		{
			int offset = 0;
			byte[] array = null;
			using (TinyJsonReader jr = new TinyJsonReader(reader, disposeInnerReader: false))
			{
				FromJsonCore(jr, ref array, ref offset);
			}
			MessagePackBinary.FastResize(ref array, offset);
			return array;
		}

		internal static ArraySegment<byte> FromJsonUnsafe(TextReader reader)
		{
			int offset = 0;
			byte[] binary = InternalMemoryPool.GetBuffer();
			using (TinyJsonReader jr = new TinyJsonReader(reader, disposeInnerReader: false))
			{
				FromJsonCore(jr, ref binary, ref offset);
			}
			return new ArraySegment<byte>(binary, 0, offset);
		}

		private static uint FromJsonCore(TinyJsonReader jr, ref byte[] binary, ref int offset)
		{
			uint num = 0u;
			while (jr.Read())
			{
				switch (jr.TokenType)
				{
				case TinyJsonToken.StartObject:
				{
					int offset2 = offset;
					offset += 5;
					uint num2 = FromJsonCore(jr, ref binary, ref offset);
					num2 /= 2;
					MessagePackBinary.WriteMapHeaderForceMap32Block(ref binary, offset2, num2);
					num++;
					break;
				}
				case TinyJsonToken.EndObject:
					return num;
				case TinyJsonToken.StartArray:
				{
					int offset3 = offset;
					offset += 5;
					uint count = FromJsonCore(jr, ref binary, ref offset);
					MessagePackBinary.WriteArrayHeaderForceArray32Block(ref binary, offset3, count);
					num++;
					break;
				}
				case TinyJsonToken.EndArray:
					return num;
				case TinyJsonToken.Number:
					switch (jr.ValueType)
					{
					case ValueType.Double:
						offset += MessagePackBinary.WriteDouble(ref binary, offset, jr.DoubleValue);
						break;
					case ValueType.Long:
						offset += MessagePackBinary.WriteInt64(ref binary, offset, jr.LongValue);
						break;
					case ValueType.ULong:
						offset += MessagePackBinary.WriteUInt64(ref binary, offset, jr.ULongValue);
						break;
					case ValueType.Decimal:
						offset += DecimalFormatter.Instance.Serialize(ref binary, offset, jr.DecimalValue, null);
						break;
					}
					num++;
					break;
				case TinyJsonToken.String:
					offset += MessagePackBinary.WriteString(ref binary, offset, jr.StringValue);
					num++;
					break;
				case TinyJsonToken.True:
					offset += MessagePackBinary.WriteBoolean(ref binary, offset, value: true);
					num++;
					break;
				case TinyJsonToken.False:
					offset += MessagePackBinary.WriteBoolean(ref binary, offset, value: false);
					num++;
					break;
				case TinyJsonToken.Null:
					offset += MessagePackBinary.WriteNil(ref binary, offset);
					num++;
					break;
				}
			}
			return num;
		}

		private static int ToJsonCore(byte[] bytes, int offset, StringBuilder builder)
		{
			int readSize = 0;
			switch (MessagePackBinary.GetMessagePackType(bytes, offset))
			{
			case MessagePackType.Integer:
			{
				byte b = bytes[offset];
				if (224 <= b && b <= byte.MaxValue)
				{
					builder.Append(MessagePackBinary.ReadSByte(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				}
				if (0 <= b && b <= 127)
				{
					builder.Append(MessagePackBinary.ReadByte(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				}
				switch (b)
				{
				case 208:
					builder.Append(MessagePackBinary.ReadSByte(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				case 209:
					builder.Append(MessagePackBinary.ReadInt16(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				case 210:
					builder.Append(MessagePackBinary.ReadInt32(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				case 211:
					builder.Append(MessagePackBinary.ReadInt64(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				case 204:
					builder.Append(MessagePackBinary.ReadByte(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				case 205:
					builder.Append(MessagePackBinary.ReadUInt16(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				case 206:
					builder.Append(MessagePackBinary.ReadUInt32(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				case 207:
					builder.Append(MessagePackBinary.ReadUInt64(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
					break;
				}
				break;
			}
			case MessagePackType.Boolean:
				builder.Append(MessagePackBinary.ReadBoolean(bytes, offset, out readSize) ? "true" : "false");
				break;
			case MessagePackType.Float:
				if (bytes[offset] == 202)
				{
					builder.Append(MessagePackBinary.ReadSingle(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
				}
				else
				{
					builder.Append(MessagePackBinary.ReadDouble(bytes, offset, out readSize).ToString(CultureInfo.InvariantCulture));
				}
				break;
			case MessagePackType.String:
				WriteJsonString(MessagePackBinary.ReadString(bytes, offset, out readSize), builder);
				break;
			case MessagePackType.Binary:
				builder.Append("\"" + Convert.ToBase64String(MessagePackBinary.ReadBytes(bytes, offset, out readSize)) + "\"");
				break;
			case MessagePackType.Array:
			{
				uint num3 = MessagePackBinary.ReadArrayHeaderRaw(bytes, offset, out readSize);
				int num4 = readSize;
				offset += readSize;
				builder.Append("[");
				for (int j = 0; j < num3; j++)
				{
					readSize = ToJsonCore(bytes, offset, builder);
					offset += readSize;
					num4 += readSize;
					if (j != num3 - 1)
					{
						builder.Append(",");
					}
				}
				builder.Append("]");
				return num4;
			}
			case MessagePackType.Map:
			{
				uint num = MessagePackBinary.ReadMapHeaderRaw(bytes, offset, out readSize);
				int num2 = readSize;
				offset += readSize;
				builder.Append("{");
				for (int i = 0; i < num; i++)
				{
					MessagePackType messagePackType = MessagePackBinary.GetMessagePackType(bytes, offset);
					if (messagePackType == MessagePackType.String || messagePackType == MessagePackType.Binary)
					{
						readSize = ToJsonCore(bytes, offset, builder);
					}
					else
					{
						builder.Append("\"");
						readSize = ToJsonCore(bytes, offset, builder);
						builder.Append("\"");
					}
					offset += readSize;
					num2 += readSize;
					builder.Append(":");
					readSize = ToJsonCore(bytes, offset, builder);
					offset += readSize;
					num2 += readSize;
					if (i != num - 1)
					{
						builder.Append(",");
					}
				}
				builder.Append("}");
				return num2;
			}
			case MessagePackType.Extension:
			{
				if (MessagePackBinary.ReadExtensionFormatHeader(bytes, offset, out readSize).TypeCode == -1)
				{
					DateTime dateTime = MessagePackBinary.ReadDateTime(bytes, offset, out readSize);
					builder.Append("\"");
					builder.Append(dateTime.ToString("o", CultureInfo.InvariantCulture));
					builder.Append("\"");
					break;
				}
				ExtensionResult extensionResult = MessagePackBinary.ReadExtensionFormat(bytes, offset, out readSize);
				builder.Append("[");
				builder.Append(extensionResult.TypeCode);
				builder.Append(",");
				builder.Append("\"");
				builder.Append(Convert.ToBase64String(extensionResult.Data));
				builder.Append("\"");
				builder.Append("]");
				break;
			}
			default:
				readSize = 1;
				builder.Append("null");
				break;
			}
			return readSize;
		}

		private static void WriteJsonString(string value, StringBuilder builder)
		{
			builder.Append('"');
			int length = value.Length;
			for (int i = 0; i < length; i++)
			{
				char c = value[i];
				switch (c)
				{
				case '"':
					builder.Append("\\\"");
					break;
				case '\\':
					builder.Append("\\\\");
					break;
				case '\b':
					builder.Append("\\b");
					break;
				case '\f':
					builder.Append("\\f");
					break;
				case '\n':
					builder.Append("\\n");
					break;
				case '\r':
					builder.Append("\\r");
					break;
				case '\t':
					builder.Append("\\t");
					break;
				default:
					builder.Append(c);
					break;
				}
			}
			builder.Append('"');
		}

		public static void SetDefaultResolver(IFormatterResolver resolver)
		{
			defaultResolver = resolver;
		}

		public static byte[] Serialize<T>(T obj)
		{
			return Serialize(obj, defaultResolver);
		}

		public static byte[] Serialize<T>(T obj, IFormatterResolver resolver)
		{
			if (resolver == null)
			{
				resolver = DefaultResolver;
			}
			IMessagePackFormatter<T> formatterWithVerify = resolver.GetFormatterWithVerify<T>();
			byte[] bytes = InternalMemoryPool.GetBuffer();
			int newSize = formatterWithVerify.Serialize(ref bytes, 0, obj, resolver);
			return MessagePackBinary.FastCloneWithResize(bytes, newSize);
		}

		public static ArraySegment<byte> SerializeUnsafe<T>(T obj)
		{
			return SerializeUnsafe(obj, defaultResolver);
		}

		public static ArraySegment<byte> SerializeUnsafe<T>(T obj, IFormatterResolver resolver)
		{
			if (resolver == null)
			{
				resolver = DefaultResolver;
			}
			IMessagePackFormatter<T> formatterWithVerify = resolver.GetFormatterWithVerify<T>();
			byte[] bytes = InternalMemoryPool.GetBuffer();
			int count = formatterWithVerify.Serialize(ref bytes, 0, obj, resolver);
			return new ArraySegment<byte>(bytes, 0, count);
		}

		public static void Serialize<T>(Stream stream, T obj)
		{
			Serialize(stream, obj, defaultResolver);
		}

		public static void Serialize<T>(Stream stream, T obj, IFormatterResolver resolver)
		{
			if (resolver == null)
			{
				resolver = DefaultResolver;
			}
			IMessagePackFormatter<T> formatterWithVerify = resolver.GetFormatterWithVerify<T>();
			byte[] bytes = InternalMemoryPool.GetBuffer();
			int count = formatterWithVerify.Serialize(ref bytes, 0, obj, resolver);
			stream.Write(bytes, 0, count);
		}

		public static T Deserialize<T>(byte[] bytes)
		{
			return Deserialize<T>(bytes, defaultResolver);
		}

		public static T Deserialize<T>(byte[] bytes, IFormatterResolver resolver)
		{
			if (resolver == null)
			{
				resolver = DefaultResolver;
			}
			int readSize;
			return resolver.GetFormatterWithVerify<T>().Deserialize(bytes, 0, resolver, out readSize);
		}

		public static T Deserialize<T>(ArraySegment<byte> bytes)
		{
			return Deserialize<T>(bytes, defaultResolver);
		}

		public static T Deserialize<T>(ArraySegment<byte> bytes, IFormatterResolver resolver)
		{
			if (resolver == null)
			{
				resolver = DefaultResolver;
			}
			int readSize;
			return resolver.GetFormatterWithVerify<T>().Deserialize(bytes.Array, bytes.Offset, resolver, out readSize);
		}

		public static T Deserialize<T>(Stream stream)
		{
			return Deserialize<T>(stream, defaultResolver);
		}

		public static T Deserialize<T>(Stream stream, IFormatterResolver resolver)
		{
			return Deserialize<T>(stream, resolver, readStrict: false);
		}

		public static T Deserialize<T>(Stream stream, bool readStrict)
		{
			return Deserialize<T>(stream, defaultResolver, readStrict);
		}

		public static T Deserialize<T>(Stream stream, IFormatterResolver resolver, bool readStrict)
		{
			if (resolver == null)
			{
				resolver = DefaultResolver;
			}
			IMessagePackFormatter<T> formatterWithVerify = resolver.GetFormatterWithVerify<T>();
			if (!readStrict)
			{
				byte[] buffer = InternalMemoryPool.GetBuffer();
				FillFromStream(stream, ref buffer);
				int readSize;
				return formatterWithVerify.Deserialize(buffer, 0, resolver, out readSize);
			}
			int readSize2;
			byte[] bytes = MessagePackBinary.ReadMessageBlockFromStreamUnsafe(stream, readOnlySingleMessage: false, out readSize2);
			int readSize3;
			return formatterWithVerify.Deserialize(bytes, 0, resolver, out readSize3);
		}

		private static int FillFromStream(Stream input, ref byte[] buffer)
		{
			int num = 0;
			int num2;
			while ((num2 = input.Read(buffer, num, buffer.Length - num)) > 0)
			{
				num += num2;
				if (num == buffer.Length)
				{
					MessagePackBinary.FastResize(ref buffer, num * 2);
				}
			}
			return num;
		}
	}
}
