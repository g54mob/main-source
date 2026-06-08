using System;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class ItemCollectionView_ItemDataFormatter : IMessagePackFormatter<ItemCollectionView.ItemData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, ItemCollectionView.ItemData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(9);
			writer.Write(value.IsComplete);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.SeatPosition, options);
			writer.Write(value.ItemID);
			writer.Write(value.IsSide);
			resolver.GetFormatterWithVerify<ItemList>().Serialize(ref writer, value.Components, options);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.TablePosition, options);
			writer.Write(value.ShowExtra);
			writer.Write(value.ExtraID);
			writer.Write(value.IsSatisfiedBySharer);
		}

		public ItemCollectionView.ItemData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			ItemCollectionView.ItemData result = default(ItemCollectionView.ItemData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.IsComplete = reader.ReadBoolean();
					break;
				case 1:
					result.SeatPosition = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 2:
					result.ItemID = reader.ReadInt32();
					break;
				case 3:
					result.IsSide = reader.ReadBoolean();
					break;
				case 4:
					result.Components = resolver.GetFormatterWithVerify<ItemList>().Deserialize(ref reader, options);
					break;
				case 5:
					result.TablePosition = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 6:
					result.ShowExtra = reader.ReadBoolean();
					break;
				case 7:
					result.ExtraID = reader.ReadInt32();
					break;
				case 8:
					result.IsSatisfiedBySharer = reader.ReadBoolean();
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
