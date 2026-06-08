using System;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : UIControl
{
	private enum BlendMode
	{
		Opaque = 0,
		Multiply = 1,
		Divide = 2,
		Add = 3,
		Subtract = 4
	}

	private readonly int MAX_WIDTH = 100;

	private readonly int MAX_HEIGHT = 27;

	private readonly int DEFAULT_SYMBOL = 35;

	private readonly Color DEFAULT_FG = Color.white;

	private readonly Color DEFAULT_BG = Color.black;

	private List<int[]> symbolGrid = new List<int[]>();

	private List<Color[]> fgColorGrid = new List<Color[]>();

	private List<Color[]> bgColorGrid = new List<Color[]>();

	private BlendMode blendMode;

	public override void ResetControl()
	{
		base.ResetControl();
		for (int i = 0; i < symbolGrid.Count; i++)
		{
			for (int j = 0; j < symbolGrid[i].Length; j++)
			{
				symbolGrid[i][j] = DEFAULT_SYMBOL;
			}
		}
		for (int k = 0; k < fgColorGrid.Count; k++)
		{
			for (int l = 0; l < fgColorGrid[k].Length; l++)
			{
				fgColorGrid[k][l] = DEFAULT_FG;
			}
		}
		for (int m = 0; m < bgColorGrid.Count; m++)
		{
			for (int n = 0; n < bgColorGrid[m].Length; n++)
			{
				bgColorGrid[m][n] = DEFAULT_BG;
			}
		}
		while (symbolGrid.Count < MAX_WIDTH)
		{
			int[] array = new int[MAX_HEIGHT];
			for (int num = 0; num < MAX_HEIGHT; num++)
			{
				array[num] = DEFAULT_SYMBOL;
			}
			symbolGrid.Add(array);
		}
		blendMode = BlendMode.Opaque;
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX;
		offsetY += PositionY;
		for (int i = 0; i < symbolGrid.Count && i < Width; i++)
		{
			for (int j = 0; j < symbolGrid[i].Length && j < Height; j++)
			{
				int num = symbolGrid[i][j];
				if (num == 35 && blendMode == BlendMode.Opaque)
				{
					continue;
				}
				Color color = DEFAULT_FG;
				Color color2 = DEFAULT_BG;
				if (i < fgColorGrid.Count)
				{
					color = fgColorGrid[i][j];
				}
				if (i < bgColorGrid.Count)
				{
					color2 = bgColorGrid[i][j];
				}
				AsciiCellProcedural cell = r.GetCell(i + offsetX, j + offsetY);
				if (cell != null)
				{
					if (blendMode == BlendMode.Multiply)
					{
						cell.SetForeground(cell.GetForeground() * color);
						cell.SetBackground(cell.GetBackground() * color2);
					}
					else if (blendMode == BlendMode.Divide)
					{
						cell.SetForeground(DivideColors(cell.GetForeground(), color));
						cell.SetBackground(DivideColors(cell.GetBackground(), color2));
					}
					else if (blendMode == BlendMode.Add)
					{
						cell.SetForeground(cell.GetForeground() + color);
						cell.SetBackground(cell.GetBackground() + color2);
					}
					else if (blendMode == BlendMode.Subtract)
					{
						cell.SetForeground(cell.GetForeground() - color);
						cell.SetBackground(cell.GetBackground() - color2);
					}
					else
					{
						cell.SetForeground(color);
						cell.SetBackground(color2);
					}
					if (num != 35)
					{
						cell.SetValue(num);
					}
				}
			}
		}
	}

	private Color DivideColors(Color c1, Color c2)
	{
		return new Color(c1.r / c2.r, c1.g / c2.g, c1.b / c2.b);
	}

	public int GetSymbol(int x, int y)
	{
		if (x < symbolGrid.Count && y < symbolGrid[x].Length)
		{
			return symbolGrid[x][y];
		}
		return 35;
	}

	public void SetSymbol(int x, int y, int symbol)
	{
		symbolGrid[x][y] = symbol;
	}

	public void SetSymbol(int symbol)
	{
		for (int i = 0; i < symbolGrid.Count; i++)
		{
			for (int j = 0; j < symbolGrid[i].Length; j++)
			{
				symbolGrid[i][j] = symbol;
			}
		}
	}

	public void SetForegroundColor(int x, int y, Color c)
	{
		while (x >= fgColorGrid.Count)
		{
			Color[] array = new Color[MAX_HEIGHT];
			for (int i = 0; i < y; i++)
			{
				array[i] = DEFAULT_FG;
			}
			fgColorGrid.Add(array);
		}
		fgColorGrid[x][y] = c;
	}

	public void SetForegroundColor(Color c)
	{
		SetForegroundColor(MAX_WIDTH - 1, MAX_HEIGHT - 1, c);
		for (int i = 0; i < fgColorGrid.Count; i++)
		{
			for (int j = 0; j < fgColorGrid[i].Length; j++)
			{
				fgColorGrid[i][j] = c;
			}
		}
	}

	public void SetBackgroundColor(int x, int y, Color c)
	{
		while (x >= bgColorGrid.Count)
		{
			Color[] array = new Color[MAX_HEIGHT];
			for (int i = 0; i < y; i++)
			{
				array[i] = DEFAULT_BG;
			}
			bgColorGrid.Add(array);
		}
		bgColorGrid[x][y] = c;
	}

	public void SetBackgroundColor(Color c)
	{
		SetBackgroundColor(MAX_WIDTH - 1, MAX_HEIGHT - 1, c);
		for (int i = 0; i < bgColorGrid.Count; i++)
		{
			for (int j = 0; j < bgColorGrid[i].Length; j++)
			{
				bgColorGrid[i][j] = c;
			}
		}
	}

	[StonescriptNativeMethod("Get")]
	public object Method_Get(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 2 && parameters[0] is int && parameters[1] is int)
		{
			int x = (int)parameters[0];
			int y = (int)parameters[1];
			return SpecialSymbols.ReverseMap(GetSymbol(x, y)).ToString();
		}
		throw new StonescriptRuntimeException("Invalid parameters canvas.Set()");
	}

	[StonescriptNativeMethod("Set")]
	public object Method_Set(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is string)
		{
			string text = parameters[0] as string;
			if (text.Length > 0)
			{
				SetSymbol(SpecialSymbols.Map(text[0]));
				return null;
			}
		}
		if (parameters.Count == 3 && parameters[0] is int && parameters[1] is int && parameters[2] is string)
		{
			int num = (int)parameters[0];
			int num2 = (int)parameters[1];
			string text2 = parameters[2] as string;
			if (num >= 0 && num < MAX_WIDTH && num2 >= 0 && num2 < MAX_HEIGHT && text2.Length > 0)
			{
				SetSymbol(num, num2, SpecialSymbols.Map(text2[0]));
				return null;
			}
		}
		if (parameters.Count == 4 && parameters[0] is int && parameters[1] is int && parameters[2] is string && parameters[3] is string)
		{
			int num3 = (int)parameters[0];
			int num4 = (int)parameters[1];
			string colorStr = parameters[2] as string;
			string text3 = parameters[3] as string;
			if (num3 >= 0 && num3 < MAX_WIDTH && num4 >= 0 && num4 < MAX_HEIGHT && text3.Length > 0)
			{
				SetSymbol(num3, num4, SpecialSymbols.Map(text3[0]));
				SetForegroundColor(num3, num4, Utils.ConvertColor(colorStr));
				return null;
			}
		}
		if (parameters.Count == 5 && parameters[0] is int && parameters[1] is int && parameters[2] is string && parameters[3] is string && parameters[4] is string)
		{
			int num5 = (int)parameters[0];
			int num6 = (int)parameters[1];
			string colorStr2 = parameters[2] as string;
			string colorStr3 = parameters[3] as string;
			string text4 = parameters[4] as string;
			if (num5 >= 0 && num5 < MAX_WIDTH && num6 >= 0 && num6 < MAX_HEIGHT && text4.Length > 0)
			{
				SetSymbol(num5, num6, SpecialSymbols.Map(text4[0]));
				SetForegroundColor(num5, num6, Utils.ConvertColor(colorStr2));
				SetBackgroundColor(num5, num6, Utils.ConvertColor(colorStr3));
				return null;
			}
		}
		throw new StonescriptRuntimeException("Invalid parameters canvas.Set()");
	}

	[StonescriptNativeMethod("SetFG")]
	public object Method_SetFG(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is string)
		{
			Color foregroundColor = Utils.ConvertColor(parameters[0] as string);
			SetForegroundColor(foregroundColor);
			return null;
		}
		if (parameters.Count == 3 && parameters[0] is int && parameters[1] is int && parameters[2] is string)
		{
			int num = (int)parameters[0];
			int num2 = (int)parameters[1];
			if (num >= 0 && num < MAX_WIDTH && num2 >= 0 && num2 < MAX_HEIGHT)
			{
				Color c = Utils.ConvertColor(parameters[2] as string);
				SetForegroundColor(num, num2, c);
			}
			return null;
		}
		throw new StonescriptRuntimeException("Invalid parameters canvas.SetFG()");
	}

	[StonescriptNativeMethod("SetBG")]
	public object Method_SetBG(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 1 && parameters[0] is string)
		{
			Color backgroundColor = Utils.ConvertColor(parameters[0] as string);
			SetBackgroundColor(backgroundColor);
			return null;
		}
		if (parameters.Count == 3 && parameters[0] is int && parameters[1] is int && parameters[2] is string)
		{
			int num = (int)parameters[0];
			int num2 = (int)parameters[1];
			if (num >= 0 && num < MAX_WIDTH && num2 >= 0 && num2 < MAX_HEIGHT)
			{
				Color c = Utils.ConvertColor(parameters[2] as string);
				SetBackgroundColor(num, num2, c);
			}
			return null;
		}
		throw new StonescriptRuntimeException("Invalid parameters canvas.SetBG()");
	}

	[StonescriptNativeGetter("blend")]
	public object Property_GetBlend()
	{
		return blendMode.ToString();
	}

	[StonescriptNativeSetter("blend")]
	public void Property_SetBlend(object value)
	{
		string value2 = value as string;
		blendMode = (BlendMode)Enum.Parse(typeof(BlendMode), value2, ignoreCase: true);
	}
}
