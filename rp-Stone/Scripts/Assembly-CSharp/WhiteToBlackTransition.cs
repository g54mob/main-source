using UnityEngine;

public class WhiteToBlackTransition : Transition
{
	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		float percent = GetPercent();
		if (base.CurrentState == State.Out)
		{
			Color color = Color.Lerp(Color.white, Color.black, percent);
			for (int i = 0; i < r.width; i++)
			{
				for (int j = 0; j < r.height; j++)
				{
					AsciiCellProcedural cell = r.GetCell(i, j);
					cell.SetForeground(color);
					cell.SetBackground(color);
				}
			}
			return;
		}
		percent = ((base.CurrentState != State.Blank) ? (1f - percent) : 1f);
		for (int k = 0; k < r.width; k++)
		{
			for (int l = 0; l < r.height; l++)
			{
				AsciiCellProcedural cell2 = r.GetCell(k, l);
				int value = cell2.GetValue();
				Color foreground = cell2.GetForeground();
				Color background = cell2.GetBackground();
				foreground = Color.Lerp(foreground, r.defaultBackgroundColor, percent);
				background = Color.Lerp(background, r.defaultBackgroundColor, percent);
				cell2.SetValue(value, foreground, background);
			}
		}
	}
}
