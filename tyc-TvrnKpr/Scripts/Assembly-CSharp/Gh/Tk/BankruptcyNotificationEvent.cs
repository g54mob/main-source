using System.Collections.Generic;

namespace Gh.Tk
{
	public class BankruptcyNotificationEvent : SimpleNotificationEvent
	{
		private static List<BankruptcyEpilogue> _epilogueData;

		private static BankruptcyEpilogue GetRandomEpilogue()
		{
			return null;
		}

		private static string GetBankruptcyNoticeText()
		{
			return null;
		}

		public static void Fire()
		{
		}

		protected BankruptcyNotificationEvent()
		{
		}

		public BankruptcyNotificationEvent(UINotificationData uiNotificationData)
		{
		}

		protected override void OnDecisionCallback(int option)
		{
		}
	}
}
