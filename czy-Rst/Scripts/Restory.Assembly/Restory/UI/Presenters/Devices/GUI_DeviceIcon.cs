using Restory.Data.Devices;
using Restory.Data.Devices.Quality;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters.Devices
{
	public class GUI_DeviceIcon : MonoBehaviour
	{
		[SerializeField]
		private Image deviceIcon;

		[SerializeField]
		private Image qualityIcon;

		public void Initialize(DeviceInfo deviceInfo, DeviceQualityBase deviceQuality)
		{
			deviceIcon.overrideSprite = deviceInfo.Icon;
			qualityIcon.sprite = deviceQuality.Icon;
		}
	}
}
