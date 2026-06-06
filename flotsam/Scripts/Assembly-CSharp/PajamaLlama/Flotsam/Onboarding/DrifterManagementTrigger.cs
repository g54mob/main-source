using System;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class DrifterManagementTrigger : TutorialNotificationTriggerBase
	{
		public override void Update()
		{
			if (!base.WasTriggered && GameManager.UIManager.IsPanelOpen(PanelID.AssignmentPanel) && Trigger())
			{
				GameEventDispatcher.Dispatch(GameEventType.DrifterDutiesPanelOpened);
			}
		}
	}
}
