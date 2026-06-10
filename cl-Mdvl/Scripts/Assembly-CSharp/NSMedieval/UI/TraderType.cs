using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	[Serializable]
	public class TraderType : TraderStockModifiersContainer
	{
		[SerializeField]
		private List<TraderStock> stocks;

		[SerializeField]
		private int bodyguardStrength;

		[SerializeField]
		private int storageCapacity = 500;

		[SerializeField]
		private bool standsOnTheMapEdge;

		[SerializeField]
		private bool idleDoNotWalk;

		[SerializeField]
		private float spawnStashMarkerGiftBalanceThresh;

		[SerializeField]
		private float knowsRumoursBanditCampChance;

		public int BodyguardStrength => bodyguardStrength;

		public int StorageCapacity => storageCapacity;

		public bool StandsOnTheMapEdge => standsOnTheMapEdge;

		public bool IdleDoNotWalk => idleDoNotWalk;

		public float SpawnStashMarkerGiftBalanceThresh => spawnStashMarkerGiftBalanceThresh;

		public float KnowsRumoursBanditCampChance => knowsRumoursBanditCampChance;

		public void GenerateResourceInstances(VillagePlace villagePlace, FactionInstance traderFaction, bool useMapTypeModifiers, out List<ResourceInstance> resources, out List<KeyValuePair<Animal, TraderStockItem>> animals, out List<string> addPrisonersByFaction)
		{
			resources = new List<ResourceInstance>();
			animals = new List<KeyValuePair<Animal, TraderStockItem>>();
			addPrisonersByFaction = new List<string>();
			List<TraderStockModifier> list = new List<TraderStockModifier>(base.StockModifiers);
			list.AddRange(MonoSingleton<TradingManager>.Instance.GetFactionMapSeasonModifiers(villagePlace, traderFaction, useMapTypeModifiers));
			foreach (TraderStock stock in stocks)
			{
				if (stock != null && (!(stock.Chance < 1f) || !(UnityEngine.Random.value > stock.Chance)))
				{
					stock.AddToList(list, resources, animals, addPrisonersByFaction);
				}
			}
		}

		public IEnumerable<TraderStock> GetStocksForResource(TradeResource tradeResource)
		{
			return stocks.Where((TraderStock stock) => stock.ContainsResource(tradeResource));
		}
	}
}
