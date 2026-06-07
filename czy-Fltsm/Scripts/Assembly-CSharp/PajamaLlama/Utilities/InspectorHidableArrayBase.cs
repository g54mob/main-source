using System;
using System.Collections;

namespace PajamaLlama.Utilities
{
	[Serializable]
	public abstract class InspectorHidableArrayBase<T> : IEnumerable
	{
		public abstract T[] Array { get; }

		public int Length => Array.Length;

		public T this[int index]
		{
			get
			{
				return Array[index];
			}
			set
			{
				Array[index] = value;
			}
		}

		public bool IsEmpty()
		{
			return Array.Length == 0;
		}

		public IEnumerator GetEnumerator()
		{
			return Array.GetEnumerator();
		}
	}
}
