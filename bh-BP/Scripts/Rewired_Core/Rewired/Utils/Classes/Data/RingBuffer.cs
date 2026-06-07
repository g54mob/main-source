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
		public struct xUlSGxMHgrjbrNqAqQzktApWHJGJA : IEnumerator<T>, IEnumerator, IDisposable
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal xUlSGxMHgrjbrNqAqQzktApWHJGJA(RingBuffer<T> P_0)
			{
				buffer = null;
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

			private bool lRyieUunyxARSkxKzRhcaNbIJPzhA()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private readonly T[] OvAvtaqWeanLOQHEVVsZqOnEIxoe;

		private readonly int mIYfWUCkuwdJNaerIYelDinUoUFdb;

		private int ifwqjBRNoZZyvbzWqCcOBLBxkVTO;

		private int OevVtWIwOXGRxEjDQzUCUaTFxOJl;

		private int OAvfZeJTAiLWvvNWPJoVMqYaZuop;

		private int kDKmIzoshZojSiwMrKpVDgBqCzmV;

		private int mapEiGAzXutNYcTRQNkPBKChloYGb;

		private IEqualityComparer<T> DrksRQEOwStfzQDAqFLcIKpzGJAB;

		public int Count => 0;

		public int Capacity => 0;

		public int OverrunCount => 0;

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

		int ICollection<T>.Count => 0;

		bool ICollection<T>.IsReadOnly => false;

		public RingBuffer(int P_0)
		{
		}

		public void Enqueue(T item)
		{
		}

		public bool EnqueueIfUnique(T item)
		{
			return false;
		}

		public T Dequeue()
		{
			return default(T);
		}

		public T Peek()
		{
			return default(T);
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

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return 0;
		}

		public bool Remove(T item)
		{
			return false;
		}

		public bool Remove(T item, IEqualityComparer<T> comparer)
		{
			return false;
		}

		public void RemoveAt(int index)
		{
		}

		public int RemoveAll(T item)
		{
			return 0;
		}

		public int RemoveAll(T item, IEqualityComparer<T> comparer)
		{
			return 0;
		}

		public void Clear()
		{
		}

		private int pMkoWhkBRSuilOdUbWBujchOzwl(T P_0)
		{
			return 0;
		}

		private int pSSkUXqERjKCmslElUhVmYpBrCuL(T P_0, IEqualityComparer<T> P_1)
		{
			return 0;
		}

		private void JdZyPoXkuZNRkqcPzZPghdSBamdJ(int P_0)
		{
		}

		private bool BdUUyLncchXtCZOaSTGuYtSMcLyo(int P_0)
		{
			return false;
		}

		private int sfHLbtLwxcktdOsxWAZqLgFZjsdD(int P_0)
		{
			return 0;
		}

		private int meXwvgKCzmEFeAsXIAxKRJfMaGbwA(int P_0)
		{
			return 0;
		}

		private void oaHlqlbiWCubnjJjEkQyaWIluwDT(T P_0)
		{
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in oaHlqlbiWCubnjJjEkQyaWIluwDT
			this.oaHlqlbiWCubnjJjEkQyaWIluwDT(P_0);
		}

		private void UWHsqcoMKFAtjDcUsmRDrqaYPXALA()
		{
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UWHsqcoMKFAtjDcUsmRDrqaYPXALA
			this.UWHsqcoMKFAtjDcUsmRDrqaYPXALA();
		}

		private bool AWtZcDHFZMlSIjToebOTiUqyTtKO(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AWtZcDHFZMlSIjToebOTiUqyTtKO
			return this.AWtZcDHFZMlSIjToebOTiUqyTtKO(P_0);
		}

		private void qVzPQNKIGPfOdGmuByLgziWnFDmHA(T[] P_0, int P_1)
		{
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in qVzPQNKIGPfOdGmuByLgziWnFDmHA
			this.qVzPQNKIGPfOdGmuByLgziWnFDmHA(P_0, P_1);
		}

		private bool vvJIzWKMhXPfLssKNBmFNgknZpaV(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in vvJIzWKMhXPfLssKNBmFNgknZpaV
			return this.vvJIzWKMhXPfLssKNBmFNgknZpaV(P_0);
		}

		private IEnumerator<T> sNUgBcKqVgNGfmWQodxbSKJCwYCsA()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in sNUgBcKqVgNGfmWQodxbSKJCwYCsA
			return this.sNUgBcKqVgNGfmWQodxbSKJCwYCsA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
