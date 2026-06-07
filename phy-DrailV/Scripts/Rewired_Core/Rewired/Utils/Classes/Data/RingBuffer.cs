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
		public struct ofNtJNJePZdEfjxvJZGWnLxFXRTl : IDisposable, IEnumerator, IEnumerator<T>
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
					if (index == 0 || index == buffer.dPaZjxYVpAOrsrCjtxboEyCaVuap + 1)
					{
						throw new InvalidOperationException();
					}
					return Current;
				}
			}

			internal ofNtJNJePZdEfjxvJZGWnLxFXRTl(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.dxTsCFpBKFlPomOIZacJFoWJetjo;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version == buffer.dxTsCFpBKFlPomOIZacJFoWJetjo && (uint)index < (uint)buffer.dPaZjxYVpAOrsrCjtxboEyCaVuap)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return veXIwWfQFZwULylAorGDfSnMesJK();
			}

			private bool veXIwWfQFZwULylAorGDfSnMesJK()
			{
				if (version != buffer.dxTsCFpBKFlPomOIZacJFoWJetjo)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.dPaZjxYVpAOrsrCjtxboEyCaVuap + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.dxTsCFpBKFlPomOIZacJFoWJetjo)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] NcVtbHdbgpPzNzjvietqfHGVBgGy;

		private readonly int WjcVbvWkFCKGROUlyUKFoxBEwNHJ;

		private int AKGveMWDXjfjOdFllgGYuNIByHWmA;

		private int stTXhjAkEpVpvNAcEhbcqtkGEBKe;

		private int dPaZjxYVpAOrsrCjtxboEyCaVuap;

		private int NQaCgkEExqyYnhaHWDHlhbnaFMCLb;

		private int dxTsCFpBKFlPomOIZacJFoWJetjo;

		private IEqualityComparer<T> YRkdAFJchOMqoJAHSoKvreOCYbop = EqualityComparerNoAlloc<T>.Default;

		public int Count => dPaZjxYVpAOrsrCjtxboEyCaVuap;

		public int Capacity => WjcVbvWkFCKGROUlyUKFoxBEwNHJ;

		public int OverrunCount => NQaCgkEExqyYnhaHWDHlhbnaFMCLb;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return YRkdAFJchOMqoJAHSoKvreOCYbop;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				YRkdAFJchOMqoJAHSoKvreOCYbop = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = hRUCgGexkURjOnnnOIONqVMMQmznA(index);
				if (!ZuZunXEyriREYnmYWrNoHZGQpBOq(num))
				{
					throw new IndexOutOfRangeException();
				}
				return NcVtbHdbgpPzNzjvietqfHGVBgGy[num];
			}
			set
			{
				int num = hRUCgGexkURjOnnnOIONqVMMQmznA(index);
				if (!ZuZunXEyriREYnmYWrNoHZGQpBOq(num))
				{
					throw new IndexOutOfRangeException();
				}
				NcVtbHdbgpPzNzjvietqfHGVBgGy[num] = value;
			}
		}

		int ICollection<T>.Count => Count;

		bool ICollection<T>.IsReadOnly => false;

		public RingBuffer(int P_0)
		{
			if (P_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("capacity must be > 0.");
			}
			NcVtbHdbgpPzNzjvietqfHGVBgGy = new T[P_0];
			WjcVbvWkFCKGROUlyUKFoxBEwNHJ = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			AKGveMWDXjfjOdFllgGYuNIByHWmA = ((AKGveMWDXjfjOdFllgGYuNIByHWmA < WjcVbvWkFCKGROUlyUKFoxBEwNHJ - 1) ? (AKGveMWDXjfjOdFllgGYuNIByHWmA + 1) : 0);
			if (dPaZjxYVpAOrsrCjtxboEyCaVuap == 0)
			{
				stTXhjAkEpVpvNAcEhbcqtkGEBKe = 0;
			}
			else if (AKGveMWDXjfjOdFllgGYuNIByHWmA == stTXhjAkEpVpvNAcEhbcqtkGEBKe)
			{
				stTXhjAkEpVpvNAcEhbcqtkGEBKe = ((stTXhjAkEpVpvNAcEhbcqtkGEBKe < WjcVbvWkFCKGROUlyUKFoxBEwNHJ - 1) ? (stTXhjAkEpVpvNAcEhbcqtkGEBKe + 1) : 0);
				NQaCgkEExqyYnhaHWDHlhbnaFMCLb++;
			}
			NcVtbHdbgpPzNzjvietqfHGVBgGy[AKGveMWDXjfjOdFllgGYuNIByHWmA] = item;
			if (dPaZjxYVpAOrsrCjtxboEyCaVuap < WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				dPaZjxYVpAOrsrCjtxboEyCaVuap++;
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
			if (dPaZjxYVpAOrsrCjtxboEyCaVuap == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = NcVtbHdbgpPzNzjvietqfHGVBgGy[stTXhjAkEpVpvNAcEhbcqtkGEBKe];
			if (stTXhjAkEpVpvNAcEhbcqtkGEBKe == AKGveMWDXjfjOdFllgGYuNIByHWmA)
			{
				Clear();
				return result;
			}
			NcVtbHdbgpPzNzjvietqfHGVBgGy[stTXhjAkEpVpvNAcEhbcqtkGEBKe] = default(T);
			stTXhjAkEpVpvNAcEhbcqtkGEBKe = ((stTXhjAkEpVpvNAcEhbcqtkGEBKe < WjcVbvWkFCKGROUlyUKFoxBEwNHJ - 1) ? (stTXhjAkEpVpvNAcEhbcqtkGEBKe + 1) : 0);
			NQaCgkEExqyYnhaHWDHlhbnaFMCLb = 0;
			dPaZjxYVpAOrsrCjtxboEyCaVuap--;
			dxTsCFpBKFlPomOIZacJFoWJetjo++;
			return result;
		}

		public T Peek()
		{
			if (AKGveMWDXjfjOdFllgGYuNIByHWmA < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return NcVtbHdbgpPzNzjvietqfHGVBgGy[stTXhjAkEpVpvNAcEhbcqtkGEBKe];
		}

		public bool Contains(T item)
		{
			return tSlrNJaxCrCzIYBFJeegwOqLSTWb(item, YRkdAFJchOMqoJAHSoKvreOCYbop) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return tSlrNJaxCrCzIYBFJeegwOqLSTWb(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, YRkdAFJchOMqoJAHSoKvreOCYbop);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return epiUWAXugcgYDLNzQUubqhPQhIBf(tSlrNJaxCrCzIYBFJeegwOqLSTWb(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, YRkdAFJchOMqoJAHSoKvreOCYbop);
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
			int num = tSlrNJaxCrCzIYBFJeegwOqLSTWb(item, comparer);
			if (num < 0)
			{
				return false;
			}
			LzDBDqkDfrlKyAtKULZKRfWYydCwA(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			LzDBDqkDfrlKyAtKULZKRfWYydCwA(hRUCgGexkURjOnnnOIONqVMMQmznA(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, YRkdAFJchOMqoJAHSoKvreOCYbop);
		}

		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			int num = 0;
			for (int num2 = Count - 1; num2 >= 0; num2--)
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
			if (dPaZjxYVpAOrsrCjtxboEyCaVuap > 0)
			{
				if (AKGveMWDXjfjOdFllgGYuNIByHWmA >= stTXhjAkEpVpvNAcEhbcqtkGEBKe)
				{
					Array.Clear(NcVtbHdbgpPzNzjvietqfHGVBgGy, stTXhjAkEpVpvNAcEhbcqtkGEBKe, AKGveMWDXjfjOdFllgGYuNIByHWmA - stTXhjAkEpVpvNAcEhbcqtkGEBKe + 1);
				}
				else
				{
					Array.Clear(NcVtbHdbgpPzNzjvietqfHGVBgGy, 0, AKGveMWDXjfjOdFllgGYuNIByHWmA + 1);
					Array.Clear(NcVtbHdbgpPzNzjvietqfHGVBgGy, stTXhjAkEpVpvNAcEhbcqtkGEBKe, WjcVbvWkFCKGROUlyUKFoxBEwNHJ - stTXhjAkEpVpvNAcEhbcqtkGEBKe);
				}
				dPaZjxYVpAOrsrCjtxboEyCaVuap = 0;
			}
			AKGveMWDXjfjOdFllgGYuNIByHWmA = -1;
			stTXhjAkEpVpvNAcEhbcqtkGEBKe = -1;
			NQaCgkEExqyYnhaHWDHlhbnaFMCLb = 0;
			dxTsCFpBKFlPomOIZacJFoWJetjo++;
		}

		private int tSlrNJaxCrCzIYBFJeegwOqLSTWb(T P_0)
		{
			return tSlrNJaxCrCzIYBFJeegwOqLSTWb(P_0, YRkdAFJchOMqoJAHSoKvreOCYbop);
		}

		private int tSlrNJaxCrCzIYBFJeegwOqLSTWb(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (dPaZjxYVpAOrsrCjtxboEyCaVuap == 0)
			{
				return -1;
			}
			if (AKGveMWDXjfjOdFllgGYuNIByHWmA >= stTXhjAkEpVpvNAcEhbcqtkGEBKe)
			{
				for (int i = stTXhjAkEpVpvNAcEhbcqtkGEBKe; i <= AKGveMWDXjfjOdFllgGYuNIByHWmA; i++)
				{
					if (P_1.Equals(NcVtbHdbgpPzNzjvietqfHGVBgGy[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= AKGveMWDXjfjOdFllgGYuNIByHWmA; j++)
				{
					if (P_1.Equals(NcVtbHdbgpPzNzjvietqfHGVBgGy[j], P_0))
					{
						return j;
					}
				}
				for (int k = stTXhjAkEpVpvNAcEhbcqtkGEBKe; k < WjcVbvWkFCKGROUlyUKFoxBEwNHJ; k++)
				{
					if (P_1.Equals(NcVtbHdbgpPzNzjvietqfHGVBgGy[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void LzDBDqkDfrlKyAtKULZKRfWYydCwA(int P_0)
		{
			if (!ZuZunXEyriREYnmYWrNoHZGQpBOq(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == stTXhjAkEpVpvNAcEhbcqtkGEBKe)
			{
				Dequeue();
				return;
			}
			if (P_0 != AKGveMWDXjfjOdFllgGYuNIByHWmA)
			{
				if (AKGveMWDXjfjOdFllgGYuNIByHWmA > stTXhjAkEpVpvNAcEhbcqtkGEBKe)
				{
					Array.Copy(NcVtbHdbgpPzNzjvietqfHGVBgGy, P_0 + 1, NcVtbHdbgpPzNzjvietqfHGVBgGy, P_0, AKGveMWDXjfjOdFllgGYuNIByHWmA - P_0);
				}
				else if (P_0 < AKGveMWDXjfjOdFllgGYuNIByHWmA)
				{
					Array.Copy(NcVtbHdbgpPzNzjvietqfHGVBgGy, P_0 + 1, NcVtbHdbgpPzNzjvietqfHGVBgGy, P_0, AKGveMWDXjfjOdFllgGYuNIByHWmA - P_0);
				}
				else
				{
					Array.Copy(NcVtbHdbgpPzNzjvietqfHGVBgGy, P_0 + 1, NcVtbHdbgpPzNzjvietqfHGVBgGy, P_0, WjcVbvWkFCKGROUlyUKFoxBEwNHJ - P_0 - 1);
					NcVtbHdbgpPzNzjvietqfHGVBgGy[WjcVbvWkFCKGROUlyUKFoxBEwNHJ - 1] = NcVtbHdbgpPzNzjvietqfHGVBgGy[0];
					if (AKGveMWDXjfjOdFllgGYuNIByHWmA > 0)
					{
						Array.Copy(NcVtbHdbgpPzNzjvietqfHGVBgGy, 1, NcVtbHdbgpPzNzjvietqfHGVBgGy, 0, AKGveMWDXjfjOdFllgGYuNIByHWmA);
					}
				}
			}
			NcVtbHdbgpPzNzjvietqfHGVBgGy[AKGveMWDXjfjOdFllgGYuNIByHWmA] = default(T);
			AKGveMWDXjfjOdFllgGYuNIByHWmA = ((AKGveMWDXjfjOdFllgGYuNIByHWmA > 0) ? (AKGveMWDXjfjOdFllgGYuNIByHWmA - 1) : (WjcVbvWkFCKGROUlyUKFoxBEwNHJ - 1));
			dxTsCFpBKFlPomOIZacJFoWJetjo++;
			dPaZjxYVpAOrsrCjtxboEyCaVuap--;
		}

		private bool ZuZunXEyriREYnmYWrNoHZGQpBOq(int P_0)
		{
			if (dPaZjxYVpAOrsrCjtxboEyCaVuap == 0)
			{
				return false;
			}
			if (AKGveMWDXjfjOdFllgGYuNIByHWmA >= stTXhjAkEpVpvNAcEhbcqtkGEBKe)
			{
				if (P_0 >= stTXhjAkEpVpvNAcEhbcqtkGEBKe)
				{
					return P_0 <= AKGveMWDXjfjOdFllgGYuNIByHWmA;
				}
				return false;
			}
			if (P_0 < stTXhjAkEpVpvNAcEhbcqtkGEBKe)
			{
				return P_0 <= AKGveMWDXjfjOdFllgGYuNIByHWmA;
			}
			return true;
		}

		private int epiUWAXugcgYDLNzQUubqhPQhIBf(int P_0)
		{
			if ((uint)P_0 >= (uint)WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				return -1;
			}
			if (!ZuZunXEyriREYnmYWrNoHZGQpBOq(P_0))
			{
				return -1;
			}
			if (P_0 >= stTXhjAkEpVpvNAcEhbcqtkGEBKe)
			{
				return P_0 - stTXhjAkEpVpvNAcEhbcqtkGEBKe;
			}
			return P_0 + WjcVbvWkFCKGROUlyUKFoxBEwNHJ - stTXhjAkEpVpvNAcEhbcqtkGEBKe;
		}

		private int hRUCgGexkURjOnnnOIONqVMMQmznA(int P_0)
		{
			if ((uint)P_0 >= (uint)dPaZjxYVpAOrsrCjtxboEyCaVuap)
			{
				return -1;
			}
			P_0 = stTXhjAkEpVpvNAcEhbcqtkGEBKe + P_0;
			if (P_0 >= WjcVbvWkFCKGROUlyUKFoxBEwNHJ)
			{
				P_0 -= WjcVbvWkFCKGROUlyUKFoxBEwNHJ;
			}
			return P_0;
		}

		void ICollection<T>.Add(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Clear()
		{
			Clear();
		}

		bool ICollection<T>.Contains(T P_0)
		{
			return Contains(P_0);
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (P_1 < 0 || P_1 + Count > P_0.Length)
			{
				throw new ArgumentException("array is too small to hold the collection.");
			}
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				P_0[P_1 + i] = this[i];
			}
		}

		bool ICollection<T>.Remove(T P_0)
		{
			return Remove(P_0);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new ofNtJNJePZdEfjxvJZGWnLxFXRTl(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ofNtJNJePZdEfjxvJZGWnLxFXRTl(this);
		}
	}
}
