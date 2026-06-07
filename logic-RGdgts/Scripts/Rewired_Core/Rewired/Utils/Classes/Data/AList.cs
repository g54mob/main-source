using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class AList<T> : IList, IEnumerable, IEnumerable<T>, ICollection, ICollection<T>, IList<T>
	{
		[Serializable]
		public struct MKWoPmPwqdKwjKvLjtFMxbcNUspE : IDisposable, IEnumerator, IEnumerator<T>
		{
			private AList<T> list;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal MKWoPmPwqdKwjKvLjtFMxbcNUspE(AList<T> P_0)
			{
				list = null;
				index = 0;
				version = 0;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			private bool YUNzHBHdnPnnvPeZBmfosUxHsXub()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private const int gFuwpTeXAJQMYnDbpepQCUsJkMloA = 4;

		private static readonly T[] siyoejNuhSbQkorHhfijXLJGHFKC;

		private IEqualityComparer<T> nbufZEcfFKaLWeibFrkRMurDRraZB;

		public T[] _items;

		private int ngsUIyottIhptdyVRpkhbNqZCuLV;

		public int _count;

		private int faWalMlGtacESEXauOhFCJEjQZOM;

		private bool kKtbfCPCHvFJRcVeOxYjOHFtSQom;

		private readonly int qOKqPXLBnRIKhjPnoxweMvAElutT;

		private readonly bool ITMwFddJyejAYoLIABArkcrWwUZD;

		private int CNDFoUJoeZozIXLwyWmfCLhOpTpJ;

		[NonSerialized]
		private object RMeCNmGPKKFWHvRprhLLNwMGEUsJA;

		public int Count => 0;

		public int Capacity => 0;

		public int FreeSpace => 0;

		public bool IsFixedSize => false;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int Version => 0;

		public T Item
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		bool ICollection<T>.IsReadOnly => false;

		bool IList.IsReadOnly => false;

		object IList.Item
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		int ICollection.Count => 0;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => null;

		public AList()
		{
		}

		public AList(int P_0)
		{
		}

		public AList(int P_0, int P_1)
		{
		}

		public AList(int P_0, int P_1, int P_2)
		{
		}

		public AList(IEnumerable<T> P_0)
		{
		}

		public AList(IEnumerable<T> P_0, int P_1, int P_2)
		{
		}

		public T GetRandom()
		{
			return default(T);
		}

		public int Add(T item)
		{
			return 0;
		}

		public bool Add(T[] items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			return false;
		}

		public bool Add(AList<T> items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
		{
			return false;
		}

		public int AddIfUnique(T item)
		{
			return 0;
		}

		public int AddToFirstOpenSpace(T item)
		{
			return 0;
		}

		public int AddToFirstOpenSpace(T item, T openSpaceEquals)
		{
			return 0;
		}

		public bool Insert(int index, T item)
		{
			return false;
		}

		public bool Remove(T item)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return false;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public int IndexOf(T item, int index)
		{
			return 0;
		}

		public int IndexOf(T item, int index, int count)
		{
			return 0;
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return 0;
		}

		public int IndexOf(T item, int index, IEqualityComparer<T> comparer)
		{
			return 0;
		}

		public int IndexOf(T item, int index, int count, IEqualityComparer<T> comparer)
		{
			return 0;
		}

		public void Reverse()
		{
		}

		public void Reverse(int index, int count)
		{
		}

		public void Sort()
		{
		}

		public void Sort(IComparer<T> comparer)
		{
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
		}

		public List<T> GetRange(int index, int count)
		{
			return null;
		}

		public ReadOnlyCollection<T> AsReadOnly()
		{
			return null;
		}

		public bool Exists(Predicate<T> match)
		{
			return false;
		}

		public T Find(Predicate<T> match)
		{
			return default(T);
		}

		public List<T> FindAll(Predicate<T> match)
		{
			return null;
		}

		public int FindIndex(Predicate<T> match)
		{
			return 0;
		}

		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return 0;
		}

		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			return 0;
		}

		public T FindLast(Predicate<T> match)
		{
			return default(T);
		}

		public int FindLastIndex(Predicate<T> match)
		{
			return 0;
		}

		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return 0;
		}

		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			return 0;
		}

		public void ForEach(Action<T> action)
		{
		}

		public int LastIndexOf(T item)
		{
			return 0;
		}

		public int LastIndexOf(T item, int index)
		{
			return 0;
		}

		public int LastIndexOf(T item, int index, int count)
		{
			return 0;
		}

		public int RemoveAll(Predicate<T> match)
		{
			return 0;
		}

		public bool TrueForAll(Predicate<T> match)
		{
			return false;
		}

		public T[] ToArray()
		{
			return null;
		}

		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public void Clear()
		{
		}

		public void TrimExcess()
		{
		}

		private int ayxfhjRtGHUCaIlbXAprIvcaRSZD(int P_0, bool P_1 = false)
		{
			return 0;
		}

		private int iyOrvBffdmoiWunaQMTWkNcgPzb(int P_0, int P_1)
		{
			return 0;
		}

		private bool cizKfixQyiMsziIsefTUZmGlIPQY(int P_0, bool P_1 = false)
		{
			return false;
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
		}

		void ICollection<T>.Add(T P_0)
		{
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		int IList.Add(object value)
		{
			return 0;
		}

		bool IList.Contains(object value)
		{
			return false;
		}

		int IList.IndexOf(object value)
		{
			return 0;
		}

		void IList.Insert(int index, object value)
		{
		}

		void IList.Remove(object value)
		{
		}

		public static AList<T> CreateFixedLengthList(int capacity)
		{
			return null;
		}

		private static bool SzYVmhUJmMCpWazhBwNjmWnjLivZ(object P_0)
		{
			return false;
		}
	}
}
