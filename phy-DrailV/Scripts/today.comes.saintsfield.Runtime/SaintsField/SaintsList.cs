using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaintsField
{
	[Serializable]
	public struct SaintsList<T> : IWrapProp, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		[SerializeField]
		public List<T> value;

		public int Count => value.Count;

		public bool IsReadOnly => false;

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

		public override string ToString()
		{
			return value.ToString();
		}

		public static implicit operator List<T>(SaintsList<T> saintsArray)
		{
			return saintsArray.value;
		}

		public static explicit operator SaintsList<T>(List<T> array)
		{
			return new SaintsList<T>
			{
				value = array
			};
		}

		public IEnumerator<T> GetEnumerator()
		{
			return value.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(T item)
		{
			value.Add(item);
		}

		public void Clear()
		{
			value.Clear();
		}

		public bool Contains(T item)
		{
			return value.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			value.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			return value.Remove(item);
		}

		public int IndexOf(T item)
		{
			return value.IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			value.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			value.RemoveAt(index);
		}

		public void AddRange(IEnumerable<T> collection)
		{
			value.AddRange(collection);
		}
	}
}
