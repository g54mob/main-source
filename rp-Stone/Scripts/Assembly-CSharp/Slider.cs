using System;
using UnityEngine;

public class Slider : MonoBehaviour
{
	public int PositionX;

	public int PositionY;

	public int Width = 10;

	public Color bgColor = Color.white;

	public AsciiSprite handleSprite;

	public int handleWidth = 2;

	[Range(0f, 1f)]
	public float percent;

	private int lastDrawX;

	private int lastDrawY;

	public bool isDraggingHandle { get; private set; }

	public event Action<Slider> OnPercentChanged;

	public void UpdateTic()
	{
		if (Width <= handleWidth || Width <= 1)
		{
			return;
		}
		int x = AsciiMouse.singleton.x;
		int y = AsciiMouse.singleton.y;
		if (AsciiMouse.singleton.down0 && x >= lastDrawX && x < lastDrawX + Width && y >= lastDrawY && y < lastDrawY + 2)
		{
			isDraggingHandle = true;
		}
		if (AsciiMouse.singleton.isDown0)
		{
			if (!isDraggingHandle)
			{
				return;
			}
			float num = Mathf.Clamp01((float)(x - lastDrawX - handleWidth / 2 + 1) / (float)(Width - handleWidth));
			if (percent != num)
			{
				percent = num;
				if (this.OnPercentChanged != null)
				{
					this.OnPercentChanged(this);
				}
			}
		}
		else
		{
			isDraggingHandle = false;
		}
	}

	public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		lastDrawX = offsetX;
		lastDrawY = offsetY;
		int value = SpecialSymbols.Map('‾');
		for (int i = 0; i < Width; i++)
		{
			AsciiCellProcedural cell = r.GetCell(i + offsetX, offsetY);
			if (cell != null)
			{
				cell.ClearInteractionLayer();
				r.SetCell(offsetX + i, offsetY + 1, value, bgColor);
			}
		}
		if (handleSprite != null)
		{
			int num = Mathf.Max(0, Width - handleWidth);
			int num2 = Mathf.RoundToInt(percent * (float)num) + handleWidth / 2 - 1;
			handleSprite.Draw(r, num2 + offsetX, offsetY);
		}
	}
}
