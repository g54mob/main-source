using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class RingBuffer<T> : IEnumerable, IEnumerable<T>, ICollection<T>
	{
		[Serializable]
		public struct xeVzDEFrngwPqkddInvlKOvcSVh : IDisposable, IEnumerator, IEnumerator<T>
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == buffer.mkqVdeEMZbmmfgIzkIQXzOUNaiC + 1)
					{
						throw new InvalidOperationException();
					}
					return Current;
				}
			}

			internal xeVzDEFrngwPqkddInvlKOvcSVh(RingBuffer<T> buffer)
			{
				this.buffer = buffer;
				index = 0;
				version = buffer.wxDwUInmywxWjbzUIARycmGyOtR;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version == buffer.wxDwUInmywxWjbzUIARycmGyOtR && (uint)index < (uint)buffer.mkqVdeEMZbmmfgIzkIQXzOUNaiC)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return mfNfqFpgjeRZMbZOhOvoOMlbxmd();
			}

			private bool mfNfqFpgjeRZMbZOhOvoOMlbxmd()
			{
				if (version != buffer.wxDwUInmywxWjbzUIARycmGyOtR)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.mkqVdeEMZbmmfgIzkIQXzOUNaiC + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.wxDwUInmywxWjbzUIARycmGyOtR)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] EdLPtGxmOIZgSaXhrGGPAdQsDsye;

		private readonly int VEmNteWmpdRTYXxUtdCoLGPlsxd;

		private int ZPQYyHCEjUScHMJzqgxtuLIwhBk;

		private int fRjPasUICJCcXCULRIDFHbnOAgN;

		private int mkqVdeEMZbmmfgIzkIQXzOUNaiC;

		private int SskgmdhGDFJRkerRHqsMBEnckAwk;

		private int wxDwUInmywxWjbzUIARycmGyOtR;

		private IEqualityComparer<T> PlaWXSBeFxfnzAqVJcbEOqQrVlM = EqualityComparerNoAlloc<T>.Default;

		public int Count => mkqVdeEMZbmmfgIzkIQXzOUNaiC;

		public int Capacity => VEmNteWmpdRTYXxUtdCoLGPlsxd;

		public int OverrunCount => SskgmdhGDFJRkerRHqsMBEnckAwk;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return PlaWXSBeFxfnzAqVJcbEOqQrVlM;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				PlaWXSBeFxfnzAqVJcbEOqQrVlM = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = mtEGmVgvSlBkJawpgPzkVaYixiNJ(index);
				if (!WZLVhIYnNDWXZyLONfcZgzWzDLm(num))
				{
					throw new IndexOutOfRangeException();
				}
				return EdLPtGxmOIZgSaXhrGGPAdQsDsye[num];
			}
			set
			{
				int num = mtEGmVgvSlBkJawpgPzkVaYixiNJ(index);
				if (!WZLVhIYnNDWXZyLONfcZgzWzDLm(num))
				{
					throw new IndexOutOfRangeException();
				}
				EdLPtGxmOIZgSaXhrGGPAdQsDsye[num] = value;
			}
		}

		int ICollection<T>.Count => Count;

		bool ICollection<T>.IsReadOnly => false;

		public RingBuffer(int capacity)
		{
			if (capacity <= 0)
			{
				throw new ArgumentOutOfRangeException("capacity must be > 0.");
			}
			EdLPtGxmOIZgSaXhrGGPAdQsDsye = new T[capacity];
			VEmNteWmpdRTYXxUtdCoLGPlsxd = capacity;
			Clear();
		}

		public void Enqueue(T item)
		{
			ZPQYyHCEjUScHMJzqgxtuLIwhBk = ((ZPQYyHCEjUScHMJzqgxtuLIwhBk < VEmNteWmpdRTYXxUtdCoLGPlsxd - 1) ? (ZPQYyHCEjUScHMJzqgxtuLIwhBk + 1) : 0);
			if (mkqVdeEMZbmmfgIzkIQXzOUNaiC == 0)
			{
				fRjPasUICJCcXCULRIDFHbnOAgN = 0;
			}
			else if (ZPQYyHCEjUScHMJzqgxtuLIwhBk == fRjPasUICJCcXCULRIDFHbnOAgN)
			{
				fRjPasUICJCcXCULRIDFHbnOAgN = ((fRjPasUICJCcXCULRIDFHbnOAgN < VEmNteWmpdRTYXxUtdCoLGPlsxd - 1) ? (fRjPasUICJCcXCULRIDFHbnOAgN + 1) : 0);
				SskgmdhGDFJRkerRHqsMBEnckAwk++;
			}
			EdLPtGxmOIZgSaXhrGGPAdQsDsye[ZPQYyHCEjUScHMJzqgxtuLIwhBk] = item;
			if (mkqVdeEMZbmmfgIzkIQXzOUNaiC < VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				mkqVdeEMZbmmfgIzkIQXzOUNaiC++;
			}
		}

		public bool EnqueueIfUnique(T item)
		{
			if (Contains(item))
			{
				return false;
			}
			Enqueue(item);
			return true;
		}

		public T Dequeue()
		{
			if (mkqVdeEMZbmmfgIzkIQXzOUNaiC == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = EdLPtGxmOIZgSaXhrGGPAdQsDsye[fRjPasUICJCcXCULRIDFHbnOAgN];
			if (fRjPasUICJCcXCULRIDFHbnOAgN == ZPQYyHCEjUScHMJzqgxtuLIwhBk)
			{
				Clear();
			}
			else
			{
				EdLPtGxmOIZgSaXhrGGPAdQsDsye[fRjPasUICJCcXCULRIDFHbnOAgN] = default(T);
				fRjPasUICJCcXCULRIDFHbnOAgN = ((fRjPasUICJCcXCULRIDFHbnOAgN < VEmNteWmpdRTYXxUtdCoLGPlsxd - 1) ? (fRjPasUICJCcXCULRIDFHbnOAgN + 1) : 0);
				SskgmdhGDFJRkerRHqsMBEnckAwk = 0;
				mkqVdeEMZbmmfgIzkIQXzOUNaiC--;
				wxDwUInmywxWjbzUIARycmGyOtR++;
			}
			return result;
		}

		public T Peek()
		{
			if (ZPQYyHCEjUScHMJzqgxtuLIwhBk < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return EdLPtGxmOIZgSaXhrGGPAdQsDsye[fRjPasUICJCcXCULRIDFHbnOAgN];
		}

		public bool Contains(T item)
		{
			return qfmnOUqVnwZcDRTCpZBcLUKeUtw(item, PlaWXSBeFxfnzAqVJcbEOqQrVlM) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return qfmnOUqVnwZcDRTCpZBcLUKeUtw(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, PlaWXSBeFxfnzAqVJcbEOqQrVlM);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return lOwINLJTWFpzGYQfXjVGXfPtlqx(qfmnOUqVnwZcDRTCpZBcLUKeUtw(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, PlaWXSBeFxfnzAqVJcbEOqQrVlM);
		}

		public bool Remove(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (Count == 0)
			{
				return false;
			}
			int num = qfmnOUqVnwZcDRTCpZBcLUKeUtw(item, comparer);
			if (num < 0)
			{
				return false;
			}
			WzNfLjARZGaNtNsWTVkjlIWxhpcC(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			WzNfLjARZGaNtNsWTVkjlIWxhpcC(mtEGmVgvSlBkJawpgPzkVaYixiNJ(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, PlaWXSBeFxfnzAqVJcbEOqQrVlM);
		}

		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			int num = 0;
			int count = Count;
			for (int num2 = count - 1; num2 >= 0; num2--)
			{
				if (comparer.Equals(this[num2], item))
				{
					RemoveAt(num2);
					num++;
				}
			}
			return num;
		}

		public void Clear()
		{
			if (mkqVdeEMZbmmfgIzkIQXzOUNaiC > 0)
			{
				if (ZPQYyHCEjUScHMJzqgxtuLIwhBk >= fRjPasUICJCcXCULRIDFHbnOAgN)
				{
					Array.Clear(EdLPtGxmOIZgSaXhrGGPAdQsDsye, fRjPasUICJCcXCULRIDFHbnOAgN, ZPQYyHCEjUScHMJzqgxtuLIwhBk - fRjPasUICJCcXCULRIDFHbnOAgN + 1);
				}
				else
				{
					Array.Clear(EdLPtGxmOIZgSaXhrGGPAdQsDsye, 0, ZPQYyHCEjUScHMJzqgxtuLIwhBk + 1);
					Array.Clear(EdLPtGxmOIZgSaXhrGGPAdQsDsye, fRjPasUICJCcXCULRIDFHbnOAgN, VEmNteWmpdRTYXxUtdCoLGPlsxd - fRjPasUICJCcXCULRIDFHbnOAgN);
				}
				mkqVdeEMZbmmfgIzkIQXzOUNaiC = 0;
			}
			ZPQYyHCEjUScHMJzqgxtuLIwhBk = -1;
			fRjPasUICJCcXCULRIDFHbnOAgN = -1;
			SskgmdhGDFJRkerRHqsMBEnckAwk = 0;
			wxDwUInmywxWjbzUIARycmGyOtR++;
		}

		private int qfmnOUqVnwZcDRTCpZBcLUKeUtw(T P_0)
		{
			return qfmnOUqVnwZcDRTCpZBcLUKeUtw(P_0, PlaWXSBeFxfnzAqVJcbEOqQrVlM);
		}

		private int qfmnOUqVnwZcDRTCpZBcLUKeUtw(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (mkqVdeEMZbmmfgIzkIQXzOUNaiC == 0)
			{
				return -1;
			}
			if (ZPQYyHCEjUScHMJzqgxtuLIwhBk >= fRjPasUICJCcXCULRIDFHbnOAgN)
			{
				for (int i = fRjPasUICJCcXCULRIDFHbnOAgN; i <= ZPQYyHCEjUScHMJzqgxtuLIwhBk; i++)
				{
					if (P_1.Equals(EdLPtGxmOIZgSaXhrGGPAdQsDsye[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= ZPQYyHCEjUScHMJzqgxtuLIwhBk; j++)
				{
					if (P_1.Equals(EdLPtGxmOIZgSaXhrGGPAdQsDsye[j], P_0))
					{
						return j;
					}
				}
				for (int k = fRjPasUICJCcXCULRIDFHbnOAgN; k < VEmNteWmpdRTYXxUtdCoLGPlsxd; k++)
				{
					if (P_1.Equals(EdLPtGxmOIZgSaXhrGGPAdQsDsye[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void WzNfLjARZGaNtNsWTVkjlIWxhpcC(int P_0)
		{
			if (!WZLVhIYnNDWXZyLONfcZgzWzDLm(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == fRjPasUICJCcXCULRIDFHbnOAgN)
			{
				Dequeue();
				return;
			}
			if (P_0 != ZPQYyHCEjUScHMJzqgxtuLIwhBk)
			{
				if (ZPQYyHCEjUScHMJzqgxtuLIwhBk > fRjPasUICJCcXCULRIDFHbnOAgN)
				{
					Array.Copy(EdLPtGxmOIZgSaXhrGGPAdQsDsye, P_0 + 1, EdLPtGxmOIZgSaXhrGGPAdQsDsye, P_0, ZPQYyHCEjUScHMJzqgxtuLIwhBk - P_0);
				}
				else if (P_0 < ZPQYyHCEjUScHMJzqgxtuLIwhBk)
				{
					Array.Copy(EdLPtGxmOIZgSaXhrGGPAdQsDsye, P_0 + 1, EdLPtGxmOIZgSaXhrGGPAdQsDsye, P_0, ZPQYyHCEjUScHMJzqgxtuLIwhBk - P_0);
				}
				else
				{
					Array.Copy(EdLPtGxmOIZgSaXhrGGPAdQsDsye, P_0 + 1, EdLPtGxmOIZgSaXhrGGPAdQsDsye, P_0, VEmNteWmpdRTYXxUtdCoLGPlsxd - P_0 - 1);
					EdLPtGxmOIZgSaXhrGGPAdQsDsye[VEmNteWmpdRTYXxUtdCoLGPlsxd - 1] = EdLPtGxmOIZgSaXhrGGPAdQsDsye[0];
					if (ZPQYyHCEjUScHMJzqgxtuLIwhBk > 0)
					{
						Array.Copy(EdLPtGxmOIZgSaXhrGGPAdQsDsye, 1, EdLPtGxmOIZgSaXhrGGPAdQsDsye, 0, ZPQYyHCEjUScHMJzqgxtuLIwhBk);
					}
				}
			}
			EdLPtGxmOIZgSaXhrGGPAdQsDsye[ZPQYyHCEjUScHMJzqgxtuLIwhBk] = default(T);
			ZPQYyHCEjUScHMJzqgxtuLIwhBk = ((ZPQYyHCEjUScHMJzqgxtuLIwhBk > 0) ? (ZPQYyHCEjUScHMJzqgxtuLIwhBk - 1) : (VEmNteWmpdRTYXxUtdCoLGPlsxd - 1));
			wxDwUInmywxWjbzUIARycmGyOtR++;
			mkqVdeEMZbmmfgIzkIQXzOUNaiC--;
		}

		private bool WZLVhIYnNDWXZyLONfcZgzWzDLm(int P_0)
		{
			if (mkqVdeEMZbmmfgIzkIQXzOUNaiC == 0)
			{
				return false;
			}
			if (ZPQYyHCEjUScHMJzqgxtuLIwhBk >= fRjPasUICJCcXCULRIDFHbnOAgN)
			{
				if (P_0 >= fRjPasUICJCcXCULRIDFHbnOAgN)
				{
					return P_0 <= ZPQYyHCEjUScHMJzqgxtuLIwhBk;
				}
				return false;
			}
			if (P_0 < fRjPasUICJCcXCULRIDFHbnOAgN)
			{
				return P_0 <= ZPQYyHCEjUScHMJzqgxtuLIwhBk;
			}
			return true;
		}

		private int lOwINLJTWFpzGYQfXjVGXfPtlqx(int P_0)
		{
			if ((uint)P_0 >= (uint)VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				return -1;
			}
			if (!WZLVhIYnNDWXZyLONfcZgzWzDLm(P_0))
			{
				return -1;
			}
			if (P_0 >= fRjPasUICJCcXCULRIDFHbnOAgN)
			{
				return P_0 - fRjPasUICJCcXCULRIDFHbnOAgN;
			}
			return P_0 + VEmNteWmpdRTYXxUtdCoLGPlsxd - fRjPasUICJCcXCULRIDFHbnOAgN;
		}

		private int mtEGmVgvSlBkJawpgPzkVaYixiNJ(int P_0)
		{
			if ((uint)P_0 >= (uint)mkqVdeEMZbmmfgIzkIQXzOUNaiC)
			{
				return -1;
			}
			P_0 = fRjPasUICJCcXCULRIDFHbnOAgN + P_0;
			if (P_0 >= VEmNteWmpdRTYXxUtdCoLGPlsxd)
			{
				P_0 -= VEmNteWmpdRTYXxUtdCoLGPlsxd;
			}
			return P_0;
		}

		void ICollection<T>.Add(T item)
		{
			Enqueue(item);
		}

		void ICollection<T>.Clear()
		{
			Clear();
		}

		bool ICollection<T>.Contains(T item)
		{
			return Contains(item);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0 || arrayIndex + Count > array.Length)
			{
				throw new ArgumentException("array is too small to hold the collection.");
			}
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				array[arrayIndex + i] = this[i];
			}
		}

		bool ICollection<T>.Remove(T item)
		{
			return Remove(item);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new xeVzDEFrngwPqkddInvlKOvcSVh(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new xeVzDEFrngwPqkddInvlKOvcSVh(this);
		}
	}
}
