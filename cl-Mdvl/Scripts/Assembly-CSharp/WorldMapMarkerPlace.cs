using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.GameEventSystem;
using NSMedieval.Model;
using NSMedieval.Model.SecondMap;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.Village.Map;
using NSMedieval.WorldMap;
using Unity.Mathematics;
using UnityEngine;

[FVSerializableKey("WorldMapMarkerPlace", "")]
public class WorldMapMarkerPlace : WorldMapPlace, IFVSerializable
{
	private string prefabAddress;

	private TimeInterval activeTimeInterval;

	private string linkedObjective;

	private string preciseEnemyCountInfoLocalized;

	private string ballparkEnemyCountInfoLocalized;

	public uint Id { get; private set; }

	public string LootSpawnConfigId { get; }

	public bool HasExpired => activeTimeInterval.HasEnded;

	public TimeInterval TimeInterval => activeTimeInterval;

	public override string EnterMapLoadingScreenTitle => base.CachedMapInfo.LoadingScreenTitle;

	public override string EnterMapLoadingScreenDescription => base.CachedMapInfo.LoadingScreenDescription;

	public string LinkedObjective => linkedObjective;

	public override string PreciseEnemyCountInfoLocalized
	{
		get
		{
			if (preciseEnemyCountInfoLocalized == null)
			{
				if (factionBlueprintId == null)
				{
					preciseEnemyCountInfoLocalized = null;
				}
				else
				{
					List<IEnemyPurchaseUnit> enemiesToSpawn;
					bool flag = MonoSingleton<RaidEnemySelector>.Instance.TryPurchaseEnemies(factionBlueprintId, this, out enemiesToSpawn);
					preciseEnemyCountInfoLocalized = (flag ? UiUtils.BuildPreciseEnemiesListing(enemiesToSpawn) : string.Empty);
				}
			}
			return preciseEnemyCountInfoLocalized;
		}
	}

	public override string BallparkEnemyCountInfoLocalized
	{
		get
		{
			if (ballparkEnemyCountInfoLocalized == null)
			{
				if (factionBlueprintId == null)
				{
					ballparkEnemyCountInfoLocalized = null;
				}
				else
				{
					List<IEnemyPurchaseUnit> enemiesToSpawn;
					bool flag = MonoSingleton<RaidEnemySelector>.Instance.TryPurchaseEnemies(factionBlueprintId, this, out enemiesToSpawn);
					ballparkEnemyCountInfoLocalized = (flag ? UiUtils.BuildBallparkEnemiesListing(enemiesToSpawn, (int)Id) : string.Empty);
				}
			}
			return ballparkEnemyCountInfoLocalized;
		}
	}

	public string PrefabAddress
	{
		get
		{
			return prefabAddress;
		}
		set
		{
			prefabAddress = value;
		}
	}

	public WorldMapMarkerPlace(string name, string mapId, string prefabAddress, Vector2Int gridPosition, int durationMinutes = int.MaxValue, string lootSpawnConfig = null, bool hasView = true, FactionInstance faction = null, string linkedObjective = null)
		: base(mapId)
	{
		if (MonoSingleton<WorldMap>.Instance?.Data?.WorldMapMarkerIdProvider == null)
		{
			throw new Exception("Can't create new world map marker: world map data id provider is null");
		}
		factionBlueprintId = faction?.BlueprintId;
		this.prefabAddress = prefabAddress;
		position = gridPosition;
		activeTimeInterval = TimeInterval.FromNowMinutes(durationMinutes);
		this.linkedObjective = linkedObjective;
		base.Name = name;
		base.HasView = hasView;
		base.MapType = MonoSingleton<WorldMap>.Instance.Data.GetCellType(base.Position).MapType;
		Id = MonoSingleton<WorldMap>.Instance.Data.WorldMapMarkerIdProvider.GetNextId();
		LootSpawnConfigId = lootSpawnConfig;
	}

	public override IWorldMapPlaceReference CreateReference()
	{
		if (base.HasDisposed)
		{
			throw new Exception("Tried to create reference of disposed map marker");
		}
		return new WorldMapMarkerReference(this);
	}

	public override void GenerateSelectionPanelText(List<string> outLines)
	{
		Vector2Int villagePosition = MonoSingleton<WorldMap>.Instance.Data.VillagePosition;
		Vector2Int vector2Int = base.Position;
		int num = (int)(villagePosition - vector2Int).magnitude;
		outLines.Add(base.Name ?? "");
		outLines.Add(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("Distance"), num));
		if (!activeTimeInterval.IsEndless)
		{
			outLines.Add("map_marker_expires_in".ToLocalized() + " " + activeTimeInterval.ToMinutesLeftString());
		}
		FactionInstance factionInstance = FactionInstance;
		if (factionInstance != null)
		{
			outLines.Add(UiUtils.GetFactionLink(factionInstance, factionInstance.NameLocalized));
			outLines.Add(WorldMapUtils.GetFriendlinessText(factionInstance));
			if (factionInstance.GetFriendliness() == FactionFriendliness.Hostile)
			{
				string item = MonoSingleton<LocalizationController>.Instance.GetText("caravan_message_hostile").Replace("<faction_name>", factionInstance.NameLocalized);
				outLines.Add(item);
			}
		}
		switch (base.MarkerState)
		{
		case MapMarkerState.Enterable:
		{
			if (factionInstance != null && factionInstance.IsHostile())
			{
				if (base.CaravanId != int.MaxValue)
				{
					if (!string.IsNullOrEmpty(PreciseEnemyCountInfoLocalized))
					{
						outLines.Add(PreciseEnemyCountInfoLocalized);
					}
				}
				else if (!string.IsNullOrEmpty(BallparkEnemyCountInfoLocalized))
				{
					outLines.Add(BallparkEnemyCountInfoLocalized);
				}
			}
			if (TryGenerateLootEstimate(out var valueEstimate, out var weightEstimate))
			{
				outLines.Add(string.Format("{0} {1:F1}-{2:F1} {3}", "loot_stash_value".ToLocalized(), valueEstimate.Min, valueEstimate.Max, TradeEntryLayoutItemView.ValueSprite));
				outLines.Add(string.Format("{0} {1:F1}-{2:F1} {3}", "loot_stash_weight".ToLocalized(), weightEstimate.Min, weightEstimate.Max, "general_kg".ToLocalized()));
				outLines.Add(string.Empty);
			}
			SecondMapSaveInfo cachedMapInfo = base.CachedMapInfo;
			if ((object)cachedMapInfo != null && cachedMapInfo.Type == SecondMapType.LootStash && base.CachedMapInfo.HasHostiles)
			{
				outLines.Add("loot_stash_hostile".ToLocalized());
			}
			outLines.Add(string.Empty);
			if (base.CaravanId == int.MaxValue)
			{
				string locKey = ((base.SecondMapType == SecondMapType.Attack) ? "point_of_interest_bandit_camp" : ((base.SecondMapType != SecondMapType.LootStash) ? string.Empty : "point_of_interest_stash"));
				outLines.Add(locKey.ToLocalized());
				outLines.Add(string.Empty);
			}
			break;
		}
		case MapMarkerState.Lootable:
			outLines.Add("point_of_interest_explored_info".ToLocalized());
			outLines.Add("point_of_interest_content".ToLocalized());
			WriteLootListing(outLines);
			outLines.Add(string.Empty);
			break;
		case MapMarkerState.Disabled:
			if (base.CachedMapInfo != null && base.CachedMapInfo.Type == SecondMapType.Attack)
			{
				long nextStateTransitionTimeMinutesLeft = base.NextStateTransitionTimeMinutesLeft;
				if (base.ShouldShowDisabledTimer && nextStateTransitionTimeMinutesLeft > 0)
				{
					string timeFormatByMinutes = UiUtils.GetTimeFormatByMinutes(nextStateTransitionTimeMinutesLeft, isDuration: true);
					string text = "point_of_interest_disabled_settlement_info".ToLocalized();
					text = text.Replace("<time>", timeFormatByMinutes);
					outLines.Add(text);
				}
				else
				{
					outLines.Add("point_of_interest_disabled_camp_info".ToLocalized());
				}
			}
			break;
		}
		if (base.HasTradeDeal)
		{
			WorldMapPlace.ListTradeDealResources(outLines, this);
		}
	}

	private void WriteLootListing(List<string> outLines)
	{
		foreach (CreatureBase lootableCreature in LootableCreatures)
		{
			if (lootableCreature is AnimalInstance animalInstance)
			{
				outLines.Add(AnimalUtils.GetTradeName(animalInstance));
			}
			else if (lootableCreature is HumanoidInstance human)
			{
				outLines.Add(HumanoidUtils.GetTradeName(human));
			}
		}
		outLines.Add(string.Empty);
		LootableStorage.WriteContentsListing(outLines);
	}

	public void MarkLootableOrDestroy(int expireAfterDays = 10)
	{
		SetExpireDaysFromNow(expireAfterDays);
		if (HasLoot())
		{
			base.MarkerState = MapMarkerState.Lootable;
		}
		else
		{
			MonoSingleton<WorldMap>.Instance.MarkerManager.DestroyMarker(this);
		}
	}

	public override List<ResourceInstance> GenerateLoot()
	{
		if (LootSpawnConfigId == null)
		{
			Log.Info("No loot will be spawned for this map because LootSpawnConfigId is not set", "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapMarkerPlace.cs");
			return null;
		}
		bool isEnabled;
		FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\WorldMap\\WorldMapMarkerPlace.cs");
		if (isEnabled)
		{
			messageBuilder.AppendLiteral("Fetching loot spawn config '");
			messageBuilder.AppendFormatted(LootSpawnConfigId);
			messageBuilder.AppendLiteral("'");
		}
		Log.Info(messageBuilder);
		SecondMapLootConfig byID = Repository<SecondMapLootConfigRepository, SecondMapLootConfig>.Instance.GetByID(LootSpawnConfigId);
		if (byID == null)
		{
			throw new Exception("Loot spawn config '" + LootSpawnConfigId + "' not found");
		}
		Unity.Mathematics.Random random = GenerateRandomGenerator();
		return byID.GenerateResourceInstances(random);
	}

	public void SetExpireDaysFromNow(int days)
	{
		activeTimeInterval.ResetFromNowDays(days);
	}

	public void SetExpireMinutesFromNow(int minutes)
	{
		activeTimeInterval.ResetFromNowMinutes(minutes);
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}, {4}: {5}, {6}: {7}, {8}: {9}, {10}: {11}", "Name", base.Name, "Position", base.Position, "MapId", base.MapId, "LootSpawnConfigId", LootSpawnConfigId, "prefabAddress", prefabAddress, "HasView", base.HasView);
	}

	public void DebugSetId(uint id)
	{
		Id = id;
	}

	public override void Serialize(FVSerializer serializer)
	{
		base.Serialize(serializer);
		serializer.Write("id", Id);
		serializer.Write("prefabAddress", prefabAddress);
		serializer.Write("lootSpawnConfigId", LootSpawnConfigId);
		serializer.Write("linkedObjective", linkedObjective);
		serializer.Write("activeTimeInterval", activeTimeInterval);
	}

	public WorldMapMarkerPlace(FVDeserializer deserializer)
		: base(deserializer)
	{
		Id = deserializer.ReadUInt("id");
		prefabAddress = deserializer.ReadString("prefabAddress");
		LootSpawnConfigId = deserializer.ReadString("lootSpawnConfigId");
		linkedObjective = deserializer.ReadString("linkedObjective");
		activeTimeInterval = deserializer.ReadObject<TimeInterval>("activeTimeInterval");
		if (position == default(Vector2Int))
		{
			position = deserializer.ReadVec2Int("gridPosition");
		}
	}
}
