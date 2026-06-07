using System;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class DrifterExpertiseTrigger : TutorialNotificationTriggerBase
	{
		public override void Update()
		{
			if (!base.WasTriggered && GameManager.UIManager.IsPanelOpen(PanelID.ExpertisePanel) && Trigger())
			{
				GameEventDispatcher.Dispatch(GameEventType.DrifterExpertisePanelOpened);
			}
		}
	}
}
