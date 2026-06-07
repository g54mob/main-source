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
		public struct jjeHiAbNaiJEyOBhQFefHmSrQzjF : IEnumerator<T>, IEnumerator, IDisposable
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
					if (index == 0 || index == buffer.QheLMHmzhhHougftpXGIkldTWhJw + 1)
					{
						throw new InvalidOperationException();
					}
					return this.Current;
				}
			}

			internal jjeHiAbNaiJEyOBhQFefHmSrQzjF(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.sHolehGfgvxcLGXquYvOggvYtOlL;
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
				if (version == buffer.sHolehGfgvxcLGXquYvOggvYtOlL && (uint)index < (uint)buffer.QheLMHmzhhHougftpXGIkldTWhJw)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return tOdxAhHmViryZsNrPJPhhZKnEvCj();
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private bool tOdxAhHmViryZsNrPJPhhZKnEvCj()
			{
				if (version != buffer.sHolehGfgvxcLGXquYvOggvYtOlL)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.QheLMHmzhhHougftpXGIkldTWhJw + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.sHolehGfgvxcLGXquYvOggvYtOlL)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] YHDfmXhLjjtBNdBkhMfScCrCzTNyB;

		private readonly int aUBNWvpNOtjcMxWksSFwMSGrNlod;

		private int ufvasgkJDSKYkqfpGbKBxPcMsGmW;

		private int UDuRMnfMtMxiuBayaWVFspoaDyaV;

		private int QheLMHmzhhHougftpXGIkldTWhJw;

		private int sCLkpMPEMMAYRCttRqeIVdmRoiDPA;

		private int sHolehGfgvxcLGXquYvOggvYtOlL;

		private IEqualityComparer<T> FPrUhkxJnVaLaPTqKKzGyYnKFooG = EqualityComparerNoAlloc<T>.Default;

		public int Count => QheLMHmzhhHougftpXGIkldTWhJw;

		public int Capacity => aUBNWvpNOtjcMxWksSFwMSGrNlod;

		public int OverrunCount => sCLkpMPEMMAYRCttRqeIVdmRoiDPA;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return FPrUhkxJnVaLaPTqKKzGyYnKFooG;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				FPrUhkxJnVaLaPTqKKzGyYnKFooG = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = uxSsDitYelrvknuaeZbJxGdrPVKe(index);
				if (!BgNrDiWJrsLUDILEcuMnatThSOBE(num))
				{
					throw new IndexOutOfRangeException();
				}
				return YHDfmXhLjjtBNdBkhMfScCrCzTNyB[num];
			}
			set
			{
				int num = uxSsDitYelrvknuaeZbJxGdrPVKe(index);
				if (!BgNrDiWJrsLUDILEcuMnatThSOBE(num))
				{
					throw new IndexOutOfRangeException();
				}
				YHDfmXhLjjtBNdBkhMfScCrCzTNyB[num] = value;
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
			YHDfmXhLjjtBNdBkhMfScCrCzTNyB = new T[P_0];
			aUBNWvpNOtjcMxWksSFwMSGrNlod = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			ufvasgkJDSKYkqfpGbKBxPcMsGmW = ((ufvasgkJDSKYkqfpGbKBxPcMsGmW < aUBNWvpNOtjcMxWksSFwMSGrNlod - 1) ? (ufvasgkJDSKYkqfpGbKBxPcMsGmW + 1) : 0);
			if (QheLMHmzhhHougftpXGIkldTWhJw == 0)
			{
				UDuRMnfMtMxiuBayaWVFspoaDyaV = 0;
			}
			else if (ufvasgkJDSKYkqfpGbKBxPcMsGmW == UDuRMnfMtMxiuBayaWVFspoaDyaV)
			{
				UDuRMnfMtMxiuBayaWVFspoaDyaV = ((UDuRMnfMtMxiuBayaWVFspoaDyaV < aUBNWvpNOtjcMxWksSFwMSGrNlod - 1) ? (UDuRMnfMtMxiuBayaWVFspoaDyaV + 1) : 0);
				sCLkpMPEMMAYRCttRqeIVdmRoiDPA++;
			}
			YHDfmXhLjjtBNdBkhMfScCrCzTNyB[ufvasgkJDSKYkqfpGbKBxPcMsGmW] = item;
			if (QheLMHmzhhHougftpXGIkldTWhJw < aUBNWvpNOtjcMxWksSFwMSGrNlod)
			{
				QheLMHmzhhHougftpXGIkldTWhJw++;
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
			if (QheLMHmzhhHougftpXGIkldTWhJw == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = YHDfmXhLjjtBNdBkhMfScCrCzTNyB[UDuRMnfMtMxiuBayaWVFspoaDyaV];
			if (UDuRMnfMtMxiuBayaWVFspoaDyaV == ufvasgkJDSKYkqfpGbKBxPcMsGmW)
			{
				Clear();
				return result;
			}
			YHDfmXhLjjtBNdBkhMfScCrCzTNyB[UDuRMnfMtMxiuBayaWVFspoaDyaV] = default(T);
			UDuRMnfMtMxiuBayaWVFspoaDyaV = ((UDuRMnfMtMxiuBayaWVFspoaDyaV < aUBNWvpNOtjcMxWksSFwMSGrNlod - 1) ? (UDuRMnfMtMxiuBayaWVFspoaDyaV + 1) : 0);
			sCLkpMPEMMAYRCttRqeIVdmRoiDPA = 0;
			QheLMHmzhhHougftpXGIkldTWhJw--;
			sHolehGfgvxcLGXquYvOggvYtOlL++;
			return result;
		}

		public T Peek()
		{
			if (ufvasgkJDSKYkqfpGbKBxPcMsGmW < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return YHDfmXhLjjtBNdBkhMfScCrCzTNyB[UDuRMnfMtMxiuBayaWVFspoaDyaV];
		}

		public bool Contains(T item)
		{
			return pNRJhmDWgeJafrZjFwuUCAGcYiRy(item, FPrUhkxJnVaLaPTqKKzGyYnKFooG) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return pNRJhmDWgeJafrZjFwuUCAGcYiRy(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, FPrUhkxJnVaLaPTqKKzGyYnKFooG);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return qYKDCUwNMhQMaLQNkrwpjDNoOcUR(pNRJhmDWgeJafrZjFwuUCAGcYiRy(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, FPrUhkxJnVaLaPTqKKzGyYnKFooG);
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
			int num = pNRJhmDWgeJafrZjFwuUCAGcYiRy(item, comparer);
			if (num < 0)
			{
				return false;
			}
			BaCClXByNKcbpdluZFfpMXpaKfIAA(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			BaCClXByNKcbpdluZFfpMXpaKfIAA(uxSsDitYelrvknuaeZbJxGdrPVKe(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, FPrUhkxJnVaLaPTqKKzGyYnKFooG);
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
			if (QheLMHmzhhHougftpXGIkldTWhJw > 0)
			{
				if (ufvasgkJDSKYkqfpGbKBxPcMsGmW >= UDuRMnfMtMxiuBayaWVFspoaDyaV)
				{
					Array.Clear(YHDfmXhLjjtBNdBkhMfScCrCzTNyB, UDuRMnfMtMxiuBayaWVFspoaDyaV, ufvasgkJDSKYkqfpGbKBxPcMsGmW - UDuRMnfMtMxiuBayaWVFspoaDyaV + 1);
				}
				else
				{
					Array.Clear(YHDfmXhLjjtBNdBkhMfScCrCzTNyB, 0, ufvasgkJDSKYkqfpGbKBxPcMsGmW + 1);
					Array.Clear(YHDfmXhLjjtBNdBkhMfScCrCzTNyB, UDuRMnfMtMxiuBayaWVFspoaDyaV, aUBNWvpNOtjcMxWksSFwMSGrNlod - UDuRMnfMtMxiuBayaWVFspoaDyaV);
				}
				QheLMHmzhhHougftpXGIkldTWhJw = 0;
			}
			ufvasgkJDSKYkqfpGbKBxPcMsGmW = -1;
			UDuRMnfMtMxiuBayaWVFspoaDyaV = -1;
			sCLkpMPEMMAYRCttRqeIVdmRoiDPA = 0;
			sHolehGfgvxcLGXquYvOggvYtOlL++;
		}

		private int vWRXhzMdeWMGrewAwEgMWpHKkkHS(T P_0)
		{
			return pNRJhmDWgeJafrZjFwuUCAGcYiRy(P_0, FPrUhkxJnVaLaPTqKKzGyYnKFooG);
		}

		private int pNRJhmDWgeJafrZjFwuUCAGcYiRy(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (QheLMHmzhhHougftpXGIkldTWhJw == 0)
			{
				return -1;
			}
			if (ufvasgkJDSKYkqfpGbKBxPcMsGmW >= UDuRMnfMtMxiuBayaWVFspoaDyaV)
			{
				for (int i = UDuRMnfMtMxiuBayaWVFspoaDyaV; i <= ufvasgkJDSKYkqfpGbKBxPcMsGmW; i++)
				{
					if (P_1.Equals(YHDfmXhLjjtBNdBkhMfScCrCzTNyB[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= ufvasgkJDSKYkqfpGbKBxPcMsGmW; j++)
				{
					if (P_1.Equals(YHDfmXhLjjtBNdBkhMfScCrCzTNyB[j], P_0))
					{
						return j;
					}
				}
				for (int k = UDuRMnfMtMxiuBayaWVFspoaDyaV; k < aUBNWvpNOtjcMxWksSFwMSGrNlod; k++)
				{
					if (P_1.Equals(YHDfmXhLjjtBNdBkhMfScCrCzTNyB[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void BaCClXByNKcbpdluZFfpMXpaKfIAA(int P_0)
		{
			if (!BgNrDiWJrsLUDILEcuMnatThSOBE(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == UDuRMnfMtMxiuBayaWVFspoaDyaV)
			{
				Dequeue();
				return;
			}
			if (P_0 != ufvasgkJDSKYkqfpGbKBxPcMsGmW)
			{
				if (ufvasgkJDSKYkqfpGbKBxPcMsGmW > UDuRMnfMtMxiuBayaWVFspoaDyaV)
				{
					Array.Copy(YHDfmXhLjjtBNdBkhMfScCrCzTNyB, P_0 + 1, YHDfmXhLjjtBNdBkhMfScCrCzTNyB, P_0, ufvasgkJDSKYkqfpGbKBxPcMsGmW - P_0);
				}
				else if (P_0 < ufvasgkJDSKYkqfpGbKBxPcMsGmW)
				{
					Array.Copy(YHDfmXhLjjtBNdBkhMfScCrCzTNyB, P_0 + 1, YHDfmXhLjjtBNdBkhMfScCrCzTNyB, P_0, ufvasgkJDSKYkqfpGbKBxPcMsGmW - P_0);
				}
				else
				{
					Array.Copy(YHDfmXhLjjtBNdBkhMfScCrCzTNyB, P_0 + 1, YHDfmXhLjjtBNdBkhMfScCrCzTNyB, P_0, aUBNWvpNOtjcMxWksSFwMSGrNlod - P_0 - 1);
					YHDfmXhLjjtBNdBkhMfScCrCzTNyB[aUBNWvpNOtjcMxWksSFwMSGrNlod - 1] = YHDfmXhLjjtBNdBkhMfScCrCzTNyB[0];
					if (ufvasgkJDSKYkqfpGbKBxPcMsGmW > 0)
					{
						Array.Copy(YHDfmXhLjjtBNdBkhMfScCrCzTNyB, 1, YHDfmXhLjjtBNdBkhMfScCrCzTNyB, 0, ufvasgkJDSKYkqfpGbKBxPcMsGmW);
					}
				}
			}
			YHDfmXhLjjtBNdBkhMfScCrCzTNyB[ufvasgkJDSKYkqfpGbKBxPcMsGmW] = default(T);
			ufvasgkJDSKYkqfpGbKBxPcMsGmW = ((ufvasgkJDSKYkqfpGbKBxPcMsGmW > 0) ? (ufvasgkJDSKYkqfpGbKBxPcMsGmW - 1) : (aUBNWvpNOtjcMxWksSFwMSGrNlod - 1));
			sHolehGfgvxcLGXquYvOggvYtOlL++;
			QheLMHmzhhHougftpXGIkldTWhJw--;
		}

		private bool BgNrDiWJrsLUDILEcuMnatThSOBE(int P_0)
		{
			if (QheLMHmzhhHougftpXGIkldTWhJw == 0)
			{
				return false;
			}
			if (ufvasgkJDSKYkqfpGbKBxPcMsGmW >= UDuRMnfMtMxiuBayaWVFspoaDyaV)
			{
				if (P_0 >= UDuRMnfMtMxiuBayaWVFspoaDyaV)
				{
					return P_0 <= ufvasgkJDSKYkqfpGbKBxPcMsGmW;
				}
				return false;
			}
			if (P_0 < UDuRMnfMtMxiuBayaWVFspoaDyaV)
			{
				return P_0 <= ufvasgkJDSKYkqfpGbKBxPcMsGmW;
			}
			return true;
		}

		private int qYKDCUwNMhQMaLQNkrwpjDNoOcUR(int P_0)
		{
			if ((uint)P_0 >= (uint)aUBNWvpNOtjcMxWksSFwMSGrNlod)
			{
				return -1;
			}
			if (!BgNrDiWJrsLUDILEcuMnatThSOBE(P_0))
			{
				return -1;
			}
			if (P_0 >= UDuRMnfMtMxiuBayaWVFspoaDyaV)
			{
				return P_0 - UDuRMnfMtMxiuBayaWVFspoaDyaV;
			}
			return P_0 + aUBNWvpNOtjcMxWksSFwMSGrNlod - UDuRMnfMtMxiuBayaWVFspoaDyaV;
		}

		private int uxSsDitYelrvknuaeZbJxGdrPVKe(int P_0)
		{
			if ((uint)P_0 >= (uint)QheLMHmzhhHougftpXGIkldTWhJw)
			{
				return -1;
			}
			P_0 = UDuRMnfMtMxiuBayaWVFspoaDyaV + P_0;
			if (P_0 >= aUBNWvpNOtjcMxWksSFwMSGrNlod)
			{
				P_0 -= aUBNWvpNOtjcMxWksSFwMSGrNlod;
			}
			return P_0;
		}

		private void uDIlcIYNzDTzuiDCuafxEfjWAlko(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in uDIlcIYNzDTzuiDCuafxEfjWAlko
			this.uDIlcIYNzDTzuiDCuafxEfjWAlko(P_0);
		}

		private void QIIpJXDzjWHoglFhGbnIUuJtUsxJ()
		{
			Clear();
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in QIIpJXDzjWHoglFhGbnIUuJtUsxJ
			this.QIIpJXDzjWHoglFhGbnIUuJtUsxJ();
		}

		private bool KjmpQggquNmfDsbZYobSGUZNuctj(T P_0)
		{
			return Contains(P_0);
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KjmpQggquNmfDsbZYobSGUZNuctj
			return this.KjmpQggquNmfDsbZYobSGUZNuctj(P_0);
		}

		private void whwOEynHlUfuuDVVnjttCPxWYQTZ(T[] P_0, int P_1)
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
			//ILSpy generated this explicit interface implementation from .override directive in whwOEynHlUfuuDVVnjttCPxWYQTZ
			this.whwOEynHlUfuuDVVnjttCPxWYQTZ(P_0, P_1);
		}

		private bool lIIcBvbSCCJGYrOvhIgYrNTGshJl(T P_0)
		{
			return Remove(P_0);
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lIIcBvbSCCJGYrOvhIgYrNTGshJl
			return this.lIIcBvbSCCJGYrOvhIgYrNTGshJl(P_0);
		}

		private IEnumerator<T> oRZGlFTqibsVwJhzGLtyaampLqze()
		{
			return new jjeHiAbNaiJEyOBhQFefHmSrQzjF(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in oRZGlFTqibsVwJhzGLtyaampLqze
			return this.oRZGlFTqibsVwJhzGLtyaampLqze();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new jjeHiAbNaiJEyOBhQFefHmSrQzjF(this);
		}
	}
}
