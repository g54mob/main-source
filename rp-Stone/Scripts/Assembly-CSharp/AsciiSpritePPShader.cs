using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public abstract class AsciiSpritePPShader : MonoBehaviour
{
	protected AsciiSprite mySprite;

	protected virtual void HandleDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!base.enabled)
		{
			return;
		}
		AsciiData.Page currentPage = sprite.GetCurrentPage();
		int[][] dataWithFlips = currentPage.GetDataWithFlips();
		if (!currentPage.flipX && !currentPage.flipY)
		{
			for (int i = 0; i < dataWithFlips.Length; i++)
			{
				for (int j = 0; j < dataWithFlips[i].Length; j++)
				{
					ApplyShading(r, currentPage, dataWithFlips, i, j, i + offsetX, j + offsetY);
				}
			}
		}
		else if (currentPage.flipY && currentPage.flipX)
		{
			for (int num = dataWithFlips.Length - 1; num >= 0; num--)
			{
				for (int num2 = dataWithFlips[num].Length - 1; num2 >= 0; num2--)
				{
					ApplyShading(r, currentPage, dataWithFlips, num, num2, offsetX - num, offsetY - num2);
				}
			}
		}
		else if (currentPage.flipX)
		{
			for (int num3 = dataWithFlips.Length - 1; num3 >= 0; num3--)
			{
				for (int k = 0; k < dataWithFlips[num3].Length; k++)
				{
					ApplyShading(r, currentPage, dataWithFlips, num3, k, offsetX - num3, k + offsetY);
				}
			}
		}
		else
		{
			if (!currentPage.flipY)
			{
				return;
			}
			for (int l = 0; l < dataWithFlips.Length; l++)
			{
				for (int num4 = dataWithFlips[l].Length - 1; num4 >= 0; num4--)
				{
					ApplyShading(r, currentPage, dataWithFlips, l, num4, l + offsetX, offsetY - num4);
				}
			}
		}
	}

	protected virtual void ApplyShading(AsciiRenderProcedural r, AsciiData.Page page, int[][] data, int i, int j, int x, int y)
	{
		if (data[i][j] != -1 && !r.IsClipped(x, y))
		{
			AsciiCellProcedural cell = r.GetCell(x, y);
			if (cell != null)
			{
				ApplyShading(cell, page, data, i, j, x, y);
			}
		}
	}

	protected abstract void ApplyShading(AsciiCellProcedural cell, AsciiData.Page page, int[][] data, int i, int j, int x, int y);

	public void ToggleEventConnection()
	{
		if (mySprite != null)
		{
			mySprite.OnDraw -= HandleDraw;
			mySprite.OnDraw += HandleDraw;
		}
	}

	protected virtual void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
		mySprite.OnDraw += HandleDraw;
	}

	protected virtual void OnDestroy()
	{
		if (mySprite != null)
		{
			mySprite.OnDraw -= HandleDraw;
		}
	}
}
