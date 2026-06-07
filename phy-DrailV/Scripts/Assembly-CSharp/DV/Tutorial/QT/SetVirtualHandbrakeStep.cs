using DV.Simulation.Brake;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class SetVirtualHandbrakeStep : ALocoTutorialStep
	{
		private float targetMin;

		private float targetMax;

		private BrakeSystem brakeSystemOfHandbrake;

		public SetVirtualHandbrakeStep(TrainCar loco, BrakeSystem brakeSystemOfHandbrake, float targetMin, float targetMax, ControlIconQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3))
			: base(loco, message, semantic, attentionPoint, attentionOffset)
		{
			this.brakeSystemOfHandbrake = brakeSystemOfHandbrake;
			this.targetMin = targetMin;
			this.targetMax = targetMax;
		}

		protected override bool InternalCheck()
		{
			if (brakeSystemOfHandbrake == null || !brakeSystemOfHandbrake.hasHandbrake)
			{
				return true;
			}
			if (brakeSystemOfHandbrake.handbrakePosition >= targetMin)
			{
				return brakeSystemOfHandbrake.handbrakePosition <= targetMax;
			}
			return false;
		}

		protected override QTVerb GetVerb()
		{
			if (base.Semantic == QTSemantic.GentlyEngage)
			{
				return QTVerb.Brake_GentlyEngage;
			}
			if (ALocoControlStep.IsPositive(base.Semantic))
			{
				return QTVerb.Brake_FullyEngage;
			}
			return QTVerb.Brake_Disengage;
		}
	}
}
