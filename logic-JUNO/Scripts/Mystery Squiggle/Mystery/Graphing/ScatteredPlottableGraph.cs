using System;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class ScatteredPlottableGraph<X, Y> : PlottableGraph<X, Y> where X : IComparable<X> where Y : IComparable<Y>
	{
		public ScatteredPlottableGraph()
		{
		}

		public override void AddPoint(X valueX, Y valueY, Color color)
		{
			AddNode(new PlottableGraphPoint<X, Y>(valueX, valueY, color));
			UpdateMinMaxX(valueX);
			UpdateMinMaxY(valueY);
		}

		public override void GetYSampleAt(float xOffset, out string valueString, out Color valueColor)
		{
			if (xOffset < 0f || xOffset > 1f)
			{
				valueString = "-";
				valueColor = Color.black;
			}
			else
			{
				valueString = XToString(GetSearchX(xOffset));
				valueColor = Color.black;
			}
		}

		public override string GetYStringAt(float xOffset)
		{
			if (xOffset < 0f || xOffset > 1f)
			{
				return "-";
			}
			return XToString(GetSearchX(xOffset));
		}
	}
}
