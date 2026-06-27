using Restory.Data.SaveLoad;
using Restory.Gameplay.Equipment.CashRegisters;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.Inventory;

namespace Restory.Gameplay.MoneyCash
{
	public class TransferCashMoneyFromCashRegisterService
	{
		private readonly CashRegister cashRegister;

		private readonly Wallet wallet;

		private readonly CashMoneyObjectFactory factory;

		private readonly CashMoneyObjectRegistry registry;

		private readonly InteractiveObjectRegistry interactiveObjectRegistry;

		private readonly IDService idService;

		private CashMoneyObject takenCashMoneyObject;

		public bool IsTakingMoney => takenCashMoneyObject != null;

		public CashMoneyObject TakenCashMoneyObject => takenCashMoneyObject;

		public TransferCashMoneyFromCashRegisterService(CashMoneyObjectFactory factory, CashMoneyObjectRegistry registry, InteractiveObjectRegistry interactiveObjectRegistry, CashRegister cashRegister, Wallet wallet, IDService idService)
		{
			this.factory = factory;
			this.registry = registry;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.cashRegister = cashRegister;
			this.wallet = wallet;
			this.idService = idService;
		}

		public bool TryStartTransfer(int moneyAmount, out CashMoneyObject cashMoneyObject)
		{
			if (!wallet.TryToRemove(moneyAmount))
			{
				cashMoneyObject = null;
				return false;
			}
			takenCashMoneyObject = factory.Create(moneyAmount);
			takenCashMoneyObject.transform.position = cashRegister.transform.position;
			SubscribeTakenObject();
			cashMoneyObject = takenCashMoneyObject;
			return true;
		}

		private void SubscribeTakenObject()
		{
			takenCashMoneyObject.InteractiveObject.OnDragComplete += ResolveDragComplete;
			takenCashMoneyObject.InteractiveObject.OnDragCanceled += ResolveDragCanceled;
			takenCashMoneyObject.InteractiveObject.OnRemove += ResolveOnRemove;
		}

		private void UnsubscribeTakenObject()
		{
			takenCashMoneyObject.InteractiveObject.OnDragComplete -= ResolveDragComplete;
			takenCashMoneyObject.InteractiveObject.OnDragCanceled -= ResolveDragCanceled;
			takenCashMoneyObject.InteractiveObject.OnRemove -= ResolveOnRemove;
		}

		private void RegisterTakenObject()
		{
			UnsubscribeTakenObject();
			if (takenCashMoneyObject != null)
			{
				takenCashMoneyObject.InteractiveObject.Init(InteractiveObjectState.Stored, idService.GenerateNew(), false);
				registry.Register(takenCashMoneyObject);
				interactiveObjectRegistry.Register(takenCashMoneyObject.InteractiveObject, factory.CashMoneyItemInfo);
			}
			takenCashMoneyObject = null;
		}

		private void RevertMoneyAndDestroyTakenObject()
		{
			UnsubscribeTakenObject();
			wallet.TryToAdd(takenCashMoneyObject.MoneyAmountHeld);
			factory.Destroy(takenCashMoneyObject);
			takenCashMoneyObject = null;
		}

		private void ResolveDragComplete()
		{
			RegisterTakenObject();
		}

		private void ResolveDragCanceled()
		{
			RevertMoneyAndDestroyTakenObject();
		}

		private void ResolveOnRemove()
		{
			UnsubscribeTakenObject();
			takenCashMoneyObject = null;
		}
	}
}
