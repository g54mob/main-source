using System;

namespace Doozy.Engine.UI
{
	[Serializable]
	public class UIPopupQueueData
	{
		public UIPopup Popup;

		public string PopupName;

		public bool InstantAction;

		public UIPopupQueueData(UIPopup popup, bool instantAction = false)
		{
		}

		public UIPopupQueueData(string popupName, UIPopup popup, bool instantAction = false)
		{
		}

		public UIPopup Show()
		{
			return null;
		}
	}
}
