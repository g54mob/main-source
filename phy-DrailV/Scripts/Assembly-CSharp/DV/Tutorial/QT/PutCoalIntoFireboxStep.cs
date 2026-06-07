using DV.Simulation.Cars;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class PutCoalIntoFireboxStep : AQuickTutorialStep
	{
		private readonly FireboxSimController fireboxSimController;

		private float normalizedTargetLevel;

		private float startingLevel;

		private bool requireAtLeastOneShovel;

		public PutCoalIntoFireboxStep(FireboxSimController fireboxSimController, float normalizedTargetLevel, bool requireAtLeastOneShovel, string message, Transform attentionPoint, Vector3 offset = default(Vector3))
			: base(message, attentionPoint, offset, shouldRecheck: false)
		{
			this.fireboxSimController = fireboxSimController;
			this.normalizedTargetLevel = normalizedTargetLevel;
			this.requireAtLeastOneShovel = requireAtLeastOneShovel;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			if (requireAtLeastOneShovel && fireboxSimController.NormalizedFireboxContents > 0.95f)
			{
				fireboxSimController.TransferCoal(-1f * fireboxSimController.FireboxCapacity * 0.5f * fireboxSimController.coalConsumptionMultiplier);
			}
			startingLevel = fireboxSimController.NormalizedFireboxContents;
		}

		protected override bool InternalCheck()
		{
			if (requireAtLeastOneShovel && startingLevel >= fireboxSimController.NormalizedFireboxContents)
			{
				return false;
			}
			return fireboxSimController.NormalizedFireboxContents > normalizedTargetLevel;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.PutInto;
		}
	}
}
