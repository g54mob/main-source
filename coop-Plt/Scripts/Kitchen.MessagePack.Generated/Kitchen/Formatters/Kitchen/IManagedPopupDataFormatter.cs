using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class IManagedPopupDataFormatter : IMessagePackFormatter<IManagedPopupData>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public IManagedPopupDataFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(7, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(CPopupEndDayData).TypeHandle,
					new KeyValuePair<int, int>(-1750067856, 0)
				},
				{
					typeof(CPopupFloat).TypeHandle,
					new KeyValuePair<int, int>(-1193961480, 1)
				},
				{
					typeof(CLocationPopupRequest).TypeHandle,
					new KeyValuePair<int, int>(-799573293, 2)
				},
				{
					typeof(CPopupSpeedrunCompleted).TypeHandle,
					new KeyValuePair<int, int>(-713795405, 3)
				},
				{
					typeof(StartPracticePopup.CRequest).TypeHandle,
					new KeyValuePair<int, int>(1277820882, 4)
				},
				{
					typeof(CPopupRecipe).TypeHandle,
					new KeyValuePair<int, int>(1874842382, 5)
				},
				{
					typeof(RestartDayPopup.SPopup).TypeHandle,
					new KeyValuePair<int, int>(1954237876, 6)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(7)
			{
				{ -1750067856, 0 },
				{ -1193961480, 1 },
				{ -799573293, 2 },
				{ -713795405, 3 },
				{ 1277820882, 4 },
				{ 1874842382, 5 },
				{ 1954237876, 6 }
			};
		}

		public void Serialize(ref MessagePackWriter writer, IManagedPopupData value, MessagePackSerializerOptions options)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				writer.WriteArrayHeader(2);
				writer.WriteInt32(value2.Key);
				switch (value2.Value)
				{
				case 0:
					options.Resolver.GetFormatterWithVerify<CPopupEndDayData>().Serialize(ref writer, (CPopupEndDayData)(object)value, options);
					break;
				case 1:
					options.Resolver.GetFormatterWithVerify<CPopupFloat>().Serialize(ref writer, (CPopupFloat)(object)value, options);
					break;
				case 2:
					options.Resolver.GetFormatterWithVerify<CLocationPopupRequest>().Serialize(ref writer, (CLocationPopupRequest)(object)value, options);
					break;
				case 3:
					options.Resolver.GetFormatterWithVerify<CPopupSpeedrunCompleted>().Serialize(ref writer, (CPopupSpeedrunCompleted)(object)value, options);
					break;
				case 4:
					options.Resolver.GetFormatterWithVerify<StartPracticePopup.CRequest>().Serialize(ref writer, (StartPracticePopup.CRequest)(object)value, options);
					break;
				case 5:
					options.Resolver.GetFormatterWithVerify<CPopupRecipe>().Serialize(ref writer, (CPopupRecipe)(object)value, options);
					break;
				case 6:
					options.Resolver.GetFormatterWithVerify<RestartDayPopup.SPopup>().Serialize(ref writer, (RestartDayPopup.SPopup)(object)value, options);
					break;
				}
			}
			else
			{
				writer.WriteNil();
			}
		}

		public IManagedPopupData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			if (reader.ReadArrayHeader() != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::Kitchen.IManagedPopupData");
			}
			options.Security.DepthStep(ref reader);
			int value = reader.ReadInt32();
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			IManagedPopupData result = null;
			switch (value)
			{
			case 0:
				result = options.Resolver.GetFormatterWithVerify<CPopupEndDayData>().Deserialize(ref reader, options);
				break;
			case 1:
				result = options.Resolver.GetFormatterWithVerify<CPopupFloat>().Deserialize(ref reader, options);
				break;
			case 2:
				result = options.Resolver.GetFormatterWithVerify<CLocationPopupRequest>().Deserialize(ref reader, options);
				break;
			case 3:
				result = options.Resolver.GetFormatterWithVerify<CPopupSpeedrunCompleted>().Deserialize(ref reader, options);
				break;
			case 4:
				result = options.Resolver.GetFormatterWithVerify<StartPracticePopup.CRequest>().Deserialize(ref reader, options);
				break;
			case 5:
				result = options.Resolver.GetFormatterWithVerify<CPopupRecipe>().Deserialize(ref reader, options);
				break;
			case 6:
				result = options.Resolver.GetFormatterWithVerify<RestartDayPopup.SPopup>().Deserialize(ref reader, options);
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
