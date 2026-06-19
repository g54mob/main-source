using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class Reorderable<T> : ReorderableBase
	{
		public T[] Collection;

		public int Length => Collection.Length;

		public T this[int i]
		{
			get
			{
				return Collection[i];
			}
			set
			{
				Collection[i] = value;
			}
		}
	}
}
