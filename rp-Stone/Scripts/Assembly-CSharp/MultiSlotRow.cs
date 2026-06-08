using System;
using System.Collections.Generic;

public class MultiSlotRow : AsciiObject
{
	public int distanceBetweenSlots;

	[NonSerialized]
	public List<AsciiObject> slots = new List<AsciiObject>();

	public bool IsFull(int newSlotWidth)
	{
		int num = newSlotWidth;
		for (int i = 0; i < slots.Count; i++)
		{
			num += slots[i].Width + distanceBetweenSlots;
			if (num > Width)
			{
				return true;
			}
		}
		return false;
	}

	public void AddSlot(AsciiObject slot)
	{
		slots.Add(slot);
		int num = Width - 1;
		for (int i = 0; i < slots.Count; i++)
		{
			num -= slot.Width - 1;
		}
		int num2 = num >> 1;
		for (int j = 0; j < slots.Count; j++)
		{
			slots[j].PositionX = num2;
			num2 += slots[j].Width - 1;
		}
	}

	public override void UpdateTic()
	{
		if (base.enabled)
		{
			for (int i = 0; i < slots.Count; i++)
			{
				slots[i].UpdateTic();
			}
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < slots.Count; i++)
		{
			slots[i].Draw(r, offsetX, offsetY);
		}
	}
}
