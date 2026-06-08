using UnityEngine;

public class FadeTransition : Transition
{
	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		float num = GetPercent();
		if (base.CurrentState == State.In)
		{
			num = 1f - num;
		}
		else if (base.CurrentState == State.Blank)
		{
			num = 1f;
		}
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				int value = cell.GetValue();
				Color foreground = cell.GetForeground();
				Color background = cell.GetBackground();
				foreground = Color.Lerp(foreground, r.defaultBackgroundColor, num);
				background = Color.Lerp(background, r.defaultBackgroundColor, num);
				cell.SetValue(value, foreground, background);
			}
		}
	}
}
