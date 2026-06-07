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
		public struct jldlRmictCOLADdLuGxvswRamekw : IEnumerator<T>, IEnumerator, IDisposable
		{
			private RingBuffer<T> buffer;

			private int index;

			private int version;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal jldlRmictCOLADdLuGxvswRamekw(RingBuffer<T> P_0)
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

			private bool voiLnHSixOBylzKZpjdxIkRsgqTy()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		private readonly T[] UKMXWnIoTZCWjMvQRdJAvoqyHxCV;

		private readonly int wGlzRzufZDewPoqCbsopnPysrhqA;

		private int wAoIOWdUjoJPWltDceZFIwdBkudg;

		private int UBxkuDuZTyDpOKaIIHlFiJdxIQdcb;

		private int QfxeerjnBBYvOxEPRgkCjNgYOLEoA;

		private int ucARJiWTquvVrccLbnCMGHjOwIOX;

		private int sFrFXLPANVixUZAMMyIJHiTNFwRc;

		private IEqualityComparer<T> HpwcXIFyXtyEMnCQquTIeFsHMzvcA;

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

		private int vYYETJgTUgoDHadyOVGEedUJFKCWB(T P_0)
		{
			return 0;
		}

		private int rnOrVECDACAfPhaXvtQSdrNtyIApA(T P_0, IEqualityComparer<T> P_1)
		{
			return 0;
		}

		private void XCNvFrforgXwHqUKvJLnuoadODLv(int P_0)
		{
		}

		private bool FdKTPMRDdYOtrHAxMGBzHtiyuUUI(int P_0)
		{
			return false;
		}

		private int qAZnuapKoXyPUGozWnObGnMfYSRT(int P_0)
		{
			return 0;
		}

		private int sBPSKreEqFyCVuaIYHpVKsJasfFY(int P_0)
		{
			return 0;
		}

		private void uFZZjwDeTlhUGbbmQmExdKsZBFthA(T P_0)
		{
		}

		void ICollection<T>.Add(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in uFZZjwDeTlhUGbbmQmExdKsZBFthA
			this.uFZZjwDeTlhUGbbmQmExdKsZBFthA(P_0);
		}

		private void OjTDarYSHkEdCotLcLAYjeWgbewM()
		{
		}

		void ICollection<T>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OjTDarYSHkEdCotLcLAYjeWgbewM
			this.OjTDarYSHkEdCotLcLAYjeWgbewM();
		}

		private bool IJpNEGhYofrHnjbvoKJOdQKEMOkg(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Contains(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IJpNEGhYofrHnjbvoKJOdQKEMOkg
			return this.IJpNEGhYofrHnjbvoKJOdQKEMOkg(P_0);
		}

		private void skpHmQocReOvKKInPVRtwqwJVyIt(T[] P_0, int P_1)
		{
		}

		void ICollection<T>.CopyTo(T[] P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in skpHmQocReOvKKInPVRtwqwJVyIt
			this.skpHmQocReOvKKInPVRtwqwJVyIt(P_0, P_1);
		}

		private bool lKZSlLaZyeCQsgOZXkmQSmOJYjMj(T P_0)
		{
			return false;
		}

		bool ICollection<T>.Remove(T P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in lKZSlLaZyeCQsgOZXkmQSmOJYjMj
			return this.lKZSlLaZyeCQsgOZXkmQSmOJYjMj(P_0);
		}

		private IEnumerator<T> mYKsfrMULBdMeAPDclefHxWqhcOB()
		{
			return null;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in mYKsfrMULBdMeAPDclefHxWqhcOB
			return this.mYKsfrMULBdMeAPDclefHxWqhcOB();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
