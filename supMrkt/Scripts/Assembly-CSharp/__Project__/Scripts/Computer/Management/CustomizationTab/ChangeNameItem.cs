using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Cameras;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Computer.Management.CustomizationTab
{
	public class ChangeNameItem : CustomizationItem
	{
		[SerializeField]
		private TextMeshProUGUI m_MoneyText;

		[SerializeField]
		private Button m_SwitchCameraButton;

		[SerializeField]
		private float m_Price;

		[SerializeField]
		private GamepadUISelectable m_gamepadUISelectable;

		private DoorSwitchCamera m_SwitchCamera;

		private void Start()
		{
		}

		public void SwitchCameraToDoor()
		{
		}

		private void UpdatePurchaseButton(float money, MoneyManager.TransitionType type)
		{
		}

		private void CheckRequirements(bool isIncreased)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
