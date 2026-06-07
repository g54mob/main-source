using DV.UI.Inventory;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI
{
	public class InventoryCanvasHelper : MonoBehaviour
	{
		[NullCheck]
		public AInventoryUIController inventoryController;

		private void Start()
		{
			inventoryController.closeButton.Clicked += OnClosePressed;
			inventoryController.PauseMenuRequested += RequestPauseMenu;
			inventoryController.Toggle(on: true);
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += OnElementToggled;
			}
			else
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= OnElementToggled;
			}
		}

		private void OnElementToggled(ACanvasController<CanvasController.ElementType>.Element element)
		{
			if (element.Type == CanvasController.ElementType.Inventory)
			{
				inventoryController.Toggle(SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.IsOn(element.Type));
			}
		}

		private void OnClosePressed(IClickable _)
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.Inventory, on: false);
		}

		private void RequestPauseMenu()
		{
			SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.TrySetState(CanvasController.ElementType.PauseMenu, on: true);
		}
	}
}
