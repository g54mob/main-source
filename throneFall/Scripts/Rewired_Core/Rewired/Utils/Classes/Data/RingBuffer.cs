using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class RingBuffer<T> : ICollection<T>, IEnumerable<T>, IEnumerable
	{
		[Serializable]
		public struct WXPnnKswXtkyAPSpNnSssWARPETO : IEnumerator<T>, IEnumerator, IDisposable
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			T IEnumerator<T>.Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == buffer.rrNqBLtvAyLUyhnomBTTLxijlvDB + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal WXPnnKswXtkyAPSpNnSssWARPETO(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.LXXkJxFeieIAfHXqxJFZcPvyqrJOA;
				current = default(T);
			}

			public void Dispose()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			public bool MoveNext()
			{
				if (version == buffer.LXXkJxFeieIAfHXqxJFZcPvyqrJOA && (uint)index < (uint)buffer.rrNqBLtvAyLUyhnomBTTLxijlvDB)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return CGMGDvEWNnOAxAtpSQWuYHYPDWqdA();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool CGMGDvEWNnOAxAtpSQWuYHYPDWqdA()
			{
				if (version != buffer.LXXkJxFeieIAfHXqxJFZcPvyqrJOA)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.rrNqBLtvAyLUyhnomBTTLxijlvDB + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.LXXkJxFeieIAfHXqxJFZcPvyqrJOA)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] xsuUaVOjzgiOrSpwsmUDppfRNvtj;

		private readonly int BMmJfzwbZyxKicMQxYBjrQSLpDYm;

		private int VtUzKaheHFrxSxIvNlNCCvuecUSU;

		private int tPsmbegrJnREWTofbGCiDqQHmYjb;

		private int rrNqBLtvAyLUyhnomBTTLxijlvDB;

		private int ZpiLwYWGKFpnzgjqClEFIgUfohxc;

		private int LXXkJxFeieIAfHXqxJFZcPvyqrJOA;

		private IEqualityComparer<T> yCWeFcaQfKRkKElqRRyZHIvwkPWx = EqualityComparerNoAlloc<T>.Default;

		public int Count => rrNqBLtvAyLUyhnomBTTLxijlvDB;

		public int Capacity => BMmJfzwbZyxKicMQxYBjrQSLpDYm;

		public int OverrunCount => ZpiLwYWGKFpnzgjqClEFIgUfohxc;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return yCWeFcaQfKRkKElqRRyZHIvwkPWx;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				yCWeFcaQfKRkKElqRRyZHIvwkPWx = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = TPbmUFoHYqmGDorkjyKWUsGRVFer(index);
				if (!awwMHyJrNbWufTfNpvnqNebVWIfv(num))
				{
					throw new IndexOutOfRangeException();
				}
				return xsuUaVOjzgiOrSpwsmUDppfRNvtj[num];
			}
			set
			{
				int num = TPbmUFoHYqmGDorkjyKWUsGRVFer(index);
				if (!awwMHyJrNbWufTfNpvnqNebVWIfv(num))
				{
					throw new IndexOutOfRangeException();
				}
				xsuUaVOjzgiOrSpwsmUDppfRNvtj[num] = value;
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
			xsuUaVOjzgiOrSpwsmUDppfRNvtj = new T[P_0];
			BMmJfzwbZyxKicMQxYBjrQSLpDYm = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			VtUzKaheHFrxSxIvNlNCCvuecUSU = ((VtUzKaheHFrxSxIvNlNCCvuecUSU < BMmJfzwbZyxKicMQxYBjrQSLpDYm - 1) ? (VtUzKaheHFrxSxIvNlNCCvuecUSU + 1) : 0);
			if (rrNqBLtvAyLUyhnomBTTLxijlvDB == 0)
			{
				tPsmbegrJnREWTofbGCiDqQHmYjb = 0;
			}
			else if (VtUzKaheHFrxSxIvNlNCCvuecUSU == tPsmbegrJnREWTofbGCiDqQHmYjb)
			{
				tPsmbegrJnREWTofbGCiDqQHmYjb = ((tPsmbegrJnREWTofbGCiDqQHmYjb < BMmJfzwbZyxKicMQxYBjrQSLpDYm - 1) ? (tPsmbegrJnREWTofbGCiDqQHmYjb + 1) : 0);
				ZpiLwYWGKFpnzgjqClEFIgUfohxc++;
			}
			xsuUaVOjzgiOrSpwsmUDppfRNvtj[VtUzKaheHFrxSxIvNlNCCvuecUSU] = item;
			if (rrNqBLtvAyLUyhnomBTTLxijlvDB < BMmJfzwbZyxKicMQxYBjrQSLpDYm)
			{
				rrNqBLtvAyLUyhnomBTTLxijlvDB++;
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
			if (rrNqBLtvAyLUyhnomBTTLxijlvDB == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = xsuUaVOjzgiOrSpwsmUDppfRNvtj[tPsmbegrJnREWTofbGCiDqQHmYjb];
			if (tPsmbegrJnREWTofbGCiDqQHmYjb == VtUzKaheHFrxSxIvNlNCCvuecUSU)
			{
				Clear();
				return result;
			}
			xsuUaVOjzgiOrSpwsmUDppfRNvtj[tPsmbegrJnREWTofbGCiDqQHmYjb] = default(T);
			tPsmbegrJnREWTofbGCiDqQHmYjb = ((tPsmbegrJnREWTofbGCiDqQHmYjb < BMmJfzwbZyxKicMQxYBjrQSLpDYm - 1) ? (tPsmbegrJnREWTofbGCiDqQHmYjb + 1) : 0);
			ZpiLwYWGKFpnzgjqClEFIgUfohxc = 0;
			rrNqBLtvAyLUyhnomBTTLxijlvDB--;
			LXXkJxFeieIAfHXqxJFZcPvyqrJOA++;
			return result;
		}

		public T Peek()
		{
			if (VtUzKaheHFrxSxIvNlNCCvuecUSU < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return xsuUaVOjzgiOrSpwsmUDppfRNvtj[tPsmbegrJnREWTofbGCiDqQHmYjb];
		}

		public bool Contains(T item)
		{
			return MywHScMoTbZlHqpKErGHfGQEkzde(item, yCWeFcaQfKRkKElqRRyZHIvwkPWx) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return MywHScMoTbZlHqpKErGHfGQEkzde(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, yCWeFcaQfKRkKElqRRyZHIvwkPWx);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return LibkmYrGSmbXAKZablUkSNNUqjyc(MywHScMoTbZlHqpKErGHfGQEkzde(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, yCWeFcaQfKRkKElqRRyZHIvwkPWx);
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
			int num = MywHScMoTbZlHqpKErGHfGQEkzde(item, comparer);
			if (num < 0)
			{
				return false;
			}
			akpXxTdtXVAYTsOiOyjoeRvIxTqg(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			akpXxTdtXVAYTsOiOyjoeRvIxTqg(TPbmUFoHYqmGDorkjyKWUsGRVFer(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, yCWeFcaQfKRkKElqRRyZHIvwkPWx);
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
			if (rrNqBLtvAyLUyhnomBTTLxijlvDB > 0)
			{
				if (VtUzKaheHFrxSxIvNlNCCvuecUSU >= tPsmbegrJnREWTofbGCiDqQHmYjb)
				{
					Array.Clear(xsuUaVOjzgiOrSpwsmUDppfRNvtj, tPsmbegrJnREWTofbGCiDqQHmYjb, VtUzKaheHFrxSxIvNlNCCvuecUSU - tPsmbegrJnREWTofbGCiDqQHmYjb + 1);
				}
				else
				{
					Array.Clear(xsuUaVOjzgiOrSpwsmUDppfRNvtj, 0, VtUzKaheHFrxSxIvNlNCCvuecUSU + 1);
					Array.Clear(xsuUaVOjzgiOrSpwsmUDppfRNvtj, tPsmbegrJnREWTofbGCiDqQHmYjb, BMmJfzwbZyxKicMQxYBjrQSLpDYm - tPsmbegrJnREWTofbGCiDqQHmYjb);
				}
				rrNqBLtvAyLUyhnomBTTLxijlvDB = 0;
			}
			VtUzKaheHFrxSxIvNlNCCvuecUSU = -1;
			tPsmbegrJnREWTofbGCiDqQHmYjb = -1;
			ZpiLwYWGKFpnzgjqClEFIgUfohxc = 0;
			LXXkJxFeieIAfHXqxJFZcPvyqrJOA++;
		}

		private int CheTVxXagLCfXlLGzYrHlRPgvenV(T P_0)
		{
			return MywHScMoTbZlHqpKErGHfGQEkzde(P_0, yCWeFcaQfKRkKElqRRyZHIvwkPWx);
		}

		private int MywHScMoTbZlHqpKErGHfGQEkzde(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (rrNqBLtvAyLUyhnomBTTLxijlvDB == 0)
			{
				return -1;
			}
			if (VtUzKaheHFrxSxIvNlNCCvuecUSU >= tPsmbegrJnREWTofbGCiDqQHmYjb)
			{
				for (int i = tPsmbegrJnREWTofbGCiDqQHmYjb; i <= VtUzKaheHFrxSxIvNlNCCvuecUSU; i++)
				{
					if (P_1.Equals(xsuUaVOjzgiOrSpwsmUDppfRNvtj[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= VtUzKaheHFrxSxIvNlNCCvuecUSU; j++)
				{
					if (P_1.Equals(xsuUaVOjzgiOrSpwsmUDppfRNvtj[j], P_0))
					{
						return j;
					}
				}
				for (int k = tPsmbegrJnREWTofbGCiDqQHmYjb; k < BMmJfzwbZyxKicMQxYBjrQSLpDYm; k++)
				{
					if (P_1.Equals(xsuUaVOjzgiOrSpwsmUDppfRNvtj[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void akpXxTdtXVAYTsOiOyjoeRvIxTqg(int P_0)
		{
			if (!awwMHyJrNbWufTfNpvnqNebVWIfv(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == tPsmbegrJnREWTofbGCiDqQHmYjb)
			{
				Dequeue();
				return;
			}
			if (P_0 != VtUzKaheHFrxSxIvNlNCCvuecUSU)
			{
				if (VtUzKaheHFrxSxIvNlNCCvuecUSU > tPsmbegrJnREWTofbGCiDqQHmYjb)
				{
					Array.Copy(xsuUaVOjzgiOrSpwsmUDppfRNvtj, P_0 + 1, xsuUaVOjzgiOrSpwsmUDppfRNvtj, P_0, VtUzKaheHFrxSxIvNlNCCvuecUSU - P_0);
				}
				else if (P_0 < VtUzKaheHFrxSxIvNlNCCvuecUSU)
				{
					Array.Copy(xsuUaVOjzgiOrSpwsmUDppfRNvtj, P_0 + 1, xsuUaVOjzgiOrSpwsmUDppfRNvtj, P_0, VtUzKaheHFrxSxIvNlNCCvuecUSU - P_0);
				}
				else
				{
					Array.Copy(xsuUaVOjzgiOrSpwsmUDppfRNvtj, P_0 + 1, xsuUaVOjzgiOrSpwsmUDppfRNvtj, P_0, BMmJfzwbZyxKicMQxYBjrQSLpDYm - P_0 - 1);
					xsuUaVOjzgiOrSpwsmUDppfRNvtj[BMmJfzwbZyxKicMQxYBjrQSLpDYm - 1] = xsuUaVOjzgiOrSpwsmUDppfRNvtj[0];
					if (VtUzKaheHFrxSxIvNlNCCvuecUSU > 0)
					{
						Array.Copy(xsuUaVOjzgiOrSpwsmUDppfRNvtj, 1, xsuUaVOjzgiOrSpwsmUDppfRNvtj, 0, VtUzKaheHFrxSxIvNlNCCvuecUSU);
					}
				}
			}
			xsuUaVOjzgiOrSpwsmUDppfRNvtj[VtUzKaheHFrxSxIvNlNCCvuecUSU] = default(T);
			VtUzKaheHFrxSxIvNlNCCvuecUSU = ((VtUzKaheHFrxSxIvNlNCCvuecUSU > 0) ? (VtUzKaheHFrxSxIvNlNCCvuecUSU - 1) : (BMmJfzwbZyxKicMQxYBjrQSLpDYm - 1));
			LXXkJxFeieIAfHXqxJFZcPvyqrJOA++;
			rrNqBLtvAyLUyhnomBTTLxijlvDB--;
		}

		private bool awwMHyJrNbWufTfNpvnqNebVWIfv(int P_0)
		{
			if (rrNqBLtvAyLUyhnomBTTLxijlvDB == 0)
			{
				return false;
			}
			if (VtUzKaheHFrxSxIvNlNCCvuecUSU >= tPsmbegrJnREWTofbGCiDqQHmYjb)
			{
				if (P_0 >= tPsmbegrJnREWTofbGCiDqQHmYjb)
				{
					return P_0 <= VtUzKaheHFrxSxIvNlNCCvuecUSU;
				}
				return false;
			}
			if (P_0 < tPsmbegrJnREWTofbGCiDqQHmYjb)
			{
				return P_0 <= VtUzKaheHFrxSxIvNlNCCvuecUSU;
			}
			return true;
		}

		private int LibkmYrGSmbXAKZablUkSNNUqjyc(int P_0)
		{
			if ((uint)P_0 >= (uint)BMmJfzwbZyxKicMQxYBjrQSLpDYm)
			{
				return -1;
			}
			if (!awwMHyJrNbWufTfNpvnqNebVWIfv(P_0))
			{
				return -1;
			}
			if (P_0 >= tPsmbegrJnREWTofbGCiDqQHmYjb)
			{
				return P_0 - tPsmbegrJnREWTofbGCiDqQHmYjb;
			}
			return P_0 + BMmJfzwbZyxKicMQxYBjrQSLpDYm - tPsmbegrJnREWTofbGCiDqQHmYjb;
		}

		private int TPbmUFoHYqmGDorkjyKWUsGRVFer(int P_0)
		{
			if ((uint)P_0 >= (uint)rrNqBLtvAyLUyhnomBTTLxijlvDB)
			{
				return -1;
			}
			P_0 = tPsmbegrJnREWTofbGCiDqQHmYjb + P_0;
			if (P_0 >= BMmJfzwbZyxKicMQxYBjrQSLpDYm)
			{
				P_0 -= BMmJfzwbZyxKicMQxYBjrQSLpDYm;
			}
			return P_0;
		}

		private void RSfeNSkDnCImAvjCbRzqhlnwStImA(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RSfeNSkDnCImAvjCbRzqhlnwStImA
			this.RSfeNSkDnCImAvjCbRzqhlnwStImA(P_0);
		}

		private void nXnvTVEdjJuwQsWpXsRXxeZZGKFK()
		{
			Clear();
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in nXnvTVEdjJuwQsWpXsRXxeZZGKFK
			this.nXnvTVEdjJuwQsWpXsRXxeZZGKFK();
		}

		private bool zXBFVypLaEWDbloVLwfLbAZpZkDS(T P_0)
		{
			return Contains(P_0);
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zXBFVypLaEWDbloVLwfLbAZpZkDS
			return this.zXBFVypLaEWDbloVLwfLbAZpZkDS(P_0);
		}

		private void PtRmkqezVPXKCKXvomUkihpsGErG(T[] P_0, int P_1)
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

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in PtRmkqezVPXKCKXvomUkihpsGErG
			this.PtRmkqezVPXKCKXvomUkihpsGErG(P_0, P_1);
		}

		private bool WXfeWpwTOHbsoKqtkHDHSEVudclzA(T P_0)
		{
			return Remove(P_0);
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in WXfeWpwTOHbsoKqtkHDHSEVudclzA
			return this.WXfeWpwTOHbsoKqtkHDHSEVudclzA(P_0);
		}

		private IEnumerator<T> ZfwjcVIPgyOLUYHjDDOzHBaLLZLwA()
		{
			return new WXPnnKswXtkyAPSpNnSssWARPETO(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZfwjcVIPgyOLUYHjDDOzHBaLLZLwA
			return this.ZfwjcVIPgyOLUYHjDDOzHBaLLZLwA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new WXPnnKswXtkyAPSpNnSssWARPETO(this);
		}
	}
}
