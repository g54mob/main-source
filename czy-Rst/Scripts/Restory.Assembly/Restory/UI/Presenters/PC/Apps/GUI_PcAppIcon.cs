using Restory.Data.PC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters.PC.Apps
{
	public class GUI_PcAppIcon : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI appName;

		[SerializeField]
		private Button button;

		[SerializeField]
		private Image image;

		public PcAppInfo AppInfo { get; private set; }

		public Button Button => button;

		private void OnDisable()
		{
			button.onClick.RemoveAllListeners();
			AppInfo = null;
		}

		public void Init(PcAppInfo appInfo, string appLocalizedName)
		{
			AppInfo = appInfo;
			appName.text = appLocalizedName;
			image.sprite = appInfo.DesktopIcon;
		}
	}
}
