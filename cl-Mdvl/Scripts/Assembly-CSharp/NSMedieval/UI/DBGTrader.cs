using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	public class DBGTrader : ITrader
	{
		private List<TradeResource> resources;

		private FactionInstance faction;

		public FactionInstance Faction => null;

		private void TryInit()
		{
			if (resources == null)
			{
				resources = new List<TradeResource>();
				Repository<ResourceRepository, Resource>.Instance.GetAllItems();
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID("wood");
				resources.Add(new TradeResource(byID, 500));
				Resource byID2 = Repository<ResourceRepository, Resource>.Instance.GetByID("good_short_bow");
				resources.Add(new TradeResource(byID2, 1));
				Resource byID3 = Repository<ResourceRepository, Resource>.Instance.GetByID("sturdy_wooden_spear");
				resources.Add(new TradeResource(byID3, 1));
			}
			if (faction == null)
			{
				faction = GlobalSaveController.CurrentVillageData.WorldMapData.FactionInstances.PickRandom();
			}
		}

		public float GetSellMultiplier()
		{
			return 1f;
		}

		public float GetBuyMultiplier()
		{
			return 1f;
		}

		public List<TradeResource> GetResources(ITrader otherTrader)
		{
			TryInit();
			return resources;
		}

		public string GetTraderName()
		{
			return "Mr. Debug Trader";
		}

		public string GetSettlementName()
		{
			TryInit();
			return "Debug Village of " + faction.NameLocalized;
		}

		public Sprite GetHeraldryCrest()
		{
			TryInit();
			return faction.Blueprint.HeraldryCrestSprite;
		}

		public Sprite GetHeraldryBackground()
		{
			TryInit();
			return faction.Blueprint.HeraldryBackgroundSprite;
		}

		public float GetBargainMultiplier()
		{
			return 1f;
		}

		public void AddItemToStorage(TradeResource tradeResource, int count)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\DBGTrader.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PH adding item ");
				messageBuilder.AppendFormatted(tradeResource.Resource.GetID());
				messageBuilder.AppendLiteral(" X ");
				messageBuilder.AppendFormatted(count);
				messageBuilder.AppendLiteral(" to DBG trader's storage/");
			}
			Log.Debug(messageBuilder);
		}

		public void RemoveItemFromStorage(TradeResource tradeResource, int count)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(45, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\DBGTrader.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PH removing item ");
				messageBuilder.AppendFormatted(tradeResource.Resource.GetID());
				messageBuilder.AppendLiteral(" X ");
				messageBuilder.AppendFormatted(count);
				messageBuilder.AppendLiteral(" to DBG trader's storage/");
			}
			Log.Debug(messageBuilder);
		}

		public float GetPerResourcePriceMultiplier(TradeResource resource)
		{
			return 1f;
		}

		public VillagePlace GetTraderVillagePlace()
		{
			return null;
		}

		public bool CanTradeResource(TradeResource resource)
		{
			return true;
		}

		public bool IsTraderFriendly()
		{
			return true;
		}

		public int GetStorageCapacity()
		{
			return -1;
		}

		public float GetMinimumNutrition()
		{
			return 0f;
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			return TradeForbiddenReason.None;
		}
	}
}
