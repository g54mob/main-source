using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.Dialogs;
using NSMedieval.Dialogs.Data;
using NSMedieval.Heraldry;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Stockpiles;
using NSMedieval.UI;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using NSMedieval.WorldMap.Caravan;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	[FVSerializableKey("CaravanInstance", "")]
	public class CaravanInstance : ITrader, ISerializationCallbackReceiver, IFVSerializable
	{
		private const float RandomAroundMeetingPoint = 3f;

		private const float TileTravelDurationMinutes = 65f;

		private int uniqueId;

		private IWorldMapPlaceReference destinationPlace;

		private long minutesStart;

		private long minutesFinish;

		private CaravanState caravanState;

		private Vector2 startGridPosition;

		private SerializableVector2Int destinationGridPosition;

		private Vector3 currentPosition;

		private HashSet<HumanoidInstance> workers;

		private HashSet<CreatureBase> creatures;

		private HashSet<int> workerGlobalIndexes;

		private Storage storage;

		private int maxWeightCarried;

		private float destinationPlaceDistance;

		private float distanceTraveled;

		private int initialTripDurationMinutes;

		private float initialTripDurationHours;

		private ResourceInstance resourceConsuming;

		private float nutritionConsumed;

		private string name;

		private HumanoidInstance trader;

		private long minutesGoHome;

		private long creationTime;

		private readonly List<ResourceInstance> tmpResourcesToCarry = new List<ResourceInstance>();

		private readonly List<SimpleResourceCount> resourcesCaravanCameWith = new List<SimpleResourceCount>();

		private float ambushTripPositionNormalized;

		private bool hasAmbushHappened;

		private ICaravanEvent eventContext;

		private AnimationCurve curveX;

		private AnimationCurve curveZ;

		private System.Random random;

		private float workerFoodRequirementPerMinute;

		private WorldDate dateTimeCache;

		private bool dateTimeCached;

		private Dictionary<CreatureBase, Vec3Int> meetingPositions;

		private Dictionary<CreatureBase, Vec3Int> exitPositions;

		private object meetingPositionsLock = new object();

		private bool prisonersCountInit;

		private int prisonersCount;

		public int PrisonersCount
		{
			get
			{
				if (!prisonersCountInit)
				{
					prisonersCountInit = true;
					prisonersCount = creatures.Count((CreatureBase creature) => creature is HumanoidInstance humanoidInstance && humanoidInstance.IsCaptive());
				}
				return prisonersCount;
			}
		}

		public int UniqueId
		{
			get
			{
				if (uniqueId == 0)
				{
					uniqueId = MonoSingleton<UniqueIdManager>.Instance.GetUniqueId(UniqueIdType.Caravan);
				}
				return uniqueId;
			}
		}

		public WorldDate DateTime
		{
			get
			{
				if (!dateTimeCached)
				{
					dateTimeCached = true;
					dateTimeCache = GlobalSaveController.CurrentVillageData.DateAndTime;
				}
				return dateTimeCache;
			}
		}

		public HumanoidInstance TraderHumanoid
		{
			get
			{
				if (trader == null)
				{
					float num = 0f;
					trader = workers.First();
					foreach (HumanoidInstance worker in workers)
					{
						AttributeInstance attributeInstance = worker.Stats.GetAttributeInstance(AttributeType.TradingValue);
						if (attributeInstance != null && attributeInstance.Value > num)
						{
							num = attributeInstance.Value;
							trader = worker;
						}
					}
				}
				return trader;
			}
		}

		public WorldMapPlace DestinationPlace => destinationPlace?.Value;

		public Vector2 StartGridPosition => startGridPosition;

		public Vector2Int DestinationGridPosition
		{
			get
			{
				return destinationGridPosition;
			}
			set
			{
				destinationGridPosition = value;
			}
		}

		public CaravanState CaravanState => caravanState;

		public Vector3 CurrentPosition => currentPosition;

		public HashSet<HumanoidInstance> Workers => workers;

		public HashSet<int> WorkerGlobalIndexes => workerGlobalIndexes;

		public Storage Storage
		{
			get
			{
				return storage;
			}
			set
			{
				storage = value;
			}
		}

		public List<ResourceInstance> TMPResourcesToCarry => tmpResourcesToCarry;

		public List<SimpleResourceCount> ResourcesCaravanCameWith => resourcesCaravanCameWith;

		public IEnumerable<ResourceInstance> AllResources
		{
			get
			{
				foreach (ResourceInstance item in tmpResourcesToCarry)
				{
					yield return item;
				}
				if (storage == null)
				{
					yield break;
				}
				foreach (ResourceInstance resource in storage.Resources)
				{
					yield return resource;
				}
			}
		}

		public float AmbushTripPositionNormalized
		{
			get
			{
				return ambushTripPositionNormalized;
			}
			set
			{
				ambushTripPositionNormalized = value;
			}
		}

		public bool HasAmbushHappened => hasAmbushHappened;

		public string Name
		{
			get
			{
				if (string.IsNullOrEmpty(name))
				{
					if (DestinationPlace == null)
					{
						return MonoSingleton<LocalizationController>.Instance.GetText("caravan");
					}
					return MonoSingleton<LocalizationController>.Instance.GetText("caravan_to", DestinationPlace);
				}
				return name;
			}
		}

		public HashSet<CreatureBase> Creatures
		{
			get
			{
				if (creatures == null)
				{
					creatures = new HashSet<CreatureBase>();
				}
				return creatures;
			}
		}

		public ICaravanEvent EventContext => eventContext;

		public long CreationTime => creationTime;

		public FactionInstance Faction => null;

		public CaravanInstance(WorldMapPlace destinationPlace, bool snapToDestination = false)
		{
			uniqueId = MonoSingleton<UniqueIdManager>.Instance.GetUniqueId(UniqueIdType.Caravan);
			creationTime = DateTime.MinutesTotal;
			workerFoodRequirementPerMinute = 5f / (float)DateTime.MinutesInHour;
			destinationPlaceDistance = (destinationPlace.Position - MonoSingleton<WorldMap>.Instance.Data.VillagePosition).magnitude;
			this.destinationPlace = destinationPlace.CreateReference();
			caravanState = CaravanState.None;
			workers = new HashSet<HumanoidInstance>();
			creatures = new HashSet<CreatureBase>();
			workerGlobalIndexes = new HashSet<int>();
			startGridPosition = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
			destinationGridPosition = this.destinationPlace.Value.Position;
			initialTripDurationMinutes = (int)GetTripDurationMinutes();
			initialTripDurationHours = (float)initialTripDurationMinutes / (float)DateTime.MinutesInHour;
			if (snapToDestination)
			{
				caravanState = CaravanState.Arrived;
				startGridPosition = this.destinationPlace.Value.Position;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(40, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Creating caravan to ");
				messageBuilder.AppendFormatted(destinationPlace.Name);
				messageBuilder.AppendLiteral(", snapToDestination ");
				messageBuilder.AppendFormatted(snapToDestination);
			}
			Log.Info(messageBuilder);
		}

		public void OnLoadedFromSave()
		{
			if (DestinationPlace == null)
			{
				StartTripHome();
			}
			else
			{
				CreateCurves();
			}
			foreach (ResourceInstance resource in storage.Resources)
			{
				if (resource != null && resource.Stats != null && resource.Stats.Owner == null)
				{
					resource.InitAfterLoadPile();
				}
			}
			foreach (CreatureBase creature in creatures)
			{
				if (creature != null && creature.Stats != null && creature.Stats.Owner == null)
				{
					creature.Stats.SetOwner(creature);
					creature.Stats.SetOwnerOnStats();
					creature.Stats.Initialize();
				}
				if (creature == null || creature.GetEquipment() == null)
				{
					continue;
				}
				foreach (EquipmentInstance item in creature.GetEquipment())
				{
					if (!item.HasDisposed)
					{
						item.CheckInitStats();
						item.Reinstantiate();
					}
				}
			}
			eventContext?.OnLoaded();
			if (MonoSingleton<TravelManager>.Instance.JustLeftSecondMap && MonoSingleton<TravelManager>.Instance.CaravanId == UniqueId)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(58, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Caravan ");
					messageBuilder.AppendFormatted(UniqueId);
					messageBuilder.AppendLiteral(" left second map with outcome ");
					messageBuilder.AppendFormatted(MonoSingleton<TravelManager>.Instance.SecondMapLeaveOutcome);
					messageBuilder.AppendLiteral(" (event context is ");
					messageBuilder.AppendFormatted(eventContext?.GetType().Name);
					messageBuilder.AppendLiteral(")");
				}
				Log.Info(messageBuilder);
				eventContext?.OnLeftMap();
			}
		}

		public void StartTrip(Vector2 startGridPosition, Vector2Int destinationGridPosition, bool returnTrip = false)
		{
			this.startGridPosition = startGridPosition;
			this.destinationGridPosition = destinationGridPosition;
			minutesStart = DateTime.MinutesTotal;
			minutesFinish = minutesStart + GetTripDurationMinutes();
			CreateCurves();
			SetCaravanState((!returnTrip) ? CaravanState.Travelling : CaravanState.Returning);
		}

		public void SetEventContext(ICaravanEvent value)
		{
			if (eventContext != value)
			{
				if (eventContext != null && value != null)
				{
					throw new Exception("Can't start new event context while one is already in progress (" + EventContext.GetType().Name + ")");
				}
				eventContext = value;
				MonoSingleton<CaravanController>.Instance.CaravanStateChanged(this, caravanState);
			}
		}

		public void ClearEventContext()
		{
			SetEventContext(null);
		}

		public void InitCaravanStorage()
		{
			maxWeightCarried = CalculateMaxWeight();
			storage = new Storage(new StorageBase(maxWeightCarried, ignoreWeigth: true, infinite: true));
			foreach (ResourceInstance item in tmpResourcesToCarry)
			{
				Storage.Add(item);
			}
			DisposeTmpResourcesToCarry();
		}

		private void DisposeTmpResourcesToCarry()
		{
			foreach (ResourceInstance item in tmpResourcesToCarry)
			{
				item?.Dispose();
			}
			tmpResourcesToCarry.Clear();
		}

		public void ClearTmpResourcesToCarry()
		{
			tmpResourcesToCarry.Clear();
		}

		public void PrisonersCountChanged()
		{
			prisonersCountInit = false;
		}

		public long GetTripDurationMinutes()
		{
			Season season = GlobalSaveController.CurrentVillageData.DateAndTime.Season;
			return (long)((startGridPosition - destinationGridPosition).magnitude * season.CaravanTravelDurationMultiplier * 65f);
		}

		public int GetTripDurationHours()
		{
			return (int)(GetTripDurationMinutes() / DateTime.MinutesInHour);
		}

		public float GetWealth()
		{
			float num = AllResources.Sum((ResourceInstance resourceInstance) => resourceInstance.GetWealth());
			foreach (CreatureBase creature in Creatures)
			{
				num += creature.WealthPoints;
			}
			return num;
		}

		public Vector3 GetDestinationPosition()
		{
			return MonoSingleton<WorldMap>.Instance.ToWorldMapSpace(DestinationGridPosition);
		}

		public float GetProgress(long minutesCurrent, float minutesFract = 0f)
		{
			return ((float)(minutesCurrent - minutesStart) + minutesFract) / (float)(minutesFinish - minutesStart);
		}

		public Vector3 GetPositionByProgress(float progress)
		{
			float num = (float)(minutesFinish - minutesStart) * progress;
			long minutesCurrent = minutesStart + (long)num;
			return GetPosition(minutesCurrent, num % 1f);
		}

		public Vector3 GetPosition(long minutesCurrent, float minutesFract)
		{
			Vector3 vector = MonoSingleton<WorldMap>.Instance.ToWorldMapSpace(DestinationGridPosition);
			Vector3 vector2 = MonoSingleton<WorldMap>.Instance.ToWorldMapSpace(startGridPosition);
			float progress = GetProgress(minutesCurrent);
			float progress2 = GetProgress(minutesCurrent, minutesFract);
			float num = Mathf.Lerp(vector2.x, vector.x, curveX.Evaluate(progress));
			float num2 = Mathf.Lerp(vector2.z, vector.z, curveZ.Evaluate(progress));
			float num3 = Mathf.Lerp(vector2.x, vector.x, curveX.Evaluate(progress2));
			float num4 = Mathf.Lerp(vector2.z, vector.z, curveZ.Evaluate(progress2));
			float heightAt = MonoSingleton<WorldMap>.Instance.GetHeightAt((int)num, (int)num2);
			float heightAt2 = MonoSingleton<WorldMap>.Instance.GetHeightAt((int)num3, (int)num4);
			return new Vector3(Mathf.Lerp(num, num3, minutesFract), Mathf.Lerp(heightAt, heightAt2, minutesFract), Mathf.Lerp(num2, num4, minutesFract));
		}

		public Vector2Int GetCurrentGridPosition()
		{
			return new Vector2Int((int)currentPosition.x, (int)currentPosition.z);
		}

		public void SetResourcesToCarry(List<ResourceInstance> resourcesToCarry)
		{
			if (tmpResourcesToCarry.Count > 0)
			{
				DisposeTmpResourcesToCarry();
			}
			tmpResourcesToCarry.AddRange(resourcesToCarry);
		}

		public bool IsStorageMassOk()
		{
			float num = workers.Sum(delegate(HumanoidInstance worker)
			{
				if (worker != null && !worker.HasDied && !worker.HasDisposed)
				{
					Storage obj = worker.Storage;
					if (obj != null)
					{
						_ = obj.StorageBase;
						if (0 == 0)
						{
							return worker.Storage.StorageBase.Capacity;
						}
					}
				}
				return 0;
			});
			foreach (CreatureBase creature in creatures)
			{
				if (creature != null && !creature.HasDied && !creature.HasDisposed)
				{
					num += (float)creature.CaravanStorageCapacity;
				}
			}
			return AllResources.Sum((ResourceInstance item) => item.Weight) <= num;
		}

		public float GetFoodLevel()
		{
			float num = ((resourceConsuming != null) ? resourceConsuming.Blueprint.Nutrition : 0f);
			num -= nutritionConsumed;
			DietModel workerDietModel = Repository<DietModelRepository, DietModel>.Instance.WorkerDietModel;
			return AllResources.Sum((ResourceInstance resource) => (!(resource.Blueprint == null) && workerDietModel.CanConsume(resource)) ? (resource.Blueprint.Nutrition * (float)resource.Amount) : 0f) + num;
		}

		public bool IsEnoughFood()
		{
			return GetFoodLevel() >= GetMinimumNutrition(Workers.Count + PrisonersCount);
		}

		public bool IsMandatoryResourcesOk()
		{
			WorldMapPlace value = destinationPlace.Value;
			if (value == null || !value.HasTradeDeal)
			{
				return true;
			}
			return GetMandatoryResourcesWealth() > (float)value.MandatoryResourceWealthPoints;
		}

		public float GetMandatoryResourcesWealth()
		{
			WorldMapPlace value = destinationPlace.Value;
			if (value == null || !value.HasTradeDeal)
			{
				return 0f;
			}
			float num = 0f;
			foreach (ResourceInstance allResource in AllResources)
			{
				if (ValidateMandatoryResourceGroup(allResource))
				{
					num += allResource.GetWealth();
				}
			}
			return num;
		}

		public float GetMassCarried()
		{
			return AllResources.Sum((ResourceInstance item) => item.Weight);
		}

		public void OnReturnedHome()
		{
			float magnitude = (startGridPosition - currentPosition.ToVector2XZ()).magnitude;
			AddToDistanceTraveled(magnitude);
			caravanState = CaravanState.Finished;
		}

		public bool TickTime(long minutes, float minuteFract)
		{
			if (caravanState == CaravanState.None)
			{
				return false;
			}
			if (GlobalSaveController.CurrentVillageData.IsSecondMap)
			{
				return false;
			}
			TickFoodConsumption();
			if (CaravanState == CaravanState.Arrived || eventContext != null)
			{
				MonoSingleton<WorldMap>.Instance.MarkerManager.TryForceTick();
				if (CaravanState == CaravanState.Returning)
				{
					return false;
				}
			}
			if (eventContext != null)
			{
				currentPosition = GetPositionByProgress(ambushTripPositionNormalized);
				if (!GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					eventContext.Tick();
				}
				return false;
			}
			UpdateCurrentPosition(minutes, minuteFract);
			bool flag = minutes >= minutesFinish;
			if (flag && caravanState == CaravanState.Travelling)
			{
				SetCaravanState(CaravanState.Arrived);
				SetGoHomeTimer();
				return false;
			}
			if (flag && caravanState == CaravanState.Arrived && minutesGoHome > 0 && MinutesToReturnHome() <= 0)
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_mesage_returning").Replace("<settlement_name>", DestinationPlace.Name));
				StartTripHome();
				return false;
			}
			if (AmbushTripPositionNormalized > 0f && caravanState == CaravanState.Travelling && !HasAmbushHappened && MonoSingleton<CaravanManager>.Instance.CanAmbushHappen() && GetProgress(DateTime.MinutesTotal, DateTime.MinuteFract) > AmbushTripPositionNormalized)
			{
				StartAmbush();
				return false;
			}
			return caravanState == CaravanState.Returning && flag;
		}

		public void StartAmbush()
		{
			if (eventContext != null)
			{
				throw new Exception("Can't start new caravan event context while current one is still in progress (" + eventContext.GetType().Name + ")");
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting ambush for caravan ");
				messageBuilder.AppendFormatted(this);
			}
			Log.Info(messageBuilder);
			hasAmbushHappened = true;
			if (AmbushTripPositionNormalized < 0f)
			{
				ambushTripPositionNormalized = GetProgress(DateTime.MinutesTotal, DateTime.MinuteFract);
			}
			UpdateCurrentPosition(DateTime.MinutesTotal, DateTime.MinuteFract);
			SetEventContext(new AmbushContext(this, DateTime, GetCurrentGridPosition(), (int)GetWealth()));
		}

		public void StartTripHome()
		{
			minutesGoHome = 0L;
			StartTrip(CurrentPosition.ToVector2XZ(), MonoSingleton<WorldMap>.Instance.Data.VillagePosition, returnTrip: true);
		}

		public void ContinueTripToDestination()
		{
			long tripDurationMinutes = GetTripDurationMinutes();
			long num = (long)((float)tripDurationMinutes * AmbushTripPositionNormalized);
			long num2 = tripDurationMinutes - num;
			minutesStart = DateTime.MinutesTotal - num;
			minutesFinish = DateTime.MinutesTotal + num2;
			SetCaravanState(CaravanState.Travelling);
		}

		public long MinutesToReturnHome()
		{
			long num = minutesGoHome - DateTime.MinutesTotal;
			if (num >= 0)
			{
				return num;
			}
			return 0L;
		}

		public void OnBeforeSerialize()
		{
			if (!MonoSingleton<GlobalSaveController>.IsInstantiated() || Workers == null)
			{
				return;
			}
			workerGlobalIndexes.Clear();
			foreach (HumanoidInstance worker in Workers)
			{
				workerGlobalIndexes.Add(worker.UniqueId);
			}
		}

		public void ResetCreaturesOnLoad()
		{
			using PooledHashSet<CreatureBase> pooledHashSet = HashSetPool<CreatureBase>.GetJanitor();
			foreach (CreatureBase creature in creatures)
			{
				if (!creature.HasDied && !creature.HasDisposed)
				{
					HumanoidInstance humanoidInstance = GlobalSaveController.CurrentVillageData.NPCs.FirstOrDefault((HumanoidInstance h) => h.UniqueId == creature.UniqueId);
					if (humanoidInstance != null && !humanoidInstance.HasDied && !humanoidInstance.HasDisposed)
					{
						pooledHashSet.Add(humanoidInstance);
					}
					AnimalInstance animalInstance = GlobalSaveController.CurrentVillageData.Animals.FirstOrDefault((AnimalInstance a) => a.UniqueId == creature.UniqueId);
					if (animalInstance != null && !animalInstance.HasDied && !animalInstance.HasDisposed)
					{
						pooledHashSet.Add(animalInstance);
					}
				}
			}
			creatures.Clear();
			creatures.UnionWith(pooledHashSet);
		}

		public void OnAfterDeserialize()
		{
		}

		private void OnAmbushResolved(AmbushContext.AmbushResolutionType resolutionType)
		{
		}

		public float GetSellMultiplier()
		{
			return TraderHumanoid.Stats.GetAttributeInstance(AttributeType.TradingValue).Value;
		}

		public float GetBuyMultiplier()
		{
			return 1f / TraderHumanoid.Stats.GetAttributeInstance(AttributeType.TradingValue).Value;
		}

		public float GetBargainMultiplier()
		{
			return TraderHumanoid.Stats.GetAttributeInstance(AttributeType.TradingBargain).Value;
		}

		public List<TradeResource> GetResources(ITrader otherTrader)
		{
			List<TradeResource> list = new List<TradeResource>();
			foreach (ResourceInstance resource in Storage.Resources)
			{
				if (resource?.Stats?.GetStat(StatType.Health) != null)
				{
					list.Add(new TradeResource(resource));
				}
			}
			if (creatures != null)
			{
				foreach (CreatureBase creature in creatures)
				{
					TradeForbiddenReason forbidden = TradeForbiddenReason.None;
					if (creature is HumanoidInstance)
					{
						forbidden = otherTrader.GetPrisonerTradeStatus(creature);
					}
					list.Add(new TradeResource(creature, forbidden));
				}
			}
			return list;
		}

		public string GetTraderName()
		{
			return Name;
		}

		public string GetSettlementName()
		{
			return GlobalSaveController.CurrentVillageData.Name;
		}

		public Sprite GetHeraldryCrest()
		{
			return MonoSingleton<HeraldryManager>.Instance.Crest.sprite;
		}

		public Sprite GetHeraldryBackground()
		{
			return MonoSingleton<HeraldryManager>.Instance.Pattern.sprite;
		}

		public void AddItemToStorage(TradeResource tradeResource, int count)
		{
			if (tradeResource.IsCreature)
			{
				Creatures.Add(tradeResource.Creature);
				PrisonersCountChanged();
			}
			else
			{
				ResourceInstance resourceToAdd = new ResourceInstance(tradeResource.Resource, count);
				Storage.Add(resourceToAdd);
			}
		}

		public void RemoveItemFromStorage(TradeResource tradeResource, int count)
		{
			if (tradeResource.IsCreature)
			{
				Creatures.Remove(tradeResource.Creature);
				PrisonersCountChanged();
			}
			else
			{
				Storage.Take(tradeResource.Resource, count);
			}
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
			maxWeightCarried = CalculateMaxWeight();
			return maxWeightCarried;
		}

		public float GetMinimumNutrition()
		{
			return GetMinimumNutrition(Workers.Count + PrisonersCount);
		}

		public float GetMinimumNutrition(int humansCount)
		{
			float num = initialTripDurationHours * 5f;
			if (caravanState == CaravanState.Arrived)
			{
				float num2 = (resourceConsuming?.Blueprint.Nutrition ?? 0f) - nutritionConsumed;
				float num3 = 5f * (float)MinutesToReturnHome() / (float)DateTime.MinutesInHour;
				return (num + num3) * (float)humansCount - num2;
			}
			return (num * 2f + (float)DateTime.HoursInDay * 5f) * (float)humansCount;
		}

		public TradeForbiddenReason GetPrisonerTradeStatus(CreatureBase creatureBase)
		{
			return TradeForbiddenReason.None;
		}

		private void SetGoHomeTimer()
		{
			minutesGoHome = DateTime.MinutesTotal + GetWaitDurationBeforeGoHome();
		}

		public long GetWaitDurationBeforeGoHome()
		{
			return DateTime.MinutesInDay;
		}

		public void FindMeetingPoints()
		{
			List<CreatureBase> list = ListPool<CreatureBase>.Get();
			list.AddRange(Creatures);
			list.AddRange(Workers);
			List<CaravanPostComponentInstance> list2 = ListPool<CaravanPostComponentInstance>.Get();
			lock (meetingPositionsLock)
			{
				meetingPositions = new Dictionary<CreatureBase, Vec3Int>();
			}
			foreach (CreatureBase item in list)
			{
				CaravanPostComponentInstance caravanPostComponentInstance = null;
				foreach (CaravanPostComponentInstance item2 in list2)
				{
					if (PathfinderUtil.IsPathPossible(item, item2))
					{
						caravanPostComponentInstance = item2;
						break;
					}
				}
				if (caravanPostComponentInstance == null)
				{
					caravanPostComponentInstance = CaravanManager.GetNearestCaravanPost(item);
					if (caravanPostComponentInstance != null)
					{
						list2.Add(caravanPostComponentInstance);
					}
				}
				lock (meetingPositionsLock)
				{
					if (meetingPositions.ContainsKey(item))
					{
						continue;
					}
				}
				if (caravanPostComponentInstance == null)
				{
					lock (meetingPositionsLock)
					{
						meetingPositions.TryAdd(item, item.GetGridPosition());
					}
					continue;
				}
				Vec3Int randomPoint = IdlePointManager.GetRandomPoint(item, caravanPostComponentInstance.GridDataPosition, 3f, item.GetHashCode());
				lock (meetingPositionsLock)
				{
					meetingPositions.TryAdd(item, randomPoint);
				}
			}
			ListPool<CreatureBase>.Return(list);
			ListPool<CaravanPostComponentInstance>.Return(list2);
		}

		public void FindExitPoints()
		{
			List<CreatureBase> list = ListPool<CreatureBase>.Get();
			list.AddRange(Creatures);
			list.AddRange(Workers);
			exitPositions = new Dictionary<CreatureBase, Vec3Int>();
			List<MapNode> nodesNearEdge = NPCStartPositionManager.GetNodesNearEdge(8, NPCStartPositionManager.CompareNodeDistanceToEdges, skipUnderwaterNodes: true);
			foreach (CreatureBase item in list)
			{
				if (exitPositions.ContainsKey(item))
				{
					continue;
				}
				Vec3Int value = Vec3Int.zero;
				foreach (Vec3Int value2 in exitPositions.Values)
				{
					if (PathfinderUtil.IsPathPossible(item, value2))
					{
						break;
					}
				}
				if (value.Equals(Vec3Int.zero))
				{
					foreach (MapNode item2 in nodesNearEdge)
					{
						Vec3Int position = item2.Position;
						if (PathfinderUtil.IsPathPossible(item, position))
						{
							value = position;
							break;
						}
					}
				}
				exitPositions.TryAdd(item, value);
			}
			ListPool<CreatureBase>.Return(list);
		}

		public void UpdateCurrentPosition(long minutesCurrent, float minutesFract)
		{
			float progress = GetProgress(minutesCurrent, minutesFract);
			currentPosition = GetPositionByProgress(progress);
		}

		public Vec3Int GetMeetingPosition(CreatureBase creatureBase)
		{
			bool flag = false;
			lock (meetingPositionsLock)
			{
				if (meetingPositions == null)
				{
					meetingPositions = new Dictionary<CreatureBase, Vec3Int>();
				}
				flag = meetingPositions.ContainsKey(creatureBase);
			}
			if (!flag)
			{
				FindMeetingPoints();
				lock (meetingPositionsLock)
				{
					if (!meetingPositions.ContainsKey(creatureBase))
					{
						return creatureBase.GetGridPosition();
					}
				}
			}
			lock (meetingPositionsLock)
			{
				return meetingPositions[creatureBase];
			}
		}

		public Vec3Int GetExitPosition(CreatureBase creatureBase)
		{
			if (exitPositions == null)
			{
				exitPositions = new Dictionary<CreatureBase, Vec3Int>();
			}
			if (!exitPositions.ContainsKey(creatureBase))
			{
				FindExitPoints();
				if (!exitPositions.ContainsKey(creatureBase))
				{
					return creatureBase.GetGridPosition();
				}
			}
			return exitPositions[creatureBase];
		}

		public void SaveResourcesCaravanCameWith()
		{
			resourcesCaravanCameWith.Clear();
			foreach (ResourceInstance item in storage.GetResourcesWithoutLock())
			{
				resourcesCaravanCameWith.Add(new SimpleResourceCount(item));
			}
		}

		public void DropCargo(float losePercent)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Dropping ");
				messageBuilder.AppendFormatted(losePercent * 100f);
				messageBuilder.AppendLiteral("% of cargo, caravan: ");
				messageBuilder.AppendFormatted(this);
			}
			Log.Info(messageBuilder);
			foreach (ResourceInstance resource in Storage.Resources)
			{
				int amount = Mathf.CeilToInt((float)resource.Amount * losePercent);
				resource.Sub(amount);
			}
			using PooledList<CreatureBase> pooledList = Creatures.ToPooledListJanitor();
			pooledList.ShuffleInPlace();
			int num = Mathf.CeilToInt((float)Creatures.Count * losePercent);
			for (int i = 0; i < num; i++)
			{
				Creatures.Remove(pooledList[i]);
			}
		}

		public void SetCaravanState(CaravanState nextCaravanState)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("SetCaravanState: ");
				messageBuilder.AppendFormatted(nextCaravanState);
				messageBuilder.AppendLiteral(", caravan: ");
				messageBuilder.AppendFormatted(UniqueId);
			}
			Log.Info(messageBuilder);
			if (nextCaravanState == CaravanState.Arrived || (nextCaravanState == CaravanState.Returning && caravanState == CaravanState.Travelling))
			{
				float magnitude = (startGridPosition - currentPosition.ToVector2XZ()).magnitude;
				AddToDistanceTraveled(magnitude);
			}
			switch (nextCaravanState)
			{
			case CaravanState.Arrived:
				destinationPlace.Value.CaravanId = UniqueId;
				break;
			case CaravanState.Returning:
				if (destinationPlace?.Value != null)
				{
					destinationPlace.Value.CaravanId = int.MaxValue;
				}
				break;
			}
			caravanState = nextCaravanState;
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				if (caravanState == CaravanState.Arrived)
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("caravan_mesage_arived"));
				}
				MonoSingleton<CaravanController>.Instance.CaravanStateChanged(this, caravanState);
			}
		}

		private int CalculateMaxWeight()
		{
			int num = 0;
			foreach (HumanoidInstance worker in workers)
			{
				num += worker.CaravanStorageCapacity;
			}
			foreach (CreatureBase creature in creatures)
			{
				num += creature.CaravanStorageCapacity;
			}
			return num;
		}

		private void AddToDistanceTraveled(float tripLength)
		{
			distanceTraveled += tripLength;
		}

		private void CreateCurves()
		{
			float num = 0.35f;
			int num2 = 4;
			curveX = new AnimationCurve();
			curveZ = new AnimationCurve();
			random = new System.Random(startGridPosition.GetHashCode());
			for (int i = 0; i < num2; i++)
			{
				float num3 = (float)i / (float)(num2 - 1);
				float t = Mathf.Sin(num3 * MathF.PI);
				float b = num3 + ((float)random.NextDouble() * num - num / 2f);
				float b2 = num3 + ((float)random.NextDouble() * num - num / 2f);
				float value = Mathf.Lerp(num3, b, t);
				float value2 = Mathf.Lerp(num3, b2, t);
				curveX.AddKey(num3, value);
				curveZ.AddKey(num3, value2);
			}
		}

		private void TickFoodConsumption()
		{
			if (resourceConsuming == null)
			{
				DietModel workerDietModel = Repository<DietModelRepository, DietModel>.Instance.WorkerDietModel;
				IEnumerable<ResourceInstance> source = storage.Resources.Where((ResourceInstance resource) => resource.Blueprint.Nutrition > 0f && resource.Amount > 0 && workerDietModel.CanConsume(resource));
				resourceConsuming = source.PickRandom();
				if (resourceConsuming == null)
				{
					Log.Info("No more food to consume.", "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
					return;
				}
				Storage.Consume(resourceConsuming.Blueprint, 1);
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(55, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("(food consumption): took out a ");
					messageBuilder.AppendFormatted(resourceConsuming.BlueprintId);
					messageBuilder.AppendLiteral(" from caravan's storage.");
				}
				Log.Info(messageBuilder);
				MonoSingleton<CaravanController>.Instance.CaravanConsumedFood(this, resourceConsuming.Blueprint, 1);
			}
			nutritionConsumed += (float)(workers.Count + PrisonersCount) * workerFoodRequirementPerMinute;
			if (nutritionConsumed > resourceConsuming.Blueprint.Nutrition)
			{
				nutritionConsumed -= resourceConsuming.Blueprint.Nutrition;
				resourceConsuming = null;
			}
		}

		public void Serialize(FVSerializer serializer)
		{
			OnBeforeSerialize();
			serializer.Write("uniqueId", uniqueId);
			serializer.Write("destinationPlace", destinationPlace);
			serializer.Write("minutesStart", minutesStart);
			serializer.Write("minutesFinish", minutesFinish);
			serializer.WriteEnum("caravanState", caravanState);
			serializer.Write("startGridPosition", startGridPosition);
			serializer.Write("destinationGridPosition", destinationGridPosition);
			serializer.Write("currentPosition", currentPosition);
			serializer.Write("workers", workers);
			serializer.Write("creatures", creatures);
			serializer.Write("workerGlobalIndexes", workerGlobalIndexes);
			serializer.Write("storage", storage);
			serializer.Write("maxWeightCarried", maxWeightCarried);
			serializer.Write("destinationPlaceDistance", destinationPlaceDistance);
			serializer.Write("distanceTraveled", distanceTraveled);
			serializer.Write("initialTripDurationMinutes", initialTripDurationMinutes);
			serializer.Write("initialTripDurationHours", initialTripDurationHours);
			serializer.Write("resourceConsuming", resourceConsuming);
			serializer.Write("nutritionConsumed", nutritionConsumed);
			serializer.Write("name", name);
			serializer.Write("trader", trader);
			serializer.Write("minutesGoHome", minutesGoHome);
			serializer.Write("creationTime", creationTime);
			serializer.Write("tmpResourcesToCarry", tmpResourcesToCarry);
			serializer.Write("resourcesCaravanCameWith", resourcesCaravanCameWith);
			serializer.Write("eventContext", eventContext);
			serializer.Write("ambushTripPositionNormalized", ambushTripPositionNormalized);
			serializer.Write("hasAmbushHappened", hasAmbushHappened);
		}

		public CaravanInstance(FVDeserializer deserializer)
		{
			destinationPlace = deserializer.ReadObject<IWorldMapPlaceReference>("destinationPlace");
			destinationPlaceDistance = deserializer.ReadFloat("destinationPlaceDistance");
			if (destinationPlace == null)
			{
				destinationPlace = deserializer.ReadObject<VillagePlaceReference>("destinationVillage");
				destinationPlaceDistance = deserializer.ReadFloat("destinationVillageDistance");
			}
			uniqueId = deserializer.ReadInt("uniqueId");
			minutesStart = deserializer.ReadLong("minutesStart", 0L);
			minutesFinish = deserializer.ReadLong("minutesFinish", 0L);
			caravanState = deserializer.ReadEnum("caravanState", CaravanState.None);
			startGridPosition = deserializer.ReadVector2("startGridPosition");
			destinationGridPosition = deserializer.ReadVec2Int("destinationGridPosition");
			currentPosition = deserializer.ReadVector3("currentPosition");
			workers = deserializer.ReadObjectHashSet<HumanoidInstance>("workers");
			creatures = deserializer.ReadObjectHashSet<CreatureBase>("creatures");
			workerGlobalIndexes = deserializer.ReadIntHashSet("workerGlobalIndexes");
			storage = deserializer.ReadObject<Storage>("storage");
			maxWeightCarried = deserializer.ReadInt("maxWeightCarried");
			distanceTraveled = deserializer.ReadFloat("distanceTraveled");
			initialTripDurationMinutes = deserializer.ReadInt("initialTripDurationMinutes");
			initialTripDurationHours = deserializer.ReadFloat("initialTripDurationHours");
			resourceConsuming = deserializer.ReadObject<ResourceInstance>("resourceConsuming");
			nutritionConsumed = deserializer.ReadFloat("nutritionConsumed");
			name = deserializer.ReadString("name");
			trader = deserializer.ReadObject<HumanoidInstance>("trader");
			minutesGoHome = deserializer.ReadLong("minutesGoHome", 0L);
			creationTime = deserializer.ReadLong("creationTime", 0L);
			tmpResourcesToCarry = deserializer.ReadObjectList<ResourceInstance>("tmpResourcesToCarry");
			resourcesCaravanCameWith = deserializer.ReadObjectList<SimpleResourceCount>("resourcesCaravanCameWith") ?? new List<SimpleResourceCount>();
			eventContext = deserializer.ReadObject<ICaravanEvent>("eventContext");
			ambushTripPositionNormalized = deserializer.ReadFloat("ambushTripPositionNormalized");
			hasAmbushHappened = deserializer.ReadBool("hasAmbushHappened");
			HashSet<AnimalInstance> hashSet = deserializer.ReadObjectHashSet<AnimalInstance>("animals");
			if (hashSet != null)
			{
				Creatures.UnionWith(hashSet);
			}
		}

		private void MakeTradeDeal()
		{
			float num = DestinationPlace.MandatoryResourceWealthPoints;
			foreach (ResourceInstance resource in Storage.Resources)
			{
				if (!ValidateMandatoryResourceGroup(resource))
				{
					continue;
				}
				float unitWealth = resource.GetUnitWealth();
				int num2 = Math.Min(Mathf.CeilToInt(num / unitWealth), resource.Amount);
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(35, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Removing ");
					messageBuilder.AppendFormatted(num2);
					messageBuilder.AppendLiteral(" of ");
					messageBuilder.AppendFormatted(resource.BlueprintId);
					messageBuilder.AppendLiteral(" from caravan storage.");
				}
				Log.Debug(messageBuilder);
				messageBuilder = new FVLogDebugInterpolationHandler(29, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Subtract ");
					messageBuilder.AppendFormatted((float)num2 * unitWealth);
					messageBuilder.AppendLiteral(" from wealth left (");
					messageBuilder.AppendFormatted(num / (float)DestinationPlace.MandatoryResourceWealthPoints);
					messageBuilder.AppendLiteral(")");
				}
				Log.Debug(messageBuilder);
				num -= (float)num2 * unitWealth;
				if (num2 >= resource.Amount)
				{
					storage.DeleteResource(resource);
					messageBuilder = new FVLogDebugInterpolationHandler(50, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Caravan\\CaravanInstance.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Deleting ");
						messageBuilder.AppendFormatted(resource.BlueprintId);
						messageBuilder.AppendLiteral(" from caravan storage - zero amount left.");
					}
					Log.Debug(messageBuilder);
				}
				else
				{
					resource.Sub(num2);
				}
			}
			StartTripHome();
			MonoSingleton<WorldMap>.Instance.Data.AddToTradeDeals(this, destinationPlace.Value.FactionInstance);
			MonoSingleton<WorldMap>.Instance.MarkerManager.DestroyMarker((WorldMapMarkerPlace)destinationPlace.Value);
		}

		private bool ValidateMandatoryResourceGroup(ResourceInstance resource)
		{
			foreach (string mandatoryResourceGroup in DestinationPlace.MandatoryResourceGroups)
			{
				if (Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.CheckGroup(resource.Blueprint.SortingGroup, mandatoryResourceGroup))
				{
					return true;
				}
			}
			return false;
		}

		public void ShowTradeDealDialog()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("trade_deal_dialog_info");
			stringBuilder.Append(text);
			stringBuilder.Replace("<resources>", MonoSingleton<LocalizationController>.Instance.GetText(destinationPlace.Value.MandatoryResourcesTextKey));
			stringBuilder.Replace("<wealth>", destinationPlace.Value.MandatoryResourceWealthPoints.ToString());
			stringBuilder.Replace("<faction_name>", destinationPlace.Value.FactionInstance.NameLocalized);
			DialogContent dialogContent = new DialogContent
			{
				WindowTitle = MonoSingleton<LocalizationController>.Instance.GetText("trade_deal_dialog_title"),
				ContentTitle = MonoSingleton<LocalizationController>.Instance.GetText("trade_deal_dialog_name"),
				ShowCloseButton = true,
				ContentBodyImagePath = "event_merchant",
				ContentBodyText = stringBuilder.ToString(),
				Options = new List<DialogOption>
				{
					new DialogOption
					{
						Text = MonoSingleton<LocalizationController>.Instance.GetText("general_no")
					},
					new DialogOption
					{
						Text = MonoSingleton<LocalizationController>.Instance.GetText("general_yes"),
						OnSelected = MakeTradeDeal
					}
				}
			};
			MonoSingleton<DialogViewManager>.Instance.OpenDialog(dialogContent);
		}
	}
}
