using System;
using Restory.Data.SaveLoad;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.UI.Presenters.Notifications;
using Zenject;

namespace Restory.Gameplay.Tips
{
	public class TipBoxService : IInitializable, IDisposable
	{
		private readonly TipBox tipBox;

		private readonly GUI_NotificationCanvas notificationCanvas;

		private readonly CashMoneyObjectFactory cashMoneyObjectFactory;

		private readonly CashMoneyObjectRegistry cashMoneyObjectRegistry;

		private readonly InteractiveObjectRegistry interactiveObjectRegistry;

		private readonly IDService idService;

		private CashMoneyObject takenCashMoneyObject;

		[Inject]
		public TipBoxService(TipBox tipBox, GUI_NotificationCanvas notificationCanvas, CashMoneyObjectFactory cashMoneyObjectFactory, CashMoneyObjectRegistry cashMoneyObjectRegistry, InteractiveObjectRegistry interactiveObjectRegistry, IDService idService)
		{
			this.tipBox = tipBox;
			this.notificationCanvas = notificationCanvas;
			this.cashMoneyObjectFactory = cashMoneyObjectFactory;
			this.cashMoneyObjectRegistry = cashMoneyObjectRegistry;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.idService = idService;
		}

		public void Initialize()
		{
			tipBox.OnTipsAdded += ResolveTipsAdded;
		}

		public void Dispose()
		{
			tipBox.OnTipsAdded -= ResolveTipsAdded;
		}

		public bool TryStartTransfer(out CashMoneyObject cashMoneyObject)
		{
			if (!tipBox.TryTakeTips(out var moneyAmount))
			{
				cashMoneyObject = null;
				return false;
			}
			takenCashMoneyObject = cashMoneyObjectFactory.Create(moneyAmount);
			takenCashMoneyObject.transform.position = tipBox.transform.position;
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

		private void ResolveDragComplete()
		{
			UnsubscribeTakenObject();
			RegisterTakenObject();
		}

		private void ResolveDragCanceled()
		{
			UnsubscribeTakenObject();
			RevertMoneyAndDestroyTakenObject();
		}

		private void ResolveOnRemove()
		{
			UnsubscribeTakenObject();
			takenCashMoneyObject = null;
		}

		private void ResolveTipsAdded(int tipsAmount)
		{
			notificationCanvas.ShowTipsNotification(tipsAmount, tipBox.transform);
		}

		private void RegisterTakenObject()
		{
			if ((bool)takenCashMoneyObject)
			{
				takenCashMoneyObject.InteractiveObject.Init(InteractiveObjectState.Stored, idService.GenerateNew(), false);
				cashMoneyObjectRegistry.Register(takenCashMoneyObject);
				interactiveObjectRegistry.Register(takenCashMoneyObject.InteractiveObject, cashMoneyObjectFactory.CashMoneyItemInfo);
			}
			takenCashMoneyObject = null;
		}

		private void RevertMoneyAndDestroyTakenObject()
		{
			tipBox.ReturnTips(takenCashMoneyObject.MoneyAmountHeld);
			cashMoneyObjectFactory.Destroy(takenCashMoneyObject);
			takenCashMoneyObject = null;
		}
	}
}
