using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class HGLcqsgCnXbwhBakTPcbGYDeQwvyb : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
		{
			LowLevelInputEvent INewEventWrapper.Event
			{
				get
				{
					return item;
				}
				set
				{
					item = value;
				}
			}

			public HGLcqsgCnXbwhBakTPcbGYDeQwvyb(object P_0)
				: base(P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue aAdIPUSyNwPArFKlihJZfqXbKFdDA;

		private readonly LowLevelInputEventQueue KULYzxTQpnYeoSdkycbMwOzhJidK;

		private readonly object mDZZbUVNSsESYhAyONHYWvPwmHsYA;

		private uint OkQfiBvxWNMxzmoOUsKDkIzgJGGV;

		private bool MkheGCetHYIGIrhabREjVfZSHHer;

		private int VIafykAEhkRyPeNHHramdbmGMudi;

		private int FrzBGaehODscEGbWoYHOpDDNXwiA;

		private HGLcqsgCnXbwhBakTPcbGYDeQwvyb FKAtkdYpHxwzOiYwioDLnRZHBqg;

		public LowLevelInputEvent currentEvent;

		private bool nEWbHvbgETEcmrsPzeJzoIQEdRVoA;

		public uint lastProcessedEventId => OkQfiBvxWNMxzmoOUsKDkIzgJGGV;

		public int count
		{
			get
			{
				lock (mDZZbUVNSsESYhAyONHYWvPwmHsYA)
				{
					return aAdIPUSyNwPArFKlihJZfqXbKFdDA.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			aAdIPUSyNwPArFKlihJZfqXbKFdDA = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			KULYzxTQpnYeoSdkycbMwOzhJidK = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			mDZZbUVNSsESYhAyONHYWvPwmHsYA = new object();
			FKAtkdYpHxwzOiYwioDLnRZHBqg = new HGLcqsgCnXbwhBakTPcbGYDeQwvyb(mDZZbUVNSsESYhAyONHYWvPwmHsYA);
		}

		public INewEventWrapper T_CreateEvent()
		{
			FKAtkdYpHxwzOiYwioDLnRZHBqg.Lock();
			FKAtkdYpHxwzOiYwioDLnRZHBqg.item = KULYzxTQpnYeoSdkycbMwOzhJidK.CreateEvent();
			return FKAtkdYpHxwzOiYwioDLnRZHBqg;
		}

		public void Update()
		{
			lock (mDZZbUVNSsESYhAyONHYWvPwmHsYA)
			{
				aAdIPUSyNwPArFKlihJZfqXbKFdDA.CopyNewEventsFrom(KULYzxTQpnYeoSdkycbMwOzhJidK);
			}
		}

		public void Clear()
		{
			lock (mDZZbUVNSsESYhAyONHYWvPwmHsYA)
			{
				StopProcessingEvents();
				aAdIPUSyNwPArFKlihJZfqXbKFdDA.Clear();
				KULYzxTQpnYeoSdkycbMwOzhJidK.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (FrzBGaehODscEGbWoYHOpDDNXwiA == 0)
			{
				Update();
				int num = aAdIPUSyNwPArFKlihJZfqXbKFdDA.FindNextIndex(OkQfiBvxWNMxzmoOUsKDkIzgJGGV);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				FrzBGaehODscEGbWoYHOpDDNXwiA = num;
				MkheGCetHYIGIrhabREjVfZSHHer = true;
				VIafykAEhkRyPeNHHramdbmGMudi = aAdIPUSyNwPArFKlihJZfqXbKFdDA.Count;
			}
			if (FrzBGaehODscEGbWoYHOpDDNXwiA >= VIafykAEhkRyPeNHHramdbmGMudi)
			{
				currentEvent = default(LowLevelInputEvent);
				MkheGCetHYIGIrhabREjVfZSHHer = false;
				FrzBGaehODscEGbWoYHOpDDNXwiA = 0;
				return false;
			}
			if (aAdIPUSyNwPArFKlihJZfqXbKFdDA.TryGetNext(FrzBGaehODscEGbWoYHOpDDNXwiA, out currentEvent))
			{
				OkQfiBvxWNMxzmoOUsKDkIzgJGGV = currentEvent.GetId();
				FrzBGaehODscEGbWoYHOpDDNXwiA++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			MkheGCetHYIGIrhabREjVfZSHHer = false;
			FrzBGaehODscEGbWoYHOpDDNXwiA = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			MkheGCetHYIGIrhabREjVfZSHHer = false;
			FrzBGaehODscEGbWoYHOpDDNXwiA = 0;
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (other == this)
			{
				return;
			}
			lock (mDZZbUVNSsESYhAyONHYWvPwmHsYA)
			{
				lock (other.mDZZbUVNSsESYhAyONHYWvPwmHsYA)
				{
					aAdIPUSyNwPArFKlihJZfqXbKFdDA.CopyAllFrom(other.aAdIPUSyNwPArFKlihJZfqXbKFdDA);
					KULYzxTQpnYeoSdkycbMwOzhJidK.CopyAllFrom(other.KULYzxTQpnYeoSdkycbMwOzhJidK);
					OkQfiBvxWNMxzmoOUsKDkIzgJGGV = other.OkQfiBvxWNMxzmoOUsKDkIzgJGGV;
					MkheGCetHYIGIrhabREjVfZSHHer = other.MkheGCetHYIGIrhabREjVfZSHHer;
					VIafykAEhkRyPeNHHramdbmGMudi = other.VIafykAEhkRyPeNHHramdbmGMudi;
					FrzBGaehODscEGbWoYHOpDDNXwiA = other.FrzBGaehODscEGbWoYHOpDDNXwiA;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~DualThreadLowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (nEWbHvbgETEcmrsPzeJzoIQEdRVoA)
			{
				return;
			}
			if (disposing)
			{
				lock (mDZZbUVNSsESYhAyONHYWvPwmHsYA)
				{
					aAdIPUSyNwPArFKlihJZfqXbKFdDA.Dispose();
					KULYzxTQpnYeoSdkycbMwOzhJidK.Dispose();
				}
			}
			nEWbHvbgETEcmrsPzeJzoIQEdRVoA = true;
		}
	}
}
