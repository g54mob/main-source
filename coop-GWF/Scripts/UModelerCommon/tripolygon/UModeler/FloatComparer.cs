using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class FloatComparer : IComparer<float>
	{
		public int Compare(float x, float y)
		{
			if (Mathf.Abs(x - y) < 0.0001f)
			{
				return 0;
			}
			if (!(x < y))
			{
				return 1;
			}
			return -1;
		}
	}
}
