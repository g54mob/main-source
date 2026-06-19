using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MessagePack.Formatters
{
	public sealed class PrimitiveObjectFormatter : IMessagePackFormatter<object>, IMessagePackFormatter
	{
		public static readonly IMessagePackFormatter<object> Instance = new PrimitiveObjectFormatter();

		private static readonly Dictionary<Type, int> typeToJumpCode = new Dictionary<Type, int>
		{
			{
				typeof(bool),
				0
			},
			{
				typeof(char),
				1
			},
			{
				typeof(sbyte),
				2
			},
			{
				typeof(byte),
				3
			},
			{
				typeof(short),
				4
			},
			{
				typeof(ushort),
				5
			},
			{
				typeof(int),
				6
			},
			{
				typeof(uint),
				7
			},
			{
				typeof(long),
				8
			},
			{
				typeof(ulong),
				9
			},
			{
				typeof(float),
				10
			},
			{
				typeof(double),
				11
			},
			{
				typeof(DateTime),
				12
			},
			{
				typeof(string),
				13
			},
			{
				typeof(byte[]),
				14
			}
		};

		private PrimitiveObjectFormatter()
		{
		}

		public static bool IsSupportedType(Type type, TypeInfo typeInfo, object value)
		{
			if (value == null)
			{
				return true;
			}
			if (typeToJumpCode.ContainsKey(type))
			{
				return true;
			}
			if (typeInfo.IsEnum)
			{
				return true;
			}
			if (value is IDictionary)
			{
				return true;
			}
			if (value is ICollection)
			{
				return true;
			}
			return false;
		}

		public int Serialize(ref byte[] bytes, int offset, object value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			Type type = value.GetType();
			if (typeToJumpCode.TryGetValue(type, out var value2))
			{
				return value2 switch
				{
					0 => MessagePackBinary.WriteBoolean(ref bytes, offset, (bool)value), 
					1 => MessagePackBinary.WriteChar(ref bytes, offset, (char)value), 
					2 => MessagePackBinary.WriteSByteForceSByteBlock(ref bytes, offset, (sbyte)value), 
					3 => MessagePackBinary.WriteByteForceByteBlock(ref bytes, offset, (byte)value), 
					4 => MessagePackBinary.WriteInt16ForceInt16Block(ref bytes, offset, (short)value), 
					5 => MessagePackBinary.WriteUInt16ForceUInt16Block(ref bytes, offset, (ushort)value), 
					6 => MessagePackBinary.WriteInt32ForceInt32Block(ref bytes, offset, (int)value), 
					7 => MessagePackBinary.WriteUInt32ForceUInt32Block(ref bytes, offset, (uint)value), 
					8 => MessagePackBinary.WriteInt64ForceInt64Block(ref bytes, offset, (long)value), 
					9 => MessagePackBinary.WriteUInt64ForceUInt64Block(ref bytes, offset, (ulong)value), 
					10 => MessagePackBinary.WriteSingle(ref bytes, offset, (float)value), 
					11 => MessagePackBinary.WriteDouble(ref bytes, offset, (double)value), 
					12 => MessagePackBinary.WriteDateTime(ref bytes, offset, (DateTime)value), 
					13 => MessagePackBinary.WriteString(ref bytes, offset, (string)value), 
					14 => MessagePackBinary.WriteBytes(ref bytes, offset, (byte[])value), 
					_ => throw new InvalidOperationException("Not supported primitive object resolver. type:" + type.Name), 
				};
			}
			if (type.GetTypeInfo().IsEnum)
			{
				Type underlyingType = Enum.GetUnderlyingType(type);
				switch (typeToJumpCode[underlyingType])
				{
				case 2:
					return MessagePackBinary.WriteSByteForceSByteBlock(ref bytes, offset, (sbyte)value);
				case 3:
					return MessagePackBinary.WriteByteForceByteBlock(ref bytes, offset, (byte)value);
				case 4:
					return MessagePackBinary.WriteInt16ForceInt16Block(ref bytes, offset, (short)value);
				case 5:
					return MessagePackBinary.WriteUInt16ForceUInt16Block(ref bytes, offset, (ushort)value);
				case 6:
					return MessagePackBinary.WriteInt32ForceInt32Block(ref bytes, offset, (int)value);
				case 7:
					return MessagePackBinary.WriteUInt32ForceUInt32Block(ref bytes, offset, (uint)value);
				case 8:
					return MessagePackBinary.WriteInt64ForceInt64Block(ref bytes, offset, (long)value);
				case 9:
					return MessagePackBinary.WriteUInt64ForceUInt64Block(ref bytes, offset, (ulong)value);
				}
			}
			else
			{
				if (value is IDictionary)
				{
					IDictionary dictionary = value as IDictionary;
					int num = offset;
					offset += MessagePackBinary.WriteMapHeader(ref bytes, offset, dictionary.Count);
					foreach (DictionaryEntry item in dictionary)
					{
						offset += Serialize(ref bytes, offset, item.Key, formatterResolver);
						offset += Serialize(ref bytes, offset, item.Value, formatterResolver);
					}
					return offset - num;
				}
				if (value is ICollection)
				{
					ICollection collection = value as ICollection;
					int num2 = offset;
					offset += MessagePackBinary.WriteArrayHeader(ref bytes, offset, collection.Count);
					foreach (object item2 in collection)
					{
						offset += Serialize(ref bytes, offset, item2, formatterResolver);
					}
					return offset - num2;
				}
			}
			throw new InvalidOperationException("Not supported primitive object resolver. type:" + type.Name);
		}

		public object Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			switch (MessagePackBinary.GetMessagePackType(bytes, offset))
			{
			case MessagePackType.Integer:
			{
				byte b = bytes[offset];
				if (224 <= b && b <= byte.MaxValue)
				{
					return MessagePackBinary.ReadSByte(bytes, offset, out readSize);
				}
				if (0 <= b && b <= 127)
				{
					return MessagePackBinary.ReadByte(bytes, offset, out readSize);
				}
				return b switch
				{
					208 => MessagePackBinary.ReadSByte(bytes, offset, out readSize), 
					209 => MessagePackBinary.ReadInt16(bytes, offset, out readSize), 
					210 => MessagePackBinary.ReadInt32(bytes, offset, out readSize), 
					211 => MessagePackBinary.ReadInt64(bytes, offset, out readSize), 
					204 => MessagePackBinary.ReadByte(bytes, offset, out readSize), 
					205 => MessagePackBinary.ReadUInt16(bytes, offset, out readSize), 
					206 => MessagePackBinary.ReadUInt32(bytes, offset, out readSize), 
					207 => MessagePackBinary.ReadUInt64(bytes, offset, out readSize), 
					_ => throw new InvalidOperationException("Invalid primitive bytes."), 
				};
			}
			case MessagePackType.Boolean:
				return MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
			case MessagePackType.Float:
				if (202 == bytes[offset])
				{
					return MessagePackBinary.ReadSingle(bytes, offset, out readSize);
				}
				return MessagePackBinary.ReadDouble(bytes, offset, out readSize);
			case MessagePackType.String:
				return MessagePackBinary.ReadString(bytes, offset, out readSize);
			case MessagePackType.Binary:
				return MessagePackBinary.ReadBytes(bytes, offset, out readSize);
			case MessagePackType.Extension:
				if (MessagePackBinary.ReadExtensionFormatHeader(bytes, offset, out readSize).TypeCode == -1)
				{
					return MessagePackBinary.ReadDateTime(bytes, offset, out readSize);
				}
				throw new InvalidOperationException("Invalid primitive bytes.");
			case MessagePackType.Array:
			{
				int num3 = MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
				int num4 = offset;
				offset += readSize;
				IMessagePackFormatter<object> formatter2 = formatterResolver.GetFormatter<object>();
				object[] array = new object[num3];
				for (int j = 0; j < num3; j++)
				{
					array[j] = formatter2.Deserialize(bytes, offset, formatterResolver, out readSize);
					offset += readSize;
				}
				readSize = offset - num4;
				return array;
			}
			case MessagePackType.Map:
			{
				int num = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
				int num2 = offset;
				offset += readSize;
				IMessagePackFormatter<object> formatter = formatterResolver.GetFormatter<object>();
				Dictionary<object, object> dictionary = new Dictionary<object, object>(num);
				for (int i = 0; i < num; i++)
				{
					object key = formatter.Deserialize(bytes, offset, formatterResolver, out readSize);
					offset += readSize;
					object value = formatter.Deserialize(bytes, offset, formatterResolver, out readSize);
					offset += readSize;
					dictionary.Add(key, value);
				}
				readSize = offset - num2;
				return dictionary;
			}
			case MessagePackType.Nil:
				readSize = 1;
				return null;
			default:
				throw new InvalidOperationException("Invalid primitive bytes.");
			}
		}
	}
}
