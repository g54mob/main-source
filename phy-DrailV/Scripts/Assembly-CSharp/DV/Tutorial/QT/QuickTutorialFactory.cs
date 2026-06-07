using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DV.CabControls;
using DV.CabControls.Spec;
using DV.Common;
using DV.Customization.Gadgets;
using DV.HUD;
using DV.Indicators;
using DV.InventorySystem;
using DV.Localization;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using DV.Simulation.Fuses;
using DV.Simulation.Ports;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.UI;
using DV.UI.Inventory;
using DV.UIFramework;
using DV.Utils;
using LocoSim.Resources;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class QuickTutorialFactory : MonoBehaviour
	{
		private class TrainTutorialConstructor
		{
			private const string CONTROL_LOC_PREFIX = "car/tut/";

			public TrainCar Loco { get; private set; }

			public BaseControlsOverrider Overrider { get; private set; }

			public InteriorControlsManager Controls { get; private set; }

			public LocoIndicatorReader Indicators { get; private set; }

			public LocoLampReader Lamps { get; private set; }

			public QuickTutorialPhase Phase { get; private set; }

			public QuickTutorial Tutorial { get; private set; }

			public TrainTutorialConstructor(TrainCar loco, bool userControlAllowed)
			{
				Tutorial = new QuickTutorial(userControlAllowed);
				Phase = new QuickTutorialPhase();
				Tutorial.Add(Phase);
				Loco = loco;
				if (loco != null)
				{
					Overrider = loco.GetComponentInChildren<BaseControlsOverrider>(includeInactive: true);
					Controls = loco.interior.GetComponentInChildren<InteriorControlsManager>();
					Indicators = loco.interior.GetComponentInChildren<LocoIndicatorReader>();
					Lamps = loco.interior.GetComponentInChildren<LocoLampReader>();
				}
			}

			public static string UnderscoreCamelCase(string input)
			{
				return Regex.Replace(input, "(?<=[a-z])([A-Z])", "_$1", RegexOptions.Compiled).TrimStart('_');
			}

			public QuickTutorialPhase BeginNewPhase()
			{
				if (Phase != null && Phase.IsEmpty)
				{
					return Phase;
				}
				Phase = new QuickTutorialPhase();
				Tutorial.Add(Phase);
				return Phase;
			}

			public ControlImplBase GetControl(InteriorControlsManager.ControlType controlType)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					return reference.controlImplBase;
				}
				return null;
			}

			private static ControlIconQuickTutorialMessage GetDescriptionFor(InteriorControlsManager.ControlType type, QTSemantic semantic, TrainCar loco, InteriorControlsManager controls, bool isSteamLoco = false)
			{
				if (!controls.TryGetControl(type, out var reference))
				{
					reference = default(InteriorControlsManager.ControlReference);
				}
				(string, string) tuple = ("", "");
				if (isSteamLoco)
				{
					switch (type)
					{
					case InteriorControlsManager.ControlType.Reverser:
						tuple = (LocalizationAPI.L("car/tut/cutoff"), LocalizationAPI.L("tutorial/control/cutoff"));
						break;
					case InteriorControlsManager.ControlType.Throttle:
						tuple = (LocalizationAPI.L("car/tut/regulator"), LocalizationAPI.L("tutorial/control/regulator"));
						break;
					case InteriorControlsManager.ControlType.Horn:
						tuple = (LocalizationAPI.L("car/tut/whistle"), LocalizationAPI.L("tutorial/control/horn"));
						break;
					case InteriorControlsManager.ControlType.IndCabLight:
						tuple = (LocalizationAPI.L("car/tut/gearlight"), LocalizationAPI.L("tutorial/control/gear_light"));
						break;
					default:
						tuple = (LocalizationAPI.L("car/tut/" + type.ToString().ToLower()), LocalizationAPI.L("tutorial/control/" + type.ToString().ToLower()));
						break;
					}
				}
				else
				{
					if (type == InteriorControlsManager.ControlType.HeadlightsFront && controls.TryGetControl(InteriorControlsManager.ControlType.HeadlightsFront, out var reference2) && !controls.TryGetControl(InteriorControlsManager.ControlType.HeadlightsRear, out reference2))
					{
						tuple.Item1 = LocalizationAPI.L("car/tut/headlights");
					}
					else
					{
						tuple.Item1 = LocalizationAPI.L("car/tut/" + type.ToString().ToLower());
					}
					switch (type)
					{
					case InteriorControlsManager.ControlType.IndHeadlightsTypeFront:
					case InteriorControlsManager.ControlType.IndHeadlightsTypeRear:
						tuple.Item2 = LocalizationAPI.L("tutorial/control/indheadlightstype");
						break;
					case InteriorControlsManager.ControlType.IndHeadlights1Front:
					case InteriorControlsManager.ControlType.IndHeadlights1Rear:
						tuple.Item2 = LocalizationAPI.L("tutorial/control/indheadlights1");
						break;
					case InteriorControlsManager.ControlType.IndHeadlights2Front:
					case InteriorControlsManager.ControlType.IndHeadlights2Rear:
						tuple.Item2 = LocalizationAPI.L("tutorial/control/indheadlights2");
						break;
					default:
						tuple.Item2 = LocalizationAPI.L("tutorial/control/" + type.ToString().ToLower());
						break;
					}
				}
				ControlIconQuickTutorialMessage controlIconQuickTutorialMessage = new ControlIconQuickTutorialMessage(tuple.Item1, tuple.Item2).WithSprite(loco, reference.controlImplBase, semantic);
				if (object.Equals(InteriorControlsManager.ControlType.Handbrake, type))
				{
					controlIconQuickTutorialMessage.spriteIndex = 6;
				}
				return controlIconQuickTutorialMessage;
			}

			public void AddLocoReset()
			{
				Phase.Add(new LocoResetStep(Loco));
			}

			public void AddPrompt(string message, bool pause)
			{
				Phase.Add(new PromptStep(message, pause));
			}

			public void AddControl(InteriorControlsManager.ControlType controlType, float targetValueMin, float targetValueMax, QTSemantic semantic, bool shouldRecheck = true)
			{
				AddControl(controlType, targetValueMin, targetValueMax, GetDescriptionFor(controlType, semantic, Loco, Controls), semantic, shouldRecheck);
			}

			public void AddControl(InteriorControlsManager.ControlType controlType, float targetValueMin, float targetValueMax, string controlName, string controlTypeName, QTSemantic semantic, bool shouldRecheck = true)
			{
				if (!Controls.TryGetControl(controlType, out var reference))
				{
					reference = default(InteriorControlsManager.ControlReference);
				}
				AddControl(controlType, targetValueMin, targetValueMax, new ControlIconQuickTutorialMessage(controlName, controlTypeName).WithSprite(Loco, reference.controlImplBase, semantic), semantic, shouldRecheck);
			}

			public void AddControl(InteriorControlsManager.ControlType controlType, float targetValueMin, float targetValueMax, ControlIconQuickTutorialMessage message, QTSemantic semantic, bool shouldRecheck = true)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					Phase.Add(new ControlImplBaseStep(targetValueMin, targetValueMax, controlType, Loco, message, semantic, reference.controlImplBase.transform, Vector3.zero, shouldRecheck));
				}
			}

			public void AddControl(ControlImplBase control, float targetValueMin, float targetValueMax, string controlName, string controlDescription, QTSemantic semantic, bool shouldRecheck = true)
			{
				if (control != null)
				{
					ControlIconQuickTutorialMessage message = new ControlIconQuickTutorialMessage(controlName, controlDescription).WithSprite(Loco, control, semantic);
					Phase.Add(new ControlImplBaseStep(targetValueMin, targetValueMax, control, Loco, message, semantic, control.transform, Vector3.zero, shouldRecheck));
				}
			}

			public void AddManualGearShifting(InteriorControlsManager.ControlType controlType, bool shouldBeInGear, bool shouldRecheck = true)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					QTSemantic semantic = (shouldBeInGear ? QTSemantic.SetToNotch1 : QTSemantic.SetToNeutral);
					Phase.Add(new ManualGearShiftStep(Loco, shouldBeInGear, controlType, GetDescriptionFor(controlType, semantic, Loco, Controls), semantic, reference.controlImplBase.transform));
				}
			}

			public void AddFuse(InteriorControlsManager.ControlType controlType, QTSemantic semantic, bool shouldRecheck = true)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					string fuseId = reference.controlImplBase.GetComponent<InteractableFuseFeeder>().fuseId;
					Phase.Add(new LocoFuseStep(fuseId, targetValue: true, Loco, controlType, GetDescriptionFor(controlType, semantic, Loco, Controls), semantic, reference.controlImplBase.transform, Vector3.zero, shouldRecheck));
				}
			}

			public void AddPort(InteriorControlsManager.ControlType controlType, string portId, float targetValueMin, float targetValueMax, QTSemantic semantic, bool shouldRecheck = true)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					Phase.Add(new LocoPortStep(portId, targetValueMin, targetValueMax, Loco, controlType, GetDescriptionFor(controlType, semantic, Loco, Controls), semantic, reference.controlImplBase.transform, Vector3.zero, shouldRecheck));
				}
			}

			public void AddEngineState(InteriorControlsManager.ControlType controlType, bool targetValue, QTSemantic semantic, bool shouldRecheck = true)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					Phase.Add(new LocoEngineStep(Loco, controlType, Overrider, targetValue, GetDescriptionFor(controlType, semantic, Loco, Controls), semantic, reference.controlImplBase.transform, Vector3.zero, shouldRecheck));
				}
			}

			public void AddAutomaticLubricatorStep(Indicator transmissionOilIndicator, bool shouldRecheck = true)
			{
				InteriorControlsManager.ControlType controlType = InteriorControlsManager.ControlType.Lubricator;
				if (Controls.TryGetControl(controlType, out var reference) && transmissionOilIndicator != null)
				{
					Phase.Add(new AutomaticLubricatorStep(Loco, controlType, transmissionOilIndicator, GetDescriptionFor(controlType, QTSemantic.Engage, Loco, Controls, isSteamLoco: true), QTSemantic.Engage, reference.controlImplBase.transform, Vector3.zero, shouldRecheck));
				}
			}

			public void AddLookAndAcknowledge(InteriorControlsManager.ControlType controlType, string controlName, string controlTypeName, bool isSteamLoco = false)
			{
				AddLookAndAcknowledge(controlType, new ControlIconQuickTutorialMessage(controlName, controlTypeName, 2), isSteamLoco);
			}

			public void AddLookAndAcknowledge(Behaviour component, string controlName, string controlType)
			{
				if (!(component == null))
				{
					AddLookAndAcknowledge(component.transform, new ControlIconQuickTutorialMessage(controlName, controlType, 2));
				}
			}

			public void AddLookAndAcknowledge(Transform attentionPoint, string controlName, string controlType)
			{
				AddLookAndAcknowledge(attentionPoint, new ControlIconQuickTutorialMessage(controlName, controlType, 2));
			}

			public void AddLookAndAcknowledge(InteriorControlsManager.ControlType controlType, ControlIconQuickTutorialMessage message = null, bool isSteamLoco = false)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					if (message == null)
					{
						message = GetDescriptionFor(controlType, QTSemantic.Look, Loco, Controls, isSteamLoco);
					}
					message.spriteIndex = 2;
					Phase.Add(new LookStep(message, reference.controlImplBase.transform, Vector3.zero));
				}
			}

			public void AddLookAndAcknowledge(Transform attentionPoint, ControlIconQuickTutorialMessage message)
			{
				if ((bool)attentionPoint)
				{
					Phase.Add(new LookStep(message, attentionPoint, Vector3.zero));
				}
			}

			public void AddVirtualHandbrakeLookAndAcknowledge(TrainCar tender, ControlIconQuickTutorialMessage message = null, bool isSteamLoco = false)
			{
				if (tender == null)
				{
					AddLookAndAcknowledge(InteriorControlsManager.ControlType.Handbrake, message, isSteamLoco);
					return;
				}
				HandbrakeFeedersController component = tender.loadedExternalInteractables.GetComponent<HandbrakeFeedersController>();
				if (component == null || component.entries.Length == 0)
				{
					return;
				}
				ControlImplBase control = component.entries[0].control;
				if (!(control == null))
				{
					if (message == null)
					{
						message = GetDescriptionFor(InteriorControlsManager.ControlType.Handbrake, QTSemantic.Look, Loco, Controls);
					}
					message.spriteIndex = 2;
					AddLookAndAcknowledge(control.transform, message);
				}
			}

			public bool AddOverridableControl(InteriorControlsManager.ControlType controlType, float targetValueMin, float targetValueMax, QTSemantic semantic, bool shouldRecheck = true, float timeout = 0f, bool isSteamLoco = false)
			{
				if (Controls.TryGetControl(controlType, out var reference))
				{
					OverridableBaseControl control = Overrider.GetControl(controlType);
					if (control != null)
					{
						Phase.Add(new LocoControlOverrideStep(targetValueMin, targetValueMax, Loco, controlType, control, GetDescriptionFor(controlType, semantic, Loco, Controls, isSteamLoco), semantic, reference.controlImplBase.transform, Vector3.zero, shouldRecheck, timeout));
						return true;
					}
				}
				return false;
			}

			public void AddVirtualHandbrakeControl(TrainCar tender, float targetValueMin, float targetValueMax, QTSemantic semantic, bool shouldRecheck = true, float timeout = 0f)
			{
				if (tender == null)
				{
					AddControl(InteriorControlsManager.ControlType.Handbrake, targetValueMin, targetValueMax, semantic, shouldRecheck);
					return;
				}
				HandbrakeFeedersController component = tender.loadedExternalInteractables.GetComponent<HandbrakeFeedersController>();
				if (!(component == null) && component.entries.Length != 0)
				{
					ControlImplBase control = component.entries[0].control;
					if (!(control == null))
					{
						Phase.Add(new SetVirtualHandbrakeStep(Loco, tender.brakeSystem, targetValueMin, targetValueMax, GetDescriptionFor(InteriorControlsManager.ControlType.Handbrake, semantic, Loco, Controls, isSteamLoco: true), semantic, control.transform, Vector3.zero));
					}
				}
			}

			public void AddMonitorBrakePressure<T>(string messageA, string messageB, float minValue, float maxValue, bool manualDismiss) where T : AIndicatorBrakePressureReader
			{
				AIndicatorBrakePressureReader componentInChildren = Loco.interior.GetComponentInChildren<T>();
				if ((bool)componentInChildren)
				{
					Phase.Add(new MonitorBrakePressureStep(Loco, new ControlIconQuickTutorialMessage(messageA, messageB, 2), componentInChildren, minValue, maxValue, manualDismiss, Vector3.zero));
				}
			}

			public void AddMonitorIndicator(Indicator indicator, string messageA, string messageB, float minValue, float maxValue, bool manualDismiss, float minTime = 0f, Transform attentionPointOverride = null, bool strictDismiss = false)
			{
				if ((bool)indicator)
				{
					Phase.Add(new MonitorIndicatorStep(Loco, new ControlIconQuickTutorialMessage(messageA, messageB, 2), indicator, minValue, maxValue, manualDismiss, Vector3.zero, minTime, attentionPointOverride, strictDismiss));
				}
			}

			public void AddMonitorIndicatorNoMessage(Indicator indicator, float minValue, float maxValue)
			{
				if ((bool)indicator)
				{
					Phase.Add(new MonitorIndicatorStep(Loco, null, indicator, minValue, maxValue, manualDismiss: false, Vector3.zero));
				}
			}

			public void AddPutCoalIntoFireboxStep(FireboxSimController fireboxSimController, float targetLevel, bool requireAtLeastOneShovel, string message, Transform attentionPoint = null, Vector3 offset = default(Vector3))
			{
				if (!(fireboxSimController == null))
				{
					Phase.Add(new PutCoalIntoFireboxStep(fireboxSimController, targetLevel, requireAtLeastOneShovel, message, attentionPoint, offset));
				}
			}

			public void AddTakeCoalStep(TrainCar carWithCoal, string message, Vector3 offset = default(Vector3), bool shouldRecheck = true)
			{
				if (!(carWithCoal == null))
				{
					ShovelCoalPile shovelCoalPile = null;
					if (carWithCoal.loadedInterior != null)
					{
						shovelCoalPile = carWithCoal.loadedInterior.GetComponentInChildren<ShovelCoalPile>();
					}
					if (shovelCoalPile == null && carWithCoal.loadedExternalInteractables != null)
					{
						shovelCoalPile = carWithCoal.loadedExternalInteractables.GetComponentInChildren<ShovelCoalPile>();
					}
					if (!(shovelCoalPile == null))
					{
						Phase.Add(new TakeCoalStep(message, shovelCoalPile, offset, shouldRecheck));
					}
				}
			}

			public void AddRefillOilingPointStep(Indicator oilingPointIndicator, float targetLevel, Vector3 offset = default(Vector3))
			{
				if (!(oilingPointIndicator == null))
				{
					VerbSimpleQuickTutorialMessage message = new VerbSimpleQuickTutorialMessage(VRManager.IsVREnabled() ? LocalizationAPI.L("tutorial/loco/refill_oiling_point_vr") : LocalizationAPI.L("tutorial/loco/refill_oiling_point_nonvr"));
					Phase.Add(new RefillOilingPointStep(oilingPointIndicator, targetLevel, message, offset));
				}
			}
		}

		public enum MountingMode
		{
			Drill = 0,
			Tape = 1,
			Either = 2
		}

		private const float MIN_MONITOR_WAIT_TIME = 3f;

		private static readonly ItemBase[] commsRadioCache = new ItemBase[1];

		private static Collider[] colCache = new Collider[32];

		public static QuickTutorial DieselEngineCareerTutorial(TrainCar loco)
		{
			if (loco == null)
			{
				Debug.LogWarning("DieselEngineCareerTutorial called with null loco, thus returning null QuickTutorial.");
				return null;
			}
			TrainTutorialConstructor c = new TrainTutorialConstructor(loco, userControlAllowed: true);
			c.Tutorial.AddStartingCheck(new PlayerInLocoCondition("tutorial/cond/in_locomotive"));
			c.Tutorial.AddStartingCheck(new CarOnRailsCondition("tutorial/cond/loco_railed_start"));
			c.Tutorial.AddStartingCheck(new CarDamageCondition(0f, 0.5f, "tutorial/cond/loco_damaged"));
			c.Tutorial.AddStartingCheck(new CarSpeedCondition(0f, 0.1f, absolute: true, "tutorial/cond/loco_stationary"));
			c.Tutorial.AddStartingCheck(new CarGradeCondition(0f, 1f, "tutorial/cond/loco_grade"));
			if (loco == null)
			{
				c.Tutorial.Add(new QuickTutorialPhase());
				return c.Tutorial;
			}
			c.Tutorial.Add(new KeepTrainLODService());
			c.Tutorial.Add(new CarRangeWarningService(15f));
			c.Tutorial.AddGlobalCheck(new CarEnabledCondition());
			c.Tutorial.AddGlobalCheck(new CarOnRailsCondition("tutorial/fail/derailed"));
			c.BeginNewPhase();
			c.AddLocoReset();
			DieselBasicPrereqs(includeHandbrakeApplied: true, includeStartedEngine: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndDashLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.CabLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndCabLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Wipers);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndWipers1);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndWipers2);
			c.AddControl(InteriorControlsManager.ControlType.HeadlightsFront, 0.59f, 1f, QTSemantic.EngageCW, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlightsTypeFront);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlightsTypeFront, 0f, 0f, QTSemantic.Disengage);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlights1Front, 1f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlights2Front);
			c.AddControl(InteriorControlsManager.ControlType.HeadlightsRear, 0f, 0.3f, QTSemantic.EngageCCW, shouldRecheck: false);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlightsTypeRear, 1f, 1f, QTSemantic.Engage);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlights1Rear, 1f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlights2Rear);
			c.BeginNewPhase();
			DieselBasicPrereqs(includeHandbrakeApplied: true, includeStartedEngine: true);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 0.49f, 0.51f, QTSemantic.SetToNeutral);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.DynamicBrake, 0f, 0f, QTSemantic.Disengage);
			c.BeginNewPhase();
			DieselBasicPrereqs(includeHandbrakeApplied: true, includeStartedEngine: true);
			c.AddMonitorIndicator(c.Indicators?.mainReservoir, LocalizationAPI.L("car/tut/mainres") + "\n" + LocalizationAPI.L("tutorial/monitor_until", "2 bar"), LocalizationAPI.L("tutorial/loco/int_main_res"), 3f, float.PositiveInfinity, manualDismiss: true, 3f);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0.05f, 0.3f, QTSemantic.GentlyEngage, shouldRecheck: false);
			c.AddLookAndAcknowledge(c.Indicators?.engineRpm, LocalizationAPI.L("car/tut/rpm"), LocalizationAPI.L("tutorial/loco/ind_rpm"));
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage);
			c.AddLookAndAcknowledge(c.Indicators?.tmTemp, LocalizationAPI.L("car/tut/tmtemp"), LocalizationAPI.L("tutorial/loco/ind_tm_temp"));
			c.BeginNewPhase();
			DieselBasicPrereqs(includeHandbrakeApplied: false, includeStartedEngine: true);
			c.AddControl(InteriorControlsManager.ControlType.Handbrake, 1f, 1f, QTSemantic.FullyEngage, shouldRecheck: false);
			c.AddOverridableControl(InteriorControlsManager.ControlType.IndBrake, 0.3f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(c.Indicators.brakeCylinder, LocalizationAPI.L("car/tut/brakecyl"), LocalizationAPI.L("tutorial/loco/brake_red_needle"));
			c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrake, 0f, 0f, QTSemantic.Disengage);
			c.AddLookAndAcknowledge(c.Indicators.brakePipe, LocalizationAPI.L("car/tut/brakepipe"), LocalizationAPI.L("tutorial/loco/brake_black_needle"));
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 1f, 1f, QTSemantic.GoForward);
			c.AddControl(InteriorControlsManager.ControlType.Handbrake, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.IndBrake, 0f, 0f, QTSemantic.Disengage);
			c.AddManualGearShifting(InteriorControlsManager.ControlType.GearboxA, shouldBeInGear: true);
			c.AddManualGearShifting(InteriorControlsManager.ControlType.GearboxB, shouldBeInGear: true);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Sander);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0.05f, 0.3f, QTSemantic.GentlyEngage, shouldRecheck: false, 3f);
			return c.Tutorial;
			void DieselBasicPrereqs(bool includeHandbrakeApplied, bool includeStartedEngine)
			{
				if (includeHandbrakeApplied)
				{
					c.AddControl(InteriorControlsManager.ControlType.Handbrake, 1f, 1f, QTSemantic.FullyEngage);
				}
				c.AddFuse(InteriorControlsManager.ControlType.ElectricsFuse, QTSemantic.Engage);
				c.AddFuse(InteriorControlsManager.ControlType.StarterFuse, QTSemantic.Engage);
				c.AddFuse(InteriorControlsManager.ControlType.TractionMotorFuse, QTSemantic.Engage);
				if (includeStartedEngine)
				{
					c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrakeCutout, 0.9f, 1f, QTSemantic.Open);
					c.AddEngineState(InteriorControlsManager.ControlType.StarterControl, targetValue: true, QTSemantic.EngageCW);
				}
			}
		}

		private static QuickTutorial DieselEngineTutorial(TrainTutorialConstructor c, TrainCar loco)
		{
			c.Tutorial.AddStartingCheck(new PlayerInLocoCondition("tutorial/cond/in_locomotive"));
			c.Tutorial.AddStartingCheck(new CarOnRailsCondition("tutorial/cond/loco_railed_start"));
			c.Tutorial.AddStartingCheck(new CarDamageCondition(0f, 0.5f, "tutorial/cond/loco_damaged"));
			c.Tutorial.AddStartingCheck(new LocoFuelCondition(0.05f, 1f, "tutorial/cond/requires_fuel", "tutorial/cond/requires_coal_and_water", "tutorial/cond/requires_power"));
			c.Tutorial.AddStartingCheck(new CarSpeedCondition(0f, 0.1f, absolute: true, "tutorial/cond/loco_stationary"));
			c.Tutorial.AddStartingCheck(new CarGradeCondition(0f, 1f, "tutorial/cond/loco_grade"));
			if (loco == null)
			{
				c.Tutorial.Add(new QuickTutorialPhase());
				return c.Tutorial;
			}
			ResourceContainerController resourceContainerController = loco.SimController?.resourceContainerController;
			c.Tutorial.Add(new KeepTrainLODService());
			c.Tutorial.Add(new CarRangeWarningService(15f));
			c.Tutorial.AddGlobalCheck(new CarEnabledCondition());
			c.Tutorial.AddGlobalCheck(new CarDistanceCondition(30f));
			c.Tutorial.AddGlobalCheck(new CarOnRailsCondition("tutorial/fail/derailed"));
			if (resourceContainerController != null)
			{
				c.Tutorial.AddGlobalCheck(new ResourceAvailableCondition(resourceContainerController, new(ResourceContainerType, float)[3]
				{
					(ResourceContainerType.FUEL, 0.1f),
					(ResourceContainerType.OIL, 0.1f),
					(ResourceContainerType.ELECTRIC_CHARGE, 0.1f)
				}, "tutorial/cond/loco_damaged"));
			}
			c.Tutorial.AddGlobalCheck(new CarDamageCondition(0f, 0.5f, "tutorial/cond/loco_damaged"));
			PlugSocket[] fuelSockets = loco.FuelSockets;
			c.BeginNewPhase();
			c.AddLocoReset();
			DieselBasicPrereqs(includeHandbrakeApplied: true, includeStartedEngine: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndDashLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.CabLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndCabLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Wipers);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndWipers1);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndWipers2);
			c.AddControl(InteriorControlsManager.ControlType.HeadlightsFront, 0.59f, 1f, QTSemantic.EngageCW, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlightsTypeFront);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlightsTypeFront, 0f, 0f, QTSemantic.Disengage);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlights1Front, 1f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlights2Front);
			c.AddControl(InteriorControlsManager.ControlType.HeadlightsRear, 0f, 0.3f, QTSemantic.EngageCCW, shouldRecheck: false);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlightsTypeRear, 1f, 1f, QTSemantic.Engage);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlights1Rear, 1f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlights2Rear);
			c.BeginNewPhase();
			DieselBasicPrereqs(includeHandbrakeApplied: true, includeStartedEngine: true);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 0.49f, 0.51f, QTSemantic.SetToNeutral);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.DynamicBrake, 0f, 0f, QTSemantic.Disengage);
			c.BeginNewPhase();
			DieselBasicPrereqs(includeHandbrakeApplied: true, includeStartedEngine: true);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 0.49f, 0.51f, QTSemantic.SetToNeutral);
			c.AddMonitorIndicator(c.Indicators?.mainReservoir, LocalizationAPI.L("car/tut/mainres") + "\n" + LocalizationAPI.L("tutorial/monitor_until", "2 bar"), LocalizationAPI.L("tutorial/loco/int_main_res"), 3f, float.PositiveInfinity, manualDismiss: true, 3f);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0.05f, 1f, QTSemantic.GentlyEngage, shouldRecheck: false);
			c.AddLookAndAcknowledge(c.Indicators?.engineRpm, LocalizationAPI.L("car/tut/rpm"), LocalizationAPI.L("tutorial/loco/ind_rpm"));
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage);
			c.BeginNewPhase();
			DieselBasicPrereqs(includeHandbrakeApplied: false, includeStartedEngine: true);
			c.AddControl(InteriorControlsManager.ControlType.Handbrake, 1f, 1f, QTSemantic.FullyEngage, shouldRecheck: false);
			bool flag = c.AddOverridableControl(InteriorControlsManager.ControlType.IndBrake, 0.3f, 1f, QTSemantic.Engage, shouldRecheck: false);
			if (!flag)
			{
				c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrake, 0.3f, 1f, QTSemantic.Engage, shouldRecheck: false);
			}
			c.AddLookAndAcknowledge(c.Indicators?.brakeCylinder, LocalizationAPI.L("car/tut/brakecyl"), LocalizationAPI.L("tutorial/loco/brake_red_needle"));
			if (flag)
			{
				c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.TrainBrake);
				c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrake, 0f, 0f, QTSemantic.Disengage);
			}
			c.AddLookAndAcknowledge(c.Indicators?.brakePipe, LocalizationAPI.L("car/tut/brakepipe"), LocalizationAPI.L("tutorial/loco/brake_black_needle"));
			c.AddLookAndAcknowledge(c.Indicators?.speed, LocalizationAPI.L("car/tut/speedometer"), LocalizationAPI.L("tutorial/loco/ind_speed"));
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Sander);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 1f, 1f, QTSemantic.GoForward);
			c.AddControl(InteriorControlsManager.ControlType.Handbrake, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(flag ? InteriorControlsManager.ControlType.IndBrake : InteriorControlsManager.ControlType.TrainBrake, 0f, 0f, QTSemantic.Disengage);
			c.AddManualGearShifting(InteriorControlsManager.ControlType.GearboxA, shouldBeInGear: true);
			c.AddManualGearShifting(InteriorControlsManager.ControlType.GearboxB, shouldBeInGear: true);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0.05f, 1f, QTSemantic.GentlyEngage, shouldRecheck: false);
			c.Phase.Add(new CarSpeedStep(loco, 1f, aboveTarget: true));
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage);
			c.BeginNewPhase();
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrake, 0.5f, 1f, QTSemantic.Engage);
			c.Phase.Add(new CarSpeedStep(loco, 1f, aboveTarget: false));
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 0.49f, 0.51f, QTSemantic.SetToNeutral);
			c.BeginNewPhase();
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.GearboxA);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.GearboxB);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.GearboxA, LocalizationAPI.L("car/tut/gearboxa"), LocalizationAPI.L("tutorial/loco/gears_higher_speed"));
			c.AddLookAndAcknowledge(c.Indicators?.amps, LocalizationAPI.L("car/tut/amperage"), LocalizationAPI.L("tutorial/loco/ind_amps"));
			c.AddLookAndAcknowledge(c.Indicators?.tmTemp, LocalizationAPI.L("car/tut/tmtemp"), LocalizationAPI.L("tutorial/loco/ind_tm_temp"));
			c.AddLookAndAcknowledge(c.Indicators?.oilTemp, LocalizationAPI.L("car/tut/oiltemp"), LocalizationAPI.L("tutorial/loco/ind_transmission_oil_temp"));
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.FuelCutoff);
			c.BeginNewPhase();
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.DynamicBrake);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Horn);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Bell);
			c.BeginNewPhase();
			c.AddLookAndAcknowledge(c.Lamps?.wheelSlip, LocalizationAPI.L("car/tut/wheelslip"), LocalizationAPI.L("tutorial/loco/ind_wheel_slip"));
			c.AddLookAndAcknowledge(c.Indicators?.battery, LocalizationAPI.L("car/tut/battery"), LocalizationAPI.L("tutorial/loco/ind_battery"));
			c.AddLookAndAcknowledge(c.Indicators?.voltage, LocalizationAPI.L("car/tut/voltage"), LocalizationAPI.L("tutorial/loco/ind_voltage"));
			c.AddLookAndAcknowledge(c.Indicators?.fuel, LocalizationAPI.L("car/tut/fuel"), LocalizationAPI.L("tutorial/loco/ind_fuel"));
			c.AddLookAndAcknowledge(c.Indicators?.oil, LocalizationAPI.L("car/tut/oil"), LocalizationAPI.L("tutorial/loco/ind_oil_engine"));
			c.AddLookAndAcknowledge(c.Indicators?.sand, LocalizationAPI.L("car/tut/sand"), LocalizationAPI.L("tutorial/loco/ind_sand"));
			for (int i = 0; i < fuelSockets.Length; i++)
			{
				if (fuelSockets[i].connectionTag == "diesel-hose")
				{
					c.AddLookAndAcknowledge(fuelSockets[i], LocalizationAPI.L("car/tut/dieselhoseslot"), LocalizationAPI.L("tutorial/loco/fuel_hose_slot"));
				}
				else if (fuelSockets[i].connectionTag == "electric-charge-cable")
				{
					c.AddLookAndAcknowledge(fuelSockets[i], LocalizationAPI.L("car/tut/electriccableslot"), LocalizationAPI.L("tutorial/loco/electric_cable_slot"));
				}
			}
			c.BeginNewPhase();
			c.AddPrompt("tutorial/loco/completed", pause: false);
			return c.Tutorial;
			void DieselBasicPrereqs(bool includeHandbrakeApplied, bool includeStartedEngine)
			{
				if (includeHandbrakeApplied)
				{
					c.AddControl(InteriorControlsManager.ControlType.Handbrake, 1f, 1f, QTSemantic.FullyEngage);
				}
				c.AddFuse(InteriorControlsManager.ControlType.ElectricsFuse, QTSemantic.Engage);
				c.AddFuse(InteriorControlsManager.ControlType.StarterFuse, QTSemantic.Engage);
				c.AddFuse(InteriorControlsManager.ControlType.TractionMotorFuse, QTSemantic.Engage);
				if (includeStartedEngine)
				{
					c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrakeCutout, 0.9f, 1f, QTSemantic.Open);
					c.AddEngineState(InteriorControlsManager.ControlType.StarterControl, targetValue: true, QTSemantic.EngageCW);
				}
			}
		}

		private static QuickTutorial SteamEngineTutorial(TrainTutorialConstructor c, TrainCar loco)
		{
			string[] array = new string[3] { "shovel", "ExpertShovel", "GoldenShovel" };
			string[] array2 = new string[1] { "lighter" };
			string[] array3 = new string[1] { "Oiler" };
			c.Tutorial.AddStartingCheck(new PlayerInLocoCondition("tutorial/cond/in_locomotive"));
			c.Tutorial.AddStartingCheck(new CarOnRailsCondition("tutorial/cond/loco_railed_start"));
			c.Tutorial.AddStartingCheck(new CarDamageCondition(0f, 0.5f, "tutorial/cond/loco_damaged"));
			c.Tutorial.AddStartingCheck(new LocoFuelCondition(0.05f, 1f, "tutorial/cond/requires_fuel", "tutorial/cond/requires_coal_and_water", "tutorial/cond/requires_power"));
			c.Tutorial.AddStartingCheck(new CarSpeedCondition(0f, 0.1f, absolute: true, "tutorial/cond/loco_stationary"));
			c.Tutorial.AddStartingCheck(new CarGradeCondition(0f, 1f, "tutorial/cond/loco_grade"));
			c.Tutorial.AddStartingCheck(new TenderPresentCondition(loco, "tutorial/cond/requires_tender"));
			c.Tutorial.AddStartingCheck(new AnyItemPresentCondition(array2, "tutorial/cond/requires_lighter"));
			c.Tutorial.AddStartingCheck(new AnyItemPresentCondition(array, "tutorial/cond/requires_shovel"));
			c.Tutorial.AddStartingCheck(new AnyItemPresentCondition(array3, "tutorial/cond/requires_oiler"));
			if (loco == null)
			{
				c.Tutorial.Add(new QuickTutorialPhase());
				return c.Tutorial;
			}
			TrainCar separateTender = null;
			if (loco.GetComponent<SteamTenderAutoCoupleMechanism>() != null && loco.rearCoupler.coupledTo != null && CarTypes.IsTender(loco.rearCoupler.coupledTo.train.carLivery))
			{
				separateTender = loco.rearCoupler.coupledTo.train;
			}
			LocoIndicatorReader locoIndicatorReader = loco.loadedInterior?.GetComponent<LocoIndicatorReader>();
			LocoIndicatorReader locoIndicatorReader2 = loco.loadedExternalInteractables?.GetComponent<LocoIndicatorReader>();
			Transform transform = locoIndicatorReader?.locoCoalLevel?.GetComponentInParent<Fire>()?.fireObj?.transform;
			SimController simController = loco.SimController;
			FireboxSimController fireboxSimController = simController?.firebox;
			ResourceContainerController resourceContainerController = ((!(separateTender != null)) ? simController?.resourceContainerController : separateTender.SimController?.resourceContainerController);
			OilingPointsPortController oilingPointsPortController = loco.loadedExternalInteractables?.GetComponent<OilingPointsPortController>();
			Indicator indicator = null;
			Indicator indicator2 = null;
			if (separateTender != null)
			{
				indicator = separateTender.loadedInterior?.GetComponent<LocoIndicatorReader>()?.tenderWaterLevel;
				if (indicator == null)
				{
					indicator = separateTender.loadedExternalInteractables?.GetComponent<LocoIndicatorReader>()?.tenderWaterLevel;
				}
				indicator2 = separateTender.loadedInterior?.GetComponent<LocoIndicatorReader>()?.tenderCoalLevel;
				if (indicator2 == null)
				{
					indicator2 = separateTender.loadedExternalInteractables?.GetComponent<LocoIndicatorReader>()?.tenderCoalLevel;
				}
			}
			else
			{
				indicator = locoIndicatorReader?.tenderWaterLevel;
				if (indicator == null)
				{
					indicator = locoIndicatorReader2?.tenderWaterLevel;
				}
				indicator2 = locoIndicatorReader?.tenderCoalLevel;
				if (indicator2 == null)
				{
					indicator2 = locoIndicatorReader2?.tenderCoalLevel;
				}
			}
			c.Tutorial.Add(new KeepTrainLODService());
			if (separateTender != null)
			{
				c.Tutorial.Add(new KeepTrainLODService(separateTender));
			}
			c.Tutorial.Add(new CarRangeWarningService(15f));
			c.Tutorial.AddGlobalCheck(new CarEnabledCondition());
			c.Tutorial.AddGlobalCheck(new CarDistanceCondition(30f));
			c.Tutorial.AddGlobalCheck(new CarOnRailsCondition("tutorial/fail/derailed"));
			c.Tutorial.AddGlobalCheck(new CarDamageCondition(0f, 0.5f, "tutorial/cond/loco_damaged"));
			c.Tutorial.AddGlobalCheck(new TenderPresentCondition(loco, "tutorial/cond/requires_tender"));
			if (resourceContainerController != null)
			{
				c.Tutorial.AddGlobalCheck(new ResourceAvailableCondition(resourceContainerController, new(ResourceContainerType, float)[2]
				{
					(ResourceContainerType.WATER, 0.1f),
					(ResourceContainerType.COAL, 0.1f)
				}, "tutorial/cond/loco_damaged"));
			}
			c.BeginNewPhase();
			c.AddPrompt("tutorial/loco/steam_startup_costs", pause: false);
			c.AddLocoReset();
			c.BeginNewPhase();
			c.AddLookAndAcknowledge(locoIndicatorReader?.locoWaterLevel, LocalizationAPI.L("car/tut/water"), LocalizationAPI.L("tutorial/loco/water_meter"));
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Injector);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Blowdown);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: true, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: false);
			c.AddControl(InteriorControlsManager.ControlType.Firedoor, 0.8f, 1f, QTSemantic.Open, shouldRecheck: false);
			c.Phase.Add(new EquipAnyItemStep(array, LocalizationAPI.L("tutorial/loco/take_out_shovel")));
			c.AddTakeCoalStep((separateTender != null) ? separateTender : loco, LocalizationAPI.L("car/tut/coal"), default(Vector3), shouldRecheck: false);
			c.AddPutCoalIntoFireboxStep(fireboxSimController, 0.95f, requireAtLeastOneShovel: true, LocalizationAPI.L("car/tut/firebox") + "\n\n" + LocalizationAPI.L("tutorial/loco/shovel_coal"), transform);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: false);
			c.AddControl(InteriorControlsManager.ControlType.Firedoor, 0.8f, 1f, QTSemantic.Open, shouldRecheck: false);
			if (locoIndicatorReader?.locoWaterLevel != null && c.Controls.TryGetControl(InteriorControlsManager.ControlType.Injector, out var reference) && c.Controls.TryGetControl(InteriorControlsManager.ControlType.Blowdown, out var reference2))
			{
				c.Phase.Add(new BoilerWaterTweakStep(locoIndicatorReader?.locoWaterLevel, reference.controlImplBase, reference2.controlImplBase, default(Vector3), shouldRecheck: false));
			}
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: true, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: false);
			c.AddControl(InteriorControlsManager.ControlType.Firedoor, 0.8f, 1f, QTSemantic.Open, shouldRecheck: false);
			c.Phase.Add(new EquipAnyItemStep(array2, LocalizationAPI.L("tutorial/loco/take_out_lighter")));
			c.Phase.Add(new LightFireStep(loco, c.Overrider, targetValue: true, LocalizationAPI.L("car/tut/firebox") + "\n\n" + LocalizationAPI.L("tutorial/loco/light_fire"), transform));
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: false);
			c.AddControl(InteriorControlsManager.ControlType.Firedoor, 0f, 0f, QTSemantic.Close, shouldRecheck: false);
			c.AddControl(InteriorControlsManager.ControlType.Blower, 1f, 1f, QTSemantic.FullyEngage);
			c.AddMonitorIndicator(locoIndicatorReader?.fireTemperature, LocalizationAPI.L("car/tut/firetemp") + "\n" + LocalizationAPI.L("tutorial/monitor_until", "400 °C"), LocalizationAPI.L("tutorial/loco/ind_fire"), 400f, float.PositiveInfinity, manualDismiss: true, 3f);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: false);
			c.AddControl(InteriorControlsManager.ControlType.Blower, 1f, 1f, QTSemantic.FullyEngage);
			c.AddMonitorIndicator(locoIndicatorReader?.steam, LocalizationAPI.L("car/tut/boilerpressure") + "\n" + LocalizationAPI.L("tutorial/monitor_until", "1 bar"), LocalizationAPI.L("tutorial/loco/ind_boiler_pressure"), 2f, float.PositiveInfinity, manualDismiss: true, 3f);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: false);
			c.AddControl(InteriorControlsManager.ControlType.Firedoor, 0f, 0f, QTSemantic.Close);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: true, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: true);
			c.AddAutomaticLubricatorStep(locoIndicatorReader2?.transmissionOil);
			c.AddLookAndAcknowledge(locoIndicatorReader2?.transmissionOil, LocalizationAPI.L("car/tut/oil_bearing"), LocalizationAPI.L("tutorial/loco/ind_oil_bearing"));
			List<OilingPointPortFeederReader> list = null;
			if (oilingPointsPortController?.entries != null)
			{
				List<Tuple<OilingPointPortFeederReader, Vector3>> source = oilingPointsPortController?.entries.Select((OilingPointPortFeederReader op) => new Tuple<OilingPointPortFeederReader, Vector3>(op, loco.transform.InverseTransformPoint(op.transform.position))).ToList();
				IEnumerable<OilingPointPortFeederReader> collection = from tp in source
					where tp.Item2.x < 0f
					orderby 0f - tp.Item2.z
					select tp.Item1;
				IEnumerable<OilingPointPortFeederReader> collection2 = from tp in source
					where tp.Item2.x >= 0f
					orderby tp.Item2.z
					select tp.Item1;
				list = new List<OilingPointPortFeederReader>();
				list.AddRange(collection2);
				list.AddRange(collection);
			}
			OilingPointPortFeederReader oilingPointPortFeederReader = list?.FirstOrDefault();
			List<OilingPointPortFeederReader> list2 = list?.Skip(1).ToList();
			ControlImplBase controlImplBase = oilingPointPortFeederReader?.GetComponent<ControlImplBase>();
			Indicator indicator3 = oilingPointPortFeederReader?.transform?.parent?.GetComponentInChildren<Indicator>();
			if (controlImplBase != null && indicator3 != null)
			{
				c.BeginNewPhase();
				SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: true);
				c.AddControl(controlImplBase, 1f, 1f, LocalizationAPI.L("car/tut/oiling_point"), LocalizationAPI.L("tutorial/control/oiling_point"), QTSemantic.Open);
				c.Phase.Add(new EquipAnyItemStep(array3, LocalizationAPI.L("tutorial/loco/take_out_oiler")));
				c.AddRefillOilingPointStep(indicator3, 1f);
				c.BeginNewPhase();
				SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: true);
				c.AddControl(controlImplBase, 0f, 0f, LocalizationAPI.L("car/tut/oiling_point"), LocalizationAPI.L("tutorial/control/oiling_point"), QTSemantic.Close);
				foreach (OilingPointPortFeederReader item in list2)
				{
					Indicator indicator4 = item?.transform?.parent?.GetComponentInChildren<Indicator>();
					if (indicator4 != null)
					{
						c.BeginNewPhase();
						SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: true);
						c.AddRefillOilingPointStep(indicator4, 1f);
					}
				}
			}
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: true);
			c.AddLookAndAcknowledge(locoIndicatorReader2?.oil, LocalizationAPI.L("car/tut/oil"), LocalizationAPI.L("tutorial/loco/ind_oil_storage"));
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: true, openDamperControl: true, engageHandbrakeControl: true, openBrakeCutout: false, engageCompressorAndDynamo: true);
			c.AddControl(InteriorControlsManager.ControlType.HeadlightsFront, 0.55f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlightsTypeFront);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlightsTypeFront, 0f, 0f, QTSemantic.Disengage);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlights1Front, 1f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlights2Front);
			c.AddControl(InteriorControlsManager.ControlType.HeadlightsRear, 0f, 0.3f, QTSemantic.Engage, shouldRecheck: false);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlightsTypeRear, 1f, 1f, QTSemantic.Engage);
			c.AddControl(InteriorControlsManager.ControlType.IndHeadlights1Rear, 1f, 1f, QTSemantic.Engage, shouldRecheck: false);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndHeadlights2Rear);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.CabLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndDashLight);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndCabLight, null, isSteamLoco: true);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Wipers);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndWipers1);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.IndWipers2);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: false, engageHandbrakeControl: true, openBrakeCutout: true, engageCompressorAndDynamo: true);
			c.AddMonitorIndicator(locoIndicatorReader?.mainReservoir, LocalizationAPI.L("car/tut/mainres") + "\n" + LocalizationAPI.L("tutorial/monitor_until", "2 bar"), LocalizationAPI.L("tutorial/loco/int_main_res"), 3f, float.PositiveInfinity, manualDismiss: true, 3f);
			c.AddOverridableControl(InteriorControlsManager.ControlType.IndBrake, 1f, 1f, QTSemantic.Engage);
			c.AddLookAndAcknowledge(locoIndicatorReader?.brakeCylinder, LocalizationAPI.L("car/tut/brakecyl"), LocalizationAPI.L("tutorial/loco/brake_red_needle"));
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.TrainBrake);
			c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrake, 0f, 0f, QTSemantic.Disengage);
			c.AddLookAndAcknowledge(locoIndicatorReader?.brakePipe, LocalizationAPI.L("car/tut/brakepipe"), LocalizationAPI.L("tutorial/loco/brake_black_needle"));
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: false, engageHandbrakeControl: true, openBrakeCutout: true, engageCompressorAndDynamo: true);
			c.AddControl(InteriorControlsManager.ControlType.Blower, 0f, 0f, QTSemantic.Disengage);
			c.AddLookAndAcknowledge(locoIndicatorReader?.speed, LocalizationAPI.L("car/tut/speedometer"), LocalizationAPI.L("tutorial/loco/ind_speed"));
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Sander);
			c.AddLookAndAcknowledge(locoIndicatorReader?.sand, LocalizationAPI.L("car/tut/sand"), LocalizationAPI.L("tutorial/loco/ind_sand"));
			c.AddPutCoalIntoFireboxStep(fireboxSimController, 0.95f, requireAtLeastOneShovel: true, LocalizationAPI.L("car/tut/firebox") + "\n\n" + LocalizationAPI.L("tutorial/loco/shovel_coal"), transform);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: false, engageHandbrakeControl: false, openBrakeCutout: true, engageCompressorAndDynamo: true);
			c.AddVirtualHandbrakeControl(separateTender, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrake, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 0.9f, 1f, QTSemantic.GoForward, shouldRecheck: true, 0f, isSteamLoco: true);
			c.AddControl(InteriorControlsManager.ControlType.CylCock, 1f, 1f, QTSemantic.Open);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0.05f, 1f, QTSemantic.GentlyEngage, shouldRecheck: true, 0f, isSteamLoco: true);
			c.AddMonitorIndicatorNoMessage(locoIndicatorReader?.steamChest, 6f, float.PositiveInfinity);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: false, engageHandbrakeControl: false, openBrakeCutout: true, engageCompressorAndDynamo: true);
			c.AddVirtualHandbrakeControl(separateTender, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage, shouldRecheck: true, 0f, isSteamLoco: true);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: false, engageHandbrakeControl: false, openBrakeCutout: true, engageCompressorAndDynamo: true);
			c.AddVirtualHandbrakeControl(separateTender, 0f, 0f, QTSemantic.Disengage);
			c.AddMonitorIndicator(locoIndicatorReader?.steamChest, LocalizationAPI.L("car/tut/chestpressure") + "\n" + LocalizationAPI.L("tutorial/monitor_above", "3 bar"), LocalizationAPI.L("tutorial/loco/chest_pressure"), 4f, float.PositiveInfinity, manualDismiss: true, 0f, null, strictDismiss: true);
			c.AddOverridableControl(InteriorControlsManager.ControlType.IndBrake, 0f, 0f, QTSemantic.Disengage);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: false, engageHandbrakeControl: false, openBrakeCutout: true, engageCompressorAndDynamo: true);
			c.AddVirtualHandbrakeControl(separateTender, 0f, 0f, QTSemantic.Disengage);
			c.Phase.Add(new CarSpeedStep(loco, 1f, aboveTarget: true));
			c.AddOverridableControl(InteriorControlsManager.ControlType.IndBrake, 0.8f, 1f, QTSemantic.Engage);
			c.BeginNewPhase();
			SteamerDrivingBasicPrereq(disengageWaterControls: false, openDamperControl: false, engageHandbrakeControl: false, openBrakeCutout: true, engageCompressorAndDynamo: true);
			c.AddVirtualHandbrakeControl(separateTender, 0f, 0f, QTSemantic.Disengage);
			c.AddOverridableControl(InteriorControlsManager.ControlType.IndBrake, 0.8f, 1f, QTSemantic.Engage);
			c.AddControl(InteriorControlsManager.ControlType.CylCock, 0f, 0f, QTSemantic.Close);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.CylCock, LocalizationAPI.L("car/tut/cylcock"), LocalizationAPI.L("tutorial/loco/water_in_cylinders"));
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Reverser, LocalizationAPI.L("car/tut/cutoff"), LocalizationAPI.L("tutorial/loco/cutoff_higher_speed"));
			c.AddOverridableControl(InteriorControlsManager.ControlType.Reverser, 0.4f, 0.6f, QTSemantic.SetToNeutral, shouldRecheck: true, 0f, isSteamLoco: true);
			c.BeginNewPhase();
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Damper);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.CoalDump);
			c.AddLookAndAcknowledge(locoIndicatorReader?.locoWaterLevel, LocalizationAPI.L("car/tut/water"), LocalizationAPI.L("tutorial/steam_water_warning"));
			c.AddLookAndAcknowledge(transform, LocalizationAPI.L("car/tut/firebox"), LocalizationAPI.L("tutorial/loco/steam_firebox_overfill"));
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Bell);
			c.AddLookAndAcknowledge(InteriorControlsManager.ControlType.Horn, null, isSteamLoco: true);
			c.AddLookAndAcknowledge(indicator, LocalizationAPI.L("car/tut/water"), LocalizationAPI.L("tutorial/loco/ind_storage_water"));
			c.AddLookAndAcknowledge(indicator2, LocalizationAPI.L("car/tut/coal"), LocalizationAPI.L("tutorial/loco/ind_storage_coal"));
			Coupler component = ((separateTender != null) ? separateTender.rearCoupler : loco.rearCoupler);
			c.AddLookAndAcknowledge(component, "", LocalizationAPI.L("tutorial/loco/eot_lantern_hook"));
			c.BeginNewPhase();
			c.AddPrompt("tutorial/loco/completed", pause: false);
			return c.Tutorial;
			void SteamerDrivingBasicPrereq(bool disengageWaterControls, bool openDamperControl, bool engageHandbrakeControl, bool openBrakeCutout, bool engageCompressorAndDynamo)
			{
				if (disengageWaterControls)
				{
					c.AddControl(InteriorControlsManager.ControlType.Blowdown, 0f, 0f, QTSemantic.Disengage);
					c.AddControl(InteriorControlsManager.ControlType.Injector, 0f, 0f, QTSemantic.Disengage);
				}
				if (openDamperControl)
				{
					c.AddControl(InteriorControlsManager.ControlType.Damper, 1f, 1f, QTSemantic.Open);
				}
				if (engageHandbrakeControl)
				{
					c.AddVirtualHandbrakeControl(separateTender, 1f, 1f, QTSemantic.FullyEngage);
				}
				if (openBrakeCutout)
				{
					c.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrakeCutout, 0.9f, 1f, QTSemantic.Open);
				}
				if (engageCompressorAndDynamo)
				{
					c.AddControl(InteriorControlsManager.ControlType.AirPump, 1f, 1f, QTSemantic.Engage);
					c.AddControl(InteriorControlsManager.ControlType.Dynamo, 1f, 1f, QTSemantic.Engage);
				}
			}
		}

		public static QuickTutorial PrepareFor(TrainCar loco)
		{
			if (loco == null)
			{
				Debug.LogWarning("PrepareFor called with null loco, thus returning null QuickTutorial.");
				return null;
			}
			TrainTutorialConstructor c = new TrainTutorialConstructor(loco, userControlAllowed: true);
			if (CarTypes.IsSteamLocomotive(loco.carLivery))
			{
				return SteamEngineTutorial(c, loco);
			}
			return DieselEngineTutorial(c, loco);
		}

		public static QuickTutorial CareerParkingTutorial(TrainCar loco, Transform parking, BoxCollider startBreakingBox, bool doRangeChecks)
		{
			TrainTutorialConstructor trainTutorialConstructor = new TrainTutorialConstructor(loco, userControlAllowed: false);
			trainTutorialConstructor.Tutorial.AddStartingCheck(new PlayerInLocoCondition("tutorial/cond/in_locomotive"));
			trainTutorialConstructor.Tutorial.AddStartingCheck(new CarOnRailsCondition("tutorial/cond/loco_railed_start"));
			trainTutorialConstructor.Tutorial.AddStartingCheck(new CarDamageCondition(0f, 0.5f, "tutorial/cond/loco_damaged"));
			if (loco == null)
			{
				trainTutorialConstructor.Tutorial.Add(new QuickTutorialPhase());
				return trainTutorialConstructor.Tutorial;
			}
			trainTutorialConstructor.Tutorial.Add(new KeepTrainLODService());
			trainTutorialConstructor.Tutorial.Add(new CarRangeWarningService(15f));
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarEnabledCondition());
			if (doRangeChecks)
			{
				trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarDistanceCondition(30f));
			}
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarOnRailsCondition("tutorial/fail/derailed"));
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarDamageCondition(0f, 0.5f, "tutorial/cond/loco_damaged"));
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.Add(new LocoInZoneStep(LocalizationAPI.L("tutorial/career/drive_loco_to_here"), trainTutorialConstructor.Loco, startBreakingBox, parking, Vector3.zero, shouldRecheck: false));
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.AddOverridableControl(InteriorControlsManager.ControlType.Throttle, 0f, 0f, QTSemantic.Disengage);
			trainTutorialConstructor.AddOverridableControl(InteriorControlsManager.ControlType.TrainBrake, 0.5f, 1f, QTSemantic.Engage, shouldRecheck: false, 1f);
			return trainTutorialConstructor.Tutorial;
		}

		private static ItemBase[] GetCommsRadioItems()
		{
			GameObject itemByName = SingletonBehaviour<Inventory>.Instance.GetItemByName("CommsRadio", partialNameCheck: false);
			commsRadioCache[0] = (itemByName ? itemByName.GetComponent<ItemBase>() : null);
			return commsRadioCache;
		}

		public static QuickTutorial RerailingTutorial(Transform referencePoint, bool doRangeChecks, bool onlyClosestRail, RailTrack specificTrack = null, Collider specificCollider = null)
		{
			int num = Physics.OverlapSphereNonAlloc(referencePoint.position, 15f, colCache, LayerMask.GetMask("Train_Big_Collider"));
			List<TrainCar> list = new List<TrainCar>();
			for (int i = 0; i < num; i++)
			{
				TrainCar trainCar = TrainCar.Resolve(colCache[i].gameObject);
				if ((bool)trainCar && trainCar.derailed && !list.Contains(trainCar) && trainCar.GetAbsSpeed() < 0.1f)
				{
					list.Add(trainCar);
				}
			}
			if (list.Count < 1)
			{
				return InstantFailCondition.CreateTutorial(LocalizationAPI.L("tutorial/rerailing/no_cars"));
			}
			TrainCar trainCar2 = list[0];
			TrainTutorialConstructor trainTutorialConstructor = new TrainTutorialConstructor(trainCar2, userControlAllowed: false);
			if ((bool)specificTrack)
			{
				trainTutorialConstructor.Tutorial.Add(new SingleRailRerailService(specificTrack));
			}
			else if (onlyClosestRail)
			{
				int closestNodeIndex;
				RailTrack trackClosestTo = CarSpawner.GetTrackClosestTo(trainCar2.transform.position, 1f, out closestNodeIndex);
				trainTutorialConstructor.Tutorial.Add(new SingleRailRerailService(trackClosestTo));
			}
			if ((bool)specificCollider)
			{
				trainTutorialConstructor.Tutorial.Add(new InsideColliderRerailService(specificCollider));
			}
			trainTutorialConstructor.Tutorial.Add(new CarRangeWarningService(80f));
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarEnabledCondition(trainCar2));
			if (doRangeChecks)
			{
				trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarDistanceCondition(100f, trainCar2));
			}
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.Add(new EquipItemStep("CommsRadio", GetCommsRadioItems(), LocalizationAPI.L("tutorial/rerailing/take_comms")));
			trainTutorialConstructor.Phase.Add(new CommsRadioModeStep<RerailController>(VRManager.IsVREnabled() ? LocalizationAPI.L("tutorial/rerailing/set_mode_vr") : LocalizationAPI.L("tutorial/rerailing/set_mode")));
			trainTutorialConstructor.Phase.Add(new RerailStateStep(LocalizationAPI.L("tutorial/rerailing/aim"), RerailController.State.PickDestination));
			trainTutorialConstructor.Phase.Add(new RerailStateStep(LocalizationAPI.L("tutorial/rerailing/rail"), RerailController.State.ConfirmRerail));
			trainTutorialConstructor.Phase.Add(new CarRerailedStep(LocalizationAPI.L("tutorial/rerailing/confirm")));
			return trainTutorialConstructor.Tutorial;
		}

		public static QuickTutorial HandcarSpawnTutorial(Transform referencePoint, bool onlyClosestRail, RailTrack specificTrack = null)
		{
			Vector3 position = referencePoint.position;
			TrainTutorialConstructor trainTutorialConstructor = new TrainTutorialConstructor(null, userControlAllowed: false);
			if ((bool)specificTrack)
			{
				trainTutorialConstructor.Tutorial.Add(new SingleRailCrewSpawnService(specificTrack));
			}
			else if (onlyClosestRail)
			{
				int closestNodeIndex;
				RailTrack trackClosestTo = CarSpawner.GetTrackClosestTo(position, 1f, out closestNodeIndex);
				trainTutorialConstructor.Tutorial.Add(new SingleRailCrewSpawnService(trackClosestTo));
			}
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.Add(new EquipItemStep("CommsRadio", GetCommsRadioItems(), LocalizationAPI.L("tutorial/handcar/comms")));
			trainTutorialConstructor.Phase.Add(new CommsRadioModeStep<CommsRadioCrewVehicle>(LocalizationAPI.L("tutorial/handcar/workmode")));
			trainTutorialConstructor.Phase.Add(new CrewSpawnStateStep(LocalizationAPI.L("tutorial/handcar/request"), CommsRadioCrewVehicle.State.EnterSpawnMode));
			trainTutorialConstructor.Phase.Add(new CrewSpawnStateStep(LocalizationAPI.L("tutorial/handcar/request"), CommsRadioCrewVehicle.State.PickCrewVehicle));
			trainTutorialConstructor.Phase.Add(new CrewSpawnStateStep(LocalizationAPI.L("tutorial/handcar/handcar"), CommsRadioCrewVehicle.State.PickDestination));
			trainTutorialConstructor.Phase.Add(new CrewSpawnStateStep(LocalizationAPI.L("tutorial/handcar/aim"), CommsRadioCrewVehicle.State.ConfirmSummon, LocalizationAPI.L("tutorial/handcar/aim_back"), CommsRadioCrewVehicle.State.CancelSummon));
			trainTutorialConstructor.Phase.Add(new CarSummonedStep(LocalizationAPI.L("tutorial/handcar/confirm")));
			return trainTutorialConstructor.Tutorial;
		}

		public static QuickTutorial HandcarClearTutorial(TrainCar carToClear)
		{
			TrainTutorialConstructor trainTutorialConstructor = new TrainTutorialConstructor(null, userControlAllowed: false);
			if (carToClear != null)
			{
				trainTutorialConstructor.Tutorial.Add(new SingleCarDeletionService(carToClear));
			}
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.Add(new EquipItemStep("CommsRadio", GetCommsRadioItems(), LocalizationAPI.L("tutorial/clear/take_comms")));
			trainTutorialConstructor.Phase.Add(new CommsRadioModeStep<CommsRadioCarDeleter>(LocalizationAPI.L("tutorial/clear/mode")));
			trainTutorialConstructor.Phase.Add(new ClearCarStateStep(LocalizationAPI.L("tutorial/clear/aim"), CommsRadioCarDeleter.State.ScanCarToDelete));
			trainTutorialConstructor.Phase.Add(new ClearCarStateStep(LocalizationAPI.L("tutorial/clear/click"), CommsRadioCarDeleter.State.ConfirmDelete, LocalizationAPI.L("tutorial/clear/aim_back"), CommsRadioCarDeleter.State.CancelDelete));
			trainTutorialConstructor.Phase.Add(new CarDeletedStep(LocalizationAPI.L("tutorial/clear/confirm"), carToClear));
			return trainTutorialConstructor.Tutorial;
		}

		private static bool ShouldChainBeAttached(ChainCouplerInteraction.State state)
		{
			if (state == ChainCouplerInteraction.State.Attached || state == ChainCouplerInteraction.State.Attached_Loose || state == ChainCouplerInteraction.State.Attached_Tight)
			{
				return false;
			}
			return true;
		}

		public static QuickTutorial CouplingTutorial(Transform referencePoint, bool announceCompletion, bool doRangeChecks, List<TrainCar> cars = null)
		{
			Vector3 playerPoint = referencePoint.position;
			List<Coupler> list = new List<Coupler>();
			if (cars == null)
			{
				int num = Physics.OverlapSphereNonAlloc(playerPoint, 15f, colCache, LayerMask.GetMask("Train_Big_Collider"));
				cars = new List<TrainCar>();
				for (int i = 0; i < num; i++)
				{
					TrainCar trainCar = TrainCar.Resolve(colCache[i].gameObject);
					if ((bool)trainCar && !trainCar.derailed && !cars.Contains(trainCar) && trainCar.GetAbsSpeed() < 0.1f)
					{
						cars.Add(trainCar);
						list.AddRange(trainCar.couplers);
					}
				}
			}
			else
			{
				for (int j = 0; j < cars.Count; j++)
				{
					list.AddRange(cars[j].couplers);
				}
			}
			if (cars.Count == 0 || list.Count < 2)
			{
				return InstantFailCondition.CreateTutorial("tutorial/coupling/no_cars");
			}
			list.Sort((Coupler a, Coupler b) => (a.transform.position - playerPoint).sqrMagnitude.CompareTo((b.transform.position - playerPoint).sqrMagnitude));
			Coupler coupler = null;
			Coupler coupler2 = null;
			for (int num2 = 0; num2 < list.Count - 1; num2++)
			{
				if (!(coupler == null))
				{
					break;
				}
				Coupler coupler3 = list[num2];
				for (int num3 = num2 + 1; num3 < list.Count; num3++)
				{
					Coupler coupler4 = list[num3];
					if (coupler3 != coupler4 && coupler3.train != coupler4.train && Vector3.Distance(coupler3.transform.position, coupler4.transform.position) < 0.6f)
					{
						coupler = coupler3;
						coupler2 = coupler4;
						break;
					}
				}
			}
			if (coupler2 == null)
			{
				return InstantFailCondition.CreateTutorial("tutorial/coupling/no_cars");
			}
			if (!coupler2.train.IsLoco && coupler.train.IsLoco)
			{
				Coupler coupler5 = coupler;
				Coupler coupler6 = coupler2;
				coupler2 = coupler5;
				coupler = coupler6;
			}
			TrainTutorialConstructor trainTutorialConstructor = new TrainTutorialConstructor(coupler.train, userControlAllowed: false);
			trainTutorialConstructor.Tutorial.Add(new KeepCouplersLODService(coupler.train));
			trainTutorialConstructor.Tutorial.Add(new KeepCouplersLODService(coupler2.train));
			coupler.train.GetComponentsInChildren<ChainCouplerVisibilityOptimizer>(includeInactive: true).ToList().ForEach(delegate(ChainCouplerVisibilityOptimizer optimizer)
			{
				optimizer.Enable();
			});
			coupler2.train.GetComponentsInChildren<ChainCouplerVisibilityOptimizer>(includeInactive: true).ToList().ForEach(delegate(ChainCouplerVisibilityOptimizer optimizer)
			{
				optimizer.Enable();
			});
			coupler.train.interior.GetComponentsInChildren<CouplingHoseRig>(includeInactive: true).ToList().ForEach(delegate(CouplingHoseRig hose)
			{
				hose.SetLOD(CouplingHoseLODManager.LODLevel.Visible_And_Full_Simulation);
			});
			coupler2.train.interior.GetComponentsInChildren<CouplingHoseRig>(includeInactive: true).ToList().ForEach(delegate(CouplingHoseRig hose)
			{
				hose.SetLOD(CouplingHoseLODManager.LODLevel.Visible_And_Full_Simulation);
			});
			Transform chain = coupler.visualCoupler.chain;
			Transform chain2 = coupler2.visualCoupler.chain;
			ChainCouplerInteraction componentInChildren = chain.GetComponentInChildren<ChainCouplerInteraction>();
			chain2.GetComponentInChildren<ChainCouplerInteraction>();
			CouplingHoseCouplerAdapter componentInChildren2 = coupler.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>();
			CouplingHoseCouplerAdapter componentInChildren3 = coupler2.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>();
			componentInChildren.GetComponentInChildren<Gizmo>(includeInactive: true);
			if (coupler.coupledTo != null && coupler2.coupledTo != null && (componentInChildren2 == null || componentInChildren3 == null || (coupler.IsCockOpen && coupler2.IsCockOpen && componentInChildren2.IsConnected && componentInChildren3.IsConnected)))
			{
				return InstantFailCondition.CreateTutorial("tutorial/coupling/already_coupled");
			}
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarEnabledCondition(coupler.train));
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarEnabledCondition(coupler2.train));
			if (doRangeChecks)
			{
				trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarDistanceCondition(50f, coupler.train));
			}
			if (doRangeChecks)
			{
				trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarDistanceCondition(50f, coupler2.train));
			}
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarOnRailsCondition("tutorial/fail/derailed", coupler.train));
			trainTutorialConstructor.Tutorial.AddGlobalCheck(new CarOnRailsCondition("tutorial/fail/derailed", coupler2.train));
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.PhaseSkipCondition = new CouplerCoupledCondition(coupler, mustBeTight: false);
			trainTutorialConstructor.Phase.Add(new CouplersCloseStep(coupler, coupler2, LocalizationAPI.L("tutorial/coupling/too_far")));
			trainTutorialConstructor.Phase.Add(new GrabGizmoStep(chain.GetComponentInChildren<Gizmo>(includeInactive: true), chain2.GetComponentInChildren<Gizmo>(includeInactive: true), new ControlIconQuickTutorialMessage(LocalizationAPI.L("hud/chain"), LocalizationAPI.L("tutorial/coupling/chain_description"), 3)));
			trainTutorialConstructor.Phase.Add(new CoupleCouplerStep(coupler2, coupler, chain.GetComponentInChildren<ControlImplBase>(), chain2.GetComponentInChildren<ControlImplBase>(), LocalizationAPI.L("tutorial/coupling/place_the_chain")));
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.PhaseSkipCondition = new CouplerCoupledCondition(coupler, mustBeTight: true);
			trainTutorialConstructor.Phase.Add(new CouplersCloseStep(coupler, coupler2, LocalizationAPI.L("tutorial/coupling/too_far")));
			trainTutorialConstructor.Phase.Add(new CoupleCouplerStep(coupler2, coupler, chain.GetComponentInChildren<ControlImplBase>(), chain2.GetComponentInChildren<ControlImplBase>(), LocalizationAPI.L("tutorial/coupling/place_the_chain")));
			trainTutorialConstructor.Phase.Add(new WaitStep(0.5f));
			trainTutorialConstructor.Phase.Add(new CouplerTightenStep(coupler, coupler2, new ControlIconQuickTutorialMessage(LocalizationAPI.L("tutorial/coupling/tighten"), LocalizationAPI.L("tutorial/coupling/screw_description"), 3), tight: true));
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.Add(new CouplersCloseStep(coupler, coupler2, LocalizationAPI.L("tutorial/coupling/too_far")));
			trainTutorialConstructor.Phase.Add(new CoupleCouplerStep(coupler2, coupler, chain.GetComponentInChildren<ControlImplBase>(), chain2.GetComponentInChildren<ControlImplBase>(), LocalizationAPI.L("tutorial/coupling/place_the_chain")));
			trainTutorialConstructor.Phase.Add(new CouplerTightenStep(coupler, coupler2, new ControlIconQuickTutorialMessage(LocalizationAPI.L("tutorial/coupling/tighten"), LocalizationAPI.L("tutorial/coupling/screw_description"), 3), tight: true));
			trainTutorialConstructor.Phase.Add(new WaitStep(0.5f));
			if (componentInChildren2 != null && componentInChildren3 != null)
			{
				trainTutorialConstructor.Phase.Add(new GrabGizmoStep(componentInChildren2.gameObject, componentInChildren3.gameObject, new ControlIconQuickTutorialMessage(LocalizationAPI.L("hud/hose"), LocalizationAPI.L("tutorial/coupling/hose_description"), 3)));
				trainTutorialConstructor.Phase.Add(new CoupleHoseStep(coupler2.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>(), coupler.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>(), componentInChildren3.gameObject, componentInChildren2.gameObject, LocalizationAPI.L("tutorial/coupling/connect_hose")));
				trainTutorialConstructor.Phase.LastStep.SetCheckingCondition(new HoseConnectedCondition(componentInChildren2), desiredValueToCheck: false);
			}
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.PhaseSkipCondition = new HoseConnectedCondition(componentInChildren2, coupler, coupler2);
			trainTutorialConstructor.Phase.Add(new CouplersCloseStep(coupler, coupler2, LocalizationAPI.L("tutorial/coupling/too_far")));
			trainTutorialConstructor.Phase.Add(new CoupleCouplerStep(coupler2, coupler, chain.GetComponentInChildren<ControlImplBase>(), chain2.GetComponentInChildren<ControlImplBase>(), LocalizationAPI.L("tutorial/coupling/place_the_chain")));
			trainTutorialConstructor.Phase.Add(new CouplerTightenStep(coupler, coupler2, new ControlIconQuickTutorialMessage(LocalizationAPI.L("tutorial/coupling/tighten"), LocalizationAPI.L("tutorial/coupling/screw_description"), 3), tight: true));
			if (componentInChildren2 != null && componentInChildren3 != null)
			{
				trainTutorialConstructor.Phase.Add(new CoupleHoseStep(coupler2.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>(), coupler.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>(), componentInChildren3.gameObject, componentInChildren2.gameObject, LocalizationAPI.L("tutorial/coupling/connect_hose")));
			}
			trainTutorialConstructor.Phase.Add(new WaitStep(0.5f));
			trainTutorialConstructor.Phase.Add(new CockOpenStep(coupler, new ControlIconQuickTutorialMessage(LocalizationAPI.L("tutorial/coupling/brake_angle_cock"), LocalizationAPI.L("tutorial/coupling/cock_description"), 4), open: true));
			trainTutorialConstructor.Phase.Add(new WaitStep(0.5f));
			trainTutorialConstructor.Phase.Add(new CockOpenStep(coupler2, new ControlIconQuickTutorialMessage(LocalizationAPI.L("tutorial/coupling/brake_angle_cock"), LocalizationAPI.L("tutorial/coupling/cock_description"), 4), open: true));
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.Add(new WaitStep(0.5f));
			if (coupler.train.IsLoco && coupler2.train.IsLoco)
			{
				CouplingHoseMultipleUnitAdapter componentInChildren4 = coupler.visualCoupler.hoses.GetComponentInChildren<CouplingHoseMultipleUnitAdapter>();
				CouplingHoseMultipleUnitAdapter componentInChildren5 = coupler2.visualCoupler.hoses.GetComponentInChildren<CouplingHoseMultipleUnitAdapter>();
				if (componentInChildren4 != null && componentInChildren5 != null && !componentInChildren4.IsConnected)
				{
					if (SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(GeneralLicenseType.MultipleUnit.ToV2()))
					{
						trainTutorialConstructor.Phase.Add(new CouplersCloseStep(coupler, coupler2, LocalizationAPI.L("tutorial/coupling/too_far")));
						trainTutorialConstructor.Phase.Add(new CoupleCouplerStep(coupler2, coupler, chain.GetComponentInChildren<ControlImplBase>(), chain2.GetComponentInChildren<ControlImplBase>(), LocalizationAPI.L("tutorial/coupling/place_the_chain")));
						trainTutorialConstructor.Phase.Add(new CouplerTightenStep(coupler, coupler2, new ControlIconQuickTutorialMessage(LocalizationAPI.L("tutorial/coupling/tighten"), LocalizationAPI.L("tutorial/coupling/screw_description"), 3), tight: true));
						trainTutorialConstructor.Phase.Add(new CoupleHoseStep(coupler2.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>(), coupler.visualCoupler.hoses.GetComponentInChildren<CouplingHoseCouplerAdapter>(), componentInChildren5.gameObject, componentInChildren4.gameObject, LocalizationAPI.L("tutorial/coupling/connect_hose")));
						trainTutorialConstructor.Phase.Add(new CockOpenStep(coupler, LocalizationAPI.L("tutorial/coupling/valve_1"), open: true));
						trainTutorialConstructor.Phase.Add(new CockOpenStep(coupler2, LocalizationAPI.L("tutorial/coupling/valve_2"), open: true));
						trainTutorialConstructor.Phase.Add(new GrabGizmoStep(componentInChildren4.gameObject, componentInChildren5.gameObject, new ControlIconQuickTutorialMessage(LocalizationAPI.L("tutorial/coupling/mu_cable"), LocalizationAPI.L("tutorial/coupling/mu_description"), 3)));
						trainTutorialConstructor.Phase.Add(new CoupleHoseStep(coupler2.visualCoupler.hoses.GetComponentInChildren<CouplingHoseMultipleUnitAdapter>(), coupler.visualCoupler.hoses.GetComponentInChildren<CouplingHoseMultipleUnitAdapter>(), componentInChildren5.gameObject, componentInChildren4.gameObject, LocalizationAPI.L("tutorial/coupling/connect_hose")));
					}
					else
					{
						trainTutorialConstructor.AddLookAndAcknowledge(componentInChildren4.GetComponentInChildren<Gizmo>(includeInactive: true), LocalizationAPI.L("tutorial/coupling/mu_cable"), LocalizationAPI.L("tutorial/coupling/no_mu_license"));
					}
				}
			}
			else if (coupler.train.IsLoco)
			{
				CouplingHoseMultipleUnitAdapter componentInChildren6 = coupler.visualCoupler.hoses.GetComponentInChildren<CouplingHoseMultipleUnitAdapter>();
				if ((bool)componentInChildren6)
				{
					trainTutorialConstructor.AddLookAndAcknowledge(componentInChildren6.GetComponentInChildren<Gizmo>(includeInactive: true), LocalizationAPI.L("tutorial/coupling/mu_cable"), LocalizationAPI.L("tutorial/coupling/no_mu_license"));
				}
			}
			else if (coupler2.train.IsLoco)
			{
				CouplingHoseMultipleUnitAdapter componentInChildren7 = coupler2.visualCoupler.hoses.GetComponentInChildren<CouplingHoseMultipleUnitAdapter>();
				if ((bool)componentInChildren7)
				{
					trainTutorialConstructor.AddLookAndAcknowledge(componentInChildren7.GetComponentInChildren<Gizmo>(includeInactive: true), LocalizationAPI.L("tutorial/coupling/mu_cable"), LocalizationAPI.L("tutorial/coupling/no_mu_license"));
				}
			}
			if (announceCompletion)
			{
				trainTutorialConstructor.BeginNewPhase();
				trainTutorialConstructor.Phase.Add(new WaitStep(1f));
				trainTutorialConstructor.AddPrompt("tutorial/coupling/completed", pause: false);
			}
			return trainTutorialConstructor.Tutorial;
		}

		public static QuickTutorial CareerDebtPayingTutorial(GameObject careerManagerGO, string locoID)
		{
			TrainTutorialConstructor trainTutorialConstructor = new TrainTutorialConstructor(null, userControlAllowed: false);
			trainTutorialConstructor.Tutorial.AddStartingCheck(new HasDebtToPayCondition(locoID));
			trainTutorialConstructor.BeginNewPhase();
			trainTutorialConstructor.Phase.Add(new CareerManagerDebtPayingStep(careerManagerGO, locoID));
			return trainTutorialConstructor.Tutorial;
		}

		public static QuickTutorial ManualTutorial()
		{
			QuickTutorial quickTutorial = new QuickTutorial(userControlAllowed: false);
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.Inventory, out var element);
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.PauseMenu, out var element2);
			InventoryUIController componentInChildren = element.reference.GetComponentInChildren<InventoryUIController>();
			PauseMenuController componentInChildren2 = element2.reference.GetComponentInChildren<PauseMenuController>();
			UIMenuController submenuController = componentInChildren2.submenuController;
			if (VRManager.IsVREnabled())
			{
				QuickTutorialPhase quickTutorialPhase = new QuickTutorialPhase();
				quickTutorialPhase.Add(new OpenCanvasElementStep(CanvasController.ElementType.Inventory, LocalizationAPI.L("tutorial/p3c03/manual")));
				quickTutorial.Add(quickTutorialPhase);
			}
			QuickTutorialPhase quickTutorialPhase2 = new QuickTutorialPhase();
			if (VRManager.IsVREnabled())
			{
				quickTutorialPhase2.Add(new OpenCanvasElementStep(CanvasController.ElementType.PauseMenu, LocalizationAPI.L("tutorial/p3c03/manual"), componentInChildren.menuButton.transform));
			}
			else
			{
				quickTutorialPhase2.Add(new OpenCanvasElementStep(CanvasController.ElementType.PauseMenu, LocalizationAPI.L("tutorial/p3c03/manual")));
			}
			quickTutorialPhase2.Add(new SubmenuSelectedStep(submenuController, 0, 3, LocalizationAPI.L("tutorial/pause/open_manual"), LocalizationAPI.L("tutorial/pause/go_back"), componentInChildren2.manualButton.transform));
			quickTutorial.Add(quickTutorialPhase2);
			QuickTutorialPhase quickTutorialPhase3 = new QuickTutorialPhase();
			quickTutorialPhase3.Add(new UIBlockersClearedStep(LocalizationAPI.L("tutorial/pause/manual_info")));
			quickTutorial.Add(quickTutorialPhase3);
			return quickTutorial;
		}

		public static QuickTutorial QTsTutorial()
		{
			QuickTutorial quickTutorial = new QuickTutorial(userControlAllowed: false);
			quickTutorial.Add(new MetaTutorialHackService());
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.Inventory, out var element);
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TryGetElement(CanvasController.ElementType.PauseMenu, out var element2);
			InventoryUIController componentInChildren = element.reference.GetComponentInChildren<InventoryUIController>();
			PauseMenuController componentInChildren2 = element2.reference.GetComponentInChildren<PauseMenuController>();
			UIMenuController submenuController = componentInChildren2.submenuController;
			TutorialsMenuController tutorialsMenuController = componentInChildren2.tutorialsMenuController;
			if (VRManager.IsVREnabled())
			{
				QuickTutorialPhase quickTutorialPhase = new QuickTutorialPhase();
				quickTutorialPhase.Add(new OpenCanvasElementStep(CanvasController.ElementType.Inventory, LocalizationAPI.L("tutorial/open_pause_vr")));
				quickTutorial.Add(quickTutorialPhase);
			}
			QuickTutorialPhase quickTutorialPhase2 = new QuickTutorialPhase();
			if (VRManager.IsVREnabled())
			{
				quickTutorialPhase2.Add(new OpenCanvasElementStep(CanvasController.ElementType.PauseMenu, LocalizationAPI.L("tutorial/open_pause_vr"), componentInChildren.menuButton.transform));
			}
			else
			{
				quickTutorialPhase2.Add(new OpenCanvasElementStep(CanvasController.ElementType.PauseMenu, LocalizationAPI.L("tutorial/open_pause")));
			}
			quickTutorialPhase2.Add(new SubmenuSelectedStep(submenuController, 0, 5, LocalizationAPI.L("tutorial/pause/open_qt"), LocalizationAPI.L("tutorial/pause/go_back"), componentInChildren2.tutorialsButton.transform));
			quickTutorial.Add(quickTutorialPhase2);
			QuickTutorialPhase quickTutorialPhase3 = new QuickTutorialPhase();
			quickTutorialPhase3.Add(new UIBlockersClearedStep(LocalizationAPI.L("tutorial/pause/launch_qt"), tutorialsMenuController.runLocoTut.transform));
			quickTutorial.Add(quickTutorialPhase3);
			return quickTutorial;
		}

		public static QuickTutorial MountGadgetTutorial(Collider[] allowedPlacement, ItemBase[] toolItems, ItemBase[] mountItems, ItemBase[] gadgetItems, float mountAngleLimit, string mountPrefabName, string gadgetPrefabName, MountingMode mode, string locEquipMount, string locPlaceMount, string locEquipTool, string locMountPoint, string locEquipGadget, string locPlaceGadget)
		{
			QuickTutorial quickTutorial = new QuickTutorial(userControlAllowed: false);
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.SolderingGadgets, enabled: false));
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.WiringGadgets, enabled: false));
			mountItems = ((mountItems != null) ? mountItems.Where(delegate(ItemBase g)
			{
				GadgetItem gadgetItem = (g ? g.GetComponent<GadgetItem>() : null);
				return (bool)gadgetItem && gadgetItem.Gadget.Custom == null;
			}).ToArray() : Array.Empty<ItemBase>());
			gadgetItems = ((gadgetItems != null) ? gadgetItems.Where(delegate(ItemBase g)
			{
				GadgetItem gadgetItem = (g ? g.GetComponent<GadgetItem>() : null);
				return (bool)gadgetItem && gadgetItem.Gadget.Custom == null;
			}).ToArray() : Array.Empty<ItemBase>());
			GameObject[] array = mountItems.Select((ItemBase i) => i.gameObject).ToArray();
			GameObject[] array2 = gadgetItems.Select((ItemBase i) => i.gameObject).ToArray();
			if (allowedPlacement != null)
			{
				quickTutorial.Add(new GadgetMountingLimitationService(allowedPlacement, mountAngleLimit, strictMode: true));
			}
			PlaceGadgetStep placeMountStep = null;
			string[] allowedTools;
			switch (mode)
			{
			case MountingMode.Drill:
				allowedTools = new string[1] { "HandDrill" };
				break;
			case MountingMode.Tape:
				allowedTools = new string[1] { "DuctTape" };
				break;
			default:
				allowedTools = new string[2] { "HandDrill", "DuctTape" };
				break;
			}
			List<string> list = new List<string>();
			if (array.Length != 0)
			{
				list.Add(mountPrefabName);
			}
			string[] mountNames = list.ToArray();
			if (array2.Length != 0)
			{
				list.Add(gadgetPrefabName);
			}
			string[] gadgetPrefabNames = list.ToArray();
			string[] finalGadget = new string[1] { gadgetPrefabName };
			quickTutorial.Add(new GadgetUsageLimitationService(gadgetPrefabNames));
			if (array.Length != 0)
			{
				QuickTutorialPhase quickTutorialPhase = new QuickTutorialPhase();
				quickTutorialPhase.Add(new EquipItemStep(mountPrefabName, mountItems, LocalizationAPI.L(locEquipMount)));
				placeMountStep = new PlaceGadgetStep(array, LocalizationAPI.L(locPlaceMount), (allowedPlacement != null && allowedPlacement.Length != 0) ? allowedPlacement[0].transform : null);
				quickTutorialPhase.Add(placeMountStep);
				quickTutorialPhase.Add(new EquipItemStep(allowedTools, toolItems, LocalizationAPI.L(locEquipTool)));
				quickTutorialPhase.Add(new DrillablePointsStateStep(() => placeMountStep.PlacedGadget.GetComponent<Drillable>(), targetState: true, LocalizationAPI.L(locMountPoint)));
				quickTutorialPhase.Add(new GadgetUsageLimitationService(() => (!placeMountStep.PlacedGadget) ? mountNames : allowedTools));
				quickTutorial.Add(quickTutorialPhase);
			}
			if (array2.Length != 0)
			{
				QuickTutorialPhase quickTutorialPhase2 = new QuickTutorialPhase();
				quickTutorialPhase2.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.HammeringGadgets, enabled: false));
				if (array.Length != 0)
				{
					quickTutorialPhase2.Add(placeMountStep);
					quickTutorialPhase2.Add(new DrillablePointsStateStep(() => placeMountStep.PlacedGadget.GetComponent<Drillable>(), targetState: true, LocalizationAPI.L(locMountPoint)));
				}
				quickTutorialPhase2.Add(new EquipItemStep(gadgetPrefabName, gadgetItems, LocalizationAPI.L(locEquipGadget)));
				quickTutorialPhase2.Add(new PlaceGadgetStep(array2, LocalizationAPI.L(locPlaceGadget), () => (placeMountStep != null) ? (placeMountStep.PlacedGadget.transform, Vector3.zero) : ((allowedPlacement != null && allowedPlacement.Length != 0) ? allowedPlacement[0].transform : null, Vector3.zero)));
				quickTutorialPhase2.Add(new GadgetUsageLimitationService(delegate
				{
					if (placeMountStep != null && placeMountStep.PlacedGadget == null)
					{
						return mountNames;
					}
					Drillable drillable = placeMountStep?.PlacedGadget.GetComponent<Drillable>();
					return (drillable != null && drillable.AttachedPointCount < drillable.MountPointCount) ? allowedTools : finalGadget;
				}));
				quickTutorial.Add(quickTutorialPhase2);
			}
			return quickTutorial;
		}

		public static QuickTutorial SolderGadgetTutorial(GameObject targetGadget, ItemBase[] toolItems, ItemBase[] reelItems, string locEquipSolderingGun, string locUnloadSolderingGun, string locLoadInInventory, string locEquipCoil, string locLoadCoil, string locSolder)
		{
			QuickTutorial quickTutorial = new QuickTutorial(userControlAllowed: false);
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.MountingGadgets, enabled: false));
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.HammeringGadgets, enabled: false));
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.WiringGadgets, enabled: false));
			GadgetBase componentInChildren = targetGadget.GetComponentInChildren<GadgetBase>();
			quickTutorial.Add(new GadgetSolderingLimitationService(new GadgetBase[1] { componentInChildren }));
			quickTutorial.Add(new GadgetUsageLimitationService(new string[1] { "SolderingGun" }));
			EquipItemStep equipSolderingGun = null;
			reelItems = ((reelItems != null) ? reelItems.Where(delegate(ItemBase r)
			{
				InventoryItemSpec inventoryItemSpec = (r ? r.GetComponent<InventoryItemSpec>() : null);
				return (bool)r && (bool)inventoryItemSpec && inventoryItemSpec.ItemPrefabName == "SolderingWireReel";
			}).ToArray() : Array.Empty<ItemBase>());
			QuickTutorialPhase quickTutorialPhase = new QuickTutorialPhase();
			equipSolderingGun = new EquipItemStep("SolderingGun", toolItems, LocalizationAPI.L(locEquipSolderingGun));
			quickTutorialPhase.Add(equipSolderingGun);
			quickTutorialPhase.Add(new LoadSolderingGunStep(() => equipSolderingGun.EquippedItem.GetComponentInChildren<GadgetSolderingTool>(), LocalizationAPI.L(locUnloadSolderingGun), okIfFull: true, okIfNoCoil: true));
			quickTutorial.Add(quickTutorialPhase);
			QuickTutorialPhase quickTutorialPhase2 = new QuickTutorialPhase();
			quickTutorialPhase2.PhaseSkipCondition = new SolderingGunFullCondition(() => equipSolderingGun.EquippedItem.GetComponentInChildren<GadgetSolderingTool>());
			if (VRManager.IsVREnabled())
			{
				quickTutorialPhase2.Add(new EquipItemStep("SolderingWireReel", reelItems, LocalizationAPI.L(locEquipCoil)));
				quickTutorialPhase2.Add(new LoadSolderingGunStep(() => equipSolderingGun.EquippedItem.GetComponentInChildren<GadgetSolderingTool>(), LocalizationAPI.L(locLoadCoil), okIfFull: true, okIfNoCoil: false));
			}
			else
			{
				quickTutorialPhase2.Add(new LoadContainerThroughInventoryStep(LocalizationAPI.L(locLoadInInventory), reelItems, () => equipSolderingGun.EquippedItem.GetComponent<ItemBase>(), oneIsEnough: true));
			}
			quickTutorialPhase2.Add(new EquipItemStep(() => equipSolderingGun.EquippedItem, LocalizationAPI.L(locEquipSolderingGun)));
			quickTutorial.Add(quickTutorialPhase2);
			QuickTutorialPhase quickTutorialPhase3 = new QuickTutorialPhase();
			quickTutorialPhase3.Add(new EquipItemStep(() => equipSolderingGun.EquippedItem, LocalizationAPI.L(locEquipSolderingGun)));
			quickTutorialPhase3.Add(new SolderGadgetStep(componentInChildren, LocalizationAPI.L(locSolder)));
			quickTutorial.Add(quickTutorialPhase3);
			return quickTutorial;
		}

		public static QuickTutorial WiringTutorial(GameObject gadgetObject1, GameObject gadgetObject2, ItemBase[] crimpingItems, string locEquipCrimpingTool, string locConnectOne, string locConnectOther)
		{
			QuickTutorial quickTutorial = new QuickTutorial(userControlAllowed: false);
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.MountingGadgets, enabled: false));
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.HammeringGadgets, enabled: false));
			quickTutorial.Add(new GameFeatureFlagControlService(GameFeatureFlags.Flag.SolderingGadgets, enabled: false));
			quickTutorial.Add(new GadgetUsageLimitationService(new string[1] { "CrimpingTool" }));
			GadgetBase componentInChildren = gadgetObject1.GetComponentInChildren<GadgetBase>();
			GadgetBase componentInChildren2 = gadgetObject2.GetComponentInChildren<GadgetBase>();
			quickTutorial.Add(new GadgetWiringLimitationService(new GadgetBase[2] { componentInChildren, componentInChildren2 }));
			QuickTutorialPhase quickTutorialPhase = new QuickTutorialPhase();
			EquipItemStep equipTool = new EquipItemStep("CrimpingTool", crimpingItems, LocalizationAPI.L(locEquipCrimpingTool));
			quickTutorialPhase.Add(equipTool);
			quickTutorialPhase.Add(new ConnectGadgetsStep(() => equipTool.EquippedItem.GetComponent<GadgetWiringTool>(), componentInChildren, componentInChildren2, LocalizationAPI.L(locConnectOne), LocalizationAPI.L(locConnectOther)));
			quickTutorial.Add(quickTutorialPhase);
			return quickTutorial;
		}
	}
}
