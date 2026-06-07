using System;
using DV.Common;
using DV.JObjectExtstensions;
using DV.Scenarios;
using DV.Scenarios.Common;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.UserManagement
{
	public static class GameSessionExtensions
	{
		public static IDifficulty GetDifficulty(this IGameSession session, bool autoFill = true)
		{
			JObject jObject = null;
			if (session.GameData["Difficulty_params"] != null)
			{
				jObject = session.GameData["Difficulty_params"] as JObject;
			}
			else if (session.LatestSave != null)
			{
				foreach (var (num, bytes) in session.LatestSave.CustomChunkData)
				{
					if (num == SaveGameManager.CHUNK_DIFFICULTY)
					{
						jObject = JObject.Parse(UserManager.ENCODING.GetString(bytes));
					}
				}
			}
			if (jObject == null)
			{
				IDifficulty difficulty = DifficultyParamsSetter.PredefinedDifficulties[0];
				if (autoFill)
				{
					session.SetDifficulty(difficulty, forcePreset: true);
				}
				return difficulty;
			}
			return DifficultyDataUtils.GetDifficultyFromJSON(jObject, autoFill);
		}

		public static void SetDifficulty(this IGameSession session, IDifficulty difficulty, bool forcePreset = false, bool forceConsistency = false)
		{
			if (session.GameData["Difficulty_params"] == null)
			{
				session.GameData["Difficulty_params"] = new JObject();
			}
			DifficultyDataUtils.SetDifficultyToJSON(session.GameData["Difficulty_params"] as JObject, difficulty, forcePreset);
			if (session.Saves.Count == 0 || forceConsistency)
			{
				session.GameData["Consistent_difficulty"] = true;
				session.GameData["Starting_difficulty"] = session.GameData["Difficulty_params"].DeepClone();
			}
		}

		public static void PerformGameplayEntryDifficultyCheck(this IGameSession session, IDifficulty currentDifficulty = null)
		{
			if (session.Saves.Count == 0)
			{
				if (currentDifficulty == null)
				{
					currentDifficulty = session.GetDifficulty();
				}
				JObject jObject = new JObject();
				DifficultyDataUtils.SetDifficultyToJSON(jObject, currentDifficulty);
				session.GameData["Consistent_difficulty"] = true;
				session.GameData["Starting_difficulty"] = jObject;
				session.Save();
				return;
			}
			bool? flag = session.GameData.GetBool("Consistent_difficulty");
			if (!flag.HasValue || !flag.Value)
			{
				return;
			}
			if (session.GameData["Starting_difficulty"] != null)
			{
				if (currentDifficulty == null)
				{
					currentDifficulty = session.GetDifficulty();
				}
				if (!DifficultyDataUtils.GetDifficultyFromJSON(session.GameData["Starting_difficulty"] as JObject, autoFill: false).Equals(currentDifficulty))
				{
					session.GameData["Consistent_difficulty"] = false;
					session.Save();
				}
			}
			else
			{
				session.GameData["Consistent_difficulty"] = false;
				session.Save();
			}
		}

		public static bool VerifyUnchangedDifficulty(this IGameSession session)
		{
			try
			{
				bool? flag = session.GameData.GetBool("Consistent_difficulty");
				if (!flag.HasValue || !flag.Value)
				{
					return false;
				}
				if (session.GameData["Difficulty_params"] != null && session.GameData["Starting_difficulty"] != null)
				{
					IDifficulty difficultyFromJSON = DifficultyDataUtils.GetDifficultyFromJSON(session.GameData["Starting_difficulty"] as JObject, autoFill: false);
					IDifficulty difficultyFromJSON2 = DifficultyDataUtils.GetDifficultyFromJSON(session.GameData["Difficulty_params"] as JObject, autoFill: false);
					bool flag2 = difficultyFromJSON.Equals(difficultyFromJSON2);
					session.GameData["Consistent_difficulty"] = flag2;
					return flag2;
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("Difficulty data parsing broke while verifying: " + ex.Message);
				Debug.LogException(ex);
			}
			session.GameData["Consistent_difficulty"] = false;
			return false;
		}

		public static IScenario GetScenario(this IGameSession session, IScenarioCRUD crud)
		{
			if (session.GameData["Scenario"] != null)
			{
				try
				{
					return crud.ScenarioFromJson(session.GameData["Scenario"] as JObject);
				}
				catch (Exception ex)
				{
					Debug.LogError("Couldn't parse scenario from session data: " + ex.Message);
					Debug.LogException(ex);
					return null;
				}
			}
			return null;
		}

		public static void SetScenario(this IGameSession session, IScenario scenario, IScenarioCRUD crud)
		{
			if (scenario is Thing)
			{
				session.GameData["Scenario"] = crud.SerializeThing(scenario);
				session.Save();
			}
			else
			{
				Debug.LogError("Scenario provided is not of type Thing, can't serialize to session.");
			}
		}
	}
}
