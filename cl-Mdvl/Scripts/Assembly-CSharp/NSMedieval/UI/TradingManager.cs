using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.UI
{
	public class TradingManager : MonoSingleton<TradingManager>
	{
		public delegate void TradeBalanceChangeDelegate(float toBuyBalance, float toSellBalance, bool isBalanceOk, float playerStorageWeight, float playerNutrition, float traderWeight);

		public delegate void TradeAppliedDelegate(ITrader playerTrader, ITrader otherTrader, float totalValueTraded, bool wasGiftingOnly);

		public const float BuyMultiplierTrader = 0.6f;

		public const float SellMultiplierTrader = 1.4f;

		public const float BuyMultiplierCaravan = 0.8f;

		public const float SellMultiplierCaravan = 1.2f;

		private const long RegenerateStorageHours = 96L;

		private const float SpeechcraftXpPerWealthPoint = 3f;

		private TradingSettings tradingSettings;

		private bool isTradingSettingsInit;

		[SerializeField]
		private TradingPanelView tradingPanelView;

		[SerializeField]
		private ExtortionPanelView extortionPanelView;

		private List<ResourcePileInstance> piles;

		private readonly List<ResourcePileInstance> equipment = new List<ResourcePileInstance>();

		private readonly List<ResourcePileInstance> structures = new List<ResourcePileInstance>();

		private readonly Dictionary<Resource, int> resourcesCount = new Dictionary<Resource, int>();

		private readonly HashSet<Tuple<TradeResource, TradeResource, int>> tradeGoods = new HashSet<Tuple<TradeResource, TradeResource, int>>();

		private ITrader player;

		private ITrader trader;

		private float toBuyBalance;

		private float toSellBalance;

		private float toSellBalanceNoPrisoners;

		private bool isBalanceOk;

		private List<TradeResource> playerResources;

		private List<TradeResource> traderResources;

		private bool ignorePlayerSellMultiplier;

		public float ToSellBalance => toSellBalance;

		public float ToBuyBalance => toBuyBalance;

		public float Balance => toBuyBalance - toSellBalance;

		public bool IsBalanceOk => isBalanceOk;

		public HashSet<Tuple<TradeResource, TradeResource, int>> TradeGoods => tradeGoods;

		public TradingSettings TradingSettings
		{
			get
			{
				if (!isTradingSettingsInit)
				{
					isTradingSettingsInit = true;
					tradingSettings = Repository<TradingSettingsData, TradingSettings>.Instance.GetData<TradingSettings>();
				}
				return tradingSettings;
			}
		}

		public ExtortionModeData ExtortionModeData { get; } = new ExtortionModeData();

		public event TradeBalanceChangeDelegate BalanceChangedEvent;

		public event TradeAppliedDelegate TradeAppliedEvent;

		public event Action ShowTradingAction;

		public event Action ShowExtortingAction;

		public static IEnumerable<ResourceInstance> GetResources(bool mustBeStored = true, IList<Vec3Int> mustBeReachableFromAtLeastOne = null)
		{
			return GetResourcesInternal(mustBeStored, mustBeReachableFromAtLeastOne);
		}

		public BodyType GetTraderBodyType()
		{
			if (!(trader is HumanoidBehaviour humanoidBehaviour))
			{
				return BodyType.None;
			}
			return humanoidBehaviour.Humanoid.Info.BodyType;
		}

		private static IEnumerable<ResourceInstance> GetResourcesInternal(bool mustBeStored = true, IList<Vec3Int> mustBeReachableFromAtLeastOne = null)
		{
			WalkableModel testAgentWalkableDoors = Repository<WalkableModelRepository, WalkableModel>.Instance.GetTestAgentWalkableDoors();
			using PooledList<ResourceInstance> resourceInstances = ListPool<ResourceInstance>.GetJanitor();
			using PooledList<CarcassResourceInstance> carcasses = ListPool<CarcassResourceInstance>.GetJanitor();
			foreach (WorldObject worldObject in VillageManager.ActiveVillage.Map.GetWorldObjects(GridDataType.ResourcePile))
			{
				if (worldObject.HasDisposed || !(worldObject is ResourcePileInstance resourcePileInstance) || worldObject is HumanCarcassPileInstance || (mustBeStored && !resourcePileInstance.IsStoredOnStockpile()))
				{
					continue;
				}
				if (mustBeReachableFromAtLeastOne != null)
				{
					bool flag = false;
					foreach (Vec3Int item2 in mustBeReachableFromAtLeastOne)
					{
						if (PathfinderUtil.IsPathPossible(testAgentWalkableDoors, item2, resourcePileInstance))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
				}
				ResourceInstance storedResource = ((ResourcePileInstance)worldObject).GetStoredResource();
				if (storedResource is CarcassResourceInstance item)
				{
					carcasses.Add(item);
				}
				else
				{
					resourceInstances.Add(storedResource);
				}
			}
			using PooledList<ResourceInstance> result = ListPool<ResourceInstance>.GetJanitor();
			foreach (CarcassResourceInstance item3 in carcasses)
			{
				if (item3.Owner is HumanoidInstance humanoidInstance && humanoidInstance.IsWorker())
				{
					result.Add(item3);
				}
			}
			PooledDictionary<Resource, int> countByRes = DictionaryPool<Resource, int>.GetJanitor();
			try
			{
				PooledDictionary<Resource, float> totalHealth = DictionaryPool<Resource, float>.GetJanitor();
				try
				{
					PooledDictionary<Resource, float> totalFreshness = DictionaryPool<Resource, float>.GetJanitor();
					try
					{
						PooledDictionary<Resource, float> totalFermentation = DictionaryPool<Resource, float>.GetJanitor();
						try
						{
							foreach (ResourceInstance item4 in resourceInstances)
							{
								if (item4 == null || item4.Blueprint == null || item4.HasDisposed)
								{
									continue;
								}
								if (ResourceUtils.IsItem(item4.Blueprint))
								{
									result.Add(item4);
									continue;
								}
								if (!countByRes.TryAdd(item4.Blueprint, item4.Amount))
								{
									countByRes[item4.Blueprint] += item4.Amount;
								}
								float num = (float)item4.Amount * item4.GetStatValue(StatType.Health);
								float num2 = (float)item4.Amount * item4.GetStatValue(StatType.Freshness);
								float num3 = (float)item4.Amount * item4.GetStatValue(StatType.Fermentation);
								if (!totalHealth.TryAdd(item4.Blueprint, num))
								{
									totalHealth[item4.Blueprint] += num;
								}
								if (!totalFreshness.TryAdd(item4.Blueprint, num2))
								{
									totalFreshness[item4.Blueprint] += num2;
								}
								if (!totalFermentation.TryAdd(item4.Blueprint, num3))
								{
									totalFermentation[item4.Blueprint] += num3;
								}
							}
							using PooledHashSet<ResourceInstance> toDispose = HashSetPool<ResourceInstance>.GetJanitor();
							foreach (KeyValuePair<Resource, int> item5 in countByRes)
							{
								ResourceInstance resourceInstance = new ResourceInstance(item5.Key, item5.Value);
								float current6 = totalHealth[item5.Key] / (float)item5.Value;
								resourceInstance.GetStat(StatType.Health).SetCurrent(current6);
								float current7 = totalFreshness[item5.Key] / (float)item5.Value;
								resourceInstance.GetStat(StatType.Freshness).SetCurrent(current7);
								float current8 = totalFermentation[item5.Key] / (float)item5.Value;
								resourceInstance.GetStat(StatType.Fermentation).SetCurrent(current8);
								result.Add(resourceInstance);
								toDispose.Add(resourceInstance);
							}
							foreach (ResourceInstance item6 in result)
							{
								yield return item6;
							}
							foreach (ResourceInstance item7 in toDispose)
							{
								item7?.Dispose();
							}
						}
						finally
						{
							((IDisposable)totalFermentation/*cast due to .constrained prefix*/).Dispose();
						}
					}
					finally
					{
						((IDisposable)totalFreshness/*cast due to .constrained prefix*/).Dispose();
					}
				}
				finally
				{
					((IDisposable)totalHealth/*cast due to .constrained prefix*/).Dispose();
				}
			}
			finally
			{
				((IDisposable)countByRes/*cast due to .constrained prefix*/).Dispose();
			}
		}

		public List<TradeResource> GetAllTradeResources()
		{
			List<TradeResource> list = new List<TradeResource>();
			GatherPiles();
			foreach (ResourcePileInstance item in equipment)
			{
				if (item?.Stats?.GetStat(StatType.Health) != null)
				{
					list.Add(new TradeResource(item));
				}
			}
			Dictionary<Resource, int> dictionary = new Dictionary<Resource, int>();
			foreach (ResourcePileInstance structure in structures)
			{
				if (structure != null && !(structure.Blueprint == null) && structure.Stats?.GetStat(StatType.Health) != null && !dictionary.TryAdd(structure.Blueprint, 1))
				{
					dictionary[structure.Blueprint]++;
				}
			}
			foreach (Resource key in dictionary.Keys)
			{
				list.Add(new TradeResource(key, dictionary[key]));
			}
			foreach (Resource key2 in resourcesCount.Keys)
			{
				if (!(key2 == null) && !key2.UniqueResource)
				{
					int count = resourcesCount[key2];
					list.Add(new TradeResource(key2, count));
				}
			}
			return list;
		}

		public void SetPlayerResources(List<TradeResource> resources)
		{
			playerResources = resources;
		}

		public void SetTraderResources(List<TradeResource> resources)
		{
			traderResources = resources;
		}

		public void OpenTradingMenu(ITrader playerTrader, ITrader otherTrader)
		{
			ignorePlayerSellMultiplier = false;
			tradeGoods.Clear();
			player = playerTrader;
			trader = otherTrader;
			tradingPanelView.Show(playerTrader, otherTrader);
			this.ShowTradingAction?.Invoke();
		}

		public void OpenExtortionMenu(ITrader playerTrader, ITrader otherTrader, float valueDemanded)
		{
			ignorePlayerSellMultiplier = false;
			tradeGoods.Clear();
			player = playerTrader;
			trader = otherTrader;
			ExtortionModeData.ValueDemanded = valueDemanded;
			extortionPanelView.BarLabelTextKey = "extortion_demanding";
			extortionPanelView.GiveTextKey = "extortion_give";
			extortionPanelView.AskingTitleTextKey = "extortion_demand_title";
			extortionPanelView.AskingDescTextKey = "extortion_demand_desc";
			extortionPanelView.WontTakeTextKey = "extortion_wont_take";
			extortionPanelView.AreYouSureTextKey = "extortion_are_you_sure";
			extortionPanelView.CantContinueTextKey = "extortion_message_cant_continue";
			extortionPanelView.OverCarryWeightTextKey = "negotiator_message_mass";
			extortionPanelView.AnimalLockedTextKey = "extortion_animal_locked";
			extortionPanelView.Show(playerTrader, otherTrader);
			this.ShowExtortingAction?.Invoke();
		}

		public void CloseExtortionMenu()
		{
			extortionPanelView.Hide();
		}

		public void OpenBeggarMenu(ITrader playerTrader, ITrader otherTrader, float valueDemanded)
		{
			ignorePlayerSellMultiplier = true;
			tradeGoods.Clear();
			player = playerTrader;
			trader = otherTrader;
			ExtortionModeData.ValueDemanded = valueDemanded;
			extortionPanelView.BarLabelTextKey = "beggar_asking";
			extortionPanelView.GiveTextKey = "beggar_give";
			extortionPanelView.AskingTitleTextKey = "beggar_ask_title";
			extortionPanelView.AskingDescTextKey = "beggar_ask_desc";
			extortionPanelView.WontTakeTextKey = "beggar_wont_take";
			extortionPanelView.AreYouSureTextKey = "beggar_are_you_sure";
			extortionPanelView.CantContinueTextKey = "beggar_message_cant_continue";
			extortionPanelView.OverCarryWeightTextKey = "beggar_message_mass";
			extortionPanelView.Show(playerTrader, otherTrader);
			this.ShowExtortingAction?.Invoke();
		}

		public void SetBuySellAmount(TradeResource playerResource, TradeResource traderResource, int tradeValue)
		{
			Tuple<TradeResource, TradeResource, int> tuple = tradeGoods.FirstOrDefault((Tuple<TradeResource, TradeResource, int> item) => item.Item1 == playerResource && item.Item2 == traderResource);
			if (tuple != null)
			{
				tradeGoods.Remove(tuple);
			}
			if (tradeValue == 0)
			{
				CalculateBalance();
				return;
			}
			tradeGoods.Add(new Tuple<TradeResource, TradeResource, int>(playerResource, traderResource, tradeValue));
			CalculateBalance();
		}

		public float GetBuyPrice(TradeResource resource)
		{
			if (resource.ConstantWealthPoints)
			{
				return resource.WealthPoints;
			}
			return resource.WealthPoints * trader.GetSellMultiplier() * player.GetBuyMultiplier() * player.GetPerResourcePriceMultiplier(resource) * GetGlobalTraderMultiplier(resource);
		}

		public float GetTradeDealMultiplier()
		{
			if (trader.Faction == null)
			{
				return 1f;
			}
			return trader.Faction.TradeDealMultiplier;
		}

		public float GetSellPriceRes(TradeResource resource)
		{
			if (resource.ConstantWealthPoints)
			{
				return resource.WealthPoints;
			}
			float num = resource.WealthPoints * trader.GetBuyMultiplier() * player.GetPerResourcePriceMultiplier(resource) * GetGlobalTraderMultiplier(resource);
			if (!ignorePlayerSellMultiplier)
			{
				num *= player.GetSellMultiplier();
			}
			return num;
		}

		public FloatRange GetTraderMultipliers()
		{
			return new FloatRange(trader.GetBuyMultiplier(), trader.GetSellMultiplier());
		}

		public FloatRange GetPlayerMultipliers()
		{
			return new FloatRange(player.GetBuyMultiplier(), player.GetSellMultiplier());
		}

		public float GetGlobalTraderMultiplier(TradeResource resource)
		{
			return trader.GetPerResourcePriceMultiplier(resource);
		}

		public float GetSellPrice(TradeResource tradeResource)
		{
			float num = GetSellPriceRes(tradeResource);
			if (tradeResource.IsItem)
			{
				num *= tradeResource.Health;
			}
			return num;
		}

		public void ApplyTrade(float maxXP = float.MaxValue)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			int num4 = 0;
			foreach (Tuple<TradeResource, TradeResource, int> tradeGood in tradeGoods)
			{
				TradeResource item = tradeGood.Item1;
				TradeResource item2 = tradeGood.Item2;
				int item3 = tradeGood.Item3;
				if (item3 > 0)
				{
					num += Mathf.Abs((float)item3 * item2.WealthPoints);
					num2 += 3f * Mathf.Abs((float)item3 * item2.WealthPoints);
					BuyItem(item2, item3);
					num3 += item3;
				}
				if (item3 < 0)
				{
					num += Mathf.Abs((float)item3 * item.WealthPoints);
					num2 += 3f * Mathf.Abs((float)item3 * item.WealthPoints);
					SellItem(item, -item3);
					num4 += Math.Abs(item3);
				}
			}
			FactionInstance faction = trader.Faction;
			float friendlinessPointsToAdd = GetFriendlinessPointsToAdd(faction);
			if (friendlinessPointsToAdd > 0f)
			{
				faction.AddFriendliness(friendlinessPointsToAdd);
			}
			num2 = Mathf.Min(num2, maxXP);
			bool isEnabled;
			if (player is CaravanInstance { TraderHumanoid: { } traderHumanoid })
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trade: ");
					messageBuilder.AppendFormatted(traderHumanoid.Info.GetFullName());
					messageBuilder.AppendLiteral(" gains ");
					messageBuilder.AppendFormatted(num2);
					messageBuilder.AppendLiteral(" speechcraft XP.");
				}
				Log.Info(messageBuilder);
				traderHumanoid.AddExperience(SkillType.Speechcraft, num2, isSilent: true);
			}
			if (player is WorkerBehaviour { Humanoid: var humanoid })
			{
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trade: ");
					messageBuilder.AppendFormatted(humanoid.Info.GetFullName());
					messageBuilder.AppendLiteral(" gains ");
					messageBuilder.AppendFormatted(num2);
					messageBuilder.AppendLiteral(" speechcraft XP.");
				}
				Log.Info(messageBuilder);
				humanoid.AddExperience(SkillType.Speechcraft, num2);
			}
			bool wasGiftingOnly = num3 <= 0 && num4 > 0;
			this.TradeAppliedEvent?.Invoke(player, trader, num, wasGiftingOnly);
		}

		public static void InitTrader(HumanoidInstance humanoidInstance, TraderType traderType, out List<CreatureBase> addedCreatures, GameEventInstance fromEvent)
		{
			addedCreatures = new List<CreatureBase>();
			bool isEnabled;
			if (!humanoidInstance.IsTrader())
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(89, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Tried to InitTrader for ");
					messageBuilder.AppendFormatted(humanoidInstance);
					messageBuilder.AppendLiteral(", but they are not a trader - the trader behaviour must be active");
				}
				Log.Error(messageBuilder);
				return;
			}
			TraderBehaviour traderBehaviour = humanoidInstance.TraderBehaviour;
			traderBehaviour.InitTrader(traderType);
			traderType.GenerateResourceInstances(traderBehaviour.GetTraderVillagePlace(), traderBehaviour.Faction, useMapTypeModifiers: false, out var resources, out var animals, out var addPrisonersByFaction);
			foreach (ResourceInstance item in resources)
			{
				int t = humanoidInstance.Storage.Add(item, item.Amount);
				FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(71, 6, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Add ");
					messageBuilder2.AppendFormatted(ResourceUtils.GetLocalizedResourceName(item.Blueprint));
					messageBuilder2.AppendLiteral(": added ");
					messageBuilder2.AppendFormatted(t);
					messageBuilder2.AppendLiteral(" of ");
					messageBuilder2.AppendFormatted(item.Amount);
					messageBuilder2.AppendLiteral(" to storage. Space left: ");
					messageBuilder2.AppendFormatted(humanoidInstance.Storage.GetFreeSpace());
					messageBuilder2.AppendLiteral(". Res weight: ");
					messageBuilder2.AppendFormatted(humanoidInstance.Storage.GetResourceWeight());
					messageBuilder2.AppendLiteral(". Max storable: ");
					messageBuilder2.AppendFormatted(humanoidInstance.Storage.GetMaximumStorableCount(item.Blueprint));
				}
				Log.Info(messageBuilder2);
			}
			System.Random random = new System.Random();
			foreach (KeyValuePair<Animal, TraderStockItem> item2 in animals)
			{
				Animal key = item2.Key;
				TraderStockItem value = item2.Value;
				BodyType bodyType = ((!(random.NextDouble() < 0.5)) ? BodyType.Male : BodyType.Female);
				int lifePhaseIndex = Mathf.FloorToInt((float)random.NextDouble() * (float)key.LifePhases.Count);
				float lifePhasePercent = Mathf.Pow(0.5f * (float)random.NextDouble(), 2f);
				AnimalInstance animalInstance = MonoSingleton<AnimalManager>.Instance.SpawnAnimal(key.GetID(), humanoidInstance.GetPosition(), bodyType, lifePhaseIndex, lifePhasePercent, isInIncognitoMode: false, AnimalType.DomesticNpc, humanoidInstance, humanoidInstance);
				animalInstance.TraderStockItem = value;
				addedCreatures.Add(animalInstance);
			}
			FVLogTraceInterpolationHandler messageBuilder3 = new FVLogTraceInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
			if (isEnabled)
			{
				messageBuilder3.AppendLiteral("Instantiating ");
				messageBuilder3.AppendFormatted(addPrisonersByFaction.Count);
				messageBuilder3.AppendLiteral(" prisoners");
			}
			Log.Trace(messageBuilder3);
			foreach (string factionId in addPrisonersByFaction)
			{
				VillagePlace villagePlace;
				if (factionId == null)
				{
					villagePlace = GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.PickRandom();
				}
				else
				{
					if (!GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaceExistsForFaction(factionId))
					{
						FVLogInfoInterpolationHandler messageBuilder2 = new FVLogInfoInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("*** No village with faction '");
							messageBuilder2.AppendFormatted(factionId);
							messageBuilder2.AppendLiteral("'.");
						}
						Log.Info(messageBuilder2);
						continue;
					}
					villagePlace = GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.PickRandom((VillagePlace village) => factionId.Equals(village.FactionInstance.BlueprintId));
					if (!GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaceExistsForFaction(factionId))
					{
						messageBuilder3 = new FVLogTraceInterpolationHandler(25, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
						if (isEnabled)
						{
							messageBuilder3.AppendLiteral("No village of faction '");
							messageBuilder3.AppendFormatted(factionId);
							messageBuilder3.AppendLiteral("'.");
						}
						Log.Trace(messageBuilder3);
						continue;
					}
				}
				if (villagePlace != null)
				{
					HumanoidInstance humanoidInstance2 = MonoSingleton<NPCManager>.Instance.SpawnPrisoner("general_prisoner", villagePlace.GetRandomBodyType(), Vector3.zero, villagePlace, humanoidInstance, null, fromEvent);
					addedCreatures.Add(humanoidInstance2);
					humanoidInstance2.PrisonerBehaviour.ShacklePrisoner(isShackled: true);
					humanoidInstance2.PrisonerBehaviour.EquipShackles();
					messageBuilder3 = new FVLogTraceInterpolationHandler(62, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
					if (isEnabled)
					{
						messageBuilder3.AppendLiteral("Successfully initialized prisoner '");
						messageBuilder3.AppendFormatted(humanoidInstance2.Info.GetFullName());
						messageBuilder3.AppendLiteral("', from faction ");
						messageBuilder3.AppendFormatted(humanoidInstance2.Faction?.BlueprintId);
						messageBuilder3.AppendLiteral(", village ");
						messageBuilder3.AppendFormatted(humanoidInstance2.OriginVillage.Value.Name);
						messageBuilder3.AppendLiteral(".");
					}
					Log.Trace(messageBuilder3);
				}
			}
		}

		public void RemoveTradeResourceFromMap(TradeResource resourceToRemove, int count)
		{
			int num = count;
			bool isItem = resourceToRemove.IsItem;
			foreach (ResourcePileInstance pile in piles)
			{
				if (!(pile.Blueprint != null) || !pile.Blueprint.Equals(resourceToRemove.Resource))
				{
					continue;
				}
				StatInstance stat = pile.GetStat(StatType.Health);
				if (stat != null && (!isItem || !(Math.Abs(stat.GetNormalizedPercentage() - resourceToRemove.Health) > 1E-06f)) && !pile.GetStorage().IsEmpty())
				{
					num -= pile.GetStorage().Consume(resourceToRemove.Resource, num);
					if (num <= 0)
					{
						break;
					}
				}
			}
			if (num > 0)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(68, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SellItem: Didn't remove the needed amount of resource ");
					messageBuilder.AppendFormatted(resourceToRemove.Resource);
					messageBuilder.AppendLiteral(". Remaining: ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(".");
				}
				Log.Info(messageBuilder);
			}
		}

		public List<TraderStockModifier> GetFactionMapSeasonModifiers(VillagePlace traderOriginVillage, FactionInstance traderFaction, bool useMapTypeModifiers)
		{
			List<TraderStockModifier> list = new List<TraderStockModifier>();
			if (useMapTypeModifiers && traderOriginVillage != null)
			{
				List<TraderStockModifier> traderStockModifiersForMapType = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Settings.GetTraderStockModifiersForMapType(traderOriginVillage.MapType);
				if (traderStockModifiersForMapType != null && traderStockModifiersForMapType.Count > 0)
				{
					list.AddRange(traderStockModifiersForMapType);
				}
			}
			List<TraderStockModifier> stockModifiers = traderFaction.Blueprint.StockModifiers;
			if (stockModifiers != null && stockModifiers.Count > 0)
			{
				list.AddRange(stockModifiers);
			}
			List<TraderStockModifier> list2 = GlobalSaveController.CurrentVillageData.DateAndTime.GetStockModifiersForCurrentSeason()?.StockModifiers;
			if (list2 != null && list2.Count > 0)
			{
				list.AddRange(list2);
			}
			return list;
		}

		public void RemoveStorageResourcesFromMap(Storage storage)
		{
			List<ResourcePileInstance> pilesFromStockpilesAndShelves = ResourcePileUtils.GetPilesFromStockpilesAndShelves();
			foreach (ResourceInstance resource in storage.Resources)
			{
				int num = resource.Amount;
				Resource blueprint = resource.Blueprint;
				foreach (ResourcePileInstance item in pilesFromStockpilesAndShelves)
				{
					if (item != null && !item.HasDisposed && item.Blueprint.Equals(blueprint))
					{
						int num2 = item.GetStorage().Consume(blueprint, num);
						if (item.GetStorage().IsEmpty())
						{
							item.Dispose();
						}
						num -= num2;
						bool isEnabled;
						FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(43, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Trading\\TradingManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("RemoveStorageResourcesFromMap: Removed ");
							messageBuilder.AppendFormatted(num2);
							messageBuilder.AppendLiteral(" of ");
							messageBuilder.AppendFormatted(blueprint.GetID());
						}
						Log.Info(messageBuilder);
						if (num <= 0)
						{
							break;
						}
					}
				}
			}
		}

		private void Start()
		{
			MonoSingleton<CombatController>.Instance.DamageAgentRemovedEvent += OnDamageAgentRemoved;
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageAgentRemovedEvent -= OnDamageAgentRemoved;
			}
			this.BalanceChangedEvent = null;
			this.TradeAppliedEvent = null;
			this.ShowTradingAction = null;
			this.ShowExtortingAction = null;
			base.OnDestroy();
		}

		private void OnDamageAgentRemoved(IDamageCommonAgent agent)
		{
			if (agent is HumanoidInstance humanoidInstance && humanoidInstance.IsTrader() && humanoidInstance.Faction?.NameLocalized != null && humanoidInstance.Stats.GetStat(StatType.Health).Current > 0f)
			{
				string messageText = MonoSingleton<LocalizationController>.Instance.GetText("trader_left").Replace("<faction_name>", humanoidInstance.Faction.NameLocalized);
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
			}
		}

		private void GatherPiles()
		{
			piles = ResourcePileUtils.GetPilesFromStockpilesAndShelves();
			piles.RemoveWhere((ResourcePileInstance pile) => pile is HumanCarcassPileInstance || pile.Blueprint.GetID().Equals("human_carcass") || pile.Blueprint.GetID().Equals("enemy_carcass"));
			equipment.Clear();
			structures.Clear();
			resourcesCount.Clear();
			foreach (ResourcePileInstance pile in piles)
			{
				if ((pile.Blueprint.Category & ResourceCategory.CtgItem) != ResourceCategory.None)
				{
					equipment.Add(pile);
					continue;
				}
				if ((pile.Blueprint.Category & ResourceCategory.CtgStructure) != ResourceCategory.None)
				{
					structures.Add(pile);
					continue;
				}
				foreach (ResourceInstance resource in pile.GetStorage().Resources)
				{
					Resource blueprint = resource.Blueprint;
					if (!(blueprint == null))
					{
						resourcesCount.TryAdd(blueprint, 0);
						resourcesCount[blueprint] += resource.Amount;
					}
				}
			}
		}

		private void CalculateBalance()
		{
			float num = toBuyBalance - toSellBalance;
			toBuyBalance = 0f;
			toSellBalance = 0f;
			toSellBalanceNoPrisoners = 0f;
			float num2 = traderResources.Sum((TradeResource resource) => (!(resource.Resource != null)) ? 0f : ((float)resource.Count * resource.Weight));
			float num3 = playerResources.Sum((TradeResource resource) => (!(resource.Resource != null)) ? 0f : ((float)resource.Count * resource.Weight));
			float num4 = playerResources.Sum((TradeResource resource) => (!(resource.Resource != null)) ? 0f : ((float)resource.Count * resource.Nutrition));
			foreach (Tuple<TradeResource, TradeResource, int> tradeGood in tradeGoods)
			{
				TradeResource item = tradeGood.Item1;
				TradeResource item2 = tradeGood.Item2;
				TradeResource tradeResource = item ?? item2;
				int item3 = tradeGood.Item3;
				if (item3 > 0)
				{
					toBuyBalance += GetBuyPrice(item2) * (float)item3;
					num3 += Mathf.Abs(tradeResource.Weight * (float)item3);
					num4 += Mathf.Abs(tradeResource.Nutrition * (float)item3);
					num2 -= Mathf.Abs(tradeResource.Weight * (float)item3);
				}
				else if (item3 < 0)
				{
					float sellPrice = GetSellPrice(item);
					toSellBalance += sellPrice * (float)item3;
					if (item == null || !item.IsCaptive())
					{
						toSellBalanceNoPrisoners += sellPrice * (float)item3;
					}
					num3 -= Mathf.Abs(tradeResource.Weight * (float)item3);
					num4 -= Mathf.Abs(tradeResource.Nutrition * (float)item3);
					num2 += Mathf.Abs(tradeResource.Weight * (float)item3);
				}
			}
			toBuyBalance = Mathf.Abs(toBuyBalance);
			toSellBalance = Mathf.Abs(toSellBalance);
			toSellBalanceNoPrisoners = Mathf.Abs(toSellBalanceNoPrisoners);
			float num5 = toBuyBalance - toSellBalance;
			float num6 = (toBuyBalance + toSellBalance) * player.GetBargainMultiplier();
			isBalanceOk = num5 <= num6;
			if (Math.Abs(num5 - num) > 1E-05f)
			{
				this.BalanceChangedEvent?.Invoke(toBuyBalance, toSellBalance, isBalanceOk, num3, num4, num2);
			}
		}

		private float GetFriendlinessPointsToAdd(FactionInstance traderFaction)
		{
			if (toBuyBalance <= 0.01f)
			{
				return toSellBalanceNoPrisoners / TradingSettings.GiftingWealthPointsFriendliness;
			}
			if (traderFaction.IsHostile())
			{
				return 0f;
			}
			return 0.5f * (toSellBalanceNoPrisoners + toBuyBalance) / TradingSettings.TradingWealthPointsFriendliness;
		}

		private void SellItem(TradeResource playerResource, int count)
		{
			trader.AddItemToStorage(playerResource, count);
			player.RemoveItemFromStorage(playerResource, count);
		}

		private void BuyItem(TradeResource traderResource, int count)
		{
			player.AddItemToStorage(traderResource, count);
			trader.RemoveItemFromStorage(traderResource, count);
		}

		public int GetPlayerAdditionalStorageCapacity()
		{
			int num = 0;
			foreach (Tuple<TradeResource, TradeResource, int> tradeGood in tradeGoods)
			{
				TradeResource item = tradeGood.Item2;
				TradeResource item2 = tradeGood.Item1;
				int item3 = tradeGood.Item3;
				if (item3 > 0 && item != null && item.IsCreature)
				{
					num += item3 * item.Creature.CaravanStorageCapacity;
				}
				if (item3 < 0 && item2 != null && item2.IsCreature)
				{
					num += item3 * item2.Creature.CaravanStorageCapacity;
				}
			}
			return num;
		}

		public int GetPlayerAdditionalHumansCount()
		{
			int num = 0;
			foreach (Tuple<TradeResource, TradeResource, int> tradeGood in tradeGoods)
			{
				TradeResource item = tradeGood.Item2;
				TradeResource item2 = tradeGood.Item1;
				int item3 = tradeGood.Item3;
				if (item3 > 0 && item != null && item.Creature is HumanoidInstance)
				{
					num += item3;
				}
				if (item3 < 0 && item2 != null && item2.Creature is HumanoidInstance)
				{
					num += item3;
				}
			}
			return num;
		}

		public bool AllRoomsBreached(bool mustBeStored = true, IEnumerable<IPathfindingAgent> mustBeReachableByAtLeastOne = null)
		{
			return AllResourcesReachable(mustBeStored, mustBeReachableByAtLeastOne);
		}

		public bool AllResourcesReachable(bool mustBeStored = true, IEnumerable<IPathfindingAgent> mustBeReachableByAtLeastOne = null)
		{
			if (mustBeReachableByAtLeastOne == null)
			{
				return false;
			}
			foreach (ResourcePileInstance spawnedPileInstance in MonoSingleton<ResourcePileManager>.Instance.SpawnedPileInstances)
			{
				if (spawnedPileInstance.HasDisposed || spawnedPileInstance is HumanCarcassPileInstance || (mustBeStored && !spawnedPileInstance.IsStoredOnStockpile()))
				{
					continue;
				}
				foreach (IPathfindingAgent item in mustBeReachableByAtLeastOne)
				{
					if (!PathfinderUtil.IsPathPossible(item, spawnedPileInstance))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
