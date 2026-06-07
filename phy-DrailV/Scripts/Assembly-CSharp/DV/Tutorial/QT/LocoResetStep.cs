using DV.HUD;
using DV.Simulation.Cars;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LocoResetStep : ALocoTutorialStep
	{
		private BaseControlsOverrider overrider;

		private InteriorControlsManager controls;

		public LocoResetStep(TrainCar loco)
			: base(loco, "", QTSemantic.Look, null, Vector3.zero, shouldRecheck: false)
		{
			if ((bool)loco)
			{
				overrider = loco.GetComponentInChildren<BaseControlsOverrider>(includeInactive: true);
				controls = loco.interior.GetComponentInChildren<InteriorControlsManager>();
			}
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			if ((bool)overrider)
			{
				overrider.SetNeutralState();
				if (controls.TryGetControl(InteriorControlsManager.ControlType.ElectricsFuse, out var reference))
				{
					reference.controlImplBase.SetValue(0f);
				}
				if (controls.TryGetControl(InteriorControlsManager.ControlType.StarterFuse, out var reference2))
				{
					reference2.controlImplBase.SetValue(0f);
				}
				if (controls.TryGetControl(InteriorControlsManager.ControlType.TractionMotorFuse, out var reference3))
				{
					reference3.controlImplBase.SetValue(0f);
				}
				if (controls.TryGetControl(InteriorControlsManager.ControlType.CabLight, out var reference4))
				{
					reference4.controlImplBase.SetValue(0f);
				}
				if (controls.TryGetControl(InteriorControlsManager.ControlType.StarterControl, out var reference5))
				{
					reference5.controlImplBase.SetValue(0f);
				}
				if (controls.TryGetControl(InteriorControlsManager.ControlType.GearboxA, out var reference6))
				{
					reference6.controlImplBase.SetValue(0f);
				}
				if (controls.TryGetControl(InteriorControlsManager.ControlType.GearboxB, out var reference7))
				{
					reference7.controlImplBase.SetValue(0f);
				}
				overrider = null;
			}
		}

		protected override bool InternalCheck()
		{
			return true;
		}
	}
}
