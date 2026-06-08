using System;
using UnityEngine;

[Serializable]
public class ScrollBar
{
	public int PositionX;

	public int PositionY;

	public int Height;

	public int handleSymbol = 219;

	public int bgSymbol = 255;

	public float percent;

	public Color bgColor = Color.white;

	public Color handleColor = Color.white;

	public bool indicateMoreInfoWithArrow;

	public int moreInfoArrowX = -1;

	private int lastX;

	private int lastY;

	private int lastHandleY;

	public bool showNewIndicatorTop { get; set; }

	public bool showNewIndicatorBottom { get; set; }

	public Color newIndicatorColorTop { get; set; }

	public Color newIndicatorColorBottom { get; set; }

	public bool isDraggingHandle { get; private set; }

	public ScrollContainer.ScrollDirection scrollDirection { get; set; }

	public event Action<ScrollBar> OnPercentChanged;

	public void UpdateTic()
	{
		if (AsciiMouse.singleton.down0 && AsciiMouse.singleton.x == lastX && AsciiMouse.singleton.y == lastHandleY)
		{
			isDraggingHandle = true;
		}
		else if (AsciiMouse.singleton.isDown0)
		{
			int y = AsciiMouse.singleton.y;
			if (y < lastY || y >= lastY + Height || (!isDraggingHandle && AsciiMouse.singleton.x != lastX))
			{
				return;
			}
			float num = y - lastY;
			AsciiCellProcedural cell = GameStates.Singleton.asciiRenderer.GetCell(lastX, y);
			if (cell == null || cell.GetInteractionLayer() != null)
			{
				return;
			}
			float num2 = num / Mathf.Max(1f, Height - 1);
			if (percent != num2)
			{
				percent = num2;
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
		lastX = offsetX;
		lastY = offsetY;
		int num = Mathf.RoundToInt(Mathf.Clamp01(percent) * (float)(Height - 1));
		lastHandleY = num + lastY;
		for (int i = 0; i < Height; i++)
		{
			r.GetCell(offsetX, i + offsetY)?.ClearInteractionLayer();
			if (i == num)
			{
				r.SetCell(offsetX, i + offsetY, 32, ColorConstants.black, handleColor);
			}
			else
			{
				r.SetCell(offsetX, i + offsetY, bgSymbol, bgColor);
			}
		}
		if (showNewIndicatorTop)
		{
			r.SetCell(offsetX, offsetY, SpecialSymbols.Map('▲'), newIndicatorColorTop);
		}
		if (showNewIndicatorBottom)
		{
			r.SetCell(offsetX, offsetY + Height - 1, SpecialSymbols.Map('▼'), newIndicatorColorBottom);
		}
		else if (indicateMoreInfoWithArrow && percent < 0.2f)
		{
			int num2 = offsetY + Height;
			if (Mathf.Repeat(Time.realtimeSinceStartup, 1.5f) < 0.75f)
			{
				num2--;
			}
			r.SetCell(offsetX + moreInfoArrowX, num2, SpecialSymbols.Map('▼'), handleColor);
		}
	}
}
