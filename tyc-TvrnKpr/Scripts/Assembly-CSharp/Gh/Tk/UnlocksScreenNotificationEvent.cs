using System.Collections.Generic;

namespace Gh.Tk
{
	public class UnlocksScreenNotificationEvent : SimpleNotificationEvent
	{
		public List<string> PropTemplateIds { get; set; }

		public int GiftTier { get; set; }

		public static void FireGiftBoxEvent(List<string> idsToShow, int giftTier)
		{
		}

		public static void FireGeneralPropEvent(List<string> templateIds)
		{
		}

		public static string CreateTitle(List<string> templates)
		{
			return null;
		}

		protected UnlocksScreenNotificationEvent()
		{
		}

		public UnlocksScreenNotificationEvent(int giftTier, List<string> templateIds, UINotificationData uiNotificationData)
		{
		}

		public UnlocksScreenNotificationEvent(List<string> templateIds, UINotificationData uiNotificationData)
		{
		}

		public override string GetGroupId()
		{
			return null;
		}

		protected override void ShowNotification()
		{
		}

		protected override void OnDecisionCallback(int option)
		{
		}

		protected override void OnDismissCallback()
		{
		}

		public void UpdateTitle()
		{
		}

		public void OnUnlocksCollected()
		{
		}

		private void MarkUnlocksSeen()
		{
		}
	}
}
