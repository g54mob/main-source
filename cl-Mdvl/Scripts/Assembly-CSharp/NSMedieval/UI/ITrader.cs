using System.Collections.Generic;
using NSMedieval.State;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	public interface ITrader
	{
		FactionInstance Faction { get; }

		float GetSellMultiplier();

		float GetBuyMultiplier();

		List<TradeResource> GetResources(ITrader otherTrader);

		string GetTraderName();

		string GetSettlementName();

		Sprite GetHeraldryCrest();

		Sprite GetHeraldryBackground();

		float GetBargainMultiplier();

		void AddItemToStorage(TradeResource tradeResource, int count);

		void RemoveItemFromStorage(TradeResource tradeResource, int count);

		float GetPerResourcePriceMultiplier(TradeResource resource);

		VillagePlace GetTraderVillagePlace();

		bool CanTradeResource(TradeResource resource);

		bool IsTraderFriendly();

		int GetStorageCapacity();

		float GetMinimumNutrition();

		TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase);
	}
}
