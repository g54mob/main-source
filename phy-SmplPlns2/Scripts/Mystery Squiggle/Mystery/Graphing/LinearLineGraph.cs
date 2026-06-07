using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class LinearLineGraph<X, Y> : LineGraph<X, Y>, ILinearLineGraph, IPlottableGraph where X : IComparable<X>
	{
		public override void AddPoint(X valueX, Y valueY, Color color)
		{
			if (valueX.CompareTo(base.DefaultRangeX.Max) < 0)
			{
				IEnumerator<LinkedListNode<LineGraphPoint<X, Y>>> linkedListNodeEnumerator = GetLinkedListNodeEnumerator();
				while (linkedListNodeEnumerator.MoveNext())
				{
					if (linkedListNodeEnumerator.Current != null && linkedListNodeEnumerator.Current.Value.ValueX.CompareTo(valueX) >= 0)
					{
						AddNodeAfter(linkedListNodeEnumerator.Current, new LineGraphPoint<X, Y>(valueX, valueY, color));
						break;
					}
				}
			}
			else
			{
				AddNode(new LineGraphPoint<X, Y>(valueX, valueY, color));
			}
			base.DefaultRangeX.UpdateMinMax(valueX);
			base.DefaultRangeY.UpdateMinMax(valueY);
		}
	}
}
