using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.Vending_Machine;
using __Project__.Scripts.Vending_Machine.VendingPanelGamepad;

namespace __Project__.Scripts.Computer.Vending_Machine
{
	public class VendingMachineTab : NoktaSingleton<VendingMachineTab>
	{
		public VendingMachineComputerSlot vendingMachineComputerSlot;

		[Space]
		[SerializeField]
		private List<VendingData> vendingDataList;

		[Space]
		[SerializeField]
		private VendingMachineSO m_VendingMachineSO;

		[Space]
		public Transform slotParent;

		[Space]
		[SerializeField]
		private Button buyButton;

		[SerializeField]
		private TextMeshProUGUI buyButtonText;

		[SerializeField]
		private Button m_SetWaypointButton;

		[SerializeField]
		private Button m_HighlightOnMapButton;

		[SerializeField]
		private VendingGamepadHandler m_VendingGamepadHandler;

		[SerializeField]
		private NetworkVendingMachineTab _networkVendingMachineTab;

		public VendingGamepadHandler VendingGamepadHandler => null;

		private void Awake()
		{
		}

		private void OnMoneyChange(float arg1, MoneyManager.TransitionType arg2)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void LoadVendingData(List<VendingData> vendingData)
		{
		}

		public void ShowSlot()
		{
		}

		public void SpawnSlot()
		{
		}

		public void CreateNewSlot(VendingData vendingData)
		{
		}

		public float SellCost()
		{
			return 0f;
		}

		public VendingMachineComputerSlot GetVendingMachineComputerSlot(int uniqueID)
		{
			return null;
		}

		public void PlaceControlFunc(int uniqueID)
		{
		}

		public void PlaceControl(int uniqueID)
		{
		}

		public void BoxUpControlFunc(int uniqueID)
		{
		}

		public void BoxUpControl(int uniqueID)
		{
		}

		private void OnEnableControl()
		{
		}

		public void SelectedSlotFunc(int uniqueID)
		{
		}

		public void SelectedSlot(int uniqueID)
		{
		}

		public void DeleteSlotFunc(int uniqueID)
		{
		}

		public void DeleteSlot(int uniqueID)
		{
		}

		public void OnSetWaypointPressed()
		{
		}

		public void OnHighlightOnMapPressed()
		{
		}
	}
}
