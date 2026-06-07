using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DV;
using DV.CabControls;
using DV.Customization;
using DV.Customization.Paint;
using DV.Damage;
using DV.ECS.Components;
using DV.ECS.Train;
using DV.Logic.Job;
using DV.MultipleUnit;
using DV.Optimizers;
using DV.OriginShift;
using DV.PointSet;
using DV.ServicePenalty;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.Telemetry;
using DV.Teleporters;
using DV.TerrainSystem;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using DV.VFX;
using DV.Wheels;
using DV.WorldTools;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Rendering;

[SelectionBase]
public class TrainCar : MonoBehaviour, ITelemetryRecorder
{
	public delegate void Derailed(TrainCar derailedCar);

	public struct Snapshot
	{
		public Vector3 position;

		public Quaternion orientation;

		public Vector3 velocity;

		public Vector3 angularVelocity;

		public bool derailed;

		public bool kinematic;
	}

	public class Telemetry : TelemetryData<TrainCar, Snapshot>
	{
		protected override string ObjectName => base.TargetObject.name + "(TrainCar)";

		public Telemetry(TrainCar tc)
			: base(tc, true, 3600)
		{
		}

		protected override void RecordTo(TrainCar obj, ref Snapshot data)
		{
			data.position = obj.rb.position;
			data.orientation = obj.rb.rotation;
			data.velocity = obj.rb.velocity;
			data.angularVelocity = obj.rb.angularVelocity;
			data.derailed = obj.derailed;
			data.kinematic = obj.rb.isKinematic;
		}
	}

	private const float AUDIO_LOD_CHECK_PERIOD = 1f;

	private const float WHEEL_AUDIO_ON_SPEED_THRESHOLD = 0.1f;

	public const string INTERIOR_CONTAINER = "[interior]";

	public const string PERSISTENT_INTERIOR_CONTAINER = "[persistent interior]";

	public const string INTERIOR_LOD = "[interior LOD]";

	public const string HAZMAT_TRAINCAR_PREFAB_NAME = "HazmatTrainCarStuff";

	public const float TRAINCAR_DEFAULT_CAPACITY = 1f;

	private const int CABIN_ORDERING_DEFAULT_ORDER = 0;

	private const int CABIN_ORDERING_WHENINSIDE_ORDER = 10;

	private static CachedArchetype interiorContainerArchetype;

	private static CachedArchetype normalArchetype;

	private static CachedArchetype wheelslipArchetype;

	public TrainCarType carType;

	public TrainCarLivery carLivery;

	public Transform centerOfMassOverride;

	[NonSerialized]
	public bool blockInteriorLoading;

	public bool preventAutoCouple;

	public bool preventCouple;

	[NonSerialized]
	public bool preventRerail;

	[NonSerialized]
	public bool preventFastTravelWithCar;

	[NonSerialized]
	public bool preventFastTravelDestination;

	[NonSerialized]
	public bool preventDelete;

	[NonSerialized]
	public bool preventService;

	[NonSerialized]
	public bool preventDebtDisplay;

	[NonSerialized]
	public readonly float cargoCapacity = 1f;

	[NonSerialized]
	public bool playerSpawnedCar;

	[NonSerialized]
	public bool uniqueCar;

	[NonSerialized]
	public bool derailed;

	[NonSerialized]
	public Transform interior;

	[NonSerialized]
	public CabTeleportDestination cabTeleportDestination;

	[NonSerialized]
	public Coupler[] couplers;

	private Transform _frontCouplerAnchor;

	private Transform _rearCouplerAnchor;

	private float _interCouplerDistance;

	private Bogie[] _bogies;

	private int numberOfAxles = -1;

	private Bounds _bounds;

	private bool? _isLoco;

	private bool? _isCaboose;

	[NonSerialized]
	public Rigidbody rb;

	[NonSerialized]
	public TrainStress stress;

	[NonSerialized]
	public Transform interiorLOD;

	[NonSerialized]
	public TrainPhysicsLod physicsLod;

	[NonSerialized]
	public TrainMassController massController;

	[NonSerialized]
	public AdhesionController adhesionController;

	[NonSerialized]
	public GroundFriction groundFriction;

	[NonSerialized]
	public DerailedParticles derailedParticles;

	[NonSerialized]
	public MultipleUnitModule muModule;

	[NonSerialized]
	public CarVisitChecker visitChecker;

	private CargoContent cargoContent;

	private TrainCarPlatesController trainPlatesCtrl;

	private TrainCarPaint paintCabInterior;

	private TrainCarPaint paintCabExterior;

	private TrainCarPaint paintEIInterior;

	private TrainCarPaint paintEIExterior;

	private TrainCarInteriorPhysics interiorPhysics;

	private Coroutine dummyExternalInteractablesCoro;

	[NonSerialized]
	public BrakeSystem brakeSystem;

	private Coroutine manualSpawnHandbrakesSetupCoro;

	[NonSerialized]
	public int indexInTrainset;

	private Trainset _trainset;

	[NonSerialized]
	public TrainCarColliders carColliders;

	private (SimController controller, bool initialized) _simController;

	private CarStateSave carStateSave;

	private CarDebtController carDebtController;

	[NonSerialized]
	public bool isExploded;

	public Car logicCar;

	public const string DIESEL_HOSE_SOCKET_TAG = "diesel-hose";

	public const string ELECTRIC_CHARGE_SOCKET_TAG = "electric-charge-cable";

	private DerailedTrainCarIsKinematicHandler derailedCarHandler;

	private Telemetry telemetryRecorder;

	private static Collider[] _zoneBlockerCols = new Collider[5];

	private static int? _zoneBlockerLayerMask;

	public Coupler frontCoupler => couplers[0];

	public Coupler rearCoupler => couplers[1];

	public Transform FrontCouplerAnchor
	{
		get
		{
			if (_frontCouplerAnchor == null)
			{
				_frontCouplerAnchor = base.transform.Find("[coupler front]");
			}
			return _frontCouplerAnchor;
		}
	}

	public Transform RearCouplerAnchor
	{
		get
		{
			if (_rearCouplerAnchor == null)
			{
				_rearCouplerAnchor = base.transform.Find("[coupler rear]");
			}
			return _rearCouplerAnchor;
		}
	}

	public float PivotToFrontCouplerZOffset => FrontCouplerAnchor.localPosition.z;

	public float PivotToRearCouplerZOffset => RearCouplerAnchor.localPosition.z;

	public float PivotToTrackHeightOffset => RearBogie.transform.localPosition.y;

	public float InterCouplerDistance
	{
		get
		{
			if (_interCouplerDistance == 0f)
			{
				_interCouplerDistance = Vector3.Distance(FrontCouplerAnchor.position, RearCouplerAnchor.position);
			}
			return _interCouplerDistance;
		}
	}

	public Bogie[] Bogies
	{
		get
		{
			if (_bogies == null || _bogies.Length == 0)
			{
				_bogies = (from b in GetComponentsInChildren<Bogie>()
					orderby b.transform.localPosition.z
					select b).ToArray();
			}
			return _bogies;
		}
	}

	public Bogie RearBogie => Bogies[0];

	public Bogie FrontBogie => Bogies[Bogies.Length - 1];

	public int NumberOfAxles
	{
		get
		{
			if (numberOfAxles == -1)
			{
				numberOfAxles = 0;
				Bogie[] bogies = Bogies;
				foreach (Bogie bogie in bogies)
				{
					numberOfAxles += bogie.Axles.Length;
				}
			}
			return numberOfAxles;
		}
	}

	public Bounds Bounds
	{
		get
		{
			if (_bounds.size.z == 0f || !Application.isPlaying)
			{
				_bounds = TrainCarColliders.GetCollisionBounds(this);
				_bounds.Encapsulate(FrontCouplerAnchor.localPosition);
				_bounds.Encapsulate(RearCouplerAnchor.localPosition);
			}
			return _bounds;
		}
	}

	public bool IsLoco
	{
		get
		{
			bool? isLoco = _isLoco;
			if (!isLoco.HasValue)
			{
				bool? flag = (_isLoco = CarTypes.IsLocomotive(carLivery));
				return flag.Value;
			}
			return isLoco == true;
		}
	}

	public bool IsCaboose
	{
		get
		{
			bool? isCaboose = _isCaboose;
			if (!isCaboose.HasValue)
			{
				bool? flag = (_isCaboose = CarTypes.IsCaboose(carLivery));
				return flag.Value;
			}
			return isCaboose == true;
		}
	}

	public bool IsMultipleUnit => muModule != null;

	public CargoModelController CargoModelController { get; private set; }

	public TrainCarCustomization Customization { get; private set; }

	public TrainCarPaint PaintInterior { get; private set; }

	public TrainCarPaint PaintExterior { get; private set; }

	public GameObject loadedInterior { get; private set; }

	public GameObject loadedExternalInteractables { get; private set; }

	public GameObject loadedDummyExternalInteractables { get; private set; }

	public CollisionInfoDispenser CollisionInfoDispenser { get; private set; }

	public bool IsInteriorLoaded => (object)loadedInterior != null;

	public bool AreExternalInteractablesLoaded => loadedExternalInteractables != null;

	public bool AreDummyExternalInteractablesLoaded => loadedDummyExternalInteractables != null;

	public Trainset trainset
	{
		get
		{
			return _trainset;
		}
		set
		{
			if (value != _trainset)
			{
				this.TrainsetAboutToBeChanged?.Invoke(value);
				_trainset = value;
				this.TrainsetChanged?.Invoke(value);
			}
		}
	}

	public TrainCarTileInteraction TileInteraction { get; private set; }

	public TrainCarCollisions TrainCarCollisions { get; private set; }

	public CargoDamageModel CargoDamage { get; private set; }

	public CarDamageModel CarDamage { get; private set; }

	public SimController SimController
	{
		get
		{
			if (!_simController.initialized)
			{
				(SimController, bool) tuple = (_simController = (controller: GetComponent<SimController>(), initialized: true));
				return tuple.Item1;
			}
			return _simController.controller;
		}
	}

	public DynamicFastTravelDestination FastTravelDestination { get; private set; }

	public DVConvertToEntity entity { get; private set; }

	public string ID
	{
		get
		{
			if (logicCar != null)
			{
				return logicCar.ID;
			}
			Debug.LogError("logicCar not set, but ID accessed! Returning empty string.");
			return string.Empty;
		}
	}

	public string CarGUID
	{
		get
		{
			if (logicCar != null)
			{
				return logicCar.carGuid;
			}
			Debug.LogError("logicCar not set, but CarGUID accessed! Returning empty string.");
			return string.Empty;
		}
	}

	public CargoType LoadedCargo
	{
		get
		{
			if (logicCar != null)
			{
				return logicCar.CurrentCargoTypeInCar;
			}
			Debug.LogError("logicCar not set, returning None!");
			return CargoType.None;
		}
	}

	public float LoadedCargoAmount
	{
		get
		{
			if (logicCar != null)
			{
				return logicCar.LoadedCargoAmount;
			}
			Debug.LogError("logicCar not set, returning 0!");
			return 0f;
		}
	}

	public bool IsCargoLoadedUnloadedByMachine
	{
		get
		{
			if (logicCar != null)
			{
				return logicCar.CargoOriginWarehouse != null;
			}
			Debug.LogError("logicCar not set, returning false!");
			return false;
		}
	}

	public PlugSocket[] FuelSockets { get; private set; }

	public bool IsTeleporting { get; private set; }

	public bool IsRerailAllowed
	{
		get
		{
			if (derailed && rb.velocity.magnitude < 1f)
			{
				return !preventRerail;
			}
			return false;
		}
	}

	public bool isEligibleForSleep { get; private set; }

	public bool isStationary { get; private set; }

	public Telemetry TelemetryRecorder
	{
		get
		{
			if (telemetryRecorder == null)
			{
				telemetryRecorder = new Telemetry(this);
			}
			return telemetryRecorder;
		}
	}

	public event Action InteriorReloadedOnExplosion;

	public event Action<GameObject> InteriorLoaded;

	public event Action<GameObject> InteriorAboutToBeUnloaded;

	public event Action<GameObject> ExternalInteractableLoaded;

	public event Action<GameObject> ExternalInteractableAboutToBeUnloaded;

	public event Action<TrainCar> InteriorAboutToBeDestroyed;

	public event Action<Trainset> TrainsetAboutToBeChanged;

	public event Action<Trainset> TrainsetChanged;

	public event Action<CargoType> CargoLoaded;

	public event Action CargoUnloaded;

	public event Action LogicCarInitialized;

	public event Action OnCarAboutToBeDestroyed;

	public event Action<TrainCar> OnDestroyCar;

	public event Action OnAwakeFromPool;

	public event Derailed OnDerailed;

	public event Action OnRerailed;

	public event Action SuppressDerailSound;

	public event Action<bool> MovementStateChanged;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void StaticInit()
	{
		interiorContainerArchetype = new CachedArchetype(ComponentType.ReadWrite<Transform>(), ComponentType.ReadWrite<LocalToWorld>(), ComponentType.ReadWrite<CopyTransformFromGameObjectLateUpdate>(), ComponentType.ReadWrite<VelocityEstimate>(), ComponentType.ReadWrite<PreviousFrameLocalToWorld>());
		normalArchetype = new CachedArchetype(ComponentType.ReadWrite<TrainCar>(), ComponentType.ReadWrite<Transform>(), ComponentType.ReadWrite<LocalToWorld>(), ComponentType.ReadWrite<CopyTransformFromGameObject>(), ComponentType.ReadWrite<TrainCarPositionMonitorSystem.TrainCarPositionData>(), ComponentType.ReadWrite<TrainCarPositionMonitorSystem.IsMovingTag>(), ComponentType.ReadWrite<AdhesionControllerSystem.StaticSharedAdhesionCalculationData>(), ComponentType.ReadWrite<AdhesionControllerSystem.StaticAdhesionCalculationData>(), ComponentType.ReadWrite<AdhesionControllerSystem.AdhesionCalculationData>(), ComponentType.ReadWrite<AdhesionControllerSystem.WheelSlideData>(), ComponentType.ReadWrite<AdhesionControllerSystem.AdhesionWheelslipOutputData>());
		wheelslipArchetype = new CachedArchetype(normalArchetype, ComponentType.ReadWrite<WheelslipController>(), ComponentType.ReadWrite<WheelslipControllerSystem.WheelslipInputData>(), ComponentType.ReadWrite<WheelslipControllerSystem.WheelslipOutputData>());
	}

	public bool AreBogiesFullyInitialized()
	{
		Bogie[] bogies = Bogies;
		for (int i = 0; i < bogies.Length; i++)
		{
			if (!bogies[i].fullyInitialized)
			{
				return false;
			}
		}
		return true;
	}

	private void RearBogieTrackUpdated(RailTrack railtrack, Bogie _)
	{
		if (logicCar != null)
		{
			logicCar.UpdateRearBogieTrack(railtrack?.LogicTrack());
		}
		else
		{
			Debug.LogError("logicCar not set, but track was updated!");
		}
	}

	private void FrontBogieTrackUpdated(RailTrack railtrack, Bogie _)
	{
		if (logicCar != null)
		{
			logicCar.UpdateFrontBogieTrack(railtrack?.LogicTrack());
		}
		else
		{
			Debug.LogError("logicCar not set, but track was updated!");
		}
	}

	private void OnLogicCarLoaded(CargoType cargoType)
	{
		this.CargoLoaded?.Invoke(cargoType);
	}

	private void OnLogicCarUnloaded()
	{
		this.CargoUnloaded?.Invoke();
	}

	private void Awake()
	{
		entity = base.gameObject.AddComponent<DVConvertToEntity>();
		if (carLivery == null)
		{
			Debug.LogError("TrainCar without assigned carLivery", this);
		}
		bool poolSetupInProgress = SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress;
		if (base.transform.parent != null)
		{
			Debug.Log("Reparenting car '" + base.name + "' from '" + base.transform.parent.name + "' to scene root", this);
			base.transform.SetParent(null);
		}
		InitializeObjectPaint(base.gameObject, out var exteriorReference, out var interiorReference);
		if (exteriorReference != null)
		{
			PaintExterior = exteriorReference;
			PaintExterior.OnThemeChanged += OnPaintThemeChanged;
		}
		if (interiorReference != null)
		{
			PaintInterior = interiorReference;
			PaintInterior.OnThemeChanged += OnPaintThemeChanged;
		}
		brakeSystem = base.gameObject.AddComponent<BrakeSystem>();
		brakeSystem.gameParams = Globals.G.GameParams.BrakeParams;
		TrainCarType_v2.BrakesSetup brakes = carLivery.parentType.brakes;
		brakeSystem.Initialize(brakes.hasCompressor, brakes.hasMainResConnections, brakes.trainBrake != TrainCarType_v2.BrakesSetup.TrainBrake.None, brakes.trainBrake == TrainCarType_v2.BrakesSetup.TrainBrake.SelfLap, brakes.hasIndependentBrake, brakes.hasHandbrake, brakes.ignoreOverheating, (BrakeSystem.BrakeCylinderPressureCalculation)brakes.brakeCylinderPressureCalculation, (brakes.trainBrakeCurveData != null) ? brakes.trainBrakeCurveData.brakesCurve : null, (brakes.indBrakeCurveData != null) ? brakes.indBrakeCurveData.brakesCurve : null);
		if (!poolSetupInProgress)
		{
			Trainset.Create(this);
			Brakeset.Create(brakeSystem);
			brakeSystem.BrakingFactorChanged += AwakeCarOnBrakingFactorChanged;
		}
		_ = SingletonBehaviour<TrainVegetationInteractionManager>.Instance;
		_ = SingletonBehaviour<HoseSeparationChecker>.Instance;
		_ = Bounds;
		CollisionInfoDispenser = base.gameObject.AddComponent<CollisionInfoDispenser>();
		massController = new TrainMassController(this);
		adhesionController = new AdhesionController(this);
		muModule = GetComponent<MultipleUnitModule>();
		if (IsMultipleUnit)
		{
			muModule.Initialize(this);
		}
		SetupRigidbody();
		SetupInterior();
		SetupTrainStress();
		SetupBuoyancy();
		carColliders = base.gameObject.AddComponent<TrainCarColliders>();
		carColliders.SetupTrainCar(this, interior);
		groundFriction = new GroundFriction(this, carColliders.GetBogies());
		derailedParticles = new DerailedParticles(this);
		ControlsInstantiator.InstantiateCabItems(interior);
		SetupCouplers();
		frontCoupler.Coupled += AwakeCarOnCouple;
		frontCoupler.Uncoupled += AwakeCarOnUnCouple;
		rearCoupler.Coupled += AwakeCarOnCouple;
		rearCoupler.Uncoupled += AwakeCarOnUnCouple;
		if (carLivery.parentType.useDefaultWheelRotation)
		{
			WheelRotationViaCode wheelRotationViaCode = base.gameObject.AddComponent<WheelRotationViaCode>();
			wheelRotationViaCode.wheelRadius = carLivery.parentType.wheelRadius;
			Transform[] transformsToRotate = Bogies.SelectMany((Bogie b) => b.Axles.Select((Bogie.AxleInfo a) => a.transform)).ToArray();
			wheelRotationViaCode.transformsToRotate = transformsToRotate;
		}
		physicsLod = base.gameObject.AddComponent<TrainPhysicsLod>();
		physicsLod.OnCreated(this, carColliders);
		if (!poolSetupInProgress)
		{
			physicsLod.SetupListeners(set: true);
		}
		TrainCarCollisions = base.gameObject.AddComponent<TrainCarCollisions>();
		TileInteraction = base.gameObject.AddComponent<TrainCarTileInteraction>();
		TileInteraction.OnCreated(this);
		CarDamage = base.gameObject.AddComponent<CarDamageModel>();
		CarDamage.OnCreated(this);
		bool num = Globals.G.Types.CarTypeToLoadableCargo[carLivery.parentType].Count > 0;
		if (num)
		{
			CargoModelController = base.gameObject.AddComponent<CargoModelController>();
			CargoModelController.InitializeCargoModelController(this, carColliders);
			CargoDamage = base.gameObject.AddComponent<CargoDamageModel>();
			CargoDamage.OnCreated(this);
			cargoContent = base.gameObject.AddComponent<CargoContent>();
			cargoContent.OnCreated(this);
		}
		DamageController component = GetComponent<DamageController>();
		bool flag = component != null;
		if (num || !flag)
		{
			carDebtController = base.gameObject.AddComponent<CarDebtController>();
			carDebtController.OnCreated(this, flag);
			carStateSave = base.gameObject.AddComponent<CarStateSave>();
			carStateSave.Initialize(flag ? null : CarDamage, CargoDamage);
		}
		if (flag)
		{
			component.InitializeTrainCarScripts(this, CarDamage, stress);
		}
		if ((bool)SimController)
		{
			SimController.Initialize(this, component);
			massController.SetResourceContainerController(SimController.resourceContainerController);
		}
		if (!TryGetComponent<TrainCarCustomization>(out var component2))
		{
			component2 = base.gameObject.AddComponent<TrainCarCustomization>();
		}
		Customization = component2;
		component2.Initialize(this);
		switch (carLivery.parentType.unusedCarDeletePreventionMode)
		{
		case TrainCarType_v2.UnusedCarDeletePreventionMode.TimeBasedCarVisit:
			visitChecker = new CarVisitChecker(this);
			break;
		case TrainCarType_v2.UnusedCarDeletePreventionMode.TimeBasedCarVisitPropagatedToFrontCar:
			visitChecker = new CarVisitChecker(this, propagateToFront: true);
			break;
		case TrainCarType_v2.UnusedCarDeletePreventionMode.TimeBasedCarVisitPropagatedToRearCar:
			visitChecker = new CarVisitChecker(this, propagateToFront: false, propagateToRear: true);
			break;
		case TrainCarType_v2.UnusedCarDeletePreventionMode.TimeBasedCarVisitPropagatedToFrontAndRearCar:
			visitChecker = new CarVisitChecker(this, propagateToFront: true, propagateToRear: true);
			break;
		default:
			Debug.LogError(string.Format("Unhandled {0}: {1}. Ignoring {2} creation", "UnusedCarDeletePreventionMode", carLivery.parentType.unusedCarDeletePreventionMode, "visitChecker"));
			break;
		case TrainCarType_v2.UnusedCarDeletePreventionMode.None:
		case TrainCarType_v2.UnusedCarDeletePreventionMode.OnlyManualDeletePossible:
			break;
		}
		if (visitChecker != null && !poolSetupInProgress)
		{
			visitChecker.SetupListeners(set: true);
		}
		trainPlatesCtrl = base.gameObject.AddComponent<TrainCarPlatesController>();
		trainPlatesCtrl.CreateTrainCarPlates(this, CarDamage, CargoDamage, IsLoco, InterCouplerDistance, carLivery.parentType.mass);
		RearBogie.TrackChanged += RearBogieTrackUpdated;
		FrontBogie.TrackChanged += FrontBogieTrackUpdated;
		FuelSockets = (from socket in GetComponentsInChildren<PlugSocket>()
			where socket.connectionTag == "diesel-hose" || socket.connectionTag == "electric-charge-cable"
			select socket).ToArray();
		if (!poolSetupInProgress)
		{
			SingletonBehaviour<TelemetryCentral>.Instance.RegisterForFixedUpdates(this);
		}
		entity.OnConverted += delegate(EntityManager entityManager, Entity entity)
		{
			entityManager.AddComponentObject(entity, this);
			entityManager.SetComponentData(entity, new TrainCarPositionMonitorSystem.TrainCarPositionData
			{
				isInteriorLoaded = IsInteriorLoaded
			});
			entityManager.SetComponentData(entity, new AdhesionControllerSystem.StaticSharedAdhesionCalculationData
			{
				bogieCount = (byte)Bogies.Length,
				numOfAxles = (byte)NumberOfAxles
			});
			entityManager.SetComponentData(entity, new AdhesionControllerSystem.StaticAdhesionCalculationData
			{
				wheelSlideFrictionCoef = carLivery.parentType.WheelSlideFrictionCoef,
				wheelslipFrictionCoef = carLivery.parentType.WheelslipFrictionCoef
			});
			if (adhesionController.wheelslipController.IsSome(out var value))
			{
				entityManager.AddComponentObject(entity, value);
			}
		};
		entity.Initialize((adhesionController.wheelslipController.IsSome() ? wheelslipArchetype : normalArchetype).Archetype);
	}

	public void AwakeForPooledCar()
	{
		Trainset.Create(this);
		Brakeset.Create(brakeSystem);
		brakeSystem.BrakingFactorChanged += AwakeCarOnBrakingFactorChanged;
		physicsLod.SetupListeners(set: true);
		stress.Initialize();
		interiorPhysics.Inititalize();
		if (visitChecker != null)
		{
			visitChecker.SetupListeners(set: true);
		}
		InitAudio();
		SingletonBehaviour<TelemetryCentral>.Instance.RegisterForFixedUpdates(this);
		if ((bool)FastTravelDestination)
		{
			UpdateFastTravelDestinationVisibility(PlayerManager.Car);
			PlayerManager.CarChanged += UpdateFastTravelDestinationVisibility;
		}
		this.OnAwakeFromPool?.Invoke();
	}

	private void Start()
	{
		bool poolSetupInProgress = SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress;
		if (!poolSetupInProgress)
		{
			InitAudio();
		}
		if (logicCar == null && !poolSetupInProgress)
		{
			Debug.LogWarning("logicCar was not initialized, initializing new logic car", this);
			InitializeNewLogicCar();
			Bogie[] bogies = Bogies;
			foreach (Bogie bogie in bogies)
			{
				if (bogie.track != null)
				{
					bogie.SetTrack(bogie.track, bogie.spawnPointsetSpan);
				}
			}
		}
		TryAddFastTravelDestination();
	}

	private void OnDisable()
	{
		UnloadInterior();
	}

	public void UpdateMassRatioWhenBogiesInitialized()
	{
		Bogie[] bogies = Bogies;
		for (int i = 0; i < bogies.Length; i++)
		{
			if ((object)bogies[i].rb == null)
			{
				return;
			}
		}
		massController.UpdateTrainCarMass();
	}

	public void Fire_OnCarAboutToBeDestroyed()
	{
		this.OnCarAboutToBeDestroyed?.Invoke();
	}

	public void PrepareForDestroy()
	{
		UnplugResourceHoses();
		SingletonBehaviour<IdGenerator>.Instance.UnregisterCarId(ID);
		SingletonBehaviour<IdGenerator>.Instance.carGuidToCar.Remove(CarGUID);
		SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.Remove(logicCar);
		logicCar.CargoLoaded -= OnLogicCarLoaded;
		logicCar.CargoUnloaded -= OnLogicCarUnloaded;
		logicCar = null;
		stress.Deinitialize();
		interiorPhysics.Deinititalize();
		physicsLod.SetupListeners(set: false);
		trainset.Destroy();
		trainset = null;
		if (visitChecker != null)
		{
			visitChecker.Deinitialize();
		}
		brakeSystem.BrakingFactorChanged -= AwakeCarOnBrakingFactorChanged;
		brakeSystem.brakeset.Destroy();
		brakeSystem.brakeset = null;
		if (manualSpawnHandbrakesSetupCoro != null)
		{
			StopCoroutine(manualSpawnHandbrakesSetupCoro);
			manualSpawnHandbrakesSetupCoro = null;
		}
		Bogie[] bogies = Bogies;
		for (int i = 0; i < bogies.Length; i++)
		{
			bogies[i].RemoveBogieFromCurrentTrack();
		}
		if (derailedCarHandler != null)
		{
			derailedCarHandler.Destroy();
			derailedCarHandler = null;
		}
		SingletonBehaviour<TelemetryCentral>.Instance.UnregisterFromFixedUpdates(this);
		TelemetryRecorder.ReleaseBuffers();
		if ((bool)FastTravelDestination)
		{
			PlayerManager.CarChanged -= UpdateFastTravelDestinationVisibility;
		}
	}

	public void ReturnCarToPool()
	{
		if (logicCar.CurrentCargoTypeInCar != CargoType.None)
		{
			logicCar.UnloadCargo(logicCar.LoadedCargoAmount, logicCar.CurrentCargoTypeInCar);
		}
		PrepareForDestroy();
		Bogie[] bogies;
		if (derailed)
		{
			bogies = Bogies;
			foreach (Bogie obj in bogies)
			{
				obj.RerailInitialize();
				obj.ResetBogieMassToDefault();
			}
			derailed = false;
			carColliders.SetBogieColliders(trainDerailed: false);
		}
		rb.mass = massController.DefaultCarRbMass;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.useGravity = true;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
		bogies = Bogies;
		foreach (Bogie obj2 in bogies)
		{
			obj2.rb.velocity = Vector3.zero;
			obj2.rb.angularVelocity = Vector3.zero;
			obj2.rb.useGravity = true;
			obj2.PreventSlopePositionHolding();
			obj2.ResetBogiesToStartPosition();
		}
		if (isExploded)
		{
			TrainCarExplosion.RevertModelToUnexploded(this);
		}
		isStationary = false;
		isEligibleForSleep = false;
		Coupler coupler = frontCoupler;
		coupler.preventAutoCouple = false;
		coupler.state = ChainCouplerInteraction.State.Parked;
		Coupler coupler2 = rearCoupler;
		coupler2.preventAutoCouple = false;
		coupler2.state = ChainCouplerInteraction.State.Parked;
		brakeSystem.ResetState();
		adhesionController.ResetState();
		groundFriction.ResetState();
		derailedParticles.ResetState();
		TrainCarTileInteraction tileInteraction = TileInteraction;
		tileInteraction.canDamageCar = true;
		tileInteraction.canDamageCargo = false;
		this.OnDestroyCar?.Invoke(this);
		CarDamage.RepairCar(CarDamage.maxHealth);
		if (CargoDamage != null)
		{
			CargoDamage.currentDamageState = DamageState.WithinSafeLimits;
		}
		physicsLod.ResetToInitialState();
		if (PaintExterior != null)
		{
			PaintExterior.CurrentTheme = PaintExterior.OriginallyAssignedTheme;
		}
		if (PaintInterior != null)
		{
			PaintInterior.CurrentTheme = PaintInterior.OriginallyAssignedTheme;
		}
		EntityCommandBuffer entityCommandBuffer = entity.EntityManager.World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>().CreateCommandBuffer();
		entityCommandBuffer.SetComponent(entity.Entity, default(TrainCarPositionMonitorSystem.TrainCarPositionData));
		entityCommandBuffer.AddComponent<TrainCarPositionMonitorSystem.IsMovingTag>(entity.Entity);
		entityCommandBuffer.SetComponent(entity.Entity, default(AdhesionControllerSystem.WheelSlideData));
		entityCommandBuffer.RemoveComponent<AdhesionControllerSystem.IsWheelSlidingTag>(entity.Entity);
		if (adhesionController.wheelslipController.IsSome(out var _))
		{
			entityCommandBuffer.SetComponent(entity.Entity, default(WheelslipControllerSystem.WheelslipOutputData));
			entityCommandBuffer.RemoveComponent<WheelslipControllerSystem.IsWheelslippingTag>(entity.Entity);
		}
		entityCommandBuffer.SetComponent(entity.Entity, new DistanceLodSystem.CurrentLodData
		{
			lod = byte.MaxValue
		});
		SingletonBehaviour<CarSpawner>.Instance.ReturnToPool(this);
	}

	private void OnDestroy()
	{
		if ((bool)FastTravelDestination)
		{
			PlayerManager.CarChanged -= UpdateFastTravelDestinationVisibility;
		}
		if (visitChecker != null)
		{
			visitChecker.Deinitialize();
		}
		if (!UnloadWatcher.isUnloading)
		{
			this.OnDestroyCar?.Invoke(this);
		}
	}

	private void CheckForParentedPlayer()
	{
		if (!UnloadWatcher.isUnloading && PlayerManager.Car == this)
		{
			Debug.LogError("[!!!] Player camera is still a child of " + base.name + " or its interior! This should not happen, trying to auto-recover...");
			if (PlayerManager.PlayerTransform.TryGetComponent<CharacterReparenting>(out var component))
			{
				component.ReparentTo(null);
			}
			if (PlayerManager.PlayerTransform.TryGetComponent<CustomFirstPersonController>(out var component2))
			{
				component2.MoveBy(Vector3.zero);
			}
		}
	}

	public void InteriorOnDestroy()
	{
		CheckForParentedPlayer();
		physicsLod.UnregisterAndActivateItems();
		this.InteriorAboutToBeDestroyed?.Invoke(this);
		if (physicsLod.HasRegisteredItems)
		{
			Debug.LogError("[TrainCar] Items got registered to activity handler during a InteriorAboutToBeDestroyed call! Clearing...");
			physicsLod.UnregisterAndActivateItems();
		}
	}

	public void InitializeNewLogicCar()
	{
		if (logicCar != null)
		{
			Debug.LogError("logicCar was already initialized! Unexpected behaviour, skipping double setup!");
			return;
		}
		logicCar = new Car(carLivery, InterCouplerDistance, cargoCapacity, playerSpawnedCar, uniqueCar);
		SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.Add(logicCar, this);
		InitializeLogicCarRelatedScript();
		this.LogicCarInitialized?.Invoke();
	}

	public void InitializeExistingLogicCar(string carId, string carGuid)
	{
		if (logicCar != null)
		{
			Debug.LogError("logicCar was already initialized! Unexpected behaviour, skipping double setup!");
			return;
		}
		logicCar = new Car(carLivery, InterCouplerDistance, cargoCapacity, carId, carGuid, playerSpawnedCar, uniqueCar);
		SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.Add(logicCar, this);
		InitializeLogicCarRelatedScript();
		this.LogicCarInitialized?.Invoke();
	}

	private void InitializeLogicCarRelatedScript()
	{
		logicCar.CargoLoaded += OnLogicCarLoaded;
		logicCar.CargoUnloaded += OnLogicCarUnloaded;
		if (trainPlatesCtrl != null)
		{
			trainPlatesCtrl.OverrideId(ID);
		}
		if (carDebtController != null)
		{
			if (!playerSpawnedCar)
			{
				carDebtController.SetDebtTracker(CarDamage, CargoDamage);
			}
			else
			{
				carDebtController.SetDummyDebtTracker();
			}
			carStateSave.SetDebtTrackerCar(carDebtController.CarDebtTracker);
		}
		if ((bool)FastTravelDestination)
		{
			FastTravelDestination.SetMarkerName(ID);
		}
	}

	public void TryAddFastTravelDestination()
	{
		if ((IsLoco || IsCaboose) && !FastTravelDestination)
		{
			FastTravelDestination = base.gameObject.AddComponent<DynamicFastTravelDestination>();
			FastTravelDestination.SetMarkerName(logicCar?.ID ?? carLivery.id);
			FastTravelDestination.markerType = (IsLoco ? DV.Teleporters.FastTravelDestination.MarkerType.Loco : DV.Teleporters.FastTravelDestination.MarkerType.Caboose);
			UpdateFastTravelDestinationVisibility(PlayerManager.Car);
			PlayerManager.CarChanged += UpdateFastTravelDestinationVisibility;
		}
	}

	private void UpdateFastTravelDestinationVisibility(TrainCar playerCar)
	{
		if ((bool)FastTravelDestination)
		{
			if (IsCaboose)
			{
				FastTravelDestination.showOnMap = playerCar != this && !preventFastTravelDestination;
			}
			else
			{
				FastTravelDestination.showOnMap = IsLoco && !preventFastTravelDestination && (trainset == null || playerCar?.trainset != trainset);
			}
			FastTravelDestination.RefreshMarkerVisibility();
		}
	}

	private void SetForwardSpeed(float speed)
	{
		rb.velocity = base.transform.forward * speed;
		Bogie[] bogies = Bogies;
		foreach (Bogie bogie in bogies)
		{
			bogie.rb.velocity = bogie.transform.forward * speed;
		}
	}

	public void StopMovement()
	{
		SetForwardSpeed(0f);
	}

	public float GetAbsSpeed()
	{
		return Mathf.Abs(GetForwardSpeed());
	}

	public float GetForwardSpeed()
	{
		return base.transform.InverseTransformDirection(rb.velocity).z;
	}

	public void SetTrack(RailTrack track, Vector3 worldPosition, Vector3 forward)
	{
		base.transform.rotation = Quaternion.LookRotation(forward);
		base.transform.position = worldPosition - forward * Bounds.center.z;
		Vector3 vector = Vector3.Lerp(RearBogie.transform.position, FrontBogie.transform.position, 0.5f);
		(EquiPointSet.Point?, float) closestPoint = RailTrack.GetClosestPoint(track, RearBogie.transform.position);
		(EquiPointSet.Point?, float) closestPoint2 = RailTrack.GetClosestPoint(track, FrontBogie.transform.position);
		RearBogie.SetTrack(track, closestPoint.Item1.Value.span);
		FrontBogie.SetTrack(track, closestPoint2.Item1.Value.span);
		Vector3 currentMove = WorldMover.currentMove;
		Vector3 vector2 = (Vector3)closestPoint.Item1.Value.position + currentMove;
		Vector3 vector3 = (Vector3)closestPoint2.Item1.Value.position + currentMove;
		Vector3 vector4 = Vector3.Lerp(vector2, vector3, 0.5f);
		base.transform.position += vector4 - vector;
		base.transform.rotation = Quaternion.LookRotation(vector3 - vector2);
	}

	public void SetClosestTrack()
	{
		var (track, point) = RailTrack.GetClosest(base.transform.position + base.transform.forward * Bounds.center.z, Bounds.extents.z);
		if (!point.HasValue)
		{
			Debug.Log("Couldn't find closest track", this);
			return;
		}
		Vector3 vector = point.Value.forward;
		if (Vector3.Dot(base.transform.forward, vector) < 0f)
		{
			vector = -vector;
		}
		SetTrack(track, (Vector3)point.Value.position + WorldMover.currentMove, vector);
	}

	private void SetupBuoyancy()
	{
		TrainBuoyancyController buoyancy = base.gameObject.AddComponent<TrainBuoyancyController>();
		buoyancy.enabled = derailed;
		OnDerailed += delegate
		{
			buoyancy.enabled = true;
		};
		OnRerailed += delegate
		{
			buoyancy.enabled = false;
		};
	}

	private void SetupRigidbody()
	{
		rb = GetComponent<Rigidbody>();
		if ((bool)rb)
		{
			Debug.LogWarning("Car '" + base.name + "' already has a Rigidbody, it shouldn't", this);
		}
		else
		{
			rb = base.gameObject.AddComponent<Rigidbody>();
		}
		rb.mass = massController.DefaultCarRbMass;
		rb.maxDepenetrationVelocity = 2f;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
		if (centerOfMassOverride != null)
		{
			rb.centerOfMass = base.transform.InverseTransformPoint(centerOfMassOverride.position);
		}
		SingletonBehaviour<PausePhysicsHandler>.Instance.Register(rb);
	}

	private void SetupInterior()
	{
		Transform transform = base.transform.Find("[interior]");
		GameObject interiorPrefab = carLivery.interiorPrefab;
		if ((bool)interiorPrefab && (bool)transform)
		{
			Debug.LogWarning("TrainCar '" + base.gameObject.name + "' has [interior] in car prefab even though it has interior prefab assigned, it will be deleted", base.gameObject);
			UnityEngine.Object.Destroy(transform.gameObject);
		}
		interiorLOD = base.transform.Find("[interior LOD]");
		if ((bool)interiorPrefab && !interiorLOD)
		{
			Debug.LogError("TrainCar '" + base.gameObject.name + "' has interior prefab assigned but no [interior LOD] child was found, there will probably be visual glitches", base.gameObject);
		}
		if ((bool)interiorLOD)
		{
			foreach (MeshRenderer item in from mr in interiorLOD.GetComponentsInChildren<MeshRenderer>()
				where mr.shadowCastingMode != ShadowCastingMode.Off
				select mr)
			{
				Debug.LogWarning(string.Format("{0} of '{1}' has shadow casting set to '{2}', changing it to 'Off'", "[interior LOD]", base.gameObject.name, item.shadowCastingMode), item);
				item.shadowCastingMode = ShadowCastingMode.Off;
			}
		}
		transform = base.transform.Find("[interior]");
		if ((bool)transform)
		{
			interior = transform;
		}
		else
		{
			interior = new GameObject().transform;
		}
		interior.gameObject.name = base.gameObject.name + " [interior]";
		interior.SetParent(null, worldPositionStays: true);
		interior.SetSiblingIndex(base.transform.GetSiblingIndex() + 1);
		interior.SetPositionAndRotation(base.transform.position, base.transform.rotation);
		interiorPhysics = base.gameObject.AddComponent<TrainCarInteriorPhysics>();
		interiorPhysics.OnCreated(this, interior);
		if (!SingletonBehaviour<CarSpawner>.Instance.PoolSetupInProgress)
		{
			interiorPhysics.Inititalize();
		}
		interior.gameObject.AddComponent<TrainCarInteriorObject>().actualTrainCar = this;
		if (TryGetComponent<CabinRenderOrdering>(out var component))
		{
			SortingGroup sortingGroup = interior.gameObject.AddComponent<SortingGroup>();
			component.ordering.Add(new CabinRenderOrdering.OrderingRenderer(sortingGroup, 0, 11));
		}
		Rigidbody rigidbody = interior.gameObject.AddComponent<Rigidbody>();
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
		interiorPhysics.interiorRb = rigidbody;
		base.transform.Find("[persistent interior]")?.SetParent(interior);
		interior.gameObject.AddComponent<DVConvertToEntity>().Initialize(interiorContainerArchetype.Archetype);
	}

	private void SetupTrainStress()
	{
		stress = base.gameObject.AddComponent<TrainStress>();
	}

	public void LoadInterior()
	{
		GameObject gameObject = ((isExploded && carLivery.explodedInteriorPrefab != null) ? carLivery.explodedInteriorPrefab : carLivery.interiorPrefab);
		if (gameObject == null)
		{
			return;
		}
		if (IsInteriorLoaded)
		{
			Debug.LogWarning("TrainCar '" + base.gameObject.name + "' interior already loaded", base.gameObject);
		}
		else if (!blockInteriorLoading)
		{
			if (interiorLOD != null)
			{
				interiorLOD.gameObject.SetActive(value: false);
			}
			loadedInterior = UnityEngine.Object.Instantiate(gameObject, interior);
			if (entity.TryGetComponentData<TrainCarPositionMonitorSystem.TrainCarPositionData>().IsSome(out var value))
			{
				value.isInteriorLoaded = true;
				entity.SetComponentData(value);
			}
			InitializeObjectPaint(loadedInterior, out paintCabExterior, out paintCabInterior);
			this.InteriorLoaded?.Invoke(loadedInterior);
		}
	}

	public void UnloadInterior()
	{
		if (IsInteriorLoaded)
		{
			if ((bool)interiorLOD)
			{
				interiorLOD.gameObject.SetActive(value: true);
			}
			this.InteriorAboutToBeUnloaded?.Invoke(loadedInterior);
			UnityEngine.Object.Destroy(loadedInterior);
			loadedInterior = null;
			if (entity.TryGetComponentData<TrainCarPositionMonitorSystem.TrainCarPositionData>().IsSome(out var value))
			{
				value.isInteriorLoaded = false;
				entity.SetComponentData(value);
			}
			this.InteriorLoaded?.Invoke(null);
		}
	}

	public void LoadExternalInteractables()
	{
		GameObject gameObject = ((isExploded && carLivery.explodedExternalInteractablesPrefab != null) ? carLivery.explodedExternalInteractablesPrefab : carLivery.externalInteractablesPrefab);
		if (!(gameObject == null))
		{
			if (AreExternalInteractablesLoaded)
			{
				Debug.LogError("Unexpected state: TrainCar '" + base.gameObject.name + "' external interactables already loaded", base.gameObject);
				return;
			}
			loadedExternalInteractables = UnityEngine.Object.Instantiate(gameObject, interior);
			InitializeObjectPaint(loadedExternalInteractables, out paintEIExterior, out paintEIInterior);
			this.ExternalInteractableLoaded?.Invoke(loadedExternalInteractables);
		}
	}

	public void UnloadExternalInteractables()
	{
		if (!AreExternalInteractablesLoaded)
		{
			Debug.LogError("Unexpected state: TrainCar '" + base.gameObject.name + "' external interactables already unloaded", base.gameObject);
			return;
		}
		this.ExternalInteractableAboutToBeUnloaded?.Invoke(loadedExternalInteractables);
		UnityEngine.Object.Destroy(loadedExternalInteractables);
		loadedExternalInteractables = null;
		this.ExternalInteractableLoaded?.Invoke(null);
	}

	public void LoadDummyExternalInteractables()
	{
		GameObject gameObject = ((isExploded && carLivery.explodedExternalInteractablesPrefab != null) ? carLivery.explodedExternalInteractablesPrefab : carLivery.externalInteractablesPrefab);
		if (!(gameObject == null))
		{
			if (AreDummyExternalInteractablesLoaded)
			{
				Debug.LogError(" Unexpected state: TrainCar '" + base.gameObject.name + "' dummy external interactables already loaded", base.gameObject);
				return;
			}
			loadedDummyExternalInteractables = UnityEngine.Object.Instantiate(gameObject, interior);
			InitializeObjectPaint(loadedDummyExternalInteractables, out paintEIExterior, out paintEIInterior);
			dummyExternalInteractablesCoro = StartCoroutine(DummyExternalInteractablesCoro());
		}
	}

	public void UnloadDummyExternalInteractables()
	{
		if (!AreDummyExternalInteractablesLoaded)
		{
			Debug.LogError("Unexpected state: TrainCar '" + base.gameObject.name + "' dummy external interactables already unloaded", base.gameObject);
			return;
		}
		if (dummyExternalInteractablesCoro != null)
		{
			StopCoroutine(dummyExternalInteractablesCoro);
			dummyExternalInteractablesCoro = null;
		}
		UnityEngine.Object.Destroy(loadedDummyExternalInteractables);
		loadedDummyExternalInteractables = null;
	}

	public void SwitchExternalInteractablesToDummy()
	{
		if (!(carLivery.externalInteractablesPrefab == null))
		{
			if (!AreExternalInteractablesLoaded)
			{
				Debug.LogError("Unexpected state: SwitchExternalInteractablesToDummy - TrainCar '" + base.gameObject.name + "' external interactables are not loaded", base.gameObject);
				LoadDummyExternalInteractables();
				return;
			}
			if (AreDummyExternalInteractablesLoaded)
			{
				Debug.LogError("Unexpected state: SwitchExternalInteractablesToDummy - TrainCar '" + base.gameObject.name + "' dummy external interactables already loaded", base.gameObject);
				LoadDummyExternalInteractables();
				return;
			}
			this.ExternalInteractableAboutToBeUnloaded?.Invoke(loadedExternalInteractables);
			loadedDummyExternalInteractables = loadedExternalInteractables;
			loadedExternalInteractables = null;
			this.ExternalInteractableLoaded?.Invoke(null);
			dummyExternalInteractablesCoro = StartCoroutine(DummyExternalInteractablesCoro());
		}
	}

	private IEnumerator DummyExternalInteractablesCoro()
	{
		yield return null;
		yield return null;
		yield return WaitFor.EndOfFrame;
		if (loadedDummyExternalInteractables == null)
		{
			Debug.LogError("Unexpected state: DummyExternalInteractablesCoro not stopped but loadedDummyExternalInteractables is null!");
			dummyExternalInteractablesCoro = null;
		}
		else
		{
			ScriptStripperRuntime.Strip(loadedDummyExternalInteractables);
			dummyExternalInteractablesCoro = null;
		}
	}

	public void RefreshLoadedPrefabsExplodedState()
	{
		if (IsInteriorLoaded && carLivery.explodedInteriorPrefab != null)
		{
			UnloadInterior();
			LoadInterior();
			this.InteriorReloadedOnExplosion?.Invoke();
		}
		if (AreExternalInteractablesLoaded && carLivery.explodedExternalInteractablesPrefab != null)
		{
			UnloadExternalInteractables();
			LoadExternalInteractables();
		}
		else if (AreDummyExternalInteractablesLoaded && carLivery.explodedExternalInteractablesPrefab != null)
		{
			UnloadDummyExternalInteractables();
			LoadDummyExternalInteractables();
		}
	}

	protected void SetupCouplers()
	{
		Transform transform = base.transform.Find("[coupler front]");
		Transform transform2 = base.transform.Find("[coupler rear]");
		if (!transform)
		{
			Debug.LogError("Couldn't find front coupler anchor. An object called '[coupler front]' must be a child of this object", this);
		}
		if (!transform2)
		{
			Debug.LogError("Couldn't find rear coupler anchor. An object called '[coupler rear]' must be a child of this object", this);
		}
		Coupler coupler = transform.gameObject.AddComponent<Coupler>();
		Coupler coupler2 = transform2.gameObject.AddComponent<Coupler>();
		coupler.isFrontCoupler = true;
		coupler2.isFrontCoupler = false;
		coupler.train = this;
		coupler2.train = this;
		couplers = new Coupler[2] { coupler, coupler2 };
		CouplerBreakDetector couplerBreakDetector = base.gameObject.AddComponent<CouplerBreakDetector>();
		CouplerBreakDetector couplerBreakDetector2 = base.gameObject.AddComponent<CouplerBreakDetector>();
		couplerBreakDetector.motherCoupler = coupler;
		couplerBreakDetector2.motherCoupler = coupler2;
		base.gameObject.AddComponent<CouplingScannerReferences>();
		VisualCouplerInit[] componentsInChildren = GetComponentsInChildren<VisualCouplerInit>();
		foreach (VisualCouplerInit visualCouplerInit in componentsInChildren)
		{
			if (Vector3.SqrMagnitude(transform.position - visualCouplerInit.transform.position) < Vector3.SqrMagnitude(transform2.position - visualCouplerInit.transform.position))
			{
				coupler.visualCoupler = visualCouplerInit;
				visualCouplerInit.Init(coupler);
			}
			else
			{
				coupler2.visualCoupler = visualCouplerInit;
				visualCouplerInit.Init(coupler2);
			}
		}
	}

	private void InitAudio()
	{
		if (SingletonBehaviour<TrainComponentPool>.Instance.RequestTrainAudioFromPool(this) == null)
		{
			Debug.LogError("Train sounds not found in AudioPool. This should not happen", this);
		}
	}

	public void Derail(bool suppressDerailSound = false, bool callDerailOnBogies = true)
	{
		if (!Application.isPlaying || derailed)
		{
			return;
		}
		derailed = true;
		ForceOptimizationState(sleep: false);
		if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
		{
			derailedCarHandler = new DerailedTrainCarIsKinematicHandler(this);
		}
		if (suppressDerailSound)
		{
			this.SuppressDerailSound?.Invoke();
		}
		this.OnDerailed?.Invoke(this);
		if (callDerailOnBogies)
		{
			Bogie[] bogies = Bogies;
			for (int i = 0; i < bogies.Length; i++)
			{
				bogies[i].Derail("Via TrainCar, due to derailAllBogiesAtOnce");
			}
		}
		brakeSystem.heatController.currentAbsSpeed = 0f;
		UpdateCouplerJoints();
		Anal.Derailed(this);
		if (SingletonBehaviour<TelemetryCentral>.Instance.enabled)
		{
			StartCoroutine(DelayedTelemetrySave(1f, "DERAIL-AUTO_"));
		}
	}

	public void DerailAllBogies(string derailMsg = "", bool suppressDerailSound = false)
	{
		Bogie[] bogies = Bogies;
		for (int i = 0; i < bogies.Length; i++)
		{
			bogies[i].Derail(derailMsg, suppressDerailSound);
		}
	}

	public void Rerail(RailTrack rerailTrack, Vector3 worldPos, Vector3 forward)
	{
		if (derailed)
		{
			StartCoroutine(RerailCoro(rerailTrack, worldPos, forward));
		}
	}

	private IEnumerator RerailCoro(RailTrack rerailTrack, Vector3 worldPos, Vector3 forward)
	{
		IsTeleporting = true;
		UncoupleSelf();
		UnplugResourceHoses();
		MultipleUnitModule.DisconnectCablesIfMultipleUnitSupported(this);
		yield return WaitFor.FixedUpdate;
		Bogie[] bogies = Bogies;
		for (int i = 0; i < bogies.Length; i++)
		{
			bogies[i].RerailInitialize();
		}
		SetTrack(rerailTrack, worldPos, forward);
		if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
		{
			derailedCarHandler.Destroy();
			derailedCarHandler = null;
		}
		if (brakeSystem.hasHandbrake)
		{
			brakeSystem.SetHandbrakePosition(1f);
		}
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		stress.ResetTrainStress();
		ForceOptimizationState(sleep: false);
		derailed = false;
		this.OnRerailed?.Invoke();
		IsTeleporting = false;
	}

	public void MoveToTrackWithCarUncouple(RailTrack destinationTrack, Vector3 worldPos, Vector3 forward)
	{
		if (derailed)
		{
			Debug.LogError("Attempt to move derailed car[" + ID + "]", this);
		}
		else
		{
			StartCoroutine(MoveToTrackWithCarUncoupleCoro(destinationTrack, worldPos, forward));
		}
	}

	private IEnumerator MoveToTrackWithCarUncoupleCoro(RailTrack rerailTrack, Vector3 worldPos, Vector3 forward)
	{
		IsTeleporting = true;
		UncoupleSelf();
		UnplugResourceHoses();
		yield return WaitFor.FixedUpdate;
		MoveToTrack(rerailTrack, worldPos, forward);
		IsTeleporting = false;
	}

	public void MoveToTrack(RailTrack rerailTrack, Vector3 worldPos, Vector3 forward)
	{
		UnplugResourceHoses();
		stress.DisableStressCheckForTwoSeconds();
		Bogie[] bogies = Bogies;
		foreach (Bogie obj in bogies)
		{
			obj.PreventSlopePositionHolding();
			obj.ResetBogiesToStartPosition();
		}
		SetTrack(rerailTrack, worldPos, forward);
		SetForwardSpeed(0f);
		rb.angularVelocity = Vector3.zero;
		stress.ResetTrainStress();
		ForceOptimizationState(sleep: false);
	}

	private void UpdateCouplerJoints()
	{
		ConfigurableJoint[] components = GetComponents<ConfigurableJoint>();
		foreach (ConfigurableJoint j in components)
		{
			UpdateCouplerJoint(j);
		}
		UpdateOtherCarCouplerJoints(frontCoupler);
		UpdateOtherCarCouplerJoints(rearCoupler);
	}

	private void UpdateOtherCarCouplerJoints(Coupler c)
	{
		if (!(c == null) && !(c.coupledTo == null))
		{
			ConfigurableJoint component = c.coupledTo.train.GetComponent<ConfigurableJoint>();
			if ((bool)component && (bool)component && component.connectedBody == rb)
			{
				UpdateCouplerJoint(component);
			}
		}
	}

	private void UpdateCouplerJoint(ConfigurableJoint j)
	{
		SoftJointLimitSpring linearLimitSpring = j.linearLimitSpring;
		linearLimitSpring.spring = 1000000f;
		linearLimitSpring.damper = 50000f;
		j.linearLimitSpring = linearLimitSpring;
		j.breakForce = 1350000f;
		j.xMotion = ConfigurableJointMotion.Limited;
	}

	public void UncoupleSelf(bool playAudio = true)
	{
		frontCoupler.Uncouple(playAudio);
		rearCoupler.Uncouple(playAudio);
	}

	private void UnplugResourceHoses()
	{
		if (FuelSockets == null)
		{
			return;
		}
		PlugSocket[] fuelSockets = FuelSockets;
		foreach (PlugSocket plugSocket in fuelSockets)
		{
			if ((bool)plugSocket && plugSocket.IsPluggedIn)
			{
				plugSocket.Eject();
			}
		}
	}

	public Vector3 GetVelocity()
	{
		return rb.velocity;
	}

	public void UpdateJobIdOnCarPlates(string jobId)
	{
		if (trainPlatesCtrl != null)
		{
			trainPlatesCtrl.UpdateJobIdData(jobId);
		}
	}

	internal void UpdateSleepState(bool isStationary, bool isEligibleForSleep)
	{
		this.isStationary = isStationary;
		this.isEligibleForSleep = isEligibleForSleep;
	}

	internal void OnMovementStateChanged(bool isMoving)
	{
		rb.interpolation = (isMoving ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None);
		this.MovementStateChanged?.Invoke(isMoving);
	}

	internal void OnInvalidPosition()
	{
		Debug.LogError($"Car '{base.name}' fell through the ground ({base.transform.AbsolutePosition()}) and will be deleted!", this);
		Job jobOfCar = SingletonBehaviour<JobsManager>.Instance.GetJobOfCar(logicCar);
		if (jobOfCar != null)
		{
			switch (jobOfCar.State)
			{
			case JobState.Available:
				jobOfCar.ExpireJob();
				break;
			case JobState.InProgress:
				SingletonBehaviour<JobsManager>.Instance.AbandonJob(jobOfCar);
				break;
			default:
				Debug.LogError($"Unexpected state {jobOfCar.State}, ignoring force abandon/expire!");
				break;
			}
		}
		SingletonBehaviour<CarSpawner>.Instance.DeleteCar(this);
		SingletonBehaviour<UnusedTrainCarDeleter>.Instance.ClearInvalidCarReferencesAfterManualDelete();
	}

	internal void OnOutOfWorld()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		Vector3 position = base.transform.position;
		float interpolated = HeightMapProvider.GetInterpolated(position);
		Vector3 vector = new Vector3(position.x, interpolated + 10f, position.z);
		base.transform.position = vector;
		Debug.LogError($"Car '{base.name}-[{ID}]' fell through the ground ({position}). Trying to recover, car moved to: {vector}!", this);
	}

	public void ForceOptimizationState(bool sleep, bool logChange = false)
	{
		if (sleep)
		{
			if (!rb.IsSleeping() || !AllBogiesSleep() || rb.useGravity || rb.velocity != Vector3.zero || rb.angularVelocity != Vector3.zero)
			{
				ForceSleep(set: true);
			}
		}
		else if (rb.IsSleeping() || AnyBogiesSleep() || !rb.useGravity)
		{
			if (entity.TryGetComponentData<TrainCarPositionMonitorSystem.TrainCarPositionData>().IsSome(out var value))
			{
				value.wakeUp = true;
				entity.SetComponentData(value);
			}
			ForceSleep(set: false);
		}
	}

	public void ForceSleep(bool set)
	{
		Bogie[] bogies = Bogies;
		foreach (Bogie bogie in bogies)
		{
			if (!bogie.HasDerailed)
			{
				bogie.ForceSleep(set);
			}
		}
		if (set)
		{
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			rb.Sleep();
		}
		else
		{
			rb.WakeUp();
			rb.useGravity = true;
		}
	}

	private bool AnyBogiesSleep()
	{
		Bogie[] bogies = Bogies;
		foreach (Bogie bogie in bogies)
		{
			if ((object)bogie.rb != null && bogie.rb.IsSleeping())
			{
				return true;
			}
		}
		return false;
	}

	private bool AllBogiesSleep()
	{
		Bogie[] bogies = Bogies;
		foreach (Bogie bogie in bogies)
		{
			if ((object)bogie.rb != null && !bogie.rb.IsSleeping())
			{
				return false;
			}
		}
		return true;
	}

	public void ActivateGravity(bool set)
	{
		if (rb.useGravity != set)
		{
			rb.useGravity = set;
		}
		Bogie[] bogies = Bogies;
		foreach (Bogie bogie in bogies)
		{
			if ((object)bogie.rb != null && bogie.rb.useGravity != set)
			{
				bogie.rb.useGravity = set;
			}
		}
	}

	private void AwakeCarOnCouple(object sender, CoupleEventArgs e)
	{
		if (!SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess)
		{
			ForceOptimizationState(sleep: false);
		}
	}

	private void AwakeCarOnUnCouple(object sender, UncoupleEventArgs e)
	{
		if (!SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess)
		{
			ForceOptimizationState(sleep: false);
		}
	}

	private void AwakeCarOnBrakingFactorChanged()
	{
		ForceOptimizationState(sleep: false);
	}

	public void SetupHandbrakesOnManualSpawn()
	{
		if (brakeSystem.hasHandbrake && !brakeSystem.brakeset.anyHandbrakeApplied)
		{
			if (manualSpawnHandbrakesSetupCoro != null)
			{
				StopCoroutine(manualSpawnHandbrakesSetupCoro);
			}
			manualSpawnHandbrakesSetupCoro = StartCoroutine(SetupHandbrakesOnManualSpawnCoro());
		}
	}

	private IEnumerator SetupHandbrakesOnManualSpawnCoro()
	{
		yield return WaitFor.Seconds(1.5f);
		if (brakeSystem.brakeset.anyHandbrakeApplied)
		{
			manualSpawnHandbrakesSetupCoro = null;
			yield break;
		}
		brakeSystem.SetHandbrakePosition(1f);
		manualSpawnHandbrakesSetupCoro = null;
	}

	private void OnPaintThemeChanged(TrainCarPaint paintController)
	{
		if (paintController == null)
		{
			return;
		}
		switch (paintController.TargetArea)
		{
		case TrainCarPaint.Target.Exterior:
			if (paintCabExterior != null)
			{
				paintCabExterior.CurrentTheme = paintController.CurrentTheme;
			}
			if (paintEIExterior != null)
			{
				paintEIExterior.CurrentTheme = paintController.CurrentTheme;
			}
			break;
		case TrainCarPaint.Target.Interior:
			if (paintCabInterior != null)
			{
				paintCabInterior.CurrentTheme = paintController.CurrentTheme;
			}
			if (paintEIInterior != null)
			{
				paintEIInterior.CurrentTheme = paintController.CurrentTheme;
			}
			break;
		}
	}

	private void InitializeObjectPaint(GameObject obj, out TrainCarPaint exteriorReference, out TrainCarPaint interiorReference)
	{
		exteriorReference = null;
		interiorReference = null;
		TrainCarPaint[] components = obj.GetComponents<TrainCarPaint>();
		foreach (TrainCarPaint trainCarPaint in components)
		{
			switch (trainCarPaint.TargetArea)
			{
			case TrainCarPaint.Target.Exterior:
				exteriorReference = trainCarPaint;
				if (PaintExterior != null)
				{
					trainCarPaint.CurrentTheme = PaintExterior.CurrentTheme;
				}
				break;
			case TrainCarPaint.Target.Interior:
				interiorReference = trainCarPaint;
				if (PaintInterior != null)
				{
					trainCarPaint.CurrentTheme = PaintInterior.CurrentTheme;
				}
				break;
			}
		}
	}

	public void RecordTelemetry()
	{
		if (!isStationary && base.isActiveAndEnabled && Time.timeScale > 0f)
		{
			TelemetryRecorder.RecordFrame();
		}
	}

	public void SaveTelemetry(string namePrefix = "")
	{
		TelemetryRecorder.SaveCSV(Path.Combine(Application.persistentDataPath, "Telemetry", namePrefix + "TrainCar_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + ID + ".csv"));
	}

	public void ReleaseTelemetryBuffers()
	{
		if (TelemetryRecorder.IsLazyAllocated)
		{
			TelemetryRecorder.ReleaseBuffers();
		}
	}

	private IEnumerator DelayedTelemetrySave(float delay, string prefix)
	{
		yield return WaitFor.SecondsRealtime(delay);
		SaveTelemetry(prefix);
	}

	public static TrainCar Resolve(GameObject potentialTrain)
	{
		if (!potentialTrain)
		{
			return null;
		}
		TrainCar componentInParent = potentialTrain.GetComponentInParent<TrainCar>();
		if ((bool)componentInParent)
		{
			return componentInParent;
		}
		TrainCarInteriorObject componentInParent2 = potentialTrain.GetComponentInParent<TrainCarInteriorObject>();
		if ((bool)componentInParent2)
		{
			return componentInParent2.actualTrainCar;
		}
		return null;
	}

	public static TrainCar Resolve(Transform potentialTrain)
	{
		if (!potentialTrain)
		{
			return null;
		}
		return Resolve(potentialTrain.gameObject);
	}

	public static List<Car> ExtractLogicCars(List<TrainCar> trainCars)
	{
		if (trainCars == null || trainCars.Count == 0)
		{
			Debug.LogError("Passed null or empty list of trainCars");
			return null;
		}
		List<Car> list = new List<Car>();
		for (int i = 0; i < trainCars.Count; i++)
		{
			if (trainCars[i] == null)
			{
				Debug.LogError(string.Format("{0}[{1}] is null! Aborting logic cars extraction!", "trainCars", i));
				return null;
			}
			if (trainCars[i].logicCar == null)
			{
				Debug.LogError(string.Format("{0}[{1}] doesn't have logicCar initialized! Aborting logic cars extraction!", "trainCars", i));
				return null;
			}
			list.Add(trainCars[i].logicCar);
		}
		return list;
	}

	public static List<TrainCar> ExtractTrainCars(List<Car> cars)
	{
		if (cars == null || cars.Count == 0)
		{
			Debug.LogError("Passed null or empty list of cars");
			return null;
		}
		List<TrainCar> list = new List<TrainCar>();
		for (int i = 0; i < cars.Count; i++)
		{
			if (cars[i] == null)
			{
				Debug.LogError(string.Format("{0}[{1}] is null! Aborting train cars extraction!", "cars", i));
				return null;
			}
			if (!SingletonBehaviour<TrainCarRegistry>.Instance.logicCarToTrainCar.TryGetValue(cars[i], out var value))
			{
				Debug.LogError(string.Format("{0}[{1}] doesn't have corresponding train car set! Aborting train cars extraction!", "cars", i));
				return null;
			}
			list.Add(value);
		}
		return list;
	}

	public static GameObject GetCarPrefab(TrainCarType carType)
	{
		if (carType == TrainCarType.NotSet)
		{
			return null;
		}
		return carType.ToV2()?.prefab;
	}

	public static bool IsInsideZoneBlocker(TrainCar car)
	{
		if (!_zoneBlockerLayerMask.HasValue)
		{
			_zoneBlockerLayerMask = LayerMask.GetMask("Train_Walkable");
		}
		int num;
		do
		{
			num = Physics.OverlapSphereNonAlloc(car.transform.position + Vector3.up * car.Bounds.center.y, 1f, _zoneBlockerCols, _zoneBlockerLayerMask.Value);
			for (int i = 0; i < num; i++)
			{
				if (_zoneBlockerCols[i].GetComponentInParent<ZoneBlocker>() != null)
				{
					return true;
				}
			}
		}
		while (RaycastUtils.ExtendOnCacheFull(ref _zoneBlockerCols, num));
		return false;
	}
}
