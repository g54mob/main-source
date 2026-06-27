using Restory.Data.Tutorials;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;

namespace Restory.Gameplay.Tutorials.Handlers
{
	public class FirstElementDeviceTutorialHandler : TutorialHandlerBase
	{
		private readonly DragObjectRegistrator dragObjectRegistrator;

		private readonly InventoryBox inventoryBox;

		private InteractiveObject elementsContainerInteractiveObject;

		public FirstElementDeviceTutorialHandler(DragObjectRegistrator dragObjectRegistrator, InventoryBox inventoryBox, FirstElementDeviceTutorial tutorial)
			: base(tutorial)
		{
			this.dragObjectRegistrator = dragObjectRegistrator;
			this.inventoryBox = inventoryBox;
		}

		public override void Init()
		{
			dragObjectRegistrator.OnInteractiveObjectStartDrag += ResolveInteractiveObjectStartedDragging;
			dragObjectRegistrator.OnInteractiveObjectStopDrag += ResolveOnInteractiveObjectStopDrag;
		}

		public override void Cleanup()
		{
			if (dragObjectRegistrator != null)
			{
				dragObjectRegistrator.OnInteractiveObjectStartDrag -= ResolveInteractiveObjectStartedDragging;
				dragObjectRegistrator.OnInteractiveObjectStopDrag -= ResolveOnInteractiveObjectStopDrag;
			}
			if (elementsContainerInteractiveObject.MonoShellExists())
			{
				elementsContainerInteractiveObject.OnDragComplete -= ResolveInteractiveObjectSuccessfullyCompletedDragging;
			}
			inventoryBox.ToggleIndicator(isActive: false);
		}

		private void ResolveInteractiveObjectStartedDragging()
		{
			if (!base.IsCompleted && dragObjectRegistrator.DraggingObject.TryGetComponent<ElementsContainer>(out var component) && component.TryGetComponent<InteractiveObject>(out elementsContainerInteractiveObject))
			{
				elementsContainerInteractiveObject.OnDragComplete += ResolveInteractiveObjectSuccessfullyCompletedDragging;
				inventoryBox.ToggleIndicator(isActive: true);
			}
		}

		private void ResolveOnInteractiveObjectStopDrag()
		{
			if (!base.IsCompleted && elementsContainerInteractiveObject.MonoShellExists())
			{
				elementsContainerInteractiveObject.OnDragComplete -= ResolveInteractiveObjectSuccessfullyCompletedDragging;
				elementsContainerInteractiveObject = null;
				inventoryBox.ToggleIndicator(isActive: false);
			}
		}

		private void ResolveInteractiveObjectSuccessfullyCompletedDragging()
		{
			if (elementsContainerInteractiveObject.MonoShellExists())
			{
				elementsContainerInteractiveObject.OnDragComplete -= ResolveInteractiveObjectSuccessfullyCompletedDragging;
				elementsContainerInteractiveObject = null;
				inventoryBox.ToggleIndicator(isActive: false);
			}
			if (!base.IsCompleted)
			{
				CompleteTutorial();
			}
		}
	}
}
