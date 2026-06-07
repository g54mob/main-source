using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class PopupNotificationReferences : MonoBehaviour
	{
		[Header("Notifications")]
		public NotificationManager notificationManager;

		[Header("Popups")]
		public PopupManager popupManager;

		public Popup popup3Buttons;

		public Popup popupOk;

		public Popup popupTextInput;

		public Popup pupupTextInputWithDelete;

		public Popup popupWaitSpinner;

		public Popup popupYesNo;

		public Popup popupSlider;
	}
}
