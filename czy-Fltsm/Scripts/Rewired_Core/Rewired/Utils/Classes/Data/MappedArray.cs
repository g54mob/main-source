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
		public struct bqiFBjfCkJkiBwtZRjRZPllrUhnEA : IEnumerator<T>, IEnumerator, IDisposable
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

			internal bqiFBjfCkJkiBwtZRjRZPllrUhnEA(MappedArray<T> P_0)
			{
				array = P_0;
				index = 0;
				version = P_0.vXnGvQryzOsRIHRqMphkHMigCOCL;
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
				if (version == mappedArray.vXnGvQryzOsRIHRqMphkHMigCOCL && (uint)index < (uint)mappedArray.Length)
				{
					current = mappedArray.ZTZGuvOXuWjVOalwlAcsaPcySxaCA[mappedArray.qLRYZpwtcrGYECNIlxzYBPVydPxc(index)];
					index++;
					return true;
				}
				return QklksiWLwdycHCjkIbnoARQPJrWxA();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool QklksiWLwdycHCjkIbnoARQPJrWxA()
			{
				if (version != array.vXnGvQryzOsRIHRqMphkHMigCOCL)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = array.Length + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != array.vXnGvQryzOsRIHRqMphkHMigCOCL)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private T[] ZTZGuvOXuWjVOalwlAcsaPcySxaCA;

		private int vXnGvQryzOsRIHRqMphkHMigCOCL;

		private Func<int, int> RPpeUolPJHtQOIPFSClNJwXUenxL;

		public Func<int, int> indexMap
		{
			get
			{
				return RPpeUolPJHtQOIPFSClNJwXUenxL;
			}
			set
			{
				RPpeUolPJHtQOIPFSClNJwXUenxL = value;
				vXnGvQryzOsRIHRqMphkHMigCOCL++;
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				return ZTZGuvOXuWjVOalwlAcsaPcySxaCA[qLRYZpwtcrGYECNIlxzYBPVydPxc(index)];
			}
			set
			{
				ZTZGuvOXuWjVOalwlAcsaPcySxaCA[qLRYZpwtcrGYECNIlxzYBPVydPxc(index)] = value;
			}
		}

		public int Length => ZTZGuvOXuWjVOalwlAcsaPcySxaCA.Length;

		int ICollection<T>.Count => ZTZGuvOXuWjVOalwlAcsaPcySxaCA.Length;

		bool ICollection<T>.IsReadOnly => ((ICollection<T>)ZTZGuvOXuWjVOalwlAcsaPcySxaCA).IsReadOnly;

		object IList.this[int index]
		{
			get
			{
				return ((IList)ZTZGuvOXuWjVOalwlAcsaPcySxaCA)[qLRYZpwtcrGYECNIlxzYBPVydPxc(index)];
			}
			set
			{
				((IList)ZTZGuvOXuWjVOalwlAcsaPcySxaCA)[qLRYZpwtcrGYECNIlxzYBPVydPxc(index)] = value;
			}
		}

		int ICollection.Count => ZTZGuvOXuWjVOalwlAcsaPcySxaCA.Length;

		bool IList.IsFixedSize => ((IList)ZTZGuvOXuWjVOalwlAcsaPcySxaCA).IsFixedSize;

		object ICollection.SyncRoot => ((ICollection)ZTZGuvOXuWjVOalwlAcsaPcySxaCA).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)ZTZGuvOXuWjVOalwlAcsaPcySxaCA).IsSynchronized;

		public MappedArray(T[] P_0, Func<int, int> P_1)
		{
			ZTZGuvOXuWjVOalwlAcsaPcySxaCA = P_0;
			RPpeUolPJHtQOIPFSClNJwXUenxL = P_1;
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
			Array.Clear(ZTZGuvOXuWjVOalwlAcsaPcySxaCA, 0, ZTZGuvOXuWjVOalwlAcsaPcySxaCA.Length);
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
			return ZTZGuvOXuWjVOalwlAcsaPcySxaCA.Contains(item);
		}

		bool ICollection<T>.Contains(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			ZTZGuvOXuWjVOalwlAcsaPcySxaCA.CopyTo(array, arrayIndex);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new bqiFBjfCkJkiBwtZRjRZPllrUhnEA(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		public int IndexOf(T item)
		{
			return qLRYZpwtcrGYECNIlxzYBPVydPxc(((IList<T>)ZTZGuvOXuWjVOalwlAcsaPcySxaCA).IndexOf(item));
		}

		int IList<T>.IndexOf(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(item);
		}

		private void GIGXlTBaDfREzFTxPfIGlnFqCEGm(int P_0, T P_1)
		{
			throw new NotImplementedException();
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GIGXlTBaDfREzFTxPfIGlnFqCEGm
			this.GIGXlTBaDfREzFTxPfIGlnFqCEGm(P_0, P_1);
		}

		private bool xsWsVQENDqaWYbZKBHOCuHbrHZNRA(T P_0)
		{
			throw new NotImplementedException();
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xsWsVQENDqaWYbZKBHOCuHbrHZNRA
			return this.xsWsVQENDqaWYbZKBHOCuHbrHZNRA(P_0);
		}

		private void cLCmfFnmiYNZvdqmwDqPptmyeHUl(int P_0)
		{
			throw new NotImplementedException();
		}

		void IList<T>.RemoveAt(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in cLCmfFnmiYNZvdqmwDqPptmyeHUl
			this.cLCmfFnmiYNZvdqmwDqPptmyeHUl(P_0);
		}

		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		bool IList.Contains(object value)
		{
			return ((IList)ZTZGuvOXuWjVOalwlAcsaPcySxaCA).Contains(value);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			ZTZGuvOXuWjVOalwlAcsaPcySxaCA.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new bqiFBjfCkJkiBwtZRjRZPllrUhnEA(this);
		}

		int IList.IndexOf(object value)
		{
			return ((IList)ZTZGuvOXuWjVOalwlAcsaPcySxaCA).IndexOf(value);
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

		private int qLRYZpwtcrGYECNIlxzYBPVydPxc(int P_0)
		{
			if (RPpeUolPJHtQOIPFSClNJwXUenxL == null)
			{
				return P_0;
			}
			if (P_0 < 0 || P_0 >= ZTZGuvOXuWjVOalwlAcsaPcySxaCA.Length)
			{
				return P_0;
			}
			return RPpeUolPJHtQOIPFSClNJwXUenxL(P_0);
		}
	}
}
