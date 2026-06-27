using Restory.Data.PC;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_PcAppToolbarButton : GUI_PcWindowsXpToolbarButton
	{
		[SerializeField]
		private Image appIcon;

		[SerializeField]
		private TextMeshProUGUI appName;

		public PcAppInfo AppInfo { get; private set; }

		public void Init(PcAppInfo appInfo, string appLocalizedName)
		{
			AppInfo = appInfo;
			appName.text = appLocalizedName;
			appIcon.sprite = appInfo.DesktopIcon;
		}
	}
}
