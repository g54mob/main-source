using Restory.Data.Devices.Quality;
using Restory.UI.Views.CheckDevice;
using UnityEngine;

namespace Restory.UI.Presenters.CheckDevice
{
	public sealed class GUI_CheckDevicePanel : MonoBehaviour
	{
		[SerializeField]
		private GUI_CheckDevicePanelView view;

		[SerializeField]
		private string idealLocalizationID = "CHECK_DEVICE_PANEL_IDEAL_MESSAGE";

		[SerializeField]
		private string workingLocalizationID = "CHECK_DEVICE_PANEL_WORKING_MESSAGE";

		[SerializeField]
		private string errorMessageLocalizationID = "CHECK_DEVICE_PANEL_ERROR_MESSAGE";

		public void Show(DeviceQualityBase quality, bool instantly = false)
		{
			if (!(quality is IdealDeviceQuality))
			{
				if (!(quality is WorkingDeviceQuality))
				{
					if (quality is BrokenDeviceQuality)
					{
						view.ShowError(errorMessageLocalizationID, instantly);
					}
				}
				else
				{
					view.ShowTitle(workingLocalizationID, instantly);
				}
			}
			else
			{
				view.ShowTitle(idealLocalizationID, instantly);
			}
		}

		public void Hide()
		{
			view.HideTitle();
			view.HideError();
		}
	}
}
