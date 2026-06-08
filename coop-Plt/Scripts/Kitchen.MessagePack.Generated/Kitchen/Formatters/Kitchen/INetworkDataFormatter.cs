using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class INetworkDataFormatter : IMessagePackFormatter<INetworkData>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public INetworkDataFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(2, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(CommandUpdate).TypeHandle,
					new KeyValuePair<int, int>(-1938433307, 0)
				},
				{
					typeof(EntityUpdate).TypeHandle,
					new KeyValuePair<int, int>(653809342, 1)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(2)
			{
				{ -1938433307, 0 },
				{ 653809342, 1 }
			};
		}

		public void Serialize(ref MessagePackWriter writer, INetworkData value, MessagePackSerializerOptions options)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				writer.WriteArrayHeader(2);
				writer.WriteInt32(value2.Key);
				switch (value2.Value)
				{
				case 0:
					options.Resolver.GetFormatterWithVerify<CommandUpdate>().Serialize(ref writer, (CommandUpdate)(object)value, options);
					break;
				case 1:
					options.Resolver.GetFormatterWithVerify<EntityUpdate>().Serialize(ref writer, (EntityUpdate)(object)value, options);
					break;
				}
			}
			else
			{
				writer.WriteNil();
			}
		}

		public INetworkData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			if (reader.ReadArrayHeader() != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::Kitchen.INetworkData");
			}
			options.Security.DepthStep(ref reader);
			int value = reader.ReadInt32();
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			INetworkData result = null;
			switch (value)
			{
			case 0:
				result = options.Resolver.GetFormatterWithVerify<CommandUpdate>().Deserialize(ref reader, options);
				break;
			case 1:
				result = options.Resolver.GetFormatterWithVerify<EntityUpdate>().Deserialize(ref reader, options);
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
