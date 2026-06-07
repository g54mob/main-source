using System;
using System.Collections.Generic;
using System.ComponentModel;
using DV.Damage;
using DV.MultipleUnit;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class HeadlightsMainController : MonoBehaviour
	{
		public delegate void HeadlightSetupChangedDelegate(HeadlightSetup newSetup, HeadlightSetup oldSetup, bool front);

		public enum HeadlightSetting
		{
			Off = 0,
			HeadlightSetting01 = 1,
			HeadlightSetting02 = 2,
			HeadlightSetting03 = 3,
			HeadlightSetting04 = 4,
			HeadlightSetting05 = 5,
			HeadlightSetting06 = 6,
			HeadlightSetting07 = 7,
			HeadlightSetting08 = 8,
			HeadlightSetting09 = 9,
			HeadlightSetting10 = 10,
			HeadlightSetting11 = 11,
			HeadlightSetting12 = 12,
			HeadlightSetting13 = 13,
			HeadlightSetting14 = 14,
			HeadlightSetting15 = 15,
			HeadlightSetting16 = 16
		}

		[Serializable]
		public struct HeadlightSetup
		{
			public HeadlightSetting setting;

			public HeadlightsSubControllerBase[] subControllers;

			public bool mainOffSetup;

			public HeadlightSetup(HeadlightSetting setting, HeadlightsSubControllerBase[] subControllers, bool mainOffSetup)
			{
				this.setting = setting;
				if (setting != HeadlightSetting.Off && subControllers == null)
				{
					Debug.LogError("'HeadlightSetup' requires a valid reference to a 'HeadlightsSubControllerBase' array if 'HeadlightSetting' is not 'Off'. Assigning 0 length array.");
					subControllers = Array.Empty<HeadlightsSubControllerBase>();
				}
				this.subControllers = subControllers;
				this.mainOffSetup = mainOffSetup;
			}

			public HeadlightSetup(bool offSetup)
			{
				setting = HeadlightSetting.Off;
				subControllers = Array.Empty<HeadlightsSubControllerBase>();
				mainOffSetup = offSetup;
			}
		}

		private const int FORCED_OFF_INDEX = -1;

		private bool headlightsBroken;

		[PortId(PortValueType.CONTROL, false)]
		public string headlightControlFrontId;

		[PortId(PortValueType.CONTROL, false)]
		public string headlightControlRearId;

		[FuseId]
		public string powerFuseId;

		private Port headlightControlFront;

		private Port headlightControlRear;

		[SerializeField]
		private float damagedThresholdPercentage = 0.5f;

		private BodyDamageDetector damageDetector;

		private HashSet<HeadlightsSubControllerBase> allSubControllers = new HashSet<HeadlightsSubControllerBase>();

		[NonSerialized]
		public readonly HashSet<Light> allLightSources = new HashSet<Light>();

		[NonSerialized]
		public readonly HashSet<Renderer> allGlareRenderers = new HashSet<Renderer>();

		private MultipleUnitModule multipleUnitModule;

		private TrainCar car;

		private GameParams gameParams;

		[SerializeField]
		private HeadlightSetup[] headlightSetupsFront;

		[SerializeField]
		private HeadlightSetup[] headlightSetupsRear;

		private HeadlightSetup currentSetupFront;

		private HeadlightSetup currentSetupRear;

		private HeadlightSetup mainOffSetupFront;

		private HeadlightSetup mainOffSetupRear;

		public bool HeadlightsBroken
		{
			get
			{
				return headlightsBroken;
			}
			private set
			{
				if (headlightsBroken != value)
				{
					headlightsBroken = value;
					UpdateHeadlights(RecalculatedIndexFront, front: true, forced: true);
					UpdateHeadlights(RecalculatedIndexRear, front: false, forced: true);
				}
			}
		}

		private int RecalculatedIndexFront
		{
			get
			{
				if ((PowerFuse != null && !PowerFuse.State) || HeadlightsBroken)
				{
					return -1;
				}
				return IndexFromControlValue(front: true);
			}
		}

		private int RecalculatedIndexRear
		{
			get
			{
				if ((PowerFuse != null && !PowerFuse.State) || HeadlightsBroken)
				{
					return -1;
				}
				return IndexFromControlValue(front: false);
			}
		}

		public Fuse PowerFuse { get; private set; }

		public event HeadlightSetupChangedDelegate HeadlightSetupChanged;

		public void Init(TrainCar car, SimulationFlow simFlow)
		{
			this.car = car;
			gameParams = Globals.G.GameParams;
			if (simFlow.TryGetPort(headlightControlFrontId, out headlightControlFront))
			{
				OnControlChanged(headlightControlFront.Value, front: true);
			}
			else
			{
				Debug.LogError("HeadlightsMainController: Port with ID '" + headlightControlFrontId + "' not found. This should not happen.", this);
			}
			if (simFlow.TryGetPort(headlightControlRearId, out headlightControlRear))
			{
				OnControlChanged(headlightControlRear.Value, front: false);
			}
			else
			{
				Debug.LogError("HeadlightsMainController: Port with ID '" + headlightControlRearId + "' not found. This should not happen.", this);
			}
			if (simFlow.TryGetFuse(powerFuseId, out var fuse, canBeNull: true))
			{
				PowerFuse = fuse;
			}
			multipleUnitModule = car.muModule;
			DamageController component = car.GetComponent<DamageController>();
			if (component != null)
			{
				damageDetector = new BodyDamageDetector(damagedThresholdPercentage, component);
				HeadlightsBroken = damageDetector.IsDamaged;
				damageDetector.DamagedStateChanged += OnHeadlightsDamagedStateChanged;
			}
			else
			{
				Debug.LogError("Unexpected state: Couldn't find dmgController in HeadlightsMainController. Headlights can't be damaged");
			}
			CarLightsOptimizer componentInParent = GetComponentInParent<CarLightsOptimizer>();
			componentInParent.Initialize();
			InitSetup(front: true, componentInParent, car);
			InitSetup(front: false, componentInParent, car);
			UpdateHeadlights(-1, front: true);
			UpdateHeadlights(-1, front: false);
			SetupListeners(on: true);
		}

		private void InitSetup(bool front, CarLightsOptimizer carLightsOptimizer, TrainCar car)
		{
			int num = 0;
			HeadlightSetup headlightSetup = new HeadlightSetup(offSetup: true);
			HeadlightSetup headlightSetup2 = new HeadlightSetup(offSetup: true);
			bool flag = false;
			HeadlightSetup[] array = (front ? headlightSetupsFront : headlightSetupsRear);
			for (int i = 0; i < array.Length; i++)
			{
				HeadlightSetup headlightSetup3 = array[i];
				if (headlightSetup3.mainOffSetup)
				{
					headlightSetup = headlightSetup3;
					num++;
				}
				else if (!flag && headlightSetup3.setting == HeadlightSetting.Off)
				{
					headlightSetup2 = headlightSetup3;
					flag = true;
				}
				HeadlightsSubControllerBase[] subControllers = headlightSetup3.subControllers;
				foreach (HeadlightsSubControllerBase headlightsSubControllerBase in subControllers)
				{
					if (headlightsSubControllerBase == null)
					{
						Debug.LogError("HeadlightSetup has a HeadlightsSubControllerBase null reference. This should not happen.", this);
						continue;
					}
					headlightsSubControllerBase.Initialize(carLightsOptimizer, car);
					allSubControllers.Add(headlightsSubControllerBase);
					allLightSources.UnionWith(headlightsSubControllerBase.lightSources);
					Headlight[] headlights = headlightsSubControllerBase.headlights;
					foreach (Headlight headlight in headlights)
					{
						if (headlight.glare != null && headlight.glare.TryGetComponent<Renderer>(out var component))
						{
							allGlareRenderers.Add(component);
						}
					}
				}
			}
			if (num <= 0)
			{
				Debug.LogError("'HeadlightsMainController' Couldn't find main " + (front ? "front" : "rear") + " off setup in any of the configurations. Is this intended? Trying to recover.", this);
				if (flag)
				{
					Debug.LogError("Found a non-main-off " + (front ? "front" : "rear") + " setup with power off.", this);
					headlightSetup = headlightSetup2;
				}
				else
				{
					Debug.LogError("Couldn't find any " + (front ? "front" : "rear") + " setup with power off. Creating a default off state.", this);
					headlightSetup = new HeadlightSetup(offSetup: true);
				}
			}
			else if (num > 1)
			{
				Debug.LogError("'HeadlightsMainController' found more than 1 " + (front ? "front" : "rear") + " off setup. This should not happen. Using the last entry as off setup.", this);
			}
			if (front)
			{
				mainOffSetupFront = headlightSetup;
			}
			else
			{
				mainOffSetupRear = headlightSetup;
			}
		}

		protected void OnDestroy()
		{
			SetupListeners(on: false);
			if (damageDetector != null)
			{
				damageDetector.DamagedStateChanged -= OnHeadlightsDamagedStateChanged;
				damageDetector.OnDestroy();
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (multipleUnitModule != null)
				{
					if (multipleUnitModule.FrontCable != null)
					{
						multipleUnitModule.FrontCable.ConnectionChanged += OnConnectionChanged;
					}
					if (multipleUnitModule.RearCable != null)
					{
						multipleUnitModule.RearCable.ConnectionChanged += OnConnectionChanged;
					}
				}
				if (headlightControlFront != null)
				{
					headlightControlFront.ValueUpdatedInternally += OnHeadlightControlFrontChanged;
				}
				if (headlightControlRear != null)
				{
					headlightControlRear.ValueUpdatedInternally += OnHeadlightControlRearChanged;
				}
				if (PowerFuse != null)
				{
					PowerFuse.StateUpdated += OnFuseChanged;
				}
				if (gameParams != null)
				{
					gameParams.PropertyChanged += OnGameParamsChanged;
				}
				if (car != null)
				{
					Coupler frontCoupler = car.frontCoupler;
					if (frontCoupler != null)
					{
						frontCoupler.HoseConnectionChanged += OnHoseConnectionChanged;
					}
					Coupler rearCoupler = car.rearCoupler;
					if (rearCoupler != null)
					{
						rearCoupler.HoseConnectionChanged += OnHoseConnectionChanged;
					}
				}
				return;
			}
			if (multipleUnitModule != null)
			{
				if (multipleUnitModule.FrontCable != null)
				{
					multipleUnitModule.FrontCable.ConnectionChanged -= OnConnectionChanged;
				}
				if (multipleUnitModule.RearCable != null)
				{
					multipleUnitModule.RearCable.ConnectionChanged -= OnConnectionChanged;
				}
			}
			if (headlightControlFront != null)
			{
				headlightControlFront.ValueUpdatedInternally -= OnHeadlightControlFrontChanged;
			}
			if (headlightControlRear != null)
			{
				headlightControlRear.ValueUpdatedInternally -= OnHeadlightControlRearChanged;
			}
			if (PowerFuse != null)
			{
				PowerFuse.StateUpdated -= OnFuseChanged;
			}
			if (gameParams != null)
			{
				gameParams.PropertyChanged -= OnGameParamsChanged;
			}
			if (car != null)
			{
				Coupler frontCoupler2 = car.frontCoupler;
				if (frontCoupler2 != null)
				{
					frontCoupler2.HoseConnectionChanged -= OnHoseConnectionChanged;
				}
				Coupler rearCoupler2 = car.rearCoupler;
				if (rearCoupler2 != null)
				{
					rearCoupler2.HoseConnectionChanged -= OnHoseConnectionChanged;
				}
			}
		}

		private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (!(e.PropertyName != "AutoHeadlightsOnOffAllowed") || !(e.PropertyName != "AutoHeadlightsDirectionAllowed"))
			{
				if (car.frontCoupler.hoseAndCock.IsHoseConnected)
				{
					UpdateHeadlights(RecalculatedIndexFront, front: true, forced: true);
				}
				if (car.rearCoupler.hoseAndCock.IsHoseConnected)
				{
					UpdateHeadlights(RecalculatedIndexRear, front: false, forced: true);
				}
			}
		}

		private void OnHoseConnectionChanged(bool _, bool isFront, bool __)
		{
			if (gameParams.AutoHeadlightsOnOffAllowed || gameParams.AutoHeadlightsDirectionAllowed)
			{
				if (isFront)
				{
					UpdateHeadlights(RecalculatedIndexFront, front: true, forced: true);
				}
				else
				{
					UpdateHeadlights(RecalculatedIndexRear, front: false, forced: true);
				}
			}
		}

		private void OnConnectionChanged(bool connected, bool playAudio)
		{
			if (!connected)
			{
				UpdateHeadlights(RecalculatedIndexFront, front: true, forced: true);
				UpdateHeadlights(RecalculatedIndexRear, front: false, forced: true);
			}
		}

		private void OnHeadlightsDamagedStateChanged(bool isDamaged)
		{
			HeadlightsBroken = isDamaged;
		}

		private void OnHeadlightControlFrontChanged(float controlValue)
		{
			OnControlChanged(controlValue, front: true);
		}

		private void OnHeadlightControlRearChanged(float controlValue)
		{
			OnControlChanged(controlValue, front: false);
		}

		protected void OnControlChanged(float controlValue, bool front)
		{
			if ((PowerFuse == null || PowerFuse.State) && !HeadlightsBroken)
			{
				UpdateHeadlights(front ? RecalculatedIndexFront : RecalculatedIndexRear, front);
			}
		}

		private int IndexFromControlValue(float controlValue, bool front)
		{
			HeadlightSetup[] array = (front ? headlightSetupsFront : headlightSetupsRear);
			return Mathf.RoundToInt(controlValue * (float)(array.Length - 1));
		}

		private int IndexFromControlValue(bool front)
		{
			return IndexFromControlValue(front ? headlightControlFront.Value : headlightControlRear.Value, front);
		}

		private void OnFuseChanged(bool state)
		{
			UpdateHeadlights(RecalculatedIndexFront, front: true, forced: true);
			UpdateHeadlights(RecalculatedIndexRear, front: false, forced: true);
		}

		private void UpdateHeadlights(int index, bool front, bool forced = false)
		{
			int num;
			HeadlightSetup headlightSetup2;
			HeadlightSetup[] array;
			HeadlightSetup headlightSetup;
			if (front)
			{
				num = Array.IndexOf(headlightSetupsFront, currentSetupFront);
				headlightSetup = currentSetupFront;
				headlightSetup2 = mainOffSetupFront;
				array = headlightSetupsFront;
			}
			else
			{
				num = Array.IndexOf(headlightSetupsRear, currentSetupRear);
				headlightSetup = currentSetupRear;
				headlightSetup2 = mainOffSetupRear;
				array = headlightSetupsRear;
			}
			if (index == num && !forced)
			{
				return;
			}
			HeadlightSetup oldSetup = headlightSetup;
			headlightSetup = ((index >= 0) ? array[index] : headlightSetup2);
			if (front)
			{
				currentSetupFront = headlightSetup;
			}
			else
			{
				currentSetupRear = headlightSetup;
			}
			foreach (HeadlightsSubControllerBase allSubController in allSubControllers)
			{
				if (allSubController.isFront == front)
				{
					allSubController.UpdateHeadlights(HeadlightSetting.Off);
				}
			}
			if (headlightSetup.setting != HeadlightSetting.Off)
			{
				HeadlightsSubControllerBase[] subControllers = headlightSetup.subControllers;
				foreach (HeadlightsSubControllerBase obj in subControllers)
				{
					HeadlightSetup obj2 = (obj.isFront ? currentSetupFront : currentSetupRear);
					HeadlightSetting setting = obj2.setting;
					obj.UpdateHeadlights(setting);
				}
			}
			this.HeadlightSetupChanged?.Invoke(headlightSetup, oldSetup, front);
		}

		public (float front, float rear) GetPortValues()
		{
			float item = headlightControlFront?.Value ?? 0.4f;
			float item2 = headlightControlRear?.Value ?? 0.4f;
			return (front: item, rear: item2);
		}

		public float GetNeutralPortValue(bool front)
		{
			if (!front)
			{
				return 0.4f;
			}
			return 0.4f;
		}

		public int GetSetupCount(bool front)
		{
			if (!front)
			{
				return headlightSetupsRear.Length;
			}
			return headlightSetupsFront.Length;
		}

		public int GetOffIndex(bool front)
		{
			return Mathf.RoundToInt(GetNeutralPortValue(front) * (float)(GetSetupCount(front) - 1));
		}
	}
}
