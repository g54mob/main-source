using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.GameEventSystem;
using NSMedieval.Model.MapNew;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	[FVSerializableKey("Scenario", "")]
	public class Scenario : NSEipix.Base.Model, IFVSerializable
	{
		[Serializable]
		[FVSerializableKey("WorkerConstraints", "")]
		public struct WorkerConstraints : IFVSerializable
		{
			[SerializeField]
			private int numberOfVillagers;

			[SerializeField]
			private int ageMin;

			[SerializeField]
			private int ageMax;

			[SerializeField]
			private int heightMin;

			[SerializeField]
			private int heightMax;

			[SerializeField]
			private int weightMin;

			[SerializeField]
			private int weightMax;

			[SerializeField]
			private int forceBodyType;

			[SerializeField]
			private int forceReligion;

			[SerializeField]
			private List<string> defaultClothes;

			[SerializeField]
			private List<GameEvent.StatSetting> overrideStats;

			[SerializeField]
			private List<SerializableIdValuePair> forcedPerks;

			public int NumberOfVillagers
			{
				get
				{
					return numberOfVillagers;
				}
				set
				{
					numberOfVillagers = value;
				}
			}

			public IntRange AgeRange
			{
				get
				{
					return new IntRange(ageMin, ageMax);
				}
				set
				{
					ageMin = value.Min;
					ageMax = value.Max;
				}
			}

			public IntRange HeightRange
			{
				get
				{
					return new IntRange(heightMin, heightMax);
				}
				set
				{
					heightMin = value.Min;
					heightMax = value.Max;
				}
			}

			public IntRange WeightRange
			{
				get
				{
					return new IntRange(weightMin, weightMax);
				}
				set
				{
					weightMin = value.Min;
					weightMax = value.Max;
				}
			}

			public int ForceBodyType
			{
				get
				{
					return forceBodyType;
				}
				set
				{
					forceBodyType = value;
				}
			}

			public int ForceReligion
			{
				get
				{
					return forceReligion;
				}
				set
				{
					forceReligion = value;
				}
			}

			public List<string> DefaultClothes
			{
				get
				{
					return defaultClothes;
				}
				set
				{
					defaultClothes = value;
				}
			}

			public List<SerializableIdValuePair> ForcedPerks
			{
				get
				{
					return forcedPerks;
				}
				set
				{
					forcedPerks = value;
				}
			}

			public List<GameEvent.StatSetting> OverrideStats
			{
				get
				{
					return overrideStats;
				}
				set
				{
					overrideStats = value;
				}
			}

			public static WorkerConstraints CreateInstance()
			{
				return default(WorkerConstraints);
			}

			public void Serialize(FVSerializer serializer)
			{
				serializer.Write("numberOfVillagers", numberOfVillagers);
				serializer.Write("ageMin", ageMin);
				serializer.Write("ageMax", ageMax);
				serializer.Write("heightMin", heightMin);
				serializer.Write("heightMax", heightMax);
				serializer.Write("weightMin", weightMin);
				serializer.Write("weightMax", weightMax);
				serializer.Write("forceBodyType", forceBodyType);
				serializer.Write("forceReligion", forceReligion);
				serializer.Write("defaultClothes", defaultClothes);
				serializer.Write("overrideStats", overrideStats);
				serializer.Write("forcedPerks", forcedPerks);
			}

			public WorkerConstraints(FVDeserializer deserializer)
			{
				numberOfVillagers = deserializer.ReadInt("numberOfVillagers");
				ageMin = deserializer.ReadInt("ageMin");
				ageMax = deserializer.ReadInt("ageMax");
				heightMin = deserializer.ReadInt("heightMin");
				heightMax = deserializer.ReadInt("heightMax");
				weightMin = deserializer.ReadInt("weightMin");
				weightMax = deserializer.ReadInt("weightMax");
				forceBodyType = deserializer.ReadInt("forceBodyType");
				forceReligion = deserializer.ReadInt("forceReligion");
				defaultClothes = deserializer.ReadStringList("defaultClothes");
				overrideStats = deserializer.ReadObjectList<GameEvent.StatSetting>("overrideStats");
				forcedPerks = deserializer.ReadObjectList<SerializableIdValuePair>("forcedPerks");
			}
		}

		[Serializable]
		public struct FactionFriendlinessOverride
		{
			[SerializeField]
			private string factionTypeId;

			[SerializeField]
			private FloatRange friendlinessRange;

			public string FactionTypeId => factionTypeId;

			public FloatRange FriendlinessRange => friendlinessRange;
		}

		private const int DefaultStartHour = 7;

		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string imageId;

		[SerializeField]
		private string difficulty;

		[SerializeField]
		private int startSeason;

		[SerializeField]
		private int startHour;

		[SerializeField]
		private List<string> startMapTypes;

		[SerializeField]
		private FactionFriendlinessOverride[] factionFriendlinessOverrides;

		[SerializeField]
		private string startEventId;

		[SerializeField]
		private string startingEventScheduleId;

		[SerializeField]
		private SerializableIdValuePair[] startingResources;

		[SerializeField]
		private SerializableIdValuePair[] startingEquipment;

		[SerializeField]
		private SerializableIdValuePair[] startingStructurePiles;

		[SerializeField]
		private ScenarioAnimalData[] startingAnimals;

		[SerializeField]
		private WorkerConstraints villagerConstraints;

		[SerializeField]
		private List<string> technologyUnlocked;

		[SerializeField]
		private string modifiedOnVersion;

		[SerializeField]
		private bool isDefault;

		[SerializeField]
		private SerializableIdValuePair[] gameParameters;

		[SerializeField]
		private List<string> allowedObjectives;

		[NonSerialized]
		private HashSet<string> allowedObjectivesSetCache;

		[NonSerialized]
		private bool allowedObjectivesSetCacheInit;

		public WorkerConstraints VillagerConstraints => villagerConstraints;

		public SerializableIdValuePair[] StartingResources => startingResources ?? new SerializableIdValuePair[0];

		public SerializableIdValuePair[] StartingEquipment => startingEquipment ?? new SerializableIdValuePair[0];

		public SerializableIdValuePair[] StartingStructurePiles => startingStructurePiles ?? new SerializableIdValuePair[0];

		public ScenarioAnimalData[] StartingAnimals => startingAnimals ?? new ScenarioAnimalData[0];

		public List<string> TechnologyUnlocked => technologyUnlocked;

		public int StartSeason => startSeason;

		public int StartHour
		{
			get
			{
				if (startHour <= 0)
				{
					return 7;
				}
				return startHour;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public string ModifiedOnVersion => modifiedOnVersion;

		public bool IsDefault => isDefault;

		public SerializableIdValuePair[] GameParameters => gameParameters ?? (gameParameters = Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters());

		public List<string> StartMapTypes
		{
			get
			{
				List<string> list = startMapTypes;
				if (list != null && list.Count > 0)
				{
					return startMapTypes;
				}
				startMapTypes = Repository<WorldMapSettingsData, WorldMapSettings>.Instance.GetData<WorldMapSettings>().StartMapTypes.ToList();
				return startMapTypes;
			}
		}

		public FactionFriendlinessOverride[] FactionFriendlinessOverrides => factionFriendlinessOverrides;

		public string StartEventId
		{
			get
			{
				if (startEventId == null)
				{
					LoadDefaultStartEventId();
				}
				return startEventId;
			}
		}

		public string StartingEventScheduleId
		{
			get
			{
				if (string.IsNullOrEmpty(startingEventScheduleId))
				{
					LoadDefaultStartEventId();
				}
				return startingEventScheduleId;
			}
		}

		public string ImageId
		{
			get
			{
				if (string.IsNullOrEmpty(imageId))
				{
					LoadDefaultImageId();
				}
				return imageId;
			}
		}

		public string Difficulty => difficulty;

		public HashSet<string> AllowedObjectives
		{
			get
			{
				if (!allowedObjectivesSetCacheInit)
				{
					allowedObjectivesSetCacheInit = true;
					if (allowedObjectives == null)
					{
						LoadDefaultObjectives();
					}
					allowedObjectivesSetCache = new HashSet<string>(allowedObjectives);
				}
				return allowedObjectivesSetCache;
			}
		}

		public bool IsAllowedMapType(string mapType)
		{
			return StartMapTypes.Contains(mapType);
		}

		public bool GetAllowedMapTypes(out List<string> allowedMapTypes)
		{
			allowedMapTypes = new List<string>();
			foreach (NSMedieval.Model.MapNew.Map allItem in Repository<MapRepository, NSMedieval.Model.MapNew.Map>.Instance.GetAllItems())
			{
				if (StartMapTypes.Contains(allItem.GetID()))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\Scenario.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Allowed Map: ");
						messageBuilder.AppendFormatted(allItem.GetID());
					}
					Log.Trace(messageBuilder);
					allowedMapTypes.Add(allItem.GetID());
				}
			}
			if (allowedMapTypes.Count == 0)
			{
				Log.Error("Couldn't find allowed map types. Check scenario settings!", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\Scenario.cs");
			}
			return allowedMapTypes.Count > 0;
		}

		public bool TryGetFriendlinessRangeOverride(string factionTypeId, out FloatRange range)
		{
			range = null;
			if (factionFriendlinessOverrides == null || factionFriendlinessOverrides.Length == 0)
			{
				return false;
			}
			FactionFriendlinessOverride[] array = factionFriendlinessOverrides;
			for (int i = 0; i < array.Length; i++)
			{
				FactionFriendlinessOverride factionFriendlinessOverride = array[i];
				if (!(factionFriendlinessOverride.FactionTypeId != factionTypeId))
				{
					range = factionFriendlinessOverride.FriendlinessRange;
					return true;
				}
			}
			return false;
		}

		public bool TryGetStartEventId(out string eventGroupInstance)
		{
			eventGroupInstance = startEventId;
			return !string.IsNullOrEmpty(startEventId);
		}

		public override string GetID()
		{
			return id;
		}

		public byte[] GetWorkerConstraintsHash()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(villagerConstraints.NumberOfVillagers);
			stringBuilder.Append(villagerConstraints.AgeRange.Min);
			stringBuilder.Append(villagerConstraints.AgeRange.Max);
			stringBuilder.Append(villagerConstraints.WeightRange.Min);
			stringBuilder.Append(villagerConstraints.WeightRange.Max);
			stringBuilder.Append(villagerConstraints.HeightRange.Min);
			stringBuilder.Append(villagerConstraints.HeightRange.Max);
			stringBuilder.Append(villagerConstraints.ForceReligion);
			stringBuilder.Append(villagerConstraints.ForceBodyType);
			foreach (string defaultClothe in villagerConstraints.DefaultClothes)
			{
				stringBuilder.Append(defaultClothe);
			}
			foreach (SerializableIdValuePair forcedPerk in villagerConstraints.ForcedPerks)
			{
				stringBuilder.Append($"{forcedPerk.Id}{forcedPerk.Value}");
			}
			foreach (GameEvent.StatSetting overrideStat in villagerConstraints.OverrideStats)
			{
				stringBuilder.Append($"{overrideStat.Stat}{overrideStat.Value}{overrideStat.ValueRange.Min}{overrideStat.ValueRange.Max}");
			}
			byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
			return new MD5CryptoServiceProvider().ComputeHash(bytes);
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("locKeys", locKeys);
			serializer.Write("startSeason", startSeason);
			serializer.Write("startingResources", startingResources);
			serializer.Write("startingEquipment", startingEquipment);
			serializer.Write("startingStructurePiles", startingStructurePiles);
			serializer.Write("startingAnimals", startingAnimals);
			serializer.Write("villagerConstraints", villagerConstraints);
			serializer.Write("technologyUnlocked", technologyUnlocked);
			serializer.Write("modifiedOnVersion", modifiedOnVersion);
			serializer.Write("gameParameters", gameParameters);
			serializer.Write("startingEventScheduleId", startingEventScheduleId);
			serializer.Write("startEventId", startEventId);
			serializer.Write("imageId", imageId);
			serializer.Write("allowedObjectives", allowedObjectives);
			serializer.Write("difficulty", difficulty);
		}

		public Scenario(FVDeserializer deserializer)
		{
			id = deserializer.ReadString("id");
			locKeys = deserializer.ReadObjectArray<LocKeys>("locKeys");
			startSeason = deserializer.ReadInt("startSeason");
			startingResources = deserializer.ReadObjectArray<SerializableIdValuePair>("startingResources");
			startingEquipment = deserializer.ReadObjectArray<SerializableIdValuePair>("startingEquipment");
			startingStructurePiles = deserializer.ReadObjectArray<SerializableIdValuePair>("startingStructurePiles");
			startingAnimals = deserializer.ReadObjectArray<ScenarioAnimalData>("startingAnimals");
			villagerConstraints = deserializer.ReadObject<WorkerConstraints>("villagerConstraints");
			technologyUnlocked = deserializer.ReadStringList("technologyUnlocked");
			modifiedOnVersion = deserializer.ReadString("modifiedOnVersion");
			gameParameters = deserializer.ReadObjectArray<SerializableIdValuePair>("gameParameters");
			startingEventScheduleId = deserializer.ReadString("startingEventScheduleId");
			startEventId = deserializer.ReadString("startEventId");
			imageId = deserializer.ReadString("imageId");
			allowedObjectives = deserializer.ReadStringList("allowedObjectives");
			difficulty = deserializer.ReadString("difficulty");
			OnAfterDeserialize();
		}

		private void OnAfterDeserialize()
		{
			TryMigrate();
		}

		public void TryMigrate()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			if (ApplicationVersionUtils.IsValidUnifiedScenarioVersion(modifiedOnVersion))
			{
				List<string> list = allowedObjectives;
				if (list != null && list.Count > 0)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(72, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\Scenario.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("No need to migrate save version: ");
						messageBuilder.AppendFormatted(ModifiedOnVersion);
						messageBuilder.AppendLiteral(". Allowed objectives are null: ");
						messageBuilder.AppendFormatted(allowedObjectives == null);
						messageBuilder.AppendLiteral(" count: ");
						messageBuilder.AppendFormatted(allowedObjectives?.Count);
					}
					Log.Trace(messageBuilder);
					return;
				}
			}
			messageBuilder = new FVLogTraceInterpolationHandler(2, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\Scenario.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(GetID());
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(ModifiedOnVersion);
			}
			Log.Trace(messageBuilder);
			TryMigrateGameParameters();
			if (allowedObjectives == null || allowedObjectives.Count == 0)
			{
				LoadDefaultObjectives();
			}
			if (string.IsNullOrEmpty(startingEventScheduleId))
			{
				LoadDefaultEventScheduleId();
			}
			if (string.IsNullOrEmpty(startEventId))
			{
				LoadDefaultStartEventId();
			}
			if (string.IsNullOrEmpty(imageId))
			{
				LoadDefaultImageId();
			}
		}

		private void LoadDefaultImageId()
		{
			imageId = Repository<ScenarioRepository, Scenario>.Instance.GetBlueprintScenario().ImageId;
		}

		private void LoadDefaultStartEventId()
		{
			startEventId = Repository<ScenarioRepository, Scenario>.Instance.GetBlueprintScenario().StartEventId;
		}

		private void LoadDefaultEventScheduleId()
		{
			startingEventScheduleId = Repository<ScenarioRepository, Scenario>.Instance.GetBlueprintScenario().StartingEventScheduleId;
		}

		private void LoadDefaultObjectives()
		{
			allowedObjectives = new List<string>();
			allowedObjectives.AddRange(Repository<ScenarioRepository, Scenario>.Instance.GetBlueprintScenario().AllowedObjectives);
		}

		private void TryMigrateGameParameters()
		{
			if (gameParameters == null || gameParameters.Length == 0)
			{
				gameParameters = Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters().ToArray();
			}
			else
			{
				if (gameParameters.Length == Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters().Length)
				{
					return;
				}
				List<SerializableIdValuePair> list = new List<SerializableIdValuePair>(gameParameters);
				SerializableIdValuePair[] defaultGameParameters = Repository<ScenarioRepository, Scenario>.Instance.GetDefaultGameParameters();
				foreach (SerializableIdValuePair kvp in defaultGameParameters)
				{
					if (!list.Any((SerializableIdValuePair p) => p.Id == kvp.Id))
					{
						bool isEnabled;
						FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\InfoMessages\\Scenario.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Adding missing parameter: ");
							messageBuilder.AppendFormatted(kvp.Id);
							messageBuilder.AppendLiteral(": ");
							messageBuilder.AppendFormatted(kvp.Value);
						}
						Log.Trace(messageBuilder);
						list.Add(new SerializableIdValuePair(kvp.Id, kvp.Value));
					}
				}
				gameParameters = list.ToArray();
			}
		}
	}
}
