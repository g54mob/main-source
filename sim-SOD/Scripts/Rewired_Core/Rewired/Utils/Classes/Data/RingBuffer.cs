using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class RingBuffer<T> : IEnumerable, IEnumerable<T>, ICollection<T>
	{
		[Serializable]
		public struct FiBTpXzEnrvknEFxrYvneAfLDqM : IDisposable, IEnumerator, IEnumerator<T>
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal FiBTpXzEnrvknEFxrYvneAfLDqM(RingBuffer<T> buffer)
			{
				this.buffer = null;
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

			private bool IKDkuALExjevDFPAYcQekijIoXMa()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private readonly T[] eTRtaPZtYVEiPEBvEtTJomWFJRV;

		private readonly int rtqrHvewxklzNjBhCjGqlvHCVXC;

		private int hZUuXYcfrRISGgfdHMQvIEETuDT;

		private int ZeTeNrHuOZYwfLsIqujZUrjMJtDQ;

		private int KfkjVbkNTkIfeUlbJbtBFArwRRj;

		private int kFyaawiDJMpkpTVNyHbGaxSFlJV;

		private int UzDCLPHgqxwDwXMIxioeAcIRYMw;

		private IEqualityComparer<T> pKufABbQPiaVcAaVsXWKegIIASzf;

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

		public RingBuffer(int capacity)
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

		private int YElcbTjAFmMnrQbFzRgXllGDNrYE(T P_0)
		{
			return 0;
		}

		private int YElcbTjAFmMnrQbFzRgXllGDNrYE(T P_0, IEqualityComparer<T> P_1)
		{
			return 0;
		}

		private void ioFHeivJAHlcoIQzuTlvaGZKAZz(int P_0)
		{
		}

		private bool cxNluTogNUdhIKyEsPSJSTYIyKT(int P_0)
		{
			return false;
		}

		private int LlslGYlSYGHDTwqrubIQfxJOoCYA(int P_0)
		{
			return 0;
		}

		private int IGKycEJMTwEJOYvwoGJyMIlQVFq(int P_0)
		{
			return 0;
		}

		void ICollection<T>.Add(T item)
		{
		}

		void ICollection<T>.Clear()
		{
		}

		bool ICollection<T>.Contains(T item)
		{
			return false;
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
		}

		bool ICollection<T>.Remove(T item)
		{
			return false;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
