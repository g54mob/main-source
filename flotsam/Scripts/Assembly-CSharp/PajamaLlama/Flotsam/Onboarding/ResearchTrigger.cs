using System;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class ResearchTrigger : TutorialNotificationTriggerBase
	{
		private bool _isResearchBuildingBuilt;

		public override void Initialize(bool gotTriggered = false)
		{
			base.Initialize(gotTriggered);
			if (!gotTriggered)
			{
				GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, ResearchBuildingBuilt);
			}
		}

		private void ResearchBuildingBuilt(GameEvent gameEvent)
		{
			if (gameEvent is BuildableEvent buildableEvent && buildableEvent.Buildable.TryReturnBuildableExtendable<ResearchStation>(out var _))
			{
				GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, ResearchBuildingBuilt);
				if (Trigger())
				{
					GameEventDispatcher.Dispatch(GameEventType.TechTreeOpened);
				}
			}
		}
	}
}
