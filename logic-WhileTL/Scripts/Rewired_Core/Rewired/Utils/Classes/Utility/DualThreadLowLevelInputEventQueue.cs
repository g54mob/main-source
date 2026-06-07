using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		private class hnbcPwzyGAbMLeBDPagtJAbsHFnv : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
		{
			public LowLevelInputEvent Event
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

			public hnbcPwzyGAbMLeBDPagtJAbsHFnv(object P_0)
				: base(P_0)
			{
			}
		}

		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
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

		public uint lastProcessedEventId => LZMVDuZlfRkwGBkwKdZmWPdLmFWm;

		public int count
		{
			get
			{
				lock (gDQbBdAZYWOfjEXaRlqFCicQwYuq)
				{
					return xzQUmpMJAJNhirjkmLDahbLYHjUH.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			xzQUmpMJAJNhirjkmLDahbLYHjUH = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			YrPExokdkJbVahAXeYyFxlJEJZjg = new LowLevelInputEventQueue(P_0, P_1, P_2, P_3);
			gDQbBdAZYWOfjEXaRlqFCicQwYuq = new object();
			HlkOMdNGazkNdincQvQrEVBwfAer = new hnbcPwzyGAbMLeBDPagtJAbsHFnv(gDQbBdAZYWOfjEXaRlqFCicQwYuq);
		}

		public INewEventWrapper T_CreateEvent()
		{
			HlkOMdNGazkNdincQvQrEVBwfAer.Lock();
			HlkOMdNGazkNdincQvQrEVBwfAer.item = YrPExokdkJbVahAXeYyFxlJEJZjg.CreateEvent();
			return HlkOMdNGazkNdincQvQrEVBwfAer;
		}

		public void Update()
		{
			lock (gDQbBdAZYWOfjEXaRlqFCicQwYuq)
			{
				xzQUmpMJAJNhirjkmLDahbLYHjUH.CopyNewEventsFrom(YrPExokdkJbVahAXeYyFxlJEJZjg);
			}
		}

		public void Clear()
		{
			lock (gDQbBdAZYWOfjEXaRlqFCicQwYuq)
			{
				StopProcessingEvents();
				xzQUmpMJAJNhirjkmLDahbLYHjUH.Clear();
				YrPExokdkJbVahAXeYyFxlJEJZjg.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (KQPNkRihyyKwVRZizyxidKNbRlMG == 0)
			{
				Update();
				int num = xzQUmpMJAJNhirjkmLDahbLYHjUH.FindNextIndex(LZMVDuZlfRkwGBkwKdZmWPdLmFWm);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				KQPNkRihyyKwVRZizyxidKNbRlMG = num;
				lUUWFUSKDnkKsTHWfpCLHvfAOkjx = true;
				RdBbojkBlORmAcyGPXeIiHLuLTWbb = xzQUmpMJAJNhirjkmLDahbLYHjUH.Count;
			}
			if (KQPNkRihyyKwVRZizyxidKNbRlMG >= RdBbojkBlORmAcyGPXeIiHLuLTWbb)
			{
				currentEvent = default(LowLevelInputEvent);
				lUUWFUSKDnkKsTHWfpCLHvfAOkjx = false;
				KQPNkRihyyKwVRZizyxidKNbRlMG = 0;
				return false;
			}
			if (xzQUmpMJAJNhirjkmLDahbLYHjUH.TryGetNext(KQPNkRihyyKwVRZizyxidKNbRlMG, out currentEvent))
			{
				LZMVDuZlfRkwGBkwKdZmWPdLmFWm = currentEvent.GetId();
				KQPNkRihyyKwVRZizyxidKNbRlMG++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			lUUWFUSKDnkKsTHWfpCLHvfAOkjx = false;
			KQPNkRihyyKwVRZizyxidKNbRlMG = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			lUUWFUSKDnkKsTHWfpCLHvfAOkjx = false;
			KQPNkRihyyKwVRZizyxidKNbRlMG = 0;
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
			lock (gDQbBdAZYWOfjEXaRlqFCicQwYuq)
			{
				lock (other.gDQbBdAZYWOfjEXaRlqFCicQwYuq)
				{
					xzQUmpMJAJNhirjkmLDahbLYHjUH.CopyAllFrom(other.xzQUmpMJAJNhirjkmLDahbLYHjUH);
					YrPExokdkJbVahAXeYyFxlJEJZjg.CopyAllFrom(other.YrPExokdkJbVahAXeYyFxlJEJZjg);
					LZMVDuZlfRkwGBkwKdZmWPdLmFWm = other.LZMVDuZlfRkwGBkwKdZmWPdLmFWm;
					lUUWFUSKDnkKsTHWfpCLHvfAOkjx = other.lUUWFUSKDnkKsTHWfpCLHvfAOkjx;
					RdBbojkBlORmAcyGPXeIiHLuLTWbb = other.RdBbojkBlORmAcyGPXeIiHLuLTWbb;
					KQPNkRihyyKwVRZizyxidKNbRlMG = other.KQPNkRihyyKwVRZizyxidKNbRlMG;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~DualThreadLowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				return;
			}
			if (disposing)
			{
				lock (gDQbBdAZYWOfjEXaRlqFCicQwYuq)
				{
					xzQUmpMJAJNhirjkmLDahbLYHjUH.Dispose();
					YrPExokdkJbVahAXeYyFxlJEJZjg.Dispose();
				}
			}
			JChPmMbeaoLOGQvosPYqDDInSiCs = true;
		}
	}
}
