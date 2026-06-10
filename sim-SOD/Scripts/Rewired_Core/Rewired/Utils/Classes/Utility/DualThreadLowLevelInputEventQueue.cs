using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private class nXnjpxdGKuhfPoteSWkOBYBvaCw : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
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

			public nXnjpxdGKuhfPoteSWkOBYBvaCw(object lockObject)
			{
			}
		}

		private readonly LowLevelInputEventQueue vNGBkxGETdFDGffJnVvlfJoTGoVd;

		private readonly LowLevelInputEventQueue QdVBpnkJkdhMOnyfvkdCfNyJoIe;

		private readonly object kKUIyUrEcehNAVEOeYKMNZLcnhc;

		private uint RmOnIhRAbrYqoBhEJvrxAxMKNwN;

		private bool bhILKHWbPTzCILWegjsGLkSPWBq;

		private int XPHNlaLWxkqvakBcEGOTDNepImJc;

		private int UeZbzIfokYfOzvLEiDKtIrojiyFy;

		private nXnjpxdGKuhfPoteSWkOBYBvaCw JWwNirJwDLNHweStXmqSOsSvrvT;

		public LowLevelInputEvent currentEvent;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public uint lastProcessedEventId => 0u;

		public int count => 0;

		public DualThreadLowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
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
