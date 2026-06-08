using UnityEngine;

public class AsciiSpritePPDesaturate : AsciiSpritePPShader
{
	protected override void ApplyShading(AsciiCellProcedural cell, AsciiData.Page page, int[][] data, int i, int j, int x, int y)
	{
		Color foreground = cell.GetForeground();
		float num = foreground.r * 0.3f + foreground.g * 0.59f + foreground.b * 0.11f;
		Color foreground2 = new Color(num, num, num, foreground.a);
		cell.SetForeground(foreground2);
	}
}
