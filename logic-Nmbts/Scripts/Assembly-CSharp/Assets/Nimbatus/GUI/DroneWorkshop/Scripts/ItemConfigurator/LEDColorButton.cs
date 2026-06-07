using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class LEDColorButton : MonoBehaviour
	{
		private ShowLEDDetails _ledSettings;

		public Color LedColor;

		public GameObject SelectedBorder;

		public void Init(ShowLEDDetails showLedDetails)
		{
			_ledSettings = showLedDetails;
		}

		public void OnClick()
		{
			_ledSettings.Select(this);
		}

		public void Update()
		{
			if (_ledSettings.SelectedColor == this)
			{
				SelectedBorder.gameObject.SetActive(true);
			}
			else
			{
				SelectedBorder.gameObject.SetActive(false);
			}
		}
	}
}
