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
		public struct kuXTqwPrRJWHgZJCeiePIjuSBBCK : IEnumerator<T>, IEnumerator, IDisposable
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

			internal kuXTqwPrRJWHgZJCeiePIjuSBBCK(MappedArray<T> P_0)
			{
				array = P_0;
				index = 0;
				version = P_0.kLMOSTcpkYwApfNodEEcKglBQixdb;
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
				if (version == mappedArray.kLMOSTcpkYwApfNodEEcKglBQixdb && (uint)index < (uint)mappedArray.Length)
				{
					current = mappedArray.SOswoeZWbMpHnOpyIZbgyonBXTXI[mappedArray.lWoDOwbpghzirioRSfWQRkGTBLsFb(index)];
					index++;
					return true;
				}
				return FRWgaxDknnOykaaelOzikaJoPUnf();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool FRWgaxDknnOykaaelOzikaJoPUnf()
			{
				if (version != array.kLMOSTcpkYwApfNodEEcKglBQixdb)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = array.Length + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != array.kLMOSTcpkYwApfNodEEcKglBQixdb)
				{
					throw new InvalidOperationException("List was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private T[] SOswoeZWbMpHnOpyIZbgyonBXTXI;

		private int kLMOSTcpkYwApfNodEEcKglBQixdb;

		private Func<int, int> ORWWYhcpAHoGfgERlBCNasUzAwGm;

		public Func<int, int> indexMap
		{
			get
			{
				return ORWWYhcpAHoGfgERlBCNasUzAwGm;
			}
			set
			{
				ORWWYhcpAHoGfgERlBCNasUzAwGm = value;
				kLMOSTcpkYwApfNodEEcKglBQixdb++;
			}
		}

		T IList<T>.this[int index]
		{
			get
			{
				return SOswoeZWbMpHnOpyIZbgyonBXTXI[lWoDOwbpghzirioRSfWQRkGTBLsFb(index)];
			}
			set
			{
				SOswoeZWbMpHnOpyIZbgyonBXTXI[lWoDOwbpghzirioRSfWQRkGTBLsFb(index)] = value;
			}
		}

		public int Length => SOswoeZWbMpHnOpyIZbgyonBXTXI.Length;

		int ICollection<T>.Count => SOswoeZWbMpHnOpyIZbgyonBXTXI.Length;

		bool IList.IsReadOnly => ((ICollection<T>)SOswoeZWbMpHnOpyIZbgyonBXTXI).IsReadOnly;

		object IList.this[int index]
		{
			get
			{
				return ((IList)SOswoeZWbMpHnOpyIZbgyonBXTXI)[lWoDOwbpghzirioRSfWQRkGTBLsFb(index)];
			}
			set
			{
				((IList)SOswoeZWbMpHnOpyIZbgyonBXTXI)[lWoDOwbpghzirioRSfWQRkGTBLsFb(index)] = value;
			}
		}

		int ICollection.Count => SOswoeZWbMpHnOpyIZbgyonBXTXI.Length;

		bool IList.IsFixedSize => ((IList)SOswoeZWbMpHnOpyIZbgyonBXTXI).IsFixedSize;

		object ICollection.SyncRoot => ((ICollection)SOswoeZWbMpHnOpyIZbgyonBXTXI).SyncRoot;

		bool ICollection.IsSynchronized => ((ICollection)SOswoeZWbMpHnOpyIZbgyonBXTXI).IsSynchronized;

		public MappedArray(T[] P_0, Func<int, int> P_1)
		{
			SOswoeZWbMpHnOpyIZbgyonBXTXI = P_0;
			ORWWYhcpAHoGfgERlBCNasUzAwGm = P_1;
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
			Array.Clear(SOswoeZWbMpHnOpyIZbgyonBXTXI, 0, SOswoeZWbMpHnOpyIZbgyonBXTXI.Length);
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
			return SOswoeZWbMpHnOpyIZbgyonBXTXI.Contains(item);
		}

		bool ICollection<T>.Contains(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			SOswoeZWbMpHnOpyIZbgyonBXTXI.CopyTo(array, arrayIndex);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new kuXTqwPrRJWHgZJCeiePIjuSBBCK(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		public int IndexOf(T item)
		{
			return lWoDOwbpghzirioRSfWQRkGTBLsFb(((IList<T>)SOswoeZWbMpHnOpyIZbgyonBXTXI).IndexOf(item));
		}

		int IList<T>.IndexOf(T item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(item);
		}

		private void DwzBJOfUEfojUFtvelSSBMOiTebtb(int P_0, T P_1)
		{
			throw new NotImplementedException();
		}

		void IList<T>.Insert(int P_0, T P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DwzBJOfUEfojUFtvelSSBMOiTebtb
			this.DwzBJOfUEfojUFtvelSSBMOiTebtb(P_0, P_1);
		}

		private bool cOpPHZZSmoshtdWzgbABeanIlgGc(T P_0)
		{
			throw new NotImplementedException();
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in cOpPHZZSmoshtdWzgbABeanIlgGc
			return this.cOpPHZZSmoshtdWzgbABeanIlgGc(P_0);
		}

		private void tqfJuEeNbUWzCHFwRDcRIIbRVQfX(int P_0)
		{
			throw new NotImplementedException();
		}

		void IList<T>.RemoveAt(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in tqfJuEeNbUWzCHFwRDcRIIbRVQfX
			this.tqfJuEeNbUWzCHFwRDcRIIbRVQfX(P_0);
		}

		int IList.Add(object value)
		{
			throw new NotImplementedException();
		}

		bool IList.Contains(object value)
		{
			return ((IList)SOswoeZWbMpHnOpyIZbgyonBXTXI).Contains(value);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			SOswoeZWbMpHnOpyIZbgyonBXTXI.CopyTo(array, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new kuXTqwPrRJWHgZJCeiePIjuSBBCK(this);
		}

		int IList.IndexOf(object value)
		{
			return ((IList)SOswoeZWbMpHnOpyIZbgyonBXTXI).IndexOf(value);
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

		private int lWoDOwbpghzirioRSfWQRkGTBLsFb(int P_0)
		{
			if (ORWWYhcpAHoGfgERlBCNasUzAwGm == null)
			{
				return P_0;
			}
			if (P_0 < 0 || P_0 >= SOswoeZWbMpHnOpyIZbgyonBXTXI.Length)
			{
				return P_0;
			}
			return ORWWYhcpAHoGfgERlBCNasUzAwGm(P_0);
		}
	}
}
