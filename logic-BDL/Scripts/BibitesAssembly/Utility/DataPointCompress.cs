using System;

namespace Utility
{
	public static class DataPointCompress<T> where T : struct, IDataPoint
	{
		public static T Sum(T[] array, Func<int, int> remap, int n)
		{
			T result = default(T);
			int lenght = result.GetLenght();
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < lenght; j++)
				{
					result[j] += array[remap(i)][j];
				}
			}
			return result;
		}
	}
}
