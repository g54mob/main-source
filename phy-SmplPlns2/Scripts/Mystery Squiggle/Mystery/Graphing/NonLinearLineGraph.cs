using System;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class NonLinearLineGraph<X, Y> : LineGraph<X, Y>, INonLinearLineGraph, IPlottableGraph where X : IComparable<X>
	{
		public override void AddPoint(X valueX, Y valueY, Color color)
		{
			AddNode(new LineGraphPoint<X, Y>(valueX, valueY, color));
			base.DefaultRangeX.UpdateMinMax(valueX);
			base.DefaultRangeY.UpdateMinMax(valueY);
		}
	}
}
