using System.Collections.Generic;
using UnityEngine;

public class CsvTable
{
	private class PoppedRow
	{
		public List<string> cols = new List<string>();

		public int end;

		public static PoppedRow Pop(string text, int start0)
		{
			PoppedRow poppedRow = new PoppedRow();
			string text2 = string.Empty;
			int num = start0;
			while (num < text.Length)
			{
				char c = text[num];
				switch (c)
				{
				case '"':
				{
					int num2 = num + 1;
					int num3 = num2;
					while (true)
					{
						num3 = text.IndexOf("\"", num2);
						if (num3 < 0)
						{
							throw new UnityException("Unclosed quote from " + text.Substring(num2, 40));
						}
						if (num3 == text.Length - 1 || text[num3 + 1] != '"')
						{
							break;
						}
						num2 = num3 + 2;
					}
					text2 = text.Substring(num + 1, num3 - num - 1).Replace("\"\"", "\"");
					num = num3 + 1;
					continue;
				}
				case ',':
					poppedRow.cols.Add(FormatCell(text2));
					text2 = string.Empty;
					num++;
					continue;
				case '\n':
					break;
				default:
					text2 += c;
					num++;
					continue;
				}
				num++;
				break;
			}
			if (text2.Length != 0)
			{
				poppedRow.cols.Add(FormatCell(text2));
			}
			poppedRow.end = num;
			return poppedRow;
		}

		private static string FormatCell(string s)
		{
			return s.Trim().Replace("\\n", "\n").Replace("&nbsp;", "\u00a0")
				.Replace("\\t", "\t");
		}
	}

	private Dictionary<string, int> colIds;

	private List<List<string>> rows;

	public int numRows
	{
		get
		{
			return rows.Count;
		}
	}

	public int numCols
	{
		get
		{
			return colIds.Count;
		}
	}

	public CsvTable(string text)
	{
		colIds = null;
		rows = new List<List<string>>();
		int num = 0;
		while (num < text.Length)
		{
			PoppedRow poppedRow = PoppedRow.Pop(text, num);
			if (colIds == null)
			{
				colIds = new Dictionary<string, int>();
				int num2 = 0;
				foreach (string col in poppedRow.cols)
				{
					colIds.Add(col, num2);
					num2++;
				}
			}
			else
			{
				rows.Add(poppedRow.cols);
			}
			num = poppedRow.end;
		}
	}

	public string GetCell(int row, string colId)
	{
		if (row < 0 || row >= numRows || !colIds.ContainsKey(colId))
		{
			return string.Empty;
		}
		int num = colIds[colId];
		if (num < 0 || num >= rows[row].Count)
		{
			return string.Empty;
		}
		return rows[row][num];
	}

	public string GetCell(int row, int col)
	{
		if (row < 0 || row >= numRows || col < 0 || col >= rows[row].Count)
		{
			return string.Empty;
		}
		return rows[row][col];
	}

	public int GetColIndex(string colId)
	{
		int value = -1;
		colIds.TryGetValue(colId, out value);
		return value;
	}
}
