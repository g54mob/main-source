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
		public struct TyrhuugmSxggytXVNBtwOKMUgHF : IDisposable, IEnumerator, IEnumerator<T>
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
					if (index == 0 || index == buffer.SDCgUCruwiFPrvEHpfWQvKptOso + 1)
					{
						throw new InvalidOperationException();
					}
					return Current;
				}
			}

			internal TyrhuugmSxggytXVNBtwOKMUgHF(RingBuffer<T> buffer)
			{
				this.buffer = buffer;
				index = 0;
				version = buffer.WanKbgUVFfRfzcocDOXjqNnCadr;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version == buffer.WanKbgUVFfRfzcocDOXjqNnCadr && (uint)index < (uint)buffer.SDCgUCruwiFPrvEHpfWQvKptOso)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return YvvuBxWKKlgqUoUosltdSSWHFyD();
			}

			private bool YvvuBxWKKlgqUoUosltdSSWHFyD()
			{
				if (version != buffer.WanKbgUVFfRfzcocDOXjqNnCadr)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.SDCgUCruwiFPrvEHpfWQvKptOso + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.WanKbgUVFfRfzcocDOXjqNnCadr)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] ekhDAugGrLfJMBjXfsQQeGdcIkDE;

		private readonly int doAsGrtKlisSXEPfwnlOTedRuDB;

		private int jCuMZvtmKDfLNZrZvEruiRzUTLA;

		private int PexsvKtBpBrAqJSgGUEWDVKJENY;

		private int SDCgUCruwiFPrvEHpfWQvKptOso;

		private int iVQRHPzPkQYkuiprOQaPSfCQzEI;

		private int WanKbgUVFfRfzcocDOXjqNnCadr;

		private IEqualityComparer<T> fUUbMusiMuKbhHxAApWLOvnRbdq = EqualityComparerNoAlloc<T>.Default;

		public int Count => SDCgUCruwiFPrvEHpfWQvKptOso;

		public int Capacity => doAsGrtKlisSXEPfwnlOTedRuDB;

		public int OverrunCount => iVQRHPzPkQYkuiprOQaPSfCQzEI;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return fUUbMusiMuKbhHxAApWLOvnRbdq;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				fUUbMusiMuKbhHxAApWLOvnRbdq = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = IxwrHhIMnwCHJdvJGLzdCmbJFqfb(index);
				if (!oCdIQirKsMgoZzqqMIkQoolDvVC(num))
				{
					throw new IndexOutOfRangeException();
				}
				return ekhDAugGrLfJMBjXfsQQeGdcIkDE[num];
			}
			set
			{
				int num = IxwrHhIMnwCHJdvJGLzdCmbJFqfb(index);
				if (!oCdIQirKsMgoZzqqMIkQoolDvVC(num))
				{
					throw new IndexOutOfRangeException();
				}
				ekhDAugGrLfJMBjXfsQQeGdcIkDE[num] = value;
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
			ekhDAugGrLfJMBjXfsQQeGdcIkDE = new T[capacity];
			doAsGrtKlisSXEPfwnlOTedRuDB = capacity;
			Clear();
		}

		public void Enqueue(T item)
		{
			jCuMZvtmKDfLNZrZvEruiRzUTLA = ((jCuMZvtmKDfLNZrZvEruiRzUTLA < doAsGrtKlisSXEPfwnlOTedRuDB - 1) ? (jCuMZvtmKDfLNZrZvEruiRzUTLA + 1) : 0);
			if (SDCgUCruwiFPrvEHpfWQvKptOso == 0)
			{
				PexsvKtBpBrAqJSgGUEWDVKJENY = 0;
			}
			else if (jCuMZvtmKDfLNZrZvEruiRzUTLA == PexsvKtBpBrAqJSgGUEWDVKJENY)
			{
				PexsvKtBpBrAqJSgGUEWDVKJENY = ((PexsvKtBpBrAqJSgGUEWDVKJENY < doAsGrtKlisSXEPfwnlOTedRuDB - 1) ? (PexsvKtBpBrAqJSgGUEWDVKJENY + 1) : 0);
				iVQRHPzPkQYkuiprOQaPSfCQzEI++;
			}
			ekhDAugGrLfJMBjXfsQQeGdcIkDE[jCuMZvtmKDfLNZrZvEruiRzUTLA] = item;
			if (SDCgUCruwiFPrvEHpfWQvKptOso < doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				SDCgUCruwiFPrvEHpfWQvKptOso++;
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
			if (SDCgUCruwiFPrvEHpfWQvKptOso == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = ekhDAugGrLfJMBjXfsQQeGdcIkDE[PexsvKtBpBrAqJSgGUEWDVKJENY];
			if (PexsvKtBpBrAqJSgGUEWDVKJENY == jCuMZvtmKDfLNZrZvEruiRzUTLA)
			{
				Clear();
			}
			else
			{
				ekhDAugGrLfJMBjXfsQQeGdcIkDE[PexsvKtBpBrAqJSgGUEWDVKJENY] = default(T);
				PexsvKtBpBrAqJSgGUEWDVKJENY = ((PexsvKtBpBrAqJSgGUEWDVKJENY < doAsGrtKlisSXEPfwnlOTedRuDB - 1) ? (PexsvKtBpBrAqJSgGUEWDVKJENY + 1) : 0);
				iVQRHPzPkQYkuiprOQaPSfCQzEI = 0;
				SDCgUCruwiFPrvEHpfWQvKptOso--;
				WanKbgUVFfRfzcocDOXjqNnCadr++;
			}
			return result;
		}

		public T Peek()
		{
			if (jCuMZvtmKDfLNZrZvEruiRzUTLA < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return ekhDAugGrLfJMBjXfsQQeGdcIkDE[PexsvKtBpBrAqJSgGUEWDVKJENY];
		}

		public bool Contains(T item)
		{
			return KEFQheJUicoOgSWtDXTORMtKCpV(item, fUUbMusiMuKbhHxAApWLOvnRbdq) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return KEFQheJUicoOgSWtDXTORMtKCpV(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, fUUbMusiMuKbhHxAApWLOvnRbdq);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return JMqprZohQVGYjRPIXlJCNiNNhVb(KEFQheJUicoOgSWtDXTORMtKCpV(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, fUUbMusiMuKbhHxAApWLOvnRbdq);
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
			int num = KEFQheJUicoOgSWtDXTORMtKCpV(item, comparer);
			if (num < 0)
			{
				return false;
			}
			aTnqeNiAaJNitzfwALyeARzDmhU(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			aTnqeNiAaJNitzfwALyeARzDmhU(IxwrHhIMnwCHJdvJGLzdCmbJFqfb(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, fUUbMusiMuKbhHxAApWLOvnRbdq);
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
			if (SDCgUCruwiFPrvEHpfWQvKptOso > 0)
			{
				if (jCuMZvtmKDfLNZrZvEruiRzUTLA >= PexsvKtBpBrAqJSgGUEWDVKJENY)
				{
					Array.Clear(ekhDAugGrLfJMBjXfsQQeGdcIkDE, PexsvKtBpBrAqJSgGUEWDVKJENY, jCuMZvtmKDfLNZrZvEruiRzUTLA - PexsvKtBpBrAqJSgGUEWDVKJENY + 1);
				}
				else
				{
					Array.Clear(ekhDAugGrLfJMBjXfsQQeGdcIkDE, 0, jCuMZvtmKDfLNZrZvEruiRzUTLA + 1);
					Array.Clear(ekhDAugGrLfJMBjXfsQQeGdcIkDE, PexsvKtBpBrAqJSgGUEWDVKJENY, doAsGrtKlisSXEPfwnlOTedRuDB - PexsvKtBpBrAqJSgGUEWDVKJENY);
				}
				SDCgUCruwiFPrvEHpfWQvKptOso = 0;
			}
			jCuMZvtmKDfLNZrZvEruiRzUTLA = -1;
			PexsvKtBpBrAqJSgGUEWDVKJENY = -1;
			iVQRHPzPkQYkuiprOQaPSfCQzEI = 0;
			WanKbgUVFfRfzcocDOXjqNnCadr++;
		}

		private int KEFQheJUicoOgSWtDXTORMtKCpV(T P_0)
		{
			return KEFQheJUicoOgSWtDXTORMtKCpV(P_0, fUUbMusiMuKbhHxAApWLOvnRbdq);
		}

		private int KEFQheJUicoOgSWtDXTORMtKCpV(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (SDCgUCruwiFPrvEHpfWQvKptOso == 0)
			{
				return -1;
			}
			if (jCuMZvtmKDfLNZrZvEruiRzUTLA >= PexsvKtBpBrAqJSgGUEWDVKJENY)
			{
				for (int i = PexsvKtBpBrAqJSgGUEWDVKJENY; i <= jCuMZvtmKDfLNZrZvEruiRzUTLA; i++)
				{
					if (P_1.Equals(ekhDAugGrLfJMBjXfsQQeGdcIkDE[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= jCuMZvtmKDfLNZrZvEruiRzUTLA; j++)
				{
					if (P_1.Equals(ekhDAugGrLfJMBjXfsQQeGdcIkDE[j], P_0))
					{
						return j;
					}
				}
				for (int k = PexsvKtBpBrAqJSgGUEWDVKJENY; k < doAsGrtKlisSXEPfwnlOTedRuDB; k++)
				{
					if (P_1.Equals(ekhDAugGrLfJMBjXfsQQeGdcIkDE[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void aTnqeNiAaJNitzfwALyeARzDmhU(int P_0)
		{
			if (!oCdIQirKsMgoZzqqMIkQoolDvVC(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == PexsvKtBpBrAqJSgGUEWDVKJENY)
			{
				Dequeue();
				return;
			}
			if (P_0 != jCuMZvtmKDfLNZrZvEruiRzUTLA)
			{
				if (jCuMZvtmKDfLNZrZvEruiRzUTLA > PexsvKtBpBrAqJSgGUEWDVKJENY)
				{
					Array.Copy(ekhDAugGrLfJMBjXfsQQeGdcIkDE, P_0 + 1, ekhDAugGrLfJMBjXfsQQeGdcIkDE, P_0, jCuMZvtmKDfLNZrZvEruiRzUTLA - P_0);
				}
				else if (P_0 < jCuMZvtmKDfLNZrZvEruiRzUTLA)
				{
					Array.Copy(ekhDAugGrLfJMBjXfsQQeGdcIkDE, P_0 + 1, ekhDAugGrLfJMBjXfsQQeGdcIkDE, P_0, jCuMZvtmKDfLNZrZvEruiRzUTLA - P_0);
				}
				else
				{
					Array.Copy(ekhDAugGrLfJMBjXfsQQeGdcIkDE, P_0 + 1, ekhDAugGrLfJMBjXfsQQeGdcIkDE, P_0, doAsGrtKlisSXEPfwnlOTedRuDB - P_0 - 1);
					ekhDAugGrLfJMBjXfsQQeGdcIkDE[doAsGrtKlisSXEPfwnlOTedRuDB - 1] = ekhDAugGrLfJMBjXfsQQeGdcIkDE[0];
					if (jCuMZvtmKDfLNZrZvEruiRzUTLA > 0)
					{
						Array.Copy(ekhDAugGrLfJMBjXfsQQeGdcIkDE, 1, ekhDAugGrLfJMBjXfsQQeGdcIkDE, 0, jCuMZvtmKDfLNZrZvEruiRzUTLA);
					}
				}
			}
			ekhDAugGrLfJMBjXfsQQeGdcIkDE[jCuMZvtmKDfLNZrZvEruiRzUTLA] = default(T);
			jCuMZvtmKDfLNZrZvEruiRzUTLA = ((jCuMZvtmKDfLNZrZvEruiRzUTLA > 0) ? (jCuMZvtmKDfLNZrZvEruiRzUTLA - 1) : (doAsGrtKlisSXEPfwnlOTedRuDB - 1));
			WanKbgUVFfRfzcocDOXjqNnCadr++;
			SDCgUCruwiFPrvEHpfWQvKptOso--;
		}

		private bool oCdIQirKsMgoZzqqMIkQoolDvVC(int P_0)
		{
			if (SDCgUCruwiFPrvEHpfWQvKptOso == 0)
			{
				return false;
			}
			if (jCuMZvtmKDfLNZrZvEruiRzUTLA >= PexsvKtBpBrAqJSgGUEWDVKJENY)
			{
				if (P_0 >= PexsvKtBpBrAqJSgGUEWDVKJENY)
				{
					return P_0 <= jCuMZvtmKDfLNZrZvEruiRzUTLA;
				}
				return false;
			}
			if (P_0 < PexsvKtBpBrAqJSgGUEWDVKJENY)
			{
				return P_0 <= jCuMZvtmKDfLNZrZvEruiRzUTLA;
			}
			return true;
		}

		private int JMqprZohQVGYjRPIXlJCNiNNhVb(int P_0)
		{
			if ((uint)P_0 >= (uint)doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				return -1;
			}
			if (!oCdIQirKsMgoZzqqMIkQoolDvVC(P_0))
			{
				return -1;
			}
			if (P_0 >= PexsvKtBpBrAqJSgGUEWDVKJENY)
			{
				return P_0 - PexsvKtBpBrAqJSgGUEWDVKJENY;
			}
			return P_0 + doAsGrtKlisSXEPfwnlOTedRuDB - PexsvKtBpBrAqJSgGUEWDVKJENY;
		}

		private int IxwrHhIMnwCHJdvJGLzdCmbJFqfb(int P_0)
		{
			if ((uint)P_0 >= (uint)SDCgUCruwiFPrvEHpfWQvKptOso)
			{
				return -1;
			}
			P_0 = PexsvKtBpBrAqJSgGUEWDVKJENY + P_0;
			if (P_0 >= doAsGrtKlisSXEPfwnlOTedRuDB)
			{
				P_0 -= doAsGrtKlisSXEPfwnlOTedRuDB;
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
			return new TyrhuugmSxggytXVNBtwOKMUgHF(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TyrhuugmSxggytXVNBtwOKMUgHF(this);
		}
	}
}
