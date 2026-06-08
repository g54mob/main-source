using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public class AsciiData
{
	[Serializable]
	public class StringReplacement
	{
		public string find;

		public string replaceWith;

		public string Process(string str)
		{
			if (!string.IsNullOrEmpty(find) && !string.IsNullOrEmpty(replaceWith) && str.Contains(find))
			{
				return str.Replace(find, replaceWith);
			}
			return str;
		}
	}

	public class PageMeta
	{
		public int repeat;

		public void Parse(string sjson)
		{
			repeat = SlimJson.ParseInt(sjson, "repeat", 1);
		}
	}

	public class Page
	{
		public int width;

		public int height;

		public bool flipX;

		public bool flipY;

		private int[][] data;

		private int[][] dataFlipX;

		private int[][] dataFlipY;

		private int[][] dataFlip180;

		private static List<string> workRows = new List<string>();

		public int[][] Data => data;

		public int[][] DataFlipX => dataFlipX;

		public int[][] DataFlipY => dataFlipY;

		public int[][] DataFlip180 => dataFlip180;

		public int[][] GetDataWithFlips()
		{
			if (flipY && flipX)
			{
				return dataFlip180;
			}
			if (flipX)
			{
				return dataFlipX;
			}
			if (flipY)
			{
				return dataFlipY;
			}
			return data;
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			Draw(r, offsetX, offsetY, r.defaultForegroundColor);
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground)
		{
			InitFlipData();
			if (!flipX && !flipY)
			{
				for (int i = 0; i < data.Length; i++)
				{
					for (int j = 0; j < data[i].Length; j++)
					{
						int num = data[i][j];
						if (num != -1)
						{
							if (num <= 255)
							{
								r.SetCell(offsetX + i, offsetY + j, num, overrideForeground);
							}
							else
							{
								r.SetCell(offsetX + i, offsetY + j, (char)num, overrideForeground);
							}
						}
					}
				}
			}
			else if (flipY && flipX)
			{
				for (int num2 = dataFlip180.Length - 1; num2 >= 0; num2--)
				{
					for (int num3 = dataFlip180[num2].Length - 1; num3 >= 0; num3--)
					{
						int num4 = dataFlip180[num2][num3];
						if (num4 != -1)
						{
							if (num4 <= 255)
							{
								r.SetCell(offsetX - num2, offsetY - num3, num4, overrideForeground);
							}
							else
							{
								r.SetCell(offsetX - num2, offsetY - num3, (char)num4, overrideForeground);
							}
						}
					}
				}
			}
			else if (flipX)
			{
				for (int num5 = dataFlipX.Length - 1; num5 >= 0; num5--)
				{
					for (int k = 0; k < dataFlipX[num5].Length; k++)
					{
						int num6 = dataFlipX[num5][k];
						if (num6 != -1)
						{
							if (num6 <= 255)
							{
								r.SetCell(offsetX - num5, offsetY + k, num6, overrideForeground);
							}
							else
							{
								r.SetCell(offsetX - num5, offsetY + k, (char)num6, overrideForeground);
							}
						}
					}
				}
			}
			else
			{
				if (!flipY)
				{
					return;
				}
				for (int l = 0; l < dataFlipY.Length; l++)
				{
					for (int num7 = dataFlipY[l].Length - 1; num7 >= 0; num7--)
					{
						int num8 = dataFlipY[l][num7];
						if (num8 != -1)
						{
							if (num8 <= 255)
							{
								r.SetCell(offsetX + l, offsetY - num7, num8, overrideForeground);
							}
							else
							{
								r.SetCell(offsetX + l, offsetY - num7, (char)num8, overrideForeground);
							}
						}
					}
				}
			}
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Color overrideForeground, Color overrideBackground)
		{
			InitFlipData();
			if (!flipX && !flipY)
			{
				for (int i = 0; i < data.Length; i++)
				{
					for (int j = 0; j < data[i].Length; j++)
					{
						int num = data[i][j];
						if (num != -1)
						{
							if (num <= 255)
							{
								r.SetCell(offsetX + i, offsetY + j, num, overrideForeground, overrideBackground);
							}
							else
							{
								r.SetCell(offsetX + i, offsetY + j, (char)num, overrideForeground, overrideBackground);
							}
						}
					}
				}
			}
			else if (flipY && flipX)
			{
				for (int num2 = dataFlip180.Length - 1; num2 >= 0; num2--)
				{
					for (int num3 = dataFlip180[num2].Length - 1; num3 >= 0; num3--)
					{
						int num4 = dataFlip180[num2][num3];
						if (num4 != -1)
						{
							if (num4 <= 255)
							{
								r.SetCell(offsetX - num2, offsetY - num3, num4, overrideForeground, overrideBackground);
							}
							else
							{
								r.SetCell(offsetX - num2, offsetY - num3, (char)num4, overrideForeground, overrideBackground);
							}
						}
					}
				}
			}
			else if (flipX)
			{
				for (int num5 = dataFlipX.Length; num5 >= 0; num5--)
				{
					for (int k = 0; k < dataFlipX[num5].Length; k++)
					{
						int num6 = dataFlipX[num5][k];
						if (num6 != -1)
						{
							if (num6 <= 255)
							{
								r.SetCell(offsetX - num5, offsetY + k, num6, overrideForeground, overrideBackground);
							}
							else
							{
								r.SetCell(offsetX - num5, offsetY + k, (char)num6, overrideForeground, overrideBackground);
							}
						}
					}
				}
			}
			else
			{
				if (!flipY)
				{
					return;
				}
				for (int l = 0; l < dataFlipY.Length; l++)
				{
					for (int num7 = dataFlipY[l].Length - 1; num7 >= 0; num7--)
					{
						int num8 = dataFlipY[l][num7];
						if (num8 != -1)
						{
							if (num8 <= 255)
							{
								r.SetCell(offsetX + l, offsetY - num7, num8, overrideForeground, overrideBackground);
							}
							else
							{
								r.SetCell(offsetX + l, offsetY - num7, (char)num8, overrideForeground, overrideBackground);
							}
						}
					}
				}
			}
		}

		private void InitFlipData()
		{
			if (flipY && flipX && dataFlip180 == null)
			{
				dataFlip180 = new int[data.Length][];
				for (int i = 0; i < data.Length; i++)
				{
					int[] array = data[i];
					dataFlip180[i] = new int[array.Length];
					for (int j = 0; j < array.Length; j++)
					{
						int num = array[j];
						switch (num)
						{
						case 96:
							num = 46;
							break;
						case 46:
							num = 39;
							break;
						case 39:
							num = 46;
							break;
						case 44:
							num = 127;
							break;
						case 127:
							num = 44;
							break;
						case 95:
							num = 28;
							break;
						case 28:
							num = 95;
							break;
						case 16:
							num = 17;
							break;
						case 17:
							num = 16;
							break;
						case 30:
							num = 31;
							break;
						case 31:
							num = 30;
							break;
						case 40:
							num = 41;
							break;
						case 41:
							num = 40;
							break;
						case 91:
							num = 93;
							break;
						case 93:
							num = 91;
							break;
						case 123:
							num = 125;
							break;
						case 125:
							num = 123;
							break;
						case 60:
							num = 62;
							break;
						case 62:
							num = 60;
							break;
						case 112:
							num = 100;
							break;
						case 100:
							num = 112;
							break;
						case 113:
							num = 98;
							break;
						case 98:
							num = 113;
							break;
						case 51:
							num = 238;
							break;
						case 238:
							num = 51;
							break;
						case 218:
							num = 217;
							break;
						case 217:
							num = 218;
							break;
						case 192:
							num = 191;
							break;
						case 191:
							num = 192;
							break;
						case 195:
							num = 180;
							break;
						case 180:
							num = 195;
							break;
						case 193:
							num = 194;
							break;
						case 194:
							num = 193;
							break;
						case 213:
							num = 190;
							break;
						case 190:
							num = 213;
							break;
						case 212:
							num = 184;
							break;
						case 184:
							num = 212;
							break;
						case 198:
							num = 181;
							break;
						case 181:
							num = 198;
							break;
						case 207:
							num = 209;
							break;
						case 209:
							num = 207;
							break;
						case 214:
							num = 189;
							break;
						case 189:
							num = 214;
							break;
						case 211:
							num = 183;
							break;
						case 183:
							num = 211;
							break;
						case 199:
							num = 182;
							break;
						case 182:
							num = 199;
							break;
						case 208:
							num = 210;
							break;
						case 210:
							num = 208;
							break;
						case 201:
							num = 188;
							break;
						case 188:
							num = 201;
							break;
						case 200:
							num = 187;
							break;
						case 187:
							num = 200;
							break;
						case 204:
							num = 185;
							break;
						case 185:
							num = 204;
							break;
						case 202:
							num = 203;
							break;
						case 203:
							num = 202;
							break;
						case 220:
							num = 221;
							break;
						case 221:
							num = 220;
							break;
						}
						dataFlip180[i][j] = num;
					}
				}
			}
			else if (flipX && dataFlipX == null)
			{
				dataFlipX = new int[data.Length][];
				for (int k = 0; k < data.Length; k++)
				{
					int[] array2 = data[k];
					dataFlipX[k] = new int[array2.Length];
					for (int l = 0; l < array2.Length; l++)
					{
						int num2 = array2[l];
						switch (num2)
						{
						case 92:
							num2 = 47;
							break;
						case 47:
							num2 = 92;
							break;
						case 96:
							num2 = 127;
							break;
						case 127:
							num2 = 96;
							break;
						case 16:
							num2 = 17;
							break;
						case 17:
							num2 = 16;
							break;
						case 40:
							num2 = 41;
							break;
						case 41:
							num2 = 40;
							break;
						case 91:
							num2 = 93;
							break;
						case 93:
							num2 = 91;
							break;
						case 123:
							num2 = 125;
							break;
						case 125:
							num2 = 123;
							break;
						case 60:
							num2 = 62;
							break;
						case 62:
							num2 = 60;
							break;
						case 112:
							num2 = 113;
							break;
						case 113:
							num2 = 112;
							break;
						case 98:
							num2 = 100;
							break;
						case 100:
							num2 = 98;
							break;
						case 51:
							num2 = 238;
							break;
						case 238:
							num2 = 51;
							break;
						case 218:
							num2 = 191;
							break;
						case 217:
							num2 = 192;
							break;
						case 192:
							num2 = 217;
							break;
						case 191:
							num2 = 218;
							break;
						case 195:
							num2 = 180;
							break;
						case 180:
							num2 = 195;
							break;
						case 213:
							num2 = 184;
							break;
						case 190:
							num2 = 212;
							break;
						case 212:
							num2 = 190;
							break;
						case 184:
							num2 = 213;
							break;
						case 198:
							num2 = 181;
							break;
						case 181:
							num2 = 198;
							break;
						case 214:
							num2 = 183;
							break;
						case 189:
							num2 = 211;
							break;
						case 211:
							num2 = 189;
							break;
						case 183:
							num2 = 214;
							break;
						case 199:
							num2 = 182;
							break;
						case 182:
							num2 = 199;
							break;
						case 201:
							num2 = 187;
							break;
						case 188:
							num2 = 200;
							break;
						case 200:
							num2 = 188;
							break;
						case 187:
							num2 = 201;
							break;
						case 204:
							num2 = 185;
							break;
						case 185:
							num2 = 204;
							break;
						case 242:
							num2 = 243;
							break;
						case 243:
							num2 = 242;
							break;
						case 245:
							num2 = 244;
							break;
						case 244:
							num2 = 245;
							break;
						}
						dataFlipX[k][l] = num2;
					}
				}
			}
			else
			{
				if (!flipY || dataFlipY != null)
				{
					return;
				}
				dataFlipY = new int[data.Length][];
				for (int m = 0; m < data.Length; m++)
				{
					int[] array3 = data[m];
					dataFlipY[m] = new int[array3.Length];
					for (int n = 0; n < array3.Length; n++)
					{
						int num3 = array3[n];
						switch (num3)
						{
						case 92:
							num3 = 47;
							break;
						case 47:
							num3 = 92;
							break;
						case 96:
							num3 = 44;
							break;
						case 44:
							num3 = 39;
							break;
						case 39:
							num3 = 46;
							break;
						case 46:
							num3 = 39;
							break;
						case 127:
							num3 = 46;
							break;
						case 95:
							num3 = 28;
							break;
						case 28:
							num3 = 95;
							break;
						case 112:
							num3 = 98;
							break;
						case 98:
							num3 = 112;
							break;
						case 113:
							num3 = 100;
							break;
						case 100:
							num3 = 113;
							break;
						case 239:
							num3 = 109;
							break;
						case 109:
							num3 = 239;
							break;
						case 218:
							num3 = 192;
							break;
						case 217:
							num3 = 191;
							break;
						case 192:
							num3 = 218;
							break;
						case 191:
							num3 = 217;
							break;
						case 193:
							num3 = 194;
							break;
						case 194:
							num3 = 193;
							break;
						case 213:
							num3 = 212;
							break;
						case 190:
							num3 = 184;
							break;
						case 212:
							num3 = 213;
							break;
						case 184:
							num3 = 190;
							break;
						case 207:
							num3 = 209;
							break;
						case 209:
							num3 = 207;
							break;
						case 214:
							num3 = 211;
							break;
						case 189:
							num3 = 183;
							break;
						case 211:
							num3 = 214;
							break;
						case 183:
							num3 = 189;
							break;
						case 208:
							num3 = 210;
							break;
						case 210:
							num3 = 208;
							break;
						case 201:
							num3 = 200;
							break;
						case 188:
							num3 = 187;
							break;
						case 200:
							num3 = 201;
							break;
						case 187:
							num3 = 188;
							break;
						case 202:
							num3 = 203;
							break;
						case 203:
							num3 = 202;
							break;
						case 220:
							num3 = 221;
							break;
						case 221:
							num3 = 220;
							break;
						}
						dataFlipY[m][n] = num3;
					}
				}
			}
		}

		public void FromTextV2(string rawPageText, bool skipFirstLine)
		{
			rawPageText = rawPageText.TrimEnd('\n');
			rawPageText = rawPageText.TrimEnd('\r');
			string[] array = Regex.Split(rawPageText, "\r\n|\r|\n");
			if (skipFirstLine && array.Length == 1)
			{
				width = 0;
				height = 0;
				data = new int[0][];
				return;
			}
			width = -1;
			height = array.Length;
			if (skipFirstLine)
			{
				height--;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (!(i == 0 && skipFirstLine))
				{
					int length = array[i].Length;
					if (width < length)
					{
						width = length;
					}
				}
			}
			data = new int[width][];
			for (int j = 0; j < width; j++)
			{
				data[j] = new int[height];
			}
			for (int k = 0; k < array.Length; k++)
			{
				int num = k;
				if (skipFirstLine)
				{
					num--;
					if (num < 0)
					{
						continue;
					}
				}
				string text = array[k];
				for (int l = 0; l < width; l++)
				{
					if (l >= text.Length)
					{
						data[l][num] = -1;
						continue;
					}
					char c = text[l];
					if (c == '#')
					{
						data[l][num] = -1;
						continue;
					}
					int num2 = SpecialSymbols.Map(c);
					if (num2 >= 0)
					{
						data[l][num] = num2;
					}
					else
					{
						data[l][num] = c;
					}
				}
			}
		}

		public void FromText(string rawPageText)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			while (true)
			{
				num = rawPageText.IndexOf('%', num2) + 1;
				if (num < num2)
				{
					break;
				}
				int num4 = rawPageText.IndexOf('%', num);
				num2 = ((num4 >= 0) ? rawPageText.LastIndexOf('#', num4) : rawPageText.LastIndexOf('#'));
				int num5 = num2 - num;
				if (num5 < 0)
				{
					break;
				}
				string text = rawPageText.Substring(num, num5);
				workRows.Add(text);
				int count = Regex.Matches(text, "%").Count;
				num5 -= count * 5;
				num3 = Mathf.Max(num3, num5);
				if (VERBOSE)
				{
					Debug.Log("Row: " + text);
				}
			}
			width = num3;
			height = workRows.Count;
			data = new int[width][];
			for (int i = 0; i < num3; i++)
			{
				data[i] = new int[height];
			}
			for (int j = 0; j < workRows.Count; j++)
			{
				string text2 = workRows[j];
				num = 0;
				for (int k = 0; k < num3; k++)
				{
					if (text2.Length < num3)
					{
						data[k][j] = 0;
						continue;
					}
					string symbol = text2.Substring(num, 1);
					num++;
					data[k][j] = ConvertSymbol(symbol);
				}
			}
			workRows.Clear();
		}

		public int ConvertSymbol(string symbol)
		{
			int num = 0;
			if (symbol == "#")
			{
				num = -1;
			}
			else if (symbol.Length == 5)
			{
				num = Utils.ParseInt(symbol.Substring(1, 4));
			}
			else
			{
				num = symbol[0];
				if (num > 127)
				{
					num = SpecialSymbols.Map(symbol[0]);
				}
			}
			if (EXTRA_VERBOSE)
			{
				Debug.Log("Converted " + symbol + " to integer key " + num);
			}
			return num;
		}

		public string ConvertSymbol(int symbol)
		{
			if (symbol == -1)
			{
				return "#";
			}
			if (symbol > 255)
			{
				return ((char)symbol).ToString();
			}
			return SpecialSymbols.ReverseMap(symbol).ToString();
		}

		public string SerializeOptimized()
		{
			string text = "";
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < height; i++)
			{
				stringBuilder.Clear();
				for (int num = width - 1; num >= 0; num--)
				{
					int num2 = data[num][i];
					if (stringBuilder.Length == 0)
					{
						if (num2 == -1 && num > 0)
						{
							continue;
						}
						if (num2 == 32)
						{
							stringBuilder.Append(" #");
							continue;
						}
					}
					string value = ConvertSymbol(num2);
					stringBuilder.Insert(0, value);
				}
				text += stringBuilder.ToString();
				if (i < height - 1)
				{
					text += "\n";
				}
			}
			return text;
		}
	}

	private static bool VERBOSE;

	private static bool EXTRA_VERBOSE;

	private List<Page> pages = new List<Page>();

	public int loadingVersion { get; set; }

	public List<StringReplacement> stringReplacements { get; set; }

	public List<Page> Pages => pages;

	public void FromText(string rawAsciiText, int pageStartIndex = 0, int pageCount = -1)
	{
		if (VERBOSE)
		{
			Debug.Log("From Text: \n" + rawAsciiText);
		}
		string[] separator = new string[1] { "%%" };
		string[] array = rawAsciiText.Split(separator, StringSplitOptions.None);
		if (VERBOSE)
		{
			Debug.Log("Page Count: " + array.Length);
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (pageCount > 0 && num2 >= pageCount)
			{
				break;
			}
			string text = array[i];
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			num++;
			if (pageStartIndex >= num && (num2 > 0 || i < array.Length - 1))
			{
				continue;
			}
			num2++;
			PageMeta pageMeta = null;
			int num3 = text.IndexOf('{');
			if (num3 >= 0)
			{
				int num4 = text.IndexOf('}');
				if (num3 < num4)
				{
					int num5 = text.IndexOf('\n');
					if (num5 < 0)
					{
						num5 = text.IndexOf('\r');
					}
					if (num5 > num4)
					{
						pageMeta = new PageMeta();
						pageMeta.Parse(text);
					}
				}
			}
			bool skipFirstLine = i > 0 || pageMeta != null;
			AddPage(text, pageMeta, skipFirstLine);
		}
	}

	public int ComputeWidth()
	{
		int num = 0;
		for (int i = 0; i < pages.Count; i++)
		{
			num = Mathf.Max(num, pages[i].width);
		}
		return num;
	}

	public int ComputeHeight()
	{
		int num = 0;
		for (int i = 0; i < pages.Count; i++)
		{
			num = Mathf.Max(num, pages[i].height);
		}
		return num;
	}

	public void AddPage(string rawPageText, PageMeta meta, bool skipFirstLine)
	{
		if (stringReplacements != null)
		{
			for (int i = 0; i < stringReplacements.Count; i++)
			{
				rawPageText = stringReplacements[i].Process(rawPageText);
			}
		}
		Page page = new Page();
		if (loadingVersion == 2)
		{
			page.FromTextV2(rawPageText, skipFirstLine);
		}
		else
		{
			page.FromText(rawPageText);
		}
		int num = meta?.repeat ?? 1;
		while (--num >= 0)
		{
			pages.Add(page);
		}
	}

	public string SerializeOptimized()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Page page = null;
		string text = null;
		int num = 1;
		for (int num2 = pages.Count - 1; num2 >= 0; num2--)
		{
			Page page2 = pages[num2];
			if (page2 == page)
			{
				num++;
			}
			else
			{
				string text2 = page2.SerializeOptimized();
				if (text2 == text)
				{
					Debug.LogWarning("Duplicate page data (page " + num2 + "). Cannot auto-merge:\n" + text2);
				}
				if (num > 1)
				{
					stringBuilder.Insert(0, "\n%% {repeat:" + num + "}\n");
				}
				else if (num2 < pages.Count - 1)
				{
					stringBuilder.Insert(0, "\n%%\n");
				}
				stringBuilder.Insert(0, text2);
				page = page2;
				text = text2;
				num = 1;
			}
		}
		if (num > 1)
		{
			stringBuilder.Insert(0, "% {repeat:" + num + "}\n");
		}
		return stringBuilder.ToString();
	}
}
