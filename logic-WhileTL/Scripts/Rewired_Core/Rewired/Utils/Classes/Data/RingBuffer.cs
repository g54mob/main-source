using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class RingBuffer<T> : IEnumerable, IEnumerable<T>, ICollection<T>
	{
		[Serializable]
		public struct XVDUHUtMnFxlFEKNawdyyVWCJrBG : IDisposable, IEnumerator, IEnumerator<T>
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => current;

			object IEnumerator.Current
			{
				get
				{
					if (index == 0 || index == buffer.USiqMcuTBQSoQSZBWJUYFnznqukH + 1)
					{
						throw new InvalidOperationException();
					}
					return Current;
				}
			}

			internal XVDUHUtMnFxlFEKNawdyyVWCJrBG(RingBuffer<T> P_0)
			{
				buffer = P_0;
				index = 0;
				version = P_0.CNDFoUJoeZozIXLwyWmfCLhOpTpJ;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version == buffer.CNDFoUJoeZozIXLwyWmfCLhOpTpJ && (uint)index < (uint)buffer.USiqMcuTBQSoQSZBWJUYFnznqukH)
				{
					current = buffer[index];
					index++;
					return true;
				}
				return YUNzHBHdnPnnvPeZBmfosUxHsXub();
			}

			private bool YUNzHBHdnPnnvPeZBmfosUxHsXub()
			{
				if (version != buffer.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = buffer.USiqMcuTBQSoQSZBWJUYFnznqukH + 1;
				current = default(T);
				return false;
			}

			void IEnumerator.Reset()
			{
				if (version != buffer.CNDFoUJoeZozIXLwyWmfCLhOpTpJ)
				{
					throw new InvalidOperationException("RingBuffer was changed.");
				}
				index = 0;
				current = default(T);
			}
		}

		private readonly T[] wfNwuYXbSnYYfKrLRFIImChAmjMJ;

		private readonly int ngsUIyottIhptdyVRpkhbNqZCuLV;

		private int pNUldVennxMcquNJSgKcGSpQJxAG;

		private int BqFJAayKInfmJalyxnJShwSVnCCv;

		private int USiqMcuTBQSoQSZBWJUYFnznqukH;

		private int sTofmrqdNuJzVRWjnhBBoOWUYJGJ;

		private int CNDFoUJoeZozIXLwyWmfCLhOpTpJ;

		private IEqualityComparer<T> nbufZEcfFKaLWeibFrkRMurDRraZB = EqualityComparerNoAlloc<T>.Default;

		public int Count => USiqMcuTBQSoQSZBWJUYFnznqukH;

		public int Capacity => ngsUIyottIhptdyVRpkhbNqZCuLV;

		public int OverrunCount => sTofmrqdNuJzVRWjnhBBoOWUYJGJ;

		public IEqualityComparer<T> EqualityComparer
		{
			get
			{
				return nbufZEcfFKaLWeibFrkRMurDRraZB;
			}
			set
			{
				if (value == null)
				{
					value = EqualityComparerNoAlloc<T>.Default;
				}
				nbufZEcfFKaLWeibFrkRMurDRraZB = value;
			}
		}

		public T this[int index]
		{
			get
			{
				int num = QUAdOZJgEAcUoMzHrsqpGmfZIuju(index);
				if (!klPuMQaoNkflyOaOdlhIKJjZNmYI(num))
				{
					throw new IndexOutOfRangeException();
				}
				return wfNwuYXbSnYYfKrLRFIImChAmjMJ[num];
			}
			set
			{
				int num = QUAdOZJgEAcUoMzHrsqpGmfZIuju(index);
				if (!klPuMQaoNkflyOaOdlhIKJjZNmYI(num))
				{
					throw new IndexOutOfRangeException();
				}
				wfNwuYXbSnYYfKrLRFIImChAmjMJ[num] = value;
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
			wfNwuYXbSnYYfKrLRFIImChAmjMJ = new T[P_0];
			ngsUIyottIhptdyVRpkhbNqZCuLV = P_0;
			Clear();
		}

		public void Enqueue(T item)
		{
			pNUldVennxMcquNJSgKcGSpQJxAG = ((pNUldVennxMcquNJSgKcGSpQJxAG < ngsUIyottIhptdyVRpkhbNqZCuLV - 1) ? (pNUldVennxMcquNJSgKcGSpQJxAG + 1) : 0);
			if (USiqMcuTBQSoQSZBWJUYFnznqukH == 0)
			{
				BqFJAayKInfmJalyxnJShwSVnCCv = 0;
			}
			else if (pNUldVennxMcquNJSgKcGSpQJxAG == BqFJAayKInfmJalyxnJShwSVnCCv)
			{
				BqFJAayKInfmJalyxnJShwSVnCCv = ((BqFJAayKInfmJalyxnJShwSVnCCv < ngsUIyottIhptdyVRpkhbNqZCuLV - 1) ? (BqFJAayKInfmJalyxnJShwSVnCCv + 1) : 0);
				sTofmrqdNuJzVRWjnhBBoOWUYJGJ++;
			}
			wfNwuYXbSnYYfKrLRFIImChAmjMJ[pNUldVennxMcquNJSgKcGSpQJxAG] = item;
			if (USiqMcuTBQSoQSZBWJUYFnznqukH < ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				USiqMcuTBQSoQSZBWJUYFnznqukH++;
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
			if (USiqMcuTBQSoQSZBWJUYFnznqukH == 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			T result = wfNwuYXbSnYYfKrLRFIImChAmjMJ[BqFJAayKInfmJalyxnJShwSVnCCv];
			if (BqFJAayKInfmJalyxnJShwSVnCCv == pNUldVennxMcquNJSgKcGSpQJxAG)
			{
				Clear();
				return result;
			}
			wfNwuYXbSnYYfKrLRFIImChAmjMJ[BqFJAayKInfmJalyxnJShwSVnCCv] = default(T);
			BqFJAayKInfmJalyxnJShwSVnCCv = ((BqFJAayKInfmJalyxnJShwSVnCCv < ngsUIyottIhptdyVRpkhbNqZCuLV - 1) ? (BqFJAayKInfmJalyxnJShwSVnCCv + 1) : 0);
			sTofmrqdNuJzVRWjnhBBoOWUYJGJ = 0;
			USiqMcuTBQSoQSZBWJUYFnznqukH--;
			CNDFoUJoeZozIXLwyWmfCLhOpTpJ++;
			return result;
		}

		public T Peek()
		{
			if (pNUldVennxMcquNJSgKcGSpQJxAG < 0)
			{
				throw new Exception("There are no items in the buffer.");
			}
			return wfNwuYXbSnYYfKrLRFIImChAmjMJ[BqFJAayKInfmJalyxnJShwSVnCCv];
		}

		public bool Contains(T item)
		{
			return EPvJuGIgBEuxXfLjibGMtYlIOsHK(item, nbufZEcfFKaLWeibFrkRMurDRraZB) >= 0;
		}

		public bool Contains(T item, IEqualityComparer<T> comparer)
		{
			return EPvJuGIgBEuxXfLjibGMtYlIOsHK(item, comparer) >= 0;
		}

		public int IndexOf(T item)
		{
			return IndexOf(item, nbufZEcfFKaLWeibFrkRMurDRraZB);
		}

		public int IndexOf(T item, IEqualityComparer<T> comparer)
		{
			return FYeWFVjWMuMXhceHxveVroaXXxPM(EPvJuGIgBEuxXfLjibGMtYlIOsHK(item, comparer));
		}

		public bool Remove(T item)
		{
			return Remove(item, nbufZEcfFKaLWeibFrkRMurDRraZB);
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
			int num = EPvJuGIgBEuxXfLjibGMtYlIOsHK(item, comparer);
			if (num < 0)
			{
				return false;
			}
			qcVEijlXVjfkYEPidrokgChNidCt(num);
			return true;
		}

		public void RemoveAt(int index)
		{
			qcVEijlXVjfkYEPidrokgChNidCt(QUAdOZJgEAcUoMzHrsqpGmfZIuju(index));
		}

		public int RemoveAll(T item)
		{
			return RemoveAll(item, nbufZEcfFKaLWeibFrkRMurDRraZB);
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
			if (USiqMcuTBQSoQSZBWJUYFnznqukH > 0)
			{
				if (pNUldVennxMcquNJSgKcGSpQJxAG >= BqFJAayKInfmJalyxnJShwSVnCCv)
				{
					Array.Clear(wfNwuYXbSnYYfKrLRFIImChAmjMJ, BqFJAayKInfmJalyxnJShwSVnCCv, pNUldVennxMcquNJSgKcGSpQJxAG - BqFJAayKInfmJalyxnJShwSVnCCv + 1);
				}
				else
				{
					Array.Clear(wfNwuYXbSnYYfKrLRFIImChAmjMJ, 0, pNUldVennxMcquNJSgKcGSpQJxAG + 1);
					Array.Clear(wfNwuYXbSnYYfKrLRFIImChAmjMJ, BqFJAayKInfmJalyxnJShwSVnCCv, ngsUIyottIhptdyVRpkhbNqZCuLV - BqFJAayKInfmJalyxnJShwSVnCCv);
				}
				USiqMcuTBQSoQSZBWJUYFnznqukH = 0;
			}
			pNUldVennxMcquNJSgKcGSpQJxAG = -1;
			BqFJAayKInfmJalyxnJShwSVnCCv = -1;
			sTofmrqdNuJzVRWjnhBBoOWUYJGJ = 0;
			CNDFoUJoeZozIXLwyWmfCLhOpTpJ++;
		}

		private int EPvJuGIgBEuxXfLjibGMtYlIOsHK(T P_0)
		{
			return EPvJuGIgBEuxXfLjibGMtYlIOsHK(P_0, nbufZEcfFKaLWeibFrkRMurDRraZB);
		}

		private int EPvJuGIgBEuxXfLjibGMtYlIOsHK(T P_0, IEqualityComparer<T> P_1)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (USiqMcuTBQSoQSZBWJUYFnznqukH == 0)
			{
				return -1;
			}
			if (pNUldVennxMcquNJSgKcGSpQJxAG >= BqFJAayKInfmJalyxnJShwSVnCCv)
			{
				for (int i = BqFJAayKInfmJalyxnJShwSVnCCv; i <= pNUldVennxMcquNJSgKcGSpQJxAG; i++)
				{
					if (P_1.Equals(wfNwuYXbSnYYfKrLRFIImChAmjMJ[i], P_0))
					{
						return i;
					}
				}
			}
			else
			{
				for (int j = 0; j <= pNUldVennxMcquNJSgKcGSpQJxAG; j++)
				{
					if (P_1.Equals(wfNwuYXbSnYYfKrLRFIImChAmjMJ[j], P_0))
					{
						return j;
					}
				}
				for (int k = BqFJAayKInfmJalyxnJShwSVnCCv; k < ngsUIyottIhptdyVRpkhbNqZCuLV; k++)
				{
					if (P_1.Equals(wfNwuYXbSnYYfKrLRFIImChAmjMJ[k], P_0))
					{
						return k;
					}
				}
			}
			return -1;
		}

		private void qcVEijlXVjfkYEPidrokgChNidCt(int P_0)
		{
			if (!klPuMQaoNkflyOaOdlhIKJjZNmYI(P_0))
			{
				throw new IndexOutOfRangeException();
			}
			if (P_0 == BqFJAayKInfmJalyxnJShwSVnCCv)
			{
				Dequeue();
				return;
			}
			if (P_0 != pNUldVennxMcquNJSgKcGSpQJxAG)
			{
				if (pNUldVennxMcquNJSgKcGSpQJxAG > BqFJAayKInfmJalyxnJShwSVnCCv)
				{
					Array.Copy(wfNwuYXbSnYYfKrLRFIImChAmjMJ, P_0 + 1, wfNwuYXbSnYYfKrLRFIImChAmjMJ, P_0, pNUldVennxMcquNJSgKcGSpQJxAG - P_0);
				}
				else if (P_0 < pNUldVennxMcquNJSgKcGSpQJxAG)
				{
					Array.Copy(wfNwuYXbSnYYfKrLRFIImChAmjMJ, P_0 + 1, wfNwuYXbSnYYfKrLRFIImChAmjMJ, P_0, pNUldVennxMcquNJSgKcGSpQJxAG - P_0);
				}
				else
				{
					Array.Copy(wfNwuYXbSnYYfKrLRFIImChAmjMJ, P_0 + 1, wfNwuYXbSnYYfKrLRFIImChAmjMJ, P_0, ngsUIyottIhptdyVRpkhbNqZCuLV - P_0 - 1);
					wfNwuYXbSnYYfKrLRFIImChAmjMJ[ngsUIyottIhptdyVRpkhbNqZCuLV - 1] = wfNwuYXbSnYYfKrLRFIImChAmjMJ[0];
					if (pNUldVennxMcquNJSgKcGSpQJxAG > 0)
					{
						Array.Copy(wfNwuYXbSnYYfKrLRFIImChAmjMJ, 1, wfNwuYXbSnYYfKrLRFIImChAmjMJ, 0, pNUldVennxMcquNJSgKcGSpQJxAG);
					}
				}
			}
			wfNwuYXbSnYYfKrLRFIImChAmjMJ[pNUldVennxMcquNJSgKcGSpQJxAG] = default(T);
			pNUldVennxMcquNJSgKcGSpQJxAG = ((pNUldVennxMcquNJSgKcGSpQJxAG > 0) ? (pNUldVennxMcquNJSgKcGSpQJxAG - 1) : (ngsUIyottIhptdyVRpkhbNqZCuLV - 1));
			CNDFoUJoeZozIXLwyWmfCLhOpTpJ++;
			USiqMcuTBQSoQSZBWJUYFnznqukH--;
		}

		private bool klPuMQaoNkflyOaOdlhIKJjZNmYI(int P_0)
		{
			if (USiqMcuTBQSoQSZBWJUYFnznqukH == 0)
			{
				return false;
			}
			if (pNUldVennxMcquNJSgKcGSpQJxAG >= BqFJAayKInfmJalyxnJShwSVnCCv)
			{
				if (P_0 >= BqFJAayKInfmJalyxnJShwSVnCCv)
				{
					return P_0 <= pNUldVennxMcquNJSgKcGSpQJxAG;
				}
				return false;
			}
			if (P_0 < BqFJAayKInfmJalyxnJShwSVnCCv)
			{
				return P_0 <= pNUldVennxMcquNJSgKcGSpQJxAG;
			}
			return true;
		}

		private int FYeWFVjWMuMXhceHxveVroaXXxPM(int P_0)
		{
			if ((uint)P_0 >= (uint)ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				return -1;
			}
			if (!klPuMQaoNkflyOaOdlhIKJjZNmYI(P_0))
			{
				return -1;
			}
			if (P_0 >= BqFJAayKInfmJalyxnJShwSVnCCv)
			{
				return P_0 - BqFJAayKInfmJalyxnJShwSVnCCv;
			}
			return P_0 + ngsUIyottIhptdyVRpkhbNqZCuLV - BqFJAayKInfmJalyxnJShwSVnCCv;
		}

		private int QUAdOZJgEAcUoMzHrsqpGmfZIuju(int P_0)
		{
			if ((uint)P_0 >= (uint)USiqMcuTBQSoQSZBWJUYFnznqukH)
			{
				return -1;
			}
			P_0 = BqFJAayKInfmJalyxnJShwSVnCCv + P_0;
			if (P_0 >= ngsUIyottIhptdyVRpkhbNqZCuLV)
			{
				P_0 -= ngsUIyottIhptdyVRpkhbNqZCuLV;
			}
			return P_0;
		}

		void ICollection<T>.Add(T P_0)
		{
			Enqueue(P_0);
		}

		void ICollection<T>.Clear()
		{
			Clear();
		}

		bool ICollection<T>.Contains(T P_0)
		{
			return Contains(P_0);
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
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

		bool ICollection<T>.Remove(T P_0)
		{
			return Remove(P_0);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new XVDUHUtMnFxlFEKNawdyyVWCJrBG(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new XVDUHUtMnFxlFEKNawdyyVWCJrBG(this);
		}
	}
}
