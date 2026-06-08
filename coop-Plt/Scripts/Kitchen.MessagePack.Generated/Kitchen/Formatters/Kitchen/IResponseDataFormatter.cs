using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class IResponseDataFormatter : IMessagePackFormatter<IResponseData>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public IResponseDataFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(17, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(InfoManagerResponseData).TypeHandle,
					new KeyValuePair<int, int>(-1983764585, 0)
				},
				{
					typeof(StartDayWarningView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(-1741453998, 1)
				},
				{
					typeof(EndgamePopupView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(-1682717986, 2)
				},
				{
					typeof(GenericPopupView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(-1607102936, 3)
				},
				{
					typeof(ProfileEditorView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(-803814639, 4)
				},
				{
					typeof(GenericChoiceView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(-653212088, 5)
				},
				{
					typeof(UnlockSelectPopupView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(-418533289, 6)
				},
				{
					typeof(TransitionPopupView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(-20693806, 7)
				},
				{
					typeof(EndPracticeView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(38070481, 8)
				},
				{
					typeof(PlayerView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(539469367, 9)
				},
				{
					typeof(SeededRunIndicatorView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(724754306, 10)
				},
				{
					typeof(StarIncreaseView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(1002405037, 11)
				},
				{
					typeof(NewsUIView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(1265805642, 12)
				},
				{
					typeof(DishSelectionIndicator.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(1536855452, 13)
				},
				{
					typeof(CostumeChangeIndicator.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(1913071919, 14)
				},
				{
					typeof(EndOfDayPopupView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(1989749035, 15)
				},
				{
					typeof(NameplateView.ResponseData).TypeHandle,
					new KeyValuePair<int, int>(1989952665, 16)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(17)
			{
				{ -1983764585, 0 },
				{ -1741453998, 1 },
				{ -1682717986, 2 },
				{ -1607102936, 3 },
				{ -803814639, 4 },
				{ -653212088, 5 },
				{ -418533289, 6 },
				{ -20693806, 7 },
				{ 38070481, 8 },
				{ 539469367, 9 },
				{ 724754306, 10 },
				{ 1002405037, 11 },
				{ 1265805642, 12 },
				{ 1536855452, 13 },
				{ 1913071919, 14 },
				{ 1989749035, 15 },
				{ 1989952665, 16 }
			};
		}

		public void Serialize(ref MessagePackWriter writer, IResponseData value, MessagePackSerializerOptions options)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				writer.WriteArrayHeader(2);
				writer.WriteInt32(value2.Key);
				switch (value2.Value)
				{
				case 0:
					options.Resolver.GetFormatterWithVerify<InfoManagerResponseData>().Serialize(ref writer, (InfoManagerResponseData)(object)value, options);
					break;
				case 1:
					options.Resolver.GetFormatterWithVerify<StartDayWarningView.ResponseData>().Serialize(ref writer, (StartDayWarningView.ResponseData)(object)value, options);
					break;
				case 2:
					options.Resolver.GetFormatterWithVerify<EndgamePopupView.ResponseData>().Serialize(ref writer, (EndgamePopupView.ResponseData)(object)value, options);
					break;
				case 3:
					options.Resolver.GetFormatterWithVerify<GenericPopupView.ResponseData>().Serialize(ref writer, (GenericPopupView.ResponseData)(object)value, options);
					break;
				case 4:
					options.Resolver.GetFormatterWithVerify<ProfileEditorView.ResponseData>().Serialize(ref writer, (ProfileEditorView.ResponseData)(object)value, options);
					break;
				case 5:
					options.Resolver.GetFormatterWithVerify<GenericChoiceView.ResponseData>().Serialize(ref writer, (GenericChoiceView.ResponseData)(object)value, options);
					break;
				case 6:
					options.Resolver.GetFormatterWithVerify<UnlockSelectPopupView.ResponseData>().Serialize(ref writer, (UnlockSelectPopupView.ResponseData)(object)value, options);
					break;
				case 7:
					options.Resolver.GetFormatterWithVerify<TransitionPopupView.ResponseData>().Serialize(ref writer, (TransitionPopupView.ResponseData)(object)value, options);
					break;
				case 8:
					options.Resolver.GetFormatterWithVerify<EndPracticeView.ResponseData>().Serialize(ref writer, (EndPracticeView.ResponseData)(object)value, options);
					break;
				case 9:
					options.Resolver.GetFormatterWithVerify<PlayerView.ResponseData>().Serialize(ref writer, (PlayerView.ResponseData)(object)value, options);
					break;
				case 10:
					options.Resolver.GetFormatterWithVerify<SeededRunIndicatorView.ResponseData>().Serialize(ref writer, (SeededRunIndicatorView.ResponseData)(object)value, options);
					break;
				case 11:
					options.Resolver.GetFormatterWithVerify<StarIncreaseView.ResponseData>().Serialize(ref writer, (StarIncreaseView.ResponseData)(object)value, options);
					break;
				case 12:
					options.Resolver.GetFormatterWithVerify<NewsUIView.ResponseData>().Serialize(ref writer, (NewsUIView.ResponseData)(object)value, options);
					break;
				case 13:
					options.Resolver.GetFormatterWithVerify<DishSelectionIndicator.ResponseData>().Serialize(ref writer, (DishSelectionIndicator.ResponseData)(object)value, options);
					break;
				case 14:
					options.Resolver.GetFormatterWithVerify<CostumeChangeIndicator.ResponseData>().Serialize(ref writer, (CostumeChangeIndicator.ResponseData)(object)value, options);
					break;
				case 15:
					options.Resolver.GetFormatterWithVerify<EndOfDayPopupView.ResponseData>().Serialize(ref writer, (EndOfDayPopupView.ResponseData)(object)value, options);
					break;
				case 16:
					options.Resolver.GetFormatterWithVerify<NameplateView.ResponseData>().Serialize(ref writer, (NameplateView.ResponseData)(object)value, options);
					break;
				}
			}
			else
			{
				writer.WriteNil();
			}
		}

		public IResponseData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}
			if (reader.ReadArrayHeader() != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::Kitchen.IResponseData");
			}
			options.Security.DepthStep(ref reader);
			int value = reader.ReadInt32();
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			IResponseData result = null;
			switch (value)
			{
			case 0:
				result = options.Resolver.GetFormatterWithVerify<InfoManagerResponseData>().Deserialize(ref reader, options);
				break;
			case 1:
				result = options.Resolver.GetFormatterWithVerify<StartDayWarningView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 2:
				result = options.Resolver.GetFormatterWithVerify<EndgamePopupView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 3:
				result = options.Resolver.GetFormatterWithVerify<GenericPopupView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 4:
				result = options.Resolver.GetFormatterWithVerify<ProfileEditorView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 5:
				result = options.Resolver.GetFormatterWithVerify<GenericChoiceView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 6:
				result = options.Resolver.GetFormatterWithVerify<UnlockSelectPopupView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 7:
				result = options.Resolver.GetFormatterWithVerify<TransitionPopupView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 8:
				result = options.Resolver.GetFormatterWithVerify<EndPracticeView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 9:
				result = options.Resolver.GetFormatterWithVerify<PlayerView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 10:
				result = options.Resolver.GetFormatterWithVerify<SeededRunIndicatorView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 11:
				result = options.Resolver.GetFormatterWithVerify<StarIncreaseView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 12:
				result = options.Resolver.GetFormatterWithVerify<NewsUIView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 13:
				result = options.Resolver.GetFormatterWithVerify<DishSelectionIndicator.ResponseData>().Deserialize(ref reader, options);
				break;
			case 14:
				result = options.Resolver.GetFormatterWithVerify<CostumeChangeIndicator.ResponseData>().Deserialize(ref reader, options);
				break;
			case 15:
				result = options.Resolver.GetFormatterWithVerify<EndOfDayPopupView.ResponseData>().Deserialize(ref reader, options);
				break;
			case 16:
				result = options.Resolver.GetFormatterWithVerify<NameplateView.ResponseData>().Deserialize(ref reader, options);
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
