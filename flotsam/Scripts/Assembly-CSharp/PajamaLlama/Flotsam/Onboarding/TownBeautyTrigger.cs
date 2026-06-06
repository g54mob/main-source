using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Onboarding
{
	[Serializable]
	public class TownBeautyTrigger : TutorialNotificationTriggerBase
	{
		[SerializeField]
		private int _beautyThreshold;

		public override void Update()
		{
			if (!base.WasTriggered && Community.PlayerCommunity.BeautyScore <= _beautyThreshold && Trigger())
			{
				GameEventDispatcher.Dispatch(GameEventType.UglyTownReached);
			}
		}
	}
}
