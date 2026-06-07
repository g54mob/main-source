using System;
using System.Collections.Generic;
using System.Linq;
using DV.Damage;
using DV.PitStops;
using DV.Rain;
using DV.RemoteControls;
using DV.ServicePenalty;
using DV.Simulation.Brake;
using DV.Simulation.Controllers;
using DV.Simulation.Ports;
using DV.Utils;
using DV.Wheels;
using LocoSim.Definitions;
using LocoSim.Implementations;
using LocoSim.Implementations.Wheels;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class SimController : MonoBehaviour, ISimulationFlowProvider
	{
		[Header("required")]
		public SimConnectionDefinition connectionsDefinition;

		[Header("optional")]
		public PoweredWheelsManager poweredWheels;

		public BaseControlsOverrider controlsOverrider;

		public BasePortsOverrider portsOverrider;

		public BroadcastPortController broadcastPortController;

		public ControlsBlockController controlsBlocker;

		public HeadlightsMainController headlightsController;

		public CabLightsController cabLightsController;

		public WipersSimControlInput wipersController;

		public ParticlesPortReadersController particlesController;

		public TractionPortsFeeder tractionPortsFeeder;

		public DrivingForce drivingForce;

		public ManualGearShiftingController gearShiftingController;

		public WheelslipController wheelslipController;

		public CompressorSimController compressor;

		public CoalPileSimController coalPile;

		public FireboxSimController firebox;

		public RemoteControllerModule remoteController;

		public EnvironmentDamageController environmentDamageController;

		public ResourceMassPortReader[] additionalMassPortReaders;

		public ASimInitializedController[] otherSimControllers;

		[Space]
		public float simTimeMultiplier = 1f;

		[Header("Must be infinite when forwarding resources between sims")]
		public float maxTickTime = float.PositiveInfinity;

		[NonSerialized]
		public SimulationFlow simFlow;

		[NonSerialized]
		public ResourceContainerController resourceContainerController;

		private SimulatedCarDebtTracker debt;

		private TrainCar train;

		private List<ASimInitializedController> otherSimControllersWithTick = new List<ASimInitializedController>();

		public SimulationFlow SimulationFlow => simFlow;

		private void OnValidate()
		{
			ResourceMassPortReader[] componentsInChildren = GetComponentsInChildren<ResourceMassPortReader>();
			if (additionalMassPortReaders == null || additionalMassPortReaders.Any((ResourceMassPortReader p) => p == null) || additionalMassPortReaders.Length != componentsInChildren.Length)
			{
				additionalMassPortReaders = componentsInChildren;
			}
			ASimInitializedController[] componentsInChildren2 = GetComponentsInChildren<ASimInitializedController>();
			if (otherSimControllers == null || otherSimControllers.Any((ASimInitializedController c) => c == null) || otherSimControllers.Length != componentsInChildren2.Length)
			{
				otherSimControllers = componentsInChildren2;
			}
		}

		public void Initialize(TrainCar trainCar, DamageController damageController)
		{
			train = trainCar;
			if (train == null)
			{
				base.enabled = false;
				Debug.LogError("Unexpected state: SimController has no train! Can't function properly", this);
				return;
			}
			simFlow = new SimulationFlow(connectionsDefinition, Globals.G.GameParams.SimParams);
			base.gameObject.AddComponent<SimCarStateSave>().Initialize(simFlow, damageController, train.muModule);
			if (controlsOverrider != null)
			{
				controlsOverrider.Init(train, simFlow);
			}
			if (portsOverrider != null)
			{
				portsOverrider.Init(simFlow);
			}
			if (broadcastPortController != null)
			{
				broadcastPortController.Init(train, simFlow);
			}
			if (controlsBlocker != null)
			{
				controlsBlocker.Init(simFlow);
			}
			if (headlightsController != null)
			{
				headlightsController.Init(train, simFlow);
			}
			if (cabLightsController != null)
			{
				cabLightsController.Init(train, simFlow);
			}
			if (wipersController != null)
			{
				wipersController.Init(train, simFlow);
			}
			if (particlesController != null)
			{
				particlesController.Init(simFlow);
			}
			if (tractionPortsFeeder != null)
			{
				tractionPortsFeeder.Init(train, simFlow);
			}
			if (drivingForce != null)
			{
				drivingForce.Init(train, simFlow);
			}
			if (gearShiftingController != null)
			{
				gearShiftingController.Init(train, simFlow);
			}
			if (wheelslipController != null)
			{
				wheelslipController.Init(train, simFlow, drivingForce);
			}
			if (compressor != null)
			{
				compressor.Init(train, simFlow);
			}
			if (coalPile != null)
			{
				coalPile.Init(train, simFlow);
			}
			if (firebox != null)
			{
				firebox.Init(train, simFlow);
			}
			if (remoteController != null)
			{
				remoteController.Init(train, wheelslipController, controlsOverrider, simFlow);
			}
			if (environmentDamageController != null)
			{
				environmentDamageController.Init(simFlow);
			}
			if (additionalMassPortReaders != null)
			{
				ResourceMassPortReader[] array = additionalMassPortReaders;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Init(simFlow);
				}
			}
			resourceContainerController = new ResourceContainerController(simFlow, additionalMassPortReaders);
			if (otherSimControllers != null)
			{
				ASimInitializedController[] array2 = otherSimControllers;
				foreach (ASimInitializedController aSimInitializedController in array2)
				{
					aSimInitializedController.Init(train, simFlow);
					if (aSimInitializedController.ExternalTick)
					{
						otherSimControllersWithTick.Add(aSimInitializedController);
					}
				}
			}
			train.LogicCarInitialized += OnLogicCarInitialized;
		}

		private void OnLogicCarInitialized()
		{
			train.LogicCarInitialized -= OnLogicCarInitialized;
			DamageController component = GetComponent<DamageController>();
			base.gameObject.AddComponent<SimulatedCarPitStopParameters>().Initialize(resourceContainerController.resourceContainers, component);
			if (!train.playerSpawnedCar || train.uniqueCar)
			{
				debt = new SimulatedCarDebtTracker(component, resourceContainerController, environmentDamageController, simFlow, train.ID, train.carType);
				if (train.uniqueCar)
				{
					SingletonBehaviour<OwnedCarsStateController>.Instance.RegisterCarStateTracker(train, debt);
				}
				else
				{
					SingletonBehaviour<LocoDebtController>.Instance.RegisterLocoDebtTracker(train, debt);
				}
			}
			train.OnDestroyCar += OnCarDestroyed;
		}

		private void OnCarDestroyed(TrainCar _)
		{
			train.OnDestroyCar -= OnCarDestroyed;
			if (!train.playerSpawnedCar || train.uniqueCar)
			{
				if (train.uniqueCar)
				{
					SingletonBehaviour<OwnedCarsStateController>.Instance.StageCarStateTrackerOnDestroy(debt);
				}
				else
				{
					SingletonBehaviour<LocoDebtController>.Instance.StageLocoDebtOnLocoDestroy(debt);
				}
			}
		}

		private void Update()
		{
			if (!TimeUtil.IsFlowing || SingletonBehaviour<PausePhysicsHandler>.Instance.PhysicsHandlingInProcess)
			{
				return;
			}
			resourceContainerController.UpdateTimer();
			float num = Time.deltaTime * simTimeMultiplier;
			if (tractionPortsFeeder != null)
			{
				tractionPortsFeeder.Tick(num);
			}
			foreach (ASimInitializedController item in otherSimControllersWithTick)
			{
				item.Tick(num);
			}
			if (Time.deltaTime <= maxTickTime)
			{
				simFlow.Tick(num);
				return;
			}
			int num2 = Mathf.CeilToInt(Time.deltaTime / maxTickTime);
			float delta = num / (float)num2;
			for (int i = 0; i < num2; i++)
			{
				simFlow.Tick(delta);
			}
		}
	}
}
