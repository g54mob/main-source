using UnityEngine;
using UnityEngine.EventSystems;
using __Project__.Scripts.Computer.Vending_Machine;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Vending_Machine.VendingPanelGamepad
{
	public class VendingComputerSlotGamepadHandler : GamepadUISelectable
	{
		[SerializeField]
		private VendingMachineComputerSlot m_VendingMachineComputerSlot;

		public bool IsVendingMachinePlaced => false;

		public override void OnSelect(BaseEventData eventData)
		{
		}

		public void OnConfirm()
		{
		}

		public void OnBack()
		{
		}

		public void OnGamePadSwitch(bool isGamepad)
		{
		}
	}
}
