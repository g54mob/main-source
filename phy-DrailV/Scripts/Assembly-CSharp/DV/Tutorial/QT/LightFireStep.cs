using DV.Simulation.Cars;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LightFireStep : ALocoTutorialStep
	{
		private bool targetValue;

		private BaseControlsOverrider overrider;

		public LightFireStep(TrainCar loco, BaseControlsOverrider overrider, bool targetValue, string message, Transform fireAnchor, Vector3 attentionOffset = default(Vector3))
			: base(loco, message, QTSemantic.Ignite, fireAnchor, attentionOffset)
		{
			this.overrider = overrider;
			this.targetValue = targetValue;
			ShouldRecheck = false;
		}

		protected override bool InternalCheck()
		{
			if (overrider == null || overrider.EngineOnReader == null)
			{
				return true;
			}
			return overrider.EngineOnReader.IsOn == targetValue;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Ignite;
		}
	}
}
