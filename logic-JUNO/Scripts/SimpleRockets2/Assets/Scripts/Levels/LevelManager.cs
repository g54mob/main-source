using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Levels.LevelScripts;
using Assets.Scripts.Levels.Scores;
using Assets.Scripts.State;
using ModApi;
using ModApi.Levels;
using ModApi.Levels.Events;
using ModApi.Scenes.Parameters;
using ModApi.Scripts.State;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class LevelManager : MonoBehaviour, ILevelManager
	{
		private List<LevelData> _levels;

		public ILevel CurrentLevel { get; private set; }

		public bool DebuggingFlightScene { get; set; }

		public IReadOnlyList<LevelData> Levels { get; private set; }

		IReadOnlyList<ILevelData> ILevelManager.Levels => Levels;

		public void EndLevel()
		{
			if (CurrentLevel != null)
			{
				CurrentLevel.LevelEnded -= OnLevelEnded;
				CurrentLevel.LevelPassed -= OnLevelPassed;
				CurrentLevel.LevelFailed -= OnLevelFailed;
				CurrentLevel.Cleanup();
				DeleteLevelGameStateTags(Game.Instance.GameState.Id);
				UnityEngine.Object.Destroy(CurrentLevel.GameObject);
				CurrentLevel = null;
				Game.Instance.LoadGameStateOrDefault();
			}
		}

		public bool StartLevel(ILevelData level)
		{
			try
			{
				if (level == null)
				{
					throw new ArgumentNullException("level");
				}
				if (CurrentLevel != null)
				{
					EndLevel();
				}
				else
				{
					Game.Instance.GameState.Save();
				}
				Type levelScriptType = GetLevelScriptType(level);
				if (level == null)
				{
					Debug.Log("Unable to find level script '" + (level?.Script ?? "(null)") + "'.");
					return false;
				}
				GameObject obj = new GameObject("Level_" + level.Id);
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				ILevel level2 = (CurrentLevel = (ILevel)obj.AddComponent(levelScriptType));
				LoadGameState(level.FlightStateId);
				level2.Initialize(level, Game.Instance.SceneManager);
				if (level.LevelType == LevelType.Flight)
				{
					if (level.LaunchCraftId != null)
					{
						Game.Instance.BeginFlight(level.LaunchCraftId, "Player", "Menu", 0L);
					}
					else
					{
						FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
						ICraftNodeData craftNodeData = flightStateData.GetCraftNodeData(flightStateData.PlayerNodeId);
						if (craftNodeData == null)
						{
							throw new InvalidOperationException("The player craft node could not be found in flight state '" + flightStateData.Path + "'.");
						}
						Game.Instance.ResumeFlight(craftNodeData.NodeId, craftNodeData.ParentName);
					}
				}
				else
				{
					if (level.LevelType != LevelType.Design)
					{
						throw new NotSupportedException($"Level type of '{level.LevelType}' is not supported.");
					}
					if (DebuggingFlightScene)
					{
						Game.Instance.BeginFlight(CraftDesigns.EditorCraftId, "Debug", "Design", 0L);
					}
					else if (!string.IsNullOrEmpty(level.TutorialId))
					{
						Game.Instance.SceneManager.LoadDesigner(new DesignSceneLoadParameters
						{
							TutorialId = level.TutorialId
						});
					}
					else
					{
						Game.Instance.BeginDesign(saveGameState: false);
					}
				}
				level2.LevelEnded += OnLevelEnded;
				level2.LevelPassed += OnLevelPassed;
				level2.LevelFailed += OnLevelFailed;
				return true;
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred trying to start level '" + (level?.Id ?? "(null)") + "'.");
				Debug.LogException(exception);
				CurrentLevel = null;
				Game.Instance.LoadGameStateOrDefault();
			}
			return false;
		}

		internal static LevelManager Create(GameObject parent)
		{
			LevelManager levelManager = new GameObject("LevelManager").AddComponent<LevelManager>();
			levelManager.transform.SetParent(parent.transform);
			levelManager.Initialize();
			return levelManager;
		}

		protected virtual void FixedUpdate()
		{
			CurrentLevel?.OnFixedUpdate();
		}

		protected virtual void LateUpdate()
		{
			CurrentLevel?.OnLateUpdate();
		}

		protected virtual void Update()
		{
			CurrentLevel?.OnUpdate();
		}

		private void DeleteLevelGameStateTags(string gameStateId)
		{
			GameStateManager gameStateManager = Game.Instance.GameStateManager;
			gameStateManager.DeleteGameStateTag(gameStateId, "Level.Active");
			gameStateManager.DeleteGameStateTag(gameStateId, "Level.PreFlight");
		}

		private Type GetLevelScriptType(ILevelData level)
		{
			if (string.IsNullOrWhiteSpace(level.Script))
			{
				throw new InvalidOperationException("The level script was not specified (is null or empty)");
			}
			Type type = Type.GetType(typeof(LevelAltitude100).Namespace + "." + level.Script, throwOnError: false, ignoreCase: false);
			if (type == null)
			{
				type = Type.GetType(level.Script, throwOnError: false, ignoreCase: false);
			}
			return type;
		}

		private void Initialize()
		{
			Levels = (_levels = new List<LevelData>());
			LoadStockLevels();
		}

		private void LoadGameState(string id)
		{
			string text = Utilities.CombinePaths(Game.PersistentDataPath, "GameData/FlightStates/");
			string text2 = Utilities.CombinePaths(text, id);
			GameState gameState = Game.Instance.GameState;
			Game.Instance.GameStateManager.CopyGameStateTagFromDirectory(gameState.Id, text2, "Level.Active");
			if (!Game.Instance.LoadGameStateOrDefault(gameState.Id, "Level.Active"))
			{
				throw new Exception("Failed to load the level games state with id '" + id + "' from '" + text2 + "'.");
			}
			if (Game.Instance.GameState.Type != GameStateType.Level)
			{
				Debug.LogError("The level manager loaded a non-level GameState: " + Game.Instance.GameState.RootPath);
			}
		}

		private void LoadLevel(XElement xml)
		{
			if (xml == null)
			{
				return;
			}
			try
			{
				LevelData level = new LevelData(xml);
				if (_levels.Any((LevelData x) => x.Id == level.Id))
				{
					Debug.LogError("Could not load level '" + level.Id + "' because a level with that ID already exists.");
					return;
				}
				_levels.Add(level);
				try
				{
					level.ScoreData.LoadScores();
				}
				catch (Exception exception)
				{
					Debug.LogError("An error occurred loading scores for level '" + level.Id + "'.");
					Debug.LogException(exception);
				}
			}
			catch (Exception exception2)
			{
				string text = (string)xml.Attribute("id");
				if (string.IsNullOrWhiteSpace(text))
				{
					Debug.LogError("An error occurred loading a level with an unknown id. XML: '" + xml.ToString() + "'");
				}
				else
				{
					Debug.LogError("An error occurred loading level '" + text + "'");
				}
				Debug.LogException(exception2);
			}
		}

		private void LoadStockLevels()
		{
			try
			{
				foreach (XElement item in XDocument.Parse(Game.Instance.ResourceLoader.LoadText("Levels/Levels")).Root.Elements("Level"))
				{
					LoadLevel(item);
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred loading the stock levels");
				Debug.LogException(exception);
			}
		}

		private void OnLevelEnded(object sender, LevelEventArgs e)
		{
			EndLevel();
		}

		private void OnLevelFailed(object sender, LevelCompletedEventArgs e)
		{
		}

		private void OnLevelPassed(object sender, LevelCompletedEventArgs e)
		{
			((LevelScoreData)CurrentLevel.LevelData.ScoreData).LogScore(e.Score);
		}
	}
}
