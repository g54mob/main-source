using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Components;
using NSMedieval.Components.Base;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Model.SecondMap;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.Village.Map;
using Repository.Map;
using Unity.Mathematics;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	[FVSerializableKey("WorldMapPlace", "")]
	public abstract class WorldMapPlace : IFVSerializable
	{
		public readonly Storage LootableStorage;

		public readonly HashSet<CreatureBase> LootableCreatures;

		protected string factionBlueprintId;

		protected Vector2Int position;

		protected readonly uint randomSeed;

		private FactionInstance cachedFactionInstance;

		private string mapId;

		private WorldDate cachedDateTime;

		private MapMarkerState markerState;

		private readonly List<(long, MapMarkerState)> scheduledStateChanges;

		private List<string> mandatoryResourceGroups;

		private int mandatoryResourceWealthPoints;

		private string mandatoryResourcesTextKey;

		private FloatRange cachedLootValueEstimate;

		private FloatRange cachedLootWeightEstimate;

		public bool HasDisposed { get; private set; }

		public string MapId
		{
			get
			{
				return mapId;
			}
			set
			{
				mapId = value;
				if (mapId != null)
				{
					CachedMapInfo = Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetByID(MapId);
					if (CachedMapInfo == null)
					{
						throw new Exception("Map with id " + MapId + " not found");
					}
				}
			}
		}

		public MapMarkerState MarkerState
		{
			get
			{
				return markerState;
			}
			set
			{
				if (markerState != value)
				{
					if (markerState == MapMarkerState.Lootable)
					{
						LootableStorage.ClearAll(isSilent: true);
						LootableCreatures.Clear();
					}
					markerState = value;
				}
			}
		}

		public int CaravanId { get; set; }

		public SecondMapSaveInfo CachedMapInfo { get; private set; }

		public bool HasView { get; set; }

		public string Name { get; set; }

		public string MapType { get; set; }

		public bool ShouldShowDisabledTimer { get; set; }

		public virtual FactionInstance FactionInstance
		{
			get
			{
				if (cachedFactionInstance == null)
				{
					cachedFactionInstance = MonoSingleton<WorldMap>.Instance.Data.FactionInstances.FirstOrDefault((FactionInstance faction) => faction.BlueprintId.Equals(factionBlueprintId));
				}
				return cachedFactionInstance;
			}
			set
			{
				factionBlueprintId = value?.BlueprintId;
				cachedFactionInstance = value;
			}
		}

		public Vector2Int Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
				this.OnPositionChanged?.Invoke();
			}
		}

		public abstract string EnterMapLoadingScreenTitle { get; }

		public abstract string EnterMapLoadingScreenDescription { get; }

		public abstract string PreciseEnemyCountInfoLocalized { get; }

		public abstract string BallparkEnemyCountInfoLocalized { get; }

		public SecondMapType SecondMapType => CachedMapInfo?.Type ?? SecondMapType.None;

		protected WorldDate DateTime => cachedDateTime ?? (cachedDateTime = GlobalSaveController.CurrentVillageData.DateAndTime);

		protected long NextStateTransitionTimeMinutesLeft
		{
			get
			{
				if (scheduledStateChanges.Count != 0)
				{
					return scheduledStateChanges[0].Item1 - DateTime.MinutesTotal;
				}
				return -1L;
			}
		}

		public IReadOnlyList<string> MandatoryResourceGroups => mandatoryResourceGroups;

		public int MandatoryResourceWealthPoints => mandatoryResourceWealthPoints;

		public string MandatoryResourcesTextKey => mandatoryResourcesTextKey;

		public bool HasTradeDeal
		{
			get
			{
				if (mandatoryResourceWealthPoints > 0)
				{
					return mandatoryResourceGroups.Count > 0;
				}
				return false;
			}
		}

		public event Action OnPositionChanged;

		protected WorldMapPlace(string mapId)
		{
			LootableStorage = new Storage(new StorageBase(1000, ignoreWeigth: true, infinite: true));
			LootableCreatures = new HashSet<CreatureBase>();
			scheduledStateChanges = new List<(long, MapMarkerState)>();
			MapId = mapId;
			CaravanId = int.MaxValue;
			MarkerState = MapMarkerState.Enterable;
			HasView = true;
			ShouldShowDisabledTimer = true;
			randomSeed = (uint)UnityEngine.Random.Range(1f, 4.2949673E+09f);
		}

		public void SetMandatoryResourceGroups(SortingGroupsWithWealth groups)
		{
			mandatoryResourceGroups = new List<string>(groups.Groups);
			mandatoryResourceWealthPoints = groups.MinimumWealth;
			mandatoryResourcesTextKey = groups.TextKey;
		}

		public bool HasLoot()
		{
			if (LootableCreatures.Count <= 0)
			{
				return !LootableStorage.IsEmpty();
			}
			return true;
		}

		public void ScheduleStateChangeDays(int days, MapMarkerState state)
		{
			ScheduleStateChange(DateTime.DaysToMinutes(days), state);
		}

		public void ScheduleStateChangeHours(int hours, MapMarkerState state)
		{
			ScheduleStateChange(DateTime.HoursToMinutes(hours), state);
		}

		public void ScheduleStateChange(int minutesAfterLast, MapMarkerState state)
		{
			long num;
			if (scheduledStateChanges.Count != 0)
			{
				List<(long, MapMarkerState)> list = scheduledStateChanges;
				num = list[list.Count - 1].Item1;
			}
			else
			{
				num = DateTime.MinutesTotal;
			}
			long num2 = num;
			scheduledStateChanges.Add((num2 + minutesAfterLast, state));
		}

		public void ClearScheduledStateChanges()
		{
			scheduledStateChanges.Clear();
		}

		public void TickScheduledStateChanges()
		{
			while (scheduledStateChanges.Count > 0 && scheduledStateChanges[0].Item1 < DateTime.MinutesTotal)
			{
				MapMarkerState item = scheduledStateChanges[0].Item2;
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(72, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapPlace.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Changing marker state ");
					messageBuilder.AppendFormatted(MarkerState);
					messageBuilder.AppendLiteral(" -> ");
					messageBuilder.AppendFormatted(item);
					messageBuilder.AppendLiteral(" as part of a scheduled state change, marker: ");
					messageBuilder.AppendFormatted(this);
				}
				Log.Info(messageBuilder);
				MarkerState = item;
				scheduledStateChanges.RemoveAt(0);
			}
		}

		public void SetMapInfo(SecondMapSaveInfo map)
		{
			mapId = map.Id;
			CachedMapInfo = map;
		}

		public bool TryGenerateLootEstimate(out FloatRange valueEstimate, out FloatRange weightEstimate)
		{
			if (CachedMapInfo == null || CachedMapInfo.Type != SecondMapType.LootStash)
			{
				valueEstimate = (cachedLootValueEstimate = null);
				weightEstimate = (cachedLootWeightEstimate = null);
				return false;
			}
			if (cachedLootValueEstimate != null && cachedLootWeightEstimate != null)
			{
				valueEstimate = cachedLootValueEstimate;
				weightEstimate = cachedLootWeightEstimate;
				return true;
			}
			List<ResourceInstance> list = GenerateLoot();
			if (list == null || list.Count == 0)
			{
				valueEstimate = null;
				weightEstimate = null;
				return false;
			}
			float num = 0f;
			float num2 = 0f;
			foreach (ResourceInstance item in list)
			{
				num += item.GetWealth();
				num2 += item.Weight;
				item.Dispose();
			}
			Unity.Mathematics.Random random = GenerateRandomGenerator();
			cachedLootValueEstimate = new FloatRange(num * random.NextFloat(0.8f, 0.95f), num * random.NextFloat(1.05f, 1.2f));
			cachedLootWeightEstimate = new FloatRange(num2 * random.NextFloat(0.8f, 0.95f), num2 * random.NextFloat(1.05f, 1.2f));
			valueEstimate = cachedLootValueEstimate;
			weightEstimate = cachedLootWeightEstimate;
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(122, 5, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapPlace.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Generated loot value and weight estimates for place ");
				messageBuilder.AppendFormatted(this);
				messageBuilder.AppendLiteral(", value actual: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(", value estimate: ");
				messageBuilder.AppendFormatted(valueEstimate);
				messageBuilder.AppendLiteral(", weight actual: ");
				messageBuilder.AppendFormatted(num2);
				messageBuilder.AppendLiteral(", weight estimate: ");
				messageBuilder.AppendFormatted(weightEstimate);
			}
			Log.Info(messageBuilder);
			return true;
		}

		public virtual List<ResourceInstance> GenerateLoot()
		{
			return null;
		}

		public virtual void Dispose()
		{
			if (!HasDisposed)
			{
				HasDisposed = true;
				this.OnPositionChanged = null;
			}
		}

		public abstract IWorldMapPlaceReference CreateReference();

		public abstract void GenerateSelectionPanelText(List<string> outLines);

		protected Unity.Mathematics.Random GenerateRandomGenerator()
		{
			Unity.Mathematics.Random result = new Unity.Mathematics.Random(randomSeed);
			result.NextDouble();
			return result;
		}

		protected static void ListTradeDealResources(List<string> lines, WorldMapPlace worldMapPlace)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("trade_deal_resources_needed");
			stringBuilder.Append(text);
			stringBuilder.Replace("<resources>", MonoSingleton<LocalizationController>.Instance.GetText(worldMapPlace.MandatoryResourcesTextKey));
			stringBuilder.Replace("<wealth>", worldMapPlace.MandatoryResourceWealthPoints.ToString());
			lines.Add(stringBuilder.ToString());
		}

		public virtual void Serialize(FVSerializer serializer)
		{
			serializer.Write("name", Name);
			serializer.Write("hasView", HasView);
			serializer.Write("position", position);
			serializer.Write("factionBlueprintId", factionBlueprintId);
			serializer.Write("mapType", MapType);
			serializer.Write("mapId", MapId);
			serializer.Write("caravanId", CaravanId);
			serializer.WriteEnum("markerState", MarkerState);
			serializer.Write("lootableStorage", LootableStorage);
			serializer.Write("lootableCreatures", LootableCreatures);
			serializer.Write("scheduledStateChangesTimes", scheduledStateChanges.Select(((long, MapMarkerState) pair) => pair.Item1).ToList());
			serializer.WriteEnum("scheduledStateChangesStates", (IList<MapMarkerState>)scheduledStateChanges.Select(((long, MapMarkerState) pair) => pair.Item2).ToList());
			serializer.Write("shouldShowDisabledTimer", ShouldShowDisabledTimer);
			serializer.Write("randomSeed", randomSeed);
			serializer.Write("mandatoryResourceGroups", mandatoryResourceGroups);
			serializer.Write("mandatoryResourceWealthPoints", mandatoryResourceWealthPoints);
			serializer.Write("mandatoryResourcesTextKey", mandatoryResourcesTextKey);
		}

		public WorldMapPlace(FVDeserializer deserializer)
		{
			Name = deserializer.ReadString("name");
			HasView = deserializer.ReadBool("hasView", defaultValue: true);
			position = deserializer.ReadVec2Int("position");
			factionBlueprintId = deserializer.ReadString("factionBlueprintId");
			MapType = deserializer.ReadString("mapType");
			MapId = deserializer.ReadString("mapId");
			CaravanId = deserializer.ReadInt("caravanId", int.MaxValue);
			MarkerState = deserializer.ReadEnum("markerState", MapMarkerState.Enterable);
			LootableStorage = deserializer.ReadObject<Storage>("lootableStorage") ?? new Storage(new StorageBase(1000, ignoreWeigth: true, infinite: true));
			LootableCreatures = deserializer.ReadObjectHashSet<CreatureBase>("lootableCreatures") ?? new HashSet<CreatureBase>();
			ShouldShowDisabledTimer = deserializer.ReadBool("shouldShowDisabledTimer", defaultValue: true);
			mandatoryResourceGroups = deserializer.ReadStringList("mandatoryResourceGroups");
			mandatoryResourceWealthPoints = deserializer.ReadInt("mandatoryResourceWealthPoints");
			mandatoryResourcesTextKey = deserializer.ReadString("mandatoryResourcesTextKey");
			List<long> list = deserializer.ReadLongList("scheduledStateChangesTimes");
			if (list == null && MarkerState == MapMarkerState.Disabled)
			{
				MarkerState = MapMarkerState.Enterable;
			}
			if (list == null)
			{
				list = new List<long>();
			}
			List<long> list2 = list;
			List<MapMarkerState> list3 = deserializer.ReadEnumList<MapMarkerState>("scheduledStateChangesStates") ?? new List<MapMarkerState>();
			scheduledStateChanges = new List<(long, MapMarkerState)>();
			for (int i = 0; i < list2.Count; i++)
			{
				scheduledStateChanges.Add((list2[i], list3[i]));
			}
			randomSeed = deserializer.ReadUInt("randomSeed", (uint)UnityEngine.Random.Range(1f, 4.2949673E+09f));
		}
	}
}
