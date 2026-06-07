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
		public struct bYfpYqmuYhhhRulapDqZakrztMOy : IEnumerator<T>, IEnumerator, IDisposable
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
					if (index == 0 || index == buffer.MBrZjFfuSuYTDAoUQrmmFOdVzGsD + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal bYfpYqmuYhhhRulapDqZakrztMOy(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.kvtEuTTelslTaaqzXCfoJqWOdxYu;
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
				if (version == buffer.kvtEuTTelslTaaqzXCfoJqWOdxYu && (uint)index < (uint)buffer.MBrZjFfuSuYTDAoUQrmmFOdVzGsD)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return zQgDaRHGShwJmqMcaccTaEvbvKbRb();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool zQgDaRHGShwJmqMcaccTaEvbvKbRb()
			{
				if (version != buffer.kvtEuTTelslTaaqzXCfoJqWOdxYu)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.MBrZjFfuSuYTDAoUQrmmFOdVzGsD + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.kvtEuTTelslTaaqzXCfoJqWOdxYu)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] YsIdUtSMkenwkvGvUUNgrPOlTtif;

		private readonly int uiUfGDoNOyrXxPXXXBrInSlbjDFV;

		private int aJuTzAxOITNiPQqybdpxIEJCxWXq;

		private int UytTGZkwDTEHLflOBcEdHKXwiCPk;

		private int MBrZjFfuSuYTDAoUQrmmFOdVzGsD;

		private int wzWgpeIiZPcAgRhiyJXsCjBDaamx;

		private int kvtEuTTelslTaaqzXCfoJqWOdxYu;

		private IEqualityComparer<T> BpuuFKcEeEhfHzsvtgAqTGISCRTBA = EqualityComparerNoAlloc<T>.Default;

		public int Count => MBrZjFfuSuYTDAoUQrmmFOdVzGsD;

		public int Capacity => uiUfGDoNOyrXxPXXXBrInSlbjDFV;

		public int OverrunCount => wzWgpeIiZPcAgRhiyJXsCjBDaamx;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return BpuuFKcEeEhfHzsvtgAqTGISCRTBA;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				BpuuFKcEeEhfHzsvtgAqTGISCRTBA = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = oaRSjdaCHuhZUbBtDKonhEdpXHxhb(index);
				if (!DzOreOTcKpxngyJANGJNANEjzKoz(num))
				{
					throw new IndexOutOfRangeException();
				}
				return YsIdUtSMkenwkvGvUUNgrPOlTtif[num];
			}
			set
			{
				int num = oaRSjdaCHuhZUbBtDKonhEdpXHxhb(index);
				if (!DzOreOTcKpxngyJANGJNANEjzKoz(num))
				{
					throw new IndexOutOfRangeException();
				}
				YsIdUtSMkenwkvGvUUNgrPOlTtif[num] = value;
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
			YsIdUtSMkenwkvGvUUNgrPOlTtif = new T[P_0];
			uiUfGDoNOyrXxPXXXBrInSlbjDFV = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			aJuTzAxOITNiPQqybdpxIEJCxWXq = ((aJuTzAxOITNiPQqybdpxIEJCxWXq < uiUfGDoNOyrXxPXXXBrInSlbjDFV - 1) ? (aJuTzAxOITNiPQqybdpxIEJCxWXq + 1) : 0);
			if (MBrZjFfuSuYTDAoUQrmmFOdVzGsD == 0)
			{
				UytTGZkwDTEHLflOBcEdHKXwiCPk = 0;
			}
			else if (aJuTzAxOITNiPQqybdpxIEJCxWXq == UytTGZkwDTEHLflOBcEdHKXwiCPk)
			{
				UytTGZkwDTEHLflOBcEdHKXwiCPk = ((UytTGZkwDTEHLflOBcEdHKXwiCPk < uiUfGDoNOyrXxPXXXBrInSlbjDFV - 1) ? (UytTGZkwDTEHLflOBcEdHKXwiCPk + 1) : 0);
				wzWgpeIiZPcAgRhiyJXsCjBDaamx++;
			}
			YsIdUtSMkenwkvGvUUNgrPOlTtif[aJuTzAxOITNiPQqybdpxIEJCxWXq] = item;
			if (MBrZjFfuSuYTDAoUQrmmFOdVzGsD < uiUfGDoNOyrXxPXXXBrInSlbjDFV)
			{
				MBrZjFfuSuYTDAoUQrmmFOdVzGsD++;
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
			if (MBrZjFfuSuYTDAoUQrmmFOdVzGsD == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = YsIdUtSMkenwkvGvUUNgrPOlTtif[UytTGZkwDTEHLflOBcEdHKXwiCPk];
			if (UytTGZkwDTEHLflOBcEdHKXwiCPk == aJuTzAxOITNiPQqybdpxIEJCxWXq)
			{
				Clear();
				return result;
			}
			YsIdUtSMkenwkvGvUUNgrPOlTtif[UytTGZkwDTEHLflOBcEdHKXwiCPk] = default(T);
			UytTGZkwDTEHLflOBcEdHKXwiCPk = ((UytTGZkwDTEHLflOBcEdHKXwiCPk < uiUfGDoNOyrXxPXXXBrInSlbjDFV - 1) ? (UytTGZkwDTEHLflOBcEdHKXwiCPk + 1) : 0);
			wzWgpeIiZPcAgRhiyJXsCjBDaamx = 0;
			MBrZjFfuSuYTDAoUQrmmFOdVzGsD--;
			kvtEuTTelslTaaqzXCfoJqWOdxYu++;
			return result;
		}

		public T Peek()
		{
			if (aJuTzAxOITNiPQqybdpxIEJCxWXq < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return YsIdUtSMkenwkvGvUUNgrPOlTtif[UytTGZkwDTEHLflOBcEdHKXwiCPk];
		}

		public bool Contains(T item)
		{
			return twMyeSAfzfYEQVTcqDhezIncfusP(item, BpuuFKcEeEhfHzsvtgAqTGISCRTBA) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return twMyeSAfzfYEQVTcqDhezIncfusP(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, BpuuFKcEeEhfHzsvtgAqTGISCRTBA);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return eiBRMchZouwEHzWPZXYPGcpiksbE(twMyeSAfzfYEQVTcqDhezIncfusP(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, BpuuFKcEeEhfHzsvtgAqTGISCRTBA);
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
			int num = twMyeSAfzfYEQVTcqDhezIncfusP(item, comparer);
			if (num < 0)
			{
				return false;
			}
			LhPcytzkMPRrMFgrqOSVuECotydi(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			LhPcytzkMPRrMFgrqOSVuECotydi(oaRSjdaCHuhZUbBtDKonhEdpXHxhb(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, BpuuFKcEeEhfHzsvtgAqTGISCRTBA);
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
			if (MBrZjFfuSuYTDAoUQrmmFOdVzGsD > 0)
			{
				if (aJuTzAxOITNiPQqybdpxIEJCxWXq >= UytTGZkwDTEHLflOBcEdHKXwiCPk)
				{
					Array.Clear(YsIdUtSMkenwkvGvUUNgrPOlTtif, UytTGZkwDTEHLflOBcEdHKXwiCPk, aJuTzAxOITNiPQqybdpxIEJCxWXq - UytTGZkwDTEHLflOBcEdHKXwiCPk + 1);
				}
				else
				{
					Array.Clear(YsIdUtSMkenwkvGvUUNgrPOlTtif, 0, aJuTzAxOITNiPQqybdpxIEJCxWXq + 1);
					Array.Clear(YsIdUtSMkenwkvGvUUNgrPOlTtif, UytTGZkwDTEHLflOBcEdHKXwiCPk, uiUfGDoNOyrXxPXXXBrInSlbjDFV - UytTGZkwDTEHLflOBcEdHKXwiCPk);
				}
				MBrZjFfuSuYTDAoUQrmmFOdVzGsD = 0;
			}
			aJuTzAxOITNiPQqybdpxIEJCxWXq = -1;
			UytTGZkwDTEHLflOBcEdHKXwiCPk = -1;
			wzWgpeIiZPcAgRhiyJXsCjBDaamx = 0;
			kvtEuTTelslTaaqzXCfoJqWOdxYu++;
		}

		private int bgUboPPIrVckAcSVDjPoudmOKuoUA(T P_0)
		{
			return twMyeSAfzfYEQVTcqDhezIncfusP(P_0, BpuuFKcEeEhfHzsvtgAqTGISCRTBA);
		}

		private int twMyeSAfzfYEQVTcqDhezIncfusP(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (MBrZjFfuSuYTDAoUQrmmFOdVzGsD == 0)
			{
				return -1;
			}
			if (aJuTzAxOITNiPQqybdpxIEJCxWXq >= UytTGZkwDTEHLflOBcEdHKXwiCPk)
			{
				for (int i = UytTGZkwDTEHLflOBcEdHKXwiCPk; i <= aJuTzAxOITNiPQqybdpxIEJCxWXq; i++)
				{
					if (P_1.Equals(YsIdUtSMkenwkvGvUUNgrPOlTtif[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= aJuTzAxOITNiPQqybdpxIEJCxWXq; j++)
				{
					if (P_1.Equals(YsIdUtSMkenwkvGvUUNgrPOlTtif[j], P_0))
					{
						return j;
					}
				}
				for (int k = UytTGZkwDTEHLflOBcEdHKXwiCPk; k < uiUfGDoNOyrXxPXXXBrInSlbjDFV; k++)
				{
					if (P_1.Equals(YsIdUtSMkenwkvGvUUNgrPOlTtif[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void LhPcytzkMPRrMFgrqOSVuECotydi(int P_0)
		{
			if (!DzOreOTcKpxngyJANGJNANEjzKoz(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == UytTGZkwDTEHLflOBcEdHKXwiCPk)
			{
				Dequeue();
				return;
			}
			if (P_0 != aJuTzAxOITNiPQqybdpxIEJCxWXq)
			{
				if (aJuTzAxOITNiPQqybdpxIEJCxWXq > UytTGZkwDTEHLflOBcEdHKXwiCPk)
				{
					Array.Copy(YsIdUtSMkenwkvGvUUNgrPOlTtif, P_0 + 1, YsIdUtSMkenwkvGvUUNgrPOlTtif, P_0, aJuTzAxOITNiPQqybdpxIEJCxWXq - P_0);
				}
				else if (P_0 < aJuTzAxOITNiPQqybdpxIEJCxWXq)
				{
					Array.Copy(YsIdUtSMkenwkvGvUUNgrPOlTtif, P_0 + 1, YsIdUtSMkenwkvGvUUNgrPOlTtif, P_0, aJuTzAxOITNiPQqybdpxIEJCxWXq - P_0);
				}
				else
				{
					Array.Copy(YsIdUtSMkenwkvGvUUNgrPOlTtif, P_0 + 1, YsIdUtSMkenwkvGvUUNgrPOlTtif, P_0, uiUfGDoNOyrXxPXXXBrInSlbjDFV - P_0 - 1);
					YsIdUtSMkenwkvGvUUNgrPOlTtif[uiUfGDoNOyrXxPXXXBrInSlbjDFV - 1] = YsIdUtSMkenwkvGvUUNgrPOlTtif[0];
					if (aJuTzAxOITNiPQqybdpxIEJCxWXq > 0)
					{
						Array.Copy(YsIdUtSMkenwkvGvUUNgrPOlTtif, 1, YsIdUtSMkenwkvGvUUNgrPOlTtif, 0, aJuTzAxOITNiPQqybdpxIEJCxWXq);
					}
				}
			}
			YsIdUtSMkenwkvGvUUNgrPOlTtif[aJuTzAxOITNiPQqybdpxIEJCxWXq] = default(T);
			aJuTzAxOITNiPQqybdpxIEJCxWXq = ((aJuTzAxOITNiPQqybdpxIEJCxWXq > 0) ? (aJuTzAxOITNiPQqybdpxIEJCxWXq - 1) : (uiUfGDoNOyrXxPXXXBrInSlbjDFV - 1));
			kvtEuTTelslTaaqzXCfoJqWOdxYu++;
			MBrZjFfuSuYTDAoUQrmmFOdVzGsD--;
		}

		private bool DzOreOTcKpxngyJANGJNANEjzKoz(int P_0)
		{
			if (MBrZjFfuSuYTDAoUQrmmFOdVzGsD == 0)
			{
				return false;
			}
			if (aJuTzAxOITNiPQqybdpxIEJCxWXq >= UytTGZkwDTEHLflOBcEdHKXwiCPk)
			{
				if (P_0 >= UytTGZkwDTEHLflOBcEdHKXwiCPk)
				{
					return P_0 <= aJuTzAxOITNiPQqybdpxIEJCxWXq;
				}
				return false;
			}
			if (P_0 < UytTGZkwDTEHLflOBcEdHKXwiCPk)
			{
				return P_0 <= aJuTzAxOITNiPQqybdpxIEJCxWXq;
			}
			return true;
		}

		private int eiBRMchZouwEHzWPZXYPGcpiksbE(int P_0)
		{
			if ((uint)P_0 >= (uint)uiUfGDoNOyrXxPXXXBrInSlbjDFV)
			{
				return -1;
			}
			if (!DzOreOTcKpxngyJANGJNANEjzKoz(P_0))
			{
				return -1;
			}
			if (P_0 >= UytTGZkwDTEHLflOBcEdHKXwiCPk)
			{
				return P_0 - UytTGZkwDTEHLflOBcEdHKXwiCPk;
			}
			return P_0 + uiUfGDoNOyrXxPXXXBrInSlbjDFV - UytTGZkwDTEHLflOBcEdHKXwiCPk;
		}

		private int oaRSjdaCHuhZUbBtDKonhEdpXHxhb(int P_0)
		{
			if ((uint)P_0 >= (uint)MBrZjFfuSuYTDAoUQrmmFOdVzGsD)
			{
				return -1;
			}
			P_0 = UytTGZkwDTEHLflOBcEdHKXwiCPk + P_0;
			if (P_0 >= uiUfGDoNOyrXxPXXXBrInSlbjDFV)
			{
				P_0 -= uiUfGDoNOyrXxPXXXBrInSlbjDFV;
			}
			return P_0;
		}

		private void egBDmyANsGPbBeKRFBJXMlADGzJPd(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in egBDmyANsGPbBeKRFBJXMlADGzJPd
			this.egBDmyANsGPbBeKRFBJXMlADGzJPd(P_0);
		}

		private void GZXtqlGouZolRDQcfeSiHbarLWKYA()
		{
			Clear();
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GZXtqlGouZolRDQcfeSiHbarLWKYA
			this.GZXtqlGouZolRDQcfeSiHbarLWKYA();
		}

		private bool WWrhgYzCbClOaOxQpcHexmoXisAZ(T P_0)
		{
			return Contains(P_0);
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in WWrhgYzCbClOaOxQpcHexmoXisAZ
			return this.WWrhgYzCbClOaOxQpcHexmoXisAZ(P_0);
		}

		private void ijXXUdkwXVMDrdOUUGZukWYOAoEb(T[] P_0, int P_1)
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
			//ILSpy generated this explicit interface implementation from .override directive in ijXXUdkwXVMDrdOUUGZukWYOAoEb
			this.ijXXUdkwXVMDrdOUUGZukWYOAoEb(P_0, P_1);
		}

		private bool zABDhFJsVNZzpNNgCMhsISoYKicSA(T P_0)
		{
			return Remove(P_0);
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zABDhFJsVNZzpNNgCMhsISoYKicSA
			return this.zABDhFJsVNZzpNNgCMhsISoYKicSA(P_0);
		}

		private IEnumerator<T> aIQgBlMdtscUBCnirpiCeLBInPKNB()
		{
			return new bYfpYqmuYhhhRulapDqZakrztMOy(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in aIQgBlMdtscUBCnirpiCeLBInPKNB
			return this.aIQgBlMdtscUBCnirpiCeLBInPKNB();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new bYfpYqmuYhhhRulapDqZakrztMOy(this);
		}
	}
}
