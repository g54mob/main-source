using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	[Serializable]
	public class PascalSet : ICollection<int>, IEnumerable<int>, IEnumerable, ISet, IEquatable<PascalSet>
	{
		private readonly BitArray data;

		private readonly int lowerBound;

		private readonly int upperBound;

		public int LowerBound
		{
			get
			{
				return lowerBound;
			}
		}

		public int UpperBound
		{
			get
			{
				return upperBound;
			}
		}

		public int Capacity
		{
			get
			{
				return upperBound - lowerBound + 1;
			}
		}

		public bool this[int item]
		{
			get
			{
				CheckValidIndex(item);
				return data[GetOffSet(item)];
			}
		}

		public int Count { get; private set; }

		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}

		public bool IsFull
		{
			get
			{
				return Capacity == Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public PascalSet(int upperBound)
			: this(0, upperBound)
		{
		}

		public PascalSet(int upperBound, int[] initialValues)
			: this(0, upperBound, initialValues)
		{
		}

		public PascalSet(int lowerBound, int upperBound, int[] initialValues)
			: this(lowerBound, upperBound)
		{
			Guard.ArgumentNotNull(initialValues, "initialValues");
			for (int i = 0; i < initialValues.Length; i++)
			{
				Add(initialValues[i]);
			}
		}

		public PascalSet(int lowerBound, int upperBound)
		{
			if (lowerBound < 0)
			{
				throw new ArgumentException("The lower bound must be larger or equal to zero.", "lowerBound");
			}
			if (upperBound < lowerBound)
			{
				throw new ArgumentException("The upper bound must be larger than the lower bound specified.", "upperBound");
			}
			this.lowerBound = lowerBound;
			this.upperBound = upperBound;
			data = new BitArray(upperBound - lowerBound + 1, false);
		}

		private PascalSet(BitArray initialData, int lowerBound, int upperBound)
		{
			this.upperBound = upperBound;
			this.lowerBound = lowerBound;
			data = initialData;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i])
				{
					Count++;
				}
			}
		}

		public PascalSet Union(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			CheckIfUniverseTheSame(set);
			return new PascalSet(data.Or(set.data), lowerBound, upperBound);
		}

		public PascalSet Subtract(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			CheckIfUniverseTheSame(set);
			return new PascalSet(data.Xor(set.data), lowerBound, upperBound);
		}

		public PascalSet Intersection(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			CheckIfUniverseTheSame(set);
			return new PascalSet(data.And(set.data), lowerBound, upperBound);
		}

		public PascalSet Inverse()
		{
			return new PascalSet(data.Not(), lowerBound, upperBound);
		}

		public bool IsSubsetOf(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			CheckIfUniverseTheSame(set);
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] && !set.data[i])
				{
					return false;
				}
			}
			return true;
		}

		public bool IsProperSubsetOf(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			CheckIfUniverseTheSame(set);
			if (IsSubsetOf(set))
			{
				return !set.IsSubsetOf(this);
			}
			return false;
		}

		public bool IsSupersetOf(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			CheckIfUniverseTheSame(set);
			for (int i = 0; i < data.Length; i++)
			{
				if (set.data[i] && !data[i])
				{
					return false;
				}
			}
			return true;
		}

		public bool IsProperSupersetOf(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			CheckIfUniverseTheSame(set);
			if (IsSupersetOf(set))
			{
				return !set.IsSupersetOf(this);
			}
			return false;
		}

		public static PascalSet operator +(PascalSet left, PascalSet right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.Union(right);
		}

		public static PascalSet operator -(PascalSet left, PascalSet right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.Subtract(right);
		}

		public static PascalSet operator *(PascalSet left, PascalSet right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.Intersection(right);
		}

		public static bool operator <=(PascalSet left, PascalSet right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.IsSubsetOf(right);
		}

		public static bool operator >=(PascalSet left, PascalSet right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.IsSupersetOf(right);
		}

		public static bool operator <(PascalSet left, PascalSet right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.IsProperSubsetOf(right);
		}

		public static bool operator >(PascalSet left, PascalSet right)
		{
			Guard.ArgumentNotNull(left, "left");
			return left.IsProperSupersetOf(right);
		}

		public static PascalSet operator !(PascalSet set)
		{
			Guard.ArgumentNotNull(set, "set");
			return set.Inverse();
		}

		private int GetOffSet(int item)
		{
			return item - lowerBound;
		}

		private bool IsUniverseTheSame(PascalSet set)
		{
			if (set.lowerBound == lowerBound)
			{
				return set.upperBound == upperBound;
			}
			return false;
		}

		private void CheckIfUniverseTheSame(PascalSet set)
		{
			if (!IsUniverseTheSame(set))
			{
				throw new ArgumentException("The operation requested can only be done if the sets share the same universe.", "set");
			}
		}

		private bool IsIndexValid(int index)
		{
			if (index >= lowerBound)
			{
				return index <= upperBound;
			}
			return false;
		}

		private void CheckValidIndex(int index)
		{
			if (!IsIndexValid(index))
			{
				throw new ArgumentException("The item is not in the universe of the set.", "index");
			}
		}

		public void Add(int item)
		{
			CheckValidIndex(item);
			int offSet = GetOffSet(item);
			if (!data[offSet])
			{
				AddItem(item, offSet);
			}
		}

		protected virtual void AddItem(int item, int offset)
		{
			Count++;
			data[offset] = true;
		}

		public bool Remove(int item)
		{
			CheckValidIndex(item);
			int offSet = GetOffSet(item);
			if (data[offSet])
			{
				RemoveItem(item, offSet);
				return true;
			}
			return false;
		}

		protected virtual void RemoveItem(int item, int offset)
		{
			Count--;
			data[offset] = false;
		}

		public bool Contains(int item)
		{
			CheckValidIndex(item);
			return data[item];
		}

		public void Clear()
		{
			ClearItems();
		}

		protected virtual void ClearItems()
		{
			data.SetAll(false);
			Count = 0;
		}

		public void CopyTo(int[] array, int arrayIndex)
		{
			Guard.ArgumentNotNull(array, "array");
			if (array.Length - arrayIndex < Count)
			{
				throw new ArgumentException("Not enough space in the target array.", "array");
			}
			using (IEnumerator<int> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					int current = enumerator.Current;
					array.SetValue(current, arrayIndex++);
				}
			}
		}

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 0; i < data.Count; i++)
			{
				if (data[i])
				{
					yield return i + lowerBound;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		ISet ISet.Subtract(ISet set)
		{
			return Subtract((PascalSet)set);
		}

		ISet ISet.Intersection(ISet set)
		{
			return Intersection((PascalSet)set);
		}

		ISet ISet.Inverse()
		{
			return Inverse();
		}

		bool ISet.IsProperSubsetOf(ISet set)
		{
			return IsProperSubsetOf((PascalSet)set);
		}

		bool ISet.IsProperSupersetOf(ISet set)
		{
			return IsProperSupersetOf((PascalSet)set);
		}

		bool ISet.IsSubsetOf(ISet set)
		{
			return IsSubsetOf((PascalSet)set);
		}

		bool ISet.IsSupersetOf(ISet set)
		{
			return IsSupersetOf((PascalSet)set);
		}

		ISet ISet.Union(ISet set)
		{
			return Union((PascalSet)set);
		}

		public bool Equals(PascalSet other)
		{
			if (other == null || !IsUniverseTheSame(other))
			{
				return false;
			}
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != other.data[i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
