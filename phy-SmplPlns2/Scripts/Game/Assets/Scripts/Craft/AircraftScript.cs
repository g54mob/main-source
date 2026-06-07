using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Assets.Scripts.Achievements;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Events;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.Simulation;
using Assets.Scripts.Input;
using Assets.Scripts.Levels;
using Assets.Scripts.Mods;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.SyncData;
using Jundroo.Common.Events;
using Jundroo.Common.Expressions;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Jundroo.Common.Threading.Tasks;
using Jundroo.Common.Utils;
using Jundroo.SocialPlatforms.Achievements;
using Unity.Profiling;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Craft
{
	public class AircraftScript : MonoBehaviour, IRepositionable, IFuelSource
	{
		public delegate void AircraftDamagedDelegate(PartScript damagedPart);

		public delegate void AircraftStructureChangedDelegate();

		public delegate void PartEnteredWaterDelegate(PartScript part);

		public enum AircraftStats
		{
			WingSpan = 0,
			Length = 1,
			Height = 2,
			WingArea = 3,
			WingLoading = 4,
			EmptyWeight = 5,
			LoadedWeight = 6,
			PowerToWeightRatio = 7,
			PowerOutput = 8,
			PartCount = 9,
			ControlSurfaceCount = 10,
			PerformanceCost = 11,
			FuelAmount = 12,
			Drag = 13,
			HorsePower = 14,
			HorsePowerToWeightRatio = 15
		}

		public enum SpeedType
		{
			IAS = 0,
			TAS = 1,
			GS = 2
		}

		private static class Profile
		{
			public static readonly ProfilerMarker RebuildAircraftStructure = new ProfilerMarker("AircraftScript.RebuildAircraftStructure");

			public static readonly ProfilerMarker RecalculateInertiaTensorsIfNeeded = new ProfilerMarker("AircraftScript.RecalculateInertiaTensorsIfNeeded");

			public static readonly ProfilerMarker UpdateInertiaTensorsWithDiffusion = new ProfilerMarker("AircraftScript.UpdateInertiaTensorsWithDiffusion");
		}

		private static bool _mach2Achieved;

		private Vector3 _acceleration;

		private Vector3 _aerodynamicCenter;

		private GameObject _aerodynamicCenterGameObject;

		private float _altitudeAgl;

		private Vector3 _altitudeAglPos;

		private float? _cachedStreamlineMagnitude;

		private GroupCenterOfMass _centerOfMass = new GroupCenterOfMass();

		private Vector3 _centerOfMassCalculatedForDebug;

		private GameObject _centerOfMassGameObject;

		private List<Rigidbody> _centerOfMassRegidBodiesForDebug;

		private bool _criticallyDamagedMessageShown;

		private float _currentWingSurfaceArea;

		private Dictionary<int, float> _damageFromAttackers = new Dictionary<int, float>();

		private string _damageMessage;

		private bool _drawAerodynamicCenter;

		private bool _drawCenterOfMass;

		private List<ICraftEngine> _engines = new List<ICraftEngine>();

		private Context _expressionContext;

		private Vector3 _floatingOriginMissed = Vector3.zero;

		private bool _floatingOriginSubbed;

		private float _fuelGainedInFrame;

		private List<FuelTankScript> _fuelTanks = new List<FuelTankScript>();

		private float _fuelUsedInFrame;

		private AudioSource _groundRollAudio;

		private bool _initialized;

		private int _initialNonWeaponPartCount;

		private float _initialWingSurfaceArea;

		private Vector3 _lastVelocity;

		private float _mach2HoldTime;

		private PartScript _mainCockpit;

		private PartScript _mainSeat;

		private bool _newVelocitySetWhilePausedIgnoresDisconnectedParts;

		private Vector3? _newVeloctySetWhilePaused;

		private int _nextBodyId;

		private int _numActiveTanks;

		private Dictionary<int, PartGroupScript> _partGroups = new Dictionary<int, PartGroupScript>();

		private Dictionary<PartScript, float> _pendingExplosiveForces;

		private bool _raiseAircraftKilledEvent;

		private AudioSource _rattleAudio;

		private bool _recalculateDrag;

		private ReflectionProbe _reflectionProbe;

		private IRpmSource[] _rpmSources;

		private float? _startTime;

		private AudioSource _waterAmbienceAudio;

		private AudioSource _windAudio;

		private Transform _windAudioParent;

		[SerializeField]
		private Vector3 _windSpeed = Vector3.zero;

		private List<IWingScript> _wings = new List<IWingScript>();

		public Vector3 Acceleration
		{
			get
			{
				return _acceleration;
			}
			set
			{
				_acceleration = value;
			}
		}

		public AircraftData Aircraft { get; private set; }

		public float AirSpeed
		{
			get
			{
				return ((!_newVeloctySetWhilePaused.HasValue) ? Velocity : _newVeloctySetWhilePaused.Value).magnitude;
			}
			set
			{
				SetSpeed(value);
			}
		}

		public AiControlledAircraftScript AIScript { get; private set; }

		[Exposed]
		public float Altitude => GlobalPosition.y - GameWorld.Instance.SeaLevel.GetValueOrDefault();

		[Exposed]
		public float AltitudeAgl
		{
			get
			{
				Vector3 position = OrientedCenterOfMassRigidBodies.transform.position;
				if (position == _altitudeAglPos)
				{
					return _altitudeAgl;
				}
				RaycastHit hitInfo = default(RaycastHit);
				_altitudeAglPos = position;
				if (Physics.Raycast(position, Vector3.down, out hitInfo, float.PositiveInfinity, 9437200))
				{
					_altitudeAgl = hitInfo.distance;
					return hitInfo.distance;
				}
				_altitudeAgl = Altitude;
				return Altitude;
			}
		}

		public Vector3 AngularVelocity
		{
			get
			{
				if (RemoteAircraft)
				{
					return MainCockpit.Body.SyncData.AngularVelocity;
				}
				return MainCockpit.Body.RigidBody.angularVelocity;
			}
		}

		public AtmosphereSample AtmosphereSample { get; private set; }

		public List<BodyScript> Bodies { get; private set; }

		public GroupCenterOfMass CenterOfMass
		{
			get
			{
				return _centerOfMass;
			}
			private set
			{
				_centerOfMass = value;
			}
		}

		public Transform Children { get; private set; }

		public AircraftControls Controls { get; private set; }

		public CraftUpdateScript CraftUpdate { get; private set; }

		public float CriticalDamageThreshold { get; set; }

		public bool CriticallyDamaged { get; private set; }

		public float Damage { get; set; }

		public PartDamageEffects DamageEffects { get; private set; }

		public bool DamageVisualizerEnabled { get; private set; }

		public bool DisableBombs { get; set; }

		public bool DisableCannons { get; set; }

		public bool DisableGuns { get; set; }

		public bool DisableMissiles { get; set; }

		public bool DisableRockets { get; set; }

		public bool DrawAerodynamicCenter
		{
			get
			{
				return _drawAerodynamicCenter;
			}
			set
			{
				_drawAerodynamicCenter = value;
				if (!value && _aerodynamicCenterGameObject != null)
				{
					UnityEngine.Object.Destroy(_aerodynamicCenterGameObject);
				}
				else if (value && _aerodynamicCenterGameObject == null)
				{
					_aerodynamicCenterGameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					_aerodynamicCenterGameObject.GetComponent<Collider>().enabled = false;
					_aerodynamicCenterGameObject.transform.localScale = Vector3.one * 1f;
					_aerodynamicCenterGameObject.GetComponent<MeshRenderer>().material.color = Constants.Colors.PrimaryLight;
				}
			}
		}

		public bool DrawCenterOfMass
		{
			get
			{
				return _drawCenterOfMass;
			}
			set
			{
				_drawCenterOfMass = value;
				if (!value && _centerOfMassGameObject != null)
				{
					UnityEngine.Object.Destroy(_centerOfMassGameObject);
				}
				else if (value && _centerOfMassGameObject == null)
				{
					_centerOfMassGameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					_centerOfMassGameObject.GetComponent<Collider>().enabled = false;
					_centerOfMassGameObject.transform.localScale = Vector3.one * 1f;
					_centerOfMassGameObject.GetComponent<MeshRenderer>().material.color = Color.red;
				}
			}
		}

		public IReadOnlyList<ICraftEngine> Engines => _engines;

		public Context ExpressionContext
		{
			get
			{
				if (_expressionContext == null)
				{
					_expressionContext = new Context(true, this);
					_expressionContext.GetDeltaTime = () => Time.deltaTime;
					Controls.SetupContext(_expressionContext);
				}
				return _expressionContext;
			}
		}

		public float Fuel { get; private set; }

		public float FuelCapacity { get; private set; }

		public bool GenerationComplete { get; private set; }

		public Vector3 GlobalPosition
		{
			get
			{
				return Utility.ConvertFloatingOriginToAbsolutePosition(MainCockpit.transform.position);
			}
			set
			{
				Vector3 delta = value - GlobalPosition;
				MoveBodies(delta);
				NetworkAircraft?.OnCraftRepositioned();
			}
		}

		public bool HasInputOverrides => Controls.HasInputOverrides;

		public bool InertiaTensorRecalculationEnabled { get; set; } = true;

		public float InitialFuel { get; set; }

		public float InitialFuelCapacity { get; private set; }

		public List<PartData> InitiallyDisconnectedParts { get; private set; }

		public InletAir InletAir { get; private set; }

		public InstrumentData InstrumentData
		{
			get
			{
				InstrumentData result = default(InstrumentData);
				if (FuelCapacity > 0f)
				{
					result.Fuel = Fuel / InitialFuelCapacity;
				}
				result.Throttle = Controls.Throttle;
				result.Speed = AirSpeed;
				result.SignedSpeed = Vector3.Dot(OrientedCenterOfMassRigidBodies.forward, Velocity);
				result.Altitude = LevelBase.CurrentLevel.GetElevationAboveSeaLevel(Altitude);
				Vector3 eulerAngles = MainCockpit.Body.transform.rotation.eulerAngles;
				result.Heading = eulerAngles.y;
				result.Roll = eulerAngles.z;
				result.Pitch = Mathf.Asin(OrientedCenterOfMassRigidBodies.forward.y) * 57.29578f;
				if (float.IsNaN(result.Pitch))
				{
					result.Pitch = 0f;
				}
				return result;
			}
		}

		public float IRSignature { get; private set; }

		public bool IsConnectedToCatapult { get; set; }

		bool IFuelSource.IsEmpty => Fuel == 0f;

		public bool IsInitialized => _initialized;

		public bool IsNonFlyableAircraft { get; set; }

		public bool IsPrimaryLocalPlayer { get; private set; }

		public bool IsTargetingPlayer => (TargetingSystem?.CurrentTarget as PlayerTarget)?.Player?.IsPrimaryLocal == true;

		public bool IsThudSoundEnabled => !IsConnectedToCatapult;

		public CraftLoadContext LoadContext => Aircraft.LoadContext;

		public PartScript MainCockpit
		{
			get
			{
				return _mainCockpit;
			}
			private set
			{
				PartScript mainCockpit = _mainCockpit;
				if (mainCockpit != null && mainCockpit != value)
				{
					mainCockpit.GetComponent<CockpitScript>().PrimaryCockpit = false;
				}
				_mainCockpit = value;
				this.MainCockpitChanged?.Invoke(this, new MainCockpitChangedEventArgs(mainCockpit, value));
			}
		}

		public PartScript MainSeat
		{
			get
			{
				return _mainSeat;
			}
			set
			{
				if (_mainSeat != null && _mainSeat != value)
				{
					_mainSeat.GetModifier<SeatScript>().PrimarySeat = false;
				}
				_mainSeat = value;
			}
		}

		public INetworkAircraft NetworkAircraft { get; private set; }

		public Transform OrientedCenterOfMassRigidBodies { get; private set; }

		public float? OverrideSignatureNormalized { get; set; }

		public HashSet<int> PartCollidersSkippingCollisionHandler { get; private set; }

		public List<PartData> Parts { get; private set; }

		public FlightScenePlayer Player { get; private set; }

		public Vector3 Position
		{
			get
			{
				return MainCockpit?.transform.position ?? Vector3.zero;
			}
			set
			{
				Vector3 delta = value - Position;
				MoveBodies(delta);
				NetworkAircraft?.OnCraftRepositioned();
			}
		}

		public CraftPowertrainScript Powertrain { get; private set; }

		public float RadarSignature { get; private set; }

		public ReflectionProbe ReflectionProbe
		{
			get
			{
				return _reflectionProbe;
			}
			set
			{
				if (!(_reflectionProbe != value))
				{
					return;
				}
				_reflectionProbe = value;
				foreach (PartData part in Parts)
				{
					part.PartScript?.PartMaterialScript.SetReflectionProbe(value);
				}
				foreach (PartGroupScript value2 in _partGroups.Values)
				{
					value2.SetReflectionProbe(value);
				}
			}
		}

		public List<RefuelProbeScript> RefuelProbes { get; private set; }

		public bool RemoteAircraft { get; private set; }

		public bool RequiresFlapsSlider { get; private set; }

		public bool RequiresTrimSlider { get; private set; }

		public bool RequiresVtolSlider { get; private set; }

		public Vector3 Rotation
		{
			get
			{
				return OrientedCenterOfMassRigidBodies.eulerAngles;
			}
			set
			{
				GameObject gameObject = new GameObject("TempRotationContainer");
				gameObject.transform.position = Position;
				gameObject.transform.eulerAngles = Rotation;
				int childCount = Children.childCount;
				List<Transform> list = new List<Transform>();
				for (int i = 0; i < childCount; i++)
				{
					list.Add(Children.GetChild(i));
				}
				foreach (Transform item in list)
				{
					item.parent = gameObject.transform;
				}
				gameObject.transform.eulerAngles = value;
				foreach (Transform item2 in list)
				{
					item2.parent = Children;
				}
				UnityEngine.Object.Destroy(gameObject);
			}
		}

		public RoundRobinUpdateManager RoundRobinUpdateManager { get; } = new RoundRobinUpdateManager();

		public List<PartScript> SyncParts { get; private set; } = new List<PartScript>();

		public Target Target { get; private set; }

		public TargetingPodScript TargetingPod { get; private set; }

		public TargetingSystem TargetingSystem { get; private set; }

		[field: SerializeField]
		public ushort TeamId { get; private set; }

		public ThemeScript Theme { get; private set; }

		float IFuelSource.TotalCapacity => FuelCapacity;

		public float TotalDragForceMagnitude { get; private set; }

		float IFuelSource.TotalFuel => Fuel;

		public VariableSystemScript VariableSystem { get; set; }

		public Vector3 Velocity { get; private set; }

		public VtolManagerScript VtolManagerScript { get; private set; }

		public WheelManagerScript WheelManager { get; private set; }

		public List<IWheelPart> WheelParts { get; private set; }

		public AudioSource WindAudio => _windAudio;

		public Vector3 WindVelocity
		{
			get
			{
				return _windSpeed;
			}
			set
			{
				_windSpeed = value;
			}
		}

		public List<IWingScript> Wings => _wings;

		public Transform WorldRigidBodies { get; private set; }

		[Exposed]
		private float Rpm1 => GetRpm(0);

		[Exposed]
		private float Rpm2 => GetRpm(1);

		[Exposed]
		private float Rpm3 => GetRpm(2);

		[Exposed]
		private float Rpm4 => GetRpm(3);

		[Exposed]
		private float AngleOfAttack
		{
			get
			{
				Vector3 vector = MainCockpit.transform.InverseTransformDirection(Velocity - WindVelocity);
				return 57.29578f * Mathf.Atan2(vector.y, vector.z);
			}
		}

		[Exposed]
		private float AngleOfSlip
		{
			get
			{
				Vector3 vector = MainCockpit.transform.InverseTransformDirection(Velocity - WindVelocity);
				return 57.29578f * Mathf.Atan2(vector.x, vector.z);
			}
		}

		[Exposed(Name = "Fuel")]
		private float FuelProportion
		{
			get
			{
				if (InitialFuelCapacity > 0f)
				{
					return Fuel / InitialFuelCapacity;
				}
				return 0f;
			}
		}

		[Exposed]
		private float GForce => (Physics.gravity - _acceleration).magnitude / 9.81f;

		[Exposed]
		private float GS => GetSpeed(SpeedType.GS);

		[Exposed]
		private float Heading
		{
			get
			{
				Vector3 forward = MainCockpit.transform.forward;
				return Mathf.Atan2(forward.x, forward.z) * 57.29578f % 360f;
			}
		}

		[Exposed]
		private float IAS => GetSpeed(SpeedType.IAS);

		[Exposed]
		private float Latitude => GlobalPosition.z;

		[Exposed]
		private float Longitude => GlobalPosition.x;

		[Exposed]
		private float PitchAngle => Mathf.DeltaAngle(0f, Mathf.Asin(MainCockpit.transform.forward.y) * 57.29578f);

		[Exposed]
		private float PitchRate
		{
			get
			{
				if (LoadContext != CraftLoadContext.Flight)
				{
					return 0f;
				}
				return MainCockpit.transform.InverseTransformDirection(AngularVelocity).x * 57.29578f;
			}
		}

		[Exposed]
		private float RollAngle => Mathf.DeltaAngle(0f, MainCockpit.transform.eulerAngles.z);

		[Exposed]
		private float RollRate
		{
			get
			{
				if (LoadContext != CraftLoadContext.Flight)
				{
					return 0f;
				}
				return MainCockpit.transform.InverseTransformDirection(AngularVelocity).z * 57.29578f;
			}
		}

		[Exposed(Name = "SelectedWeapon")]
		private string SelectedWeaponName => TargetingSystem?.SelectedWeaponSystem?.WeaponPartName ?? string.Empty;

		[Exposed]
		private float TargetDistance
		{
			get
			{
				if (!TargetSelected)
				{
					return 0f;
				}
				return (TargetingSystem.CurrentTarget.Position - Position).magnitude;
			}
		}

		[Exposed]
		private float TargetElevation
		{
			get
			{
				if (TargetSelected)
				{
					return Mathf.Asin((TargetingSystem.CurrentTarget.Position - Position).normalized.y) * 57.29578f;
				}
				return 0f;
			}
		}

		[Exposed]
		private float TargetHeading
		{
			get
			{
				if (TargetSelected)
				{
					Vector3 vector = TargetingSystem.CurrentTarget.Position - Position;
					return (Mathf.Atan2(vector.x, vector.z) * 57.29578f + 360f) % 360f;
				}
				return 0f;
			}
		}

		[Exposed]
		private bool TargetLocked
		{
			get
			{
				if (TargetSelected)
				{
					return TargetingSystem.CurrentTargetWarningState == TargetingSystem.WarningState.Locked;
				}
				return false;
			}
		}

		[Exposed]
		private bool TargetLocking
		{
			get
			{
				if (TargetSelected)
				{
					return TargetingSystem.CurrentTargetWarningState == TargetingSystem.WarningState.Acquiring;
				}
				return false;
			}
		}

		[Exposed]
		private bool TargetSelected
		{
			get
			{
				if (TargetingSystem?.CurrentTarget != null)
				{
					return TargetingSystem.TargetMatchesMode;
				}
				return false;
			}
		}

		[Exposed]
		private float TAS => GetSpeed(SpeedType.TAS);

		[Exposed(Name = "Time")]
		private float TimeSinceStart
		{
			get
			{
				if (_startTime.HasValue)
				{
					return Time.time - _startTime.Value;
				}
				return 0f;
			}
		}

		[Exposed]
		private float VerticalG => Vector3.Dot(MainCockpit.transform.up, _acceleration - Physics.gravity) / 9.81f;

		[Exposed]
		private float YawRate
		{
			get
			{
				if (LoadContext != CraftLoadContext.Flight)
				{
					return 0f;
				}
				return MainCockpit.transform.InverseTransformDirection(AngularVelocity).y * 57.29578f;
			}
		}

		public event EventHandler<AircraftKilledEventArgs> AircraftKilled;

		public event EventHandler<AircraftLocationChangedEventArgs> AircraftLocationChanged
		{
			add
			{
				_aircraftLocationChanged += WeakEventHandler.Create(value, delegate(EventHandler<AircraftLocationChangedEventArgs> x)
				{
					_aircraftLocationChanged -= x;
				});
			}
			remove
			{
				_aircraftLocationChanged -= WeakEventHandler.FindUnregisterHandler(this._aircraftLocationChanged, value);
			}
		}

		public event Action<BodyScript> BodyCreated;

		public event Action<BodyScript> BodyRemoved;

		public event Action<float> FastTouchdown;

		public event Action<AircraftScript> Initialized;

		public event EventHandler<MainCockpitChangedEventArgs> MainCockpitChanged;

		public event AircraftDamagedDelegate OnAircraftDamaged;

		public event AircraftStructureChangedDelegate OnAircraftStructureChanged;

		public event PartEnteredWaterDelegate OnPartEnteredWater;

		public event PartEnteredWaterDelegate OnPartExitedWater;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> PlayerEntered;

		public event EventHandler<FlightScenePlayerAircraftEventArgs> PlayerExited;

		public event EventHandler<TeamChangedEventArgs> TeamChanged;

		public event EventHandler<AircraftScriptEventArgs> Unloaded;

		public event Action<Vector3> VelocitySet;

		private event EventHandler<AircraftLocationChangedEventArgs> _aircraftLocationChanged;

		public static Aerofoil GetAirfoil(string airfoilName)
		{
			return Game.Instance.ResourceLoader.LoadAirfoil(airfoilName);
		}

		public void AircraftDamaged(PartScript partScript)
		{
			if (this.OnAircraftDamaged != null)
			{
				this.OnAircraftDamaged(partScript);
			}
			LogDamageMessage(partScript);
		}

		public void AircraftStructureChanged()
		{
			if (LoadContext == CraftLoadContext.Designer)
			{
				RebuildAircraftStructure();
			}
			else
			{
				RebuildPartList();
				CheckForCriticalDamage();
			}
			if (this.OnAircraftStructureChanged != null)
			{
				this.OnAircraftStructureChanged();
			}
			RadarSignature = CalculateRadarSignature();
		}

		public Bounds CalculateBounds(bool includeDisconnectedParts)
		{
			if (Children.childCount > 0)
			{
				if (LoadContext == CraftLoadContext.Designer)
				{
					EditorCollider.GlobalUpdateId++;
					Bounds bounds = default(Bounds);
					bool flag = false;
					{
						foreach (PartData part in Aircraft.Assembly.Parts)
						{
							if (!includeDisconnectedParts && !part.InitiallyConnectedToMainCockpit)
							{
								continue;
							}
							foreach (EditorCollider editorCollider in part.PartScript.EditorColliders)
							{
								try
								{
									if (editorCollider.IncludeInBounds)
									{
										editorCollider.Update();
										if (flag)
										{
											bounds = Utilities.ExpandBounds(bounds, editorCollider.Bounds);
											continue;
										}
										bounds = editorCollider.Bounds;
										flag = true;
									}
								}
								catch (Exception ex)
								{
									UnityEngine.Debug.LogException(ex);
									UnityEngine.Debug.LogError($"Error calculating bounds for part '{part.Name}' (ID: {part.Id}). \n{ex.Message}");
								}
							}
						}
						return bounds;
					}
				}
				Bounds result = default(Bounds);
				bool flag2 = false;
				{
					foreach (PartData part2 in Parts)
					{
						if (!includeDisconnectedParts && !part2.PartScript.ConnectedToMainCockpit)
						{
							continue;
						}
						Collider[] componentsInChildren = part2.PartScript.GetComponentsInChildren<Collider>();
						foreach (Collider collider in componentsInChildren)
						{
							try
							{
								if (flag2)
								{
									result.Encapsulate(collider.bounds);
									continue;
								}
								result = collider.bounds;
								flag2 = true;
							}
							catch (Exception ex2)
							{
								UnityEngine.Debug.LogException(ex2);
								UnityEngine.Debug.LogError($"Error calculating bounds for part '{part2.Name}' (ID: {part2.Id}). \n{ex2.Message}");
							}
						}
					}
					return result;
				}
			}
			return default(Bounds);
		}

		public float CalculateRadarSignature()
		{
			float num = 0f;
			foreach (PartData part in Parts)
			{
				num += part.PartDrag.GetDrag(PartDrag.DragDirection.Forward);
				num += part.PartDrag.GetDrag(PartDrag.DragDirection.Backward);
				num += part.PartDrag.GetDrag(PartDrag.DragDirection.Leftward);
				num += part.PartDrag.GetDrag(PartDrag.DragDirection.Rightward);
				num += part.PartDrag.GetDrag(PartDrag.DragDirection.Downward);
				num += part.PartDrag.GetDrag(PartDrag.DragDirection.Upward);
			}
			return num + _currentWingSurfaceArea;
		}

		public float CalculateStreamlineMagnitude()
		{
			if (!_cachedStreamlineMagnitude.HasValue)
			{
				float value = 1f;
				PartDrag streamlineFactor = Aircraft.CraftDrag.StreamlineFactor;
				if (streamlineFactor.TotalArea > 0f)
				{
					Vector3 normalized = Velocity.normalized;
					Vector3 vector = OrientedCenterOfMassRigidBodies.InverseTransformDirection(normalized);
					value = 0f;
					value += ((vector.z > 0f) ? streamlineFactor.GetDrag(PartDrag.DragDirection.Forward) : streamlineFactor.GetDrag(PartDrag.DragDirection.Backward)) * (vector.z * vector.z);
					value += ((vector.y > 0f) ? streamlineFactor.GetDrag(PartDrag.DragDirection.Upward) : streamlineFactor.GetDrag(PartDrag.DragDirection.Downward)) * (vector.y * vector.y);
					value += ((vector.x > 0f) ? streamlineFactor.GetDrag(PartDrag.DragDirection.Rightward) : streamlineFactor.GetDrag(PartDrag.DragDirection.Leftward)) * (vector.x * vector.x);
					value = Mathf.Clamp01(value);
				}
				_cachedStreamlineMagnitude = value;
			}
			return _cachedStreamlineMagnitude.Value;
		}

		public BodyScript CreateBodyScript(RigidBodyGroup rigidBodyGroup)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.parent = Children;
			gameObject.layer = 21;
			BodyScript bodyScript = gameObject.AddComponent<BodyScript>();
			bodyScript.Id = GetNextBodyId();
			gameObject.name = $"Body {bodyScript.Id}";
			Bodies.Add(bodyScript);
			bodyScript.Aircraft = this;
			bodyScript.RigidBodyGroup = rigidBodyGroup;
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (PartData part in rigidBodyGroup.Parts)
			{
				if (part.Enabled)
				{
					Vector3 vector = part.PartScript.transform.TransformPoint(part.PartScript.Part.CenterOfMass) * part.LoadedMass;
					zero += vector;
					num += part.LoadedMass;
				}
			}
			if (num > 0f)
			{
				zero /= num;
			}
			else
			{
				zero = Vector3.zero;
				foreach (PartData part2 in rigidBodyGroup.Parts)
				{
					zero += part2.PartScript.transform.TransformPoint(part2.PartScript.Part.CenterOfMass);
				}
				zero /= (float)rigidBodyGroup.Parts.Count;
			}
			if (float.IsNaN(zero.x) || float.IsNaN(zero.y) || float.IsNaN(zero.z))
			{
				UnityEngine.Debug.Log("TODO: CoM is NaN");
				foreach (PartData part3 in rigidBodyGroup.Parts)
				{
					if (part3.Enabled)
					{
						Vector3 vector2 = part3.PartScript.transform.TransformPoint(part3.PartScript.Part.CenterOfMass);
						string text = part3.PartType.Name;
						Vector3 vector3 = vector2;
						UnityEngine.Debug.Log("Part: " + text + ", weighted pos = " + vector3.ToString());
					}
				}
				zero = Vector3.zero;
			}
			gameObject.transform.position = zero;
			gameObject.transform.eulerAngles = Vector3.zero;
			rigidBodyGroup.CenterOfMass = zero;
			rigidBodyGroup.Mass = num;
			foreach (PartData part4 in rigidBodyGroup.Parts)
			{
				if (part4.Enabled)
				{
					part4.PartScript.Body = bodyScript;
				}
			}
			bodyScript.InitializeRigidBody(rigidBodyGroup, RemoteAircraft);
			this.BodyCreated?.Invoke(bodyScript);
			return bodyScript;
		}

		public void DeletePart(PartScript partScript)
		{
			partScript.OnPartDeleted();
			PartConnection[] array = partScript.Part.PartConnections.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
			}
			Aircraft.Assembly.RemovePart(partScript.Part);
			Parts.Remove(partScript.Part);
			partScript.transform.parent = null;
			partScript.gameObject.SetActive(value: false);
			UnityEngine.Object.Destroy(partScript.gameObject);
		}

		public Vector3 GetAerodynamicCenter()
		{
			Vector3 zero = Vector3.zero;
			float num = 0f;
			foreach (IWingScript wing in _wings)
			{
				float lift;
				Vector3 centreOfLift = wing.GetCentreOfLift(out lift);
				num += lift;
				zero += centreOfLift * lift;
			}
			if (num > 0f)
			{
				zero /= num;
			}
			return zero;
		}

		public BodyScript GetBody(int id)
		{
			foreach (BodyScript body in Bodies)
			{
				if (body.Id == id)
				{
					return body;
				}
			}
			return null;
		}

		(Bounds Bounds, Vector3 BoundsOffset) IRepositionable.GetBounds()
		{
			Bounds item = CalculateBounds(includeDisconnectedParts: false);
			Vector3 item2 = item.center - (MainCockpit?.transform.position ?? Vector3.zero);
			return (Bounds: item, BoundsOffset: item2);
		}

		public int GetNextBodyId()
		{
			return _nextBodyId++;
		}

		public PartData GetPartById(int partId, bool includeDisconnected = false)
		{
			if (includeDisconnected)
			{
				foreach (PartData part in Aircraft.Assembly.Parts)
				{
					if (part.Id == partId)
					{
						return part;
					}
				}
				return null;
			}
			foreach (PartData part2 in Parts)
			{
				if (part2.Id == partId)
				{
					return part2;
				}
			}
			return null;
		}

		public PartGroupScript GetPartGroup(int id)
		{
			return _partGroups[id];
		}

		public List<RequiredModInfo> GetRequiredMods()
		{
			List<RequiredModInfo> list = new List<RequiredModInfo>();
			foreach (PartData item in Aircraft.Assembly.Parts.Where((PartData x) => x.PartType != null && x.PartType.Mod != null))
			{
				ModInfo modInfo = item.PartType.Mod.ModInfo;
				RequiredModInfo mod = new RequiredModInfo(modInfo.Name, modInfo.Author, modInfo.Version, modInfo.LastUpdated, modInfo.SteamWorkshopItemId);
				if (!list.Any((RequiredModInfo x) => x.Name == mod.Name && x.Author == mod.Author && x.Version == mod.Version && x.LastModified == mod.LastModified))
				{
					list.Add(mod);
				}
			}
			return list;
		}

		public float GetSpeed(SpeedType type)
		{
			if (LoadContext != CraftLoadContext.Flight)
			{
				return 0f;
			}
			Vector3 velocity = MainCockpit.Body.Velocity;
			if (type == SpeedType.GS)
			{
				return velocity.magnitude;
			}
			float magnitude = (velocity - WindVelocity).magnitude;
			switch (type)
			{
			case SpeedType.TAS:
				return magnitude;
			case SpeedType.IAS:
				return magnitude * Mathf.Sqrt(AtmosphereSample.AirDensityRatio);
			default:
				UnityEngine.Debug.LogError($"Unknown speed type: {type}");
				return -1f;
			}
		}

		public float GetStats(AircraftStats statsToGet)
		{
			switch (statsToGet)
			{
			case AircraftStats.WingSpan:
				return CalculateBounds(includeDisconnectedParts: false).extents.x * 2f;
			case AircraftStats.Length:
				return CalculateBounds(includeDisconnectedParts: false).extents.z * 2f;
			case AircraftStats.Height:
				return CalculateBounds(includeDisconnectedParts: false).extents.y * 2f;
			case AircraftStats.WingLoading:
				return GetStats(AircraftStats.LoadedWeight) / GetStats(AircraftStats.WingArea);
			case AircraftStats.EmptyWeight:
				return GetStats(AircraftStats.LoadedWeight) - GetStats(AircraftStats.FuelAmount) * 0.804f;
			case AircraftStats.LoadedWeight:
				return CenterOfMass.LoadedMass / 0.01f;
			case AircraftStats.PowerToWeightRatio:
				return GetStats(AircraftStats.PowerOutput) / ((0f - Physics.gravity.y) * GetStats(AircraftStats.LoadedWeight));
			case AircraftStats.HorsePowerToWeightRatio:
				return GetStats(AircraftStats.HorsePower) / (GetStats(AircraftStats.LoadedWeight) * 2.20462f);
			case AircraftStats.HorsePower:
			{
				float num = 0f;
				{
					foreach (PartData part in Parts)
					{
						foreach (PartModifierData modifier3 in part.Modifiers)
						{
							if (modifier3 is PropEngineAdvancedData propEngineAdvancedData)
							{
								num += propEngineAdvancedData.Power * 0.5f;
							}
						}
						JEngineData modifier = part.GetModifier<JEngineData>();
						if (modifier != null)
						{
							num += modifier.Power;
						}
					}
					return num;
				}
			}
			case AircraftStats.PowerOutput:
			{
				float num5 = 0f;
				foreach (PartData part2 in Parts)
				{
					foreach (PartModifierData modifier4 in part2.Modifiers)
					{
						EngineData engineData = modifier4 as EngineData;
						PropEngineAdvancedData propEngineAdvancedData2 = modifier4 as PropEngineAdvancedData;
						if (engineData != null && propEngineAdvancedData2 == null)
						{
							num5 += engineData.Power * engineData.PowerMultiplier;
						}
					}
					JetEngineData modifier2 = part2.GetModifier<JetEngineData>();
					if (modifier2 != null)
					{
						num5 += modifier2.CalculateThrustAtSeaLevel() * 0.01f;
					}
				}
				return num5 / 0.01f;
			}
			case AircraftStats.WingArea:
			{
				float num4 = 0f;
				{
					foreach (PartData part3 in Parts)
					{
						WingData result2;
						if (part3.TryGetModifier<JWingData>(out var result))
						{
							num4 += result.WingArea;
						}
						else if (part3.TryGetModifier<WingData>(out result2))
						{
							num4 += result2.WingArea;
						}
					}
					return num4;
				}
			}
			case AircraftStats.PartCount:
				return Parts.Count;
			case AircraftStats.ControlSurfaceCount:
			{
				int num3 = 0;
				foreach (PartData part4 in Parts)
				{
					List<ControlSurfaceScript> list2 = Utilities.FindObjectsMyselfOrChildren<ControlSurfaceScript>(null, part4.PartScript.gameObject);
					if (list2 != null)
					{
						num3 += list2.Count;
					}
				}
				return num3;
			}
			case AircraftStats.FuelAmount:
			{
				float num2 = 0f;
				foreach (PartData part5 in Parts)
				{
					List<FuelTankScript> list = Utilities.FindObjectsMyselfOrChildren<FuelTankScript>(null, part5.PartScript.gameObject);
					if (list == null)
					{
						continue;
					}
					foreach (FuelTankScript item in list)
					{
						num2 += item.FuelTank.Fuel;
					}
				}
				return Mathf.Max(num2, 0f);
			}
			case AircraftStats.Drag:
			{
				if (Aircraft.AerodynamicsModelType == CraftAerodynamicsModelType.Legacy)
				{
					return new DragCalculator(Parts).CalculateDragCount(PartDrag.DragDirection.Forward);
				}
				DesignerScript designerScript = Designer.Instance?.DesignerScript;
				if (designerScript == null)
				{
					UnityEngine.Debug.LogError("Unable to calculate craft drag stat outside of the designer.");
					return 0f;
				}
				designerScript.DragCalculator.CalculateDragInDesigner(this, PartDrag.DragDirection.Forward, out var dragCount);
				return dragCount;
			}
			case AircraftStats.PerformanceCost:
				return PerformanceCost.CalculateCost(Aircraft);
			default:
				throw new Exception("Aircraft statistic not found.");
			}
		}

		public void GiveFuel(float amount)
		{
			_fuelGainedInFrame += amount;
		}

		public void HandleExplosiveBlast(List<PartScript> aircraftParts, float blastForce, float blastRadius, float criticalBlastRadius, Vector3 blastOrigin, AircraftScript owner, List<AircraftScript> allAffectedAircraft)
		{
			if (aircraftParts == null || aircraftParts.Count == 0 || FlightSceneScript.IsPeacefulMode)
			{
				return;
			}
			if (owner != null && allAffectedAircraft != null)
			{
				bool flag = false;
				AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
				for (int i = 0; i < allAffectedAircraft.Count; i++)
				{
					if (allAffectedAircraft[i] == aircraftScript)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					AchievementHelper.OnAircraftAttacked(this, owner);
				}
			}
			if (owner != null && allAffectedAircraft != null)
			{
				FlightSceneScript instance = FlightSceneScript.Instance;
				foreach (AircraftScript item in allAffectedAircraft)
				{
					instance.TeamAggressionManager.SetAggressionLevel(owner.TeamId, item.TeamId, AggressionLevel.Hostile);
				}
			}
			Dictionary<BodyScript, List<PartScript>> value;
			using (CollectionPool<Dictionary<BodyScript, List<PartScript>>, KeyValuePair<BodyScript, List<PartScript>>>.Get(out value))
			{
				for (int j = 0; j < aircraftParts.Count; j++)
				{
					PartScript partScript = aircraftParts[j];
					if (!value.TryGetValue(partScript.Body, out var value2))
					{
						value2 = (value[partScript.Body] = CollectionPool<List<PartScript>, PartScript>.Get());
					}
					value2.Add(partScript);
				}
				foreach (KeyValuePair<BodyScript, List<PartScript>> item2 in value)
				{
					item2.Key.HandleExplosiveBlast(item2.Value, blastForce, blastRadius, criticalBlastRadius, blastOrigin, owner);
					CollectionPool<List<PartScript>, PartScript>.Release(item2.Value);
				}
				if (value.Count > 0)
				{
					AircraftStructureChanged();
				}
			}
		}

		public void Initialize(AircraftData aircraft, ushort teamId, Func<AircraftScript, Target> createAirTarget = null, bool remoteAircraft = false, INetworkAircraft networkAircraft = null)
		{
			Aircraft = aircraft;
			NetworkAircraft = networkAircraft;
			RemoteAircraft = remoteAircraft;
			Theme = new ThemeScript(aircraft.CurrentTheme, LoadContext);
			TeamId = teamId;
			VariableSystem = base.gameObject.AddComponent<VariableSystemScript>();
			VariableSystem.Initialise(Aircraft.VariableSetters, this);
			DamageEffects = new PartDamageEffects(networkAircraft);
			Powertrain = CraftPowertrainScript.Create(this);
			if (LoadContext == CraftLoadContext.Flight && FloatingOriginScript.Instance != null)
			{
				base.transform.SetParent(FlightSceneScript.Instance.AircraftContainer, worldPositionStays: true);
				Target = createAirTarget(this);
				FlightSceneScript.Instance.TargetRegistry.RegisterTarget(Target);
				TargetingSystem = new TargetingSystem(this, teamId);
				FloatingOriginScript.Instance.Repositioned += FloatingOriginChanged;
				_floatingOriginSubbed = true;
			}
			CreateReflectionProbe();
		}

		public void LogDamageMessage(PartScript partScript)
		{
			if (!(partScript != null) || !partScript.ConnectedToMainCockpit)
			{
				return;
			}
			if (!CriticallyDamaged)
			{
				if (IsPrimaryLocalPlayer)
				{
					if (_damageMessage == null)
					{
						_damageMessage = "Part damaged: " + partScript.Part.PartType.Name;
					}
					else
					{
						_damageMessage = "Multiple parts damaged";
					}
				}
				else if (LevelBase.CurrentLevel.ShowEnemyDamageMessages && IsTargetingPlayer)
				{
					_damageMessage = "Enemy aircraft damaged";
				}
			}
			else if (!_criticallyDamagedMessageShown)
			{
				_criticallyDamagedMessageShown = true;
				if (IsPrimaryLocalPlayer)
				{
					_damageMessage = "Your aircraft has been critically damaged";
				}
				else if (LevelBase.CurrentLevel.ShowEnemyDamageMessages && IsTargetingPlayer)
				{
					_damageMessage = "Enemy aircraft has been critically damaged";
				}
			}
		}

		public void LookAt(Vector3 position, Vector3 up)
		{
			Transform transform = new GameObject("TempGo").transform;
			transform.position = MainCockpit.transform.position;
			transform.up = MainCockpit.transform.up;
			transform.rotation = MainCockpit.transform.rotation;
			transform.LookAt(position, up);
			Rotation = transform.transform.eulerAngles;
			UnityEngine.Object.Destroy(transform.gameObject);
		}

		public void MarkAsCriticallyDamaged()
		{
			if (!CriticallyDamaged)
			{
				CriticallyDamaged = true;
				_raiseAircraftKilledEvent = true;
			}
		}

		public void MoveWindAudio(Transform parent)
		{
			_windAudioParent.parent = parent;
			_windAudioParent.localPosition = new Vector3(0f, 0.1f, 0f);
		}

		public void OnBeginReposition(Vector3 approximateGlobalPosition)
		{
			Controls.ParkingBrake = false;
			foreach (PartData part in Parts)
			{
				part.PartScript.OnBeginReposition();
			}
		}

		public void OnDamaged(int? attackerPlayerId, float damage)
		{
			if (attackerPlayerId.HasValue && attackerPlayerId.Value != NetworkAircraft.PlayerId)
			{
				if (!_damageFromAttackers.ContainsKey(attackerPlayerId.Value))
				{
					_damageFromAttackers[attackerPlayerId.Value] = 0f;
				}
				_damageFromAttackers[attackerPlayerId.Value] += damage;
			}
			Damage += damage;
		}

		public void OnEndReposition(Vector3 finalGlobalPosition, Vector3 finalRotation)
		{
			foreach (BodyScript body in Bodies)
			{
				body.OnRepositioned();
			}
			foreach (PartData part in Parts)
			{
				part.PartScript.OnEndReposition();
			}
			if (this._aircraftLocationChanged != null)
			{
				this._aircraftLocationChanged(this, new AircraftLocationChangedEventArgs(Position));
			}
			FlightSceneScript.Instance.CameraScript?.AircraftRepositioned();
		}

		public void OnFastTouchdown(float overStress)
		{
			this.FastTouchdown?.Invoke(overStress);
		}

		public virtual void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			_cachedStreamlineMagnitude = null;
			if (LoadContext != CraftLoadContext.Flight || PauseManager.Paused || IsNonFlyableAircraft)
			{
				return;
			}
			Physics.SyncTransforms();
			UpdateAirDensity(Altitude);
			if (_newVeloctySetWhilePaused.HasValue)
			{
				SetVelocity(_newVeloctySetWhilePaused.Value, _newVelocitySetWhilePausedIgnoresDisconnectedParts);
				_newVeloctySetWhilePaused = null;
			}
			if (_fuelUsedInFrame > _fuelGainedInFrame)
			{
				_fuelUsedInFrame -= _fuelGainedInFrame;
				_fuelGainedInFrame = 0f;
			}
			else
			{
				_fuelGainedInFrame -= _fuelUsedInFrame;
				_fuelUsedInFrame = 0f;
				if (_fuelGainedInFrame > 0f)
				{
					float num = Mathf.Min(_fuelGainedInFrame, FuelCapacity - Fuel);
					if (num > 0f)
					{
						Fuel += num;
						_numActiveTanks = 0;
						for (int i = 0; i < _fuelTanks.Count; i++)
						{
							FuelTankData fuelTank = _fuelTanks[i].FuelTank;
							fuelTank.Fuel = fuelTank.Capacity * FuelProportion;
							_numActiveTanks++;
						}
					}
				}
			}
			if (_fuelUsedInFrame > 0f && _numActiveTanks > 0)
			{
				float num2 = _fuelUsedInFrame / (float)_numActiveTanks;
				float num3 = 0f;
				while (num3 < _fuelUsedInFrame && _numActiveTanks > 0)
				{
					for (int j = 0; j < _fuelTanks.Count; j++)
					{
						FuelTankScript fuelTankScript = _fuelTanks[j];
						if (fuelTankScript.FuelTank.Fuel > num2)
						{
							fuelTankScript.FuelTank.Fuel -= num2;
							num3 += num2;
						}
						else if (fuelTankScript.FuelTank.Fuel > 0f)
						{
							if (_numActiveTanks == 0)
							{
								UnityEngine.Debug.Log("Done");
							}
							fuelTankScript.FuelTank.Fuel = 0f;
							num3 += fuelTankScript.FuelTank.Fuel;
							_numActiveTanks--;
						}
					}
				}
				Fuel -= num3;
				_fuelUsedInFrame = 0f;
				_fuelGainedInFrame = 0f;
			}
			if (Fuel < 0f || _numActiveTanks == 0)
			{
				Fuel = 0f;
			}
			Vector3 vector = (Velocity = MainCockpit.Body.Velocity);
			_acceleration = (vector - _lastVelocity) / Time.deltaTime;
			_lastVelocity = vector;
		}

		public void OnGenerationComplete()
		{
			GenerationComplete = true;
			if (!Utilities.CompareVector3s(_floatingOriginMissed, Vector3.zero))
			{
				MoveBodies(-_floatingOriginMissed);
				_floatingOriginMissed = Vector3.zero;
			}
		}

		public virtual void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			if (LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			if (_raiseAircraftKilledEvent)
			{
				_raiseAircraftKilledEvent = false;
				int? topAttackerByDamage = GetTopAttackerByDamage();
				this.AircraftKilled?.Invoke(this, new AircraftKilledEventArgs(this, topAttackerByDamage));
			}
			if (!IsNonFlyableAircraft)
			{
				if (DrawAerodynamicCenter)
				{
					_aerodynamicCenter = GetAerodynamicCenter();
					_aerodynamicCenterGameObject.transform.position = _aerodynamicCenter;
				}
				if (DrawCenterOfMass)
				{
					_centerOfMassCalculatedForDebug = GetCenterOfMass();
					_centerOfMassGameObject.transform.position = _centerOfMassCalculatedForDebug;
				}
				InletAir.Update();
				if (DebugInput.GetKeyUp(KeyCode.KeypadEnter))
				{
					UnityEngine.Debug.Log($"Loaded {Aircraft.Name}. IR Signature: {IRSignature:n2}. Radar Signature: {RadarSignature:n2}");
				}
			}
		}

		public void OnPlayerEntered(FlightScenePlayer flightScenePlayer)
		{
			if (Player != null)
			{
				if (Player == flightScenePlayer)
				{
					throw new Exception("Player " + flightScenePlayer.NetworkPlayer.Name + " is unable to enter the craft because it is currently occupied by another player.");
				}
				throw new Exception("Player " + flightScenePlayer.NetworkPlayer.Name + " is unable to enter the craft because it is currently occupied by player '" + Player.NetworkPlayer.Name + "'.");
			}
			Player = flightScenePlayer;
			UpdatePlayerEventSubscriptions(flightScenePlayer, subscribe: true);
			IsPrimaryLocalPlayer = flightScenePlayer.IsPrimaryLocal;
			if (IsPrimaryLocalPlayer)
			{
				CameraManagerScript.Instance.SwitchingToNewViewMode += OnSwitchingToNewViewMode;
			}
			if (NetworkAircraft.IsOwner)
			{
				NetworkAircraft.SetRemotePlayerEnteredState(entered: true);
			}
			Initialize();
			if (TeamId != flightScenePlayer.TeamId)
			{
				OnTeamChanged(flightScenePlayer, new TeamChangedEventArgs(TeamId, flightScenePlayer.TeamId));
			}
			this.PlayerEntered?.Invoke(this, new FlightScenePlayerAircraftEventArgs(flightScenePlayer, this));
		}

		public void OnPlayerExited(FlightScenePlayer flightScenePlayer)
		{
			if (Player == null || Player != flightScenePlayer)
			{
				throw new Exception("Player " + flightScenePlayer.NetworkPlayer.Name + " is unable to exit the craft because it is not currently occupied by that player.");
			}
			if (NetworkAircraft.IsOwner && !NetworkAircraft.IsUnloaded)
			{
				NetworkAircraft.SetRemotePlayerEnteredState(entered: false);
			}
			UpdatePlayerEventSubscriptions(Player, subscribe: false);
			if (IsPrimaryLocalPlayer)
			{
				CameraManagerScript.Instance.SwitchingToNewViewMode -= OnSwitchingToNewViewMode;
			}
			Player = null;
			IsPrimaryLocalPlayer = false;
			this.PlayerExited?.Invoke(this, new FlightScenePlayerAircraftEventArgs(flightScenePlayer, this));
		}

		public virtual void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (!PauseManager.Paused && !IsNonFlyableAircraft && LoadContext == CraftLoadContext.Flight)
			{
				if (DebugInput.GetKeyDown(KeyCode.Keypad0) && DebugInput.GetKey(KeyCode.RightControl))
				{
					DebugRecalculateDragReport(null, includeArea: true, (1E-05f, 0.001f, 0.5f), (1E-05f, 0.001f, 0.5f));
				}
				else if (DebugInput.GetKeyDown(KeyCode.KeypadEnter) && DebugInput.GetKey(KeyCode.RightControl))
				{
					UnityEngine.Debug.Log("Recalculating Drag");
					_recalculateDrag = true;
				}
				FlightSceneScript instance = FlightSceneScript.Instance;
				if (_recalculateDrag && instance != null)
				{
					_recalculateDrag = false;
					foreach (BodyScript body in Bodies)
					{
						_ = body;
					}
				}
				if (_pendingExplosiveForces.Count > 0)
				{
					foreach (KeyValuePair<PartScript, float> pendingExplosiveForce in _pendingExplosiveForces)
					{
						ExplosionScript.CreateExplosion(this, pendingExplosiveForce.Key.transform.position, pendingExplosiveForce.Key.Body.RigidBody.velocity, pendingExplosiveForce.Value);
					}
					_pendingExplosiveForces.Clear();
				}
				if (InertiaTensorRecalculationEnabled)
				{
					RecalculateInertiaTensorsIfNeeded(forceUpdateAllBodies: false);
				}
				WindVelocity = FlightSceneScript.Instance.WindManager.WindVelocity;
				float speed = GetSpeed(SpeedType.TAS);
				if (!_mach2Achieved && IsPrimaryLocalPlayer && speed >= 680.5f)
				{
					_mach2HoldTime += Time.deltaTime;
					if (_mach2HoldTime >= 2f)
					{
						AchievementHelper.UnlockAchievement(AchievementKey.MachTwo);
						_mach2Achieved = true;
					}
				}
				else
				{
					_mach2HoldTime = 0f;
				}
				float num = 0f;
				if (Fuel > 0f)
				{
					foreach (ICraftEngine engine in _engines)
					{
						num += engine.IRSignature;
					}
					num *= 0.25f;
				}
				IRSignature = Utilities.StepTowards(IRSignature, 250f * Time.deltaTime, num);
			}
			Controls.Update(Time.deltaTime);
			TargetingSystem?.Update(Time.deltaTime);
			RoundRobinUpdateManager.Update();
			if (_damageMessage != null)
			{
				FlightSceneScript.Instance.FlightUI.ShowLogMessage(_damageMessage);
				_damageMessage = null;
			}
			if (LoadContext == CraftLoadContext.Flight && NetworkAircraft != null && NetworkAircraft.IsOwner)
			{
				TotalDragForceMagnitude = 0f;
				foreach (BodyScript body2 in Bodies)
				{
					TotalDragForceMagnitude += body2.DragPhysics.TotalDragForceMagnitude;
					if (body2.AeroManager != null)
					{
						TotalDragForceMagnitude += body2.AeroManager.TotalDragForceMagnitude;
					}
				}
				UpdateLocalPlayerAudio();
			}
			if (IsPrimaryLocalPlayer && Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				float num2 = 1f;
				if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
				{
					num2 = 5f;
				}
				else if (UnityEngine.Input.GetKey(KeyCode.LeftControl))
				{
					num2 = 0.2f;
				}
				if (Game.Inputs.TeleportUp.GetButtonDownIfEnabled())
				{
					Teleport(500f * num2 * Vector3.up);
				}
				else if (Game.Inputs.TeleportDown.GetButtonDownIfEnabled())
				{
					Teleport(-250f * num2 * Vector3.up);
				}
			}
		}

		public void PartEnteredWater(PartScript part)
		{
			if (this.OnPartEnteredWater != null)
			{
				this.OnPartEnteredWater(part);
			}
		}

		public void PartExitedWater(PartScript part)
		{
			if (this.OnPartExitedWater != null)
			{
				this.OnPartExitedWater(part);
			}
		}

		public void PartHasBeenDisconnected(PartScript part)
		{
		}

		public void PauseAircraft(bool disableColliders)
		{
			SetSpeed(0f);
			MainCockpit.Body.GetComponent<Rigidbody>().isKinematic = true;
			if (disableColliders)
			{
				Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = false;
				}
			}
		}

		public void QueueDragRecalculation()
		{
			_recalculateDrag = true;
		}

		public void QueueExplosion(PartScript source, float explosiveForce)
		{
			if (_pendingExplosiveForces.TryGetValue(source, out var value))
			{
				explosiveForce += value;
			}
			_pendingExplosiveForces[source] = explosiveForce;
		}

		public void RebuildAircraftStructure()
		{
			using (Profile.RebuildAircraftStructure.Auto())
			{
				_wings.Clear();
				SyncParts.Clear();
				List<IPowertrainNode> list = new List<IPowertrainNode>();
				PartScript mainSeat = null;
				foreach (PartData part in Aircraft.Assembly.Parts)
				{
					part.InitiallyConnectedToMainCockpit = false;
					part.PartScript.ConnectedToMainCockpit = false;
					SeatData modifier = part.GetModifier<SeatData>();
					if (modifier != null && modifier.PrimarySeat)
					{
						mainSeat = part.PartScript;
					}
					IPartSyncData syncData = part.PartScript.SyncData;
					if (syncData != null && syncData.Count > 0)
					{
						SyncParts.Add(part.PartScript);
					}
					IPowertrainNode modifierWithInterface = part.PartScript.GetModifierWithInterface<IPowertrainNode>();
					if (modifierWithInterface != null)
					{
						if (modifierWithInterface.IsEngine)
						{
							list.Add(modifierWithInterface);
							modifierWithInterface.IsConnectedToEngine = true;
						}
						else
						{
							modifierWithInterface.IsConnectedToEngine = false;
						}
					}
				}
				InitiallyDisconnectedParts.Clear();
				Parts.Clear();
				MainSeat = mainSeat;
				if (MainCockpit != null)
				{
					OrientedCenterOfMassRigidBodies.forward = Vector3.forward;
					OrientedCenterOfMassRigidBodies.right = Vector3.right;
					OrientedCenterOfMassRigidBodies.up = Vector3.up;
					PartGraph partGraph = new PartGraph(MainCockpit.Part, breakOnRigidBodyBoundary: false);
					foreach (PartData part2 in partGraph.Parts)
					{
						part2.PartScript.PartMaterialScript.IsDisconnected = false;
						part2.InitiallyConnectedToMainCockpit = true;
						part2.PartScript.ConnectedToMainCockpit = true;
						Parts.Add(part2);
						IWingScript modifierWithInterface2 = part2.PartScript.GetModifierWithInterface<IWingScript>();
						if (modifierWithInterface2 != null && modifierWithInterface2.PhysicsEnabled)
						{
							_initialWingSurfaceArea += modifierWithInterface2.GetArea();
							_wings.Add(modifierWithInterface2);
						}
						ICraftEngine modifierWithInterface3 = part2.PartScript.GetModifierWithInterface<ICraftEngine>();
						if (modifierWithInterface3 != null)
						{
							_engines.Add(modifierWithInterface3);
						}
					}
					_currentWingSurfaceArea = _initialWingSurfaceArea;
					RefreshFuelTankList();
					foreach (PartData part3 in partGraph.Parts)
					{
						part3.RecalculateLoadedMass(recalculateModifierMass: true);
					}
					CenterOfMass = new GroupCenterOfMass(partGraph.Parts);
					foreach (PartData part4 in Aircraft.Assembly.Parts)
					{
						if (!part4.InitiallyConnectedToMainCockpit)
						{
							InitiallyDisconnectedParts.Add(part4);
						}
					}
					{
						foreach (IPowertrainNode item in list)
						{
							PowertrainBuilder.BuildPowertrainTree(item).ExecuteOnTree(delegate(PowertrainNode x)
							{
								x.Part.IsConnectedToEngine = true;
							});
						}
						return;
					}
				}
				CenterOfMass = new GroupCenterOfMass();
			}
		}

		public void RegisterPartGroup(PartGroupScript partGroup)
		{
			_partGroups[partGroup.Id] = partGroup;
		}

		public void RemoveBody(BodyScript bodyScript)
		{
			this.BodyRemoved?.Invoke(bodyScript);
			Aircraft.Assembly.RigidBodyGroups.Remove(bodyScript.RigidBodyGroup);
			Bodies.Remove(bodyScript);
		}

		void IFuelSource.RemoveFuel(float amount)
		{
			UseFuel(amount);
		}

		public void RepositionOnGround()
		{
			PositionUtility.RepositionAircraftOnGround(this, excludePartsDisconnectedFromMainCockpit: true, 10f);
		}

		public void SetAIControlled(AiControlledAircraftScript aiScript)
		{
			AIScript = aiScript;
		}

		public void SetFuel(float fuel)
		{
			if (_fuelTanks.Count > 0)
			{
				float fuel2 = fuel / (float)_fuelTanks.Count;
				foreach (FuelTankScript fuelTank in _fuelTanks)
				{
					fuelTank.FuelTank.Fuel = fuel2;
				}
			}
			RefreshFuelTankList();
			InitialFuelCapacity = fuel;
			FuelCapacity = fuel;
		}

		public void SetPositionOfCenterOfMass(Vector3 com, bool local)
		{
			if (local)
			{
				OrientedCenterOfMassRigidBodies.transform.localPosition = com;
			}
			else
			{
				OrientedCenterOfMassRigidBodies.transform.position = com;
			}
		}

		public void SetVelocity(Vector3 velocity, bool ignoreDisconnectedBodies = false)
		{
			if (PauseManager.Paused)
			{
				_newVeloctySetWhilePaused = velocity;
				_newVelocitySetWhilePausedIgnoresDisconnectedParts = ignoreDisconnectedBodies;
				return;
			}
			Velocity = velocity;
			foreach (BodyScript body in Bodies)
			{
				if (body.RigidBody.isKinematic && !CraftUpdate.IsPaused)
				{
					continue;
				}
				if (ignoreDisconnectedBodies)
				{
					BodyScript component = body.GetComponent<BodyScript>();
					if (component != null && component.PartGroups.Count > 0 && component.PartGroups[0].Parts.Count > 0 && component.PartGroups[0].Parts[0].ConnectedToMainCockpit)
					{
						body.Velocity = velocity;
					}
				}
				else
				{
					body.Velocity = velocity;
				}
			}
			this.VelocitySet?.Invoke(velocity);
		}

		public void TogglePartDamageVisualizer()
		{
			foreach (PartData part in Parts)
			{
				PartMaterialScript partMaterialScript = part.PartScript.PartMaterialScript;
				partMaterialScript.ShowPartDamage = !partMaterialScript.ShowPartDamage;
			}
			DamageVisualizerEnabled = !DamageVisualizerEnabled;
		}

		public void UpdateInertiaTensorsWithDiffusion(List<BodyScript> bodyScripts)
		{
			using (Profile.UpdateInertiaTensorsWithDiffusion.Auto())
			{
				if (bodyScripts.Count == 0)
				{
					return;
				}
				if (bodyScripts.Count == 1)
				{
					BodyScript bodyScript = bodyScripts[0];
					if (!bodyScript.OriginalInertiaTensor.HasValue)
					{
						bodyScript.OriginalInertiaTensor = bodyScript.RigidBody.inertiaTensor;
					}
					else if (bodyScript.InertiaTensorRecalculationEnabled)
					{
						bodyScript.RigidBody.SetInertiaTensor(bodyScript.OriginalInertiaTensor.Value);
					}
					return;
				}
				float num = 0f;
				List<(BodyScript, BodyScript, float)> value;
				using (CollectionPool<List<(BodyScript, BodyScript, float)>, (BodyScript, BodyScript, float)>.Get(out value))
				{
					List<BodyScript> value2;
					using (CollectionPool<List<BodyScript>, BodyScript>.Get(out value2))
					{
						foreach (BodyScript bodyScript4 in bodyScripts)
						{
							Rigidbody physxRigidBody = bodyScript4.RigidBody.PhysxRigidBody;
							if (!(physxRigidBody != null))
							{
								continue;
							}
							BodyScript bodyScript2 = bodyScript4;
							Vector3? originalInertiaTensor = bodyScript2.OriginalInertiaTensor;
							Vector3 valueOrDefault = originalInertiaTensor.GetValueOrDefault();
							Vector3 vector3;
							if (!originalInertiaTensor.HasValue)
							{
								valueOrDefault = physxRigidBody.inertiaTensor;
								Vector3? vector = (bodyScript2.OriginalInertiaTensor = valueOrDefault);
								vector3 = valueOrDefault;
							}
							else
							{
								vector3 = valueOrDefault;
							}
							Vector3 vector4 = vector3;
							bool flag = false;
							foreach (BodyJoint joint in bodyScript4.Joints)
							{
								if (!joint.PreventInertiaTensorDiffusion)
								{
									BodyScript bodyScript3 = joint.OtherBody(bodyScript4);
									value.Add((bodyScript4, bodyScript3, 0.005f / (float)bodyScript3.InertiaTensorDiffusionJointCount));
									flag = true;
								}
							}
							if (flag)
							{
								float num2 = (bodyScript4.InertiaTensorInitial = (bodyScript4.InertiaTensorMagnitude = vector4.magnitude));
								num += num2;
								value2.Add(bodyScript4);
							}
						}
						for (int i = 0; i < 25; i++)
						{
							foreach (var item in value)
							{
								item.Item1.InertiaTensorMagnitude += item.Item2.InertiaTensorInitial * item.Item3;
							}
							foreach (BodyScript item2 in value2)
							{
								item2.InertiaTensorMagnitude -= item2.InertiaTensorInitial * 0.005f;
								item2.InertiaTensorInitial = item2.InertiaTensorMagnitude;
							}
						}
						float num4 = 0f;
						foreach (BodyScript item3 in value2)
						{
							num4 += item3.InertiaTensorMagnitude;
						}
						float num5 = num / num4;
						foreach (BodyScript item4 in value2)
						{
							if (item4.InertiaTensorRecalculationEnabled)
							{
								item4.RigidBody.SetInertiaTensor(item4.OriginalInertiaTensor.Value.normalized * (item4.InertiaTensorMagnitude * num5));
							}
						}
					}
				}
			}
		}

		public void UpdateMainCockpit(PartScript mainCockpit = null)
		{
			if (mainCockpit == null)
			{
				foreach (PartData part in Aircraft.Assembly.Parts)
				{
					if (part.TryGetModifier<CockpitData>(out var result) && result.PrimaryCockpit)
					{
						mainCockpit = result.Part.PartScript;
						break;
					}
				}
			}
			if (mainCockpit != null && mainCockpit != MainCockpit)
			{
				MainCockpit = mainCockpit;
				if (OrientedCenterOfMassRigidBodies == null)
				{
					OrientedCenterOfMassRigidBodies = new GameObject("CenterOfMass").transform;
					OrientedCenterOfMassRigidBodies.parent = MainCockpit.transform;
					OrientedCenterOfMassRigidBodies.localPosition = Vector3.zero;
					OrientedCenterOfMassRigidBodies.localScale = Vector3.one;
				}
				else
				{
					OrientedCenterOfMassRigidBodies.SetParent(MainCockpit.transform, worldPositionStays: true);
				}
				OrientedCenterOfMassRigidBodies.forward = Vector3.forward;
				OrientedCenterOfMassRigidBodies.right = Vector3.right;
				OrientedCenterOfMassRigidBodies.up = Vector3.up;
				if (LoadContext == CraftLoadContext.Flight)
				{
					Powertrain.SetParentTransform(OrientedCenterOfMassRigidBodies);
				}
			}
		}

		public void UseFuel(float amount)
		{
			_fuelUsedInFrame += amount;
		}

		public void UseFuel(float amount, FuelTankData fuelTank)
		{
			if (fuelTank.Fuel > amount)
			{
				fuelTank.Fuel -= amount;
				Fuel -= amount;
			}
			else if (fuelTank.Fuel > 0f)
			{
				Fuel -= fuelTank.Fuel;
				fuelTank.Fuel = 0f;
				_numActiveTanks--;
			}
		}

		protected virtual void Awake()
		{
			Children = new GameObject("Children").transform;
			Children.localPosition = default(Vector3);
			Children.localScale = new Vector3(1f, 1f, 1f);
			Children.parent = base.transform;
			WorldRigidBodies = new GameObject("WorldRigidBodies").transform;
			WorldRigidBodies.localPosition = default(Vector3);
			WorldRigidBodies.localScale = new Vector3(1f, 1f, 1f);
			WorldRigidBodies.parent = base.transform;
			LayerUtility.SetLayerRecursive(base.gameObject, 21);
			Controls = new AircraftControls(this);
			Bodies = new List<BodyScript>();
			Parts = new List<PartData>();
			RefuelProbes = new List<RefuelProbeScript>();
			InitiallyDisconnectedParts = new List<PartData>();
			WheelParts = new List<IWheelPart>();
			PartCollidersSkippingCollisionHandler = new HashSet<int>();
			_pendingExplosiveForces = new Dictionary<PartScript, float>();
			DrawAerodynamicCenter = false;
			CriticalDamageThreshold = 0.7f;
			InletAir = new InletAir();
			_mach2Achieved = AchievementManager.Instance.HasUnlocked(AchievementKey.MachTwo) == true;
			CraftUpdate = base.gameObject.AddComponent<CraftUpdateScript>();
			CraftUpdate.RegisterUpdate(CraftUpdateType.Start, this, OnStart, CraftUpdateFlags.Default, -1000);
		}

		protected virtual void OnApplicationFocus(bool focusState)
		{
			if (focusState)
			{
				Theme?.UpdateMaterialProperties();
			}
		}

		protected virtual void OnDestroy()
		{
			this.Unloaded?.Invoke(this, new AircraftScriptEventArgs(this));
			this.Unloaded = null;
			UpdatePlayerEventSubscriptions(Player, subscribe: false);
			Theme.OnDestroy();
			TargetingSystem?.OnDestroy();
			if (Target != null)
			{
				FlightSceneScript.Instance.TargetRegistry.UnregisterTarget(Target);
			}
			if (CameraManagerScript.Instance != null && IsPrimaryLocalPlayer)
			{
				CameraManagerScript.Instance.SwitchingToNewViewMode -= OnSwitchingToNewViewMode;
			}
			if (_floatingOriginSubbed && (object)FloatingOriginScript.Instance != null)
			{
				FloatingOriginScript.Instance.Repositioned -= FloatingOriginChanged;
				_floatingOriginSubbed = false;
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null && !RemoteAircraft && Aircraft.AerodynamicsModelType != CraftAerodynamicsModelType.Legacy)
			{
				instance.DragCalculator.OnCraftDestroyed(this);
			}
		}

		private void CheckForCriticalDamage()
		{
			if (!CriticallyDamaged)
			{
				float num = (float)Parts.Count / (float)_initialNonWeaponPartCount;
				float num2 = _currentWingSurfaceArea / _initialWingSurfaceArea;
				if (num < CriticalDamageThreshold || num2 < CriticalDamageThreshold)
				{
					MarkAsCriticallyDamaged();
				}
			}
		}

		private void CreateReflectionProbe()
		{
			if (LoadContext != CraftLoadContext.Flight || NetworkAircraft?.Player?.IsPrimaryLocal == true)
			{
				_reflectionProbe = CraftReflectionProbe.Create(this)?.ReflectionProbe;
			}
		}

		private async void DebugRecalculateDragReport(PartDrag.DragDirection? direction, bool includeArea, (float Min, float Tolerance, float ToleranceExcessive)? dragConfig = null, (float Min, float Tolerance, float ToleranceExcessive)? areaConfig = null)
		{
			UnityEngine.Debug.Log("Building drag recalculation report...");
			Dictionary<int, (float[] Drag, float[] Area)> originalValues = new Dictionary<int, (float[], float[])>();
			foreach (PartData item in Parts.OrderBy((PartData x) => x.Id))
			{
				originalValues.Add(item.Id, (item.PartDrag.GetDrag().ToArray(), item.PartDrag.GetArea().ToArray()));
			}
			FlightSceneScript flightSceneScript = FlightSceneScript.Instance;
			foreach (BodyScript body in Bodies)
			{
				flightSceneScript.DragCalculator.Queue.AddBody(body);
			}
			int timeoutInSeconds = 60;
			if (!(await UniTaskEx.WaitUntilWithTimeout(() => !flightSceneScript.DragCalculator.Queue.Processing, timeoutInSeconds * 1000)))
			{
				UnityEngine.Debug.LogError($"Recalculating drag took longer than '{timeoutInSeconds}' seconds. Report timed out.");
				return;
			}
			float num = dragConfig?.Min ?? 0.001f;
			float num2 = dragConfig?.Tolerance ?? 0.1f;
			float num3 = dragConfig?.ToleranceExcessive ?? 0.5f;
			float num4 = areaConfig?.Min ?? 0.001f;
			float num5 = areaConfig?.Tolerance ?? 0.1f;
			float num6 = areaConfig?.ToleranceExcessive ?? 0.5f;
			float[] array = new float[6];
			float[] array2 = new float[6];
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (PartData item2 in Parts.OrderBy((PartData x) => x.Id))
			{
				(float[], float[]) tuple = originalValues[item2.Id];
				float[] drag = item2.PartDrag.GetDrag();
				float[] area = item2.PartDrag.GetArea();
				stringBuilder2.Clear();
				for (int num7 = 0; num7 < 6; num7++)
				{
					if (direction.HasValue && num7 != (int)direction.Value)
					{
						continue;
					}
					float num8 = ((Math.Abs(tuple.Item1[num7]) >= num) ? tuple.Item1[num7] : 0f);
					float num9 = ((Math.Abs(drag[num7]) >= num) ? drag[num7] : 0f);
					if (num8 != num9)
					{
						float num10 = num9 - num8;
						float num11 = ((num8 == 0f || num9 == 0f) ? 1f : Math.Abs(num10 / num8));
						if (num11 > num2)
						{
							stringBuilder2.AppendLine($"  Drag {(PartDrag.DragDirection)num7,9}:  {num8:00.0000}  -->  {num9:00.0000}" + string.Format("   {0,8:P1}{1}    Diff: {2,6:0.000}", num11, (num11 > num3) ? "   *" : "    ", num10));
						}
						array[num7] += num10;
					}
				}
				if (includeArea)
				{
					for (int num12 = 0; num12 < 6; num12++)
					{
						if (direction.HasValue && num12 != (int)direction.Value)
						{
							continue;
						}
						float num13 = ((Math.Abs(tuple.Item2[num12]) >= num4) ? tuple.Item2[num12] : 0f);
						float num14 = ((Math.Abs(area[num12]) >= num4) ? area[num12] : 0f);
						if (num13 != num14)
						{
							float num15 = num14 - num13;
							float num16 = ((num13 == 0f || num14 == 0f) ? 1f : Math.Abs(num15 / num13));
							if (num16 > num5)
							{
								stringBuilder2.AppendLine($"  Area {(PartDrag.DragDirection)num12,9}:  {num13:00.0000}  -->  {num14:00.0000}" + string.Format("   {0,8:P1}{1}    Diff: {2,6:0.000}", num16, (num16 > num6) ? "   *" : "    ", num15));
							}
							array2[num12] += num15;
						}
					}
				}
				if (stringBuilder2.Length > 0)
				{
					stringBuilder.AppendLine($"Part {item2.Id:0000}:   ({item2.Name})");
					stringBuilder.AppendLine(stringBuilder2.ToString());
				}
			}
			stringBuilder.AppendLine("Total Diff Drag");
			for (int num17 = 0; num17 < 6; num17++)
			{
				if (!direction.HasValue || num17 == (int)direction.Value)
				{
					stringBuilder.AppendLine($"  {(PartDrag.DragDirection)num17,9}: {array[num17]:0.000}");
				}
			}
			if (includeArea)
			{
				stringBuilder.AppendLine("Total Diff Area");
				for (int num18 = 0; num18 < 6; num18++)
				{
					if (!direction.HasValue || num18 == (int)direction.Value)
					{
						stringBuilder.AppendLine($"  {(PartDrag.DragDirection)num18,9}: {array2[num18]:0.000}");
					}
				}
			}
			FileInfo fileInfo = new FileInfo("C:\\Temp\\RecalculateDragReport" + ((!direction.HasValue) ? string.Empty : $"_{direction}") + ".txt");
			if (!fileInfo.Directory.Exists)
			{
				fileInfo.Directory.Create();
			}
			string text = stringBuilder.ToString();
			UnityEngine.Debug.Log(text);
			File.WriteAllText(fileInfo.FullName, text);
			Process.Start(fileInfo.FullName);
		}

		[ContextMenu("Select Part By ID")]
		private void EditorDebugSelectPartById()
		{
		}

		private void FindRpmSources()
		{
			List<IRpmSource> list = new List<IRpmSource>();
			foreach (PartData part in Parts)
			{
				IRpmSource modifierWithInterface = part.PartScript.GetModifierWithInterface<IRpmSource>();
				if (modifierWithInterface != null)
				{
					list.Add(modifierWithInterface);
				}
			}
			_rpmSources = list.OrderByDescending((IRpmSource x) => x.ReportedRpmPriority).Take(4).ToArray();
		}

		private void FloatingOriginChanged(object sender, FloatingOriginUpdatedEventArgs e)
		{
			if (!GenerationComplete)
			{
				_floatingOriginMissed += e.Delta;
			}
			else
			{
				MoveBodies(-e.Delta);
			}
		}

		private Vector3 GetCenterOfMass()
		{
			if (_centerOfMassRegidBodiesForDebug == null)
			{
				_centerOfMassRegidBodiesForDebug = new List<Rigidbody>();
			}
			if (_centerOfMassRegidBodiesForDebug.Count < 1)
			{
				_centerOfMassRegidBodiesForDebug.AddRange(GetComponentsInChildren<Rigidbody>());
			}
			Vector3 zero = Vector3.zero;
			float num = 0f;
			foreach (Rigidbody item in _centerOfMassRegidBodiesForDebug)
			{
				Vector3 worldCenterOfMass = item.worldCenterOfMass;
				num += item.mass;
				zero += worldCenterOfMass * item.mass;
			}
			if (num > 0f)
			{
				zero /= num;
			}
			return zero;
		}

		private float GetRpm(int rpmSourceIndex)
		{
			if (_rpmSources != null && rpmSourceIndex >= 0 && rpmSourceIndex < _rpmSources.Length)
			{
				IRpmSource rpmSource = _rpmSources[rpmSourceIndex];
				if (rpmSource != null && rpmSource.ReportingPartScript?.ConnectedToMainCockpit == true)
				{
					return rpmSource.ReportedRpm;
				}
			}
			return 0f;
		}

		private int? GetTopAttackerByDamage()
		{
			if (_damageFromAttackers.Count > 0)
			{
				return _damageFromAttackers.OrderByDescending((KeyValuePair<int, float> x) => x.Value).First().Key;
			}
			return null;
		}

		private void Initialize()
		{
			if (_initialized)
			{
				return;
			}
			_initialized = true;
			_startTime = Time.time;
			if (IsNonFlyableAircraft)
			{
				return;
			}
			UpdateAirDensity(0f);
			if (Bodies.Count > 0 && Bodies[0].GetComponent<Rigidbody>() != null)
			{
				if (Aircraft.DiffuseInertiaTensors && !RemoteAircraft)
				{
					RecalculateInertiaTensorsIfNeeded(forceUpdateAllBodies: true);
				}
				else
				{
					InertiaTensorRecalculationEnabled = false;
				}
				RefreshFuelTankList();
				RebuildPartList();
				RadarSignature = CalculateRadarSignature();
				InitialFuelCapacity = FuelCapacity;
			}
			if (LoadContext == CraftLoadContext.Flight)
			{
				_windAudioParent = new GameObject("WindAudio").transform;
				_windAudio = _windAudioParent.gameObject.AddComponent<AudioSource>();
				_rattleAudio = _windAudioParent.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(_windAudio, AudioStore.WindAudio, AudioStore.WindAudio.Resource);
				AudioStore.SetupAudioSource(_rattleAudio, AudioStore.RattleAudio, AudioStore.RattleAudio.Resource, loop: true, autoPlay: false, 0f);
				MoveWindAudio(MainCockpit.transform);
				if (IsPrimaryLocalPlayer)
				{
					_groundRollAudio = AudioManager.CreateAudioSource(AudioStore.GroundRoll, new GameObject("GroundRollAudio"));
					_groundRollAudio.transform.parent = base.transform;
					_groundRollAudio.loop = true;
					_groundRollAudio.playOnAwake = false;
					_groundRollAudio.dopplerLevel = 0f;
					_waterAmbienceAudio = AudioManager.CreateAudioSource(AudioStore.WaterAmbience, new GameObject("WaterAmbienceAudio"));
					_waterAmbienceAudio.transform.parent = base.transform;
					_waterAmbienceAudio.loop = true;
					_waterAmbienceAudio.playOnAwake = false;
					_waterAmbienceAudio.dopplerLevel = 0f;
				}
				_initialNonWeaponPartCount = Parts.Count;
				foreach (PartData part in Parts)
				{
					if (part.PartScript.GetModifier<BombScript>() != null || part.PartScript.GetModifier<MissileScript>() != null)
					{
						_initialNonWeaponPartCount--;
					}
					Assets.Scripts.Craft.Parts.Modifiers.JetEngineScript modifier = part.PartScript.GetModifier<Assets.Scripts.Craft.Parts.Modifiers.JetEngineScript>();
					if (modifier != null && modifier.AvailableAirIntakeRatio < 1f && modifier.Engine.RequiredAirIntake > 0f && IsPrimaryLocalPlayer && !Game.Instance.Device.IsVRExclusiveBuild)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("FYI: Your engines aren't getting enough air.\nTry putting some inlets on your plane.");
					}
					JetEngineAfterburningScript modifier2 = part.PartScript.GetModifier<JetEngineAfterburningScript>();
					if (modifier2 != null && modifier2.AvailableAirIntakeRatio < 1f && modifier2.Engine.RequiredAirIntake > 0f && IsPrimaryLocalPlayer && !Game.Instance.Device.IsVRExclusiveBuild)
					{
						FlightSceneScript.Instance.FlightUI.ShowMessage("FYI: Your engines aren't getting enough air.\nTry putting some inlets on your plane.");
					}
				}
				TargetingSystem.InventoryWeapons();
				FindRpmSources();
				RequiresTrimSlider = RequiresSliderInput("Trim", trim: true);
				RequiresVtolSlider = RequiresSliderInput("VTOL");
				RequiresFlapsSlider = RequiresSliderInput("Flaps");
			}
			float num = 0f;
			Vector3 zero = Vector3.zero;
			foreach (BodyScript body in Bodies)
			{
				IRigidBody rigidBody = body.RigidBody;
				num += rigidBody.mass;
				zero += rigidBody.position * rigidBody.mass;
			}
			if (num > 0f)
			{
				zero /= num;
			}
			if (MainCockpit != null)
			{
				SetPositionOfCenterOfMass(zero, local: false);
			}
			VtolManagerScript = base.gameObject.AddComponent<VtolManagerScript>();
			VtolManagerScript.Initialize();
			WheelManager = base.gameObject.AddComponent<WheelManagerScript>();
			WheelManager.Initialize(this);
			if (IsPrimaryLocalPlayer)
			{
				AchievementHelper.CheckComplicatedDesign(this);
			}
			this.Initialized?.Invoke(this);
		}

		[ContextMenu("Log Current Target")]
		private void LogCurrentTarget()
		{
			string text = Player?.Name;
			string text2 = base.gameObject.name;
			string text3 = TargetingSystem.CurrentTarget?.Player?.Name;
			UnityEngine.Debug.Log("Player '" + (text ?? string.Empty) + "' in craft '" + text2 + "' is targeting " + ((text3 != null) ? ("player '" + text3 + "'") : "Nobody"));
		}

		private void MoveBodies(Vector3 delta)
		{
			foreach (Transform child in Children)
			{
				child.position += delta;
			}
			WorldRigidBodies.transform.position += delta;
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			Initialize();
		}

		private void OnSwitchingToNewViewMode(Assets.Scripts.Flight.Cameras.CameraController oldController, Assets.Scripts.Flight.Cameras.CameraController newController)
		{
			SelectWindAudioParent(newController);
		}

		private void OnTeamChanged(object sender, TeamChangedEventArgs e)
		{
			ushort teamId = TeamId;
			if (teamId != e.NewTeamId)
			{
				if (teamId != e.PreviousTeamId)
				{
					e = new TeamChangedEventArgs(teamId, e.NewTeamId);
				}
				TeamId = e.NewTeamId;
				Target.TeamId = e.NewTeamId;
				this.TeamChanged?.Invoke(this, e);
			}
		}

		private void RebuildPartList()
		{
			for (int i = 0; i < Parts.Count; i++)
			{
				PartScript partScript = Parts[i].PartScript;
				partScript.Body.ConnectedToMainCockpit = false;
				partScript.ConnectedToMainCockpit = false;
			}
			Parts.Clear();
			RefuelProbes.Clear();
			_engines.Clear();
			WheelParts.Clear();
			TargetingPod = null;
			_currentWingSurfaceArea = 0f;
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				PartGraph.GetConnectedParts(MainCockpit.Part, breakOnRigidBodyBoundary: false, value);
				for (int j = 0; j < value.Count; j++)
				{
					PartData partData = value[j];
					PartScript partScript2 = partData.PartScript;
					partScript2.ConnectedToMainCockpit = true;
					partScript2.Body.ConnectedToMainCockpit = true;
					Parts.Add(partData);
					foreach (PartModifierScript modifier in partScript2.Modifiers)
					{
						if (!(modifier is IWingScript wingScript))
						{
							if (!(modifier is ICraftEngine item))
							{
								if (!(modifier is RefuelProbeScript item2))
								{
									if (!(modifier is IWheelPart item3))
									{
										if (modifier is TargetingPodScript targetingPod)
										{
											TargetingPod = targetingPod;
										}
									}
									else
									{
										WheelParts.Add(item3);
									}
								}
								else
								{
									RefuelProbes.Add(item2);
								}
							}
							else
							{
								_engines.Add(item);
							}
						}
						else
						{
							_currentWingSurfaceArea += wingScript.GetArea();
						}
					}
				}
				RefreshFuelTankList();
			}
		}

		private void RecalculateInertiaTensorsIfNeeded(bool forceUpdateAllBodies)
		{
			using (Profile.RecalculateInertiaTensorsIfNeeded.Auto())
			{
				List<BodyScript> list = null;
				foreach (BodyScript body in Bodies)
				{
					if (forceUpdateAllBodies || body.RecalculateInertiaTensor)
					{
						body.RecalculateInertiaTensor = false;
						if (list == null)
						{
							list = CollectionPool<List<BodyScript>, BodyScript>.Get();
						}
						list.Add(body);
					}
				}
				if ((list?.Count ?? 0) <= 0)
				{
					return;
				}
				HashSet<BodyScript> value;
				using (CollectionPool<HashSet<BodyScript>, BodyScript>.Get(out value))
				{
					List<BodyScript> value2;
					using (CollectionPool<List<BodyScript>, BodyScript>.Get(out value2))
					{
						Queue<BodyScript> value3;
						using (QueuePool<BodyScript>.Get(out value3))
						{
							foreach (BodyScript item2 in list)
							{
								if (!value.Add(item2))
								{
									continue;
								}
								value2.Clear();
								value3.Clear();
								value3.Enqueue(item2);
								while (value3.Count > 0)
								{
									BodyScript bodyScript = value3.Dequeue();
									value2.Add(bodyScript);
									foreach (BodyJoint joint in bodyScript.Joints)
									{
										BodyScript item = joint.OtherBody(bodyScript);
										if (value.Add(item))
										{
											value3.Enqueue(item);
										}
									}
								}
								UpdateInertiaTensorsWithDiffusion(value2);
							}
							CollectionPool<List<BodyScript>, BodyScript>.Release(list);
						}
					}
				}
			}
		}

		private void RefreshFuelTankList()
		{
			_numActiveTanks = 0;
			FuelCapacity = 0f;
			Fuel = 0f;
			_fuelTanks.Clear();
			foreach (PartData part in Parts)
			{
				FuelTankScript modifier = part.PartScript.GetModifier<FuelTankScript>();
				if (modifier != null && modifier.FuelTank.Capacity > 0f)
				{
					FuelCapacity += modifier.FuelTank.Capacity;
					if (modifier.FuelTank.Fuel > 0f)
					{
						_fuelTanks.Add(modifier);
						Fuel += modifier.FuelTank.Fuel;
						_numActiveTanks++;
					}
				}
			}
		}

		private bool RequiresSliderInput(string inputName, bool trim = false)
		{
			bool flag = false;
			foreach (VariableSetter variableSetter in Aircraft.VariableSetters)
			{
				if (variableSetter.Expression.Contains(inputName) || (variableSetter.Activator ?? string.Empty).Contains(inputName))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				foreach (PartData part in Parts)
				{
					foreach (InputControllerScript modifier in part.PartScript.GetModifiers<InputControllerScript>())
					{
						if (!modifier.Disabled && modifier.InputController.Input.Contains(inputName))
						{
							flag = true;
							break;
						}
					}
					foreach (WingScript modifier2 in part.PartScript.GetModifiers<WingScript>())
					{
						foreach (ControlSurfaceScript controlSurface in modifier2.ControlSurfaces)
						{
							if (controlSurface.ControlSurface.InputId.Contains(inputName) || (trim && controlSurface.ControlSurface.Trim != ControlSurfaceData.TrimType.Off))
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			return flag;
		}

		private void SelectWindAudioParent(Assets.Scripts.Flight.Cameras.CameraController newController)
		{
			if (newController?.CameraVantage != null && newController.CameraVantage.TransformToTrack.gameObject.activeInHierarchy)
			{
				MoveWindAudio(newController.CameraVantage.TransformToTrack);
			}
			else
			{
				MoveWindAudio(MainCockpit.transform);
			}
		}

		private void SetSpeed(float value)
		{
			SetVelocity(OrientedCenterOfMassRigidBodies.forward * value);
		}

		private void Teleport(Vector3 delta)
		{
			OnBeginReposition(GlobalPosition + delta);
			MoveBodies(delta);
			OnEndReposition(GlobalPosition, Rotation);
		}

		private void UpdateAirDensity(float altitude)
		{
			AtmosphereSample = Atmosphere.SampleAltitude(altitude);
		}

		private void UpdateGroundRollAudio()
		{
			if (_groundRollAudio == null)
			{
				return;
			}
			if (PauseManager.Paused)
			{
				if (_groundRollAudio.isPlaying)
				{
					_groundRollAudio.Pause();
				}
				return;
			}
			Vector3 position = CameraManagerScript.Instance.CameraTransform.position;
			Vector3 zero = Vector3.zero;
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			float magnitude = Aircraft.Size.magnitude;
			foreach (IWheelPart wheelPart in WheelParts)
			{
				if (wheelPart.IsGrounded)
				{
					float num4 = Mathf.InverseLerp(0.05f, 0.03f, wheelPart.WheelRadius / magnitude) / (wheelPart.WheelPosition - position).sqrMagnitude;
					num2 += num4;
					zero += wheelPart.WheelPosition * num4;
					num += Mathf.Abs(wheelPart.WheelSpeed) * num4;
					num3++;
				}
			}
			float num5;
			if (num3 == 0 || (num5 = Mathf.InverseLerp(0.0025f, 0.01f, num2 / (float)num3)) <= 0f)
			{
				if (_groundRollAudio.isPlaying)
				{
					if (_groundRollAudio.volume > 0f)
					{
						_groundRollAudio.volume = Mathf.MoveTowards(_groundRollAudio.volume, 0f, Time.unscaledDeltaTime * 4f);
					}
					else
					{
						_groundRollAudio.Stop();
					}
				}
				return;
			}
			float num6 = 1f / num2;
			zero *= num6;
			num *= num6;
			float num7 = Mathf.InverseLerp(18f, 50f, num);
			if (num7 <= 0f)
			{
				_groundRollAudio.Stop();
				return;
			}
			num7 *= num7;
			_groundRollAudio.volume = num7 * num5 * AudioStore.GroundRoll.DefaultVolume;
			_groundRollAudio.pitch = Mathf.Lerp(0.5f, 1.5f, Mathf.InverseLerp(18f, 80f, num));
			_groundRollAudio.transform.position = zero;
			if (!_groundRollAudio.isPlaying)
			{
				_groundRollAudio.Play();
			}
		}

		private void UpdateLocalPlayerAudio()
		{
			if (!PauseManager.Paused && !IsNonFlyableAircraft)
			{
				if (_windAudio != null)
				{
					float speed = GetSpeed(SpeedType.IAS);
					float totalDragForceMagnitude = TotalDragForceMagnitude;
					if (WindAudio.isPlaying && speed < 1f)
					{
						_windAudio.Stop();
						_rattleAudio.Stop();
					}
					else
					{
						if (!_windAudio.isPlaying)
						{
							_windAudio.Play();
							_windAudio.timeSamples = (int)(UnityEngine.Random.value * (float)_windAudio.clip.samples);
						}
						_ = AudioMixing.IsInCockpit;
						_ = 0f;
						if (_rattleAudio.isPlaying)
						{
							_rattleAudio.Stop();
						}
						_windAudio.volume = ((Altitude < 0f) ? 0f : 0.7f) * Mathf.Clamp01(totalDragForceMagnitude / Mathf.Pow(CenterOfMass.LoadedMass, 1.5f));
						_windAudio.pitch = 0.3f + Mathf.Min(1.7f, speed / 250f) + 0.1f * Mathf.PerlinNoise1D(TimeSinceStart);
						_windAudio.spatialBlend = ((!(AudioMixing.IsInCockpit > 0f)) ? 1 : 0);
						bool flag = WheelParts.Any((IWheelPart wheel) => wheel.IsGrounded);
						_rattleAudio.volume = Mathf.Clamp01(speed / (flag ? 100f : 500f));
					}
				}
			}
			else if (PauseManager.Paused)
			{
				if (_windAudio != null && _windAudio.isPlaying)
				{
					_windAudio.Stop();
				}
				if (_rattleAudio != null && _rattleAudio.isPlaying)
				{
					_rattleAudio.Stop();
				}
			}
			UpdateGroundRollAudio();
			UpdateWaterAmbience();
		}

		private void UpdatePlayerEventSubscriptions(FlightScenePlayer player, bool subscribe)
		{
			if (player != null)
			{
				if (subscribe)
				{
					player.TeamChanged += OnTeamChanged;
				}
				else
				{
					player.TeamChanged -= OnTeamChanged;
				}
			}
		}

		private void UpdateWaterAmbience()
		{
			if (_waterAmbienceAudio == null)
			{
				return;
			}
			if (PauseManager.Paused || !GameWorld.Instance.FloatingOriginSeaLevel.HasValue)
			{
				if (_waterAmbienceAudio.isPlaying)
				{
					_waterAmbienceAudio.Pause();
				}
				return;
			}
			float num = 1f - Mathf.Clamp01((GS - 10f) / 20f);
			if (num > 0f)
			{
				float value = GameWorld.Instance.FloatingOriginSeaLevel.Value;
				float num2 = _altitudeAglPos.y - value - AltitudeAgl;
				float num3 = Mathf.Clamp01(1f - num2);
				if (num3 > 0f)
				{
					_waterAmbienceAudio.volume = num * num3;
					Vector3 position = CameraManagerScript.Instance.CameraTransform.position;
					position.y = value;
					_waterAmbienceAudio.transform.position = position;
					if (!_waterAmbienceAudio.isPlaying)
					{
						_waterAmbienceAudio.Play();
					}
					return;
				}
			}
			if (_waterAmbienceAudio.isPlaying)
			{
				if (_waterAmbienceAudio.volume > 0f)
				{
					_waterAmbienceAudio.volume = Mathf.MoveTowards(_waterAmbienceAudio.volume, 0f, Time.deltaTime * 2f);
				}
				else
				{
					_waterAmbienceAudio.Stop();
				}
			}
		}

		[Exposed(Name = "ammo")]
		private float GetAmmoForWeapon(string weapon)
		{
			IReadOnlyList<WeaponSystem> readOnlyList = TargetingSystem?.WeaponSystemsReadOnly;
			if (readOnlyList != null)
			{
				for (int i = 0; i < readOnlyList.Count; i++)
				{
					if (readOnlyList[i].WeaponPartName == weapon)
					{
						return readOnlyList[i].Ammo;
					}
				}
			}
			return 0f;
		}
	}
}
