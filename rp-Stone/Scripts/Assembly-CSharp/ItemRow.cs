using UnityEngine;

public class ItemRow : MultiSlotRow, INewIndicatorProvider
{
	private Color indicatorColor;

	public bool IsNewIndicating()
	{
		for (int i = 0; i < slots.Count; i++)
		{
			if (slots[i] is INewIndicatorProvider newIndicatorProvider && newIndicatorProvider.IsNewIndicating())
			{
				indicatorColor = newIndicatorProvider.GetNewIndicatorColor();
				return true;
			}
		}
		return false;
	}

	public Color GetNewIndicatorColor()
	{
		return indicatorColor;
	}

	public string GetNewIndicatorString()
	{
		return "";
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		for (int i = 0; i < slots.Count; i++)
		{
			ItemSlot itemSlot = slots[i] as ItemSlot;
			if ((bool)itemSlot && (bool)itemSlot.item && itemSlot.icon != null && (itemSlot.icon.width > itemSlot.Width - 2 || itemSlot.item.isLost))
			{
				int offsetX2 = itemSlot.icon.lastDrawX + itemSlot.icon.pivotX;
				int offsetY2 = itemSlot.icon.lastDrawY + itemSlot.icon.pivotY;
				if (itemSlot.item.isLost)
				{
					IconLoader.Singleton.lostItemLaurels.Draw(r, offsetX2, offsetY2);
				}
				itemSlot.icon.Draw(r, offsetX2, offsetY2);
				if (itemSlot.item.isLost)
				{
					itemSlot.DrawCountLabel(r, offsetX, offsetY);
				}
			}
		}
	}
}
