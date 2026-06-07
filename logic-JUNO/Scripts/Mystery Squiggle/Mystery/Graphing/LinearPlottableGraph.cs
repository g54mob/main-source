using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class LinearPlottableGraph<X, Y> : PlottableGraph<X, Y> where X : IComparable<X> where Y : IComparable<Y>
	{
		public LinearPlottableGraph()
		{
		}

		public override void AddPoint(X valueX, Y valueY, Color color)
		{
			if (valueX.CompareTo(MaxX) < 0)
			{
				IEnumerator<LinkedListNode<PlottableGraphPoint<X, Y>>> linkedListNodeEnumerator = GetLinkedListNodeEnumerator();
				while (linkedListNodeEnumerator.MoveNext())
				{
					if (linkedListNodeEnumerator.Current != null && linkedListNodeEnumerator.Current.Value.ValueX.CompareTo(valueX) >= 0)
					{
						AddNodeAfter(linkedListNodeEnumerator.Current, new PlottableGraphPoint<X, Y>(valueX, valueY, color));
						break;
					}
				}
			}
			else
			{
				AddNode(new PlottableGraphPoint<X, Y>(valueX, valueY, color));
			}
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
				PlottableGraphPoint<X, Y> plottableGraphPoint = FindPointAt(xOffset);
				valueString = YToString(plottableGraphPoint.ValueY);
				valueColor = plottableGraphPoint.Color;
			}
		}

		public override string GetYStringAt(float xOffset)
		{
			if (xOffset < 0f || xOffset > 1f)
			{
				return "-";
			}
			return YToString(FindPointAt(xOffset).ValueY);
		}
	}
}
