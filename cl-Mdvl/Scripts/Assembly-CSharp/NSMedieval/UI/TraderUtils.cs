using System.Collections.Generic;
using FoxyVoxel.Logging;
using Gameplay.Resource;
using NSEipix.Base;
using NSMedieval.Components;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;

namespace NSMedieval.UI
{
	public static class TraderUtils
	{
		public static List<TradeResource> GetResources(Storage storage)
		{
			VillageMap map = VillageManager.ActiveVillage.Map;
			List<TradeResource> list = new List<TradeResource>();
			foreach (ResourceInstance resource in storage.Resources)
			{
				if (resource == null || resource.HasDisposed || resource.Amount == 0 || resource.Stats?.GetStat(StatType.Health) == null)
				{
					continue;
				}
				if (resource.Blueprint.UniqueResource)
				{
					int uniqueResourceCount = map.UniqueResourceTracker.GetUniqueResourceCount(resource.BlueprintId);
					UniqueResourceTracker.Occurence uniqueResourceOccurence = map.UniqueResourceTracker.GetUniqueResourceOccurence(resource.BlueprintId);
					if (uniqueResourceCount >= 1 && (uniqueResourceOccurence & UniqueResourceTracker.Occurence.InPlayersPossession) != UniqueResourceTracker.Occurence.None)
					{
						continue;
					}
				}
				list.Add(new TradeResource(resource));
			}
			return list;
		}

		public static float GetPerResourcePriceMultiplier(TraderType traderType, TradeResource resource, VillagePlace traderOriginVillage, FactionInstance traderFaction, bool useMapTypeModifiers)
		{
			float num = 1f;
			foreach (TraderStock item in traderType.GetStocksForResource(resource))
			{
				num *= item.PriceModifier;
			}
			foreach (TraderStockModifier allModifier in GetAllModifiers(traderType, traderOriginVillage, traderFaction, useMapTypeModifiers))
			{
				num *= allModifier.GetPriceModifier(resource);
			}
			return num;
		}

		public static bool CanTradeResource(TraderStockModifiersContainer stockModifiersContainer, TradeResource tradeResource, VillagePlace traderOriginVillage, FactionInstance traderFaction, bool useMapTypeModifiers, List<string> ignoreModifiers = null)
		{
			foreach (TraderStockModifier allModifier in GetAllModifiers(stockModifiersContainer, traderOriginVillage, traderFaction, useMapTypeModifiers))
			{
				if ((ignoreModifiers == null || !ignoreModifiers.Contains(allModifier.GetID())) && !allModifier.CanTradeResource(tradeResource))
				{
					return false;
				}
			}
			return true;
		}

		private static IEnumerable<TraderStockModifier> GetAllModifiers(TraderStockModifiersContainer stockModifiersContainer, VillagePlace traderOriginVillage, FactionInstance traderFaction, bool useMapTypeModifiers)
		{
			List<TraderStockModifier> list = new List<TraderStockModifier>(stockModifiersContainer.StockModifiers);
			if (traderFaction == null)
			{
				Log.Error("GetAllModifiers() called with a null trader faction! Faction modifiers will be skipped so that the game can continue, but this is indicative of a problem in the calling code: faction should not be null", "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TraderUtils.cs");
			}
			else
			{
				list.AddRange(MonoSingleton<TradingManager>.Instance.GetFactionMapSeasonModifiers(traderOriginVillage, traderFaction, useMapTypeModifiers));
				List<TraderStockModifier> stockModifiersForFriendliness = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionSettings.GetStockModifiersForFriendliness(traderFaction.GetFriendliness());
				if (stockModifiersForFriendliness != null)
				{
					list.AddRange(stockModifiersForFriendliness);
				}
			}
			return list;
		}
	}
}
