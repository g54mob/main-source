using System.Collections.Generic;
using UnityEngine;

public class BoxDrawing
{
	public struct Command
	{
		public int x;

		public int y;

		public int w;

		public int h;

		public int style;

		public Color color;

		public Command(int x, int y, int w, int h, Color c, int style)
		{
			this.x = x;
			this.y = y;
			this.w = w;
			this.h = h;
			color = c;
			this.style = style;
		}
	}

	private static char[] boxStyleBlank = new char[14]
	{
		' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',
		' ', ' ', ' ', ' '
	};

	private static char[] boxStyleLine = new char[14]
	{
		'┌', '─', '┐', '│', ' ', '│', '└', '─', '┘', '┼',
		'├', '┤', '┬', '┴'
	};

	private static char[] boxStyleOrganic = new char[14]
	{
		'.', '─', '.', '│', ' ', '│', '\'', '─', '\'', '+',
		':', ':', '.', '\''
	};

	private static char[] boxStyleDouble = new char[14]
	{
		'╔', '═', '╗', '║', ' ', '║', '╚', '═', '╝', '╬',
		'╠', '╣', '╦', '╩'
	};

	private static char[] boxStyleShadowCenter = new char[14]
	{
		'┌', '─', '┐', '│', ' ', '│', '╘', '═', '╛', '╪',
		'╞', '╡', '╤', '╧'
	};

	private static char[] boxStyleShadowLeft = new char[14]
	{
		'╓', '─', '┐', '║', ' ', '│', '╚', '═', '╛', '╫',
		'╟', '╢', '╥', '╨'
	};

	private static char[] boxStyleShadowRight = new char[14]
	{
		'┌', '─', '╖', '│', ' ', '║', '╘', '═', '╝', '╫',
		'╟', '╢', '╥', '╨'
	};

	private static char[] boxStyleFull1 = new char[14]
	{
		'▄', '▄', '▄', '█', ' ', '█', '▀', '▀', '▀', '█',
		'█', '█', '▄', '▀'
	};

	private static char[] boxStyleFull2 = new char[14]
	{
		'█', '▀', '█', '█', ' ', '█', '█', '▄', '█', '█',
		'█', '█', '▄', '▀'
	};

	private static List<char[]> allBoxStyles = null;

	private static void InitStyles()
	{
		if (allBoxStyles == null)
		{
			allBoxStyles = new List<char[]>();
			allBoxStyles.Add(boxStyleBlank);
			allBoxStyles.Add(boxStyleLine);
			allBoxStyles.Add(boxStyleOrganic);
			allBoxStyles.Add(boxStyleDouble);
			allBoxStyles.Add(boxStyleShadowCenter);
			allBoxStyles.Add(boxStyleShadowLeft);
			allBoxStyles.Add(boxStyleShadowRight);
			allBoxStyles.Add(boxStyleFull1);
			allBoxStyles.Add(boxStyleFull2);
		}
	}

	public static int AddStyle(char[] newBoxStyle)
	{
		InitStyles();
		allBoxStyles.Add(newBoxStyle);
		return allBoxStyles.Count - 1;
	}

	public static void Draw(AsciiRenderProcedural r, Command command)
	{
		InitStyles();
		int num = command.style;
		bool flag = false;
		if (num < 0)
		{
			flag = true;
			num = -num;
		}
		int index = num % allBoxStyles.Count;
		char[] array = allBoxStyles[index];
		if (array.Length == 0)
		{
			return;
		}
		int num2 = command.x;
		int num3 = command.y;
		int num4 = command.w;
		int num5 = command.h;
		if (num4 >= -1 && num4 <= 1 && num5 >= -1 && num5 <= 1)
		{
			int num6 = ((num4 > 0) ? ((num5 <= 0) ? ((num5 >= 0) ? 10 : 6) : 0) : ((num4 < 0) ? ((num5 > 0) ? 2 : ((num5 >= 0) ? 11 : 8)) : ((num5 > 0) ? 12 : ((num5 >= 0) ? 9 : 13))));
			if (num6 >= array.Length)
			{
				num6 = array[^1];
			}
			AsciiCellProcedural cell = r.GetCell(num2, num3);
			char c = array[num6];
			if (cell != null && c != '#')
			{
				cell.SetForeground(command.color);
				int num7 = SpecialSymbols.Map(c);
				if (num7 > 0)
				{
					cell.SetValue(num7);
					cell.SetUnicodeValue('\0');
				}
				else
				{
					cell.SetValue(32);
					cell.SetUnicodeValue(c);
				}
			}
			return;
		}
		if (num4 < 0)
		{
			num2 += num4 + 1;
			num4 = -num4;
		}
		if (num5 < 0)
		{
			num3 += num5 + 1;
			num5 = -num5;
		}
		for (int i = 0; i < num4 || (num4 == 0 && i == 0); i++)
		{
			int x = num2 + i;
			for (int j = 0; j < num5 || (num5 == 0 && j == 0); j++)
			{
				if (flag && i > 0 && j > 0 && i < num4 - 1)
				{
					j = num5 - 1;
				}
				int y = num3 + j;
				if (r.IsClipped(x, y))
				{
					continue;
				}
				AsciiCellProcedural cell2 = r.GetCell(x, y);
				if (cell2 == null)
				{
					continue;
				}
				int num6 = 4;
				if (num5 <= 1)
				{
					num6 = 1;
				}
				else if (num4 <= 1)
				{
					num6 = 3;
				}
				else if (j == 0)
				{
					num6 = ((i != 0) ? ((i != num4 - 1) ? 1 : 2) : 0);
				}
				else if (j == num5 - 1)
				{
					num6 = ((i == 0) ? 6 : ((i != num4 - 1) ? 7 : 8));
				}
				else if (i == 0)
				{
					num6 = 3;
				}
				else if (i == num4 - 1)
				{
					num6 = 5;
				}
				if (num6 >= array.Length)
				{
					num6 = array.Length - 1;
				}
				char c2 = array[num6];
				if (c2 != '#')
				{
					cell2.SetForeground(command.color);
					int num8 = SpecialSymbols.Map(c2);
					if (num8 > 0)
					{
						cell2.SetValue(num8);
						cell2.SetUnicodeValue('\0');
					}
					else
					{
						cell2.SetValue(32);
						cell2.SetUnicodeValue(c2);
					}
				}
			}
		}
	}
}
