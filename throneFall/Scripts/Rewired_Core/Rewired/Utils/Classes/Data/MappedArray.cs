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
		public struct WoEayBfMrFppCAWSlFziEnKLVtmgb : IEnumerator<T>, IEnumerator, IDisposable
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

			internal WoEayBfMrFppCAWSlFziEnKLVtmgb(MappedArray<T> P_0)
			{
				array = P_0;
				index = 0;
				version = P_0.OZLtesdxkMbZRybbuXqNDYBWWjTi;
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
				if (version == mappedArray.OZLtesdxkMbZRybbuXqNDYBWWjTi && (uint)index < (uint)mappedArray.Length)
				{
					current = mappedArray.sFrgLDUNxCiCVZnpJmGFZdZKLtru[mappedArray.ZchbLPiEivBJVdWULLrzDncCbRQi(index)];
					index++;
					return true;
				}
				return zJTFTYMPljKpAvGvcJZBJHlfWzFt();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool zJTFTYMPljKpAvGvcJZBJHlfWzFt()
			{
				if (version != array.OZLtesdxkMbZRybbuXqNDYBWWjTi)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = array.Length + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != array.OZLtesdxkMbZRybbuXqNDYBWWjTi)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private T[] sFrgLDUNxCiCVZnpJmGFZdZKLtru;

		private int OZLtesdxkMbZRybbuXqNDYBWWjTi;

		private Func<int, int> kDBlhYfEUFPFRnWIkLBsPJmaecuO;

		public Func<int, int> indexMap
		{
			get
			{
				return kDBlhYfEUFPFRnWIkLBsPJmaecuO;
			}
			set
			{
				kDBlhYfEUFPFRnWIkLBsPJmaecuO = value;
				OZLtesdxkMbZRybbuXqNDYBWWjTi++;
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				return sFrgLDUNxCiCVZnpJmGFZdZKLtru[ZchbLPiEivBJVdWULLrzDncCbRQi(index)];
			}
			set
			{
				sFrgLDUNxCiCVZnpJmGFZdZKLtru[ZchbLPiEivBJVdWULLrzDncCbRQi(index)] = value;
			}
		}

		public int Length => sFrgLDUNxCiCVZnpJmGFZdZKLtru.Length;

		int ICollection<T>.Count => sFrgLDUNxCiCVZnpJmGFZdZKLtru.Length;

		bool IList.IsReadOnly => ((ICollection<T>)sFrgLDUNxCiCVZnpJmGFZdZKLtru).IsReadOnly;

		object IList.this[int index]
		{
			get
			{
				return ((IList)sFrgLDUNxCiCVZnpJmGFZdZKLtru)[ZchbLPiEivBJVdWULLrzDncCbRQi(index)];
			}
			set
			{
				((IList)sFrgLDUNxCiCVZnpJmGFZdZKLtru)[ZchbLPiEivBJVdWULLrzDncCbRQi(index)] = value;
			}
		}

		int ICollection.Count => sFrgLDUNxCiCVZnpJmGFZdZKLtru.Length;

		bool IList.IsFixedSize => ((IList)sFrgLDUNxCiCVZnpJmGFZdZKLtru).IsFixedSize;

		object ICollection.SyncRoot => ((ICollection)sFrgLDUNxCiCVZnpJmGFZdZKLtru).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)sFrgLDUNxCiCVZnpJmGFZdZKLtru).IsSynchronized;

		public MappedArray(T[] P_0, Func<int, int> P_1)
		{
			sFrgLDUNxCiCVZnpJmGFZdZKLtru = P_0;
			kDBlhYfEUFPFRnWIkLBsPJmaecuO = P_1;
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
			Array.Clear(sFrgLDUNxCiCVZnpJmGFZdZKLtru, 0, sFrgLDUNxCiCVZnpJmGFZdZKLtru.Length);
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
			return sFrgLDUNxCiCVZnpJmGFZdZKLtru.Contains(item);
		}

		bool ICollection<T>.Contains(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			sFrgLDUNxCiCVZnpJmGFZdZKLtru.CopyTo(array, arrayIndex);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new WoEayBfMrFppCAWSlFziEnKLVtmgb(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		public int IndexOf(T item)
		{
			return ZchbLPiEivBJVdWULLrzDncCbRQi(((IList<T>)sFrgLDUNxCiCVZnpJmGFZdZKLtru).IndexOf(item));
		}

		int IList<T>.IndexOf(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(item);
		}

		private void dhseNnXSjdAetcezzJfxxgtUYHNB(int P_0, T P_1)
		{
			throw new NotImplementedException();
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in dhseNnXSjdAetcezzJfxxgtUYHNB
			this.dhseNnXSjdAetcezzJfxxgtUYHNB(P_0, P_1);
		}

		private bool CDuasgaQMedFFxsNbMkzDHYeRTCTb(T P_0)
		{
			throw new NotImplementedException();
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CDuasgaQMedFFxsNbMkzDHYeRTCTb
			return this.CDuasgaQMedFFxsNbMkzDHYeRTCTb(P_0);
		}

		private void TzgRelxxvSAveScfObFqbFVEdsPx(int P_0)
		{
			throw new NotImplementedException();
		}

		void IList<T>.RemoveAt(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in TzgRelxxvSAveScfObFqbFVEdsPx
			this.TzgRelxxvSAveScfObFqbFVEdsPx(P_0);
		}

		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		bool IList.Contains(object value)
		{
			return ((IList)sFrgLDUNxCiCVZnpJmGFZdZKLtru).Contains(value);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			sFrgLDUNxCiCVZnpJmGFZdZKLtru.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new WoEayBfMrFppCAWSlFziEnKLVtmgb(this);
		}

		int IList.IndexOf(object value)
		{
			return ((IList)sFrgLDUNxCiCVZnpJmGFZdZKLtru).IndexOf(value);
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

		private int ZchbLPiEivBJVdWULLrzDncCbRQi(int P_0)
		{
			if (kDBlhYfEUFPFRnWIkLBsPJmaecuO == null)
			{
				return P_0;
			}
			if (P_0 < 0 || P_0 >= sFrgLDUNxCiCVZnpJmGFZdZKLtru.Length)
			{
				return P_0;
			}
			return kDBlhYfEUFPFRnWIkLBsPJmaecuO(P_0);
		}
	}
}
