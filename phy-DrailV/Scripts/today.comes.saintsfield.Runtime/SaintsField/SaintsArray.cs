using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaintsField
{
	[Serializable]
	public struct SaintsArray<T> : IWrapProp, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, ICollection, ICloneable, IStructuralComparable
	{
		[SerializeField]
		public T[] value;

		public int Count => value.Length;

		public T this[int index]
		{
			get
			{
				return value[index];
			}
			set
			{
				this.value[index] = value;
			}
		}

		public bool IsSynchronized => value.IsSynchronized;

		public object SyncRoot => value.SyncRoot;

		public static implicit operator T[](SaintsArray<T> saintsArray)
		{
			return saintsArray.value;
		}

		public static explicit operator SaintsArray<T>(T[] array)
		{
			return new SaintsArray<T>
			{
				value = array
			};
		}

		public override string ToString()
		{
			return value.ToString();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)value).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void CopyTo(Array array, int index)
		{
			value.CopyTo(array, index);
		}

		public object Clone()
		{
			return value.Clone();
		}

		public int CompareTo(object other, IComparer comparer)
		{
			throw null;
		}
	}
}
