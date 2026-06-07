using DV.HUD;
using DV.Simulation.Cars;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LocoEngineStep : ALocoControlStep
	{
		private bool targetValue;

		private BaseControlsOverrider overrider;

		public LocoEngineStep(TrainCar loco, InteriorControlsManager.ControlType controlType, BaseControlsOverrider overrider, bool targetValue, ControlIconQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, controlType, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.overrider = overrider;
			this.targetValue = targetValue;
		}

		protected override bool InternalCheck()
		{
			if (overrider == null || overrider.EngineOnReader == null)
			{
				return true;
			}
			return overrider.EngineOnReader.IsOn == targetValue;
		}
	}
}
