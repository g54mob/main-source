using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Environment.Water;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Maps;
using Assets.Scripts.Flight.UI.Panels;
using Assets.Scripts.Menu;
using Assets.Scripts.Mods;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class LevelLoaderScript : MonoBehaviour
	{
		public Transform Water;

		public WaterSplashManager WaterSplashManager;

		private LevelBase _levelBaseScript;

		public int WaterNumTiles { get; private set; }

		public float WaterScale { get; set; }

		protected virtual void Awake()
		{
			try
			{
				Transform transform = base.transform.Find("Development");
				if (transform != null)
				{
					transform.gameObject.SetActive(value: false);
				}
				GameWorld.Instance.FloatingOriginOffsetD = Vector3.zero;
				GameWorld.Instance.SeaLevel = 0f;
				LevelInfo level = Game.Instance.CurrentLevel;
				MapLoadResult mapLoadResult = Game.Instance.CurrentMap.LoadMap(level);
				LevelBase levelBase = mapLoadResult.LevelScript;
				if (levelBase == null && !string.IsNullOrEmpty(level.ModName))
				{
					TodoException<LevelLoaderScript>.LogOnce("Mod levels are not currently supported");
					IModManager modManager = Game.Instance.ModManager;
					ModLevelInfo? modLevelInfo = modManager.Levels.Where((ModLevelInfo x) => x.Mod.Name == level.ModName && x.Name == level.Name).Cast<ModLevelInfo?>().FirstOrDefault();
					if (!modLevelInfo.HasValue)
					{
						string message = $"The mod manager could not find the current level '{level.Name}' for mod '{level.ModName}'";
						Debug.LogError(message);
						Game.Instance.SceneManager.LoadLevelMenuWithMessage(message);
						return;
					}
					levelBase = modManager.LoadLevel(modLevelInfo.Value);
				}
				_levelBaseScript = levelBase;
				LevelBase.CurrentLevel = levelBase;
				string text = PlayerPrefs.GetString("AircraftLoadOverride");
				if (string.IsNullOrEmpty(text))
				{
					text = (string.IsNullOrEmpty(_levelBaseScript.AircraftId) ? Game.Instance.SelectedCraftId : _levelBaseScript.AircraftId);
				}
				else
				{
					PlayerPrefs.DeleteKey("AircraftLoadOverride");
				}
				XElement xElement = Game.Instance.CraftDatabase.LoadCraftXml(text, showErrorDialogs: true);
				if (xElement == null)
				{
					string arg = text;
					if (text != "__editor__.xml")
					{
						text = "__editor__.xml";
						xElement = Game.Instance.CraftDatabase.LoadCraftXml(text, showErrorDialogs: false);
					}
					if (xElement == null)
					{
						foreach (CraftFileInfo craft in Game.Instance.CraftDatabase.GetCrafts())
						{
							xElement = craft.LoadXml(showErrorDialogs: false);
							if (xElement != null)
							{
								break;
							}
						}
					}
					if (xElement == null)
					{
						Debug.LogError("No designs could be loaded, falling back ");
						xElement = Game.Instance.CraftDatabase.LoadBuiltinCraftXml("__new__", showErrorDialogs: false);
						Game.Instance.UserInterface.CreateMessageDialog().MessageText = "No aircraft designs could be loaded.  Please clear your devices cache, or reinstall the application";
					}
					else
					{
						string text2 = $"The requested aircraft design could not be loaded \"{arg}\": loading alternative aircraft.";
						Debug.LogWarning(text2);
						Game.Instance.UserInterface.CreateMessageDialog().MessageText = text2;
					}
				}
				FlightSceneScript instance = FlightSceneScript.Instance;
				_levelBaseScript.transform.parent = base.transform;
				_levelBaseScript.transform.localScale = Vector3.one;
				_levelBaseScript.transform.position = Vector3.zero;
				_levelBaseScript.SceneRoot = base.transform;
				_levelBaseScript.WorldRigidbodiesContainer = new GameObject("WorldRigidbodiesContainer").transform;
				_levelBaseScript.WorldRigidbodiesContainer.parent = _levelBaseScript.SceneRoot;
				_levelBaseScript.FlightUI = FlightSceneScript.Instance.FlightUI;
				_levelBaseScript.Arrow = Utilities.GetFirstChild<Transform>("Arrow", instance.RenderingManager);
				_levelBaseScript.ArrowContainer = Utilities.GetFirstChild<Transform>("ArrowContainer", instance.RenderingManager);
				_levelBaseScript.WindGizmoContainer = Utilities.GetFirstChild<Transform>("WindGizmoContainer", instance.RenderingManager);
				_levelBaseScript.WindGizmo = Utilities.GetFirstChild<WindGizmoScript>("WindGizmo", instance.RenderingManager);
				_levelBaseScript.Terrain = mapLoadResult.Terrain;
				_levelBaseScript.WaterSplashManager = WaterSplashManager;
				_levelBaseScript.WaterVolume = Water.Find("WaterVolume").gameObject;
				LoadSky();
				if (levelBase.TimeOfDay > 0f)
				{
					instance.Environment.TimeOfDay = levelBase.TimeOfDay;
				}
				if (!ValidateLevelLoad())
				{
					Game.Instance.SceneManager.LoadLevelMenuWithMessage("An error occurred trying to load the level.");
				}
				else
				{
					CrashDetection.ClearFlag();
				}
			}
			catch (Exception ex)
			{
				string text3 = ((Game.Instance.CurrentLevel == null) ? "unknown" : Game.Instance.CurrentLevel.Name);
				this.LogException(ex, "An error occurred trying to load the level '{0}': {1}", text3, ex.Message);
				Game.Instance.SceneManager.LoadLevelMenuWithMessage("An error occurred trying to load the level.");
			}
		}

		protected virtual void OnDestroy()
		{
			UnloadSky();
		}

		protected virtual void Start()
		{
			ConfigureQualitySettings();
		}

		private void ConfigureFog()
		{
		}

		private void ConfigureQualitySettings()
		{
			_ = Game.Instance.Device.IsDesktopBuild;
			_ = Game.Instance.Settings.Quality.General;
			Utilities.FindFirstGameObjectMyselfOrChildren("ShadowCatcher", Water.gameObject);
			GameObject gameObject = null;
			gameObject = UnityEngine.Object.Instantiate(Resources.Load("Environment/Water/Crest/CrestOcean")) as GameObject;
			WaterNumTiles = 1;
			WaterScale = gameObject.transform.localScale.x;
			gameObject.transform.parent = Water;
			ConfigureFog();
		}

		private void LoadSky()
		{
			FlightSceneScript.Instance.Environment.OnLevelLoaded();
		}

		private void UnloadSky()
		{
			FlightSceneScript.Instance.Environment.OnLevelUnloaded();
		}

		private bool ValidateLevelLoad()
		{
			List<string> list = new List<string>();
			if (LevelBase.CurrentLevel == null)
			{
				list.Add("CurrentLevel is null");
			}
			else
			{
				if (LevelBase.CurrentLevel.LevelLoader == null)
				{
					list.Add("LevelLoader on LevelBase is null");
				}
				if (LevelBase.CurrentLevel.SceneRoot == null)
				{
					list.Add("SceneRoot on LevelBase is null");
				}
				if (LevelBase.CurrentLevel.WorldRigidbodiesContainer == null)
				{
					list.Add("WorldRigidBodiesContainer on LevelBase is null");
				}
			}
			if (Water == null)
			{
				list.Add("Water is null");
			}
			if (_levelBaseScript == null)
			{
				list.Add("_levelBaseScript is null");
			}
			if (list.Count > 0)
			{
				this.LogException("One or more level load validation errors occurred: {0}{1}", System.Environment.NewLine, string.Join(System.Environment.NewLine, list.ToArray()));
			}
			return list.Count == 0;
		}
	}
}
