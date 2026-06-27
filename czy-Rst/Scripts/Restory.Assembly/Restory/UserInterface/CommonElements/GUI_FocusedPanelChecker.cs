using Restory.Data.GuiElementTypes;
using Restory.EventSystems;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_FocusedPanelChecker : IFocusedPanelChecker
	{
		public class Factory : PlaceholderFactory<GUI_FocusedPanelChecker>
		{
		}

		private ActiveSelectionService activeSelectionService;

		private ActiveGuiRegistry activeGuiRegistry;

		[Inject]
		private void Construct(ActiveSelectionService activeSelectionService, ActiveGuiRegistry activeGuiRegistry)
		{
			this.activeSelectionService = activeSelectionService;
			this.activeGuiRegistry = activeGuiRegistry;
		}

		public bool IsPanelFocused(Transform panel)
		{
			if (panel == null)
			{
				return false;
			}
			GameObject currentSelection = activeSelectionService.GetCurrentSelection();
			if (currentSelection == null)
			{
				return false;
			}
			if (!(currentSelection == panel.gameObject))
			{
				return currentSelection.transform.IsChildOf(panel);
			}
			return true;
		}

		public bool IsPanelFocused(GuiElementType elementType)
		{
			GameObject currentSelection = activeSelectionService.GetCurrentSelection();
			if (currentSelection == null)
			{
				return false;
			}
			if (!activeGuiRegistry.TryGetRoot(elementType, out var root))
			{
				return false;
			}
			if (currentSelection == root)
			{
				return true;
			}
			return currentSelection.transform.IsChildOf(root.transform);
		}
	}
}
