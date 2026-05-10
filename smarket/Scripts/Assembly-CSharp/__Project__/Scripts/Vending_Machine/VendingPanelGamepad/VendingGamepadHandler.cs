using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Computer.Vending_Machine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Vending_Machine.VendingPanelGamepad
{
	[RequireComponent(typeof(GamePadUIPanel))]
	public class VendingGamepadHandler : MonoBehaviour
	{
		private GamePadUIPanel m_GamePadUIPanel;

		[SerializeField]
		private VendingSlotGamepadParent m_VendingSlotGamepadParent;

		[SerializeField]
		private VendingTrackerPanelGamepadHandler m_VendingTrackerPanelGamepadHandler;

		[SerializeField]
		private VendingMachineTab m_VendingMachineTab;

		private List<VendingComputerSlotGamepadHandler> m_VendingComputerSlotGamepadHandlers;

		private VendingComputerSlotGamepadHandler m_SelectedSlotGamepadHandler;

		private VendingMachineComputerSlot m_SelectedSlot;

		public GamePadUIPanel GamePadPanel => null;

		private void OnEnable()
		{
		}

		private void OnLeftComputer()
		{
		}

		private void OnDisable()
		{
		}

		public void OnGamepadSwitch(bool isGamepad)
		{
		}

		public void SetSelectedVendingMachineSlot(VendingMachineComputerSlot slot)
		{
		}

		public void Initialize()
		{
		}

		public void OnSlotConfirm()
		{
		}

		public void OnSlotBack()
		{
		}

		private void FocusToTrackerMenu()
		{
		}

		public void FocusBackToSlot()
		{
		}

		public void OnBuyButtonConfirmGamepad()
		{
		}
	}
}
