using DV.CabControls;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using DV.UI.LocoHUD;
using DV.Utils;
using UnityEngine;

namespace DV.HUD
{
	public class LocoHUDObserver : MonoBehaviour
	{
		private HUDLocoControls locoControls;

		private BaseControlsOverrider baseControls;

		private InteriorControlsManager controlsManager;

		private void Start()
		{
			SetupListener(on: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListener(on: false);
			}
		}

		private void SetupListener(bool on)
		{
			if (on)
			{
				SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged += HUDChanged;
				return;
			}
			SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged -= HUDChanged;
			HUDChanged(default(HUDInterfacer.HUDChangeEvent));
		}

		private void HUDChanged(HUDInterfacer.HUDChangeEvent obj)
		{
			controlsManager = obj.newManager;
			baseControls = obj.newBase;
			if ((bool)locoControls)
			{
				if ((bool)locoControls.basicControls.throttle)
				{
					locoControls.basicControls.throttle.controlModule.ValueChanged -= ThrottleValueUpdated;
				}
				if ((bool)locoControls.basicControls.reverser)
				{
					locoControls.basicControls.reverser.controlModule.ValueChanged -= ReverserValueUpdated;
				}
				if ((bool)locoControls.basicControls.sand)
				{
					locoControls.basicControls.sand.controlModule.ValueChanged -= SandValueUpdated;
				}
				if ((bool)locoControls.basicControls.gearboxA)
				{
					locoControls.basicControls.gearboxA.controlModule.ValueChanged -= GearboxAUpdated;
				}
				if ((bool)locoControls.basicControls.gearboxB)
				{
					locoControls.basicControls.gearboxB.controlModule.ValueChanged -= GearboxBUpdated;
				}
				if ((bool)locoControls.braking.trainBrake)
				{
					locoControls.braking.trainBrake.controlModule.ValueChanged -= BrakeValueUpdated;
				}
				if ((bool)locoControls.braking.indBrake)
				{
					locoControls.braking.indBrake.controlModule.ValueChanged -= IndBrakeValueUpdated;
				}
				if ((bool)locoControls.braking.dynBrake)
				{
					locoControls.braking.dynBrake.controlModule.ValueChanged -= DynamicBrakeUpdated;
				}
				if ((bool)locoControls.braking.handbrake)
				{
					locoControls.braking.handbrake.controlModule.ValueChanged -= HandbrakeValueUpdated;
				}
				if ((bool)locoControls.braking.releaseCyl)
				{
					locoControls.braking.releaseCyl.controlModule.ValueChanged -= ReleaseCylValueUpdated;
				}
				if ((bool)locoControls.braking.brakeCutout)
				{
					locoControls.braking.brakeCutout.controlModule.ValueChanged -= BrakeCutoutUpdated;
				}
				if ((bool)locoControls.steam.cylCock)
				{
					locoControls.steam.cylCock.controlModule.ValueChanged -= CylCockValueUpdated;
				}
				if ((bool)locoControls.steam.injector)
				{
					locoControls.steam.injector.controlModule.ValueChanged -= InjectorValueUpdated;
				}
				if ((bool)locoControls.steam.firedoor)
				{
					locoControls.steam.firedoor.controlModule.ValueChanged -= FiredoorValueUpdated;
				}
				if ((bool)locoControls.steam.blower)
				{
					locoControls.steam.blower.controlModule.ValueChanged -= BlowerValueUpdated;
				}
				if ((bool)locoControls.steam.damper)
				{
					locoControls.steam.damper.controlModule.ValueChanged -= DamperValueUpdated;
				}
				if ((bool)locoControls.steam.blowdown)
				{
					locoControls.steam.blowdown.controlModule.ValueChanged -= BlowdownValueUpdated;
				}
				if ((bool)locoControls.steam.coalDump)
				{
					locoControls.steam.coalDump.controlModule.ValueChanged -= CoalDumpValueUpdated;
				}
				if ((bool)locoControls.steam.dynamo)
				{
					locoControls.steam.dynamo.controlModule.ValueChanged -= DynamoUpdated;
				}
				if ((bool)locoControls.steam.airPump)
				{
					locoControls.steam.airPump.controlModule.ValueChanged -= AirPumpUpdated;
				}
				if ((bool)locoControls.steam.lubricator)
				{
					locoControls.steam.lubricator.controlModule.ValueChanged -= LubricatorUpdated;
				}
				if ((bool)locoControls.steam.shovel)
				{
					locoControls.steam.shovel.controlModule.ValueChanged -= ShovelValueUpdated;
				}
				if ((bool)locoControls.steam.lightFirebox)
				{
					locoControls.steam.lightFirebox.controlModule.ValueChanged -= LightFireboxUpdated;
				}
				if ((bool)locoControls.cab.bell)
				{
					locoControls.cab.bell.controlModule.ValueChanged -= BellUpdated;
				}
				if ((bool)locoControls.cab.headlightsFront)
				{
					locoControls.cab.headlightsFront.controlModule.ValueChanged -= HeadlightsValueUpdatedFront;
				}
				if ((bool)locoControls.cab.headlightsRear)
				{
					locoControls.cab.headlightsRear.controlModule.ValueChanged -= HeadlightsValueUpdatedRear;
				}
				if ((bool)locoControls.cab.horn)
				{
					locoControls.cab.horn.controlModule.ValueChanged -= HornValueUpdated;
				}
				if ((bool)locoControls.cab.cabLight)
				{
					locoControls.cab.cabLight.controlModule.ValueChanged -= CabLightUpdated;
				}
				if ((bool)locoControls.cab.wipers)
				{
					locoControls.cab.wipers.controlModule.ValueChanged -= WipersUpdated;
				}
				if ((bool)locoControls.cab.indHeadlightsTypeFront)
				{
					locoControls.cab.indHeadlightsTypeFront.controlModule.ValueChanged -= IndHeadlightsTypeFrontUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights1Front)
				{
					locoControls.cab.indHeadlights1Front.controlModule.ValueChanged -= IndHeadlights1FrontUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights2Front)
				{
					locoControls.cab.indHeadlights2Front.controlModule.ValueChanged -= IndHeadlights2FrontUpdated;
				}
				if ((bool)locoControls.cab.indHeadlightsTypeRear)
				{
					locoControls.cab.indHeadlightsTypeRear.controlModule.ValueChanged -= IndHeadlightsTypeRearUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights1Rear)
				{
					locoControls.cab.indHeadlights1Rear.controlModule.ValueChanged -= IndHeadlights1RearUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights2Rear)
				{
					locoControls.cab.indHeadlights2Rear.controlModule.ValueChanged -= IndHeadlights2RearUpdated;
				}
				if ((bool)locoControls.cab.indWipers1)
				{
					locoControls.cab.indWipers1.controlModule.ValueChanged -= IndWipers1Updated;
				}
				if ((bool)locoControls.cab.indWipers2)
				{
					locoControls.cab.indWipers2.controlModule.ValueChanged -= IndWipers2Updated;
				}
				if ((bool)locoControls.cab.indCabLight)
				{
					locoControls.cab.indCabLight.controlModule.ValueChanged -= IndCabLightUpdated;
				}
				if ((bool)locoControls.cab.indDashLight)
				{
					locoControls.cab.indDashLight.controlModule.ValueChanged -= IndDashLightUpdated;
				}
				if ((bool)locoControls.mechanical.starterFuse)
				{
					locoControls.mechanical.starterFuse.controlModule.ValueChanged -= StarterFuseUpdated;
				}
				if ((bool)locoControls.mechanical.electricsFuse)
				{
					locoControls.mechanical.electricsFuse.controlModule.ValueChanged -= ElectricsFuseUpdated;
				}
				if ((bool)locoControls.mechanical.tractionMotorFuse)
				{
					locoControls.mechanical.tractionMotorFuse.controlModule.ValueChanged -= TractionMotorFuseUpdated;
				}
				if ((bool)locoControls.mechanical.starterControl)
				{
					locoControls.mechanical.starterControl.controlModule.ValueChanged -= StarterControlUpdated;
				}
				if ((bool)locoControls.mechanical.fuelCutoff)
				{
					locoControls.mechanical.fuelCutoff.controlModule.ValueChanged -= FuelCutoffUpdated;
				}
			}
			locoControls = obj.newControls;
			if ((bool)locoControls)
			{
				if ((bool)locoControls.basicControls.throttle)
				{
					locoControls.basicControls.throttle.controlModule.ValueChanged += ThrottleValueUpdated;
				}
				if ((bool)locoControls.basicControls.reverser)
				{
					locoControls.basicControls.reverser.controlModule.ValueChanged += ReverserValueUpdated;
				}
				if ((bool)locoControls.basicControls.sand)
				{
					locoControls.basicControls.sand.controlModule.ValueChanged += SandValueUpdated;
				}
				if ((bool)locoControls.basicControls.gearboxA)
				{
					locoControls.basicControls.gearboxA.controlModule.ValueChanged += GearboxAUpdated;
				}
				if ((bool)locoControls.basicControls.gearboxB)
				{
					locoControls.basicControls.gearboxB.controlModule.ValueChanged += GearboxBUpdated;
				}
				if ((bool)locoControls.braking.trainBrake)
				{
					locoControls.braking.trainBrake.controlModule.ValueChanged += BrakeValueUpdated;
				}
				if ((bool)locoControls.braking.indBrake)
				{
					locoControls.braking.indBrake.controlModule.ValueChanged += IndBrakeValueUpdated;
				}
				if ((bool)locoControls.braking.dynBrake)
				{
					locoControls.braking.dynBrake.controlModule.ValueChanged += DynamicBrakeUpdated;
				}
				if ((bool)locoControls.braking.handbrake)
				{
					locoControls.braking.handbrake.controlModule.ValueChanged += HandbrakeValueUpdated;
				}
				if ((bool)locoControls.braking.releaseCyl)
				{
					locoControls.braking.releaseCyl.controlModule.ValueChanged += ReleaseCylValueUpdated;
				}
				if ((bool)locoControls.braking.brakeCutout)
				{
					locoControls.braking.brakeCutout.controlModule.ValueChanged += BrakeCutoutUpdated;
				}
				if ((bool)locoControls.steam.cylCock)
				{
					locoControls.steam.cylCock.controlModule.ValueChanged += CylCockValueUpdated;
				}
				if ((bool)locoControls.steam.injector)
				{
					locoControls.steam.injector.controlModule.ValueChanged += InjectorValueUpdated;
				}
				if ((bool)locoControls.steam.firedoor)
				{
					locoControls.steam.firedoor.controlModule.ValueChanged += FiredoorValueUpdated;
				}
				if ((bool)locoControls.steam.blower)
				{
					locoControls.steam.blower.controlModule.ValueChanged += BlowerValueUpdated;
				}
				if ((bool)locoControls.steam.damper)
				{
					locoControls.steam.damper.controlModule.ValueChanged += DamperValueUpdated;
				}
				if ((bool)locoControls.steam.blowdown)
				{
					locoControls.steam.blowdown.controlModule.ValueChanged += BlowdownValueUpdated;
				}
				if ((bool)locoControls.steam.coalDump)
				{
					locoControls.steam.coalDump.controlModule.ValueChanged += CoalDumpValueUpdated;
				}
				if ((bool)locoControls.steam.dynamo)
				{
					locoControls.steam.dynamo.controlModule.ValueChanged += DynamoUpdated;
				}
				if ((bool)locoControls.steam.airPump)
				{
					locoControls.steam.airPump.controlModule.ValueChanged += AirPumpUpdated;
				}
				if ((bool)locoControls.steam.lubricator)
				{
					locoControls.steam.lubricator.controlModule.ValueChanged += LubricatorUpdated;
				}
				if ((bool)locoControls.steam.shovel)
				{
					locoControls.steam.shovel.controlModule.ValueChanged += ShovelValueUpdated;
				}
				if ((bool)locoControls.steam.lightFirebox)
				{
					locoControls.steam.lightFirebox.controlModule.ValueChanged += LightFireboxUpdated;
				}
				if ((bool)locoControls.cab.bell)
				{
					locoControls.cab.bell.controlModule.ValueChanged += BellUpdated;
				}
				if ((bool)locoControls.cab.headlightsFront)
				{
					locoControls.cab.headlightsFront.controlModule.ValueChanged += HeadlightsValueUpdatedFront;
				}
				if ((bool)locoControls.cab.headlightsRear)
				{
					locoControls.cab.headlightsRear.controlModule.ValueChanged += HeadlightsValueUpdatedRear;
				}
				if ((bool)locoControls.cab.horn)
				{
					locoControls.cab.horn.controlModule.ValueChanged += HornValueUpdated;
				}
				if ((bool)locoControls.cab.cabLight)
				{
					locoControls.cab.cabLight.controlModule.ValueChanged += CabLightUpdated;
				}
				if ((bool)locoControls.cab.wipers)
				{
					locoControls.cab.wipers.controlModule.ValueChanged += WipersUpdated;
				}
				if ((bool)locoControls.cab.indHeadlightsTypeFront)
				{
					locoControls.cab.indHeadlightsTypeFront.controlModule.ValueChanged += IndHeadlightsTypeFrontUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights1Front)
				{
					locoControls.cab.indHeadlights1Front.controlModule.ValueChanged += IndHeadlights1FrontUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights2Front)
				{
					locoControls.cab.indHeadlights2Front.controlModule.ValueChanged += IndHeadlights2FrontUpdated;
				}
				if ((bool)locoControls.cab.indHeadlightsTypeRear)
				{
					locoControls.cab.indHeadlightsTypeRear.controlModule.ValueChanged += IndHeadlightsTypeRearUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights1Rear)
				{
					locoControls.cab.indHeadlights1Rear.controlModule.ValueChanged += IndHeadlights1RearUpdated;
				}
				if ((bool)locoControls.cab.indHeadlights2Rear)
				{
					locoControls.cab.indHeadlights2Rear.controlModule.ValueChanged += IndHeadlights2RearUpdated;
				}
				if ((bool)locoControls.cab.indWipers1)
				{
					locoControls.cab.indWipers1.controlModule.ValueChanged += IndWipers1Updated;
				}
				if ((bool)locoControls.cab.indWipers2)
				{
					locoControls.cab.indWipers2.controlModule.ValueChanged += IndWipers2Updated;
				}
				if ((bool)locoControls.cab.indCabLight)
				{
					locoControls.cab.indCabLight.controlModule.ValueChanged += IndCabLightUpdated;
				}
				if ((bool)locoControls.cab.indDashLight)
				{
					locoControls.cab.indDashLight.controlModule.ValueChanged += IndDashLightUpdated;
				}
				if ((bool)locoControls.mechanical.starterFuse)
				{
					locoControls.mechanical.starterFuse.controlModule.ValueChanged += StarterFuseUpdated;
				}
				if ((bool)locoControls.mechanical.electricsFuse)
				{
					locoControls.mechanical.electricsFuse.controlModule.ValueChanged += ElectricsFuseUpdated;
				}
				if ((bool)locoControls.mechanical.tractionMotorFuse)
				{
					locoControls.mechanical.tractionMotorFuse.controlModule.ValueChanged += TractionMotorFuseUpdated;
				}
				if ((bool)locoControls.mechanical.starterControl)
				{
					locoControls.mechanical.starterControl.controlModule.ValueChanged += StarterControlUpdated;
				}
				if ((bool)locoControls.mechanical.fuelCutoff)
				{
					locoControls.mechanical.fuelCutoff.controlModule.ValueChanged += FuelCutoffUpdated;
				}
			}
		}

		private void ThrottleValueUpdated(float value)
		{
			baseControls.Throttle?.Move(value);
		}

		private void BrakeValueUpdated(float value)
		{
			baseControls.Brake?.Move(value);
		}

		private void ReverserValueUpdated(float value)
		{
			baseControls.Reverser?.Move(value);
		}

		private void IndBrakeValueUpdated(float value)
		{
			baseControls.IndependentBrake?.Move(value);
		}

		private void DynamicBrakeUpdated(float value)
		{
			baseControls.DynamicBrake?.Move(value);
		}

		private void HeadlightsValueUpdatedFront(float value)
		{
			baseControls.HeadlightsFront?.Move(value);
		}

		private void HeadlightsValueUpdatedRear(float value)
		{
			baseControls.HeadlightsRear?.Move(value);
		}

		private void HornValueUpdated(float value)
		{
			baseControls.Horn?.Move(value);
		}

		private void SandValueUpdated(float value)
		{
			baseControls.Sander?.Move(value);
		}

		private void HandbrakeValueUpdated(float value)
		{
			baseControls.Handbrake?.Move(value);
		}

		private void ReleaseCylValueUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.ReleaseCyl, (value > 0.5f) ? 1 : 0);
		}

		private void CylCockValueUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.CylCock, Mathf.RoundToInt(value));
		}

		private void InjectorValueUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Injector, Mathf.RoundToInt(value));
		}

		private void FiredoorValueUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Firedoor, Mathf.RoundToInt(value));
		}

		private void BlowerValueUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Blower, Mathf.RoundToInt(value));
		}

		private void DamperValueUpdated(float value)
		{
			if (value != 0f)
			{
				controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Damper, Mathf.RoundToInt(value));
			}
		}

		private void BlowdownValueUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Blowdown, Mathf.RoundToInt(value));
		}

		private void CoalDumpValueUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.CoalDump, Mathf.RoundToInt(value));
		}

		private void ShovelValueUpdated(float value)
		{
			if (value != 0f)
			{
				MagicShoveling component = baseControls.car.GetComponent<MagicShoveling>();
				if (component == null)
				{
					Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find MagicShoveling, UI shoveling won't work!");
				}
				else
				{
					component.AddCoalToFirebox(1);
				}
			}
		}

		private void LightFireboxUpdated(float value)
		{
			if (value != 0f)
			{
				baseControls.car.SimController.firebox.Ignite();
			}
		}

		private void BellUpdated(float value)
		{
			if (!controlsManager.TryGetControl(InteriorControlsManager.ControlType.Bell, out var reference))
			{
				return;
			}
			if (reference.controlImplBase is ToggleSwitchBase || reference.controlImplBase is ButtonBase)
			{
				if (!(value < 0.5f))
				{
					controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Bell, (reference.controlImplBase.Value < 0.5f) ? 1 : (-1));
				}
			}
			else
			{
				controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Bell, (int)value);
			}
		}

		private void StarterControlUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.StarterControl, (int)value);
		}

		private void CabLightUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.CabLight, (int)value);
		}

		private void WipersUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Wipers, (int)value);
		}

		private void DynamoUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.Dynamo);
		}

		private void AirPumpUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.AirPump);
		}

		private void LubricatorUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.Lubricator, (int)value);
		}

		private void StarterFuseUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.StarterFuse);
		}

		private void ElectricsFuseUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.ElectricsFuse);
		}

		private void TractionMotorFuseUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.TractionMotorFuse);
		}

		private void IndHeadlightsTypeFrontUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndHeadlightsTypeFront);
		}

		private void IndHeadlights1FrontUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndHeadlights1Front);
		}

		private void IndHeadlights2FrontUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndHeadlights2Front);
		}

		private void IndHeadlightsTypeRearUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndHeadlightsTypeRear);
		}

		private void IndHeadlights1RearUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndHeadlights1Rear);
		}

		private void IndHeadlights2RearUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndHeadlights2Rear);
		}

		private void IndWipers1Updated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndWipers1);
		}

		private void IndWipers2Updated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndWipers2);
		}

		private void IndCabLightUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndCabLight);
		}

		private void IndDashLightUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.IndDashLight);
		}

		private void BrakeCutoutUpdated(float value)
		{
			ToggleControlIfValue(value, InteriorControlsManager.ControlType.TrainBrakeCutout, -1);
		}

		private void GearboxAUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.GearboxA, (int)value);
		}

		private void GearboxBUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.GearboxB, (int)value);
		}

		private void FuelCutoffUpdated(float value)
		{
			controlsManager.MoveScrollable(InteriorControlsManager.ControlType.FuelCutoff, ((double)value > 0.5) ? 1 : (-1));
		}

		private void ToggleControlIfValue(float value, InteriorControlsManager.ControlType type, int direction = 1)
		{
			if (!(value < 0.5f) && controlsManager.TryGetControl(type, out var reference))
			{
				controlsManager.MoveScrollable(type, (reference.controlImplBase.Value < 0.5f) ? direction : (-direction));
			}
		}
	}
}
