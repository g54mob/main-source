using DV.UIFramework;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DV.UI.Inventory
{
	public class InventoryGridElement : AViewElement<InventorySlotDisplayData>
	{
		public Button lockButton;

		public Button getButton;

		public Button beltResetButton;

		public Button beltToggleButton;

		public Button itemContainerButton;

		public bool allowSelection;

		private ButtonDVMarkable markableButton;

		private InventorySlotVisualController visualController;

		public InventorySlotDisplayData Data { get; private set; }

		public bool ContainsData(InventorySlotDisplayData data)
		{
			return Data == data;
		}

		public override void SetData(InventorySlotDisplayData data, AGridView<InventorySlotDisplayData> _)
		{
			Data = data;
			if (visualController == null)
			{
				visualController = GetComponent<InventorySlotVisualController>();
			}
			visualController.UpdateVisuals(data);
		}

		public override void SetSelected(bool selected)
		{
			if (allowSelection)
			{
				base.SetSelected(selected);
			}
		}

		public override void OnSelect(BaseEventData eventData)
		{
		}

		public void HoverUpdate(InventorySlotDisplayData draggedData, bool hovered)
		{
			visualController.HoverUpdate(draggedData, hovered);
		}

		public void ItemContainerAccessHoverUpdate(InventorySlotDisplayData draggedData, bool hovered)
		{
			visualController.ItemContainerAccessHoverUpdate(draggedData, hovered);
		}

		public void DragUpdate(InventorySlotDisplayData draggedData, bool dragStart)
		{
			visualController.DragUpdate(draggedData, dragStart);
		}
	}
}
