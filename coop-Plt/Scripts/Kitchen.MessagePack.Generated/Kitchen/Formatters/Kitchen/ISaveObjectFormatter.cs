using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ISaveObjectFormatter : IMessagePackFormatter<ISaveObject>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public ISaveObjectFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(10, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(PackSaveUpgrades.V1).TypeHandle,
					new KeyValuePair<int, int>(-1784243180, 0)
				},
				{
					typeof(IPackSaveObject).TypeHandle,
					new KeyValuePair<int, int>(-1716215254, 1)
				},
				{
					typeof(PackSaveExpGrants.V1).TypeHandle,
					new KeyValuePair<int, int>(0, 2)
				},
				{
					typeof(PackSaveCardSets.V1).TypeHandle,
					new KeyValuePair<int, int>(1, 3)
				},
				{
					typeof(PackSaveLevel.V1).TypeHandle,
					new KeyValuePair<int, int>(2, 4)
				},
				{
					typeof(PackSaveUpgrades.V2).TypeHandle,
					new KeyValuePair<int, int>(3, 5)
				},
				{
					typeof(PackSaveCardSets.V2).TypeHandle,
					new KeyValuePair<int, int>(4, 6)
				},
				{
					typeof(PackSaveCardSets.V3).TypeHandle,
					new KeyValuePair<int, int>(5, 7)
				},
				{
					typeof(PackSaveCardSets.V4).TypeHandle,
					new KeyValuePair<int, int>(6, 8)
				},
				{
					typeof(PackSaveSpeedrun.V1).TypeHandle,
					new KeyValuePair<int, int>(7, 9)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(10)
			{
				{ -1784243180, 0 },
				{ -1716215254, 1 },
				{ 0, 2 },
				{ 1, 3 },
				{ 2, 4 },
				{ 3, 5 },
				{ 4, 6 },
				{ 5, 7 },
				{ 6, 8 },
				{ 7, 9 }
			};
		}

		public void Serialize(ref MessagePackWriter writer, ISaveObject value, MessagePackSerializerOptions options)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				writer.WriteArrayHeader(2);
				writer.WriteInt32(value2.Key);
				switch (value2.Value)
				{
				case 0:
					options.Resolver.GetFormatterWithVerify<PackSaveUpgrades.V1>().Serialize(ref writer, (PackSaveUpgrades.V1)(object)value, options);
					break;
				case 1:
					options.Resolver.GetFormatterWithVerify<IPackSaveObject>().Serialize(ref writer, (IPackSaveObject)value, options);
					break;
				case 2:
					options.Resolver.GetFormatterWithVerify<PackSaveExpGrants.V1>().Serialize(ref writer, (PackSaveExpGrants.V1)(object)value, options);
					break;
				case 3:
					options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V1>().Serialize(ref writer, (PackSaveCardSets.V1)(object)value, options);
					break;
				case 4:
					options.Resolver.GetFormatterWithVerify<PackSaveLevel.V1>().Serialize(ref writer, (PackSaveLevel.V1)(object)value, options);
					break;
				case 5:
					options.Resolver.GetFormatterWithVerify<PackSaveUpgrades.V2>().Serialize(ref writer, (PackSaveUpgrades.V2)(object)value, options);
					break;
				case 6:
					options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V2>().Serialize(ref writer, (PackSaveCardSets.V2)(object)value, options);
					break;
				case 7:
					options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V3>().Serialize(ref writer, (PackSaveCardSets.V3)(object)value, options);
					break;
				case 8:
					options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V4>().Serialize(ref writer, (PackSaveCardSets.V4)(object)value, options);
					break;
				case 9:
					options.Resolver.GetFormatterWithVerify<PackSaveSpeedrun.V1>().Serialize(ref writer, (PackSaveSpeedrun.V1)(object)value, options);
					break;
				}
			}
			else
			{
				writer.WriteNil();
			}
		}

		public ISaveObject Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			if (reader.ReadArrayHeader() != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::Kitchen.ISaveObject");
			}
			options.Security.DepthStep(ref reader);
			int value = reader.ReadInt32();
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			ISaveObject result = null;
			switch (value)
			{
			case 0:
				result = options.Resolver.GetFormatterWithVerify<PackSaveUpgrades.V1>().Deserialize(ref reader, options);
				break;
			case 1:
				result = options.Resolver.GetFormatterWithVerify<IPackSaveObject>().Deserialize(ref reader, options);
				break;
			case 2:
				result = options.Resolver.GetFormatterWithVerify<PackSaveExpGrants.V1>().Deserialize(ref reader, options);
				break;
			case 3:
				result = options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V1>().Deserialize(ref reader, options);
				break;
			case 4:
				result = options.Resolver.GetFormatterWithVerify<PackSaveLevel.V1>().Deserialize(ref reader, options);
				break;
			case 5:
				result = options.Resolver.GetFormatterWithVerify<PackSaveUpgrades.V2>().Deserialize(ref reader, options);
				break;
			case 6:
				result = options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V2>().Deserialize(ref reader, options);
				break;
			case 7:
				result = options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V3>().Deserialize(ref reader, options);
				break;
			case 8:
				result = options.Resolver.GetFormatterWithVerify<PackSaveCardSets.V4>().Deserialize(ref reader, options);
				break;
			case 9:
				result = options.Resolver.GetFormatterWithVerify<PackSaveSpeedrun.V1>().Deserialize(ref reader, options);
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
