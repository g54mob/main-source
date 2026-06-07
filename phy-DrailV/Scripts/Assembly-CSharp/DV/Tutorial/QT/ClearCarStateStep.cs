using UnityEngine;

namespace DV.Tutorial.QT
{
	public class ClearCarStateStep : ACommsRadioStep<CommsRadioCarDeleter>
	{
		private CommsRadioCarDeleter.State minimumState;

		private CommsRadioCarDeleter.State tempState;

		private string originalMessage;

		private string tempMessage;

		private bool usingTempState;

		private bool wasInTempState;

		public ClearCarStateStep(string message, CommsRadioCarDeleter.State minimumState, string tempMessage, CommsRadioCarDeleter.State tempState, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			usingTempState = true;
			this.minimumState = minimumState;
			this.tempMessage = tempMessage;
			this.tempState = tempState;
			originalMessage = message;
		}

		public ClearCarStateStep(string message, CommsRadioCarDeleter.State minimumState, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			usingTempState = false;
			this.minimumState = minimumState;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			wasInTempState = false;
		}

		protected override bool InternalCheck()
		{
			CommsRadioCarDeleter modeController = GetModeController();
			if (modeController == null)
			{
				return false;
			}
			if (usingTempState)
			{
				if (modeController.CurrentState == tempState && !wasInTempState)
				{
					wasInTempState = true;
					Message = tempMessage;
					AttentionPoint = modeController.trainHighlighter.transform;
					ShowVisual();
				}
				else if (modeController.CurrentState != tempState && wasInTempState)
				{
					wasInTempState = false;
					Message = originalMessage;
					AttentionPoint = null;
					ShowVisual();
				}
			}
			if (modeController.CurrentState >= minimumState)
			{
				if (usingTempState)
				{
					return modeController.CurrentState != tempState;
				}
				return true;
			}
			return false;
		}
	}
}
