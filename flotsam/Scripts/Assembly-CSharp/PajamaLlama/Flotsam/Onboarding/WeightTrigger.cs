using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class WeightTrigger : TutorialNotificationTriggerBase
	{
		[Tooltip("Specific weight tier reached")]
		[SerializeField]
		private WeightTier _weightTierThreshold;

		public override void Initialize(bool gotTriggered = false)
		{
			base.Initialize(gotTriggered);
			if (!gotTriggered)
			{
				GameEventDispatcher.AddListener(GameEventType.WeightTierUpdated, OnWeightTierUpdated);
			}
		}

		private void OnWeightTierUpdated(GameEvent gameEvent)
		{
			if (gameEvent is WeightEvent weightEvent && weightEvent.WeightTier.EelsPerUnit >= _weightTierThreshold.EelsPerUnit)
			{
				GameEventDispatcher.RemoveListener(GameEventType.WeightTierUpdated, OnWeightTierUpdated);
				if (Trigger())
				{
					GameEventDispatcher.Dispatch(GameEventType.WeightTierHeavy);
				}
			}
		}
	}
}
