using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Comparers
{
	[Serializable]
	public class AssociationKeyComparer<TKey, TValue> : IComparer<Association<TKey, TValue>>, IComparer<TKey> where TKey : IComparable
	{
		private readonly IComparer<TKey> comparer;

		public static AssociationKeyComparer<TKey, TValue> DefaultComparer
		{
			get
			{
				return new AssociationKeyComparer<TKey, TValue>();
			}
		}

		public AssociationKeyComparer()
		{
			comparer = Comparer<TKey>.Default;
		}

		public AssociationKeyComparer(IComparer<TKey> comparer)
		{
			this.comparer = comparer;
		}

		public int Compare(Association<TKey, TValue> x, Association<TKey, TValue> y)
		{
			return comparer.Compare(x.Key, y.Key);
		}

		public int Compare(TKey x, TKey y)
		{
			return comparer.Compare(x, y);
		}
	}
}
