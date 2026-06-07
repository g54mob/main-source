using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DV.CabControls;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using DV.Simulation.Ports;
using DV.UI.LocoHUD;
using DV.Utils;
using UnityEngine;

namespace DV.HUD
{
	public class InteriorControlsManager : MonoBehaviour
	{
		public enum ControlType
		{
			None = 0,
			Throttle = 1,
			TrainBrake = 2,
			Reverser = 3,
			IndBrake = 4,
			Handbrake = 5,
			Sander = 6,
			Horn = 7,
			HeadlightsFront = 8,
			HeadlightsRear = 9,
			StarterFuse = 10,
			ElectricsFuse = 11,
			TractionMotorFuse = 12,
			StarterControl = 13,
			DynamicBrake = 14,
			CabLight = 15,
			Wipers = 16,
			FuelCutoff = 17,
			ReleaseCyl = 18,
			IndHeadlightsTypeFront = 19,
			IndHeadlights1Front = 20,
			IndHeadlights2Front = 21,
			IndHeadlightsTypeRear = 22,
			IndHeadlights1Rear = 23,
			IndHeadlights2Rear = 24,
			IndWipers1 = 25,
			IndWipers2 = 26,
			IndCabLight = 27,
			IndDashLight = 28,
			GearboxA = 29,
			GearboxB = 30,
			CylCock = 31,
			Injector = 32,
			Firedoor = 33,
			Blower = 34,
			Damper = 35,
			Blowdown = 36,
			CoalDump = 37,
			Dynamo = 38,
			AirPump = 39,
			Lubricator = 40,
			Bell = 41,
			TrainBrakeCutout = 42
		}

		public struct ControlReference
		{
			public ControlImplBase controlImplBase;

			public IScrollable scrollable;

			public OverridableBaseControl overridableBaseControl;
		}

		public bool electricsFuseAffectsIndicators = true;

		public List<ControlType> reverseDirectionList = new List<ControlType>();

		private HashSet<ControlType> reverseHashSet = new HashSet<ControlType>();

		private Dictionary<ControlType, ControlReference> controls = new Dictionary<ControlType, ControlReference>();

		[NonSerialized]
		public LocoIndicatorReader indicatorReader;

		[NonSerialized]
		public LocoLampReader lampReader;

		[NonSerialized]
		public LocoFuseBoxReference locoFuseBoxReference;

		[NonSerialized]
		public ScrollableTimerUtil scrollableTimerUtil;

		public bool Initialized { get; private set; }

		public TrainCar Car { get; private set; }

		public event Action<InteriorControlsManager> OnInitialized;

		private void Awake()
		{
			Car = TrainCar.Resolve(base.gameObject);
			scrollableTimerUtil = base.gameObject.AddComponent<ScrollableTimerUtil>();
			lampReader = GetComponent<LocoLampReader>();
			indicatorReader = GetComponent<LocoIndicatorReader>();
			locoFuseBoxReference = GetComponent<LocoFuseBoxReference>();
		}

		private IEnumerator Start()
		{
			foreach (ControlType reverseDirection in reverseDirectionList)
			{
				reverseHashSet.Add(reverseDirection);
			}
			SetBaseControlsReferences();
			SetHandbrakeAndReleaseCylReferences();
			do
			{
				yield return null;
			}
			while ((bool)Car.carLivery.externalInteractablesPrefab && !Car.loadedExternalInteractables);
			SetFuseBoxReferences(locoFuseBoxReference);
			SetFuseBoxReferences(Car.loadedExternalInteractables?.GetComponent<LocoFuseBoxReference>());
			SetupControlReader(GetComponent<LocoControlsReader>());
			SetupControlReader(Car.loadedExternalInteractables?.GetComponent<LocoControlsReader>());
			SubToHUD_Internal();
			Initialized = true;
			this.OnInitialized?.Invoke(this);
		}

		public void SubToHUD()
		{
			if (Initialized)
			{
				SubToHUD_Internal();
			}
		}

		private void SubToHUD_Internal()
		{
			if (SingletonBehaviour<HUDManager>.Instance.locoHUDVisible)
			{
				LocoHUDProvider component = SingletonBehaviour<HUDInterfacer>.Instance.GetComponent<LocoHUDProvider>();
				component.Sub(indicatorReader);
				component.Sub(lampReader);
				component.Sub(GetComponent<LocoControlsReader>());
				component.Sub(this);
				GameObject loadedExternalInteractables = Car.loadedExternalInteractables;
				if ((bool)loadedExternalInteractables)
				{
					component.Sub(loadedExternalInteractables.GetComponent<LocoIndicatorReader>());
					component.Sub(loadedExternalInteractables.GetComponent<LocoLampReader>());
					component.Sub(loadedExternalInteractables.GetComponent<LocoControlsReader>());
				}
			}
		}

		public void UnsubFromHUD()
		{
			if (Initialized)
			{
				UnsubFromHUD_Internal();
			}
		}

		private void UnsubFromHUD_Internal()
		{
			LocoHUDProvider component = SingletonBehaviour<HUDInterfacer>.Instance.GetComponent<LocoHUDProvider>();
			component.Unsub(indicatorReader);
			component.Unsub(lampReader);
			component.Unsub(GetComponent<LocoControlsReader>());
			component.Unsub(this);
			GameObject loadedExternalInteractables = Car.loadedExternalInteractables;
			if ((bool)loadedExternalInteractables)
			{
				component.Unsub(loadedExternalInteractables.GetComponent<LocoIndicatorReader>());
				component.Unsub(loadedExternalInteractables.GetComponent<LocoLampReader>());
				component.Unsub(loadedExternalInteractables.GetComponent<LocoControlsReader>());
			}
		}

		public void RemoveControl(ControlType type)
		{
			controls.Remove(type);
		}

		public void SetupControlReader(LocoControlsReader lcr)
		{
			if (!lcr)
			{
				return;
			}
			FieldInfo[] fields = typeof(LocoControlsReader).GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!(fieldInfo.FieldType != typeof(GameObject)))
				{
					if (Enum.TryParse<ControlType>(fieldInfo.Name, ignoreCase: true, out var result))
					{
						GameObject reference = (GameObject)fieldInfo.GetValue(lcr);
						SetupControl(reference, result);
					}
					else
					{
						Debug.LogError("Couldn't find ControlType from " + fieldInfo.Name);
					}
				}
			}
		}

		public void SetupControl(GameObject reference, ControlType type)
		{
			if ((bool)reference)
			{
				controls[type] = new ControlReference
				{
					scrollable = reference.GetComponent<IScrollable>(),
					controlImplBase = reference.GetComponent<ControlImplBase>()
				};
			}
		}

		public bool MoveScrollable(ControlType type, int notches)
		{
			if (controls.TryGetValue(type, out var value))
			{
				if (value.scrollable == null)
				{
					return false;
				}
				if (reverseHashSet.Contains(type))
				{
					notches = -notches;
				}
				scrollableTimerUtil.MoveScrollable(value.scrollable, notches);
				return true;
			}
			return false;
		}

		public (string value, string unit) GetCurrentPositionName(ControlType type)
		{
			if (!controls.TryGetValue(type, out var value))
			{
				return (value: "", unit: "");
			}
			return value.controlImplBase.GetCurrentPositionName();
		}

		public bool TryGetControl(ControlType type, out ControlReference reference)
		{
			reference = default(ControlReference);
			reference.controlImplBase = null;
			if (!controls.TryGetValue(type, out var value))
			{
				return false;
			}
			reference = value;
			return true;
		}

		public void TryUnhandControl(ControlType type)
		{
			if (TryGetControl(type, out var reference) && reference.controlImplBase.IsGrabbed())
			{
				reference.controlImplBase.ForceEndInteraction();
			}
		}

		public IScrollable GetScrollable(ControlType type)
		{
			if (!controls.TryGetValue(type, out var value))
			{
				return null;
			}
			return value.scrollable;
		}

		public bool IsControlScrolledRecently(ControlType type)
		{
			if (scrollableTimerUtil == null)
			{
				return false;
			}
			IScrollable scrollable = GetScrollable(type);
			if (scrollable == null)
			{
				return false;
			}
			return scrollableTimerUtil.timerDictionary.ContainsKey(scrollable);
		}

		private void SetHandbrakeAndReleaseCylReferences()
		{
			HandbrakeFeedersController handbrakeFeedersController = base.gameObject.GetComponent<HandbrakeFeedersController>();
			if (handbrakeFeedersController == null)
			{
				handbrakeFeedersController = Car.loadedExternalInteractables?.GetComponent<HandbrakeFeedersController>();
			}
			if (handbrakeFeedersController != null && handbrakeFeedersController.entries.Length != 0)
			{
				GameObject gameObject = handbrakeFeedersController.entries[0].gameObject;
				controls[ControlType.Handbrake] = new ControlReference
				{
					scrollable = gameObject.GetComponent<IScrollable>(),
					controlImplBase = gameObject.GetComponent<ControlImplBase>()
				};
			}
			if (Car.brakeSystem.hasTrainBrake || Car.brakeSystem.hasIndependentBrake)
			{
				BrakeCylinderReleaseButtonFeeder brakeCylinderReleaseButtonFeeder = base.gameObject.GetComponentInChildren<BrakeCylinderReleaseButtonFeeder>();
				if (brakeCylinderReleaseButtonFeeder == null)
				{
					brakeCylinderReleaseButtonFeeder = Car.loadedExternalInteractables?.GetComponentInChildren<BrakeCylinderReleaseButtonFeeder>();
				}
				if (brakeCylinderReleaseButtonFeeder != null)
				{
					controls[ControlType.ReleaseCyl] = new ControlReference
					{
						scrollable = brakeCylinderReleaseButtonFeeder.GetComponent<IScrollable>(),
						controlImplBase = brakeCylinderReleaseButtonFeeder.GetComponent<ControlImplBase>()
					};
				}
			}
		}

		private void SetFuseBoxReferences(LocoFuseBoxReference fuseBoxReferences)
		{
			if (!(fuseBoxReferences == null))
			{
				DoFuse(fuseBoxReferences.starterFuse, ControlType.StarterFuse);
				DoFuse(fuseBoxReferences.electricsFuse, ControlType.ElectricsFuse);
				DoFuse(fuseBoxReferences.tractionMotorFuse, ControlType.TractionMotorFuse);
			}
			void DoFuse(GameObject fuse, ControlType type)
			{
				if ((bool)fuse)
				{
					if (!fuse.TryGetComponent<ControlImplBase>(out var component))
					{
						Debug.LogError("Fuse " + fuse.name + " does not have a ControlImplBase! Did you assign the wrong gameObject?", fuse);
					}
					else
					{
						controls[type] = new ControlReference
						{
							controlImplBase = component,
							scrollable = fuse.GetComponent<IScrollable>()
						};
					}
				}
			}
		}

		private void SetBaseControlsReferences()
		{
			BaseControlsOverrider bco = Car.SimController.controlsOverrider;
			InteractablePortFeedersController component = GetComponent<InteractablePortFeedersController>();
			if (component != null)
			{
				InitControls(component);
			}
			if (Car.AreExternalInteractablesLoaded)
			{
				InteractablePortFeedersController component2 = Car.loadedExternalInteractables.GetComponent<InteractablePortFeedersController>();
				if (component2 != null)
				{
					InitControls(component2);
				}
			}
			void InitControls(InteractablePortFeedersController ctrl)
			{
				InteractablePortFeeder[] entries = ctrl.entries;
				foreach (InteractablePortFeeder feeder in entries)
				{
					GameObject obj = feeder.gameObject;
					IScrollable component3 = obj.GetComponent<IScrollable>();
					ControlImplBase component4 = obj.GetComponent<ControlImplBase>();
					ControlType type;
					OverridableBaseControl overridableBaseControl;
					if ((component3 != null || VRManager.IsVREnabled()) && component4 != null)
					{
						type = ControlType.None;
						overridableBaseControl = null;
						CheckPort(bco.Throttle, ControlType.Throttle);
						CheckPort(bco.Brake, ControlType.TrainBrake);
						CheckPort(bco.IndependentBrake, ControlType.IndBrake);
						CheckPort(bco.DynamicBrake, ControlType.DynamicBrake);
						CheckPort(bco.Reverser, ControlType.Reverser);
						CheckPort(bco.Sander, ControlType.Sander);
						CheckPort(bco.Horn, ControlType.Horn);
						CheckPort(bco.HeadlightsFront, ControlType.HeadlightsFront);
						CheckPort(bco.HeadlightsRear, ControlType.HeadlightsRear);
						CheckPort(bco.BrakeCutout, ControlType.TrainBrakeCutout);
						CheckPort(bco.Starter, ControlType.StarterControl);
						CheckPort(bco.Dynamo, ControlType.Dynamo);
						CheckPort(bco.AirPump, ControlType.AirPump);
						CheckPort(bco.CabLight, ControlType.CabLight);
						CheckPort(bco.IndCabLight, ControlType.IndCabLight);
						CheckPort(bco.Wipers, ControlType.Wipers);
						if (type != ControlType.None)
						{
							controls[type] = new ControlReference
							{
								controlImplBase = component4,
								scrollable = component3,
								overridableBaseControl = overridableBaseControl
							};
						}
					}
					void CheckPort(OverridableBaseControl obc, ControlType ct)
					{
						if (!(feeder.portId != obc?.portId))
						{
							type = ct;
							overridableBaseControl = obc;
						}
					}
				}
			}
		}
	}
}
