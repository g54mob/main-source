using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[DefaultMember("Item")]
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

			T IEnumerator<T>.Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == array.Length + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal xjsiDsaPWFasvWZjQQvcejxWcAxL(MappedArray<T> P_0)
			{
				array = P_0;
				index = 0;
				version = P_0.npHCTSBVYpmsQwGJPqPKKiXqPWxA;
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
				MappedArray<T> mappedArray = array;
				if (version == mappedArray.npHCTSBVYpmsQwGJPqPKKiXqPWxA && (uint)index < (uint)mappedArray.Length)
				{
					current = mappedArray.NsHcgghgMCWJafXWkmlDcGyZMwsNA[mappedArray.sQHOfeYGZxEGqpYvckYfEWXXySDH(index)];
					index++;
					return true;
				}
				return EJfCizEaWniahixIBAeRqGWkUuGMA();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool EJfCizEaWniahixIBAeRqGWkUuGMA()
			{
				if (version != array.npHCTSBVYpmsQwGJPqPKKiXqPWxA)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = array.Length + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != array.npHCTSBVYpmsQwGJPqPKKiXqPWxA)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private T[] NsHcgghgMCWJafXWkmlDcGyZMwsNA;

		private int npHCTSBVYpmsQwGJPqPKKiXqPWxA;

		private Func<int, int> VwleKfKFhHPOkcrpJIauzGNfJrdrA;

		public Func<int, int> indexMap
		{
			get
			{
				return VwleKfKFhHPOkcrpJIauzGNfJrdrA;
			}
			set
			{
				VwleKfKFhHPOkcrpJIauzGNfJrdrA = value;
				npHCTSBVYpmsQwGJPqPKKiXqPWxA++;
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				return NsHcgghgMCWJafXWkmlDcGyZMwsNA[sQHOfeYGZxEGqpYvckYfEWXXySDH(index)];
			}
			set
			{
				NsHcgghgMCWJafXWkmlDcGyZMwsNA[sQHOfeYGZxEGqpYvckYfEWXXySDH(index)] = value;
			}
		}

		public int Length => NsHcgghgMCWJafXWkmlDcGyZMwsNA.Length;

		int ICollection<T>.Count => NsHcgghgMCWJafXWkmlDcGyZMwsNA.Length;

		bool ICollection<T>.IsReadOnly => ((ICollection<T>)NsHcgghgMCWJafXWkmlDcGyZMwsNA).IsReadOnly;

		object IList.this[int index]
		{
			get
			{
				return ((IList)NsHcgghgMCWJafXWkmlDcGyZMwsNA)[sQHOfeYGZxEGqpYvckYfEWXXySDH(index)];
			}
			set
			{
				((IList)NsHcgghgMCWJafXWkmlDcGyZMwsNA)[sQHOfeYGZxEGqpYvckYfEWXXySDH(index)] = value;
			}
		}

		int ICollection.Count => NsHcgghgMCWJafXWkmlDcGyZMwsNA.Length;

		bool IList.IsFixedSize => ((IList)NsHcgghgMCWJafXWkmlDcGyZMwsNA).IsFixedSize;

		object ICollection.SyncRoot => ((ICollection)NsHcgghgMCWJafXWkmlDcGyZMwsNA).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)NsHcgghgMCWJafXWkmlDcGyZMwsNA).IsSynchronized;

		public MappedArray(T[] P_0, Func<int, int> P_1)
		{
			NsHcgghgMCWJafXWkmlDcGyZMwsNA = P_0;
			VwleKfKFhHPOkcrpJIauzGNfJrdrA = P_1;
		}

		public void Add(T item)
		{
			throw new NotImplementedException();
		}

		void ICollection<T>.Add(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(item);
		}

		public void Clear()
		{
			Array.Clear(NsHcgghgMCWJafXWkmlDcGyZMwsNA, 0, NsHcgghgMCWJafXWkmlDcGyZMwsNA.Length);
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		void IList.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		public bool Contains(T item)
		{
			return NsHcgghgMCWJafXWkmlDcGyZMwsNA.Contains(item);
		}

		bool ICollection<T>.Contains(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			NsHcgghgMCWJafXWkmlDcGyZMwsNA.CopyTo(array, arrayIndex);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new xjsiDsaPWFasvWZjQQvcejxWcAxL(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		public int IndexOf(T item)
		{
			return sQHOfeYGZxEGqpYvckYfEWXXySDH(((IList<T>)NsHcgghgMCWJafXWkmlDcGyZMwsNA).IndexOf(item));
		}

		int IList<T>.IndexOf(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(item);
		}

		private void GfATrMpmflDQXmHsAoAtmHLHDhCK(int P_0, T P_1)
		{
			throw new NotImplementedException();
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GfATrMpmflDQXmHsAoAtmHLHDhCK
			this.GfATrMpmflDQXmHsAoAtmHLHDhCK(P_0, P_1);
		}

		private bool hVQONRipduQIketqQkXlUKbKxAHU(T P_0)
		{
			throw new NotImplementedException();
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hVQONRipduQIketqQkXlUKbKxAHU
			return this.hVQONRipduQIketqQkXlUKbKxAHU(P_0);
		}

		private void qOIsYMNKPSVeDMQotSQiugLDreAC(int P_0)
		{
			throw new NotImplementedException();
		}

		void IList<T>.RemoveAt(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qOIsYMNKPSVeDMQotSQiugLDreAC
			this.qOIsYMNKPSVeDMQotSQiugLDreAC(P_0);
		}

		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		bool IList.Contains(object value)
		{
			return ((IList)NsHcgghgMCWJafXWkmlDcGyZMwsNA).Contains(value);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			NsHcgghgMCWJafXWkmlDcGyZMwsNA.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new xjsiDsaPWFasvWZjQQvcejxWcAxL(this);
		}

		int IList.IndexOf(object value)
		{
			return ((IList)NsHcgghgMCWJafXWkmlDcGyZMwsNA).IndexOf(value);
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

		private int sQHOfeYGZxEGqpYvckYfEWXXySDH(int P_0)
		{
			if (VwleKfKFhHPOkcrpJIauzGNfJrdrA == null)
			{
				return P_0;
			}
			if (P_0 < 0 || P_0 >= NsHcgghgMCWJafXWkmlDcGyZMwsNA.Length)
			{
				return P_0;
			}
			return VwleKfKFhHPOkcrpJIauzGNfJrdrA(P_0);
		}
	}
}
