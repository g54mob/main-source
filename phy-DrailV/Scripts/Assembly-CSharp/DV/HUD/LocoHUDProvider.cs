using System;
using System.Collections.Generic;
using DV.CabControls;
using DV.Localization;
using DV.Simulation.Cars;
using DV.UI.LocoHUD;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.HUD
{
	public class LocoHUDProvider : MonoBehaviour
	{
		private struct IndicatorWrapper
		{
			public Indicator indicator;

			public Action<float> meterValue;

			public Action<float> meterIndicator;

			public IndicatorWrapper(Indicator indicator, Action<float> meterValue, Action<float> meterIndicator)
			{
				this.indicator = indicator;
				this.meterValue = meterValue;
				this.meterIndicator = meterIndicator;
			}
		}

		private HUDLocoControls locoControls;

		private BaseControlsOverrider baseControls;

		private InteriorControlsManager controlsManager;

		private bool hornNeutralAt0;

		private bool electricsFuseOn;

		private Indicator waterInCylinder;

		private Indicator cylCocksPopped;

		private LampControl automaticLubricatorLampControl;

		private LampControl manualLubricatorLampControl;

		private List<IndicatorWrapper> indicators = new List<IndicatorWrapper>();

		private void Start()
		{
			SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged += HUDChanged;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged -= HUDChanged;
			}
		}

		public void Sub(object target)
		{
			if (target != null)
			{
				if (target is LocoIndicatorReader ir)
				{
					SubIndicators(ir);
				}
				else if (target is LocoLampReader lr)
				{
					SubLamps(lr);
				}
				else if (target is LocoControlsReader lcr)
				{
					SubControls(lcr);
				}
				else if (target is InteriorControlsManager icm)
				{
					SubControlsManager(icm);
				}
			}
		}

		public void Unsub(object target)
		{
			if (target != null)
			{
				if (target is LocoIndicatorReader ir)
				{
					UnsubIndicators(ir);
				}
				else if (target is LocoLampReader lr)
				{
					UnsubLamps(lr);
				}
				else if (target is LocoControlsReader lcr)
				{
					UnsubControls(lcr);
				}
				else if (target is InteriorControlsManager icm)
				{
					UnsubControlsManager(icm);
				}
			}
		}

		private void SubControls(LocoControlsReader lcr)
		{
			SubscribeControlEvent(lcr.cabLight, locoControls.cab.cabLight, CabLightUpdated);
			SubscribeControlEvent(lcr.wipers, locoControls.cab.wipers, WipersUpdated);
			SubscribeControlEvent(lcr.fuelCutoff, locoControls.mechanical.fuelCutoff, FuelCutoffUpdated);
			SubscribeControlEvent(lcr.indHeadlightsTypeFront, locoControls.cab.indHeadlightsTypeFront, IndHeadlightsTypeFrontUpdated);
			SubscribeControlEvent(lcr.indHeadlights1Front, locoControls.cab.indHeadlights1Front, IndHeadlights1FrontUpdated);
			SubscribeControlEvent(lcr.indHeadlights2Front, locoControls.cab.indHeadlights2Front, IndHeadlights2FrontUpdated);
			SubscribeControlEvent(lcr.indHeadlightsTypeRear, locoControls.cab.indHeadlightsTypeRear, IndHeadlightsTypeRearUpdated);
			SubscribeControlEvent(lcr.indHeadlights1Rear, locoControls.cab.indHeadlights1Rear, IndHeadlights1RearUpdated);
			SubscribeControlEvent(lcr.indHeadlights2Rear, locoControls.cab.indHeadlights2Rear, IndHeadlights2RearUpdated);
			SubscribeControlEvent(lcr.indWipers1, locoControls.cab.indWipers1, IndWipers1Updated);
			SubscribeControlEvent(lcr.indWipers2, locoControls.cab.indWipers2, IndWipers2Updated);
			SubscribeControlEvent(lcr.indCabLight, locoControls.cab.indCabLight, IndCabLightUpdated);
			SubscribeControlEvent(lcr.indDashLight, locoControls.cab.indDashLight, IndDashLightUpdated);
			SubscribeControlEvent(lcr.headlightsFront, locoControls.cab.headlightsFront, HeadlightsVisualUpdatedFront);
			SubscribeControlEvent(lcr.headlightsRear, locoControls.cab.headlightsRear, HeadlightsVisualUpdatedRear);
			SubscribeControlEvent(lcr.gearboxA, locoControls.basicControls.gearboxA, GearboxAUpdated);
			SubscribeControlEvent(lcr.gearboxB, locoControls.basicControls.gearboxB, GearboxBUpdated);
			SubscribeControlEvent(lcr.cylCock, locoControls.steam.cylCock, CylCockUpdated);
			SubscribeControlEvent(lcr.injector, locoControls.steam.injector, InjectorUpdated);
			SubscribeControlEvent(lcr.firedoor, locoControls.steam.firedoor, FiredoorUpdated);
			SubscribeControlEvent(lcr.blower, locoControls.steam.blower, BlowerUpdated);
			SubscribeControlEvent(lcr.damper, locoControls.steam.damper, DamperUpdated);
			SubscribeControlEvent(lcr.blowdown, locoControls.steam.blowdown, BlowdownUpdated);
			SubscribeControlEvent(lcr.coalDump, locoControls.steam.coalDump, CoalDumpUpdated);
			SubscribeControlEvent(lcr.lubricator, locoControls.steam.lubricator, LubricatorUpdated);
			SubscribeControlEvent(lcr.bell, locoControls.cab.bell, BellUpdated);
			void SubscribeControlEvent(GameObject control, LocoHUDControlBase hudElement, Action<ValueChangedEventArgs> action)
			{
				if ((bool)hudElement && (bool)control && control.TryGetComponent<ControlImplBase>(out var component))
				{
					component.ValueChanged += action;
					action?.Invoke(new ValueChangedEventArgs(0f, component.Value));
				}
			}
		}

		private void UnsubControls(LocoControlsReader lcr)
		{
			UnsubscribeControlEvent(lcr.cabLight, CabLightUpdated);
			UnsubscribeControlEvent(lcr.wipers, WipersUpdated);
			UnsubscribeControlEvent(lcr.fuelCutoff, FuelCutoffUpdated);
			UnsubscribeControlEvent(lcr.indHeadlightsTypeFront, IndHeadlightsTypeFrontUpdated);
			UnsubscribeControlEvent(lcr.indHeadlights1Front, IndHeadlights1FrontUpdated);
			UnsubscribeControlEvent(lcr.indHeadlights2Front, IndHeadlights2FrontUpdated);
			UnsubscribeControlEvent(lcr.indHeadlightsTypeRear, IndHeadlightsTypeRearUpdated);
			UnsubscribeControlEvent(lcr.indHeadlights1Rear, IndHeadlights1RearUpdated);
			UnsubscribeControlEvent(lcr.indHeadlights2Rear, IndHeadlights2RearUpdated);
			UnsubscribeControlEvent(lcr.indWipers1, IndWipers1Updated);
			UnsubscribeControlEvent(lcr.indWipers2, IndWipers2Updated);
			UnsubscribeControlEvent(lcr.indCabLight, IndCabLightUpdated);
			UnsubscribeControlEvent(lcr.indDashLight, IndDashLightUpdated);
			UnsubscribeControlEvent(lcr.headlightsFront, HeadlightsVisualUpdatedFront);
			UnsubscribeControlEvent(lcr.headlightsRear, HeadlightsVisualUpdatedRear);
			UnsubscribeControlEvent(lcr.gearboxA, GearboxAUpdated);
			UnsubscribeControlEvent(lcr.gearboxB, GearboxBUpdated);
			UnsubscribeControlEvent(lcr.cylCock, CylCockUpdated);
			UnsubscribeControlEvent(lcr.injector, InjectorUpdated);
			UnsubscribeControlEvent(lcr.firedoor, FiredoorUpdated);
			UnsubscribeControlEvent(lcr.blower, BlowerUpdated);
			UnsubscribeControlEvent(lcr.damper, DamperUpdated);
			UnsubscribeControlEvent(lcr.blowdown, BlowdownUpdated);
			UnsubscribeControlEvent(lcr.coalDump, CoalDumpUpdated);
			UnsubscribeControlEvent(lcr.lubricator, LubricatorUpdated);
			UnsubscribeControlEvent(lcr.bell, BellUpdated);
			void UnsubscribeControlEvent(GameObject control, Action<ValueChangedEventArgs> action)
			{
				if ((bool)control && control.TryGetComponent<ControlImplBase>(out var component))
				{
					component.ValueChanged -= action;
				}
			}
		}

		private void SubControlsManager(InteriorControlsManager icm)
		{
			SubscribeControlEvent(InteriorControlsManager.ControlType.StarterFuse, locoControls.mechanical.starterFuse, StarterFuseUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.ElectricsFuse, locoControls.mechanical.electricsFuse, ElectricsFuseUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.TractionMotorFuse, locoControls.mechanical.tractionMotorFuse, TractionMotorFuseUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.StarterControl, locoControls.mechanical.starterControl, StarterControlUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.DynamicBrake, locoControls.braking.dynBrake, DynamicBrakeUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.HeadlightsFront, locoControls.cab.headlightsFront, HeadlightsVisualUpdatedFront);
			SubscribeControlEvent(InteriorControlsManager.ControlType.HeadlightsRear, locoControls.cab.headlightsRear, HeadlightsVisualUpdatedRear);
			SubscribeControlEvent(InteriorControlsManager.ControlType.Horn, locoControls.cab.horn, HornVisualUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.TrainBrake, locoControls.braking.trainBrake, TrainBrakeVisualUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.Sander, locoControls.basicControls.sand, SandVisualUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.Throttle, locoControls.basicControls.throttle, ThrottleVisualUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.Reverser, locoControls.basicControls.reverser, ReverserVisualUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.ReleaseCyl, locoControls.braking.releaseCyl, ReleaseCylVisualUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.IndBrake, locoControls.braking.indBrake, IndBrakeVisualUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.TrainBrakeCutout, locoControls.braking.brakeCutout, BrakeCutoutUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.Dynamo, locoControls.steam.dynamo, DynamoUpdated);
			SubscribeControlEvent(InteriorControlsManager.ControlType.AirPump, locoControls.steam.airPump, AirPumpUpdated);
			if ((bool)locoControls.braking.handbrake && baseControls.Handbrake != null)
			{
				baseControls.Handbrake.ControlUpdated += HandbrakeVisualUpdated;
				HandbrakeVisualUpdated(baseControls.Handbrake.Value);
			}
			void SubscribeControlEvent(InteriorControlsManager.ControlType type, LocoHUDControlBase locoControl, Action<ValueChangedEventArgs> action)
			{
				if ((bool)locoControl && icm.TryGetControl(type, out var reference))
				{
					reference.controlImplBase.ValueChanged += action;
					action?.Invoke(new ValueChangedEventArgs(0f, reference.controlImplBase.Value));
				}
			}
		}

		private void UnsubControlsManager(InteriorControlsManager icm)
		{
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.StarterFuse, StarterFuseUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.ElectricsFuse, ElectricsFuseUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.TractionMotorFuse, TractionMotorFuseUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.StarterControl, StarterControlUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.DynamicBrake, DynamicBrakeUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.HeadlightsFront, HeadlightsVisualUpdatedFront);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.HeadlightsRear, HeadlightsVisualUpdatedRear);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.Horn, HornVisualUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.TrainBrake, TrainBrakeVisualUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.Sander, SandVisualUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.Throttle, ThrottleVisualUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.Reverser, ReverserVisualUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.ReleaseCyl, ReleaseCylVisualUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.IndBrake, IndBrakeVisualUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.TrainBrakeCutout, BrakeCutoutUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.Dynamo, DynamoUpdated);
			UnsubscribeControlEvent(InteriorControlsManager.ControlType.AirPump, AirPumpUpdated);
			BaseControlsOverrider controlsOverrider = icm.Car.SimController.controlsOverrider;
			if (controlsOverrider.Handbrake != null)
			{
				controlsOverrider.Handbrake.ControlUpdated -= HandbrakeVisualUpdated;
			}
			void UnsubscribeControlEvent(InteriorControlsManager.ControlType type, Action<ValueChangedEventArgs> action)
			{
				if (icm.TryGetControl(type, out var reference))
				{
					reference.controlImplBase.ValueChanged -= action;
				}
			}
		}

		private void SubLamps(LocoLampReader lr)
		{
			if ((bool)locoControls.basicControls.tmTempMeter)
			{
				DoLamp(lr.engineTemp, TMTempLightUpdated);
			}
			if ((bool)locoControls.basicControls.oilTempMeter)
			{
				DoLamp(lr.oilTemp, OilTempLightUpdated);
			}
			if ((bool)locoControls.basicControls.ampMeter)
			{
				DoLamp(lr.amp, AmpLampUpdated);
			}
			if ((bool)locoControls.basicControls.rpmMeter)
			{
				DoLamp(lr.rpm, RpmLampUpdated);
			}
			if ((bool)locoControls.basicControls.turbineRpmMeter)
			{
				DoLamp(lr.turbineRpm, TurbineRpmLampUpdated);
			}
			if ((bool)locoControls.basicControls.voltageMeter)
			{
				DoLamp(lr.voltage, VoltageLampUpdated);
			}
			if ((bool)locoControls.basicControls.powerMeter)
			{
				DoLamp(lr.availablePower, AvailablePowerLampUpdated);
			}
			if ((bool)locoControls.basicControls.wheelSlipIndicator)
			{
				DoLamp(lr.wheelSlip, WheelslipLampUpdated);
			}
			if ((bool)locoControls.basicControls.sand)
			{
				DoLamp(lr.sandDeploying, SandLampUpdated);
			}
			if ((bool)locoControls.cab.sandMeter)
			{
				DoLamp(lr.sandLow, SandLevelLampUpdated);
			}
			if ((bool)locoControls.cab.fuelLevelMeter)
			{
				DoLamp(lr.fuel, FuelLevelLampUpdated);
			}
			if ((bool)locoControls.cab.batteryLevelMeter)
			{
				DoLamp(lr.battery, BatteryLevelLampUpdated);
			}
			if ((bool)locoControls.cab.oilLevelMeter)
			{
				DoLamp(lr.oil, OilLevelLampUpdated);
			}
			if ((bool)locoControls.cab.cabLight)
			{
				DoLamp(lr.cabLight, CabLightLampUpdated);
			}
			if ((bool)locoControls.cab.headlightsFront)
			{
				DoLamp(lr.headlightsFront, HeadlightsFrontLampUpdated);
			}
			if ((bool)locoControls.cab.headlightsRear)
			{
				DoLamp(lr.headlightsRear, HeadlightsRearLampUpdated);
			}
			if ((bool)locoControls.cab.wipers)
			{
				DoLamp(lr.wipers, WipersLampUpdated);
			}
			if ((bool)locoControls.braking.brakePipeMeter)
			{
				DoLamp(lr.brakePipe, BrakePipeLampUpdated);
			}
			if ((bool)locoControls.braking.mainResMeter)
			{
				DoLamp(lr.mainRes, MainResLampUpdated);
			}
			if ((bool)locoControls.braking.brakeCylMeter)
			{
				DoLamp(lr.brakeCyl, BrakeCylLampUpdated);
			}
			if ((bool)locoControls.mechanical.tmOfflineIndicator)
			{
				DoLamp(lr.tmOffline, TMOffUpdated);
			}
			if ((bool)locoControls.mechanical.electricsFuse)
			{
				DoLamp(lr.electronics, ElectronicsLampUpdated);
			}
			if ((bool)locoControls.steam.lubricator)
			{
				manualLubricatorLampControl = lr.manualLubricator;
				DoLamp(lr.manualLubricator, LubricatorLampUpdated);
				automaticLubricatorLampControl = lr.automaticLubricator;
				DoLamp(lr.automaticLubricator, LubricatorLampUpdated);
			}
			void DoLamp(LampControl lamp, Action<float> action)
			{
				if ((bool)lamp)
				{
					lamp.lampInd.ValueChanged += action;
					action?.Invoke(lamp.lampInd.Value);
				}
			}
		}

		private void UnsubLamps(LocoLampReader lr)
		{
			DoLamp(lr.engineTemp, TMTempLightUpdated);
			DoLamp(lr.oilTemp, OilTempLightUpdated);
			DoLamp(lr.amp, AmpLampUpdated);
			DoLamp(lr.rpm, RpmLampUpdated);
			DoLamp(lr.turbineRpm, TurbineRpmLampUpdated);
			DoLamp(lr.voltage, VoltageLampUpdated);
			DoLamp(lr.availablePower, AvailablePowerLampUpdated);
			DoLamp(lr.wheelSlip, WheelslipLampUpdated);
			DoLamp(lr.brakePipe, BrakePipeLampUpdated);
			DoLamp(lr.mainRes, MainResLampUpdated);
			DoLamp(lr.brakeCyl, BrakeCylLampUpdated);
			DoLamp(lr.sandDeploying, SandLampUpdated);
			DoLamp(lr.tmOffline, TMOffUpdated);
			DoLamp(lr.sandLow, SandLevelLampUpdated);
			DoLamp(lr.fuel, FuelLevelLampUpdated);
			DoLamp(lr.battery, BatteryLevelLampUpdated);
			DoLamp(lr.oil, OilLevelLampUpdated);
			DoLamp(lr.electronics, ElectronicsLampUpdated);
			DoLamp(lr.cabLight, CabLightLampUpdated);
			DoLamp(lr.headlightsFront, HeadlightsFrontLampUpdated);
			DoLamp(lr.headlightsRear, HeadlightsRearLampUpdated);
			DoLamp(lr.wipers, WipersLampUpdated);
			DoLamp(lr.automaticLubricator, LubricatorLampUpdated);
			DoLamp(lr.manualLubricator, LubricatorLampUpdated);
			void DoLamp(LampControl lamp, Action<float> action)
			{
				if ((bool)lamp)
				{
					lamp.lampInd.ValueChanged -= action;
				}
			}
		}

		private void SubIndicators(LocoIndicatorReader ir)
		{
			AddIndicator(ir.speed, SpeedometerUpdated, SpeedometerVisualUpdated);
			AddIndicator(ir.engineRpm, RpmMeterUpdated, RpmMeterVisualUpdated);
			AddIndicator(ir.turbineRpmMeter, TurbineRpmMeterUpdated, TurbineRpmMeterVisualUpdated);
			AddIndicator(ir.amps, AmpMeterUpdated, AmpMeterVisualUpdated);
			AddIndicator(ir.voltage, VoltageMeterUpdated, VoltageMeterVisualUpdated);
			AddIndicator(ir.availablePower, AvailablePowerMeterUpdated, AvailablePowerMeterVisualUpdated);
			AddIndicator(ir.tmTemp, TMTempUpdated, TMTempVisualUpdated);
			AddIndicator(ir.oilTemp, OilTempUpdated, OilTempVisualUpdated);
			AddIndicator(ir.brakePipe, BrakePipeMeterUpdated, BrakePipeMeterVisualUpdated);
			AddIndicator(ir.mainReservoir, MainResMeterUpdated, MainResMeterVisualUpdated);
			AddIndicator(ir.brakeCylinder, BrakeCylMeterUpdated, BrakeCylMeterVisualUpdated);
			AddIndicator(ir.sand, SandLevelMeterUpdated, SandLevelMeterVisualUpdated);
			AddIndicator(ir.fuel, FuelLevelMeterUpdated, FuelLevelMeterVisualUpdated);
			AddIndicator(ir.battery, BatteryLevelMeterUpdated, BatteryLevelMeterVisualUpdated);
			AddIndicator(ir.oil, OilLevelMeterUpdated, OilLevelMeterVisualUpdated);
			AddIndicator(ir.tenderCoalLevel, TenderCoalLevelUpdated, TenderCoalMeterVisualUpdated);
			AddIndicator(ir.tenderWaterLevel, TenderWaterLevelUpdated, TenderWaterMeterVisualUpdated);
			AddIndicator(ir.steam, SteamMeterUpdated, SteamMeterVisualUpdated);
			AddIndicator(ir.chestPressure, ChestPressureMeterUpdated, ChestPressureMeterVisualUpdated);
			AddIndicator(ir.locoWaterLevel, LocoWaterMeterUpdated, LocoWaterMeterVisualUpdated);
			AddIndicator(ir.locoCoalLevel, null, LocoCoalMeterVisualUpdated);
			AddIndicator(ir.fireTemperature, FireTemperatureUpdated, FireTemperatureVisualUpdated);
			if ((bool)ir.waterInCylinder)
			{
				AddIndicator(ir.waterInCylinder, CylinderCockStatusUpdated, null);
				waterInCylinder = ir.waterInCylinder;
			}
			if ((bool)ir.cylCocksPopped)
			{
				AddIndicator(ir.cylCocksPopped, CylinderCockStatusUpdated, null);
				cylCocksPopped = ir.cylCocksPopped;
			}
			void AddIndicator(Indicator indicator, Action<float> updateMeter, Action<float> updateMeterVisual)
			{
				if ((bool)indicator)
				{
					indicators.Add(new IndicatorWrapper(indicator, updateMeter, updateMeterVisual));
				}
				DoIndicator(indicator, updateMeter, updateMeterVisual);
			}
			void DoIndicator(Indicator indicator, Action<float> updateMeter, Action<float> updateMeterVisual)
			{
				if ((bool)indicator)
				{
					indicator.ValueChanged += updateMeter;
					indicator.NormalizedValueChanged += updateMeterVisual;
					updateMeter?.Invoke(indicator.Value);
					updateMeterVisual?.Invoke(indicator.NormalizedValue);
				}
			}
		}

		private void UnsubIndicators(LocoIndicatorReader ir)
		{
			DoIndicator(ir.speed, SpeedometerUpdated, SpeedometerVisualUpdated);
			DoIndicator(ir.engineRpm, RpmMeterUpdated, RpmMeterVisualUpdated);
			DoIndicator(ir.turbineRpmMeter, TurbineRpmMeterUpdated, TurbineRpmMeterVisualUpdated);
			DoIndicator(ir.amps, AmpMeterUpdated, AmpMeterVisualUpdated);
			DoIndicator(ir.voltage, VoltageMeterUpdated, VoltageMeterVisualUpdated);
			DoIndicator(ir.brakeCylinder, BrakeCylMeterUpdated, BrakeCylMeterVisualUpdated);
			DoIndicator(ir.availablePower, AvailablePowerMeterUpdated, AvailablePowerMeterVisualUpdated);
			DoIndicator(ir.tmTemp, TMTempUpdated, TMTempVisualUpdated);
			DoIndicator(ir.oilTemp, OilTempUpdated, OilTempVisualUpdated);
			DoIndicator(ir.brakePipe, BrakePipeMeterUpdated, BrakePipeMeterVisualUpdated);
			DoIndicator(ir.mainReservoir, MainResMeterUpdated, MainResMeterVisualUpdated);
			DoIndicator(ir.sand, SandLevelMeterUpdated, SandLevelMeterVisualUpdated);
			DoIndicator(ir.fuel, FuelLevelMeterUpdated, FuelLevelMeterVisualUpdated);
			DoIndicator(ir.battery, BatteryLevelMeterUpdated, BatteryLevelMeterVisualUpdated);
			DoIndicator(ir.oil, OilLevelMeterUpdated, OilLevelMeterVisualUpdated);
			DoIndicator(ir.tenderCoalLevel, TenderCoalLevelUpdated, TenderCoalMeterVisualUpdated);
			DoIndicator(ir.tenderWaterLevel, TenderWaterLevelUpdated, TenderWaterMeterVisualUpdated);
			DoIndicator(ir.steam, SteamMeterUpdated, SteamMeterVisualUpdated);
			DoIndicator(ir.chestPressure, ChestPressureMeterUpdated, ChestPressureMeterVisualUpdated);
			DoIndicator(ir.locoWaterLevel, LocoWaterMeterUpdated, LocoWaterMeterVisualUpdated);
			DoIndicator(ir.locoCoalLevel, null, LocoCoalMeterVisualUpdated);
			DoIndicator(ir.fireTemperature, FireTemperatureUpdated, FireTemperatureVisualUpdated);
			DoIndicator(ir.waterInCylinder, CylinderCockStatusUpdated, null);
			DoIndicator(ir.cylCocksPopped, CylinderCockStatusUpdated, null);
			void DoIndicator(Indicator indicator, Action<float> updateMeter, Action<float> updateMeterVisual)
			{
				if ((bool)indicator)
				{
					indicator.ValueChanged -= updateMeter;
					indicator.NormalizedValueChanged -= updateMeterVisual;
				}
			}
		}

		private void HUDChanged(HUDInterfacer.HUDChangeEvent obj)
		{
			locoControls = obj.newControls;
			controlsManager = obj.newManager;
			baseControls = obj.newBase;
			bool num = (bool)obj.oldManager && (bool)obj.oldBase;
			bool flag = (bool)obj.newManager && (bool)obj.newBase && (bool)obj.newControls;
			if (num)
			{
				obj.oldManager.UnsubFromHUD();
				indicators.Clear();
			}
			if (!flag)
			{
				return;
			}
			if (!controlsManager.electricsFuseAffectsIndicators)
			{
				electricsFuseOn = true;
			}
			hornNeutralAt0 = obj.newBase.Horn?.neutralAt0 ?? true;
			if ((bool)locoControls.text.locoIDText)
			{
				locoControls.text.locoIDText.SetTextValue(obj.newBase.car.ID);
			}
			if ((bool)locoControls.text.locoTypeText)
			{
				locoControls.text.locoTypeText.SetTextValue(LocalizationAPI.L(obj.newBase.car.carLivery.localizationKey));
			}
			controlsManager.SubToHUD();
			foreach (IndicatorWrapper indicator in indicators)
			{
				if (!indicator.indicator)
				{
					indicator.meterValue?.Invoke(0f);
					indicator.meterIndicator?.Invoke(0f);
				}
			}
		}

		private void BrakeCylMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.braking.brakeCylMeter)
			{
				locoControls.braking.brakeCylMeter.SetVisualLevel(level);
			}
		}

		private void SpeedometerVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.speedMeter)
			{
				locoControls.basicControls.speedMeter.SetVisualLevel(level);
			}
		}

		private void OilLevelMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.cab.oilLevelMeter)
			{
				locoControls.cab.oilLevelMeter.SetVisualLevel(level);
			}
		}

		private void TenderCoalMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.steam.tenderCoalLevel)
			{
				locoControls.steam.tenderCoalLevel.SetVisualLevel(level);
			}
		}

		private void TenderWaterMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.steam.tenderWaterLevel)
			{
				locoControls.steam.tenderWaterLevel.SetVisualLevel(level);
			}
		}

		private void SteamMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.steam.steamMeter)
			{
				locoControls.steam.steamMeter.SetVisualLevel(level);
			}
		}

		private void ChestPressureMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.steam.chestPressureMeter)
			{
				locoControls.steam.chestPressureMeter.SetVisualLevel(level);
			}
		}

		private void LocoWaterMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.steam.locoWaterMeter)
			{
				locoControls.steam.locoWaterMeter.SetVisualLevel(level);
				locoControls.steam.locoWaterMeter.SetTextValue("");
				locoControls.steam.locoWaterMeter.SetIndicatorColor((level > 0f) ? UIColors.CLEAR : UIColors.RED);
			}
		}

		private void LocoCoalMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.steam.locoCoalMeter)
			{
				locoControls.steam.locoCoalMeter.SetVisualLevel(level);
				locoControls.steam.locoCoalMeter.SetTextValue("");
				locoControls.steam.locoCoalMeter.SetTextUnit("");
			}
		}

		private void FireTemperatureVisualUpdated(float level)
		{
			if ((bool)locoControls.steam.fireTemp)
			{
				locoControls.steam.fireTemp.SetVisualLevel(level);
			}
		}

		private void FuelLevelMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.cab.fuelLevelMeter)
			{
				locoControls.cab.fuelLevelMeter.SetVisualLevel(level);
			}
		}

		private void BatteryLevelMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.cab.batteryLevelMeter)
			{
				locoControls.cab.batteryLevelMeter.SetVisualLevel(level);
			}
		}

		private void SandLevelMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.cab.sandMeter)
			{
				locoControls.cab.sandMeter.SetVisualLevel(level);
			}
		}

		private void MainResMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.braking.mainResMeter)
			{
				locoControls.braking.mainResMeter.SetVisualLevel(level);
			}
		}

		private void BrakePipeMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.braking.brakePipeMeter)
			{
				locoControls.braking.brakePipeMeter.SetVisualLevel(level);
			}
		}

		private void TMTempVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.tmTempMeter)
			{
				locoControls.basicControls.tmTempMeter.SetVisualLevel(level);
			}
		}

		private void OilTempVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.oilTempMeter)
			{
				locoControls.basicControls.oilTempMeter.SetVisualLevel(level);
			}
		}

		private void AvailablePowerMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.powerMeter)
			{
				locoControls.basicControls.powerMeter.SetVisualLevel(level);
			}
		}

		private void VoltageMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.voltageMeter)
			{
				locoControls.basicControls.voltageMeter.SetVisualLevel(level);
			}
		}

		private void AmpMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.ampMeter)
			{
				locoControls.basicControls.ampMeter.SetVisualLevel(level);
			}
		}

		private void RpmMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.rpmMeter)
			{
				locoControls.basicControls.rpmMeter.SetVisualLevel(level);
			}
		}

		private void TurbineRpmMeterVisualUpdated(float level)
		{
			if ((bool)locoControls.basicControls.turbineRpmMeter)
			{
				locoControls.basicControls.turbineRpmMeter.SetVisualLevel(level);
			}
		}

		private void ThrottleVisualUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.basicControls.throttle)
			{
				locoControls.basicControls.throttle.SetVisualLevel(value.newValue);
				SetControlName(locoControls.basicControls.throttle, InteriorControlsManager.ControlType.Throttle);
			}
		}

		private void TrainBrakeVisualUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.braking.trainBrake)
			{
				if (baseControls.car.brakeSystem.selfLappingController)
				{
					locoControls.braking.trainBrake.SetVisualLevel(value.newValue);
					locoControls.braking.trainBrake.SetTextUnit("%");
					locoControls.braking.trainBrake.SetTextValue(((int)(value.newValue * 100f)).ToString(LocalizationAPI.CC));
				}
				else
				{
					locoControls.braking.trainBrake.SetVisualLevel(value.newValue);
					locoControls.braking.trainBrake.SetTextUnit("");
					float newValue = value.newValue;
					string textValue = ((newValue > 0.9f) ? "!" : ((newValue > 0.5f) ? "+" : ((newValue > 0.1f) ? "X" : "-")));
					locoControls.braking.trainBrake.SetTextValue(textValue);
				}
			}
		}

		private void ReverserVisualUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.basicControls.reverser)
			{
				locoControls.basicControls.reverser.SetVisualLevel(value.newValue);
				SetControlName(locoControls.basicControls.reverser, InteriorControlsManager.ControlType.Reverser);
			}
		}

		private void IndBrakeVisualUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.braking.indBrake)
			{
				locoControls.braking.indBrake.SetVisualLevel(value.newValue);
				locoControls.braking.indBrake.SetTextUnit("%");
				locoControls.braking.indBrake.SetTextValue(((int)(value.newValue * 100f)).ToString(LocalizationAPI.CC));
			}
		}

		private void BrakeCutoutUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.braking.brakeCutout)
			{
				locoControls.braking.brakeCutout.SetVisualLevel(value.newValue);
			}
		}

		private void HeadlightsVisualUpdatedFront(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.headlightsFront)
			{
				locoControls.cab.headlightsFront.SetVisualLevel(value.newValue);
				SetControlName(locoControls.cab.headlightsFront, InteriorControlsManager.ControlType.HeadlightsFront);
			}
		}

		private void HeadlightsVisualUpdatedRear(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.headlightsRear)
			{
				locoControls.cab.headlightsRear.SetVisualLevel(value.newValue);
				SetControlName(locoControls.cab.headlightsRear, InteriorControlsManager.ControlType.HeadlightsRear);
			}
		}

		private void HornVisualUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.horn)
			{
				if (hornNeutralAt0)
				{
					locoControls.cab.horn.SetVisualLevel(value.newValue);
				}
				else
				{
					locoControls.cab.horn.SetVisualLevel((Mathf.Abs(0.5f - value.newValue) > 0.25f) ? 1f : 0f);
				}
				locoControls.cab.horn.SetTextValue((Mathf.Abs(value.newValue - (hornNeutralAt0 ? 0f : 0.5f)) > 0.45f) ? "!" : "");
			}
		}

		private void SandVisualUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.basicControls.sand)
			{
				locoControls.basicControls.sand.SetVisualLevel(value.newValue);
				SetControlName(locoControls.basicControls.sand, InteriorControlsManager.ControlType.Sander);
			}
		}

		private void SandLampUpdated(float value)
		{
			if ((bool)locoControls.basicControls.sand)
			{
				locoControls.basicControls.sand.SetIndicatorColor((value > 0.5f) ? UIColors.YELLOW : UIColors.CLEAR);
			}
		}

		private void TMOffUpdated(float value)
		{
			if ((bool)locoControls.mechanical.tmOfflineIndicator)
			{
				locoControls.mechanical.tmOfflineIndicator.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void SandLevelLampUpdated(float value)
		{
			if ((bool)locoControls.cab.sandMeter)
			{
				locoControls.cab.sandMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void FuelLevelLampUpdated(float value)
		{
			if ((bool)locoControls.cab.fuelLevelMeter)
			{
				locoControls.cab.fuelLevelMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void BatteryLevelLampUpdated(float value)
		{
			if ((bool)locoControls.cab.batteryLevelMeter)
			{
				locoControls.cab.batteryLevelMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void OilLevelLampUpdated(float value)
		{
			locoControls.cab.oilLevelMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
		}

		private void ElectronicsLampUpdated(float value)
		{
			locoControls.mechanical.electricsFuse.SetIndicatorColor((value > 0.5f) ? UIColors.GREEN : UIColors.CLEAR);
		}

		private void CabLightLampUpdated(float value)
		{
			locoControls.cab.cabLight.SetIndicatorColor((value > 0.5f) ? UIColors.BLUE : UIColors.CLEAR);
		}

		private void HeadlightsFrontLampUpdated(float value)
		{
			locoControls.cab.headlightsFront.SetIndicatorColor((value > 0.5f) ? UIColors.BLUE : UIColors.CLEAR);
		}

		private void HeadlightsRearLampUpdated(float value)
		{
			locoControls.cab.headlightsRear.SetIndicatorColor((value > 0.5f) ? UIColors.BLUE : UIColors.CLEAR);
		}

		private void WipersLampUpdated(float value)
		{
			locoControls.cab.wipers.SetIndicatorColor((value > 0.5f) ? UIColors.BLUE : UIColors.CLEAR);
		}

		private void HandbrakeVisualUpdated(float value)
		{
			if ((bool)locoControls.braking.handbrake)
			{
				locoControls.braking.handbrake.SetVisualLevel(value);
				locoControls.braking.handbrake.SetTextValue(((int)(value * 100f)).ToString(LocalizationAPI.CC));
				locoControls.braking.handbrake.SetTextUnit("%");
			}
		}

		private void ReleaseCylVisualUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.braking.releaseCyl)
			{
				locoControls.braking.releaseCyl.SetVisualLevel(value.newValue);
			}
		}

		private void StarterFuseUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.mechanical.starterFuse)
			{
				locoControls.mechanical.starterFuse.SetVisualLevel(value.newValue);
			}
		}

		private void ElectricsFuseUpdated(ValueChangedEventArgs value)
		{
			electricsFuseOn = !controlsManager.electricsFuseAffectsIndicators || (double)value.newValue > 0.5;
			foreach (IndicatorWrapper indicator in indicators)
			{
				indicator.meterValue?.Invoke(indicator.indicator.Value);
				indicator.meterIndicator?.Invoke(Mathf.InverseLerp(indicator.indicator.minValue, indicator.indicator.maxValue, indicator.indicator.Value));
			}
			if ((bool)locoControls.mechanical.electricsFuse)
			{
				locoControls.mechanical.electricsFuse.SetVisualLevel(value.newValue);
			}
		}

		private void TractionMotorFuseUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.mechanical.tractionMotorFuse)
			{
				locoControls.mechanical.tractionMotorFuse.SetVisualLevel(value.newValue);
			}
		}

		private void StarterControlUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.mechanical.starterControl)
			{
				locoControls.mechanical.starterControl.SetVisualLevel((value.newValue > 0.75f) ? 1 : 0);
			}
		}

		private void SpeedometerUpdated(float value)
		{
			if ((bool)locoControls.basicControls.speedMeter)
			{
				locoControls.basicControls.speedMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.speedMeter.SetTextUnit(electricsFuseOn ? "km/h" : "");
			}
		}

		private void RpmMeterUpdated(float value)
		{
			if ((bool)locoControls.basicControls.rpmMeter)
			{
				locoControls.basicControls.rpmMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.rpmMeter.SetTextUnit(electricsFuseOn ? "RPM" : "");
			}
		}

		private void TurbineRpmMeterUpdated(float value)
		{
			if ((bool)locoControls.basicControls.turbineRpmMeter)
			{
				locoControls.basicControls.turbineRpmMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.turbineRpmMeter.SetTextUnit(electricsFuseOn ? "RPM" : "");
			}
		}

		private void RpmLampUpdated(float value)
		{
			if ((bool)locoControls.basicControls.rpmMeter)
			{
				locoControls.basicControls.rpmMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void TurbineRpmLampUpdated(float value)
		{
			if ((bool)locoControls.basicControls.turbineRpmMeter)
			{
				locoControls.basicControls.turbineRpmMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void AmpMeterUpdated(float value)
		{
			if ((bool)locoControls.basicControls.ampMeter)
			{
				locoControls.basicControls.ampMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.ampMeter.SetTextUnit(electricsFuseOn ? "A" : "");
			}
		}

		private void AmpLampUpdated(float value)
		{
			if ((bool)locoControls.basicControls.ampMeter)
			{
				locoControls.basicControls.ampMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void VoltageMeterUpdated(float value)
		{
			if ((bool)locoControls.basicControls.voltageMeter)
			{
				locoControls.basicControls.voltageMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.voltageMeter.SetTextUnit(electricsFuseOn ? "V" : "");
			}
		}

		private void VoltageLampUpdated(float value)
		{
			if ((bool)locoControls.basicControls.voltageMeter)
			{
				locoControls.basicControls.voltageMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void AvailablePowerMeterUpdated(float value)
		{
			if ((bool)locoControls.basicControls.powerMeter)
			{
				locoControls.basicControls.powerMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.powerMeter.SetTextUnit(electricsFuseOn ? "W" : "");
			}
		}

		private void AvailablePowerLampUpdated(float value)
		{
			if ((bool)locoControls.basicControls.powerMeter)
			{
				locoControls.basicControls.powerMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void BrakePipeMeterUpdated(float value)
		{
			if ((bool)locoControls.braking.brakePipeMeter)
			{
				locoControls.braking.brakePipeMeter.SetTextValue((value - 1f).ToString("N1", LocalizationAPI.CC));
				locoControls.braking.brakePipeMeter.SetTextUnit("bar");
			}
		}

		private void BrakePipeLampUpdated(float value)
		{
			if ((bool)locoControls.braking.brakePipeMeter)
			{
				locoControls.braking.brakePipeMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void MainResMeterUpdated(float value)
		{
			if ((bool)locoControls.braking.mainResMeter)
			{
				locoControls.braking.mainResMeter.SetTextValue((value - 1f).ToString("N1", LocalizationAPI.CC));
				locoControls.braking.mainResMeter.SetTextUnit("bar");
			}
		}

		private void MainResLampUpdated(float value)
		{
			if ((bool)locoControls.braking.mainResMeter)
			{
				locoControls.braking.mainResMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void BrakeCylMeterUpdated(float value)
		{
			if ((bool)locoControls.braking.brakeCylMeter)
			{
				locoControls.braking.brakeCylMeter.SetTextValue((value - 1f).ToString("N1", LocalizationAPI.CC));
				locoControls.braking.brakeCylMeter.SetTextUnit("bar");
			}
		}

		private void SandLevelMeterUpdated(float value)
		{
			if ((bool)locoControls.cab.sandMeter)
			{
				locoControls.cab.sandMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.cab.sandMeter.SetTextUnit("");
			}
		}

		private void FuelLevelMeterUpdated(float value)
		{
			if ((bool)locoControls.cab.fuelLevelMeter)
			{
				locoControls.cab.fuelLevelMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.cab.fuelLevelMeter.SetTextUnit("");
			}
		}

		private void BatteryLevelMeterUpdated(float value)
		{
			if ((bool)locoControls.cab.batteryLevelMeter)
			{
				locoControls.cab.batteryLevelMeter.SetTextValue(electricsFuseOn ? (value * 100f).ToString("N0", LocalizationAPI.CC) : "");
				locoControls.cab.batteryLevelMeter.SetTextUnit("%");
			}
		}

		private void OilLevelMeterUpdated(float value)
		{
			if ((bool)locoControls.cab.oilLevelMeter)
			{
				locoControls.cab.oilLevelMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.cab.oilLevelMeter.SetTextUnit("");
			}
		}

		private void TenderCoalLevelUpdated(float value)
		{
			if ((bool)locoControls.steam.tenderCoalLevel)
			{
				locoControls.steam.tenderCoalLevel.SetTextValue((value * 0.001f).ToString("N1", LocalizationAPI.CC));
				locoControls.steam.tenderCoalLevel.SetTextUnit("");
			}
		}

		private void TenderWaterLevelUpdated(float value)
		{
			if ((bool)locoControls.steam.tenderWaterLevel)
			{
				locoControls.steam.tenderWaterLevel.SetTextValue((value * 0.001f).ToString("N1", LocalizationAPI.CC));
				locoControls.steam.tenderWaterLevel.SetTextUnit("");
			}
		}

		private void SteamMeterUpdated(float value)
		{
			if ((bool)locoControls.steam.steamMeter)
			{
				locoControls.steam.steamMeter.SetTextValue((value - 1f).ToString("N1", LocalizationAPI.CC));
				locoControls.steam.steamMeter.SetTextUnit("");
			}
		}

		private void ChestPressureMeterUpdated(float value)
		{
			if ((bool)locoControls.steam.chestPressureMeter)
			{
				locoControls.steam.chestPressureMeter.SetTextValue((value - 1f).ToString("N1", LocalizationAPI.CC));
				locoControls.steam.chestPressureMeter.SetTextUnit("");
			}
		}

		private void LocoWaterMeterUpdated(float value)
		{
			if ((bool)locoControls.steam.locoWaterMeter)
			{
				locoControls.steam.locoWaterMeter.SetTextUnit("");
			}
		}

		private void FireTemperatureUpdated(float value)
		{
			if ((bool)locoControls.steam.fireTemp)
			{
				locoControls.steam.fireTemp.SetTextValue(value.ToString("N0", LocalizationAPI.CC));
				locoControls.steam.fireTemp.SetTextUnit("");
			}
		}

		private void CylinderCockStatusUpdated(float value)
		{
			if (!(cylCocksPopped == null) && !(waterInCylinder == null))
			{
				if ((double)cylCocksPopped.Value > 0.5)
				{
					locoControls.steam.cylCock.SetIndicatorColor(UIColors.RED);
				}
				else if (waterInCylinder.Value > 0.01f)
				{
					locoControls.steam.cylCock.SetIndicatorColor(UIColors.BLUE);
				}
				else
				{
					locoControls.steam.cylCock.SetIndicatorColor(UIColors.CLEAR);
				}
			}
		}

		private void LubricatorLampUpdated(float _)
		{
			if (!(locoControls.steam.lubricator == null) && !(automaticLubricatorLampControl == null) && !(manualLubricatorLampControl == null))
			{
				if (automaticLubricatorLampControl.lampState == LampControl.LampState.Blinking)
				{
					locoControls.steam.lubricator.SetIndicatorColor((automaticLubricatorLampControl.lampInd.Value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
				}
				else if (manualLubricatorLampControl.lampState == LampControl.LampState.Blinking)
				{
					locoControls.steam.lubricator.SetIndicatorColor((manualLubricatorLampControl.lampInd.Value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
				}
				else if (automaticLubricatorLampControl.lampState == LampControl.LampState.On)
				{
					locoControls.steam.lubricator.SetIndicatorColor((automaticLubricatorLampControl.lampInd.Value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
				}
				else if (manualLubricatorLampControl.lampState == LampControl.LampState.On)
				{
					locoControls.steam.lubricator.SetIndicatorColor((manualLubricatorLampControl.lampInd.Value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
				}
				else
				{
					locoControls.steam.lubricator.SetIndicatorColor(UIColors.CLEAR);
				}
			}
		}

		private void BrakeCylLampUpdated(float value)
		{
			if ((bool)locoControls.braking.brakeCylMeter)
			{
				locoControls.braking.brakeCylMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void WheelslipLampUpdated(float value)
		{
			if ((bool)locoControls.basicControls.wheelSlipIndicator)
			{
				locoControls.basicControls.wheelSlipIndicator.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void TMTempUpdated(float value)
		{
			if ((bool)locoControls.basicControls.tmTempMeter)
			{
				locoControls.basicControls.tmTempMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.tmTempMeter.SetTextUnit(electricsFuseOn ? "C" : "");
			}
		}

		private void TMTempLightUpdated(float value)
		{
			if ((bool)locoControls.basicControls.tmTempMeter)
			{
				locoControls.basicControls.tmTempMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void OilTempUpdated(float value)
		{
			if ((bool)locoControls.basicControls.oilTempMeter)
			{
				locoControls.basicControls.oilTempMeter.SetTextValue(electricsFuseOn ? value.ToString("N0", LocalizationAPI.CC) : "");
				locoControls.basicControls.oilTempMeter.SetTextUnit(electricsFuseOn ? "C" : "");
			}
		}

		private void OilTempLightUpdated(float value)
		{
			if ((bool)locoControls.basicControls.oilTempMeter)
			{
				locoControls.basicControls.oilTempMeter.SetIndicatorColor((value > 0.5f) ? UIColors.RED : UIColors.CLEAR);
			}
		}

		private void DynamicBrakeUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.braking.dynBrake)
			{
				locoControls.braking.dynBrake.SetVisualLevel(value.newValue);
				locoControls.braking.dynBrake.SetTextUnit("%");
				locoControls.braking.dynBrake.SetTextValue(((int)(value.newValue * 100f)).ToString(LocalizationAPI.CC));
			}
		}

		private void CabLightUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.cabLight)
			{
				locoControls.cab.cabLight.SetVisualLevel(value.newValue);
				SetControlName(locoControls.cab.cabLight, InteriorControlsManager.ControlType.CabLight);
			}
		}

		private void WipersUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.wipers)
			{
				locoControls.cab.wipers.SetVisualLevel(value.newValue);
				SetControlName(locoControls.cab.wipers, InteriorControlsManager.ControlType.Wipers);
			}
		}

		private void IndHeadlightsTypeFrontUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indHeadlightsTypeFront)
			{
				locoControls.cab.indHeadlightsTypeFront.SetVisualLevel(value.newValue);
			}
		}

		private void IndHeadlights1FrontUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indHeadlights1Front)
			{
				locoControls.cab.indHeadlights1Front.SetVisualLevel(value.newValue);
			}
		}

		private void IndHeadlights2FrontUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indHeadlights2Front)
			{
				locoControls.cab.indHeadlights2Front.SetVisualLevel(value.newValue);
			}
		}

		private void IndHeadlightsTypeRearUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indHeadlightsTypeRear)
			{
				locoControls.cab.indHeadlightsTypeRear.SetVisualLevel(value.newValue);
			}
		}

		private void IndHeadlights1RearUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indHeadlights1Rear)
			{
				locoControls.cab.indHeadlights1Rear.SetVisualLevel(value.newValue);
			}
		}

		private void IndHeadlights2RearUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indHeadlights2Rear)
			{
				locoControls.cab.indHeadlights2Rear.SetVisualLevel(value.newValue);
			}
		}

		private void IndWipers1Updated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indWipers1)
			{
				locoControls.cab.indWipers1.SetVisualLevel(value.newValue);
			}
		}

		private void IndWipers2Updated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indWipers2)
			{
				locoControls.cab.indWipers2.SetVisualLevel(value.newValue);
			}
		}

		private void IndCabLightUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indCabLight)
			{
				locoControls.cab.indCabLight.SetVisualLevel(value.newValue);
			}
		}

		private void IndDashLightUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.indDashLight)
			{
				locoControls.cab.indDashLight.SetVisualLevel(value.newValue);
			}
		}

		private void GearboxAUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.basicControls.gearboxA)
			{
				locoControls.basicControls.gearboxA.SetVisualLevel(value.newValue);
				SetControlName(locoControls.basicControls.gearboxA, InteriorControlsManager.ControlType.GearboxA);
			}
		}

		private void GearboxBUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.basicControls.gearboxB)
			{
				locoControls.basicControls.gearboxB.SetVisualLevel(value.newValue);
				SetControlName(locoControls.basicControls.gearboxB, InteriorControlsManager.ControlType.GearboxB);
			}
		}

		private void CylCockUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.cylCock)
			{
				locoControls.steam.cylCock.SetVisualLevel(value.newValue);
				SetControlName(locoControls.steam.cylCock, InteriorControlsManager.ControlType.CylCock);
			}
		}

		private void InjectorUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.injector)
			{
				locoControls.steam.injector.SetVisualLevel(value.newValue);
				SetControlName(locoControls.steam.injector, InteriorControlsManager.ControlType.Injector);
			}
		}

		private void FiredoorUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.firedoor)
			{
				locoControls.steam.firedoor.SetVisualLevel(value.newValue);
				SetControlName(locoControls.steam.firedoor, InteriorControlsManager.ControlType.Firedoor);
			}
		}

		private void BlowerUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.blower)
			{
				locoControls.steam.blower.SetVisualLevel(value.newValue);
				SetControlName(locoControls.steam.blower, InteriorControlsManager.ControlType.Blower);
			}
		}

		private void DamperUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.damper)
			{
				locoControls.steam.damper.SetVisualLevel(value.newValue);
				SetControlName(locoControls.steam.damper, InteriorControlsManager.ControlType.Damper);
			}
		}

		private void BlowdownUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.blowdown)
			{
				locoControls.steam.blowdown.SetVisualLevel(value.newValue);
				SetControlName(locoControls.steam.blowdown, InteriorControlsManager.ControlType.Blowdown);
			}
		}

		private void CoalDumpUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.coalDump)
			{
				locoControls.steam.coalDump.SetVisualLevel((Mathf.Abs(0.5f - value.newValue) > 0.25f) ? 1f : 0f);
				SetControlName(locoControls.steam.coalDump, InteriorControlsManager.ControlType.CoalDump);
			}
		}

		private void DynamoUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.dynamo)
			{
				locoControls.steam.dynamo.SetVisualLevel(value.newValue);
			}
		}

		private void AirPumpUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.airPump)
			{
				locoControls.steam.airPump.SetVisualLevel(value.newValue);
			}
		}

		private void LubricatorUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.steam.lubricator)
			{
				locoControls.steam.lubricator.SetVisualLevel(value.newValue);
			}
		}

		private void BellUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.cab.bell)
			{
				locoControls.cab.bell.SetVisualLevel(value.newValue);
				SetControlName(locoControls.cab.bell, InteriorControlsManager.ControlType.Bell);
			}
		}

		private void FuelCutoffUpdated(ValueChangedEventArgs value)
		{
			if ((bool)locoControls.mechanical.fuelCutoff)
			{
				locoControls.mechanical.fuelCutoff.SetVisualLevel(value.newValue);
			}
		}

		private void SetControlName(LocoHUDControlBase control, InteriorControlsManager.ControlType type)
		{
			(string, string) currentPositionName = controlsManager.GetCurrentPositionName(type);
			control.SetTextUnit(currentPositionName.Item2);
			control.SetTextValue(currentPositionName.Item1.ToString(LocalizationAPI.CC));
		}
	}
}
