using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class NotificationUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		[SerializeField]
		private Notification notification;

		private void Start()
		{
			notification.gameObject.SetActive(value: false);
			button.onClick.AddListener(OnButtonClick);
		}

		public void OnButtonClick()
		{
			notification.OnCancel.RemoveAllListeners();
			notification.OnCancel.AddListener(NotificationCancel);
			notification.ShowNotification();
		}

		private void NotificationCancel()
		{
			Debug.Log("Cancel Button Clicked");
		}
	}
}
