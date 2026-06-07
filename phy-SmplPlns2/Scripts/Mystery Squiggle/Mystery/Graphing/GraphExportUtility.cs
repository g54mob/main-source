using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Mystery.Graphing
{
	public static class GraphExportUtility
	{
		public static void WriteDelimited(StreamWriter sw, string name, IEnumerable<string> valueNames, List<ILineGraphPoint[]> list, string delimiter, bool format)
		{
			if (format)
			{
				WriteDelimitedFormatted(sw, name, valueNames, list, delimiter);
			}
			else
			{
				WriteDelimitedRaw(sw, name, valueNames, list, delimiter);
			}
		}

		private static void WriteDelimitedRaw(StreamWriter sw, string name, IEnumerable<string> valueNames, List<ILineGraphPoint[]> list, string delimiter)
		{
			IEnumerator<string> enumerator = valueNames?.GetEnumerator();
			foreach (ILineGraphPoint[] item in list)
			{
				sw.Write(name);
				if (enumerator != null && enumerator.MoveNext() && enumerator.Current != null)
				{
					sw.Write(" - ");
					sw.Write(enumerator.Current);
				}
				sw.Write(delimiter);
				sw.WriteLine();
				sw.Write("X");
				sw.Write(delimiter);
				ILineGraphPoint[] array = item;
				foreach (ILineGraphPoint lineGraphPoint in array)
				{
					sw.Write(lineGraphPoint.ValueX);
					sw.Write(delimiter);
				}
				sw.WriteLine();
				sw.Write("Y");
				sw.Write(delimiter);
				array = item;
				foreach (ILineGraphPoint lineGraphPoint2 in array)
				{
					sw.Write(lineGraphPoint2.ValueY);
					sw.Write(delimiter);
				}
				sw.WriteLine();
				sw.Write("Color");
				sw.Write(delimiter);
				array = item;
				foreach (ILineGraphPoint lineGraphPoint3 in array)
				{
					sw.Write(GetColorHex(lineGraphPoint3.Color));
					sw.Write(delimiter);
				}
				sw.WriteLine();
				sw.WriteLine();
			}
		}

		private static void WriteDelimitedFormatted(StreamWriter sw, string name, IEnumerable<string> valueNames, List<ILineGraphPoint[]> list, string delimiter)
		{
			if (list.Count == 0)
			{
				return;
			}
			IEnumerator<string> enumerator = valueNames?.GetEnumerator();
			sw.Write(name);
			sw.Write(delimiter);
			sw.WriteLine();
			ILineGraphPoint[] array = list[0];
			sw.Write("Time");
			sw.Write(delimiter);
			ILineGraphPoint[] array2 = array;
			foreach (ILineGraphPoint lineGraphPoint in array2)
			{
				sw.Write(lineGraphPoint.ValueX);
				sw.Write(delimiter);
			}
			sw.WriteLine();
			int num = 0;
			foreach (ILineGraphPoint[] item in list)
			{
				if (enumerator != null && enumerator.MoveNext() && enumerator.Current != null)
				{
					sw.Write(enumerator.Current);
				}
				else
				{
					sw.Write("Value");
					if (list.Count > 1)
					{
						sw.Write(" ");
						sw.Write(num.ToString());
					}
				}
				num++;
				sw.Write(delimiter);
				array2 = item;
				foreach (ILineGraphPoint lineGraphPoint2 in array2)
				{
					sw.Write(lineGraphPoint2.ValueY);
					sw.Write(delimiter);
				}
				sw.WriteLine();
				if (list.Count == 1)
				{
					sw.Write("Color");
					sw.Write(delimiter);
					array2 = item;
					foreach (ILineGraphPoint lineGraphPoint3 in array2)
					{
						sw.Write(GetColorHex(lineGraphPoint3.Color));
						sw.Write(delimiter);
					}
					sw.WriteLine();
				}
			}
		}

		public static string GetColorHex(Color32 color)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(color.r.ToString("X2"));
			stringBuilder.Append(color.g.ToString("X2"));
			stringBuilder.Append(color.b.ToString("X2"));
			stringBuilder.Append(color.a.ToString("X2"));
			return stringBuilder.ToString();
		}

		public static void WriteMesh(StreamWriter sw, string name, IEnumerable<string> valueNames, List<ILineGraphPoint[]> list, bool format)
		{
			IEnumerator<string> enumerator = valueNames?.GetEnumerator();
			int num = 0;
			foreach (ILineGraphPoint[] item in list)
			{
				int num2 = 0;
				ILineGraphPoint[] array = item;
				foreach (ILineGraphPoint lineGraphPoint in array)
				{
					sw.Write("v ");
					sw.Write(lineGraphPoint.ValueX);
					sw.Write(" ");
					sw.Write(lineGraphPoint.ValueY);
					sw.WriteLine(" 0");
					num2++;
				}
				int num3 = 0;
				array = item;
				for (int i = 0; i < array.Length; i++)
				{
					_ = array[i];
					sw.Write("vt ");
					sw.Write((float)num3 / (float)(num2 - 1));
					sw.WriteLine(" 0");
					num3++;
				}
				if (enumerator != null && enumerator.MoveNext() && enumerator.Current != null)
				{
					sw.Write("g ");
					sw.Write(enumerator.Current);
				}
				sw.Write("l");
				for (num3 = 0; num3 < num2; num3++)
				{
					sw.Write(" ");
					sw.Write(num + num3);
				}
				sw.WriteLine();
				num += num2;
			}
		}
	}
}
