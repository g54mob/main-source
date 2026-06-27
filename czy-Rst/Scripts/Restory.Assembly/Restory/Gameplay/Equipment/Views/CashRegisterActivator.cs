using Restory.Gameplay.Equipment.CashRegisters;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public class CashRegisterActivator : EquipmentActivatorBase
	{
		[SerializeField]
		private CashRegister cashRegister;

		public override void RestoreState(bool isActivated)
		{
			base.IsActivated = isActivated;
			cashRegister.SetCashDrawerState(CashDrawerState.Closed, animate: false);
		}

		public override void Activate()
		{
			base.IsActivated = true;
			cashRegister.SetCashDrawerState(CashDrawerState.Closed, animate: true);
		}

		public override void ToggleIndicator(bool isActive)
		{
			base.ToggleIndicator(isActive);
			cashRegister.SetCashDrawerState(isActive ? CashDrawerState.PartiallyOpen : CashDrawerState.Closed, animate: true);
		}
	}
}
