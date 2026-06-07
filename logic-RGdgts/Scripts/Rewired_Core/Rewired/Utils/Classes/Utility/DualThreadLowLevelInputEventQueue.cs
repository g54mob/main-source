using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class hnbcPwzyGAbMLeBDPagtJAbsHFnv : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
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

			public hnbcPwzyGAbMLeBDPagtJAbsHFnv(object P_0)
			{
			}
		}

		[CustomClassObfuscation]
		[CustomObfuscation]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private readonly LowLevelInputEventQueue xzQUmpMJAJNhirjkmLDahbLYHjUH;

		private readonly LowLevelInputEventQueue YrPExokdkJbVahAXeYyFxlJEJZjg;

		private readonly object gDQbBdAZYWOfjEXaRlqFCicQwYuq;

		private uint LZMVDuZlfRkwGBkwKdZmWPdLmFWm;

		private bool lUUWFUSKDnkKsTHWfpCLHvfAOkjx;

		private int RdBbojkBlORmAcyGPXeIiHLuLTWbb;

		private int KQPNkRihyyKwVRZizyxidKNbRlMG;

		private hnbcPwzyGAbMLeBDPagtJAbsHFnv HlkOMdNGazkNdincQvQrEVBwfAer;

		public LowLevelInputEvent currentEvent;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

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
