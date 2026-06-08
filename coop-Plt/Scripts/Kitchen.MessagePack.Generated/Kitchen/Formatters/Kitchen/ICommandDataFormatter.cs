using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ICommandDataFormatter : IMessagePackFormatter<ICommandData>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public ICommandDataFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(2, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(KickUserData).TypeHandle,
					new KeyValuePair<int, int>(-592772741, 0)
				},
				{
					typeof(UserJoinData).TypeHandle,
					new KeyValuePair<int, int>(2146445293, 1)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(2)
			{
				{ -592772741, 0 },
				{ 2146445293, 1 }
			};
		}

		public void Serialize(ref MessagePackWriter writer, ICommandData value, MessagePackSerializerOptions options)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				writer.WriteArrayHeader(2);
				writer.WriteInt32(value2.Key);
				switch (value2.Value)
				{
				case 0:
					options.Resolver.GetFormatterWithVerify<KickUserData>().Serialize(ref writer, (KickUserData)(object)value, options);
					break;
				case 1:
					options.Resolver.GetFormatterWithVerify<UserJoinData>().Serialize(ref writer, (UserJoinData)(object)value, options);
					break;
				}
			}
			else
			{
				writer.WriteNil();
			}
		}

		public ICommandData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			if (reader.ReadArrayHeader() != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::Kitchen.ICommandData");
			}
			options.Security.DepthStep(ref reader);
			int value = reader.ReadInt32();
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			ICommandData result = null;
			switch (value)
			{
			case 0:
				result = options.Resolver.GetFormatterWithVerify<KickUserData>().Deserialize(ref reader, options);
				break;
			case 1:
				result = options.Resolver.GetFormatterWithVerify<UserJoinData>().Deserialize(ref reader, options);
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
