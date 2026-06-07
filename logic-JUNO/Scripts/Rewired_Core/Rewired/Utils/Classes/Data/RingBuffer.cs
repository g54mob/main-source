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
		public struct bPdIYGavMWkElWqkkeTwhRaguwBH : IEnumerator<T>, IEnumerator, IDisposable
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
					if (index == 0 || index == buffer.YNvbZPxSgZGZbDokLtlFFSXOFZtXA + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal bPdIYGavMWkElWqkkeTwhRaguwBH(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.kodsxtNXdZWAKAFdEirXWNXTXNFl;
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
				if (version == buffer.kodsxtNXdZWAKAFdEirXWNXTXNFl && (uint)index < (uint)buffer.YNvbZPxSgZGZbDokLtlFFSXOFZtXA)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return xkLchQMAKOYKwgqztskCDyaxemKA();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool xkLchQMAKOYKwgqztskCDyaxemKA()
			{
				if (version != buffer.kodsxtNXdZWAKAFdEirXWNXTXNFl)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.YNvbZPxSgZGZbDokLtlFFSXOFZtXA + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.kodsxtNXdZWAKAFdEirXWNXTXNFl)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] GBWRbPYpoTgyEDBzLwEVrmXcJznuA;

		private readonly int ebAIUroZIVQLRzIHQfUrqMmotLEH;

		private int qYgboybQCytrruilwlhEFIULgGID;

		private int YkxELrFwosvRnLZnQuwYgWQvOYQPA;

		private int YNvbZPxSgZGZbDokLtlFFSXOFZtXA;

		private int aJSXwSKJLsNpWzIobYLDHvSWCOlX;

		private int kodsxtNXdZWAKAFdEirXWNXTXNFl;

		private IEqualityComparer<T> NjqigiumohnmnFGzcjUPOMBThfOEA = EqualityComparerNoAlloc<T>.Default;

		public int Count => YNvbZPxSgZGZbDokLtlFFSXOFZtXA;

		public int Capacity => ebAIUroZIVQLRzIHQfUrqMmotLEH;

		public int OverrunCount => aJSXwSKJLsNpWzIobYLDHvSWCOlX;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return NjqigiumohnmnFGzcjUPOMBThfOEA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				NjqigiumohnmnFGzcjUPOMBThfOEA = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = mDRvCPoxZBWfunqnEwbOFiawavcw(index);
				if (!BCUcyuDmAEsaWQgWYCXoWJBkbalq(num))
				{
					throw new IndexOutOfRangeException();
				}
				return GBWRbPYpoTgyEDBzLwEVrmXcJznuA[num];
			}
			set
			{
				int num = mDRvCPoxZBWfunqnEwbOFiawavcw(index);
				if (!BCUcyuDmAEsaWQgWYCXoWJBkbalq(num))
				{
					throw new IndexOutOfRangeException();
				}
				GBWRbPYpoTgyEDBzLwEVrmXcJznuA[num] = value;
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
			GBWRbPYpoTgyEDBzLwEVrmXcJznuA = new T[P_0];
			ebAIUroZIVQLRzIHQfUrqMmotLEH = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			qYgboybQCytrruilwlhEFIULgGID = ((qYgboybQCytrruilwlhEFIULgGID < ebAIUroZIVQLRzIHQfUrqMmotLEH - 1) ? (qYgboybQCytrruilwlhEFIULgGID + 1) : 0);
			if (YNvbZPxSgZGZbDokLtlFFSXOFZtXA == 0)
			{
				YkxELrFwosvRnLZnQuwYgWQvOYQPA = 0;
			}
			else if (qYgboybQCytrruilwlhEFIULgGID == YkxELrFwosvRnLZnQuwYgWQvOYQPA)
			{
				YkxELrFwosvRnLZnQuwYgWQvOYQPA = ((YkxELrFwosvRnLZnQuwYgWQvOYQPA < ebAIUroZIVQLRzIHQfUrqMmotLEH - 1) ? (YkxELrFwosvRnLZnQuwYgWQvOYQPA + 1) : 0);
				aJSXwSKJLsNpWzIobYLDHvSWCOlX++;
			}
			GBWRbPYpoTgyEDBzLwEVrmXcJznuA[qYgboybQCytrruilwlhEFIULgGID] = item;
			if (YNvbZPxSgZGZbDokLtlFFSXOFZtXA < ebAIUroZIVQLRzIHQfUrqMmotLEH)
			{
				YNvbZPxSgZGZbDokLtlFFSXOFZtXA++;
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
			if (YNvbZPxSgZGZbDokLtlFFSXOFZtXA == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = GBWRbPYpoTgyEDBzLwEVrmXcJznuA[YkxELrFwosvRnLZnQuwYgWQvOYQPA];
			if (YkxELrFwosvRnLZnQuwYgWQvOYQPA == qYgboybQCytrruilwlhEFIULgGID)
			{
				Clear();
				return result;
			}
			GBWRbPYpoTgyEDBzLwEVrmXcJznuA[YkxELrFwosvRnLZnQuwYgWQvOYQPA] = default(T);
			YkxELrFwosvRnLZnQuwYgWQvOYQPA = ((YkxELrFwosvRnLZnQuwYgWQvOYQPA < ebAIUroZIVQLRzIHQfUrqMmotLEH - 1) ? (YkxELrFwosvRnLZnQuwYgWQvOYQPA + 1) : 0);
			aJSXwSKJLsNpWzIobYLDHvSWCOlX = 0;
			YNvbZPxSgZGZbDokLtlFFSXOFZtXA--;
			kodsxtNXdZWAKAFdEirXWNXTXNFl++;
			return result;
		}

		public T Peek()
		{
			if (qYgboybQCytrruilwlhEFIULgGID < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return GBWRbPYpoTgyEDBzLwEVrmXcJznuA[YkxELrFwosvRnLZnQuwYgWQvOYQPA];
		}

		public bool Contains(T item)
		{
			return huUyuyEolSIDujzkbDwVeWgfQOvl(item, NjqigiumohnmnFGzcjUPOMBThfOEA) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return huUyuyEolSIDujzkbDwVeWgfQOvl(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, NjqigiumohnmnFGzcjUPOMBThfOEA);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return efZWLArvLJDllHmGUeXkTMztRYmT(huUyuyEolSIDujzkbDwVeWgfQOvl(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, NjqigiumohnmnFGzcjUPOMBThfOEA);
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
			int num = huUyuyEolSIDujzkbDwVeWgfQOvl(item, comparer);
			if (num < 0)
			{
				return false;
			}
			FDBPaXpUUueAktudlWKofLRzEHwhA(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			FDBPaXpUUueAktudlWKofLRzEHwhA(mDRvCPoxZBWfunqnEwbOFiawavcw(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, NjqigiumohnmnFGzcjUPOMBThfOEA);
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
			if (YNvbZPxSgZGZbDokLtlFFSXOFZtXA > 0)
			{
				if (qYgboybQCytrruilwlhEFIULgGID >= YkxELrFwosvRnLZnQuwYgWQvOYQPA)
				{
					Array.Clear(GBWRbPYpoTgyEDBzLwEVrmXcJznuA, YkxELrFwosvRnLZnQuwYgWQvOYQPA, qYgboybQCytrruilwlhEFIULgGID - YkxELrFwosvRnLZnQuwYgWQvOYQPA + 1);
				}
				else
				{
					Array.Clear(GBWRbPYpoTgyEDBzLwEVrmXcJznuA, 0, qYgboybQCytrruilwlhEFIULgGID + 1);
					Array.Clear(GBWRbPYpoTgyEDBzLwEVrmXcJznuA, YkxELrFwosvRnLZnQuwYgWQvOYQPA, ebAIUroZIVQLRzIHQfUrqMmotLEH - YkxELrFwosvRnLZnQuwYgWQvOYQPA);
				}
				YNvbZPxSgZGZbDokLtlFFSXOFZtXA = 0;
			}
			qYgboybQCytrruilwlhEFIULgGID = -1;
			YkxELrFwosvRnLZnQuwYgWQvOYQPA = -1;
			aJSXwSKJLsNpWzIobYLDHvSWCOlX = 0;
			kodsxtNXdZWAKAFdEirXWNXTXNFl++;
		}

		private int vaSMuzTPlyhXyiFJKeNZsFfFZOro(T P_0)
		{
			return huUyuyEolSIDujzkbDwVeWgfQOvl(P_0, NjqigiumohnmnFGzcjUPOMBThfOEA);
		}

		private int huUyuyEolSIDujzkbDwVeWgfQOvl(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (YNvbZPxSgZGZbDokLtlFFSXOFZtXA == 0)
			{
				return -1;
			}
			if (qYgboybQCytrruilwlhEFIULgGID >= YkxELrFwosvRnLZnQuwYgWQvOYQPA)
			{
				for (int i = YkxELrFwosvRnLZnQuwYgWQvOYQPA; i <= qYgboybQCytrruilwlhEFIULgGID; i++)
				{
					if (P_1.Equals(GBWRbPYpoTgyEDBzLwEVrmXcJznuA[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= qYgboybQCytrruilwlhEFIULgGID; j++)
				{
					if (P_1.Equals(GBWRbPYpoTgyEDBzLwEVrmXcJznuA[j], P_0))
					{
						return j;
					}
				}
				for (int k = YkxELrFwosvRnLZnQuwYgWQvOYQPA; k < ebAIUroZIVQLRzIHQfUrqMmotLEH; k++)
				{
					if (P_1.Equals(GBWRbPYpoTgyEDBzLwEVrmXcJznuA[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void FDBPaXpUUueAktudlWKofLRzEHwhA(int P_0)
		{
			if (!BCUcyuDmAEsaWQgWYCXoWJBkbalq(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == YkxELrFwosvRnLZnQuwYgWQvOYQPA)
			{
				Dequeue();
				return;
			}
			if (P_0 != qYgboybQCytrruilwlhEFIULgGID)
			{
				if (qYgboybQCytrruilwlhEFIULgGID > YkxELrFwosvRnLZnQuwYgWQvOYQPA)
				{
					Array.Copy(GBWRbPYpoTgyEDBzLwEVrmXcJznuA, P_0 + 1, GBWRbPYpoTgyEDBzLwEVrmXcJznuA, P_0, qYgboybQCytrruilwlhEFIULgGID - P_0);
				}
				else if (P_0 < qYgboybQCytrruilwlhEFIULgGID)
				{
					Array.Copy(GBWRbPYpoTgyEDBzLwEVrmXcJznuA, P_0 + 1, GBWRbPYpoTgyEDBzLwEVrmXcJznuA, P_0, qYgboybQCytrruilwlhEFIULgGID - P_0);
				}
				else
				{
					Array.Copy(GBWRbPYpoTgyEDBzLwEVrmXcJznuA, P_0 + 1, GBWRbPYpoTgyEDBzLwEVrmXcJznuA, P_0, ebAIUroZIVQLRzIHQfUrqMmotLEH - P_0 - 1);
					GBWRbPYpoTgyEDBzLwEVrmXcJznuA[ebAIUroZIVQLRzIHQfUrqMmotLEH - 1] = GBWRbPYpoTgyEDBzLwEVrmXcJznuA[0];
					if (qYgboybQCytrruilwlhEFIULgGID > 0)
					{
						Array.Copy(GBWRbPYpoTgyEDBzLwEVrmXcJznuA, 1, GBWRbPYpoTgyEDBzLwEVrmXcJznuA, 0, qYgboybQCytrruilwlhEFIULgGID);
					}
				}
			}
			GBWRbPYpoTgyEDBzLwEVrmXcJznuA[qYgboybQCytrruilwlhEFIULgGID] = default(T);
			qYgboybQCytrruilwlhEFIULgGID = ((qYgboybQCytrruilwlhEFIULgGID > 0) ? (qYgboybQCytrruilwlhEFIULgGID - 1) : (ebAIUroZIVQLRzIHQfUrqMmotLEH - 1));
			kodsxtNXdZWAKAFdEirXWNXTXNFl++;
			YNvbZPxSgZGZbDokLtlFFSXOFZtXA--;
		}

		private bool BCUcyuDmAEsaWQgWYCXoWJBkbalq(int P_0)
		{
			if (YNvbZPxSgZGZbDokLtlFFSXOFZtXA == 0)
			{
				return false;
			}
			if (qYgboybQCytrruilwlhEFIULgGID >= YkxELrFwosvRnLZnQuwYgWQvOYQPA)
			{
				if (P_0 >= YkxELrFwosvRnLZnQuwYgWQvOYQPA)
				{
					return P_0 <= qYgboybQCytrruilwlhEFIULgGID;
				}
				return false;
			}
			if (P_0 < YkxELrFwosvRnLZnQuwYgWQvOYQPA)
			{
				return P_0 <= qYgboybQCytrruilwlhEFIULgGID;
			}
			return true;
		}

		private int efZWLArvLJDllHmGUeXkTMztRYmT(int P_0)
		{
			if ((uint)P_0 >= (uint)ebAIUroZIVQLRzIHQfUrqMmotLEH)
			{
				return -1;
			}
			if (!BCUcyuDmAEsaWQgWYCXoWJBkbalq(P_0))
			{
				return -1;
			}
			if (P_0 >= YkxELrFwosvRnLZnQuwYgWQvOYQPA)
			{
				return P_0 - YkxELrFwosvRnLZnQuwYgWQvOYQPA;
			}
			return P_0 + ebAIUroZIVQLRzIHQfUrqMmotLEH - YkxELrFwosvRnLZnQuwYgWQvOYQPA;
		}

		private int mDRvCPoxZBWfunqnEwbOFiawavcw(int P_0)
		{
			if ((uint)P_0 >= (uint)YNvbZPxSgZGZbDokLtlFFSXOFZtXA)
			{
				return -1;
			}
			P_0 = YkxELrFwosvRnLZnQuwYgWQvOYQPA + P_0;
			if (P_0 >= ebAIUroZIVQLRzIHQfUrqMmotLEH)
			{
				P_0 -= ebAIUroZIVQLRzIHQfUrqMmotLEH;
			}
			return P_0;
		}

		private void eXjuUZForZotukNKzLmozFZwNYU(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eXjuUZForZotukNKzLmozFZwNYU
			this.eXjuUZForZotukNKzLmozFZwNYU(P_0);
		}

		private void YcVgQFIwkekVtrivwIiFwzCmgNJd()
		{
			Clear();
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in YcVgQFIwkekVtrivwIiFwzCmgNJd
			this.YcVgQFIwkekVtrivwIiFwzCmgNJd();
		}

		private bool OPbcwglmlrrFMkMQgdTJhynCQAZZ(T P_0)
		{
			return Contains(P_0);
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OPbcwglmlrrFMkMQgdTJhynCQAZZ
			return this.OPbcwglmlrrFMkMQgdTJhynCQAZZ(P_0);
		}

		private void aozCJogqeooVhWRILgUyPtBFnklRA(T[] P_0, int P_1)
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
			//ILSpy generated this explicit interface implementation from .override directive in aozCJogqeooVhWRILgUyPtBFnklRA
			this.aozCJogqeooVhWRILgUyPtBFnklRA(P_0, P_1);
		}

		private bool xRnavqEZaqtTlFsDhkPDUbVANtG(T P_0)
		{
			return Remove(P_0);
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xRnavqEZaqtTlFsDhkPDUbVANtG
			return this.xRnavqEZaqtTlFsDhkPDUbVANtG(P_0);
		}

		private IEnumerator<T> eOETpXMzlDNQrPqQombrCaAmrQPI()
		{
			return new bPdIYGavMWkElWqkkeTwhRaguwBH(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in eOETpXMzlDNQrPqQombrCaAmrQPI
			return this.eOETpXMzlDNQrPqQombrCaAmrQPI();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new bPdIYGavMWkElWqkkeTwhRaguwBH(this);
		}
	}
}
