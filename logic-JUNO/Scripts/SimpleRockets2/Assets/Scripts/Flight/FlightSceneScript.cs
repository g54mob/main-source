using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.DevConsole;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.ScaledSpace;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Input;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Services.Analytics;
using Assets.Scripts.State;
using Assets.Scripts.Terrain.Rendering;
using Assets.Scripts.Tools;
using Assets.Scripts.Ui;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using Assets.Scripts.Ui.Sharing.Screenshot;
using ModApi;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Flight.Events;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Input;
using ModApi.Ioc;
using ModApi.Planet;
using ModApi.Scenes.Events;
using ModApi.Scenes.Parameters;
using ModApi.Services.Purchasing;
using ModApi.Settings.Core;
using ModApi.State;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class FlightSceneScript : MonoBehaviour, IFlightScene
	{
		private static class ProcessNodeTreeFlightLateUpdate
		{
			public static double DeltaTimeWorld;

			public static Action<INode> FlightLateUpdate = delegate(INode n)
			{
				n.FlightLateUpdate(DeltaTimeWorld);
			};
		}

		private static class ProcessNodeTreeFlightUpdate
		{
			public static double DeltaTimeWorld;

			public static double FlightStateTime;

			public static Action<INode> FlightUpdate = delegate(INode n)
			{
				n.FlightUpdate(DeltaTimeWorld, FlightStateTime);
			};
		}

		private static FlightSceneScript _instance;

		private CraftNode _craftNode;

		private ExplosionManagerScript _explosionManager;

		private FlightSceneExitReason _flightSceneExitReason;

		[SerializeField]
		private FlightSceneInterfaceScript _flightSceneUi;

		private float _invincibilityTimer = 3f;

		private bool _isNewLaunch;

		private bool _saveFlightStateOnExit;

		private ISingleSoundManager _singleSoundManager;

		private TimeManager _timeManager;

		[SerializeField]
		private ViewManagerScript _viewManager;

		public static FlightSceneScript Instance => _instance;

		public static Action<IFlightScene> OnSingletonUpdated { get; set; }

		public static string ReturnToSceneAfterFlight { get; set; }

		public FlightSceneAnalytics Analytics { get; private set; }

		public PositionBiomeData CraftBiomeData { get; private set; }

		public ICraftNode CraftNode => _craftNode;

		public DragCalculatorScript DragCalculator { get; private set; }

		public int FixedUpdateFrameCount { get; private set; }

		public FlightControls FlightControls { get; private set; }

		public FlightLog FlightLog { get; private set; }

		public IFlightSceneUI FlightSceneUI => _flightSceneUi;

		public FlightState FlightState { get; private set; }

		IFlightState IFlightScene.FlightState => FlightState;

		public IFlightGameLoop GameLoop { get; private set; }

		public GameObject GameObject => base.gameObject;

		public IIocContainer IocContainer { get; private set; }

		public bool IsInitialized { get; private set; }

		public FlightSceneLoadParameters LoadParameters { get; private set; }

		public ISingleSoundManager SingleSoundManager => _singleSoundManager;

		public ITimeManager TimeManager => _timeManager;

		public bool VaporTrailsVisible { get; private set; }

		public ViewManagerScript ViewManager => _viewManager;

		IViewManager IFlightScene.ViewManager => _viewManager;

		public event FlightSceneCraftHandler ActiveCommandPodChanged;

		public event FlightSceneCraftHandler ActiveCommandPodStateChanged;

		public event FlightSceneCraftHandler CraftChanged;

		public event SimpleNotificationDelegate CraftStructureChanged;

		public event EventHandler<EventArgs> ExplosionCreated;

		public event EventHandler<FlightEndedEventArgs> FlightEnded;

		public event InitializedHandler<IFlightScene> Initialized
		{
			add
			{
				if (IsInitialized)
				{
					value(this);
				}
				else
				{
					_initialized += value;
				}
			}
			remove
			{
				_initialized -= value;
			}
		}

		public event PlayerChangedSoiHandler PlayerChangedSoi;

		private event InitializedHandler<IFlightScene> _initialized;

		public static bool IsCraftTooCloseToLaunchPosition(Vector3d existingCraftPosition, Vector3d launchPosition)
		{
			Vector3d lhs = existingCraftPosition - launchPosition;
			Vector3d normalized = launchPosition.normalized;
			double num = Mathd.Abs(Vector3d.Dot(lhs, normalized));
			if (Mathd.Sqrt(lhs.sqrMagnitude - num * num) < 100.0)
			{
				return num < 250.0;
			}
			return false;
		}

		public bool ChangePlayersActiveCommandPodImmediate(ICommandPod commandPod, ICraftNode craftNode, bool ignoreDistance = false)
		{
			double num = (int)Game.Instance.QualitySettings.Physics.PhysicsDistance * 1000 - 100;
			double num2 = ViewManager.GameView.PlanetScript.QuadSphere.TerrainMaxHeight + 20000.0;
			if (CraftNode.AltitudeAgl > num2 && craftNode.AltitudeAgl > num2)
			{
				num = craftNode.GameViewLoadDistance;
			}
			if ((double)(CraftNode.FramePosition - commandPod.Part.PartScript.Transform.position).magnitude < num || ignoreDistance)
			{
				CraftControls.ZeroControls(CraftNode.Controls, zeroOffsets: false);
				ViewManager.GameView.GameCamera.Recenter(immediate: true);
				CraftNode craftNode2 = craftNode as CraftNode;
				if (craftNode.CraftScript.ActiveCommandPod != commandPod)
				{
					craftNode2.CraftScript.SetActiveCommandPod(commandPod);
				}
				if (CraftNode != craftNode)
				{
					SetCraftNode(craftNode2);
				}
				craftNode.CraftScript.SetStructureChanged();
				craftNode.AllowPlayerControl = true;
				return true;
			}
			return false;
		}

		public void ChangePlayersActiveCraftNode(ICraftNode craftNode)
		{
			FlightState.PlayerNodeId = craftNode.NodeId;
			FlightSceneLoadParameters sceneLoadParameters = FlightSceneLoadParameters.ResumeCraft(FlightState.PlayerNodeId, craftNode.Parent.Name);
			ReloadFlightScene(saveFlightState: true, sceneLoadParameters, FlightSceneExitReason.CraftNodeChanged);
		}

		public void CreateExplosion(IEnumerable<PartData> parts, Vector3 position, Vector3 velocity, float magnitude, float magnitudeFromFuel)
		{
			_explosionManager.CreateExplosion(parts, position, velocity, magnitude, magnitudeFromFuel);
			this.ExplosionCreated?.Invoke(this, new EventArgs());
		}

		public void ExitFlightScene(bool saveFlightState, FlightSceneExitReason exitReason = FlightSceneExitReason.Unknown, string sceneName = null)
		{
			_saveFlightStateOnExit = saveFlightState;
			_flightSceneExitReason = exitReason;
			Time.timeScale = 1f;
			if (sceneName != null)
			{
				ReturnToSceneAfterFlight = sceneName;
			}
			if (ReturnToSceneAfterFlight == "Design")
			{
				Game.Instance.SceneManager.LoadDesigner();
			}
			else if (ReturnToSceneAfterFlight == "PlanetStudio")
			{
				Game.Instance.SceneManager.LoadPlanetStudio();
			}
			else if (ReturnToSceneAfterFlight == "Menu")
			{
				Game.Instance.SceneManager.LoadMenu();
			}
			else if (ReturnToSceneAfterFlight == "TechTree")
			{
				Game.Instance.SceneManager.LoadTechTree();
			}
			else
			{
				Game.Instance.SceneManager.LoadMenu();
			}
		}

		public void OnFixedUpdate(in FlightFrameData frame)
		{
			if (!frame.IsPaused && !frame.IsWarping)
			{
				FlightState.RootNode.UpdateRotation(frame.DeltaTime);
				ViewManager.GameView.UpdateReferenceFrame(frame.DeltaTime, timeWarp: false);
				Physics.gravity = _craftNode.CraftScript.GravityForce;
				FixedUpdateFrameCount++;
			}
		}

		public void OnLateUpdate(in FlightFrameData frame)
		{
			Game.Instance.GameState.Career?.OnFlightUpdate(in frame);
			ProcessNodeTreeFlightLateUpdate.DeltaTimeWorld = frame.DeltaTimeWorld;
			FlightState.ProcessNodeTree(ProcessNodeTreeFlightLateUpdate.FlightLateUpdate);
			FlightState.ProcessDestroyedCraftNodes();
			_timeManager.CheckCurrentTimeMultiplier(CraftNode);
			TerrainRendererManagerScript instance = TerrainRendererManagerScript.Instance;
			if (instance != null)
			{
				instance.UpdateQuadSphereRenderers();
			}
			ScaledSpaceScript instance2 = ScaledSpaceScript.Instance;
			if (instance2 != null)
			{
				instance2.OnLateUpdate();
			}
			if (!(_invincibilityTimer > 0f) || LoadParameters.AutoEnableCheats)
			{
				return;
			}
			_invincibilityTimer -= Time.deltaTime;
			if (!(_invincibilityTimer <= 0f))
			{
				return;
			}
			BodyCollisionHandler.BodyCollisionsEnabled = true;
			DevConsoleApi.RegisterCommand("IDDQD", delegate
			{
				if (Game.Instance.LevelManager.CurrentLevel == null)
				{
					BodyCollisionHandler.BodyCollisionsEnabled = !BodyCollisionHandler.BodyCollisionsEnabled;
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Your craft suddenly feels " + (BodyCollisionHandler.BodyCollisionsEnabled ? "less" : "more") + " robust.");
				}
				else
				{
					Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Command disabled during challenges.");
				}
			});
		}

		public void OnUpdate(in FlightFrameData frame)
		{
			OrbitMath.ReturnAllPoolItems();
			FlightState.TotalFlightTimeInRealtimeSeconds += Time.unscaledDeltaTime;
			FlightControls.Update(frame.DeltaTimeUnscaled);
			if (!frame.IsPaused)
			{
				double deltaTimeWorld = frame.DeltaTimeWorld;
				if (frame.IsWarping)
				{
					FlightState.RootNode.UpdateRotation(deltaTimeWorld);
					ViewManager.GameView.UpdateReferenceFrame(deltaTimeWorld, timeWarp: true);
				}
				FlightState.Time += deltaTimeWorld;
				ProcessNodeTreeFlightUpdate.DeltaTimeWorld = deltaTimeWorld;
				ProcessNodeTreeFlightUpdate.FlightStateTime = FlightState.Time;
				FlightState.ProcessNodeTree(ProcessNodeTreeFlightUpdate.FlightUpdate);
				IReadOnlyList<CraftNode> craftNodes = FlightState.CraftNodes;
				for (int i = 0; i < craftNodes.Count; i++)
				{
					CheckSoiTransition(craftNodes[i]);
				}
				FlightLog.Update(CraftNode, deltaTimeWorld);
			}
			MusicPlayer.Instance?.CalculateMusicIntensity(CraftNode.CraftScript);
			ViewManager.GameView.EndFrame();
			ProcessInputs();
			VaporTrailsVisible = ViewManager.GameView.CameraControllerManager.CurrentCameraController.VaporTrailsVisible;
		}

		public void QuickLoad()
		{
			GameState gameState = Game.Instance.GameState;
			string quicksaveTag = gameState.GetTagQuicksave();
			if (!string.IsNullOrWhiteSpace(quicksaveTag) & Game.Instance.GameState.Validator.IsItemAvailable("Cheats.QuickSave"))
			{
				if (Game.Instance.GameStateManager.CheckGameStateTagExists(gameState.Id, quicksaveTag))
				{
					TimeManager.RequestPauseChange(paused: true, userInitiated: false);
					ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
					messageDialogScript.MessageText = "Confirm that you wish to restore from your last quick save.";
					messageDialogScript.OkayButtonText = "RESTORE";
					messageDialogScript.UseDangerButtonStyle = true;
					messageDialogScript.OkayClicked += delegate
					{
						Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.UseQuickload);
						Game.Instance.GameStateManager.RestoreGameStateTag(gameState.Id, quicksaveTag, gameState.GetTagActive());
						ReloadFlightScene(saveFlightState: false, FlightSceneLoadParameters.ResumeCraft(), FlightSceneExitReason.QuickLoad);
					};
					messageDialogScript.CancelClicked += delegate(ModApi.Ui.MessageDialogScript d)
					{
						TimeManager.RequestPauseChange(paused: false, userInitiated: false);
						d.Close();
					};
				}
				else
				{
					FlightSceneUI.ShowMessage("No quick save available");
				}
			}
			else
			{
				FlightSceneUI.ShowMessage("Quick Load is currently disabled");
			}
		}

		public void QuickSave()
		{
			GameState gameState = Game.Instance.GameState;
			string tagQuicksave = gameState.GetTagQuicksave();
			if (!string.IsNullOrWhiteSpace(tagQuicksave) & Game.Instance.GameState.Validator.IsItemAvailable("Cheats.QuickSave"))
			{
				FlightState.Save();
				gameState.Save();
				Game.Instance.GameStateManager.CopyGameStateTag(gameState.Id, gameState.GetTagActive(), tagQuicksave);
				FlightSceneUI.ShowMessage("Quick Save Complete");
			}
			else
			{
				FlightSceneUI.ShowMessage("Quick Save is currently disabled");
			}
		}

		public void RaiseActiveCommandPodStateChanged()
		{
			this.ActiveCommandPodStateChanged?.Invoke(_craftNode);
		}

		public void Relaunch(LaunchLocation launchLocation)
		{
			FlightSceneLoadParameters flightSceneLoadParameters = Game.Instance.SceneManager.FlightSceneLoadParameters;
			if (flightSceneLoadParameters == null)
			{
				flightSceneLoadParameters = FlightSceneLoadParameters.NewCraft(CraftDesigns.EditorCraftId, CraftNode.CraftScript.Data.Name, launchLocation, 0L);
			}
			flightSceneLoadParameters.LaunchLocation = launchLocation;
			flightSceneLoadParameters.LoadingScreen = launchLocation.PlanetName;
			ReloadFlightScene(saveFlightState: false, flightSceneLoadParameters, FlightSceneExitReason.Relaunch);
		}

		public void ReloadFlightScene(bool saveFlightState, FlightSceneLoadParameters sceneLoadParameters, FlightSceneExitReason exitReason = FlightSceneExitReason.Unknown)
		{
			_saveFlightStateOnExit = saveFlightState;
			_flightSceneExitReason = exitReason;
			Game.Instance.SceneManager.LoadFlight(sceneLoadParameters);
		}

		public void SaveLaunchLocationPrompt()
		{
			if (Game.IsCareer && !CareerState.IsDebugMode && !Game.Instance.GameState.Validator.IsItemAvailable("Cheats.CustomLaunch"))
			{
				return;
			}
			IInAppPurchaseFeatures<IInAppPurchaseFeature> features = Game.Instance.InAppPurchases.Features;
			if (!features.IsFeatureUnlocked(features.LaunchLocationsCustom, "unlock the ability to save and load custom launch locations."))
			{
				return;
			}
			TimeManager.RequestPauseChange(paused: true, userInitiated: false);
			ModApi.Ui.InputDialogScript inputDialogScript = Game.Instance.UserInterface.CreateInputDialog();
			inputDialogScript.MessageText = "Save Launch Location";
			bool useCameraLocation = false;
			if (DebugInput.GetKey(KeyCode.RightShift))
			{
				useCameraLocation = true;
				inputDialogScript.MessageText += " (using camera location).";
			}
			inputDialogScript.InputPlaceholderText = "Launch Location Name";
			inputDialogScript.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				string name = d.InputText;
				if (CelestialBodyDesignerScript.TestFlightLaunchLocations != null)
				{
					LaunchLocation item = CreateLaunchLocation(name, useCameraLocation);
					CelestialBodyDesignerScript.TestFlightLaunchLocations.Add(item);
				}
				else
				{
					LaunchLocation existingLaunchLocation = Game.Instance.GameState.LaunchLocations.FirstOrDefault((LaunchLocation x) => x.Name == name && x.UserCreated);
					if (existingLaunchLocation != null)
					{
						ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
						messageDialogScript.MessageText = "A launch location with that name already exists. Do you want to overwrite it?";
						messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript od)
						{
							Game.Instance.GameState.LaunchLocations.Remove(existingLaunchLocation);
							SaveLaunchLocation(name, useCameraLocation);
							od.Close();
						};
						messageDialogScript.CancelClicked += delegate(ModApi.Ui.MessageDialogScript od)
						{
							od.Close();
						};
					}
					else
					{
						SaveLaunchLocation(name, useCameraLocation);
					}
				}
				d.Close();
			};
		}

		public void SetPlayerSpeed()
		{
			ModApi.Ui.InputDialogScript dialog = Game.Instance.UserInterface.CreateInputDialog();
			dialog.MessageText = "Overriding the current craft surface speed.<br>Set the new speed in m/s.";
			dialog.InputText = "0";
			dialog.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				d.Close();
				if (float.TryParse(dialog.InputText, out var result))
				{
					Vector3d surfacePoint = CraftNode.Parent.PlanetVectorToSurfaceVector(CraftNode.Position);
					Vector3d vector3d = CraftNode.CraftScript.FlightData.SurfaceVelocity;
					if (vector3d.magnitude < 5.0)
					{
						vector3d = CraftNode.ReferenceFrame.FrameToPlanetVector(CraftNode.CraftScript.CenterOfMass.forward);
					}
					Vector3d velocity = CraftNode.Parent.SurfaceVectorToPlanetVector(CraftNode.Parent.CalculateSurfaceVelocity(surfacePoint)) + vector3d.normalized * result;
					CraftNode.SetStateVectors(CraftNode.Position, velocity, CraftNode.Orbit.Time);
					CraftNode.RecalculateFrameState(ViewManager.GameView.ReferenceFrame);
				}
				else
				{
					FlightSceneUI.ShowMessage("Invalid input, it has to be a number.");
				}
			};
		}

		public CraftNode SpawnCraft(string craftNodeName, CraftData craftData, LaunchLocation location, XElement pendingXml = null)
		{
			float value = 0f - craftData.InitialBoundsMin.y;
			IPlanetNode planetNode = FlightState.RootNode.FindPlanet(location.PlanetName);
			bool num = !planetNode.IsTerrainDataLoaded;
			planetNode.LoadTerrainData();
			Vector3d position = location.OrbitalPosition;
			Vector3d velocity = location.Velocity;
			Quaterniond heading = Quaterniond.identity;
			if (location.LocationType != LaunchLocationType.Orbital)
			{
				Vector3d surfacePosition = planetNode.GetSurfacePosition(location.Latitude * (Math.PI / 180.0), location.Longitude * (Math.PI / 180.0), AltitudeType.AboveGroundLevel, location.AltitudeAboveGroundLevel, value);
				position = planetNode.SurfaceVectorToPlanetVector(surfacePosition);
				velocity = ((location.LocationType != LaunchLocationType.SurfaceLockedGround) ? (planetNode.Rotation * location.Velocity) : (planetNode.Rotation * planetNode.CalculateSurfaceVelocity(surfacePosition.normalized * planetNode.PlanetData.Radius)));
				heading = planetNode.Rotation * location.Rotation;
			}
			else if (location.Orbit != null)
			{
				Orbit orbit = new Orbit(location.Orbit, planetNode.PlanetData.Mass);
				position = orbit.Position;
				velocity = orbit.Velocity;
			}
			CraftNode craftNode = new CraftNode(new CraftNodeDataStatic(craftNodeName, position, velocity, heading, hasCommandPod: true), FlightState, planetNode.PlanetData.Mass, craftData, null, pendingXml)
			{
				InitialLaunch = true,
				InitialLaunchHeadingIsDirectionOfTravel = (location.LocationType == LaunchLocationType.Orbital || location.LocationType == LaunchLocationType.SurfaceLockedAir)
			};
			planetNode.AddChildNode(craftNode);
			FlightState.AddCraft(craftNode, null);
			craftNode.Initialize();
			craftNode.SetInitialCraftNodeData(location, FlightState.Time);
			if (num)
			{
				planetNode.UnloadTerrainData();
			}
			return craftNode;
		}

		public void SwitchLocation(LaunchLocation launchLocation)
		{
			Game.Instance.GameState.SelectedLaunchLocation = launchLocation;
			Game.Instance.GameState.Save();
			Game.Instance.BeginFlight(CraftDesigns.EditorCraftId, CraftNode.CraftScript.Data.Name, "Design", 0L);
		}

		public void TeleportPlayer()
		{
			IPartScript selectedPart = ViewManager.GameView.SelectedPart;
			if (selectedPart != null && selectedPart.GetModifier<DockingPortScript>() != null && selectedPart.CraftScript != CraftNode.CraftScript)
			{
				GetDistanceAndTP("Teleporting in front of a docking port.<br>How far from it do you want to be?");
				return;
			}
			INavSphereTarget target = FlightSceneUI.NavSphere.Target;
			if (target == null)
			{
				GetDistanceAndTP("Teleporting up.<br>By how much?");
			}
			else if (target is PlanetNode planetNode)
			{
				GetCoordsAndTP("Teleporting to " + planetNode.Name + ".<br>Choose the coordinates as 'Lat, Lon, AGL'");
			}
			else if (target.Parent == CraftNode.Parent)
			{
				GetDistanceAndTP("Teleporting to the target craft.<br>How high do you want to be relative to it?");
			}
			else
			{
				FlightSceneUI.ShowMessage("Cannot teleport to a target on another planet.");
			}
		}

		public void UpdateActiveControlMaps(ICraftNode craftNode)
		{
			Action<ICraftScript> updateControlMaps = delegate(ICraftScript craftScript)
			{
				bool flag = false;
				if (craftScript.ActiveCommandPod != null)
				{
					flag = craftScript.ActiveCommandPod.IsEva && craftScript.ActiveCommandPod.EvaScript.EvaControlScheme == EvaControlSchemeType.Eva;
				}
				else
				{
					Debug.LogError($"The ActiveCommandPod of {craftNode?.Name} (ID={craftNode?.NodeId}) was null");
				}
				InputWrapper.SetMapEnabled("FlightEva", flag);
				InputWrapper.SetMapEnabled("FlightCraft", !flag);
			};
			if (craftNode.CraftScript == null)
			{
				GameViewObjectHandler setControlMaps = null;
				setControlMaps = delegate(IGameViewObject x)
				{
					updateControlMaps(((ICraftNode)x).CraftScript);
					craftNode.LoadedIntoGameView -= setControlMaps;
				};
				_craftNode.LoadedIntoGameView += setControlMaps;
			}
			else
			{
				updateControlMaps(_craftNode.CraftScript);
			}
		}

		protected virtual void Awake()
		{
			try
			{
				Game.EnsureInitialized();
				IocContainer = new IocContainer();
				_instance = this;
				OnSingletonUpdated(this);
				MemoryLeakUtility.Track(this);
				_saveFlightStateOnExit = false;
				Game.Instance.SceneManager.SceneUnloading += OnSceneUnloading;
				GameLoop = Game.Loop.CreateFlightLoop();
				Game.Instance.ThemeManager.DestroyAllThemes();
				FlightSceneLoadParameters flightSceneLoadParameters = (LoadParameters = Game.Instance.SceneManager.FlightSceneLoadParameters ?? new FlightSceneLoadParameters());
				IFlightStateData flightStateData2;
				if (flightSceneLoadParameters.FlightStateDataLoader == null)
				{
					IFlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
					flightStateData2 = flightStateData;
				}
				else
				{
					flightStateData2 = flightSceneLoadParameters.FlightStateDataLoader();
				}
				IFlightStateData flightStateData3 = flightStateData2;
				FlightState = new FlightState(flightStateData3, FlightStateLoadContext.Flight);
				FlightState.SolarSystemData.ApplyCustomSkybox();
				_isNewLaunch = !string.IsNullOrWhiteSpace(flightSceneLoadParameters.LaunchCraftId);
				if (!_isNewLaunch)
				{
					FlightSceneLoadParameters flightSceneLoadParameters3 = flightSceneLoadParameters;
					int? resumeCraftNodeId = flightSceneLoadParameters3.ResumeCraftNodeId;
					int valueOrDefault = resumeCraftNodeId.GetValueOrDefault();
					if (!resumeCraftNodeId.HasValue)
					{
						valueOrDefault = FlightState.PlayerNodeId;
						int? num = (flightSceneLoadParameters3.ResumeCraftNodeId = valueOrDefault);
					}
				}
				Analytics = (Game.Instance.Analytics.Enabled ? new FlightSceneAnalytics(Game.Instance.GameState) : null);
				Analytics?.OnFlightStart();
				DragCalculator = GetComponentInChildren<DragCalculatorScript>();
				BodyScript.EnableDragLift = Game.Instance.QualitySettings.Physics.EnableDragLift;
				DragPhysics.HeatDamageEnabled = flightSceneLoadParameters.HeatDamage ?? ((float)Game.Instance.Settings.Game.Flight.HeatDamageScale > 0f || (Game.IsCareer && !Game.Instance.GameState.Validator.IsItemAvailable("Cheats.FlightCheats")));
				_explosionManager = GetComponentInChildren<ExplosionManagerScript>();
				_timeManager = new TimeManager(this);
				FlightLog = new FlightLog(_isNewLaunch, Game.Instance.GameState.PreflightLoadParameters?.LaunchCost ?? 0);
				FlightControls = new FlightControls(_flightSceneUi.NavSphere);
				CraftBiomeData = new PositionBiomeData();
				_singleSoundManager = base.gameObject.AddComponent<SingleSoundManager>();
				InputWrapper.ControlMapsChanged += OnControlsMapsChanged;
				CraftNode craftNode = null;
				if (_isNewLaunch)
				{
					craftNode = LaunchNewCraft(flightSceneLoadParameters.LaunchCraftId, flightSceneLoadParameters.LaunchCraftNodeName, flightSceneLoadParameters.LaunchLocation);
				}
				else
				{
					craftNode = FlightState.GetCraftNode(flightSceneLoadParameters.ResumeCraftNodeId.Value);
					if (craftNode != null)
					{
						if (FlightState.CheckCraftXmlExists(craftNode.NodeId))
						{
							FlightState.PlayerNodeId = craftNode.NodeId;
						}
						else
						{
							craftNode = null;
							Debug.LogError($"Could not load craft XML for craft node with ID '{flightSceneLoadParameters.ResumeCraftNodeId.Value}'.");
						}
					}
					else
					{
						Debug.LogError($"Could not load craft with ID {flightSceneLoadParameters.ResumeCraftNodeId.Value}. A craft with that ID could not be found.");
					}
				}
				if (craftNode != null)
				{
					craftNode.Parent.LoadTerrainData();
					FlightSceneBenchmarkScript currentBenchmark = FlightSceneBenchmarkScript.CurrentBenchmark;
					if (currentBenchmark != null && currentBenchmark.CraftStartPosition.HasValue)
					{
						craftNode.SetStateVectorsAtDefaultTime(currentBenchmark.CraftStartPosition.Value, craftNode.Velocity);
					}
					SetCraftNode(craftNode);
				}
				else
				{
					Debug.LogError("Could not load craft. Reverting to designer.");
					Game.Instance.SceneManager.DeactivateCurrentScene();
					Game.Instance.SceneManager.LoadDesigner();
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("An error occurred initializing the flight scene.");
				Game.Instance.SceneManager.DeactivateCurrentScene();
				Game.Instance.SceneManager.LoadMenu();
			}
		}

		protected virtual void OnDestroy()
		{
			Game.Instance.SceneManager.SceneUnloading -= OnSceneUnloading;
			_timeManager?.Dispose();
			_timeManager = null;
			DevConsoleApi.UnregisterCommand("MLI");
			DevConsoleApi.UnregisterCommand("IDDQD");
			DevConsoleApi.UnregisterCommand("tp");
			DevConsoleApi.UnregisterCommand("tpplanet");
			DevConsoleApi.UnregisterCommand("velSurface");
			DevConsoleApi.UnregisterCommand("CameraCoords");
			Game.Loop.DestroyFlightLoop();
			_instance = null;
			OnSingletonUpdated(null);
		}

		protected virtual void Start()
		{
			BodyCollisionHandler.BodyCollisionsEnabled = false;
			if (FlightSceneBenchmarkScript.CurrentBenchmark != null)
			{
				FlightSceneBenchmarkScript.CurrentBenchmark.StartBenchmark();
			}
			GameStateType type = Game.Instance.GameState.Type;
			if (type == GameStateType.Default || type == GameStateType.Simulation)
			{
				ApplicationState.FlightInProgress = true;
				if (!Device.IsUnityEditor)
				{
					StartCoroutine(AutosaveCoroutine());
				}
			}
			_timeManager.SetNormalSpeedMode();
			FlightState.ProcessNodeTree(delegate(INode n)
			{
				n.FlightStart();
			});
			ViewManager.Initialize();
			if (Game.Instance.GameState.Career?.Contracts != null)
			{
				Game.Instance.GameState.Career?.OnFlightStart(this, _isNewLaunch);
			}
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				this._initialized?.Invoke(this);
				IsInitialized = true;
				this._initialized = null;
				if (!Physics.autoSyncTransforms)
				{
					Physics.SyncTransforms();
				}
			});
			DevConsoleApi.RegisterCommand("MLI", delegate
			{
				if (Instance != null)
				{
					Instance.ToggleInfiniteFuel();
				}
			});
			DevConsoleApi.RegisterCommand("tpplanet", delegate(string planet, double lat, double lon, double agl)
			{
				Debug.LogFormat($"Teleport: {planet}, {lat}, {lon}, {agl}");
				Relaunch(new LaunchLocation("Teleport", LaunchLocationType.SurfaceLockedGround, planet, lat, lon, Vector3d.zero, 0.0, agl));
			});
			DevConsoleApi.RegisterCommand("tp", delegate(double distance)
			{
				if (Instance != null)
				{
					Instance.TeleportPlayerToTarget(distance);
				}
			});
			DevConsoleApi.RegisterCommand("velSurface", delegate(double velocityMagnitude)
			{
				Debug.LogFormat($"Set craft surface velocity: {velocityMagnitude:n2}");
				Vector3d surfacePoint = CraftNode.Parent.PlanetVectorToSurfaceVector(CraftNode.Position);
				Vector3d vector3d = CraftNode.CraftScript.FlightData.SurfaceVelocity;
				if (vector3d.magnitude < 5.0)
				{
					vector3d = CraftNode.ReferenceFrame.FrameToPlanetVector(CraftNode.CraftScript.CenterOfMass.forward);
				}
				Vector3d velocity = CraftNode.Parent.SurfaceVectorToPlanetVector(CraftNode.Parent.CalculateSurfaceVelocity(surfacePoint)) + vector3d.normalized * velocityMagnitude;
				CraftNode.SetStateVectors(CraftNode.Position, velocity, CraftNode.Orbit.Time);
				CraftNode.RecalculateFrameState(ViewManager.GameView.ReferenceFrame);
			});
			DevConsoleApi.RegisterCommand("CameraCoords", delegate
			{
				Vector3d planetPosition = ViewManager.GameView.GameCamera.PlanetPosition;
				Vector3d surfacePosition = CraftNode.Parent.PlanetVectorToSurfaceVector(planetPosition);
				CraftNode.Parent.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
				double height = CraftNode.Parent.GetTerrainVertexData(VertexDataRequestType.AllData, planetPosition, planetPosition).Height;
				double num = ViewManager.GameView.GameCamera.AltitudeAboveSeaLevel - height;
				Debug.Log($"Camera Lat,Lon,AGL: {latitude * 57.29578},{longitude * 57.29578},{num}");
			});
			if (LoadParameters.AutoEnableCheats)
			{
				Game.InfiniteFuelEnabled = true;
				BodyCollisionHandler.BodyCollisionsEnabled = false;
			}
		}

		private IEnumerator AutosaveCoroutine()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			while (true)
			{
				Debug.Log("Auto-saving flight...");
				FlightState.Save();
				Game.Instance.GameState.Save();
				Debug.Log("Auto-save flight complete.");
				yield return new WaitForSecondsRealtime(300f);
			}
		}

		private void CheckSoiTransition(ShipNode ship)
		{
			IPlanetNode parent = ship.Parent.Parent;
			if (parent != null && ship.Position.magnitude > ship.Parent.SphereOfInfluenceExitDistance)
			{
				TransitionShipToNewPlanetSoi(ship, parent, ship.Position + ship.Parent.Position, ship.Velocity + ship.Parent.Velocity);
				return;
			}
			IReadOnlyList<IPlanetNode> childPlanets = ship.Parent.ChildPlanets;
			for (int i = 0; i < childPlanets.Count; i++)
			{
				IPlanetNode planetNode = childPlanets[i];
				if ((ship.Position - planetNode.Position).magnitude < planetNode.SphereOfInfluence)
				{
					TransitionShipToNewPlanetSoi(ship, planetNode, ship.Position - planetNode.Position, ship.Velocity - planetNode.Velocity);
					break;
				}
			}
		}

		private void ClearStartLocation(CraftNode craftNode)
		{
			CraftNode[] array = FlightState.CraftNodes.ToArray();
			foreach (CraftNode craftNode2 in array)
			{
				if (craftNode2 != craftNode && IsCraftTooCloseToLaunchPosition(craftNode2.Position, craftNode.Position))
				{
					try
					{
						new CraftRecovery(Game.Instance.GameState, craftNode2.LoadCraftData(), craftNode2.CraftMass, new CraftNodeDataDynamic(craftNode2), craftNode2.Parent).RecoverCraft();
						craftNode2.DestroyCraft();
					}
					catch (Exception ex)
					{
						Debug.LogError("Unable to recover craft.\n" + ex.ToString());
					}
				}
			}
		}

		private LaunchLocation CreateLaunchLocation(string name, bool useCameraPosition)
		{
			PlanetNode planetNode = CraftNode.Parent as PlanetNode;
			bool flag = CraftNode.InContactWithPlanet || (CraftNode.IsDestroyed && CraftNode.AltitudeAgl < 1000.0);
			if (planetNode.PlanetData.HasWater && CraftNode.Altitude < 200.0 && planetNode.GetTerrainHeight(CraftNode.Position) < (double)planetNode.PlanetData.SeaLevel)
			{
				flag = true;
			}
			Vector3d position = CraftNode.Position;
			Vector3d velocity = CraftNode.Velocity;
			if (useCameraPosition)
			{
				position = ViewManager.GameView.GameCamera.PlanetPosition;
				velocity = Vector3d.zero;
				flag = true;
			}
			LaunchLocationType type = ((!flag) ? ((!(CraftNode.Altitude > planetNode.PlanetData.AtmosphereData.Height)) ? LaunchLocationType.SurfaceLockedAir : LaunchLocationType.Orbital) : LaunchLocationType.SurfaceLockedGround);
			LaunchLocation launchLocation = LaunchLocation.CreateLaunchLocation(name, planetNode, position, velocity, CraftNode.Heading, ViewManager.GameView.ReferenceFrame, type);
			if (flag)
			{
				launchLocation.HeadingSimple = CraftNode.CraftScript.FlightData.Heading + 180.0;
			}
			launchLocation.UserCreated = true;
			return launchLocation;
		}

		private void FlightEnd()
		{
			this.FlightEnded?.Invoke(this, new FlightEndedEventArgs(_flightSceneExitReason));
			Game.Instance.SceneManager.SceneUnloading -= OnSceneUnloading;
			InputWrapper.ControlMapsChanged -= OnControlsMapsChanged;
			ViewManager.GameView.FlightEnd();
			foreach (CraftNode craftNode in FlightState.CraftNodes)
			{
				if (craftNode.DestroyOnExitFlightScene)
				{
					craftNode.DestroyCraft();
				}
			}
			Game.Instance.GameState.Career?.OnFlightEnd();
			FlightState.ProcessDestroyedCraftNodes();
			Analytics?.OnFlightEnd(FlightState, _flightSceneExitReason, _isNewLaunch, _saveFlightStateOnExit);
			if (_saveFlightStateOnExit)
			{
				FlightState.Save();
				Game.Instance.GameState.Save();
			}
			FlightState.ProcessNodeTree(delegate(INode n)
			{
				n.FlightEnd();
			});
			FlightState.Destroy();
			FlightState = null;
			_timeManager.FlightEnd();
			_timeManager.Dispose();
			_timeManager = null;
			Time.timeScale = 1f;
			_craftNode = null;
			this.FlightEnded = null;
			this.ActiveCommandPodChanged = null;
			this.CraftChanged = null;
			this.PlayerChangedSoi = null;
			this._initialized = null;
			FlightSceneLoadParameters loadParameters = LoadParameters;
			if (loadParameters != null && loadParameters.AutoEnableCheats)
			{
				Game.InfiniteFuelEnabled = false;
				BodyCollisionHandler.BodyCollisionsEnabled = true;
			}
			_instance = null;
			OnSingletonUpdated(null);
		}

		private void GetCoordsAndTP(string message)
		{
			ModApi.Ui.InputDialogScript dialog = Game.Instance.UserInterface.CreateInputDialog();
			dialog.MessageText = message;
			dialog.InputText = "0, 0, 0";
			dialog.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				d.Close();
				if (Vector3d.TryParse(dialog.InputText, out var result))
				{
					TeleportPlayerToTarget(result.z, result.x, result.y);
				}
				else
				{
					FlightSceneUI.ShowMessage("Invalid input, it has to be in the format 'Lat, Lon, AGL'.");
				}
			};
		}

		private void GetDistanceAndTP(string message)
		{
			ModApi.Ui.InputDialogScript dialog = Game.Instance.UserInterface.CreateInputDialog();
			dialog.MessageText = message;
			dialog.InputText = "0";
			dialog.OkayClicked += delegate(ModApi.Ui.InputDialogScript d)
			{
				d.Close();
				if (float.TryParse(dialog.InputText, out var result))
				{
					TeleportPlayerToTarget(result);
				}
				else
				{
					FlightSceneUI.ShowMessage("Invalid input, it has to be a number.");
				}
			};
		}

		private CraftNode LaunchNewCraft(string craftId, string craftNodeName, LaunchLocation location)
		{
			if (location == null)
			{
				throw new Exception("Launch location not set. Unable to launch craft.");
			}
			if (LoadParameters.LaunchCost > 0)
			{
				Game.Instance.GameState.Career?.SpendMoney(LoadParameters.LaunchCost);
			}
			CraftData craftData = Game.Instance.CraftLoader.LoadCraftImmediate(craftId);
			CraftNode craftNode = SpawnCraft(craftNodeName, craftData, location);
			FlightState.PlayerNodeId = craftNode.NodeId;
			ClearStartLocation(craftNode);
			return craftNode;
		}

		private void OnControlsMapsChanged(object sender, EventArgs e)
		{
			if (_craftNode != null)
			{
				UpdateActiveControlMaps(_craftNode);
			}
			else
			{
				Debug.LogError("Craft node is null and its craft specific control maps cannot be updated.");
			}
		}

		private void OnPlayerCraftActiveCommandPodChanged(ICraftScript source, ICommandPod newPod, ICommandPod oldPod)
		{
			UpdateActiveControlMaps(_craftNode);
			this.ActiveCommandPodChanged?.Invoke(_craftNode);
		}

		private void OnPlayerCraftStructureChanged()
		{
			this.CraftStructureChanged?.Invoke();
		}

		private void OnSceneUnloading(object sender, SceneEventArgs e)
		{
			if (e.Scene == "Flight")
			{
				FlightEnd();
			}
		}

		private void ProcessInputs()
		{
			IUserInterface userInterface = Game.Instance.UserInterface;
			if (userInterface.AnyDialogsOpen || userInterface.IsTextInputFocused)
			{
				return;
			}
			IGameInputs inputs = Game.Instance.Inputs;
			if (inputs.ToggleMapView.GetButtonDownIfEnabled())
			{
				ViewManager.ToggleMapView();
			}
			if (inputs.ToggleNavSphere.GetButtonDownIfEnabled())
			{
				FlightSceneUI.SetNavSphereVisibility(!FlightSceneUI.NavSphereVisible, updateSettings: true);
			}
			if (inputs.Pause.GetButtonDownIfEnabled())
			{
				bool flag = !TimeManager.Paused;
				if (flag)
				{
					_flightSceneUi.ShowMessage("Paused");
				}
				else
				{
					_flightSceneUi.ShowMessage("Unpaused");
				}
				TimeManager.RequestPauseChange(flag, userInitiated: true);
			}
			else if (inputs.QuickSave.GetButtonDownIfEnabled())
			{
				QuickSave();
			}
			else if (inputs.QuickLoad.GetButtonDownIfEnabled())
			{
				QuickLoad();
			}
			else if (inputs.SaveLaunchLocation.GetButtonDownIfEnabled())
			{
				SaveLaunchLocationPrompt();
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) || inputs.FlightOpenMenu.GetButtonDownIfEnabled())
			{
				if (!FlightSceneUI.Visible)
				{
					FlightSceneUI.Visible = true;
				}
			}
			else if ((DebugInput.GetKeyDown(KeyCode.KeypadPlus) || DebugInput.GetKeyDown(KeyCode.KeypadMinus)) && DebugInput.GetKey(KeyCode.LeftShift))
			{
				NumericSetting<float> userInterfaceScale = Game.Instance.Settings.Game.General.UserInterfaceScale;
				float value = userInterfaceScale.Value;
				value = ((!DebugInput.GetKeyDown(KeyCode.KeypadPlus)) ? (value * 0.9f) : (value * 1.1f));
				value = Mathf.Clamp(value, 0.5f, 1.5f);
				userInterfaceScale.UpdateAndCommit(value);
				Debug.LogFormat("Changed UI Scale: {0:n3}", value);
			}
			else if (DebugInput.GetKeyDown(KeyCode.F4))
			{
				ToggleInfiniteFuel();
			}
			else if (DebugInput.GetKeyDown(KeyCode.F3))
			{
				Game.MaxWarpUnlocked = !Game.MaxWarpUnlocked;
				if (Game.MaxWarpUnlocked)
				{
					_flightSceneUi.ShowMessage("Max Warp Unlocked");
				}
				else
				{
					_flightSceneUi.ShowMessage("Max Warp Enforced");
				}
			}
			else if (DebugInput.GetKeyDown(KeyCode.F9))
			{
				ScenarioDialogScript.Create(FlightSceneUI.Transform);
			}
			else if (DebugInput.GetKey(KeyCode.LeftControl) && DebugInput.GetKey(KeyCode.LeftShift))
			{
				if (DebugInput.GetKeyDown(KeyCode.I))
				{
					ToggleInterpolation(RigidbodyInterpolation.Interpolate);
				}
				else if (DebugInput.GetKeyDown(KeyCode.E))
				{
					ToggleInterpolation(RigidbodyInterpolation.Extrapolate);
				}
			}
			else if (inputs.OpenPhotoLibrary.GetButtonDownIfEnabled())
			{
				TimeManager.RequestPauseChange(paused: true, userInitiated: false);
				PhotoLibraryDialogScript.Create(FlightSceneUI.Transform);
			}
			else if (inputs.ToggleHideUI.GetButtonDownIfEnabled())
			{
				FlightSceneUI.Visible = !FlightSceneUI.Visible;
			}
			else if (inputs.TimeWarpDecrease.GetButtonDownIfEnabled())
			{
				TimeManager.DecreaseTimeMultiplier();
			}
			else if (inputs.TimeWarpIncrease.GetButtonDownIfEnabled())
			{
				TimeManager.IncreaseTimeMultiplier();
			}
			else if (inputs.CommandPodPrevious.GetButtonDownIfEnabled())
			{
				SwitchToNextCommandPod(reverse: true);
			}
			else if (inputs.CommandPodNext.GetButtonDownIfEnabled())
			{
				SwitchToNextCommandPod(reverse: false);
			}
			else if (inputs.NextCameraMode.GetButtonDownIfEnabled())
			{
				ViewManager.GameView.CameraControllerManager.SwitchToNextViewMode(saveAsDefault: true, displayMessage: true);
			}
			else if (inputs.PreviousCameraMode.GetButtonDownIfEnabled())
			{
				ViewManager.GameView.CameraControllerManager.SwitchToNextViewMode(saveAsDefault: true, displayMessage: true, forward: false);
			}
			else if (DebugInput.GetKeyDown(KeyCode.K))
			{
				if (DebugInput.GetKey(KeyCode.LeftControl))
				{
					PromotionalScreenshot.SaveCraftScreenshot(CraftNode.CraftScript, exhaustEnabled: true, "Normal");
				}
				if (DebugInput.GetKey(KeyCode.LeftShift))
				{
					PromotionalScreenshot.SavePlanetScreenshot();
				}
			}
		}

		private void SaveLaunchLocation(string name, bool useCameraPosition)
		{
			LaunchLocation launchLocation = CreateLaunchLocation(name, useCameraPosition);
			Game.Instance.GameState.LaunchLocations.Add(launchLocation);
			Game.Instance.GameState.SaveLaunchLocations();
			Debug.LogFormat("Saved launch location at {0},{1} at {2} agl with rotation {3}", launchLocation.Latitude, launchLocation.Longitude, launchLocation.AltitudeAboveGroundLevel, Utilities.QuaterniondToString(launchLocation.Rotation));
		}

		private void SetCraftNode(CraftNode craftNode)
		{
			if (_craftNode != null)
			{
				_craftNode.UpdateTarget(isForSelf: true);
				_craftNode.SetIsPlayer(isPlayer: false, craftNode);
				_craftNode.CraftScript.ActiveCommandPodChanged -= OnPlayerCraftActiveCommandPodChanged;
				_craftNode.CraftScript.CraftStructureChanged -= OnPlayerCraftStructureChanged;
			}
			CraftNode craftNode2 = _craftNode;
			_craftNode = craftNode;
			if (_craftNode.IsLoadedInGameView)
			{
				_craftNode.CraftScript.ActiveCommandPodChanged += OnPlayerCraftActiveCommandPodChanged;
				_craftNode.CraftScript.CraftStructureChanged += OnPlayerCraftStructureChanged;
			}
			else
			{
				GameViewObjectHandler craftLoaded = null;
				craftLoaded = delegate
				{
					_craftNode.CraftScript.ActiveCommandPodChanged += OnPlayerCraftActiveCommandPodChanged;
					_craftNode.CraftScript.CraftStructureChanged += OnPlayerCraftStructureChanged;
					_craftNode.LoadedIntoGameView -= craftLoaded;
				};
				_craftNode.LoadedIntoGameView += craftLoaded;
			}
			_craftNode.SetIsPlayer(isPlayer: true, craftNode2);
			FlightControls.SetCraftNode(_craftNode);
			this.CraftChanged?.Invoke(_craftNode);
			OnPlayerCraftActiveCommandPodChanged(_craftNode.CraftScript, _craftNode.CraftScript?.ActiveCommandPod, craftNode2?.CraftScript?.ActiveCommandPod);
			_craftNode.UpdateTarget(isForSelf: false);
		}

		private void SwitchToNextCommandPod(bool reverse)
		{
			int num = -1;
			List<ICommandPod> list = new List<ICommandPod>();
			foreach (CraftNode item in ViewManager.GameView.PlanetNode.DynamicNodes.OfType<CraftNode>())
			{
				if (!item.IsLoadedInGameView || !item.HasCommandPod || item.IsDestroyed)
				{
					continue;
				}
				foreach (PartData part in item.CraftScript.Data.Assembly.Parts)
				{
					ICommandPod modifierWithInterface = part.PartScript.GetModifierWithInterface<ICommandPod>();
					if (modifierWithInterface != null && !part.IsDestroyed && !part.PartScript.Disconnected && modifierWithInterface.Part.Enabled)
					{
						if (item.IsPlayer && item.CraftScript.ActiveCommandPod == modifierWithInterface)
						{
							num = list.Count;
						}
						list.Add(modifierWithInterface);
					}
				}
			}
			if (num < 0)
			{
				list.Add(null);
				num = list.Count - 1;
			}
			int num2 = num;
			bool flag = false;
			while (!flag)
			{
				num2 = (num2 + ((!reverse) ? 1 : (-1))) % list.Count;
				if (num2 < 0)
				{
					num2 = list.Count - 1;
				}
				if (num2 == num)
				{
					break;
				}
				ICommandPod commandPod = list[num2];
				ICraftScript craftScript = commandPod.Part.PartScript.CraftScript;
				flag = ChangePlayersActiveCommandPodImmediate(commandPod, craftScript.CraftNode);
				if (!flag)
				{
					continue;
				}
				ViewManager.GameView.GameCamera.Recenter();
				if (!commandPod.SupressSwitchedToCraftMessage)
				{
					craftScript.CameraFocus = commandPod.Part.PartScript.Transform;
					string text = commandPod.Part.Name;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = "Command Pod";
					}
					string text2 = craftScript.CraftNode.Name;
					FlightSceneUI.ShowMessage("Switched to '" + text + "' on '" + text2 + "'");
				}
			}
		}

		private void TeleportPlayerToTarget(double distance, double lat = 0.0, double lon = 0.0)
		{
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				ICraftNode craftNode = CraftNode;
				IReferenceFrame referenceFrame = craftNode.ReferenceFrame;
				string text = string.Empty;
				IPartScript selectedPart = ViewManager.GameView.SelectedPart;
				if (selectedPart != null)
				{
					DockingPortScript modifier = selectedPart.GetModifier<DockingPortScript>();
					if (modifier != null && selectedPart.CraftScript != craftNode.CraftScript)
					{
						Vector3 framePosition = modifier.transform.position + modifier.transform.up * (float)distance;
						Vector3d position = referenceFrame.FrameToPlanetPosition(framePosition);
						Vector3d velocity = selectedPart.CraftScript.CraftNode.Velocity;
						craftNode.SetStateVectorsAtDefaultTime(position, velocity);
						craftNode.RecalculateFrameState(referenceFrame);
						text = "Teleported to the target docking port";
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					INavSphereTarget target = FlightSceneUI.NavSphere.Target;
					if (target == null)
					{
						text = $"Teleported up {distance}m";
						Vector3d position2 = CraftNode.Position + CraftNode.Position.normalized * distance;
						CraftNode.SetStateVectors(position2, CraftNode.Velocity, CraftNode.Orbit.Time);
						CraftNode.RecalculateFrameState(ViewManager.GameView.ReferenceFrame);
					}
					else if (target is CraftNode craftNode2)
					{
						if (target.Parent == CraftNode.Parent)
						{
							text = "Teleported next to the target";
							Vector3d position3 = target.Position + target.Position.normalized * distance;
							CraftNode.SetStateVectors(position3, craftNode2.Velocity, CraftNode.Orbit.Time);
							CraftNode.RecalculateFrameState(ViewManager.GameView.ReferenceFrame);
						}
						else
						{
							text = "Cannot teleport to a target on another planet.";
						}
					}
					else if (target is PlanetNode)
					{
						text = "Teleported to target planet";
						Relaunch(new LaunchLocation("Teleport", LaunchLocationType.SurfaceLockedGround, target.Name, lat, lon, Vector3d.zero, 0.0, distance));
					}
					else
					{
						text = "Teleported to target location";
						Vector3d position4 = target.Position + target.Position.normalized * distance;
						CraftNode.SetStateVectors(position4, CraftNode.Velocity, CraftNode.Orbit.Time);
						CraftNode.RecalculateFrameState(ViewManager.GameView.ReferenceFrame);
					}
				}
				FlightSceneUI.ShowMessage(text, devlog: true);
			});
		}

		private void ToggleInfiniteFuel()
		{
			Game.InfiniteFuelEnabled = !Game.InfiniteFuelEnabled;
			if (Game.InfiniteFuelEnabled)
			{
				_flightSceneUi.ShowMessage("Oh, that feels nice.");
			}
			else
			{
				_flightSceneUi.ShowMessage("Good feeling's gone.");
			}
		}

		private void ToggleInterpolation(RigidbodyInterpolation interpolationMethod)
		{
			bool flag = false;
			RigidbodyInterpolation rigidbodyInterpolation = RigidbodyInterpolation.None;
			foreach (BodyData body in CraftNode.CraftScript.Data.Assembly.Bodies)
			{
				Rigidbody rigidBody = body.BodyScript.RigidBody;
				if (rigidBody.interpolation == RigidbodyInterpolation.None)
				{
					flag = true;
					rigidBody.interpolation = interpolationMethod;
					rigidbodyInterpolation = interpolationMethod;
				}
				else
				{
					flag = false;
					rigidbodyInterpolation = rigidBody.interpolation;
					rigidBody.interpolation = RigidbodyInterpolation.None;
				}
			}
			if (flag)
			{
				FlightSceneUI.ShowMessage($"{rigidbodyInterpolation} enabled");
			}
			else
			{
				FlightSceneUI.ShowMessage($"{rigidbodyInterpolation} disabled");
			}
		}

		private void TransitionShipToNewPlanetSoi(ShipNode ship, IPlanetNode newParent, Vector3d newPosition, Vector3d newVelocity)
		{
			if (ship.IsPlayer)
			{
				_timeManager.SetNormalSpeedMode();
			}
			ship.TransitionToNewSoi(newParent, newPosition, newVelocity);
			if (!ship.IsPlayer)
			{
				return;
			}
			ViewManager.GameView.OnPlayerChangedSoi();
			if (this.PlayerChangedSoi == null)
			{
				return;
			}
			Delegate[] invocationList = this.PlayerChangedSoi.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				PlayerChangedSoiHandler playerChangedSoiHandler = (PlayerChangedSoiHandler)invocationList[i];
				try
				{
					playerChangedSoiHandler?.Invoke(_craftNode, _craftNode.Parent);
				}
				catch (Exception exception)
				{
					Debug.LogError("An error occurred invoking the PlayerChangedSoi event.");
					Debug.LogException(exception);
				}
			}
		}
	}
}
