using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class FloatIntComparer : IComparer<KeyValuePair<float, int>>
	{
		public int Compare(KeyValuePair<float, int> x, KeyValuePair<float, int> y)
		{
			if (x.Key < y.Key - 0.0001f)
			{
				return -1;
			}
			if (x.Key > y.Key + 0.0001f)
			{
				return 1;
			}
			if (x.Value == y.Value)
			{
				return 0;
			}
			if (x.Value >= y.Value)
			{
				return 1;
			}
			return -1;
		}
	}
}
