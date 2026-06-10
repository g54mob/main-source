using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Model.MapNew;
using NSMedieval.Resources;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Map
{
	[Serializable]
	public class AnimalSpawner : MonoSingleton<AnimalSpawner>, IObserver
	{
		private static bool gameLoaded;

		private const float MinTemperatureMultiplier = 0.25f;

		private const float MinCountMultiplier = 0.25f;

		[NonSerialized]
		private List<MapNode> possiblePositions = new List<MapNode>();

		[NonSerialized]
		private Dictionary<string, int> animalsCount = new Dictionary<string, int>();

		[NonSerialized]
		private List<AnimalPlacement> animals;

		[NonSerialized]
		private int hoursInDay = 24;

		[NonSerialized]
		private float mapSizeMult;

		public static bool GameLoaded => gameLoaded;

		public List<AnimalPlacement> Animals => animals;

		public float MapSizeMultiplier
		{
			get
			{
				if (mapSizeMult == 0f)
				{
					float num = 206f;
					mapSizeMult = (float)MonoSingleton<World>.Instance.SizeX / num;
				}
				return mapSizeMult;
			}
		}

		private Dictionary<string, float> AnimalSpawnValue => GlobalSaveController.CurrentVillageData.AnimalSpawnValue.Dictionary;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public new static void OnDomainReload()
		{
			gameLoaded = false;
		}

		public float GetMaxCount(AnimalPlacement animalPlacement)
		{
			return (float)animalPlacement.MaxCount * MapSizeMultiplier;
		}

		public float GetAnimalCountSpawnRateMultiplier(AnimalPlacement animalPlacement)
		{
			float num = GetAnimalsCount(animalPlacement.AnimalId);
			float maxCount = GetMaxCount(animalPlacement);
			if (num >= maxCount)
			{
				return 0f;
			}
			num = Mathf.Max(num, 1f) / 10f;
			return Mathf.Clamp(num, 0.25f, 1f);
		}

		public float GetTemperatureMultiplier(AnimalPlacement animalPlacement, float temperature)
		{
			float value = ((!(temperature < animalPlacement.OptimalTemperature)) ? (1f - (temperature - animalPlacement.OptimalTemperature) / (animalPlacement.Temperature.Max - animalPlacement.OptimalTemperature)) : ((temperature - animalPlacement.Temperature.Min) / (animalPlacement.OptimalTemperature - animalPlacement.Temperature.Min)));
			return Mathf.Clamp(value, 0.25f, 1f);
		}

		public float GetTemperatureMultiplierCurrent(AnimalPlacement animal)
		{
			float temperatureCelsius = GlobalSaveController.CurrentVillageData.DateAndTime.TemperatureCelsius;
			return GetTemperatureMultiplier(animal, temperatureCelsius);
		}

		public float GetFinalSpawnMultiplier(AnimalPlacement animalPlacement)
		{
			float animalCountSpawnRateMultiplier = GetAnimalCountSpawnRateMultiplier(animalPlacement);
			if (animalCountSpawnRateMultiplier <= 0f)
			{
				return 0f;
			}
			float num = animalPlacement.SpawnSpeedMultiplier * animalCountSpawnRateMultiplier;
			float temperatureMultiplierCurrent = GetTemperatureMultiplierCurrent(animalPlacement);
			return Mathf.Lerp(b: Mathf.Clamp((num + temperatureMultiplierCurrent) / 2f, 0f, 1f), a: Mathf.Clamp(num * temperatureMultiplierCurrent, 0f, 1f), t: 0.25f) * GetDifficultyMultiplier();
		}

		private float GetDifficultyMultiplier()
		{
			return GlobalSaveController.CurrentVillageData.GameParametersCurrent?.AnimalSpawnMultiplier ?? 1f;
		}

		public int GetAnimalsCount(string animalId)
		{
			return animalsCount.GetValueOrDefault(animalId, 0);
		}

		public float GetAnimalSpawnValue(string animalId)
		{
			if (!AnimalSpawnValue.ContainsKey(animalId))
			{
				return 0f;
			}
			return AnimalSpawnValue[animalId];
		}

		private void OnGameLoaded(bool fromSave)
		{
			possiblePositions = new List<MapNode>(CalculatePossiblePositions());
			if (!fromSave)
			{
				if (GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					SpawnAnimalsTravel();
					InitializeAnimalsCountOnLoad();
				}
				else
				{
					SpawnAnimalsInitial();
				}
			}
			else
			{
				MonoSingleton<AnimalManager>.Instance.SpawnAnimalsFromSavegame();
				InitializeAnimalsCountOnLoad();
			}
			gameLoaded = true;
		}

		private void InitializeAnimalsCountOnLoad()
		{
			animalsCount.Clear();
			foreach (AnimalInstance animal in GlobalSaveController.CurrentVillageData.Animals)
			{
				animalsCount.TryAdd(animal.Id, 0);
				animalsCount[animal.Id]++;
			}
		}

		private void Start()
		{
			hoursInDay = GlobalSaveController.CurrentVillageData.DateAndTime.HoursInDay;
		}

		private void OnEnable()
		{
			MonoSingleton<World>.Instance.MapLoadedEvent += OnGameLoaded;
			MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent += OnLeavingScene;
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnLeavingScene;
			MonoSingleton<AnimalController>.Instance.HealthDepletedEvent += OnAnimalDeath;
			MonoSingleton<AnimalController>.Instance.DieFormStarvationEvent += OnAnimalDeath;
			MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent += OnSpawnAnimal;
			MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent += OnDateTimeInitalize;
			MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent += OnDateUpdate;
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
		}

		private void OnDisable()
		{
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnGameLoaded;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnLeavingScene;
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnLeavingScene;
			}
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.HealthDepletedEvent -= OnAnimalDeath;
				MonoSingleton<AnimalController>.Instance.DieFormStarvationEvent -= OnAnimalDeath;
				MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent -= OnSpawnAnimal;
			}
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.DateTimeInitalizeEvent -= OnDateTimeInitalize;
				MonoSingleton<WorldTimeManager>.Instance.DateUpdateEvent -= OnDateUpdate;
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
			animals?.Clear();
			possiblePositions?.Clear();
			animalsCount?.Clear();
		}

		private void OnHourUpdate()
		{
			TickAnimalSpawning();
		}

		private void OnDateUpdate()
		{
		}

		private void OnDateTimeInitalize()
		{
			TickAnimalSpawning();
		}

		private void TickAnimalSpawning()
		{
			if (!gameLoaded)
			{
				return;
			}
			animals = new List<AnimalPlacement>(GlobalSaveController.CurrentVillageData.MapBlueprint.Animals);
			foreach (AnimalPlacement animal in animals)
			{
				if (GlobalSaveController.CurrentVillageData.IsAnimalPlacementEnabled(animal.GetID()))
				{
					string animalId = animal.AnimalId;
					AnimalSpawnValue.TryAdd(animalId, 0f);
					animalsCount.TryAdd(animalId, 0);
					float num = GetFinalSpawnMultiplier(animal) / (float)hoursInDay;
					AnimalSpawnValue[animalId] += num;
					if (AnimalSpawnValue[animalId] > 1f)
					{
						AnimalSpawnValue[animalId] -= 1f;
						PlaceAnimal(animalId);
					}
				}
			}
		}

		private void OnSpawnAnimal(AnimalInstance instance)
		{
			string id = instance.Id;
			if (!animalsCount.ContainsKey(id))
			{
				animalsCount.Add(id, 0);
			}
			animalsCount[id]++;
		}

		private void OnAnimalDeath(AnimalInstance animalInstance)
		{
			string iD = animalInstance.Blueprint.GetID();
			animalsCount.TryAdd(iD, 0);
			animalsCount[iD]--;
			if (animalsCount[iD] < 0)
			{
				animalsCount[iD] = 0;
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\FasterMapGeneration\\AnimalSpawner.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Animal count below zero for ");
					messageBuilder.AppendFormatted(iD);
				}
				Log.Error(messageBuilder);
			}
		}

		private IList<MapNode> CalculatePossiblePositions()
		{
			IList<MapNode> list = GetNodes(skipUnderwaterNodes: true, removeInaccessibleRegions: true);
			if (list.Count > 0)
			{
				return list;
			}
			list = GetNodes(skipUnderwaterNodes: false, removeInaccessibleRegions: true);
			if (list.Count > 0)
			{
				return list;
			}
			list = GetNodes(skipUnderwaterNodes: true, removeInaccessibleRegions: false);
			if (list.Count > 0)
			{
				return list;
			}
			list = GetNodes(skipUnderwaterNodes: false, removeInaccessibleRegions: false);
			if (list.Count > 0)
			{
				return list;
			}
			return null;
			static IList<MapNode> GetNodes(bool skipUnderwaterNodes, bool removeInaccessibleRegions)
			{
				List<MapNode> nodesNearEdge = NPCStartPositionManager.GetNodesNearEdge(16, null, skipUnderwaterNodes, removeInaccessibleRegions);
				nodesNearEdge.RemoveAll((MapNode node) => !node.IsWalkable || node.Coverage != CoverageType.Outside);
				return nodesNearEdge;
			}
		}

		private void OnDrawGizmos()
		{
			Color color = Gizmos.color;
			Gizmos.color = new Color(0.5f, 1f, 1f, 0.2f);
			foreach (MapNode possiblePosition in possiblePositions)
			{
				if (possiblePosition?.Region != null)
				{
					Gizmos.DrawCube(possiblePosition.WorldPosition, Vector3.one * 0.9f);
				}
			}
			Gizmos.color = color;
		}

		private void SpawnAnimalsInitial()
		{
			UnityEngine.Random.InitState(VillageManager.ActiveVillage.Seed.GetHashCode());
			foreach (AnimalPlacement animal in GlobalSaveController.CurrentVillageData.MapBlueprint.Animals)
			{
				bool flag = animal.SpawnerChance > 0f && UnityEngine.Random.Range(0f, 1f) < animal.SpawnerChance;
				GlobalSaveController.CurrentVillageData.SetAnimalPlacementEnabled(animal.GetID(), flag);
				if (flag)
				{
					PlaceAnimalsInitial(animal);
				}
			}
			ScenarioAnimalData[] startingAnimals = GlobalSaveController.CurrentVillageData.Scenario.StartingAnimals;
			if (startingAnimals == null)
			{
				return;
			}
			ScenarioAnimalData[] array = startingAnimals;
			for (int i = 0; i < array.Length; i++)
			{
				ScenarioAnimalData scenarioAnimalData = array[i];
				for (int num = scenarioAnimalData.Count; num > 0; num--)
				{
					PlaceAnimal(scenarioAnimalData.ID, scenarioAnimalData.BodyType, scenarioAnimalData.LifePhaseIndex, scenarioAnimalData.AnimalType);
				}
			}
		}

		private void PlaceAnimalsInitial(AnimalPlacement animalPlacement)
		{
			float num = Mathf.Ceil((float)animalPlacement.InitialCount.Random() * MapSizeMultiplier);
			float num2 = Mathf.Lerp(GetTemperatureMultiplierCurrent(animalPlacement), 0.5f, 0.25f);
			int num3 = Mathf.CeilToInt(num * num2);
			string animalId = animalPlacement.AnimalId;
			for (int i = 0; i < num3; i++)
			{
				PlaceAnimal(animalId);
			}
		}

		private void SpawnAnimalsTravel()
		{
			if (possiblePositions.Count != 0)
			{
				MonoSingleton<AnimalManager>.Instance.SpawnAnimalsFromTravel(possiblePositions);
			}
		}

		private void PlaceAnimal(string animalId)
		{
			BodyType bodyType = ((!(UnityEngine.Random.Range(0f, 1f) > 0.5f)) ? BodyType.Male : BodyType.Female);
			PlaceAnimal(animalId, bodyType, -1);
		}

		private void PlaceAnimal(string animalId, BodyType bodyType, int lifePhaseIndex, AnimalType animalType = AnimalType.Wild)
		{
			if (possiblePositions.Count == 0)
			{
				return;
			}
			Vector3 position = possiblePositions.PickRandom().WorldPosition;
			float lifePhasePercent = UnityEngine.Random.Range(0f, 0.2f);
			AnimalInstance animalInstance = MonoSingleton<AnimalManager>.Instance.SpawnAnimal(animalId, position, bodyType, lifePhaseIndex, lifePhasePercent);
			if (animalType == AnimalType.Domestic || animalType == AnimalType.Pet)
			{
				bool flag = false;
				while (!flag)
				{
					position = MonoSingleton<StartPositionManager>.Instance.GetNextPositionWorldSpace();
					MonoSingleton<World>.Instance.LimitPositionToRange(ref position);
					if (!MonoSingleton<SlopeManager>.Instance.IsSlopeAt((int)position.x, (int)position.z) && !(MonoSingleton<FloraRegrowController>.Instance.GetPositionUsedBy((int)position.x, (int)position.z) != null))
					{
						position.y = MonoSingleton<Heightmap>.Instance.GetHeightAt((int)position.x, (int)position.z) * World.MapBlockHeight;
						animalInstance.UpdatePosition(position);
						flag = true;
					}
				}
			}
			switch (animalType)
			{
			case AnimalType.Domestic:
			{
				StatInstance stat2 = animalInstance.Stats.GetStat(StatType.AnimalUntrained);
				stat2.SetCurrent(stat2.Max);
				break;
			}
			case AnimalType.Pet:
				animalInstance.Stats.GetStat(StatType.AnimalWild)?.SetCurrent(0f);
				break;
			case AnimalType.WildAggressive:
			{
				StatInstance stat = animalInstance.Stats.GetStat(StatType.AnimalWild);
				stat.SetCurrent(stat.Max);
				break;
			}
			}
			animalInstance.SpawnPosition = position;
			animalInstance.SetAnimalType(animalType);
			animalInstance.SetName(string.Empty);
			MonoSingleton<TaskController>.Instance.WaitFor(0.1f).Then(delegate
			{
				animalInstance.GetGoapAgent()?.StartTicker();
			});
		}

		private void OnLeavingScene()
		{
			gameLoaded = false;
		}
	}
}
