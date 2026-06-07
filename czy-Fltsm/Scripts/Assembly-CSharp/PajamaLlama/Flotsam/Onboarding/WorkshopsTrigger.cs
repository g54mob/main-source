using System;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class WorkshopsTrigger : TutorialNotificationTriggerBase
	{
		public override void Initialize(bool gotTriggered = false)
		{
			base.Initialize(gotTriggered);
			if (!gotTriggered)
			{
				GameEventDispatcher.AddListener(GameEventType.BuildableSelected, ProducerSelected);
			}
		}

		private void ProducerSelected(GameEvent gameEvent)
		{
			if (gameEvent is BuildableEvent buildableEvent && buildableEvent.Buildable.TryReturnBuildableExtendable<Producer>(out var buildableExtendable) && buildableExtendable.ProductionProperties.Type == Producer.Type.Workshop)
			{
				GameEventDispatcher.RemoveListener(GameEventType.BuildableSelected, ProducerSelected);
				if (Trigger())
				{
					GameEventDispatcher.Dispatch(GameEventType.WorkshopSelected);
				}
			}
		}
	}
}
