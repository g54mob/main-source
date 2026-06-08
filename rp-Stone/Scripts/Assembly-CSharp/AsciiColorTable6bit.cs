using UnityEngine;

public class AsciiColorTable6bit
{
	public static void DrawColorTable(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		float num = 0.333333f;
		for (int i = 0; i <= 3; i++)
		{
			for (int j = 0; j <= 3; j++)
			{
				for (int k = 0; k <= 3; k++)
				{
					int x = i * 4 + j + 1 + offsetX;
					int y = k + offsetY;
					r.SetCell(x, y, 32, ColorConstants.black, new Color(num * (float)i, num * (float)j, num * (float)k));
				}
			}
		}
		r.SetCell(offsetX, offsetY, 32, ColorConstants.black, new Color(0f, 0f, 0f));
		r.SetCell(offsetX, offsetY + 1, 32, ColorConstants.black, new Color(num, num, num));
		r.SetCell(offsetX, offsetY + 2, 32, ColorConstants.black, new Color(2f * num, 2f * num, 2f * num));
		r.SetCell(offsetX, offsetY + 3, 32, ColorConstants.black, new Color(3f * num, 3f * num, 3f * num));
	}
}
