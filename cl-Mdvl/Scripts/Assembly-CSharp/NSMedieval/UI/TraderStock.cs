using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	[FVSerializableKey("TraderStock", "")]
	public class TraderStock : IFVSerializable
	{
		[SerializeField]
		private string stockName;

		[SerializeField]
		private float chance;

		[SerializeField]
		private float priceModifier = 1f;

		[NonSerialized]
		private TraderStockContent traderStockCache;

		public float Chance => chance;

		public TraderStockContent Stock
		{
			get
			{
				if (traderStockCache == null)
				{
					traderStockCache = Repository<TraderStockRepository, TraderStockContent>.Instance.GetByID(stockName);
				}
				return traderStockCache;
			}
		}

		public float PriceModifier => priceModifier;

		public TraderStock()
		{
		}

		public void AddToList(List<ResourceInstance> resources, Unity.Mathematics.Random random)
		{
			AddToList(null, resources, null, null, random);
		}

		public void AddToList(List<TraderStockModifier> modifiers, List<ResourceInstance> resourceInstances, List<KeyValuePair<Animal, TraderStockItem>> animals, List<string> addPrisonersByFaction, Unity.Mathematics.Random random = default(Unity.Mathematics.Random))
		{
			if (Stock == null)
			{
				Log.Info("Trader stocks: stocks list is null.", "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TraderStock.cs");
				return;
			}
			if (random.state == 0)
			{
				random = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(1f, 4.2949673E+09f));
			}
			foreach (TraderStockItem stockItem in Stock.StockItems)
			{
				if (stockItem == null || (stockItem.Chance < 1f && random.NextDouble() > (double)stockItem.Chance))
				{
					continue;
				}
				HashSet<TraderStockResource> allPossibleResources = stockItem.GetAllPossibleResources();
				if (allPossibleResources.Count == 0)
				{
					bool isEnabled;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TraderStock.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Stock item ");
						messageBuilder.AppendFormatted(Stock.GetID());
						messageBuilder.AppendLiteral(" [");
						messageBuilder.AppendFormatted(Stock.StockItems.IndexOf(stockItem));
						messageBuilder.AppendLiteral("] has no content.");
					}
					Log.Info(messageBuilder);
					continue;
				}
				int num = stockItem.EntriesCount.Random(random);
				for (int i = 0; i < num; i++)
				{
					TraderStockResource traderStockResource = allPossibleResources.PickRandom(ref random);
					float num2 = stockItem.AmountRange.Random(random);
					if (modifiers != null)
					{
						foreach (TraderStockModifier modifier in modifiers)
						{
							if (!modifier.IsExcluded(traderStockResource))
							{
								num2 *= modifier.GetAmountModifier(traderStockResource);
							}
						}
					}
					if (traderStockResource.Resource != null)
					{
						resourceInstances.Add(new ResourceInstance(traderStockResource.Resource, (int)num2));
					}
					if (traderStockResource.Animal != null)
					{
						animals?.Add(new KeyValuePair<Animal, TraderStockItem>(traderStockResource.Animal, stockItem));
					}
					if (traderStockResource.IsPrisoner)
					{
						addPrisonersByFaction?.Add(traderStockResource.PrisonerFactionId);
					}
				}
			}
		}

		public bool ContainsResource(TradeResource tradeResource)
		{
			return Stock.Contains(tradeResource);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("stockName", stockName);
			serializer.Write("chance", chance);
			serializer.Write("priceModifier", priceModifier);
		}

		public TraderStock(FVDeserializer deserializer)
		{
			stockName = deserializer.ReadString("stockName");
			chance = deserializer.ReadFloat("chance");
			priceModifier = deserializer.ReadFloat("priceModifier");
		}
	}
}
