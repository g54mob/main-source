using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Cameras;
using __Project__.Scripts.Computer.Management.CustomizationTab;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.EntranceVariants
{
	public class EntranceChangeItem : CustomizationItem
	{
		[SerializeField]
		private Button m_SwitchCameraButton;

		private DoorSwitchCamera m_DoorCam;

		[SerializeField]
		private float m_Price;

		[SerializeField]
		private TMP_Text m_PriceText;

		[SerializeField]
		private GamepadUISelectable m_gamepadUISelectable;

		private void Start()
		{
		}

		public void SwitchCameraToDoor()
		{
		}

		private void UpdatePurchaseButton(float money, MoneyManager.TransitionType type)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
