using DV.HUD;
using DV.Simulation.Controllers;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class ManualGearShiftStep : ALocoControlStep
	{
		private readonly bool shouldBeInGear;

		private readonly GearShifter gearShifter;

		public ManualGearShiftStep(TrainCar loco, bool shouldBeInGear, InteriorControlsManager.ControlType controlType, AQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, controlType, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.shouldBeInGear = shouldBeInGear;
			ManualGearShiftingController manualGearShiftingController = loco?.SimController?.gearShiftingController;
			if (!(manualGearShiftingController != null))
			{
				return;
			}
			GearShifter[] entries = manualGearShiftingController.entries;
			foreach (GearShifter gearShifter in entries)
			{
				if ((gearShifter.isGearboxA && controlType == InteriorControlsManager.ControlType.GearboxA) || (!gearShifter.isGearboxA && controlType == InteriorControlsManager.ControlType.GearboxB))
				{
					this.gearShifter = gearShifter;
					break;
				}
			}
		}

		protected override bool InternalCheck()
		{
			if (gearShifter == null)
			{
				return true;
			}
			if (!shouldBeInGear)
			{
				return gearShifter.InNeutral;
			}
			return !gearShifter.InNeutral;
		}
	}
}
