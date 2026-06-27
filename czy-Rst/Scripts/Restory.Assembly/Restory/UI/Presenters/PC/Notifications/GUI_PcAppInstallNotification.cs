using Restory.Data.PC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters.PC.Notifications
{
	public class GUI_PcAppInstallNotification : GUI_PcNotificationBase
	{
		[SerializeField]
		private TextMeshProUGUI appName;

		[SerializeField]
		private Button confirmButton;

		private PcAppInfo appInfo;

		public PcAppInfo AppInfo => appInfo;

		public Button ConfirmButton => confirmButton;

		private void OnDisable()
		{
			confirmButton.onClick.RemoveAllListeners();
			appInfo = null;
		}

		public void Init(PcAppInfo appInfo, string appLocalizedName)
		{
			this.appInfo = appInfo;
			appName.text = appLocalizedName;
		}
	}
}
