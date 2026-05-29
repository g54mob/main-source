using System;
using MyBox.Internal;

namespace MyBox
{
	[Serializable]
	public class Reorderable<T> : ReorderableBase
	{
		public T[] Collection;

		public int Length => 0;

		public T this[int i]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}
	}
}
