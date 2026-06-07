using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class RAVVDSqKyRUiUxZbHjjsNAmMctUh : LockedObject<LowLevelInputEvent>, INewEventWrapper, IDisposable
		{
			public LowLevelInputEvent Event
			{
				get
				{
					return default(LowLevelInputEvent);
				}
				set
				{
				}
			}

			public RAVVDSqKyRUiUxZbHjjsNAmMctUh(object P_0)
			{
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue mlrGowCUawHaAbKSKoAAgnspbRUyb;

		private readonly LowLevelInputEventQueue OaTfAJXKQxcZVTbTmoeFfQOpVLAi;

		private readonly object gWJsWuXifcEqpXyLKgKTwGmelDTN;

		private uint AjAANrdrjNCZGjlnMRJUkhCgbIjuA;

		private bool WqzBDguJWOgenBkRtnMaASyEUHFcb;

		private int LKiQTKGopcpMuljyVoTtmhDUUQIF;

		private int VUjwhyabSKAAPLOMCFLQuMoXiTDw;

		private RAVVDSqKyRUiUxZbHjjsNAmMctUh DgSxoQreSPjHCRVxqlpWIQOJvFHX;

		public LowLevelInputEvent currentEvent;

		private bool jvKQgLqZfBnKFrJynGYeaZnKlDyeA;

		public uint lastProcessedEventId => 0u;

		public int count => 0;

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
		}

		public INewEventWrapper T_CreateEvent()
		{
			return null;
		}

		public void Update()
		{
		}

		public void Clear()
		{
		}

		public bool ProcessNewEvents()
		{
			return false;
		}

		public void StopProcessingEvents()
		{
		}

		public void ImportAll(DualThreadLowLevelInputEventQueue other)
		{
		}

		public void Dispose()
		{
		}

		~DualThreadLowLevelInputEventQueue()
		{
		}

		protected void Dispose(bool disposing)
		{
		}
	}
}
