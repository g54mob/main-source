using System.Collections.Generic;
using Restory.Data.Tutorials;
using Restory.Gameplay.Equipment.CashRegisters;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Restory.Gameplay.RegularPayments;
using Restory.Gameplay.Tutorials.Settings;
using Restory.UI.Presenters.RegularPayment;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class FirstRegularPaymentTutorialHandler : TutorialHandlerBase
	{
		private readonly DiContainer diContainer;

		private readonly InteractiveObjectRegistry interactiveObjectRegistry;

		private readonly GUI_RegularPayment guiRegularPayment;

		private readonly CashRegister cashRegister;

		private readonly DragObjectRegistrator dragObjectRegistrator;

		private readonly Transform tutorialIconsCanvas;

		private readonly FirstRegularPaymentTutorialSettings settings;

		private readonly HashSet<RegularPaymentObject> trackedRegularPaymentObjects = new HashSet<RegularPaymentObject>();

		private GUI_MouseTooltip mouseTooltip;

		private bool isDraggingMoney;

		[Inject]
		public FirstRegularPaymentTutorialHandler(DiContainer diContainer, InteractiveObjectRegistry interactiveObjectRegistry, GUI_RegularPayment guiRegularPayment, CashRegister cashRegister, DragObjectRegistrator dragObjectRegistrator, [Inject(Id = "GameWorldTutorialIconsCanvas")] Transform tutorialIconsCanvas, FirstRegularPaymentTutorial tutorial)
			: base(tutorial)
		{
			this.diContainer = diContainer;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.guiRegularPayment = guiRegularPayment;
			this.cashRegister = cashRegister;
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.tutorialIconsCanvas = tutorialIconsCanvas;
			settings = tutorial.Settings;
		}

		public override void Init()
		{
			interactiveObjectRegistry.OnInteractiveObjectRegistered += ResolveInteractiveObjectRegistered;
			interactiveObjectRegistry.OnInteractiveObjectUnregistered += ResolveInteractiveObjectUnregistered;
			guiRegularPayment.OnIsVisibleChanged += ResolveRegularPaymentVisibilityChanged;
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveOnInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveOnInteractiveObjectEndDrag;
			foreach (InteractiveObject key in interactiveObjectRegistry.All.Keys)
			{
				if (key.TryGetComponent<RegularPaymentObject>(out var component))
				{
					AddTrackedObject(component);
				}
			}
		}

		public override void Cleanup()
		{
			interactiveObjectRegistry.OnInteractiveObjectRegistered -= ResolveInteractiveObjectRegistered;
			interactiveObjectRegistry.OnInteractiveObjectUnregistered -= ResolveInteractiveObjectUnregistered;
			guiRegularPayment.OnIsVisibleChanged -= ResolveRegularPaymentVisibilityChanged;
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveOnInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveOnInteractiveObjectEndDrag;
			foreach (RegularPaymentObject trackedRegularPaymentObject in trackedRegularPaymentObjects)
			{
				if ((bool)trackedRegularPaymentObject)
				{
					trackedRegularPaymentObject.InteractiveObject.ToggleIndicator(isActive: false);
				}
			}
			trackedRegularPaymentObjects.Clear();
			if ((bool)cashRegister)
			{
				cashRegister.ToggleIndicator(isActive: false);
			}
			if ((bool)guiRegularPayment)
			{
				guiRegularPayment.ToggleIndicator(isActive: false);
			}
		}

		private void AddTrackedObject(RegularPaymentObject regularPaymentObject)
		{
			if (trackedRegularPaymentObjects.Add(regularPaymentObject))
			{
				regularPaymentObject.InteractiveObject.ToggleIndicator(!guiRegularPayment.IsVisible);
			}
		}

		private void ResolveInteractiveObjectRegistered(InteractiveObject interactiveObject)
		{
			if (!base.IsCompleted && interactiveObject.TryGetComponent<RegularPaymentObject>(out var component))
			{
				AddTrackedObject(component);
			}
		}

		private void ResolveInteractiveObjectUnregistered(InteractiveObject interactiveObject)
		{
			if (!base.IsCompleted && interactiveObject.TryGetComponent<RegularPaymentObject>(out var _))
			{
				CompleteTutorial();
			}
		}

		private void ResolveOnInteractiveObjectStartDrag()
		{
			if (dragObjectRegistrator.DraggingObject.TryGetComponent<CashMoneyObject>(out var _))
			{
				isDraggingMoney = true;
				UpdateToggleIndicators();
			}
		}

		private void ResolveOnInteractiveObjectEndDrag()
		{
			isDraggingMoney = false;
			UpdateToggleIndicators();
		}

		private void ResolveRegularPaymentVisibilityChanged()
		{
			if (!base.IsCompleted)
			{
				UpdateToggleIndicators();
			}
		}

		private void UpdateToggleIndicators()
		{
			foreach (RegularPaymentObject trackedRegularPaymentObject in trackedRegularPaymentObjects)
			{
				trackedRegularPaymentObject.InteractiveObject.ToggleIndicator(!guiRegularPayment.IsVisible);
			}
			guiRegularPayment.ToggleIndicator(isDraggingMoney);
			if (guiRegularPayment.IsVisible && !isDraggingMoney)
			{
				cashRegister.ToggleIndicator(isActive: true);
				cashRegister.SetCashDrawerState(CashDrawerState.PartiallyOpen, animate: true);
				mouseTooltip = CreateMouseTooltip(cashRegister.transform);
				mouseTooltip.PlayDragAnimation();
			}
			else
			{
				cashRegister.ToggleIndicator(isActive: false);
				cashRegister.SetCashDrawerState(CashDrawerState.Closed, animate: true);
				DestroyMouseTooltip();
			}
		}

		private GUI_MouseTooltip CreateMouseTooltip(Transform target)
		{
			DestroyMouseTooltip();
			GUI_MouseTooltip gUI_MouseTooltip = diContainer.InstantiatePrefabForComponent<GUI_MouseTooltip>(settings.MouseTooltipPrefab.gameObject, tutorialIconsCanvas);
			gUI_MouseTooltip.Init(target);
			return gUI_MouseTooltip;
		}

		private void DestroyMouseTooltip()
		{
			if ((bool)mouseTooltip)
			{
				Object.Destroy(mouseTooltip.gameObject);
			}
		}
	}
}
