using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class FloatFloatComparer : IComparer<KeyValuePair<float, float>>
	{
		public int Compare(KeyValuePair<float, float> x, KeyValuePair<float, float> y)
		{
			if (x.Key < y.Key - 0.0001f)
			{
				return -1;
			}
			if (x.Key > y.Key + 0.0001f)
			{
				return 1;
			}
			if (Comparer.IsEquivalent(x.Value, y.Value))
			{
				return 0;
			}
			if (!(x.Value < y.Value - 0.0001f))
			{
				return 1;
			}
			return -1;
		}
	}
}
