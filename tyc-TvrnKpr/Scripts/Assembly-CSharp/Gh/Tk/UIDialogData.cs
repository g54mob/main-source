using System.Collections.Generic;

namespace Gh.Tk
{
	public class UIDialogData : IPersistable
	{
		public string dialogTypeId;

		public List<UIDialogPageData> pages;

		public bool canCloseDialogWithoutDecision;

		public List<NotificationDecision> decisionButtons;

		public Dictionary<string, string> customDisplayValues;

		public static NotificationDecision GetDefaultNextPageButton()
		{
			return null;
		}

		public static NotificationDecision GetDefaultFinalPageButton()
		{
			return null;
		}
	}
}
