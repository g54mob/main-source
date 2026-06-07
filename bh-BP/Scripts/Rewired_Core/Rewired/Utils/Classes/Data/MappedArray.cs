using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class MappedArray<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
	{
		[Serializable]
		public struct xjsiDsaPWFasvWZjQQvcejxWcAxL : IEnumerator<T>, IEnumerator, IDisposable
		{
			private MappedArray<T> array;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal xjsiDsaPWFasvWZjQQvcejxWcAxL(MappedArray<T> P_0)
			{
				array = null;
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

			private bool EJfCizEaWniahixIBAeRqGWkUuGMA()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private T[] NsHcgghgMCWJafXWkmlDcGyZMwsNA;

		private int npHCTSBVYpmsQwGJPqPKKiXqPWxA;

		private Func<int, int> VwleKfKFhHPOkcrpJIauzGNfJrdrA;

		public Func<int, int> indexMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public int Length => 0;

		int ICollection<T>.Count => 0;

		public bool IsReadOnly => false;

		object IList.this[int index]
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

		bool IList.IsFixedSize => false;

		object ICollection.SyncRoot => null;

		bool ICollection.IsSynchronized => false;

		public MappedArray(T[] P_0, Func<int, int> P_1)
		{
		}

		public void Add(T item)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		private void GfATrMpmflDQXmHsAoAtmHLHDhCK(int P_0, T P_1)
		{
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GfATrMpmflDQXmHsAoAtmHLHDhCK
			this.GfATrMpmflDQXmHsAoAtmHLHDhCK(P_0, P_1);
		}

		private bool hVQONRipduQIketqQkXlUKbKxAHU(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hVQONRipduQIketqQkXlUKbKxAHU
			return this.hVQONRipduQIketqQkXlUKbKxAHU(P_0);
		}

		private void qOIsYMNKPSVeDMQotSQiugLDreAC(int P_0)
		{
		}

		void IList<T>.RemoveAt(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qOIsYMNKPSVeDMQotSQiugLDreAC
			this.qOIsYMNKPSVeDMQotSQiugLDreAC(P_0);
		}

		int IList.Add(object value)
		{
			return 0;
		}

		bool IList.Contains(object value)
		{
			return false;
		}

		void ICollection.CopyTo(Array array, int index)
		{
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
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

		void IList.RemoveAt(int index)
		{
		}

		private int sQHOfeYGZxEGqpYvckYfEWXXySDH(int P_0)
		{
			return 0;
		}
	}
}
