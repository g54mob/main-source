using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Computer;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.Vending_Machine.VendingPanelGamepad
{
	public class VendingSlotGamepadParent : MonoBehaviour
	{
		[SerializeField]
		private VendingComputerSlotGamepadHandler m_BuyButtonHandler;

		[SerializeField]
		private GamePadUIPanel m_ParentPanel;

		private List<VendingComputerSlotGamepadHandler> m_VendingComputerSlotGamepadHandlers;

		private __Project__.Scripts.Computer.Computer m_Computer;

		public VendingComputerSlotGamepadHandler BuyButtonHandler => null;

		public void Initialize(List<VendingComputerSlotGamepadHandler> vendingComputerSlotGamepadHandlers)
		{
		}

		private void SetNeighborhoods()
		{
		}

		public void OnNewSlotBought(List<VendingComputerSlotGamepadHandler> vendingComputerSlotGamepadHandlers)
		{
		}

		public void OnGamepadSwitch(bool isGamepad)
		{
		}
	}
}
