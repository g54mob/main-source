using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Social.Achievements;
using Assets.Scripts.State;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using ModApi.Planet;
using ModApi.Scripts.State;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public class CraftNode : ShipNode, ICraftNode, IGameViewObject, ICameraTarget, IOrbitNode, INode, INavSphereTarget
	{
		private class AchievementHelperLightThisCandle
		{
			private static bool _achievementUnlocked;

			private static bool _initialized;

			public CraftNode CraftNode { get; }

			public Vector3d InitialPosition { get; }

			public double LaunchTime { get; }

			public AchievementHelperLightThisCandle(CraftNode craftNode)
			{
				CraftNode = craftNode;
				InitialPosition = craftNode.Parent.PlanetVectorToSurfaceVector(craftNode.Position);
				LaunchTime = craftNode.FlightState.Time;
			}

			public static void OnInitialLaunch(CraftNode craftNode)
			{
				if (!_initialized)
				{
					_initialized = true;
					_achievementUnlocked = Game.Instance.AchievementManager.GetAchievement(AchievementKey.LightThisCandle)?.completed ?? false;
				}
				if (!_achievementUnlocked && craftNode._craftScript.Data.Size.y >= 25f && craftNode._craftScript.NumAstronauts > 0)
				{
					InitialCraftNodeData initialCraftNodeData = craftNode.InitialCraftNodeData.FirstOrDefault();
					if (initialCraftNodeData != null && initialCraftNodeData.LaunchLocationName.Contains(" Pad"))
					{
						craftNode._achievementHelperLightThisCandle = new AchievementHelperLightThisCandle(craftNode);
					}
				}
			}

			public static void Update(CraftNode craftNode)
			{
				AchievementHelperLightThisCandle achievementHelperLightThisCandle = craftNode._achievementHelperLightThisCandle;
				if (achievementHelperLightThisCandle == null)
				{
					return;
				}
				if ((craftNode.Parent.PlanetVectorToSurfaceVector(craftNode.Position) - achievementHelperLightThisCandle.InitialPosition).magnitude > 5.0)
				{
					craftNode._achievementHelperLightThisCandle = null;
					return;
				}
				bool flag = craftNode.CraftScript.FlightData.CurrentEngineThrust > 1f;
				if (craftNode.FlightState.Time - achievementHelperLightThisCandle.LaunchTime >= 14400.0)
				{
					if (flag)
					{
						Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.LightThisCandle);
						_achievementUnlocked = true;
						craftNode._achievementHelperLightThisCandle = null;
					}
				}
				else if (flag)
				{
					craftNode._achievementHelperLightThisCandle = null;
				}
			}
		}

		private static bool _achievementUnlockedHeavyLifter;

		private static bool _achievementUnlockedManyParts;

		private static bool _achievementUnlockedSandboxLaunch;

		private static bool _achievementUnlockedZeroMass;

		private AchievementHelperLightThisCandle _achievementHelperLightThisCandle;

		private Vector3d _cameraTargetPlanetPosition;

		private CraftData _craftData;

		private CraftScript _craftScript;

		private FlightState _flightState;

		private IGameView _gameView;

		private Dictionary<int, InitialCraftNodeData> _initialCraftNodeData;

		private bool _isPlayer;

		private Vector2d _latLon;

		private bool _latLonDirty = true;

		private XElement _pendingCraftXml;

		private bool _physicsEnabledBeforeWarp;

		private bool _requiresSave;

		private Vector3d? _surfaceVelocity;

		private INavSphereTarget _target;

		private Vector3 _timeWarpForceTotal;

		private bool _warp;

		public bool AllowPlayerControl { get; set; } = true;

		public double AltitudeAboveTerrain { get; private set; }

		public double AltitudeAgl { get; private set; }

		public override Transform CameraTarget => CraftScript.CameraTarget;

		public override Vector3 CameraTargetPlanetPosition => (Vector3)_cameraTargetPlanetPosition;

		public bool CanWarp
		{
			get
			{
				if (InContactWithPlanet)
				{
					if (CraftScript != null)
					{
						return FrameVelocity.magnitude < 2f;
					}
					return false;
				}
				if (base.IsDestroyed)
				{
					return true;
				}
				return false;
			}
		}

		public string ContractTrackingId { get; set; }

		public CraftControls Controls => this?.CraftScript?.ActiveCommandPod?.Controls;

		public float CraftMass { get; private set; }

		public int CraftPartCount { get; private set; }

		public ICraftScript CraftScript => _craftScript;

		public bool DestroyOnExitFlightScene { get; set; }

		public FlightState FlightState => _flightState;

		public override Vector3 FramePosition => _craftScript.FramePosition;

		public override Vector3 FrameVelocity => _craftScript.FrameVelocity;

		public override GameObject GameObject
		{
			get
			{
				if (!IsLoadedInGameView)
				{
					return null;
				}
				return _craftScript.gameObject;
			}
		}

		public IGameView GameView => _gameView;

		public override float GameViewLoadDistance => 10000f;

		public override IGameViewObject GameViewObject => this;

		public Vector3d? GroundedSurfacePosition { get; private set; }

		public Quaterniond? GroundedSurfaceRotation { get; private set; }

		public Vector3d? GroundedSurfaceVelocity { get; private set; }

		public bool HasCommandPod { get; set; }

		public Quaterniond Heading { get; private set; }

		public bool InContactWithPlanet { get; set; }

		public bool InContactWithWater { get; set; }

		public IReadOnlyCollection<InitialCraftNodeData> InitialCraftNodeData => _initialCraftNodeData.Values;

		public List<int> InitialCraftNodeIds { get; set; } = new List<int>();

		public bool InitialLaunch { get; internal set; }

		public bool InitialLaunchHeadingIsDirectionOfTravel { get; set; }

		public override bool IsLoadedInGameView => _craftScript != null;

		public override bool IsPhysicsEnabled
		{
			get
			{
				if (_craftScript != null)
				{
					return _craftScript.IsPhysicsEnabled;
				}
				return false;
			}
		}

		public override bool IsPlayer => _isPlayer;

		public Vector2d LatLon
		{
			get
			{
				if (_latLonDirty)
				{
					_latLonDirty = false;
					Vector3d surfacePosition = base.Parent.PlanetVectorToSurfaceVector(Position);
					base.Parent.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
					_latLon.x = latitude;
					_latLon.y = longitude;
				}
				return _latLon;
			}
		}

		public int NodeId { get; set; }

		IOrbitNode INavSphereTarget.OrbitNode => this;

		public bool PhysicsEnabledBeforeWarp => _physicsEnabledBeforeWarp;

		public override Vector3d Position => base.Orbit.Position;

		public IReferenceFrame ReferenceFrame => _gameView.ReferenceFrame;

		public Vector3d SurfaceVelocity
		{
			get
			{
				if (!_surfaceVelocity.HasValue)
				{
					if (GroundedSurfaceVelocity.HasValue)
					{
						_surfaceVelocity = GroundedSurfaceVelocity.Value;
					}
					else
					{
						Vector3d surfacePoint = base.Parent.PlanetVectorToSurfaceVector(Position).normalized * base.Parent.PlanetData.Radius;
						Vector3d vector3d = base.Parent.CalculateSurfaceVelocity(surfacePoint);
						Vector3d vector3d2 = base.Parent.PlanetVectorToSurfaceVector(Velocity);
						_surfaceVelocity = vector3d2 - vector3d;
					}
				}
				return _surfaceVelocity.Value;
			}
		}

		public override Vector3 TargetRotation => CraftScript.ActiveCommandPod.Part.PartScript.Transform.eulerAngles;

		public override Vector3d Velocity => base.Orbit.Velocity;

		public double WaterDepth { get; set; }

		public event CraftNodeMergeDelegate CraftNodeMerged;

		public override event GameViewObjectHandler LoadedIntoGameView;

		public event PhysicsChangedHandler PhysicsDisabled;

		public event PhysicsChangedHandler PhysicsEnabled;

		public event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanged;

		public override event GameViewObjectHandler UnloadedFromGameView;

		public override event GameViewObjectHandler UnloadingFromGameView;

		public CraftNode(ICraftNodeData data, FlightState flightState, double primaryMass, CraftData craftData = null, CraftScript craftScript = null, XElement pendingXml = null)
		{
			InitializeFromData(data, flightState, primaryMass, craftData, craftScript);
			_pendingCraftXml = pendingXml;
		}

		public CraftNode(Vector3d position, Vector3d velocity, Quaterniond heading, FlightState flightState, double primaryMass, CraftData craftData = null, CraftScript craftScript = null)
		{
			InitializeFromStateVectors(position, velocity, flightState, primaryMass, craftData, craftScript);
			Heading = heading;
		}

		public static bool IsOrbitSuitableToRestore(OrbitData orbitData)
		{
			bool result = true;
			if (orbitData.Eccentricity > 10000.0)
			{
				result = false;
			}
			return result;
		}

		public void AddTimeWarpForce(Vector3 force)
		{
			_timeWarpForceTotal += force;
		}

		public void ClearUnusedInitialCraftNodeData()
		{
			foreach (int item in _initialCraftNodeData.Keys.ToList())
			{
				if (!InitialCraftNodeIds.Contains(item))
				{
					_initialCraftNodeData.Remove(item);
				}
			}
		}

		public void CopyInitialCraftNodeData(ICraftNode source)
		{
			foreach (int initialCraftNodeId in InitialCraftNodeIds)
			{
				InitialCraftNodeData initialCraftNodeData = source.GetInitialCraftNodeData(initialCraftNodeId);
				if (initialCraftNodeData != null)
				{
					InitialCraftNodeData value = initialCraftNodeData.Clone();
					_initialCraftNodeData[initialCraftNodeId] = value;
				}
			}
		}

		public void DestroyCraft()
		{
			if (!base.IsDestroyed)
			{
				base.IsDestroyed = true;
				try
				{
					RaiseDestroyedEvent();
					return;
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					return;
				}
			}
			Debug.LogError("Attempting to destroy a craft that has already been destroyed");
		}

		public override void FlightEnd()
		{
			base.FlightEnd();
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
			_flightState = null;
			_craftData = null;
			if (_craftScript != null)
			{
				Debug.LogError("Craft Script is not null in FlightEnd");
				_craftScript.CraftNode = null;
				_craftScript = null;
			}
		}

		public override void FlightStart()
		{
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
		}

		public override void FlightUpdate(double elapsedTime, double currentTime)
		{
			UpdateCraft(elapsedTime, currentTime);
		}

		public InitialCraftNodeData GetInitialCraftNodeData(int craftNodeId)
		{
			if (!_initialCraftNodeData.TryGetValue(craftNodeId, out var value))
			{
				return null;
			}
			return value;
		}

		public override void Initialize()
		{
			base.Initialize();
			base.Altitude = base.Orbit.Position.magnitude - (base.Parent.PlanetData.Radius + (double)base.Parent.PlanetData.SeaLevel);
		}

		public CraftData LoadCraftData()
		{
			XElement craftXml = _flightState.LoadCraftXml(NodeId);
			return Game.Instance.CraftLoader.LoadCraftImmediate(craftXml);
		}

		public void OnMergedWithCraftNode(CraftNode targetCraftNode, CraftNode sourceCraftNode)
		{
			this.CraftNodeMerged?.Invoke(targetCraftNode, sourceCraftNode);
		}

		public override void RecalculateFrameState(IReferenceFrame referenceFrame)
		{
			if (_warp)
			{
				Vector3 vector = _gameView.ReferenceFrame.PlanetToFramePosition(Position);
				if ((_craftScript.transform.position - vector).sqrMagnitude > 1.0000001E-06f)
				{
					_craftScript.transform.position = vector;
				}
				return;
			}
			Vector3 positionDelta = referenceFrame.PlanetToFramePosition(Position) - _craftScript.FramePosition;
			Vector3 velocityDelta = referenceFrame.PlanetToFrameVelocity(Velocity) - _craftScript.FrameVelocity;
			Vector3 frameZeroVelocity = Vector3.zero;
			if (!referenceFrame.IsSurfaceLocked)
			{
				frameZeroVelocity = referenceFrame.PlanetToFrameVector(referenceFrame.Velocity);
			}
			_craftScript.RecalculateFrameState(positionDelta, velocityDelta, frameZeroVelocity);
			if (_craftScript.IsPhysicsEnabled)
			{
				_craftScript.RecenterTransformOnCoM(updateRotation: true);
			}
		}

		public void SetInitialCraftNodeData(LaunchLocation launchLocation, double launchTime)
		{
			if (_initialCraftNodeData.Count > 0)
			{
				Debug.LogError("Attempting to set the initial craft node data on a craft node that already has data.");
				_initialCraftNodeData.Remove(NodeId);
			}
			InitialCraftNodeData value = new InitialCraftNodeData(this, launchLocation, launchTime);
			_initialCraftNodeData[NodeId] = value;
		}

		public override void SetIsPlayer(bool isPlayer, ICraftNode other)
		{
			_isPlayer = isPlayer;
			IReadOnlyList<PartData> readOnlyList = CraftScript?.Data?.Assembly?.Parts;
			if (readOnlyList == null)
			{
				return;
			}
			foreach (PartData item in readOnlyList)
			{
				List<PartModifierScript> modifiers = item.PartScript.Modifiers;
				for (int i = 0; i < modifiers.Count; i++)
				{
					modifiers[i].OnIsPlayerCraftChanged(isPlayer, other);
				}
			}
		}

		public virtual void SetName(string name)
		{
			Name = name;
		}

		public override void SetPhysicsEnabled(bool enabled, PhysicsChangeReason reason)
		{
			if (!(_craftScript != null) || _craftScript.IsPhysicsEnabled == enabled)
			{
				return;
			}
			_craftScript.IsPhysicsEnabled = enabled;
			if (enabled)
			{
				if (!InContactWithPlanet)
				{
					Vector3 velocity = _gameView.ReferenceFrame.PlanetToFrameVelocity(Velocity);
					_craftScript.SetVelocity(velocity);
				}
				else
				{
					_craftScript.SetVelocity(Vector3.zero);
				}
				this.PhysicsEnabled?.Invoke(this, reason);
			}
			else
			{
				if (InContactWithPlanet)
				{
					UpdateSurfaceParameters();
				}
				this.PhysicsDisabled?.Invoke(this, reason);
			}
		}

		public override void SetStateVectors(Vector3d position, Vector3d velocity, double time)
		{
			base.SetStateVectors(position, velocity, time);
		}

		public override void SynchronizeData()
		{
			SavePendingCraftXmlChanges();
			if (_pendingCraftXml != null)
			{
				_flightState.SaveCraftXml(NodeId, _pendingCraftXml);
				_pendingCraftXml = null;
			}
			if (InContactWithPlanet)
			{
				UpdateSurfaceParameters();
			}
			UpdateCraftMetaData();
		}

		public override void TransitionToNewSoi(IPlanetNode newParent, Vector3d newPosition, Vector3d newVelocity)
		{
			base.TransitionToNewSoi(newParent, newPosition, newVelocity);
			RecalculateAltitude(base.Parent.PlanetData);
		}

		public void UpdateTarget(bool isForSelf)
		{
			if (Game.Instance.FlightScene.ViewManager.MapViewManager != null)
			{
				if (isForSelf)
				{
					_target = Game.Instance.FlightScene.FlightSceneUI.NavSphere.Target;
				}
				else if (_target != null)
				{
					IIocContainer iocContainer = Game.Instance.FlightScene.IocContainer;
					IMapViewContext context = (Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).Context;
					iocContainer.Resolve<INavigationTargetProvider>(context)?.SetNavSphereTarget(_target);
				}
			}
		}

		protected override Transform OnLoadIntoGameView(IGameView gameView)
		{
			try
			{
				_gameView = gameView;
				if (_craftData == null)
				{
					try
					{
						_craftData = LoadCraftData();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						_craftData = null;
					}
					if (_craftData == null)
					{
						Debug.LogError("Failed to load craft " + Name + " into Game View. It will be removed from the flight state.");
						DestroyCraft();
						return null;
					}
					if (_craftData.Assembly.Parts.Count == 0)
					{
						Debug.Log($"CraftNode {NodeId} has no parts and is being removed.");
						DestroyCraft();
						return null;
					}
				}
				if (_craftScript == null)
				{
					Vector3? localCenterOfMass = _craftData.LocalCenterOfMass;
					CraftBuilder craftBuilder = new CraftBuilder(_craftData);
					_craftScript = craftBuilder.BuildCraft(createRigidBodies: true, InitialLaunch);
					if (localCenterOfMass.HasValue)
					{
						_craftScript.CenterOfMass.localPosition = localCenterOfMass.Value;
					}
					_craftScript.Transform.position = gameView.ReferenceFrame.PlanetToFramePosition(Position);
					if (InitialLaunchHeadingIsDirectionOfTravel)
					{
						_craftScript.RecenterTransformOnCoM(updateRotation: true);
						InitialLaunchHeadingIsDirectionOfTravel = false;
					}
					_craftScript.Transform.rotation = gameView.ReferenceFrame.PlanetToFrameRotation(Heading);
					_craftScript.CraftNode = this;
					_craftScript.gameObject.name = "Craft-" + NodeId;
					_craftScript.IsPhysicsEnabled = false;
					if (_craftData.LegacyLaunchConfiguration)
					{
						_craftData.LegacyLaunchConfiguration = false;
						_craftScript.RecenterTransformOnCoM(updateRotation: false);
					}
					else
					{
						RecalculateFrameState(gameView.ReferenceFrame);
					}
					_craftScript.OnPreNodeLoaded();
					_craftScript.RestoreActiveCommandPod();
					_craftScript.OnNodeLoaded();
					if (InitialLaunch)
					{
						_requiresSave = true;
						InitialCraftNodeIds.Add(NodeId);
					}
					foreach (PartData part in _craftScript.Data.Assembly.Parts)
					{
						if (InitialLaunch)
						{
							((ConfigData)part.Config).InitialCraftNodeId = NodeId;
						}
						if (part.PreviouslyActivated && !string.IsNullOrEmpty(part.Payload?.CraftTrackingId))
						{
							ContractTrackingId = part.Payload.CraftTrackingId;
						}
					}
					if (InitialLaunch)
					{
						InitialLaunch = false;
						if (_initialCraftNodeData.TryGetValue(NodeId, out var value))
						{
							value.SetupCraftScriptData(_craftScript);
						}
						else
						{
							Debug.LogError("Unable to find the initial craft node data in order to apply initial craft script data.");
						}
						CheckAchievementsCraftLaunch();
						AchievementHelperLightThisCandle.OnInitialLaunch(this);
						_flightState.OnInitialLaunch(_craftScript);
					}
				}
				else
				{
					_craftScript.OnPreNodeLoaded();
					_craftScript.RestoreActiveCommandPod();
					_craftScript.OnNodeLoaded();
				}
				PartCollisionIgnoreUtility.ApplyPartCollisions(_craftScript);
				_cameraTargetPlanetPosition = _gameView.ReferenceFrame.FrameToPlanetPosition(CameraTarget.position);
				LoadedIntoGameView?.Invoke(this);
				return _craftScript.transform;
			}
			catch (Exception)
			{
				_gameView = null;
				_craftScript = null;
				throw;
			}
		}

		protected override void OnUnloadFromGameView(bool flightEnd)
		{
			UnloadingFromGameView?.Invoke(this);
			SetPhysicsEnabled(enabled: false, (!flightEnd) ? PhysicsChangeReason.UnloadedFromGameView : PhysicsChangeReason.FlightEnd);
			SavePendingCraftXmlChanges();
			_craftScript.FlightEnd();
			_craftScript.Unload();
			_craftScript = null;
			if (base.IsDestroyed)
			{
				base.Parent.RemoveChildNode(this);
			}
			_gameView = null;
			UnloadedFromGameView?.Invoke(this);
		}

		private void ApplyTimeWarpForce(double deltaTime)
		{
			if (CraftScript != null && _timeWarpForceTotal.sqrMagnitude > 0f)
			{
				Vector3 vector = _timeWarpForceTotal / CraftScript.Mass * (float)deltaTime;
				Vector3d velocity = base.Orbit.Velocity + vector;
				SetStateVectorsAtDefaultTime(base.Orbit.Position, velocity);
				_timeWarpForceTotal = Vector3.zero;
			}
			CraftControls controls = Controls;
			if (controls != null && controls.TargetHeading.HasValue)
			{
				Vector3 forward = CraftScript.CenterOfMass.forward;
				Vector3 toDirection = GameView.ReferenceFrame.PlanetToFrameVector(Controls.TargetDirection.Value);
				Quaternion b = Quaternion.FromToRotation(forward, toDirection) * _craftScript.Transform.rotation;
				_craftScript.Transform.rotation = Quaternion.Lerp(_craftScript.Transform.rotation, b, 0.1f * (float)deltaTime);
				Heading = GameView.ReferenceFrame.FrameToPlanetRotation(_craftScript.transform.rotation);
			}
		}

		private void CheckAchievementsCraftLaunch()
		{
			if (!_achievementUnlockedSandboxLaunch && Game.Instance.GameState.Mode == GameStateMode.Sandbox && Game.Instance.LevelManager.CurrentLevel == null)
			{
				_achievementUnlockedSandboxLaunch = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.LaunchCraftInSandbox);
			}
			if (!_achievementUnlockedZeroMass && CraftScript.Data.Assembly.Parts.All((PartData x) => x.Config.MassScale == 0f))
			{
				_achievementUnlockedZeroMass = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.LaunchedCraftZeroMass);
			}
			if (!_achievementUnlockedManyParts && CraftScript.Data.Assembly.Parts.Count > 1000)
			{
				_achievementUnlockedManyParts = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.LaunchedCraftManyParts);
			}
			if (_achievementUnlockedHeavyLifter)
			{
				return;
			}
			int num = 0;
			foreach (PartData part in CraftScript.Data.Assembly.Parts)
			{
				if (part.ActivationStage == 0 && part.Config.SupportsActivation && part.Config.StageActivationType == StageActivationType.Engine && part.PartScript.GetModifierWithInterface<IReactionEngine>() != null)
				{
					num++;
				}
			}
			if (num == 27)
			{
				_achievementUnlockedHeavyLifter = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.LaunchedCraftHeavyLifter);
			}
		}

		private void InitializeCommon(FlightState flightState, CraftData craftData, CraftScript craftScript)
		{
			_flightState = flightState;
			_craftData = craftData;
			_craftScript = craftScript;
			_initialCraftNodeData = new Dictionary<int, InitialCraftNodeData>();
		}

		private void InitializeFromData(ICraftNodeData data, FlightState flightState, double primaryMass, CraftData craftData, CraftScript craftScript)
		{
			InitializeCommon(flightState, craftData, craftScript);
			AllowPlayerControl = data.AllowPlayerControl;
			CraftMass = data.CraftMass;
			CraftPartCount = data.CraftPartCount;
			ContractTrackingId = data.ContractTrackingId;
			HasCommandPod = data.HasCommandPod;
			Heading = data.Heading;
			InContactWithPlanet = data.InContactWithPlanet;
			Name = data.Name;
			NodeId = data.NodeId;
			GroundedSurfacePosition = data.SurfacePosition;
			GroundedSurfaceRotation = data.SurfaceRotation;
			GroundedSurfaceVelocity = data.SurfaceVelocity;
			InitialCraftNodeIds = data.InitialCraftNodeIds.ToList();
			foreach (InitialCraftNodeData initialCraftNodeDatum in data.InitialCraftNodeData)
			{
				_initialCraftNodeData.Add(initialCraftNodeDatum.NodeId, initialCraftNodeDatum.Clone());
			}
			if (data.OrbitData != null)
			{
				base.Orbit = new Orbit(data.OrbitData, primaryMass);
			}
			else
			{
				base.Orbit = new Orbit(data.Position, data.Velocity, flightState.Time, primaryMass);
			}
		}

		private void InitializeFromStateVectors(Vector3d position, Vector3d velocity, FlightState flightState, double primaryMass, CraftData craftData, CraftScript craftScript)
		{
			InitializeCommon(flightState, craftData, craftScript);
			base.Orbit = new Orbit(position, velocity, flightState.Time, primaryMass);
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			if (e.EnteredWarpMode)
			{
				_warp = true;
				_physicsEnabledBeforeWarp = IsPhysicsEnabled;
				SetPhysicsEnabled(enabled: false, PhysicsChangeReason.Warp);
			}
			else if (e.ExitedWarpMode)
			{
				bool physicsEnabledBeforeWarp = _physicsEnabledBeforeWarp;
				_warp = false;
				_physicsEnabledBeforeWarp = false;
				SetPhysicsEnabled(physicsEnabledBeforeWarp, PhysicsChangeReason.Warp);
			}
			this.TimeMultiplierModeChanged?.Invoke(e);
		}

		private void RecalculateAltitude(IPlanetData planetData)
		{
			base.Altitude = base.Orbit.Position.magnitude - (planetData.Radius + (double)planetData.SeaLevel);
		}

		private void SavePendingCraftXmlChanges()
		{
			if (!_requiresSave)
			{
				return;
			}
			if (!base.IsDestroyed)
			{
				if (_craftData != null && _craftScript != null)
				{
					_craftScript.RecenterTransformOnCoM(updateRotation: true);
					_pendingCraftXml = _craftData.GenerateXml(_craftScript.Transform, optimizeXml: true, generateRequiredMods: true);
				}
			}
			else
			{
				_pendingCraftXml = null;
			}
			_requiresSave = false;
		}

		private void UpdateCraft(double elapsedTime, double currentTime)
		{
			if (base.IsDestroyed)
			{
				if (IsPlayer && _craftScript != null)
				{
					SetStateVectorsAtDefaultTime(_gameView.ReferenceFrame.FrameToPlanetPosition(_craftScript.FramePosition), Vector3.zero);
					_cameraTargetPlanetPosition = _gameView.ReferenceFrame.FrameToPlanetPosition(CameraTarget.position);
				}
				return;
			}
			if (_craftScript == null)
			{
				if (!InContactWithPlanet)
				{
					base.Orbit.AdvanceTime(elapsedTime, currentTime);
					if (Position.sqrMagnitude < base.Parent.PlanetData.ImpactRadiusSquared)
					{
						DestroyCraft();
						Debug.Log("Craft Impacted Planet: " + Name);
					}
				}
				else
				{
					if (!GroundedSurfaceRotation.HasValue)
					{
						UpdateSurfaceParameters();
					}
					Heading = base.Parent.Rotation * GroundedSurfaceRotation.Value;
					SetStateVectorsAtDefaultTime(base.Parent.SurfaceVectorToPlanetVector(GroundedSurfacePosition.Value), base.Parent.SurfaceVectorToPlanetVector(GroundedSurfaceVelocity.Value));
				}
			}
			else
			{
				if (IsPhysicsEnabled)
				{
					Heading = _gameView.ReferenceFrame.FrameToPlanetRotation(_craftScript.FrameHeading);
					SetStateVectorsAtDefaultTime(_gameView.ReferenceFrame.FrameToPlanetPosition(_craftScript.FramePosition), _gameView.ReferenceFrame.FrameToPlanetVelocity(_craftScript.FrameVelocity));
					GroundedSurfacePosition = null;
					GroundedSurfaceRotation = null;
					GroundedSurfaceVelocity = null;
					_requiresSave = IsPhysicsEnabled;
				}
				else if (InContactWithPlanet)
				{
					Heading = base.Parent.Rotation * GroundedSurfaceRotation.Value;
					SetStateVectorsAtDefaultTime(base.Parent.SurfaceVectorToPlanetVector(GroundedSurfacePosition.Value), base.Parent.SurfaceVectorToPlanetVector(GroundedSurfaceVelocity.Value));
					RecalculateFrameState(_gameView.ReferenceFrame);
				}
				else
				{
					Heading = _gameView.ReferenceFrame.FrameToPlanetRotation(_craftScript.FrameHeading);
					base.Orbit.AdvanceTime(elapsedTime, currentTime);
					RecalculateFrameState(_gameView.ReferenceFrame);
					ApplyTimeWarpForce(elapsedTime);
					if (base.Orbit.Position.sqrMagnitude < base.Parent.PlanetData.ImpactRadiusSquared)
					{
						DestroyCraft();
						Debug.Log("Craft Impacted Planet: " + Name);
					}
				}
				UpdateCraftMetaData();
			}
			PlanetNode planetNode = base.Parent as PlanetNode;
			IPlanetData planetData = planetNode.PlanetData;
			RecalculateAltitude(planetData);
			double crushAltitude = planetNode.PlanetData.AtmosphereData.CrushAltitude;
			if (crushAltitude > 0.0 && base.Altitude < crushAltitude)
			{
				if (IsPlayer)
				{
					Game.Instance.FlightScene.FlightSceneUI.FlightLog.LogTotalCraftDestruction("Your craft got crushed by the celestial body.");
					IPartScript rootPart = _craftScript.RootPart;
					rootPart.BodyScript.ExplodePart(rootPart, 100f);
				}
				else
				{
					DestroyCraft();
				}
				return;
			}
			double num = (GameView?.Planet.QuadSphere.TerrainMaxHeight ?? 0.0) + 20000.0;
			if (IsPlayer)
			{
				if (base.Altitude < num)
				{
					RaycastHit hitInfo;
					PlanetVertexData planetVertexData = planetNode.GetTerrainVertexData(planetNormal: (!Physics.Raycast(_craftScript.FramePosition, _craftScript.GravityNormal, out hitInfo, 1000f, 603979776)) ? ReferenceFrame.FrameToPlanetVector(-_craftScript.GravityNormal) : ReferenceFrame.FrameToPlanetVector(hitInfo.normal), type: VertexDataRequestType.AllData, planetPosition: Position);
					double height = planetVertexData.Height;
					AltitudeAboveTerrain = base.Altitude - (height - (double)planetData.SeaLevel);
					AltitudeAgl = ((AltitudeAboveTerrain > base.Altitude && planetNode.PlanetData.HasWater) ? base.Altitude : AltitudeAboveTerrain);
					FlightSceneScript.Instance.CraftBiomeData.UpdateCraftPositionData(planetVertexData, planetNode.PlanetData.TerrainData);
					if (AltitudeAboveTerrain < -20.0)
					{
						Vector3d surfacePoint = base.Parent.PlanetVectorToSurfaceVector(Position);
						Vector3d vector3d = base.Parent.SurfaceVectorToPlanetVector(base.Parent.CalculateSurfaceVelocity(surfacePoint));
						Vector3d vector3d2 = base.Orbit.Velocity - vector3d;
						Debug.LogFormat("CraftNode below surface at {0}m. Repositioning at surface: Vel = {1}, Relative = {2}, Surface = {3}", AltitudeAboveTerrain, base.Orbit.Velocity, vector3d2, vector3d);
						if (vector3d2.magnitude > 50.0)
						{
							IPartScript rootPart2 = _craftScript.RootPart;
							rootPart2.BodyScript.ExplodePart(rootPart2, 100f);
							Debug.Log("Destroy Command Pod");
							Game.Instance.FlightScene.FlightSceneUI.FlightLog.LogTotalCraftDestruction("Your craft exploded upon impact");
						}
						double altitudeAgl = (AltitudeAboveTerrain = 0.0);
						AltitudeAgl = altitudeAgl;
						SetStateVectorsAtDefaultTime(base.Orbit.Position.normalized * (planetNode.PlanetData.Radius + height), Vector3d.zero);
						RecalculateFrameState(_gameView.ReferenceFrame);
					}
					if (InContactWithPlanet || InContactWithWater)
					{
						AchievementHelper.InContactWithPlanetOrWater(this);
					}
					AchievementHelperLightThisCandle.Update(this);
				}
				else
				{
					double altitudeAgl = (AltitudeAboveTerrain = base.Altitude);
					AltitudeAgl = altitudeAgl;
					FlightSceneScript.Instance.CraftBiomeData.UpdateCraftPositionData(null, null);
					AchievementHelper.InHighAltitudeOrSpace(this);
				}
			}
			else if (IsPhysicsEnabled && base.Altitude < num)
			{
				double height2 = planetNode.GetTerrainVertexData(VertexDataRequestType.HeightData, Position, Position.normalized).Height;
				AltitudeAboveTerrain = base.Altitude - (height2 - (double)planetData.SeaLevel);
				AltitudeAgl = ((AltitudeAboveTerrain > base.Altitude && planetNode.PlanetData.HasWater) ? base.Altitude : AltitudeAboveTerrain);
			}
			else if (InContactWithPlanet)
			{
				double altitudeAgl = (AltitudeAboveTerrain = 0.0);
				AltitudeAgl = altitudeAgl;
			}
			else
			{
				double altitudeAgl = (AltitudeAboveTerrain = base.Altitude);
				AltitudeAgl = altitudeAgl;
			}
			if (_gameView != null)
			{
				_cameraTargetPlanetPosition = _gameView.ReferenceFrame.FrameToPlanetPosition(CameraTarget.position);
			}
			_surfaceVelocity = null;
			_latLonDirty = true;
		}

		private void UpdateCraftMetaData()
		{
			if (_craftData != null)
			{
				CraftPartCount = _craftData.Assembly.Parts.Count;
			}
			if (_craftScript != null)
			{
				CraftMass = _craftScript.Mass;
			}
		}

		private void UpdateSurfaceParameters()
		{
			GroundedSurfaceRotation = base.Parent.RotationInverse * Heading;
			GroundedSurfacePosition = base.Parent.PlanetVectorToSurfaceVector(Position);
			GroundedSurfaceVelocity = base.Parent.CalculateSurfaceVelocity(GroundedSurfacePosition.Value.normalized * base.Parent.PlanetData.Radius);
		}
	}
}
