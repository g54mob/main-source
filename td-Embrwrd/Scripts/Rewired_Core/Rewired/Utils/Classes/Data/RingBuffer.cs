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
		public struct zXUaSILGrfHEhaOdsnUSXXCvmedc : IEnumerator<T>, IEnumerator, IDisposable
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal zXUaSILGrfHEhaOdsnUSXXCvmedc(RingBuffer<T> P_0)
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

			private bool fRAEZpzqAxnojELOfzVQpiTruQTF()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private readonly T[] MbycLPgroeMZthbLBTDvMOizWrIGA;

		private readonly int sEqsSbFHMwtAwLatYjuVCwHpJzlS;

		private int ocQCVwUOEZDKQOmMyjechwdYHqvdA;

		private int IhZplfLHmLeoKdzZIpnuGijeeWzoA;

		private int MDBtpPGeegmkWQmSXfkxemcTdRCdA;

		private int cgoHQUtjNTIKhFJSvKYzAvfbREQTb;

		private int sxRIepwJdofLhyBTYsOfyxuEJAaH;

		private IEqualityComparer<T> VwSUIsJOkEEPYhkLuZThergMsxvO;

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

		private int jkoSEruYhDgGBYXvStKzMjCAqCIP(T P_0)
		{
			return 0;
		}

		private int dwoEEctebxOiLDGGbOQpSzJyDQKp(T P_0, IEqualityComparer<T> P_1)
		{
			return 0;
		}

		private void LjzEMFdCOTXzRhRTtNHUcPoaqTHZB(int P_0)
		{
		}

		private bool DaKEeZcOdEBbyimMWOOosczlkYxA(int P_0)
		{
			return false;
		}

		private int yfnIfEGjPkmAOjPqAmQMtEMgfURhA(int P_0)
		{
			return 0;
		}

		private int mArRTjDVHcjZAPJnMzoAhHFphdHD(int P_0)
		{
			return 0;
		}

		private void wXlOAWgEuOhNEItdCsCIIEgYCBfgA(T P_0)
		{
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in wXlOAWgEuOhNEItdCsCIIEgYCBfgA
			this.wXlOAWgEuOhNEItdCsCIIEgYCBfgA(P_0);
		}

		private void MudcCBzeaXoJSZQIsKRjSjIjRako()
		{
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MudcCBzeaXoJSZQIsKRjSjIjRako
			this.MudcCBzeaXoJSZQIsKRjSjIjRako();
		}

		private bool IqTKsyQdgCcMvQwNiICjAMVBObyc(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IqTKsyQdgCcMvQwNiICjAMVBObyc
			return this.IqTKsyQdgCcMvQwNiICjAMVBObyc(P_0);
		}

		private void eyDpdoBpqZAaMeruDbLKVFyWfqEQA(T[] P_0, int P_1)
		{
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in eyDpdoBpqZAaMeruDbLKVFyWfqEQA
			this.eyDpdoBpqZAaMeruDbLKVFyWfqEQA(P_0, P_1);
		}

		private bool rSlLalFaVFeRaRkMVsarxZSQOKUR(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in rSlLalFaVFeRaRkMVsarxZSQOKUR
			return this.rSlLalFaVFeRaRkMVsarxZSQOKUR(P_0);
		}

		private IEnumerator<T> kiolJTjJloytWbqGyrXFmBfrblkf()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in kiolJTjJloytWbqGyrXFmBfrblkf
			return this.kiolJTjJloytWbqGyrXFmBfrblkf();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
