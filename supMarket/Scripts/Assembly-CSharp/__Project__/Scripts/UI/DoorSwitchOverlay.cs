using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using __Project__.Scripts.Cameras;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.UI
{
	public class DoorSwitchOverlay : MonoBehaviour
	{
		[SerializeField]
		private Button m_ApproveButton;

		[SerializeField]
		private Button m_CancelButton;

		[SerializeField]
		private TMP_Text m_PriceText;

		[SerializeField]
		private TMP_Text m_ApprovedCanvas;

		[SerializeField]
		private TMP_Text m_SwitchTitleText;

		[SerializeField]
		private LocalizeStringEvent m_LocalizedCostText;

		[SerializeField]
		private GamePadUIPanel m_gamepadPanel;

		private DoorSwitchCamera m_DoorCamera;

		private float m_Price;

		private int m_Index;

		public void Initialize(float price, int index, DoorSwitchCamera switchCamera)
		{
		}

		public void Approve()
		{
		}

		public void Cancel()
		{
		}

		public void SwitchIndexForGamepad(bool isLeft)
		{
		}

		private void OnDisable()
		{
		}
	}
}
