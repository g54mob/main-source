using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class MappedArray<T> : IList, IEnumerable, IEnumerable<T>, ICollection, ICollection<T>, IList<T>
	{
		[Serializable]
		public struct agQHESbzzrNNjcQUpwdQiHvPsQwk : IDisposable, IEnumerator, IEnumerator<T>
		{
			private MappedArray<T> array;

			private int index;

			private int version;

			private T current;

			public T Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == array.Length + 1)
					{
						throw new InvalidOperationException();
					}
					return Current;
				}
			}

			internal agQHESbzzrNNjcQUpwdQiHvPsQwk(MappedArray<T> P_0)
			{
				array = P_0;
				index = 0;
				version = P_0.dxTsCFpBKFlPomOIZacJFoWJetjo;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				MappedArray<T> mappedArray = array;
				if (version == mappedArray.dxTsCFpBKFlPomOIZacJFoWJetjo && (uint)index < (uint)mappedArray.Length)
				{
					current = mappedArray.ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb[mappedArray.JDMhVnAHPmCGgzLWhGnzklccNxyW(index)];
					index++;
					return true;
				}
				return veXIwWfQFZwULylAorGDfSnMesJK();
			}

			private bool veXIwWfQFZwULylAorGDfSnMesJK()
			{
				if (version != array.dxTsCFpBKFlPomOIZacJFoWJetjo)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = array.Length + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != array.dxTsCFpBKFlPomOIZacJFoWJetjo)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private T[] ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb;

		private int dxTsCFpBKFlPomOIZacJFoWJetjo;

		private Func<int, int> ZphAaknheRBhwafSnMSiimhzPENA;

		public Func<int, int> indexMap
		{
			get
			{
				return ZphAaknheRBhwafSnMSiimhzPENA;
			}
			set
			{
				ZphAaknheRBhwafSnMSiimhzPENA = value;
				dxTsCFpBKFlPomOIZacJFoWJetjo++;
			}
		}

		public T this[int index]
		{
			get
			{
				return ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb[JDMhVnAHPmCGgzLWhGnzklccNxyW(index)];
			}
			set
			{
				ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb[JDMhVnAHPmCGgzLWhGnzklccNxyW(index)] = value;
			}
		}

		public int Length => ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.Length;

		int ICollection<T>.Count => ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.Length;

		public bool IsReadOnly => ((ICollection<T>)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb).IsReadOnly;

		object IList.this[int index]
		{
			get
			{
				return ((IList)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb)[JDMhVnAHPmCGgzLWhGnzklccNxyW(index)];
			}
			set
			{
				((IList)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb)[JDMhVnAHPmCGgzLWhGnzklccNxyW(index)] = value;
			}
		}

		int ICollection.Count => ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.Length;

		bool IList.IsFixedSize => ((IList)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb).IsFixedSize;

		object ICollection.SyncRoot => ((ICollection)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb).IsSynchronized;

		public MappedArray(T[] P_0, Func<int, int> P_1)
		{
			ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb = P_0;
			ZphAaknheRBhwafSnMSiimhzPENA = P_1;
		}

		public void Add(T item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			Array.Clear(ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb, 0, ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.Length);
		}

		public bool Contains(T item)
		{
			return ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new agQHESbzzrNNjcQUpwdQiHvPsQwk(this);
		}

		public int IndexOf(T item)
		{
			return JDMhVnAHPmCGgzLWhGnzklccNxyW(((IList<T>)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb).IndexOf(item));
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			throw new NotImplementedException();
		}

		bool ICollection<T>.Remove(T P_0)
		{
			throw new NotImplementedException();
		}

		void IList<T>.RemoveAt(int P_0)
		{
			throw new NotImplementedException();
		}

		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		bool IList.Contains(object value)
		{
			return ((IList)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb).Contains(value);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new agQHESbzzrNNjcQUpwdQiHvPsQwk(this);
		}

		int IList.IndexOf(object value)
		{
			return ((IList)ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb).IndexOf(value);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotImplementedException();
		}

		void IList.Remove(object value)
		{
			throw new NotImplementedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		private int JDMhVnAHPmCGgzLWhGnzklccNxyW(int P_0)
		{
			if (ZphAaknheRBhwafSnMSiimhzPENA == null)
			{
				return P_0;
			}
			if (P_0 < 0 || P_0 >= ZCsaNxKvFlfkIjhFDqLOfyLoqnDDb.Length)
			{
				return P_0;
			}
			return ZphAaknheRBhwafSnMSiimhzPENA(P_0);
		}
	}
}
