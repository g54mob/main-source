using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data
{
	[Serializable]
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal sealed class RingBuffer<T> : IEnumerable, IEnumerable<T>, ICollection<T>
	{
		[Serializable]
		public struct XVDUHUtMnFxlFEKNawdyyVWCJrBG : IDisposable, IEnumerator, IEnumerator<T>
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal XVDUHUtMnFxlFEKNawdyyVWCJrBG(RingBuffer<T> P_0)
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

			private bool YUNzHBHdnPnnvPeZBmfosUxHsXub()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private readonly T[] wfNwuYXbSnYYfKrLRFIImChAmjMJ;

		private readonly int ngsUIyottIhptdyVRpkhbNqZCuLV;

		private int pNUldVennxMcquNJSgKcGSpQJxAG;

		private int BqFJAayKInfmJalyxnJShwSVnCCv;

		private int USiqMcuTBQSoQSZBWJUYFnznqukH;

		private int sTofmrqdNuJzVRWjnhBBoOWUYJGJ;

		private int CNDFoUJoeZozIXLwyWmfCLhOpTpJ;

		private IEqualityComparer<T> nbufZEcfFKaLWeibFrkRMurDRraZB;

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

		public T Item
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

		private int EPvJuGIgBEuxXfLjibGMtYlIOsHK(T P_0)
		{
			return 0;
		}

		private int EPvJuGIgBEuxXfLjibGMtYlIOsHK(T P_0, IEqualityComparer<T> P_1)
		{
			return 0;
		}

		private void qcVEijlXVjfkYEPidrokgChNidCt(int P_0)
		{
		}

		private bool klPuMQaoNkflyOaOdlhIKJjZNmYI(int P_0)
		{
			return false;
		}

		private int FYeWFVjWMuMXhceHxveVroaXXxPM(int P_0)
		{
			return 0;
		}

		private int QUAdOZJgEAcUoMzHrsqpGmfZIuju(int P_0)
		{
			return 0;
		}

		void ICollection<T>.Add(T P_0)
		{
		}

		void ICollection<T>.Clear()
		{
		}

		bool ICollection<T>.Contains(T P_0)
		{
			return false;
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
		}

		bool ICollection<T>.Remove(T P_0)
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
