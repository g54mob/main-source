using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class GameInfoTransferView_ViewDataFormatter : IMessagePackFormatter<GameInfoTransferView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, GameInfoTransferView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(4);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Unlocks, options);
			resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Upgrades, options);
			resolver.GetFormatterWithVerify<SceneType>().Serialize(ref writer, value.CurrentScene, options);
			resolver.GetFormatterWithVerify<Bounds>().Serialize(ref writer, value.CurrentGameplayBounds, options);
		}

		public GameInfoTransferView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			GameInfoTransferView.ViewData result = default(GameInfoTransferView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Unlocks = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Upgrades = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
					break;
				case 2:
					result.CurrentScene = resolver.GetFormatterWithVerify<SceneType>().Deserialize(ref reader, options);
					break;
				case 3:
					result.CurrentGameplayBounds = resolver.GetFormatterWithVerify<Bounds>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
