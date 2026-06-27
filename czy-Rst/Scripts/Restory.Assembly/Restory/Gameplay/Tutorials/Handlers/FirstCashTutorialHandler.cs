using Restory.Data.Tutorials;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.MoneyCash;
using Zenject;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class FirstCashTutorialHandler : TutorialHandlerBase
	{
		private readonly InteractiveObjectRegistry interactiveObjectRegistry;

		private readonly DragObjectRegistrator dragObjectRegistrator;

		private InteractiveObject trackedCashMoneyObject;

		[Inject]
		public FirstCashTutorialHandler(InteractiveObjectRegistry interactiveObjectRegistry, DragObjectRegistrator dragObjectRegistrator, FirstCashTutorial tutorial)
			: base(tutorial)
		{
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.dragObjectRegistrator = dragObjectRegistrator;
		}

		public override void Init()
		{
			interactiveObjectRegistry.OnInteractiveObjectRegistered += ResolveInteractiveObjectRegistered;
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveInteractiveObjectStopDrag;
			foreach (InteractiveObject key in interactiveObjectRegistry.All.Keys)
			{
				if (key.TryGetComponent<CashMoneyObject>(out var _))
				{
					trackedCashMoneyObject = key;
					trackedCashMoneyObject.ToggleIndicator(isActive: true);
					break;
				}
			}
		}

		public override void Cleanup()
		{
			interactiveObjectRegistry.OnInteractiveObjectRegistered -= ResolveInteractiveObjectRegistered;
			dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartDrag;
			dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveInteractiveObjectStopDrag;
			trackedCashMoneyObject = null;
		}

		private void ResolveInteractiveObjectRegistered(InteractiveObject interactiveObject)
		{
			if (!base.IsCompleted && interactiveObject.TryGetComponent<CashMoneyObject>(out var _))
			{
				if ((bool)trackedCashMoneyObject)
				{
					trackedCashMoneyObject.ToggleIndicator(isActive: false);
				}
				trackedCashMoneyObject = interactiveObject;
				trackedCashMoneyObject.ToggleIndicator(isActive: true);
			}
		}

		private void ResolveInteractiveObjectStartDrag()
		{
			if (!base.IsCompleted)
			{
				if ((bool)trackedCashMoneyObject)
				{
					trackedCashMoneyObject.ToggleIndicator(isActive: false);
				}
				if (!(dragObjectRegistrator.DraggingObject != trackedCashMoneyObject))
				{
					CompleteTutorial();
				}
			}
		}

		private void ResolveInteractiveObjectStopDrag()
		{
			if (!base.IsCompleted && (bool)trackedCashMoneyObject)
			{
				trackedCashMoneyObject.ToggleIndicator(isActive: true);
			}
		}
	}
}
