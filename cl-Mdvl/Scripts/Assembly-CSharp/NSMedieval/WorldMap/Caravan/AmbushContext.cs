using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Dialogs;
using NSMedieval.Dialogs.Data;
using NSMedieval.GameEventSystem;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.WorldMap.Caravan
{
	[FVSerializableKey("AmbushContext", "")]
	public class AmbushContext : ICaravanEvent, IFVSerializable, ITrader
	{
		public enum AmbushResolutionType
		{
			None = 0,
			VictoryNegotiated = 1,
			DefeatTimeout = 2,
			VictoryBattle = 3,
			DefeatBattle = 4,
			DefeatEscape = 5,
			TieBattle = 6,
			FullDefeat = 7
		}

		public WorldMapMarkerReference MapPlaceReference;

		public long MinutesExpireAmbushWait;

		public float ValueDemanded;

		private Storage negotiatorStorage;

		private WorldDate dateTime;

		private string enemyCountInfoLocalized;

		private int caravanId;

		public FactionInstance Faction { get; set; }

		public int CaravanId
		{
			get
			{
				return caravanId;
			}
			set
			{
				caravanId = value;
				Caravan = CaravanManager.GetCaravan(caravanId);
			}
		}

		public AmbushResolutionType Outcome { get; private set; }

		public string EnemyCountInfoLocalized
		{
			get
			{
				if (enemyCountInfoLocalized == null)
				{
					int count = CaravanManager.GetCaravan(CaravanId).Workers.Count;
					List<IEnemyPurchaseUnit> enemies;
					List<SiegeWeaponComponentBlueprint> siegeWeapons;
					bool isSiege;
					bool flag = GameEventUtil.TryPurchaseEnemies(Faction.BlueprintId, MonoSingleton<BaseWealth>.Instance.GetRaidPointsForAmbush(count), out enemies, out siegeWeapons, out isSiege);
					enemyCountInfoLocalized = (flag ? UiUtils.BuildPreciseEnemiesListing(enemies, siegeWeapons) : string.Empty);
				}
				return enemyCountInfoLocalized;
			}
		}

		private CaravanInstance Caravan { get; set; }

		private TraderType NegotiatorTraderType => CaravanAmbushSettings.I.NegotiatorTraderType;

		private WorldDate DateTime
		{
			get
			{
				if (dateTime == null)
				{
					dateTime = GlobalSaveController.CurrentVillageData.DateAndTime;
				}
				return dateTime;
			}
		}

		public AmbushContext(CaravanInstance caravan, WorldDate dateTime, Vector2Int currentCaravanPosition, int caravanWealth)
		{
			negotiatorStorage = new Storage(new StorageBase(300, ignoreWeigth: true, infinite: true));
			caravanId = caravan.UniqueId;
			Caravan = caravan;
			WorldMapMarkerPlace worldMapMarkerPlace = MapPlaceGenerator.SpawnCaravanAmbush(currentCaravanPosition);
			worldMapMarkerPlace.CaravanId = CaravanId;
			Faction = worldMapMarkerPlace.FactionInstance;
			MapPlaceReference = (WorldMapMarkerReference)worldMapMarkerPlace.CreateReference();
			MinutesExpireAmbushWait = dateTime.MinutesTotal + CaravanAmbushSettings.I.WaitTimeRangeMinutes.Random();
			ValueDemanded = CaravanAmbushSettings.I.ValueDemandedBasedOnWealth.GetMultiplierInterpolated(caravanWealth);
			Outcome = AmbushResolutionType.None;
			DialogContent dialogContent = new DialogContent
			{
				WindowTitle = "game_event_type_raid",
				ContentTitle = "ambush_load_title",
				ContentBodyText = "ambush_load_desc",
				ContentBodyImagePath = "event_ambush",
				ShowCloseButton = true,
				Options = new List<DialogOption>
				{
					new DialogOption
					{
						Text = "general_ok"
					},
					new DialogOption
					{
						Text = "general_jump_to_location"
					}
				}
			};
			dialogContent.Localize();
			dialogContent.Format((string text) => text.Replace("<faction_name>", Faction.NameLocalized));
			MonoSingleton<DialogViewManager>.Instance.OpenDialog(dialogContent);
			DialogViewManager instance = MonoSingleton<DialogViewManager>.Instance;
			instance.OnClose = (Action<int>)Delegate.Combine(instance.OnClose, new Action<int>(OnDialogClosed));
		}

		private void OnDialogClosed(int optionIndex)
		{
			DialogViewManager instance = MonoSingleton<DialogViewManager>.Instance;
			instance.OnClose = (Action<int>)Delegate.Remove(instance.OnClose, new Action<int>(OnDialogClosed));
			if (optionIndex != 0 && optionIndex == 1)
			{
				MonoSingleton<WorldMap>.Instance.JumpToCaravan(Caravan);
			}
		}

		public long MinutesToAutoSurrenderAmbush()
		{
			long num = MinutesExpireAmbushWait - DateTime.MinutesTotal;
			if (num >= 0)
			{
				return num;
			}
			return 0L;
		}

		public void OpenNegotiationPanel(CaravanInstance caravan)
		{
			MonoSingleton<TradingManager>.Instance.OpenExtortionMenu(caravan, this, ValueDemanded);
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
			MonoSingleton<TradingManager>.Instance.TradeAppliedEvent += OnTradeApplied;
		}

		public void CloseNegotiationPanel()
		{
			if (MonoSingleton<TradingManager>.IsInstantiated())
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
				MonoSingleton<TradingManager>.Instance.CloseExtortionMenu();
			}
		}

		private void OnTradeApplied(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly)
		{
			if (otherTrader == this)
			{
				MonoSingleton<TradingManager>.Instance.TradeAppliedEvent -= OnTradeApplied;
				Resolve(AmbushResolutionType.VictoryNegotiated);
			}
		}

		public void Tick()
		{
			if (MinutesExpireAmbushWait > 0 && MinutesToAutoSurrenderAmbush() <= 0)
			{
				Resolve(AmbushResolutionType.DefeatTimeout);
			}
		}

		public void Resolve(AmbushResolutionType type)
		{
			bool isEnabled;
			if (Outcome != AmbushResolutionType.None)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\AmbushContext.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to resolve ambush but it is already resolved with ");
					messageBuilder.AppendFormatted(Outcome);
				}
				Log.Error(messageBuilder);
				return;
			}
			FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\AmbushContext.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Ambush resolved with ");
				messageBuilder2.AppendFormatted(type);
			}
			Log.Info(messageBuilder2);
			Outcome = type;
			Caravan.ClearEventContext();
			bool flag = true;
			switch (Outcome)
			{
			case AmbushResolutionType.VictoryBattle:
				Caravan.ContinueTripToDestination();
				flag = false;
				break;
			case AmbushResolutionType.DefeatBattle:
				Caravan.StartTripHome();
				break;
			case AmbushResolutionType.DefeatTimeout:
			case AmbushResolutionType.DefeatEscape:
				Caravan.StartTripHome();
				break;
			case AmbushResolutionType.TieBattle:
				Caravan.ContinueTripToDestination();
				break;
			case AmbushResolutionType.VictoryNegotiated:
				Caravan.ContinueTripToDestination();
				break;
			case AmbushResolutionType.FullDefeat:
				Caravan.StartTripHome();
				break;
			}
			WorldMapMarkerPlace worldMapMarkerPlace = (WorldMapMarkerPlace)MapPlaceReference.Value;
			worldMapMarkerPlace.CaravanId = int.MaxValue;
			bool flag2 = worldMapMarkerPlace.LootableCreatures.Count == 0 && worldMapMarkerPlace.LootableStorage.IsEmpty();
			if (flag || flag2)
			{
				MonoSingleton<WorldMap>.Instance.MarkerManager.DestroyMarker(worldMapMarkerPlace);
			}
			else
			{
				worldMapMarkerPlace.MarkerState = MapMarkerState.Lootable;
				worldMapMarkerPlace.SetExpireDaysFromNow(10);
				worldMapMarkerPlace.HasView = true;
				MonoSingleton<WorldMap>.Instance.MarkerManager.CreateView(worldMapMarkerPlace);
				worldMapMarkerPlace.Position = Caravan.GetCurrentGridPosition();
			}
			CloseNegotiationPanel();
			MapPlaceReference = null;
			Faction = null;
			ValueDemanded = 0f;
			MinutesExpireAmbushWait = 0L;
			enemyCountInfoLocalized = null;
		}

		public void OnLeftMap()
		{
			switch (MonoSingleton<TravelManager>.Instance.SecondMapLeaveOutcome)
			{
			case SecondMapLeaveOutcome.LeftWithoutEngagingEnemy:
			case SecondMapLeaveOutcome.BattleInProgress:
				Resolve(AmbushResolutionType.DefeatEscape);
				break;
			case SecondMapLeaveOutcome.BattleDefeat:
				Resolve(AmbushResolutionType.DefeatBattle);
				break;
			case SecondMapLeaveOutcome.BattleTie:
				Resolve(AmbushResolutionType.TieBattle);
				break;
			case SecondMapLeaveOutcome.BattleVictory:
				Resolve(AmbushResolutionType.VictoryBattle);
				break;
			case SecondMapLeaveOutcome.FullDefeat:
				Resolve(AmbushResolutionType.FullDefeat);
				break;
			}
		}

		public void OnLoaded()
		{
			Caravan = CaravanManager.GetCaravan(CaravanId);
		}

		public float GetSellMultiplier()
		{
			return 1.4f;
		}

		public float GetBuyMultiplier()
		{
			return 0.6f;
		}

		public List<TradeResource> GetResources(ITrader otherTrader)
		{
			return new List<TradeResource>();
		}

		public string GetTraderName()
		{
			return Faction?.NameLocalized;
		}

		public string GetSettlementName()
		{
			return "general_ambush";
		}

		public Sprite GetHeraldryCrest()
		{
			return Faction.Blueprint.HeraldryCrestSprite;
		}

		public Sprite GetHeraldryBackground()
		{
			return Faction.Blueprint.HeraldryBackgroundSprite;
		}

		public float GetBargainMultiplier()
		{
			return 1f;
		}

		public void AddItemToStorage(TradeResource tradeResource, int count)
		{
			if (tradeResource.IsCreature)
			{
				return;
			}
			ResourceInstance resourceToAdd = new ResourceInstance(tradeResource.Resource, count);
			int num = negotiatorStorage.Add(resourceToAdd, count);
			if (num < count)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(62, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\AmbushContext.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trader: Added ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(count);
					messageBuilder.AppendLiteral(" to the storage. There was not enough space.");
				}
				Log.Error(messageBuilder);
			}
		}

		public void RemoveItemFromStorage(TradeResource tradeResource, int count)
		{
			Log.Error("Tried to remove item from Negotiator storage. Negotiators don't offer any resources, this should not happen!", "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\AmbushContext.cs");
		}

		public float GetPerResourcePriceMultiplier(TradeResource resource)
		{
			return TraderUtils.GetPerResourcePriceMultiplier(NegotiatorTraderType, resource, GetTraderVillagePlace(), Faction, useMapTypeModifiers: false) * GetExtortionResourcePriceMultiplier(resource);
		}

		public bool CanTradeResource(TradeResource resource)
		{
			List<string> list = ListPool<string>.Get();
			list.Add("dont_trade_neutral");
			bool num = TraderUtils.CanTradeResource(NegotiatorTraderType, resource, GetTraderVillagePlace(), Faction, useMapTypeModifiers: true, list);
			ListPool<string>.Return(list);
			if (num)
			{
				return AcceptsResource(resource.Resource);
			}
			return false;
		}

		private bool AcceptsResource(Resource resource)
		{
			foreach (TraderStockModifier extortionStockModifier in Faction.Blueprint.ExtortionStockModifiers)
			{
				if (!extortionStockModifier.CanTradeResource(resource))
				{
					return false;
				}
			}
			return true;
		}

		private float GetExtortionResourcePriceMultiplier(TradeResource resource)
		{
			float num = 1f;
			foreach (TraderStockModifier extortionStockModifier in Faction.Blueprint.ExtortionStockModifiers)
			{
				num *= extortionStockModifier.GetPriceModifier(resource);
			}
			return num;
		}

		public VillagePlace GetTraderVillagePlace()
		{
			return null;
		}

		public bool IsTraderFriendly()
		{
			return false;
		}

		public int GetStorageCapacity()
		{
			return NegotiatorTraderType.StorageCapacity;
		}

		public float GetMinimumNutrition()
		{
			return 0f;
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			return Faction.GetPrisonerTradeStatus(creatureBase);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("mapPlaceReference", MapPlaceReference);
			serializer.Write("faction", Faction);
			serializer.Write("minutesExpireAmbushWait", MinutesExpireAmbushWait);
			serializer.Write("valueDemanded", ValueDemanded);
			serializer.Write("caravanId", CaravanId);
		}

		public AmbushContext(FVDeserializer deserializer)
		{
			MapPlaceReference = deserializer.ReadObject<WorldMapMarkerReference>("mapPlaceReference");
			Faction = deserializer.ReadObject<FactionInstance>("faction");
			MinutesExpireAmbushWait = deserializer.ReadLong("minutesExpireAmbushWait", 0L);
			ValueDemanded = deserializer.ReadFloat("valueDemanded");
			negotiatorStorage = new Storage(new StorageBase(400, ignoreWeigth: true, infinite: true));
			caravanId = deserializer.ReadInt("caravanId");
		}
	}
}
