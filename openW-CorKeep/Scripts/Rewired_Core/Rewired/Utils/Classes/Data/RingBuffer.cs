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

			T IEnumerator<T>.Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == buffer.OAvfZeJTAiLWvvNWPJoVMqYaZuop + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal xUlSGxMHgrjbrNqAqQzktApWHJGJA(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.mapEiGAzXutNYcTRQNkPBKChloYGb;
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
				if (version == buffer.mapEiGAzXutNYcTRQNkPBKChloYGb && (uint)index < (uint)buffer.OAvfZeJTAiLWvvNWPJoVMqYaZuop)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return lRyieUunyxARSkxKzRhcaNbIJPzhA();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool lRyieUunyxARSkxKzRhcaNbIJPzhA()
			{
				if (version != buffer.mapEiGAzXutNYcTRQNkPBKChloYGb)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.OAvfZeJTAiLWvvNWPJoVMqYaZuop + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.mapEiGAzXutNYcTRQNkPBKChloYGb)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] OvAvtaqWeanLOQHEVVsZqOnEIxoe;

		private readonly int mIYfWUCkuwdJNaerIYelDinUoUFdb;

		private int ifwqjBRNoZZyvbzWqCcOBLBxkVTO;

		private int OevVtWIwOXGRxEjDQzUCUaTFxOJl;

		private int OAvfZeJTAiLWvvNWPJoVMqYaZuop;

		private int kDKmIzoshZojSiwMrKpVDgBqCzmV;

		private int mapEiGAzXutNYcTRQNkPBKChloYGb;

		private IEqualityComparer<T> DrksRQEOwStfzQDAqFLcIKpzGJAB = EqualityComparerNoAlloc<T>.Default;

		public int Count => OAvfZeJTAiLWvvNWPJoVMqYaZuop;

		public int Capacity => mIYfWUCkuwdJNaerIYelDinUoUFdb;

		public int OverrunCount => kDKmIzoshZojSiwMrKpVDgBqCzmV;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return DrksRQEOwStfzQDAqFLcIKpzGJAB;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				DrksRQEOwStfzQDAqFLcIKpzGJAB = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = meXwvgKCzmEFeAsXIAxKRJfMaGbwA(index);
				if (!BdUUyLncchXtCZOaSTGuYtSMcLyo(num))
				{
					throw new IndexOutOfRangeException();
				}
				return OvAvtaqWeanLOQHEVVsZqOnEIxoe[num];
			}
			set
			{
				int num = meXwvgKCzmEFeAsXIAxKRJfMaGbwA(index);
				if (!BdUUyLncchXtCZOaSTGuYtSMcLyo(num))
				{
					throw new IndexOutOfRangeException();
				}
				OvAvtaqWeanLOQHEVVsZqOnEIxoe[num] = value;
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
			OvAvtaqWeanLOQHEVVsZqOnEIxoe = new T[P_0];
			mIYfWUCkuwdJNaerIYelDinUoUFdb = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			ifwqjBRNoZZyvbzWqCcOBLBxkVTO = ((ifwqjBRNoZZyvbzWqCcOBLBxkVTO < mIYfWUCkuwdJNaerIYelDinUoUFdb - 1) ? (ifwqjBRNoZZyvbzWqCcOBLBxkVTO + 1) : 0);
			if (OAvfZeJTAiLWvvNWPJoVMqYaZuop == 0)
			{
				OevVtWIwOXGRxEjDQzUCUaTFxOJl = 0;
			}
			else if (ifwqjBRNoZZyvbzWqCcOBLBxkVTO == OevVtWIwOXGRxEjDQzUCUaTFxOJl)
			{
				OevVtWIwOXGRxEjDQzUCUaTFxOJl = ((OevVtWIwOXGRxEjDQzUCUaTFxOJl < mIYfWUCkuwdJNaerIYelDinUoUFdb - 1) ? (OevVtWIwOXGRxEjDQzUCUaTFxOJl + 1) : 0);
				kDKmIzoshZojSiwMrKpVDgBqCzmV++;
			}
			OvAvtaqWeanLOQHEVVsZqOnEIxoe[ifwqjBRNoZZyvbzWqCcOBLBxkVTO] = item;
			if (OAvfZeJTAiLWvvNWPJoVMqYaZuop < mIYfWUCkuwdJNaerIYelDinUoUFdb)
			{
				OAvfZeJTAiLWvvNWPJoVMqYaZuop++;
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
			if (OAvfZeJTAiLWvvNWPJoVMqYaZuop == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = OvAvtaqWeanLOQHEVVsZqOnEIxoe[OevVtWIwOXGRxEjDQzUCUaTFxOJl];
			if (OevVtWIwOXGRxEjDQzUCUaTFxOJl == ifwqjBRNoZZyvbzWqCcOBLBxkVTO)
			{
				Clear();
				return result;
			}
			OvAvtaqWeanLOQHEVVsZqOnEIxoe[OevVtWIwOXGRxEjDQzUCUaTFxOJl] = default(T);
			OevVtWIwOXGRxEjDQzUCUaTFxOJl = ((OevVtWIwOXGRxEjDQzUCUaTFxOJl < mIYfWUCkuwdJNaerIYelDinUoUFdb - 1) ? (OevVtWIwOXGRxEjDQzUCUaTFxOJl + 1) : 0);
			kDKmIzoshZojSiwMrKpVDgBqCzmV = 0;
			OAvfZeJTAiLWvvNWPJoVMqYaZuop--;
			mapEiGAzXutNYcTRQNkPBKChloYGb++;
			return result;
		}

		public T Peek()
		{
			if (ifwqjBRNoZZyvbzWqCcOBLBxkVTO < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return OvAvtaqWeanLOQHEVVsZqOnEIxoe[OevVtWIwOXGRxEjDQzUCUaTFxOJl];
		}

		public bool Contains(T item)
		{
			return pSSkUXqERjKCmslElUhVmYpBrCuL(item, DrksRQEOwStfzQDAqFLcIKpzGJAB) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return pSSkUXqERjKCmslElUhVmYpBrCuL(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, DrksRQEOwStfzQDAqFLcIKpzGJAB);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return sfHLbtLwxcktdOsxWAZqLgFZjsdD(pSSkUXqERjKCmslElUhVmYpBrCuL(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, DrksRQEOwStfzQDAqFLcIKpzGJAB);
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
			int num = pSSkUXqERjKCmslElUhVmYpBrCuL(item, comparer);
			if (num < 0)
			{
				return false;
			}
			JdZyPoXkuZNRkqcPzZPghdSBamdJ(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			JdZyPoXkuZNRkqcPzZPghdSBamdJ(meXwvgKCzmEFeAsXIAxKRJfMaGbwA(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, DrksRQEOwStfzQDAqFLcIKpzGJAB);
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
			if (OAvfZeJTAiLWvvNWPJoVMqYaZuop > 0)
			{
				if (ifwqjBRNoZZyvbzWqCcOBLBxkVTO >= OevVtWIwOXGRxEjDQzUCUaTFxOJl)
				{
					Array.Clear(OvAvtaqWeanLOQHEVVsZqOnEIxoe, OevVtWIwOXGRxEjDQzUCUaTFxOJl, ifwqjBRNoZZyvbzWqCcOBLBxkVTO - OevVtWIwOXGRxEjDQzUCUaTFxOJl + 1);
				}
				else
				{
					Array.Clear(OvAvtaqWeanLOQHEVVsZqOnEIxoe, 0, ifwqjBRNoZZyvbzWqCcOBLBxkVTO + 1);
					Array.Clear(OvAvtaqWeanLOQHEVVsZqOnEIxoe, OevVtWIwOXGRxEjDQzUCUaTFxOJl, mIYfWUCkuwdJNaerIYelDinUoUFdb - OevVtWIwOXGRxEjDQzUCUaTFxOJl);
				}
				OAvfZeJTAiLWvvNWPJoVMqYaZuop = 0;
			}
			ifwqjBRNoZZyvbzWqCcOBLBxkVTO = -1;
			OevVtWIwOXGRxEjDQzUCUaTFxOJl = -1;
			kDKmIzoshZojSiwMrKpVDgBqCzmV = 0;
			mapEiGAzXutNYcTRQNkPBKChloYGb++;
		}

		private int pMkoWhkBRSuilOdUbWBujchOzwl(T P_0)
		{
			return pSSkUXqERjKCmslElUhVmYpBrCuL(P_0, DrksRQEOwStfzQDAqFLcIKpzGJAB);
		}

		private int pSSkUXqERjKCmslElUhVmYpBrCuL(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (OAvfZeJTAiLWvvNWPJoVMqYaZuop == 0)
			{
				return -1;
			}
			if (ifwqjBRNoZZyvbzWqCcOBLBxkVTO >= OevVtWIwOXGRxEjDQzUCUaTFxOJl)
			{
				for (int i = OevVtWIwOXGRxEjDQzUCUaTFxOJl; i <= ifwqjBRNoZZyvbzWqCcOBLBxkVTO; i++)
				{
					if (P_1.Equals(OvAvtaqWeanLOQHEVVsZqOnEIxoe[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= ifwqjBRNoZZyvbzWqCcOBLBxkVTO; j++)
				{
					if (P_1.Equals(OvAvtaqWeanLOQHEVVsZqOnEIxoe[j], P_0))
					{
						return j;
					}
				}
				for (int k = OevVtWIwOXGRxEjDQzUCUaTFxOJl; k < mIYfWUCkuwdJNaerIYelDinUoUFdb; k++)
				{
					if (P_1.Equals(OvAvtaqWeanLOQHEVVsZqOnEIxoe[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void JdZyPoXkuZNRkqcPzZPghdSBamdJ(int P_0)
		{
			if (!BdUUyLncchXtCZOaSTGuYtSMcLyo(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == OevVtWIwOXGRxEjDQzUCUaTFxOJl)
			{
				Dequeue();
				return;
			}
			if (P_0 != ifwqjBRNoZZyvbzWqCcOBLBxkVTO)
			{
				if (ifwqjBRNoZZyvbzWqCcOBLBxkVTO > OevVtWIwOXGRxEjDQzUCUaTFxOJl)
				{
					Array.Copy(OvAvtaqWeanLOQHEVVsZqOnEIxoe, P_0 + 1, OvAvtaqWeanLOQHEVVsZqOnEIxoe, P_0, ifwqjBRNoZZyvbzWqCcOBLBxkVTO - P_0);
				}
				else if (P_0 < ifwqjBRNoZZyvbzWqCcOBLBxkVTO)
				{
					Array.Copy(OvAvtaqWeanLOQHEVVsZqOnEIxoe, P_0 + 1, OvAvtaqWeanLOQHEVVsZqOnEIxoe, P_0, ifwqjBRNoZZyvbzWqCcOBLBxkVTO - P_0);
				}
				else
				{
					Array.Copy(OvAvtaqWeanLOQHEVVsZqOnEIxoe, P_0 + 1, OvAvtaqWeanLOQHEVVsZqOnEIxoe, P_0, mIYfWUCkuwdJNaerIYelDinUoUFdb - P_0 - 1);
					OvAvtaqWeanLOQHEVVsZqOnEIxoe[mIYfWUCkuwdJNaerIYelDinUoUFdb - 1] = OvAvtaqWeanLOQHEVVsZqOnEIxoe[0];
					if (ifwqjBRNoZZyvbzWqCcOBLBxkVTO > 0)
					{
						Array.Copy(OvAvtaqWeanLOQHEVVsZqOnEIxoe, 1, OvAvtaqWeanLOQHEVVsZqOnEIxoe, 0, ifwqjBRNoZZyvbzWqCcOBLBxkVTO);
					}
				}
			}
			OvAvtaqWeanLOQHEVVsZqOnEIxoe[ifwqjBRNoZZyvbzWqCcOBLBxkVTO] = default(T);
			ifwqjBRNoZZyvbzWqCcOBLBxkVTO = ((ifwqjBRNoZZyvbzWqCcOBLBxkVTO > 0) ? (ifwqjBRNoZZyvbzWqCcOBLBxkVTO - 1) : (mIYfWUCkuwdJNaerIYelDinUoUFdb - 1));
			mapEiGAzXutNYcTRQNkPBKChloYGb++;
			OAvfZeJTAiLWvvNWPJoVMqYaZuop--;
		}

		private bool BdUUyLncchXtCZOaSTGuYtSMcLyo(int P_0)
		{
			if (OAvfZeJTAiLWvvNWPJoVMqYaZuop == 0)
			{
				return false;
			}
			if (ifwqjBRNoZZyvbzWqCcOBLBxkVTO >= OevVtWIwOXGRxEjDQzUCUaTFxOJl)
			{
				if (P_0 >= OevVtWIwOXGRxEjDQzUCUaTFxOJl)
				{
					return P_0 <= ifwqjBRNoZZyvbzWqCcOBLBxkVTO;
				}
				return false;
			}
			if (P_0 < OevVtWIwOXGRxEjDQzUCUaTFxOJl)
			{
				return P_0 <= ifwqjBRNoZZyvbzWqCcOBLBxkVTO;
			}
			return true;
		}

		private int sfHLbtLwxcktdOsxWAZqLgFZjsdD(int P_0)
		{
			if ((uint)P_0 >= (uint)mIYfWUCkuwdJNaerIYelDinUoUFdb)
			{
				return -1;
			}
			if (!BdUUyLncchXtCZOaSTGuYtSMcLyo(P_0))
			{
				return -1;
			}
			if (P_0 >= OevVtWIwOXGRxEjDQzUCUaTFxOJl)
			{
				return P_0 - OevVtWIwOXGRxEjDQzUCUaTFxOJl;
			}
			return P_0 + mIYfWUCkuwdJNaerIYelDinUoUFdb - OevVtWIwOXGRxEjDQzUCUaTFxOJl;
		}

		private int meXwvgKCzmEFeAsXIAxKRJfMaGbwA(int P_0)
		{
			if ((uint)P_0 >= (uint)OAvfZeJTAiLWvvNWPJoVMqYaZuop)
			{
				return -1;
			}
			P_0 = OevVtWIwOXGRxEjDQzUCUaTFxOJl + P_0;
			if (P_0 >= mIYfWUCkuwdJNaerIYelDinUoUFdb)
			{
				P_0 -= mIYfWUCkuwdJNaerIYelDinUoUFdb;
			}
			return P_0;
		}

		private void oaHlqlbiWCubnjJjEkQyaWIluwDT(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in oaHlqlbiWCubnjJjEkQyaWIluwDT
			this.oaHlqlbiWCubnjJjEkQyaWIluwDT(P_0);
		}

		private void UWHsqcoMKFAtjDcUsmRDrqaYPXALA()
		{
			Clear();
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in UWHsqcoMKFAtjDcUsmRDrqaYPXALA
			this.UWHsqcoMKFAtjDcUsmRDrqaYPXALA();
		}

		private bool AWtZcDHFZMlSIjToebOTiUqyTtKO(T P_0)
		{
			return Contains(P_0);
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AWtZcDHFZMlSIjToebOTiUqyTtKO
			return this.AWtZcDHFZMlSIjToebOTiUqyTtKO(P_0);
		}

		private void qVzPQNKIGPfOdGmuByLgziWnFDmHA(T[] P_0, int P_1)
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
			//ILSpy generated this explicit interface implementation from .override directive in qVzPQNKIGPfOdGmuByLgziWnFDmHA
			this.qVzPQNKIGPfOdGmuByLgziWnFDmHA(P_0, P_1);
		}

		private bool vvJIzWKMhXPfLssKNBmFNgknZpaV(T P_0)
		{
			return Remove(P_0);
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in vvJIzWKMhXPfLssKNBmFNgknZpaV
			return this.vvJIzWKMhXPfLssKNBmFNgknZpaV(P_0);
		}

		private IEnumerator<T> sNUgBcKqVgNGfmWQodxbSKJCwYCsA()
		{
			return new xUlSGxMHgrjbrNqAqQzktApWHJGJA(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in sNUgBcKqVgNGfmWQodxbSKJCwYCsA
			return this.sNUgBcKqVgNGfmWQodxbSKJCwYCsA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new xUlSGxMHgrjbrNqAqQzktApWHJGJA(this);
		}
	}
}
