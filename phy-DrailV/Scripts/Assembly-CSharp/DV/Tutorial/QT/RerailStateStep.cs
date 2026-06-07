using UnityEngine;

namespace DV.Tutorial.QT
{
	public class RerailStateStep : ACommsRadioStep<RerailController>
	{
		private RerailController.State minimumState;

		public RerailStateStep(string message, RerailController.State minimumState, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			this.minimumState = minimumState;
		}

		protected override bool InternalCheck()
		{
			RerailController modeController = GetModeController();
			if (modeController == null)
			{
				return false;
			}
			return modeController.CurrentState >= minimumState;
		}
	}
}
