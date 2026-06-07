using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Mystery.Graphing
{
	public static class GraphExportUtility
	{
		public static void WriteDelimited(StreamWriter sw, string name, IEnumerable<string> valueNames, List<IPlottableGraphPoint[]> list, string delimiter, bool format)
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

		private static void WriteDelimitedRaw(StreamWriter sw, string name, IEnumerable<string> valueNames, List<IPlottableGraphPoint[]> list, string delimiter)
		{
			IEnumerator<string> enumerator = valueNames?.GetEnumerator();
			foreach (IPlottableGraphPoint[] item in list)
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
				IPlottableGraphPoint[] array = item;
				foreach (IPlottableGraphPoint plottableGraphPoint in array)
				{
					sw.Write(plottableGraphPoint.ValueX);
					sw.Write(delimiter);
				}
				sw.WriteLine();
				sw.Write("Y");
				sw.Write(delimiter);
				array = item;
				foreach (IPlottableGraphPoint plottableGraphPoint2 in array)
				{
					sw.Write(plottableGraphPoint2.ValueY);
					sw.Write(delimiter);
				}
				sw.WriteLine();
				sw.Write("Color");
				sw.Write(delimiter);
				array = item;
				foreach (IPlottableGraphPoint plottableGraphPoint3 in array)
				{
					sw.Write(GetColorHex(plottableGraphPoint3.Color));
					sw.Write(delimiter);
				}
				sw.WriteLine();
				sw.WriteLine();
			}
		}

		private static void WriteDelimitedFormatted(StreamWriter sw, string name, IEnumerable<string> valueNames, List<IPlottableGraphPoint[]> list, string delimiter)
		{
			if (list.Count == 0)
			{
				return;
			}
			IEnumerator<string> enumerator = valueNames?.GetEnumerator();
			sw.Write(name);
			sw.Write(delimiter);
			sw.WriteLine();
			IPlottableGraphPoint[] array = list[0];
			sw.Write("Time");
			sw.Write(delimiter);
			IPlottableGraphPoint[] array2 = array;
			foreach (IPlottableGraphPoint plottableGraphPoint in array2)
			{
				sw.Write(plottableGraphPoint.ValueX);
				sw.Write(delimiter);
			}
			sw.WriteLine();
			int num = 0;
			foreach (IPlottableGraphPoint[] item in list)
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
				foreach (IPlottableGraphPoint plottableGraphPoint2 in array2)
				{
					sw.Write(plottableGraphPoint2.ValueY);
					sw.Write(delimiter);
				}
				sw.WriteLine();
				if (list.Count == 1)
				{
					sw.Write("Color");
					sw.Write(delimiter);
					array2 = item;
					foreach (IPlottableGraphPoint plottableGraphPoint3 in array2)
					{
						sw.Write(GetColorHex(plottableGraphPoint3.Color));
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
	}
}
