using System;
using System.Collections;
using System.Linq;

namespace FluentAssertions.Formatting
{
	public class MultidimensionalArrayFormatter : IValueFormatter
	{
		public bool CanHandle(object value)
		{
			if (value is Array array)
			{
				return array.Rank >= 2;
			}
			return false;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			Array arr = (Array)value;
			if (arr.Length == 0)
			{
				formattedGraph.AddFragment("{empty}");
				return;
			}
			int[] array = (from dimension in Enumerable.Range(0, arr.Rank)
				select arr.GetLowerBound(dimension)).ToArray();
			int num = 0;
			IEnumerator enumerator = arr.GetEnumerator();
			while (num >= 0)
			{
				int index = array[num];
				if (IsFirstIteration(arr, index, num))
				{
					formattedGraph.AddFragment("{");
				}
				if (IsInnerMostLoop(arr, num))
				{
					enumerator.MoveNext();
					formatChild(string.Join("-", array), enumerator.Current, formattedGraph);
					if (!IsLastIteration(arr, index, num))
					{
						formattedGraph.AddFragment(", ");
					}
					array[num]++;
					while (IsLastIteration(arr, index, num))
					{
						formattedGraph.AddFragment("}");
						array[num] = arr.GetLowerBound(num);
						num--;
						if (num < 0)
						{
							break;
						}
						index = array[num];
						if (!IsLastIteration(arr, index, num))
						{
							formattedGraph.AddFragment(", ");
						}
						array[num]++;
					}
				}
				else
				{
					num++;
				}
			}
		}

		private static bool IsFirstIteration(Array arr, int index, int dimension)
		{
			return index == arr.GetLowerBound(dimension);
		}

		private static bool IsInnerMostLoop(Array arr, int index)
		{
			return index == arr.Rank - 1;
		}

		private static bool IsLastIteration(Array arr, int index, int dimension)
		{
			return index >= arr.GetUpperBound(dimension);
		}
	}
}
