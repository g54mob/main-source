using UnityEngine;

namespace DV.Tutorial.QT
{
	public class RefillOilingPointStep : AQuickTutorialStep
	{
		private readonly Indicator oilingPointIndicator;

		private readonly float targetLevel;

		public RefillOilingPointStep(Indicator oilingPointIndicator, float targetLevel, AQuickTutorialMessage message, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, oilingPointIndicator.transform, attentionOffset, shouldRecheck)
		{
			this.oilingPointIndicator = oilingPointIndicator;
			this.targetLevel = targetLevel;
		}

		protected override bool InternalCheck()
		{
			return oilingPointIndicator.Value >= targetLevel;
		}

		protected override QTVerb GetVerb()
		{
			return QTVerb.Refill;
		}
	}
}
