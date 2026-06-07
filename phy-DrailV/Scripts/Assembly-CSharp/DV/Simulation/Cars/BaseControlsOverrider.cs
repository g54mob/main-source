using System;
using System.Collections.Generic;
using System.Linq;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Simulation.Brake;
using DV.Simulation.Controllers;
using DV.Simulation.Ports;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class BaseControlsOverrider : MonoBehaviour
	{
		public interface IHandbrakeOverrider
		{
			HandbrakeControl GetHandbrake(TrainCar car);
		}

		[Serializable]
		public class PortSetter
		{
			[PortId(null, null, false)]
			public string portId;

			public float value;

			public PortSetter(string portId, float value)
			{
				this.portId = portId;
				this.value = value;
			}
		}

		private const float HANDBRAKE_APPLIED_THRESHOLD_UNCOUPLED = 0.75f;

		private const float HANDBRAKE_APPLIED_THRESHOLD_COUPLED = 0.9f;

		[SerializeField]
		private ThrottleControl throttle;

		[SerializeField]
		private BrakeControl brake;

		[SerializeField]
		private BrakeCutoutControl brakeCutout;

		[SerializeField]
		private IndependentBrakeControl independentBrake;

		[SerializeField]
		private DynamicBrakeControl dynamicBrake;

		[SerializeField]
		private ReverserControl reverser;

		[SerializeField]
		private SanderControl sander;

		[SerializeField]
		private HornControl horn;

		[SerializeField]
		private HeadlightsControlFront headlightsFront;

		[SerializeField]
		private HeadlightsControlRear headlightsRear;

		[SerializeField]
		private StarterControl starter;

		[SerializeField]
		private PowerOffControl powerOff;

		[SerializeField]
		private DynamoControl dynamo;

		[SerializeField]
		private AirPumpControl airPump;

		[SerializeField]
		private CabLightControl cabLight;

		[SerializeField]
		private IndCabLightControl indCabLight;

		[SerializeField]
		private WipersControl wipers;

		private HandbrakeControl handbrake;

		public PortSetter[] neutralStateSetters;

		public bool propagateNeutralStateToFront;

		public bool propagateNeutralStateToRear;

		private bool neutralStatePropagationInProgress;

		[SerializeField]
		private EngineOnReader engineOnReader;

		private SimulationFlow simFlow;

		[NonSerialized]
		public TrainCar car;

		[NonSerialized]
		public bool skipGameLoadBrakeSetup;

		private Dictionary<InteriorControlsManager.ControlType, OverridableBaseControl> controlsMap = new Dictionary<InteriorControlsManager.ControlType, OverridableBaseControl>();

		private static List<InteractablePortFeeder> tempListFeeders = new List<InteractablePortFeeder>();

		private static List<OverridableBaseControl> tempListControls = new List<OverridableBaseControl>();

		public ThrottleControl Throttle
		{
			get
			{
				if (!(throttle != null))
				{
					return null;
				}
				return throttle;
			}
		}

		public BrakeControl Brake
		{
			get
			{
				if (!(brake != null))
				{
					return null;
				}
				return brake;
			}
		}

		public BrakeCutoutControl BrakeCutout
		{
			get
			{
				if (!(brakeCutout != null))
				{
					return null;
				}
				return brakeCutout;
			}
		}

		public IndependentBrakeControl IndependentBrake
		{
			get
			{
				if (!(independentBrake != null))
				{
					return null;
				}
				return independentBrake;
			}
		}

		public DynamicBrakeControl DynamicBrake
		{
			get
			{
				if (!(dynamicBrake != null))
				{
					return null;
				}
				return dynamicBrake;
			}
		}

		public ReverserControl Reverser
		{
			get
			{
				if (!(reverser != null))
				{
					return null;
				}
				return reverser;
			}
		}

		public SanderControl Sander
		{
			get
			{
				if (!(sander != null))
				{
					return null;
				}
				return sander;
			}
		}

		public HornControl Horn
		{
			get
			{
				if (!(horn != null))
				{
					return null;
				}
				return horn;
			}
		}

		public HeadlightsControlFront HeadlightsFront
		{
			get
			{
				if (!(headlightsFront != null))
				{
					return null;
				}
				return headlightsFront;
			}
		}

		public HeadlightsControlRear HeadlightsRear
		{
			get
			{
				if (!(headlightsRear != null))
				{
					return null;
				}
				return headlightsRear;
			}
		}

		public StarterControl Starter
		{
			get
			{
				if (!(starter != null))
				{
					return null;
				}
				return starter;
			}
		}

		public PowerOffControl PowerOff
		{
			get
			{
				if (!(powerOff != null))
				{
					return null;
				}
				return powerOff;
			}
		}

		public DynamoControl Dynamo
		{
			get
			{
				if (!(dynamo != null))
				{
					return null;
				}
				return dynamo;
			}
		}

		public AirPumpControl AirPump
		{
			get
			{
				if (!(airPump != null))
				{
					return null;
				}
				return airPump;
			}
		}

		public CabLightControl CabLight
		{
			get
			{
				if (!(cabLight != null))
				{
					return null;
				}
				return cabLight;
			}
		}

		public IndCabLightControl IndCabLight
		{
			get
			{
				if (!(indCabLight != null))
				{
					return null;
				}
				return indCabLight;
			}
		}

		public WipersControl Wipers
		{
			get
			{
				if (!(wipers != null))
				{
					return null;
				}
				return wipers;
			}
		}

		public HandbrakeControl Handbrake
		{
			get
			{
				if (handbrake == null)
				{
					return null;
				}
				return handbrake;
			}
		}

		public EngineOnReader EngineOnReader
		{
			get
			{
				if (!(engineOnReader != null))
				{
					return null;
				}
				return engineOnReader;
			}
		}

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			this.car = car;
			this.simFlow = simFlow;
			tempListControls.Clear();
			tempListControls.Add(Throttle);
			tempListControls.Add(Brake);
			tempListControls.Add(BrakeCutout);
			tempListControls.Add(IndependentBrake);
			tempListControls.Add(DynamicBrake);
			tempListControls.Add(Reverser);
			tempListControls.Add(Sander);
			tempListControls.Add(Horn);
			tempListControls.Add(HeadlightsFront);
			tempListControls.Add(HeadlightsRear);
			tempListControls.Add(Starter);
			tempListControls.Add(PowerOff);
			tempListControls.Add(Dynamo);
			tempListControls.Add(AirPump);
			tempListControls.Add(CabLight);
			tempListControls.Add(IndCabLight);
			tempListControls.Add(Wipers);
			tempListFeeders.Clear();
			if ((bool)car.carLivery.interiorPrefab && car.carLivery.interiorPrefab.TryGetComponent<InteractablePortFeedersController>(out var component))
			{
				tempListFeeders.AddRange(component.entries);
			}
			if ((bool)car.carLivery.externalInteractablesPrefab && car.carLivery.externalInteractablesPrefab.TryGetComponent<InteractablePortFeedersController>(out var component2))
			{
				tempListFeeders.AddRange(component2.entries);
			}
			foreach (OverridableBaseControl tempListControl in tempListControls)
			{
				if (tempListControl == null)
				{
					continue;
				}
				ControlSpec spec = null;
				foreach (InteractablePortFeeder tempListFeeder in tempListFeeders)
				{
					if (tempListFeeder.portId == tempListControl.portId)
					{
						spec = tempListFeeder.gameObject.GetComponent<ControlSpec>();
						break;
					}
				}
				tempListControl.Init(car, simFlow, spec);
				controlsMap[tempListControl.ControlType] = tempListControl;
			}
			if (TryGetComponent<IHandbrakeOverrider>(out var component3))
			{
				handbrake = component3.GetHandbrake(car);
			}
			if (handbrake == null && car.brakeSystem.hasHandbrake)
			{
				ControlSpec controlSpec = null;
				if ((bool)car.carLivery.interiorPrefab && car.carLivery.interiorPrefab.TryGetComponent<HandbrakeFeedersController>(out var component4))
				{
					HandbrakeFeeder[] entries = component4.entries;
					foreach (HandbrakeFeeder handbrakeFeeder in entries)
					{
						if (handbrakeFeeder.control != null)
						{
							controlSpec = handbrakeFeeder.gameObject.GetComponent<ControlSpec>();
							break;
						}
					}
				}
				if (controlSpec == null && (bool)car.carLivery.externalInteractablesPrefab && car.carLivery.externalInteractablesPrefab.TryGetComponent<HandbrakeFeedersController>(out var component5))
				{
					HandbrakeFeeder[] entries = component5.entries;
					foreach (HandbrakeFeeder handbrakeFeeder2 in entries)
					{
						if (handbrakeFeeder2.control != null)
						{
							controlSpec = handbrakeFeeder2.gameObject.GetComponent<ControlSpec>();
							break;
						}
					}
				}
				handbrake = new HandbrakeControl(car, controlSpec);
			}
			EngineOnReader?.Init(simFlow);
			car.OnRerailed += SetNeutralState;
			car.InteriorLoaded += OnInteriorLoadedStateChanged;
			tempListFeeders.Clear();
			tempListControls.Clear();
		}

		public float GetValue(InteriorControlsManager.ControlType type, float defaultValue = float.MinValue)
		{
			if (controlsMap.TryGetValue(type, out var value))
			{
				return value.Value;
			}
			return defaultValue;
		}

		public OverridableBaseControl GetControl(InteriorControlsManager.ControlType type)
		{
			if (controlsMap.TryGetValue(type, out var value))
			{
				return value;
			}
			return null;
		}

		private void OnInteriorLoadedStateChanged(GameObject interior)
		{
			InteriorControlsManager interiorControlsManager = null;
			if ((bool)interior)
			{
				interiorControlsManager = interior.GetComponent<InteriorControlsManager>();
				if (!interiorControlsManager)
				{
					Debug.LogError("Missing interiorControlsManager!", this);
				}
			}
			Throttle?.SetInteriorControlsManager(interiorControlsManager);
			Brake?.SetInteriorControlsManager(interiorControlsManager);
			BrakeCutout?.SetInteriorControlsManager(interiorControlsManager);
			IndependentBrake?.SetInteriorControlsManager(interiorControlsManager);
			DynamicBrake?.SetInteriorControlsManager(interiorControlsManager);
			Reverser?.SetInteriorControlsManager(interiorControlsManager);
			Sander?.SetInteriorControlsManager(interiorControlsManager);
			Horn?.SetInteriorControlsManager(interiorControlsManager);
			HeadlightsFront?.SetInteriorControlsManager(interiorControlsManager);
			HeadlightsRear?.SetInteriorControlsManager(interiorControlsManager);
			Starter?.SetInteriorControlsManager(interiorControlsManager);
			PowerOff?.SetInteriorControlsManager(interiorControlsManager);
			Dynamo?.SetInteriorControlsManager(interiorControlsManager);
			AirPump?.SetInteriorControlsManager(interiorControlsManager);
			CabLight?.SetInteriorControlsManager(interiorControlsManager);
			IndCabLight?.SetInteriorControlsManager(interiorControlsManager);
			Wipers?.SetInteriorControlsManager(interiorControlsManager);
			Handbrake?.SetInteriorControlsManager(interiorControlsManager);
		}

		public void SetBrakesOnSpawn()
		{
			if (car.couplers.Any((Coupler c) => c.IsCoupled()))
			{
				if (skipGameLoadBrakeSetup)
				{
					return;
				}
				if (car.brakeSystem.brakeset.anyHandbrakeApplied)
				{
					bool flag = false;
					foreach (BrakeSystem car in car.brakeSystem.brakeset.cars)
					{
						if (car.handbrakePosition > 0.9f)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						foreach (TrainCar car2 in this.car.trainset.cars)
						{
							BaseControlsOverrider baseControlsOverrider = car2.SimController?.controlsOverrider;
							if (baseControlsOverrider != null)
							{
								baseControlsOverrider.skipGameLoadBrakeSetup = true;
							}
						}
						return;
					}
				}
				foreach (BrakeSystem car3 in this.car.brakeSystem.brakeset.cars)
				{
					car3.ForceCylinderPressure();
					car3.SetControlReservoirPressure();
					BaseControlsOverrider baseControlsOverrider2 = car3.GetComponent<SimController>()?.controlsOverrider;
					if (baseControlsOverrider2 != null)
					{
						baseControlsOverrider2.skipGameLoadBrakeSetup = true;
					}
				}
				Brake?.Set(1f);
			}
			else if (this.car.brakeSystem.handbrakePosition < 0.75f)
			{
				this.car.brakeSystem.ForceCylinderPressure();
				IndependentBrake?.Set(1f);
			}
			else
			{
				this.car.brakeSystem.ClearCylinderPressure();
			}
		}

		public void SetNeutralState()
		{
			if (neutralStatePropagationInProgress)
			{
				return;
			}
			PortSetter[] array = neutralStateSetters;
			foreach (PortSetter portSetter in array)
			{
				if (simFlow.TryGetPort(portSetter.portId, out var port))
				{
					port.ExternalValueUpdate(portSetter.value);
				}
			}
			PowerOff?.Set(1f);
			Starter?.Set(0f);
			Throttle?.Set(0f);
			Brake?.Set(0f);
			BrakeCutout?.Set(0f);
			IndependentBrake?.Set(0f);
			DynamicBrake?.Set(0f);
			Handbrake?.Set(1f);
			Reverser?.Set(0.5f);
			Sander?.Set(0f);
			neutralStatePropagationInProgress = true;
			Coupler coupledTo = car.frontCoupler.coupledTo;
			if (propagateNeutralStateToFront && coupledTo != null)
			{
				PropagateSetNeutralState(coupledTo);
			}
			Coupler coupledTo2 = car.rearCoupler.coupledTo;
			if (propagateNeutralStateToRear && coupledTo2 != null)
			{
				PropagateSetNeutralState(coupledTo2);
			}
			neutralStatePropagationInProgress = false;
			void PropagateSetNeutralState(Coupler connectedCoupler)
			{
				BaseControlsOverrider baseControlsOverrider = connectedCoupler.train.SimController?.controlsOverrider;
				if (baseControlsOverrider != null)
				{
					if (baseControlsOverrider.propagateNeutralStateToFront && connectedCoupler.isFrontCoupler)
					{
						baseControlsOverrider.SetNeutralState();
					}
					if (baseControlsOverrider.propagateNeutralStateToRear && !connectedCoupler.isFrontCoupler)
					{
						baseControlsOverrider.SetNeutralState();
					}
				}
			}
		}
	}
}
