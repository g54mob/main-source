using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.OperatorUIs.OperatorHoverUIs
{
	public class DroneInfoView : MonoBehaviour
	{
		[SerializeField]
		private Transform _droneInformationPanel;

		[SerializeField]
		private TextMeshProUGUI _droneServiceTimeText;

		[SerializeField]
		private Image _droneSpeedWarningIcon;

		[SerializeField]
		[LocaKey]
		private string _droneServiceTimeLocaKey;

		public void Show(bool show)
		{
			base.gameObject.SetActive(show);
		}

		public void SetContent(float totalTimeInSeconds, bool droneIsFastEnough)
		{
			_droneInformationPanel.gameObject.SetActive(value: true);
			string text = $"{totalTimeInSeconds:0.00}s";
			text = (droneIsFastEnough ? text : ("<style=\"Error\">" + text + "</style>"));
			string text2 = LocalizationUtility.GetLocalizedText(_droneServiceTimeLocaKey) + " " + text;
			_droneServiceTimeText.text = text2;
			_droneSpeedWarningIcon.gameObject.SetActive(!droneIsFastEnough);
		}
	}
}
