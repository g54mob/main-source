using System;
using UnityEngine;

namespace Mystery.Graphing
{
	public struct PlottableGraphPoint<X, Y> : IPlottableGraphPoint where X : IComparable<X> where Y : IComparable<Y>
	{
		private X valueX;

		private Y valueY;

		private Color color;

		public X ValueX => valueX;

		public Y ValueY => valueY;

		public Color Color => color;

		object IPlottableGraphPoint.ValueX => valueX;

		object IPlottableGraphPoint.ValueY => valueY;

		Color IPlottableGraphPoint.Color => color;

		public PlottableGraphPoint(X valueX, Y valueY, Color color)
		{
			this.valueX = valueX;
			this.valueY = valueY;
			this.color = color;
		}

		public override string ToString()
		{
			return $"({ValueX}, {ValueY})";
		}
	}
}
