using UnityEngine;

public class FilledProgressBar : AsciiObject
{
	public string topSymbol = "_";

	public string bottomSymbol = "\u00af";

	public string leftSymbol = "|";

	public string rightSymbol = "|";

	public Color borderColor = ColorConstants.darkGrey;

	public float lerpSpeed = 4f;

	public AsciiString label;

	public bool isRainbow;

	public Color barFillColor = Color.white;

	public Color targetFillColor = Color.white;

	public float percent = 0.5f;

	public float targetPercent { get; set; }

	public override void UpdateTic()
	{
	}

	protected void Update()
	{
		if (Mathf.Abs(percent - targetPercent) < 0.02f)
		{
			percent = targetPercent;
			barFillColor = targetFillColor;
		}
		else
		{
			float t = Mathf.Clamp01(Time.deltaTime * lerpSpeed);
			percent = Mathf.Lerp(percent, targetPercent, t);
			barFillColor = Color.Lerp(barFillColor, targetFillColor, t);
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		offsetX += PositionX;
		offsetY += PositionY;
		label.Draw(r, offsetX, offsetY);
		int num = Width - 2;
		if (leftSymbol.Length > 0)
		{
			r.SetCell(offsetX, offsetY + 1, SpecialSymbols.Map(leftSymbol[0]), borderColor);
		}
		if (rightSymbol.Length > 0)
		{
			r.SetCell(offsetX + Width - 1, offsetY + 1, SpecialSymbols.Map(rightSymbol[0]), borderColor);
		}
		int value = ((topSymbol.Length > 0) ? SpecialSymbols.Map(topSymbol[0]) : (-1));
		int value2 = ((bottomSymbol.Length > 0) ? SpecialSymbols.Map(bottomSymbol[0]) : (-1));
		for (int i = 0; i < num; i++)
		{
			r.SetCell(offsetX + 1 + i, offsetY, value, borderColor);
			r.SetCell(offsetX + 1 + i, offsetY + 2, value2, borderColor);
		}
		offsetX++;
		offsetY++;
		float num2 = Mathf.Clamp01(percent) * (float)num;
		int num3 = Mathf.FloorToInt(num2);
		float num4 = num2 - (float)num3;
		int j;
		for (j = 0; j < num3; j++)
		{
			Color c = (isRainbow ? AsciiString.GetRainbowColor(j, num) : barFillColor);
			SetCellFill(r, j + offsetX, offsetY, c);
		}
		if (j < num)
		{
			Color color = (isRainbow ? AsciiString.GetRainbowColor(j, num) : barFillColor);
			SetCellFill(r, j + offsetX, offsetY, color * num4);
		}
	}

	private void SetCellFill(AsciiRenderProcedural r, int x, int y, Color c)
	{
		if (x >= r.clip.left && x < r.width - r.clip.right)
		{
			AsciiCellProcedural cell = r.GetCell(x, y);
			if (cell != null)
			{
				cell.SetBackground(c);
				cell.SetForeground((c.grayscale < 0.5f) ? ColorConstants.white : ColorConstants.black);
			}
		}
	}
}
