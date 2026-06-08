using System.Collections.Generic;
using UnityEngine;

public class TilingAsciiSprite : AsciiSprite
{
	public int scrollX;

	public int scrollY;

	public bool copyRendererWidth = true;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		Draw(r, offsetX, offsetY, 1f, ColorConstants.white);
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, float colorMultiply, Color tint)
	{
		if (copyRendererWidth)
		{
			width = r.width;
			offsetX = 0;
		}
		Color defaultForegroundColor = r.defaultForegroundColor;
		if (colorOverride != Color.white)
		{
			r.defaultForegroundColor = colorOverride;
		}
		else if (colorMode == ColorMode.Darker)
		{
			r.defaultForegroundColor = ColorConstants.darkGrey;
		}
		else if (colorMode == ColorMode.Dark)
		{
			r.defaultForegroundColor = ColorConstants.lightGrey;
		}
		DoDraw(r, offsetX, offsetY);
		r.defaultForegroundColor = defaultForegroundColor;
		FireOnDraw(r, offsetX, offsetY);
	}

	private void DoDraw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (data == null)
		{
			return;
		}
		Color defaultForegroundColor = r.defaultForegroundColor;
		int index = GetFrameIndex() % data.Pages.Count;
		int[][] array = data.Pages[index].Data;
		offsetX -= pivotX;
		offsetY -= pivotY;
		int num = r.width - 46 >> 1;
		int num2 = Mathf.Max(0, r.clip.left);
		int num3 = r.width - Mathf.Max(0, r.clip.right);
		int num4 = Mathf.Max(0, r.clip.top);
		int num5 = r.height - Mathf.Max(0, r.clip.bottom);
		int num6 = array.Length;
		int num7 = ((scrollX - num) % num6 + num6) % num6;
		for (int i = offsetX; i < width + offsetX; i++)
		{
			if (i >= num2 && i < num3)
			{
				List<AsciiCellProcedural> list = r.GetAllCells()[i];
				int num8 = array[num7].Length;
				int num9 = (scrollY % num8 + num8) % num8;
				for (int j = offsetY; j < height + offsetY; j++)
				{
					if (j >= num4 && j < num5 && array[num7][num9] != -1)
					{
						list[j].SetValue(array[num7][num9], defaultForegroundColor);
					}
					num9 = (num9 + 1) % num8;
				}
			}
			num7 = (num7 + 1) % num6;
		}
	}

	public override void Load()
	{
		int num = width;
		int num2 = height;
		base.Load();
		if (num > 0)
		{
			width = num;
		}
		if (num2 > 0)
		{
			height = num2;
		}
	}
}
