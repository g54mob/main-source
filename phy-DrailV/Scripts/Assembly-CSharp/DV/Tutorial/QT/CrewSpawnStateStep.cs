using UnityEngine;

namespace DV.Tutorial.QT
{
	public class CrewSpawnStateStep : ACommsRadioStep<CommsRadioCrewVehicle>
	{
		private CommsRadioCrewVehicle.State minimumState;

		private CommsRadioCrewVehicle.State tempState;

		private string originalMessage;

		private string tempMessage;

		private bool usingTempState;

		private bool wasInTempState;

		public CrewSpawnStateStep(string message, CommsRadioCrewVehicle.State minimumState, string tempMessage, CommsRadioCrewVehicle.State tempState, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(message, attentionPoint, attentionOffset, shouldRecheck)
		{
			usingTempState = true;
			this.minimumState = minimumState;
			this.tempMessage = tempMessage;
			this.tempState = tempState;
			originalMessage = message;
		}

		public CrewSpawnStateStep(string message, CommsRadioCrewVehicle.State minimumState, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
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
			CommsRadioCrewVehicle modeController = GetModeController();
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
					AttentionPoint = modeController.Highlighter.Renderer.transform;
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
