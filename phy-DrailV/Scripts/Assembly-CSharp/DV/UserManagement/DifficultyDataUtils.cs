using System;
using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using DV.Scenarios;
using DV.Scenarios.Common;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement
{
	public static class DifficultyDataUtils
	{
		private const string CUSTOM_DIFFICULTY_FALLBACK_NAME = "Custom";

		public static readonly AJSONDataUpgrader[] DifficultyUpgraders = new AJSONDataUpgrader[8]
		{
			new Difficulty_v1_to_v2_Dash_bool_to_int(),
			new Difficulty_v2_to_v3_KeyboardDriving_bool_to_int(),
			new Difficulty_v3_to_v4_NewParamsDefaultValue(),
			new Difficulty_v4_to_v5_MainResFillTimeDefaultValue(),
			new Difficulty_v5_to_v6_PausedPhotoMode(),
			new Difficulty_v6_to_v7_BrakesHeavyParamRemovals(),
			new Difficulty_v7_to_v8_StartingItemsEnumChange(),
			new Difficulty_v8_to_v9_BrakeWarningsRename()
		};

		public static readonly AJSONDataUpgrader[] ScenarioUpgraders = new AJSONDataUpgrader[4]
		{
			new Scenario_v1_to_v2_Renamed_S282(),
			new Scenario_v2_to_v3_StockCar_and_Renamed_Chickens(),
			new Scenario_v3_to_v4_HopperCovered_Refrigerator_and_Renamed_LocalFruits(),
			new Scenario_v4_to_v5_Station_Rename()
		};

		public static readonly AJSONDataUpgrader[] TrainUpgraders = new AJSONDataUpgrader[3]
		{
			new Train_v1_to_v2_Renamed_S282(),
			new Train_v2_to_v3_StockCar_and_Renamed_Chickens(),
			new Train_v3_to_v4_HopperCovered_Refrigerator_and_Renamed_LocalFruits()
		};

		public static readonly Dictionary<string, string> NameChanges = new Dictionary<string, string>();

		private static void CheckAndUpgrade(JObject difficultyData)
		{
			ScenarioCRUD.UpgradeDifficulty(difficultyData, "", null, DifficultyUpgraders, NameChanges);
		}

		public static IDifficulty GetDifficultyFromJSON(JObject difficultyData, bool autoFill)
		{
			if (difficultyData["_Difficulty_preset"] != null)
			{
				string presetName = difficultyData.GetString("_Difficulty_preset");
				if (string.IsNullOrEmpty(presetName))
				{
					try
					{
						CheckAndUpgrade(difficultyData);
						Difficulty difficulty = difficultyData.ToObject<Difficulty>();
						difficulty.SyncState = SyncState.Synced;
						if (string.IsNullOrEmpty(difficulty.Name))
						{
							difficulty.Name = "Custom";
						}
						return difficulty;
					}
					catch (Exception ex)
					{
						Debug.LogError("Error parsing difficulty data: " + ex.Message);
						Debug.LogException(ex);
						return DifficultyParamsSetter.PredefinedDifficulties[0];
					}
				}
				IDifficulty difficulty2 = DifficultyParamsSetter.PredefinedDifficulties.FirstOrDefault((IDifficulty d) => d.Name == presetName);
				if (difficulty2 != null)
				{
					return difficulty2;
				}
				Debug.LogWarning("Difficulty '" + presetName + "' is marked as stock, but it doesn't have a name-match in current predefined difficulties, falling back to default difficulty.");
				IDifficulty difficulty3 = DifficultyParamsSetter.PredefinedDifficulties[0];
				if (autoFill)
				{
					SetDifficultyToJSON(difficultyData, difficulty3, forcePreset: true);
				}
				return difficulty3;
			}
			try
			{
				CheckAndUpgrade(difficultyData);
				IDifficulty difficulty4 = difficultyData.ToObject<Difficulty>();
				IDifficulty difficulty5 = DifficultyParamsSetter.PredefinedDifficulties.FirstOrDefault((IDifficulty d) => d.Equals(difficulty4));
				if (difficulty5 != null)
				{
					if (autoFill)
					{
						SetDifficultyToJSON(difficultyData, difficulty5, forcePreset: true);
					}
					return difficulty5;
				}
				if (autoFill)
				{
					difficultyData["_Difficulty_preset"] = "";
				}
				if (string.IsNullOrEmpty(difficulty4.Name))
				{
					difficulty4.Name = "Custom";
				}
				difficulty4.SyncState = SyncState.Synced;
				return difficulty4;
			}
			catch (Exception ex2)
			{
				Debug.LogError("Error parsing difficulty data: " + ex2.Message);
				Debug.LogException(ex2);
				return DifficultyParamsSetter.PredefinedDifficulties[0];
			}
		}

		public static void SetDifficultyToJSON(JObject difficultyData, IDifficulty difficulty, bool forcePreset = false)
		{
			if (forcePreset || difficulty.IsReadOnly)
			{
				if (difficultyData == null)
				{
					difficultyData = new JObject();
				}
				else if (difficultyData.Count > 1 || !difficultyData.ContainsKey("_Difficulty_preset"))
				{
					difficultyData.RemoveAll();
				}
				difficultyData["_Difficulty_preset"] = difficulty.Name;
				return;
			}
			JObject jObject = JObject.FromObject(difficulty);
			difficultyData.ReplaceAll(jObject.Children());
			int currentDataVersion = ScenarioCRUD.GetCurrentDataVersion(DifficultyUpgraders);
			if (currentDataVersion >= 1)
			{
				difficultyData[Thing.DATA_VERSION_KEY] = currentDataVersion;
			}
			difficultyData["_Difficulty_preset"] = "";
		}
	}
}
