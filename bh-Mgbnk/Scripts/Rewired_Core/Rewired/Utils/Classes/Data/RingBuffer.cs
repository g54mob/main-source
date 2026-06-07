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
		public struct gEYheYGUcuHwICUDNxFqvRHNRgnVA : IEnumerator<T>, IEnumerator, IDisposable
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal gEYheYGUcuHwICUDNxFqvRHNRgnVA(RingBuffer<T> P_0)
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

			private bool oKXKEryOycbSnkiXMcJkXdNNloOhA()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private readonly T[] PrfPZXsGmzgfaNUCurLIEmSRjNhB;

		private readonly int trhVyvQgytEMspScbcKbCFDTwbuU;

		private int hHFGJmLOoSZbQgHDLPCKtCdsVuyO;

		private int TvAxKpAOOYJRCLRGxXKCiHrQKXqI;

		private int RsGnEXDQExDlWciToQSJcdgbDLPH;

		private int rwfITIqhfMJzdrcPEHqTdZznQgPL;

		private int jfWUKfrPFnUrhKIEzdWDgiscOVxV;

		private IEqualityComparer<T> OwHYRyKATJaOUXIQLxaXyqKytGkE;

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

		private int mPfMslbLUUhXPgmMrsbLWhIqIiJj(T P_0)
		{
			return 0;
		}

		private int aahDOiyqNuOXDfYLYVeNUoJSPWLQ(T P_0, IEqualityComparer<T> P_1)
		{
			return 0;
		}

		private void AngKXANiXMWLhtUUKpyNLmgKTJUE(int P_0)
		{
		}

		private bool ItpcWohxussqlsGdzCyapmiVNiDbA(int P_0)
		{
			return false;
		}

		private int pocapABytlMlMHLnrdauKfAUoIGib(int P_0)
		{
			return 0;
		}

		private int pBogTBHOrtBCXYfYziPGdrHcFzCrB(int P_0)
		{
			return 0;
		}

		private void rVglQUzAWFuyGcbqpiqaYseqdVqFA(T P_0)
		{
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rVglQUzAWFuyGcbqpiqaYseqdVqFA
			this.rVglQUzAWFuyGcbqpiqaYseqdVqFA(P_0);
		}

		private void JPqFQDePKYaqGEpZFjvNeUOEToziB()
		{
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in JPqFQDePKYaqGEpZFjvNeUOEToziB
			this.JPqFQDePKYaqGEpZFjvNeUOEToziB();
		}

		private bool XdSZCcZFZTlVhyPdLeoVCPKxUSbO(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in XdSZCcZFZTlVhyPdLeoVCPKxUSbO
			return this.XdSZCcZFZTlVhyPdLeoVCPKxUSbO(P_0);
		}

		private void xeEricCtIAVRIXwjajLsHfgeoPZl(T[] P_0, int P_1)
		{
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in xeEricCtIAVRIXwjajLsHfgeoPZl
			this.xeEricCtIAVRIXwjajLsHfgeoPZl(P_0, P_1);
		}

		private bool wQglZhMIhUPcehrHcDQHnMQipONv(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wQglZhMIhUPcehrHcDQHnMQipONv
			return this.wQglZhMIhUPcehrHcDQHnMQipONv(P_0);
		}

		private IEnumerator<T> tHfudBkMBhfLIRSNLHFjkapNsznsA()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in tHfudBkMBhfLIRSNLHFjkapNsznsA
			return this.tHfudBkMBhfLIRSNLHFjkapNsznsA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
