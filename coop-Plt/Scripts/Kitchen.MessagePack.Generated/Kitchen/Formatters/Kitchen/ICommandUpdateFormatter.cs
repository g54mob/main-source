using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ICommandUpdateFormatter : IMessagePackFormatter<ICommandUpdate>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public ICommandUpdateFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(3, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(UserInputUpdate).TypeHandle,
					new KeyValuePair<int, int>(-945005371, 0)
				},
				{
					typeof(ControlCommand).TypeHandle,
					new KeyValuePair<int, int>(-246690337, 1)
				},
				{
					typeof(ResponseUpdateCommand).TypeHandle,
					new KeyValuePair<int, int>(1630395257, 2)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(3)
			{
				{ -945005371, 0 },
				{ -246690337, 1 },
				{ 1630395257, 2 }
			};
		}

		public void Serialize(ref MessagePackWriter writer, ICommandUpdate value, MessagePackSerializerOptions options)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				writer.WriteArrayHeader(2);
				writer.WriteInt32(value2.Key);
				switch (value2.Value)
				{
				case 0:
					options.Resolver.GetFormatterWithVerify<UserInputUpdate>().Serialize(ref writer, (UserInputUpdate)(object)value, options);
					break;
				case 1:
					options.Resolver.GetFormatterWithVerify<ControlCommand>().Serialize(ref writer, (ControlCommand)(object)value, options);
					break;
				case 2:
					options.Resolver.GetFormatterWithVerify<ResponseUpdateCommand>().Serialize(ref writer, (ResponseUpdateCommand)(object)value, options);
					break;
				}
			}
			else
			{
				writer.WriteNil();
			}
		}

		public ICommandUpdate Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			if (reader.ReadArrayHeader() != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::Kitchen.ICommandUpdate");
			}
			options.Security.DepthStep(ref reader);
			int value = reader.ReadInt32();
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			ICommandUpdate result = null;
			switch (value)
			{
			case 0:
				result = options.Resolver.GetFormatterWithVerify<UserInputUpdate>().Deserialize(ref reader, options);
				break;
			case 1:
				result = options.Resolver.GetFormatterWithVerify<ControlCommand>().Deserialize(ref reader, options);
				break;
			case 2:
				result = options.Resolver.GetFormatterWithVerify<ResponseUpdateCommand>().Deserialize(ref reader, options);
				break;
			default:
				reader.Skip();
				break;
			}
			reader.Depth--;
			return result;
		}
	}
}
