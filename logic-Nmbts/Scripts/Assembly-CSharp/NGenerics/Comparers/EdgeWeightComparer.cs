using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Comparers
{
	[Serializable]
	public sealed class EdgeWeightComparer<T> : IComparer<Edge<T>>
	{
		public int Compare(Edge<T> x, Edge<T> y)
		{
			return x.Weight.CompareTo(y.Weight);
		}
	}
}
