using System;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class EnergyManagementTrigger : TutorialNotificationTriggerBase
	{
		public override void Initialize(bool gotTriggered = false)
		{
			base.Initialize(gotTriggered);
			if (!gotTriggered)
			{
				GameEventDispatcher.AddListener(GameEventType.BuildableBuilt, EnergyBuildingBuilt);
			}
		}

		private void EnergyBuildingBuilt(GameEvent gameEvent)
		{
			if (gameEvent is BuildableEvent buildableEvent && buildableEvent.Buildable.TryReturnBuildableExtendable<EnergyGridBuildableComponent>(out var _))
			{
				GameEventDispatcher.RemoveListener(GameEventType.BuildableBuilt, EnergyBuildingBuilt);
				if (Trigger())
				{
					GameEventDispatcher.Dispatch(GameEventType.EnergyBuildableBuilt);
				}
			}
		}
	}
}
