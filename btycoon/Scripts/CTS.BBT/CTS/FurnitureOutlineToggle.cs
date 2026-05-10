using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class FurnitureOutlineToggle : ToggleOutlineOnSelection
	{
		[Inject(false)]
		private Furniture _furniture;

		[SerializeField]
		private SelectionMode _modeAll;

		protected override void OnHoverEnter(SelectionMode selectionMode)
		{
			base.OnHoverEnter(selectionMode);
			if (selectionMode != _modeAll)
			{
				return;
			}
			FurnitureSlot[] slots = _furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot.SlotedFurniture)
				{
					furnitureSlot.SlotedFurniture.Furniture.OutlineRenderers.EnableOutline(EOutline.Hover);
				}
			}
		}

		protected override void OnHoverExit(SelectionMode selectionMode)
		{
			base.OnHoverExit(selectionMode);
			FurnitureSlot[] slots = _furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot.SlotedFurniture)
				{
					furnitureSlot.SlotedFurniture.Furniture.OutlineRenderers.DisableOutline(EOutline.Hover);
				}
			}
		}

		protected override void OnObjectSelected(SelectionMode selectionMode)
		{
			base.OnObjectSelected(selectionMode);
			if (selectionMode != _modeAll)
			{
				return;
			}
			FurnitureSlot[] slots = _furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot.SlotedFurniture)
				{
					furnitureSlot.SlotedFurniture.Furniture.OutlineRenderers.EnableOutline(EOutline.Select);
				}
			}
		}

		protected override void OnObjectDeselected(SelectionMode selectionMode)
		{
			base.OnObjectDeselected(selectionMode);
			FurnitureSlot[] slots = _furniture.Slots;
			foreach (FurnitureSlot furnitureSlot in slots)
			{
				if ((bool)furnitureSlot.SlotedFurniture)
				{
					furnitureSlot.SlotedFurniture.Furniture.OutlineRenderers.DisableOutline(EOutline.Select);
				}
			}
		}
	}
}
