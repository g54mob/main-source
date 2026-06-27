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
		public struct oGQYVtteLjgZcSlwMdVXPAmKHirdA : IEnumerator<T>, IEnumerator, IDisposable
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
					if (index == 0 || index == buffer.RgIYBicxjwnqmyygdlKaiqBccRFHA + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal oGQYVtteLjgZcSlwMdVXPAmKHirdA(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.bnSqUAQpkyzVLKdfoSIqcPRvPeti;
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
				if (version == buffer.bnSqUAQpkyzVLKdfoSIqcPRvPeti && (uint)index < (uint)buffer.RgIYBicxjwnqmyygdlKaiqBccRFHA)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return gSJsBOPBrpjgZcmqFLhNlggAaKAf();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool gSJsBOPBrpjgZcmqFLhNlggAaKAf()
			{
				if (version != buffer.bnSqUAQpkyzVLKdfoSIqcPRvPeti)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.RgIYBicxjwnqmyygdlKaiqBccRFHA + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.bnSqUAQpkyzVLKdfoSIqcPRvPeti)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] XjzFluVBleLFNPOptehcESFCbtLp;

		private readonly int purESCpnVgpOSxbBefUQGycYibgO;

		private int rzXjdNaDpNCBkayCQUxllCtzuHwD;

		private int FISsNOxOzJHkgPrlimPdiwQPWQuw;

		private int RgIYBicxjwnqmyygdlKaiqBccRFHA;

		private int dJjAwjJHIZgQXCxeJGaoszOqJABQA;

		private int bnSqUAQpkyzVLKdfoSIqcPRvPeti;

		private IEqualityComparer<T> GuVRgTzElQERaaFlOqnyDoTCdjySB = EqualityComparerNoAlloc<T>.Default;

		public int Count => RgIYBicxjwnqmyygdlKaiqBccRFHA;

		public int Capacity => purESCpnVgpOSxbBefUQGycYibgO;

		public int OverrunCount => dJjAwjJHIZgQXCxeJGaoszOqJABQA;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return GuVRgTzElQERaaFlOqnyDoTCdjySB;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				GuVRgTzElQERaaFlOqnyDoTCdjySB = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = xDczSkfcIkejvbvvicNxzcgKBjMbA(index);
				if (!EkbaLZCYJlNaFSNKcsvNwKXKgaZi(num))
				{
					throw new IndexOutOfRangeException();
				}
				return XjzFluVBleLFNPOptehcESFCbtLp[num];
			}
			set
			{
				int num = xDczSkfcIkejvbvvicNxzcgKBjMbA(index);
				if (!EkbaLZCYJlNaFSNKcsvNwKXKgaZi(num))
				{
					throw new IndexOutOfRangeException();
				}
				XjzFluVBleLFNPOptehcESFCbtLp[num] = value;
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
			XjzFluVBleLFNPOptehcESFCbtLp = new T[P_0];
			purESCpnVgpOSxbBefUQGycYibgO = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			rzXjdNaDpNCBkayCQUxllCtzuHwD = ((rzXjdNaDpNCBkayCQUxllCtzuHwD < purESCpnVgpOSxbBefUQGycYibgO - 1) ? (rzXjdNaDpNCBkayCQUxllCtzuHwD + 1) : 0);
			if (RgIYBicxjwnqmyygdlKaiqBccRFHA == 0)
			{
				FISsNOxOzJHkgPrlimPdiwQPWQuw = 0;
			}
			else if (rzXjdNaDpNCBkayCQUxllCtzuHwD == FISsNOxOzJHkgPrlimPdiwQPWQuw)
			{
				FISsNOxOzJHkgPrlimPdiwQPWQuw = ((FISsNOxOzJHkgPrlimPdiwQPWQuw < purESCpnVgpOSxbBefUQGycYibgO - 1) ? (FISsNOxOzJHkgPrlimPdiwQPWQuw + 1) : 0);
				dJjAwjJHIZgQXCxeJGaoszOqJABQA++;
			}
			XjzFluVBleLFNPOptehcESFCbtLp[rzXjdNaDpNCBkayCQUxllCtzuHwD] = item;
			if (RgIYBicxjwnqmyygdlKaiqBccRFHA < purESCpnVgpOSxbBefUQGycYibgO)
			{
				RgIYBicxjwnqmyygdlKaiqBccRFHA++;
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
			if (RgIYBicxjwnqmyygdlKaiqBccRFHA == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = XjzFluVBleLFNPOptehcESFCbtLp[FISsNOxOzJHkgPrlimPdiwQPWQuw];
			if (FISsNOxOzJHkgPrlimPdiwQPWQuw == rzXjdNaDpNCBkayCQUxllCtzuHwD)
			{
				Clear();
				return result;
			}
			XjzFluVBleLFNPOptehcESFCbtLp[FISsNOxOzJHkgPrlimPdiwQPWQuw] = default(T);
			FISsNOxOzJHkgPrlimPdiwQPWQuw = ((FISsNOxOzJHkgPrlimPdiwQPWQuw < purESCpnVgpOSxbBefUQGycYibgO - 1) ? (FISsNOxOzJHkgPrlimPdiwQPWQuw + 1) : 0);
			dJjAwjJHIZgQXCxeJGaoszOqJABQA = 0;
			RgIYBicxjwnqmyygdlKaiqBccRFHA--;
			bnSqUAQpkyzVLKdfoSIqcPRvPeti++;
			return result;
		}

		public T Peek()
		{
			if (rzXjdNaDpNCBkayCQUxllCtzuHwD < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return XjzFluVBleLFNPOptehcESFCbtLp[FISsNOxOzJHkgPrlimPdiwQPWQuw];
		}

		public bool Contains(T item)
		{
			return mnddiHgRsjjqnFdaZPksZUaHrMZSA(item, GuVRgTzElQERaaFlOqnyDoTCdjySB) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return mnddiHgRsjjqnFdaZPksZUaHrMZSA(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, GuVRgTzElQERaaFlOqnyDoTCdjySB);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return txygJxEySwoIyHROsOmTVrhHgISBb(mnddiHgRsjjqnFdaZPksZUaHrMZSA(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, GuVRgTzElQERaaFlOqnyDoTCdjySB);
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
			int num = mnddiHgRsjjqnFdaZPksZUaHrMZSA(item, comparer);
			if (num < 0)
			{
				return false;
			}
			EwsKaiyXZBpflfPbZbnJNMRDQZUn(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			EwsKaiyXZBpflfPbZbnJNMRDQZUn(xDczSkfcIkejvbvvicNxzcgKBjMbA(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, GuVRgTzElQERaaFlOqnyDoTCdjySB);
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
			if (RgIYBicxjwnqmyygdlKaiqBccRFHA > 0)
			{
				if (rzXjdNaDpNCBkayCQUxllCtzuHwD >= FISsNOxOzJHkgPrlimPdiwQPWQuw)
				{
					Array.Clear(XjzFluVBleLFNPOptehcESFCbtLp, FISsNOxOzJHkgPrlimPdiwQPWQuw, rzXjdNaDpNCBkayCQUxllCtzuHwD - FISsNOxOzJHkgPrlimPdiwQPWQuw + 1);
				}
				else
				{
					Array.Clear(XjzFluVBleLFNPOptehcESFCbtLp, 0, rzXjdNaDpNCBkayCQUxllCtzuHwD + 1);
					Array.Clear(XjzFluVBleLFNPOptehcESFCbtLp, FISsNOxOzJHkgPrlimPdiwQPWQuw, purESCpnVgpOSxbBefUQGycYibgO - FISsNOxOzJHkgPrlimPdiwQPWQuw);
				}
				RgIYBicxjwnqmyygdlKaiqBccRFHA = 0;
			}
			rzXjdNaDpNCBkayCQUxllCtzuHwD = -1;
			FISsNOxOzJHkgPrlimPdiwQPWQuw = -1;
			dJjAwjJHIZgQXCxeJGaoszOqJABQA = 0;
			bnSqUAQpkyzVLKdfoSIqcPRvPeti++;
		}

		private int cylnkOUCkPiCpemDqKeiCMjexQFNB(T P_0)
		{
			return mnddiHgRsjjqnFdaZPksZUaHrMZSA(P_0, GuVRgTzElQERaaFlOqnyDoTCdjySB);
		}

		private int mnddiHgRsjjqnFdaZPksZUaHrMZSA(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (RgIYBicxjwnqmyygdlKaiqBccRFHA == 0)
			{
				return -1;
			}
			if (rzXjdNaDpNCBkayCQUxllCtzuHwD >= FISsNOxOzJHkgPrlimPdiwQPWQuw)
			{
				for (int i = FISsNOxOzJHkgPrlimPdiwQPWQuw; i <= rzXjdNaDpNCBkayCQUxllCtzuHwD; i++)
				{
					if (P_1.Equals(XjzFluVBleLFNPOptehcESFCbtLp[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= rzXjdNaDpNCBkayCQUxllCtzuHwD; j++)
				{
					if (P_1.Equals(XjzFluVBleLFNPOptehcESFCbtLp[j], P_0))
					{
						return j;
					}
				}
				for (int k = FISsNOxOzJHkgPrlimPdiwQPWQuw; k < purESCpnVgpOSxbBefUQGycYibgO; k++)
				{
					if (P_1.Equals(XjzFluVBleLFNPOptehcESFCbtLp[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void EwsKaiyXZBpflfPbZbnJNMRDQZUn(int P_0)
		{
			if (!EkbaLZCYJlNaFSNKcsvNwKXKgaZi(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == FISsNOxOzJHkgPrlimPdiwQPWQuw)
			{
				Dequeue();
				return;
			}
			if (P_0 != rzXjdNaDpNCBkayCQUxllCtzuHwD)
			{
				if (rzXjdNaDpNCBkayCQUxllCtzuHwD > FISsNOxOzJHkgPrlimPdiwQPWQuw)
				{
					Array.Copy(XjzFluVBleLFNPOptehcESFCbtLp, P_0 + 1, XjzFluVBleLFNPOptehcESFCbtLp, P_0, rzXjdNaDpNCBkayCQUxllCtzuHwD - P_0);
				}
				else if (P_0 < rzXjdNaDpNCBkayCQUxllCtzuHwD)
				{
					Array.Copy(XjzFluVBleLFNPOptehcESFCbtLp, P_0 + 1, XjzFluVBleLFNPOptehcESFCbtLp, P_0, rzXjdNaDpNCBkayCQUxllCtzuHwD - P_0);
				}
				else
				{
					Array.Copy(XjzFluVBleLFNPOptehcESFCbtLp, P_0 + 1, XjzFluVBleLFNPOptehcESFCbtLp, P_0, purESCpnVgpOSxbBefUQGycYibgO - P_0 - 1);
					XjzFluVBleLFNPOptehcESFCbtLp[purESCpnVgpOSxbBefUQGycYibgO - 1] = XjzFluVBleLFNPOptehcESFCbtLp[0];
					if (rzXjdNaDpNCBkayCQUxllCtzuHwD > 0)
					{
						Array.Copy(XjzFluVBleLFNPOptehcESFCbtLp, 1, XjzFluVBleLFNPOptehcESFCbtLp, 0, rzXjdNaDpNCBkayCQUxllCtzuHwD);
					}
				}
			}
			XjzFluVBleLFNPOptehcESFCbtLp[rzXjdNaDpNCBkayCQUxllCtzuHwD] = default(T);
			rzXjdNaDpNCBkayCQUxllCtzuHwD = ((rzXjdNaDpNCBkayCQUxllCtzuHwD > 0) ? (rzXjdNaDpNCBkayCQUxllCtzuHwD - 1) : (purESCpnVgpOSxbBefUQGycYibgO - 1));
			bnSqUAQpkyzVLKdfoSIqcPRvPeti++;
			RgIYBicxjwnqmyygdlKaiqBccRFHA--;
		}

		private bool EkbaLZCYJlNaFSNKcsvNwKXKgaZi(int P_0)
		{
			if (RgIYBicxjwnqmyygdlKaiqBccRFHA == 0)
			{
				return false;
			}
			if (rzXjdNaDpNCBkayCQUxllCtzuHwD >= FISsNOxOzJHkgPrlimPdiwQPWQuw)
			{
				if (P_0 >= FISsNOxOzJHkgPrlimPdiwQPWQuw)
				{
					return P_0 <= rzXjdNaDpNCBkayCQUxllCtzuHwD;
				}
				return false;
			}
			if (P_0 < FISsNOxOzJHkgPrlimPdiwQPWQuw)
			{
				return P_0 <= rzXjdNaDpNCBkayCQUxllCtzuHwD;
			}
			return true;
		}

		private int txygJxEySwoIyHROsOmTVrhHgISBb(int P_0)
		{
			if ((uint)P_0 >= (uint)purESCpnVgpOSxbBefUQGycYibgO)
			{
				return -1;
			}
			if (!EkbaLZCYJlNaFSNKcsvNwKXKgaZi(P_0))
			{
				return -1;
			}
			if (P_0 >= FISsNOxOzJHkgPrlimPdiwQPWQuw)
			{
				return P_0 - FISsNOxOzJHkgPrlimPdiwQPWQuw;
			}
			return P_0 + purESCpnVgpOSxbBefUQGycYibgO - FISsNOxOzJHkgPrlimPdiwQPWQuw;
		}

		private int xDczSkfcIkejvbvvicNxzcgKBjMbA(int P_0)
		{
			if ((uint)P_0 >= (uint)RgIYBicxjwnqmyygdlKaiqBccRFHA)
			{
				return -1;
			}
			P_0 = FISsNOxOzJHkgPrlimPdiwQPWQuw + P_0;
			if (P_0 >= purESCpnVgpOSxbBefUQGycYibgO)
			{
				P_0 -= purESCpnVgpOSxbBefUQGycYibgO;
			}
			return P_0;
		}

		private void nYykybAxLQJVmcZSoqzHSTrbTvud(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in nYykybAxLQJVmcZSoqzHSTrbTvud
			this.nYykybAxLQJVmcZSoqzHSTrbTvud(P_0);
		}

		private void XckwHyTjEHFAwzuXSpmoCfCUwmhe()
		{
			Clear();
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in XckwHyTjEHFAwzuXSpmoCfCUwmhe
			this.XckwHyTjEHFAwzuXSpmoCfCUwmhe();
		}

		private bool FFUiiPoLuOuzXsAGCscwINxwMAtK(T P_0)
		{
			return Contains(P_0);
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FFUiiPoLuOuzXsAGCscwINxwMAtK
			return this.FFUiiPoLuOuzXsAGCscwINxwMAtK(P_0);
		}

		private void bNQyVRfmnDbeyDWMzMpVFgZjFcZY(T[] P_0, int P_1)
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
			//ILSpy generated this explicit interface implementation from .override directive in bNQyVRfmnDbeyDWMzMpVFgZjFcZY
			this.bNQyVRfmnDbeyDWMzMpVFgZjFcZY(P_0, P_1);
		}

		private bool kDwflKhJEPFHUlVkhOEujutdEwTf(T P_0)
		{
			return Remove(P_0);
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in kDwflKhJEPFHUlVkhOEujutdEwTf
			return this.kDwflKhJEPFHUlVkhOEujutdEwTf(P_0);
		}

		private IEnumerator<T> hUbLueRNomsJgBgsMhXOowUMMzzK()
		{
			return new oGQYVtteLjgZcSlwMdVXPAmKHirdA(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in hUbLueRNomsJgBgsMhXOowUMMzzK
			return this.hUbLueRNomsJgBgsMhXOowUMMzzK();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new oGQYVtteLjgZcSlwMdVXPAmKHirdA(this);
		}
	}
}
