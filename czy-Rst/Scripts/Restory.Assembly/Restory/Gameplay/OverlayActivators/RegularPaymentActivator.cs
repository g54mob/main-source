using System;
using Restory.Gameplay.Equipment.CashRegisters;
using Restory.Gameplay.RegularPayments;
using Restory.UI.Presenters.RegularPayment;
using Zenject;

namespace Restory.Gameplay.OverlayActivators
{
	public class RegularPaymentActivator : WindowActivatorBase, IInitializable, IDisposable
	{
		private GUI_RegularPayment guiRegularPayment;

		private CashRegister cashRegister;

		private RegularPaymentObjectRegistry regularPaymentObjectRegistry;

		public override bool IsActivated => guiRegularPayment.IsVisible;

		[Inject]
		private void Construct(RegularPaymentObjectRegistry regularPaymentObjectRegistry, GUI_RegularPayment guiRegularPayment, CashRegister cashRegister)
		{
			this.regularPaymentObjectRegistry = regularPaymentObjectRegistry;
			this.guiRegularPayment = guiRegularPayment;
			this.cashRegister = cashRegister;
		}

		public void Initialize()
		{
			regularPaymentObjectRegistry.OnRegistered += ResolveOnRegistered;
			regularPaymentObjectRegistry.OnUnregistered += ResolveOnUnregistered;
			foreach (RegularPaymentObject item in regularPaymentObjectRegistry.All)
			{
				ResolveOnRegistered(item);
			}
		}

		public void Dispose()
		{
			regularPaymentObjectRegistry.OnRegistered -= ResolveOnRegistered;
			regularPaymentObjectRegistry.OnUnregistered -= ResolveOnUnregistered;
		}

		public void HideWindow()
		{
			if (guiRegularPayment.IsVisible)
			{
				guiRegularPayment.Hide();
			}
		}

		private void ResolveOnRegistered(RegularPaymentObject regularPaymentObject)
		{
			regularPaymentObject.OnClicked += ResolveOnClicked;
		}

		private void ResolveOnUnregistered(RegularPaymentObject regularPaymentObject)
		{
			regularPaymentObject.OnClicked -= ResolveOnClicked;
		}

		private void ResolveOnClicked(RegularPaymentObject regularPaymentObject)
		{
			cashRegister.SetCashDrawerState(CashDrawerState.PartiallyOpen, animate: true);
			guiRegularPayment.Show(regularPaymentObject);
		}
	}
}
