using System;
using UnityEngine;

namespace Mystery.Graphing
{
	public struct LineGraphPoint<X, Y> : ILineGraphPoint where X : IComparable<X>
	{
		private X valueX;

		private Y valueY;

		private Color color;

		public X ValueX => valueX;

		public Y ValueY => valueY;

		public Color Color => color;

		object ILineGraphPoint.ValueX => valueX;

		object ILineGraphPoint.ValueY => valueY;

		Color ILineGraphPoint.Color => color;

		public LineGraphPoint(X valueX, Y valueY, Color color)
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
