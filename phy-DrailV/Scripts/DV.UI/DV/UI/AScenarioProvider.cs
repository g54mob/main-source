using System.Collections.Generic;
using System.Linq;
using DV.Common;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.UI.PresetEditors;
using UnityEngine;

namespace DV.UI
{
	public abstract class AScenarioProvider : MonoBehaviour
	{
		protected const string LOC_INVALID_DATA = "scenario/cant_start_session_invalid_data";

		protected const string LOC_SESSION_NAME_IS_NULL = "scenario/cant_start_session_name_is_null";

		protected const string LOC_SCENARIO_IS_NULL = "scenario/cant_start_scenario_is_null";

		protected const string LOC_DIFFICULTY_IS_NULL = "scenario/cant_start_difficulty_is_null";

		protected const string LOC_LOCKED_CARS = "scenario/cant_start_locked_cars";

		protected const string LOC_TRAIN_LONG_START = "scenario/cant_start_train_long_start";

		protected const string LOC_TRAIN_LONG_DEST = "scenario/cant_start_train_long_dest";

		public const int SELECTED_WORLD_INDEX = 0;

		public AUserProfileProvider userProfileProvider;

		public IScenarioCRUD CRUD { get; protected set; }

		public abstract bool IsVR { get; }

		public abstract DVObjectModel GetObjectModel();

		public abstract List<ScenarioEditorStationMapping> GetStationMappings();

		public abstract HashSet<GeneralLicenseType_v2> GetUnlockedLicenses();

		public abstract HashSet<GarageType_v2> GetUnlockedGarages();

		public abstract bool TrainTooLongForStartingTrack(IScenario scenario);

		public abstract bool TrainTooLongForDestinationTrack(IScenario scenario);

		protected abstract void CreateNewIScenarioCRUDInstance();

		protected virtual void Awake()
		{
			userProfileProvider.UserProfileChanged += CreateNewIScenarioCRUDInstance;
			ScenarioThingExtensions.Init(GetObjectModel());
			CreateNewIScenarioCRUDInstance();
		}

		public virtual (bool canRun, string reasonLocKey) CanStartNewSession(IGameSession session, IScenario scenario, IDifficulty difficulty)
		{
			if (session == null)
			{
				return (canRun: false, reasonLocKey: "scenario/cant_start_session_invalid_data");
			}
			if (session.GameMode != "Career" && session.GameMode != "FreeRoam")
			{
				return (canRun: false, reasonLocKey: "scenario/cant_start_session_invalid_data");
			}
			if (string.IsNullOrWhiteSpace(session.Name))
			{
				return (canRun: false, reasonLocKey: "scenario/cant_start_session_name_is_null");
			}
			if (difficulty == null)
			{
				return (canRun: false, reasonLocKey: "scenario/cant_start_difficulty_is_null");
			}
			if (session.GameMode == "FreeRoam")
			{
				if (scenario == null)
				{
					return (canRun: false, reasonLocKey: "scenario/cant_start_scenario_is_null");
				}
				if (ContainsLockedCars(scenario))
				{
					return (canRun: false, reasonLocKey: "scenario/cant_start_locked_cars");
				}
				if (TrainTooLongForStartingTrack(scenario))
				{
					return (canRun: false, reasonLocKey: "scenario/cant_start_train_long_start");
				}
				if (TrainTooLongForDestinationTrack(scenario))
				{
					return (canRun: false, reasonLocKey: "scenario/cant_start_train_long_dest");
				}
			}
			return (canRun: true, reasonLocKey: null);
		}

		public virtual bool ContainsLockedCars(IScenario scenario)
		{
			if (scenario.Train != null)
			{
				return ContainsLockedCars(scenario.Train);
			}
			return false;
		}

		public virtual bool ContainsLockedCars(ITrain train)
		{
			if (train == null || train.Cars == null)
			{
				return false;
			}
			return train.Cars.Any((ICar c) => !TrainEditor_Helpers.IsLiveryUnlocked(c.GetLivery(), GetUnlockedLicenses(), GetUnlockedGarages()));
		}

		public bool IsAnythingRandomized(IScenario scenario)
		{
			if (!scenario.RandomTrain && !scenario.RandomStartingTrackID && !scenario.RandomDestinationTrackID && !scenario.RandomTimeOfDay && !scenario.RandomCloudsPercentage && !scenario.RandomFogPercentage && !scenario.RandomWetnessPercentage && !scenario.RandomRainPercentage && !scenario.RandomLightningPercentage)
			{
				return scenario.RandomSeed;
			}
			return true;
		}

		public IScenario GetRandomizedScenario(IScenario scenario)
		{
			IScenario scenario2 = CRUD.CreateCopyOf(scenario);
			CRUD.DeleteScenario(scenario2);
			scenario2.Name = scenario.Name;
			if (scenario2.RandomTrain)
			{
				List<ITrain> list = new List<ITrain>(CRUD.Trains);
				list.RemoveAll(ContainsLockedCars);
				list.RemoveAll((ITrain t) => t.ExcludeFromRandomization);
				if (list.Count == 0)
				{
					Debug.LogWarning("GetRandomizedScenario: No availableTrains, using empty train");
					scenario2.Train = CRUD.CreateTrain();
				}
				else
				{
					scenario2.Train = list[Random.Range(0, list.Count)];
				}
			}
			ScenarioEditorStationMapping currentWorldMappings = GetStationMappings()[0];
			if (scenario2.RandomStartingTrackID)
			{
				List<ScenarioEditorStationMapping.Mapping> list2 = new List<ScenarioEditorStationMapping.Mapping>(currentWorldMappings.mappings);
				if (!scenario2.RandomDestinationTrackID && !string.IsNullOrEmpty(scenario2.DestinationTrackID))
				{
					string stationIdToRemoveFromRng = GetStationIdFromTrackId(scenario2.DestinationTrackID, reverseTrain: true);
					if (string.IsNullOrEmpty(stationIdToRemoveFromRng))
					{
						stationIdToRemoveFromRng = GetStationIdFromTrackId(scenario2.DestinationTrackID, reverseTrain: false);
					}
					if (string.IsNullOrEmpty(stationIdToRemoveFromRng))
					{
						Debug.LogError("GetRandomizedScenario: DestinationTrackID: " + scenario2.DestinationTrackID + " doesn't exist in mappings data");
					}
					else
					{
						list2.RemoveAll((ScenarioEditorStationMapping.Mapping m) => currentWorldMappings.Map(m).station.id == stationIdToRemoveFromRng);
					}
				}
				if (list2.Count == 0)
				{
					scenario2.StartingTrackID = string.Empty;
					Debug.LogWarning("GetRandomizedScenario: No available mappings, StartingTrackID will be empty");
				}
				else
				{
					ScenarioEditorStationMapping.Mapping mapping = list2[Random.Range(0, list2.Count)];
					scenario2.StartingTrackID = mapping.trackId;
					scenario2.ReverseTrain = mapping.reverseTrain;
				}
			}
			if (scenario2.RandomDestinationTrackID)
			{
				List<ScenarioEditorStationMapping.Mapping> list3 = new List<ScenarioEditorStationMapping.Mapping>(currentWorldMappings.mappings);
				if (!string.IsNullOrEmpty(scenario2.StartingTrackID))
				{
					string stationIdToRemoveFromRng2 = GetStationIdFromTrackId(scenario2.StartingTrackID, scenario2.ReverseTrain);
					if (string.IsNullOrEmpty(stationIdToRemoveFromRng2))
					{
						Debug.LogError("GetRandomizedScenario: StartingTrackID: " + scenario2.StartingTrackID + " doesn't exist in mappings data");
					}
					else
					{
						list3.RemoveAll((ScenarioEditorStationMapping.Mapping m) => currentWorldMappings.Map(m).station.id == stationIdToRemoveFromRng2);
					}
				}
				if (list3.Count == 0)
				{
					scenario2.DestinationTrackID = string.Empty;
					Debug.LogWarning("GetRandomizedScenario: No available mappings, DestinationTrackID will be empty");
				}
				else
				{
					scenario2.DestinationTrackID = list3[Random.Range(0, list3.Count)].trackId;
				}
			}
			if (scenario2.RandomTimeOfDay)
			{
				List<(int, string)> timesOfDay = ScenarioEditorController.GetTimesOfDay();
				scenario2.TimeOfDay = timesOfDay[Random.Range(0, timesOfDay.Count)].Item1;
			}
			if (scenario2.RandomRainPercentage)
			{
				bool flag = Random.value < 0.25f;
				scenario2.RainPercentage = (flag ? RandomWeatherPercentage(0) : 0);
			}
			bool flag2 = scenario2.RainPercentage > 0;
			if (scenario2.RandomCloudsPercentage)
			{
				scenario2.CloudsPercentage = RandomWeatherPercentage(flag2 ? 25 : 0);
			}
			if (scenario2.RandomWetnessPercentage)
			{
				scenario2.WetnessPercentage = RandomWeatherPercentage(flag2 ? 50 : 0);
			}
			if (scenario2.RandomLightningPercentage)
			{
				scenario2.LightningPercentage = ((scenario2.CloudsPercentage > 75) ? RandomWeatherPercentage(0) : 0);
			}
			if (scenario2.RandomFogPercentage)
			{
				scenario2.FogPercentage = RandomWeatherPercentage(0);
			}
			if (scenario2.RandomSeed)
			{
				char[] array = new char[8];
				for (int num = 0; num < array.Length; num++)
				{
					array[num] = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[Random.Range(0, "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)];
				}
				scenario2.Seed = new string(array);
			}
			return scenario2;
			string GetStationIdFromTrackId(string trackId, bool reverseTrain)
			{
				var (num2, mapping2) = currentWorldMappings.Unmap(trackId, reverseTrain);
				if (num2 >= 0)
				{
					WorldStationsExtractedData.StationData item = currentWorldMappings.Map(mapping2).station;
					return item.id;
				}
				return null;
			}
			int RandomWeatherPercentage(int minValue)
			{
				int max = 21;
				return Random.Range((minValue > 0) ? (minValue / 5) : 0, max) * 5;
			}
		}
	}
}
