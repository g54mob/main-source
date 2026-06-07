using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using ModApi;
using ModApi.CelestialData;
using ModApi.Scenes;
using ModApi.Scenes.Events;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.State
{
	public class GameStateManager
	{
		public static class Tags
		{
			public static class Level
			{
				public const string Active = "Level.Active";

				public const string PreFlight = "Level.PreFlight";

				private const string Prefix = "Level.";
			}

			public static class PlanetStudio
			{
				public const string Active = "PlanetStudio.Active";

				public const string PreFlight = "PlanetStudio.PreFlight";

				public const string QuickSave = "PlanetStudio.QuickSave";

				private const string Prefix = "PlanetStudio.";
			}

			public static class Simulation
			{
				public const string Active = "Simulation.Active";

				public const string PreFlight = "Simulation.PreFlight";

				public const string QuickSave = "Simulation.QuickSave";

				private const string Prefix = "Simulation.";
			}

			public const string Active = "Active";

			public const string PreFlight = "PreFlight";

			public const string QuickSave = "QuickSave";

			public const string Temp = "Temp";
		}

		public const string DefaultGameState = "__default__";

		public const string DefaultGameStateCareer = "__new_career__";

		public const string DefaultGameStateSandbox = "__new__";

		private string _gameStatesFolder;

		public string GameStatesBaseFolder => _gameStatesFolder;

		public GameStateManager(string gameStatesFolder, ISceneManager sceneManager)
		{
			_gameStatesFolder = gameStatesFolder;
			sceneManager.SceneLoading += OnSceneLoading;
		}

		public bool CheckGameStateSetExists(string id)
		{
			return CheckGameStateTagExists(id, "Active");
		}

		public bool CheckGameStateTagExists(string id, string tag)
		{
			if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(tag))
			{
				return false;
			}
			return File.Exists(GetGameStateFileName(id, tag));
		}

		public void CopyGameStateSet(string sourceId, string targetId)
		{
			if (!CheckGameStateSetExists(sourceId))
			{
				throw new Exception("Source Game ID does not exist: " + sourceId);
			}
			if (CheckGameStateSetExists(targetId))
			{
				DeleteGameStateSet(targetId);
			}
			string gameStateSetPath = GetGameStateSetPath(targetId);
			Utilities.CopyDirectory(GetGameStateSetPath(sourceId), gameStateSetPath, copySubDirectories: true, overwriteFiles: true);
		}

		public void CopyGameStateTag(string id, string sourceTag, string targetTag)
		{
			string gameStateTagPath = GetGameStateTagPath(id, sourceTag);
			CopyGameStateTagFromDirectory(id, gameStateTagPath, targetTag);
		}

		public void CopyGameStateTagFromDirectory(string id, string sourcePath, string targetTag)
		{
			if (!Directory.Exists(sourcePath))
			{
				throw new Exception("Source game state tag does not exist: " + sourcePath);
			}
			string gameStateTagPath = GetGameStateTagPath(id, targetTag);
			if (Directory.Exists(gameStateTagPath))
			{
				string gameStateTagPath2 = GetGameStateTagPath(id, "Temp");
				if (Directory.Exists(gameStateTagPath2))
				{
					Utilities.DeleteDirectoryFromPersistentData(gameStateTagPath2, recursive: true);
				}
				Directory.Move(gameStateTagPath, gameStateTagPath2);
			}
			Utilities.CopyDirectory(sourcePath, gameStateTagPath, copySubDirectories: true, overwriteFiles: true);
			string text = sourcePath.Replace(GetGameStateSetPath(id), string.Empty).Replace(Game.PersistentDataPath, string.Empty).TrimStart('/');
			Debug.Log("Copied Game State '" + text + "' --> '" + targetTag + "'  (" + id + ")");
		}

		public GameState CreateDefaultGameStateSet()
		{
			CopyGameStateSet("__new__", "__default__");
			GameState obj = new GameState("__default__", GetGameStateTagPath("__default__"))
			{
				CompanyName = string.Empty
			};
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			FlightStateData flightStateData = obj.LoadFlightStateData();
			flightStateData.ChangePlanetarySystem(CelestialFileReference.CreateWithFileId(null, celestialDatabase.DefaultPlanetarySystemV2Id));
			flightStateData.Save();
			obj.Save();
			return obj;
		}

		public void CreateDefaultSandboxTag(string id, string tag, GameStateType gameStateType)
		{
			string gameStateTagPath = GetGameStateTagPath("__new__");
			CopyGameStateTagFromDirectory(id, gameStateTagPath, tag);
			GameState obj = new GameState(id, GetGameStateTagPath(id, tag))
			{
				CompanyName = string.Empty,
				Type = gameStateType
			};
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			FlightStateData flightStateData = obj.LoadFlightStateData();
			flightStateData.ChangePlanetarySystem(CelestialFileReference.CreateWithFileId(null, celestialDatabase.DefaultPlanetarySystemV2Id));
			flightStateData.Save();
			obj.Save();
		}

		public void CreateGameStateTag(string id, string tag)
		{
			CopyGameStateTag(id, "Active", tag);
		}

		public GameState CreateNewGameStateSet(CelestialFileReference planetarySystem = null, GameStateMode mode = GameStateMode.Sandbox, string careerModePath = null)
		{
			string text = Guid.NewGuid().ToString();
			switch (mode)
			{
			case GameStateMode.Sandbox:
				CopyGameStateSet("__new__", text);
				break;
			case GameStateMode.Career:
				CopyGameStateSet("__new_career__", text);
				break;
			default:
				throw new ArgumentException($"Unsupported mode: {mode}");
			}
			GameState gameState = new GameState(text, GetGameStateTagPath(text), careerModePath);
			CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
			FlightStateData flightStateData = gameState.LoadFlightStateData();
			flightStateData.ChangePlanetarySystem(planetarySystem ?? CelestialFileReference.CreateWithFileId(null, celestialDatabase.DefaultPlanetarySystemV2Id));
			flightStateData.Save();
			return gameState;
		}

		public void DeleteGameStateSet(string id)
		{
			string gameStateSetPath = GetGameStateSetPath(id);
			if (!Directory.Exists(gameStateSetPath))
			{
				return;
			}
			try
			{
				string text = (string)GetGameStateXml(id).Root.Attribute("editorCraftId");
				if (!string.IsNullOrEmpty(text))
				{
					Game.Instance.CraftDesigns.DeleteCraftFile(text);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			Utilities.DeleteDirectoryFromPersistentData(gameStateSetPath, recursive: true);
		}

		public void DeleteGameStateTag(string id, string tag)
		{
			string gameStateTagPath = GetGameStateTagPath(id, tag);
			if (Directory.Exists(gameStateTagPath))
			{
				Utilities.DeleteDirectoryFromPersistentData(gameStateTagPath, recursive: true);
			}
		}

		public string GetFlightStatePath(string gameStateId, string tag = "Active")
		{
			return Utilities.CombinePaths(GetGameStateTagPath(gameStateId, tag), "FlightState.xml");
		}

		public XDocument GetFlightStateXml(string gameStateId, string tag = "Active")
		{
			return XDocument.Load(GetFlightStatePath(gameStateId, tag));
		}

		public string GetGameStateFileName(string gameStateId, string tag = "Active")
		{
			return new FileInfo(GetGameStateTagPath(gameStateId, tag) + "/GameState.xml").FullName;
		}

		public List<string> GetGameStateIds(bool excludeReservedIds = true)
		{
			List<string> list = new List<string>();
			DirectoryInfo[] directories = new DirectoryInfo(_gameStatesFolder).GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				if (!excludeReservedIds || !directoryInfo.Name.StartsWith("__"))
				{
					list.Add(directoryInfo.Name);
				}
			}
			return list;
		}

		public string GetGameStateTagPath(string id, string tag = "Active")
		{
			return Utilities.CombinePaths(GetGameStateSetPath(id), tag);
		}

		public XDocument GetGameStateXml(string gameStateId, string tag = "Active")
		{
			return XDocument.Load(GetGameStateFileName(gameStateId, tag));
		}

		public string GetPhotoLibraryPath(string gameStateId)
		{
			return Utilities.CombinePaths(GetGameStateSetPath(gameStateId), "PhotoLibrary");
		}

		public bool HasLoadableGameStates()
		{
			return GetGameStateIds().Count > 0;
		}

		public GameState LoadGameState(string id, string tag = "Active")
		{
			try
			{
				return new GameState(id, GetGameStateTagPath(id, tag));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return null;
		}

		public void ProcessDownloadedSandbox(string id)
		{
			GameState gameState = new GameState(id, GetGameStateTagPath(id));
			gameState.PreflightLoadParameters = null;
			gameState.Save();
			CopyGameStateTag(id, "Active", "PreFlight");
		}

		public void RestoreGameStateTag(string id, string sourceTag, string targetTag = "Active")
		{
			CopyGameStateTag(id, sourceTag, targetTag);
			Game.Instance.LoadGameStateOrDefault(id, targetTag);
		}

		private string GetGameStateSetPath(string id)
		{
			return Path.Combine(_gameStatesFolder, id);
		}

		private void OnSceneLoading(object sender, SceneEventArgs e)
		{
			if (e.Scene == "Menu")
			{
				GameState gameState = Game.Instance.GameState;
				if (gameState == null || gameState.Type != GameStateType.Default)
				{
					Game.Instance.LoadGameStateOrDefault();
				}
			}
		}
	}
}
