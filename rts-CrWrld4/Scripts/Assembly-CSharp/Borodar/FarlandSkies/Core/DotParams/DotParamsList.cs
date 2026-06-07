using System.Collections.Generic;

namespace Borodar.FarlandSkies.Core.DotParams
{
	public class DotParamsList<T> : SortedList<float, T>
	{
		public DotParamsList(int capacity)
		{
		}

		public int FindIndexPerTime(float time)
		{
			return 0;
		}

		private static int BinarySearch<T>(IList<T> list, T value)
		{
			return 0;
		}
	}
}
