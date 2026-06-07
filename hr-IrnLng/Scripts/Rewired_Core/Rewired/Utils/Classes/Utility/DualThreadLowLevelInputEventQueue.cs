using System;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualThreadLowLevelInputEventQueue : IDisposable
	{
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public interface INewEventWrapper : IDisposable
		{
			LowLevelInputEvent Event { get; set; }
		}

		private class vcVTQWyYrihkeTEVgxdhrxraZxj : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
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

			public vcVTQWyYrihkeTEVgxdhrxraZxj(object lockObject)
				: base(lockObject)
			{
			}
		}

		private readonly LowLevelInputEventQueue briwoQBlgphYFQAnBhUuVoDGABC;

		private readonly LowLevelInputEventQueue AWnjiCfwVvHsRUCDBMVJXNRWHNj;

		private readonly object soeOzLJfzmrsOhRwaibZoLuOaAa;

		private uint FwWnYtEQtLhrhcafDCwmajXLVCb;

		private bool fqxnoFJibPNPhiYwIJBxlvHKyzl;

		private int JzBAXdQSatxnuXIiglEMnNsKBG;

		private int ObrBYtxwJEWTesBoSDpkaRLpPBCj;

		private vcVTQWyYrihkeTEVgxdhrxraZxj JnMRmDCEZXWAGFJaxCBtahPwHOic;

		public LowLevelInputEvent currentEvent;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public uint lastProcessedEventId => FwWnYtEQtLhrhcafDCwmajXLVCb;

		public int count
		{
			get
			{
				lock (soeOzLJfzmrsOhRwaibZoLuOaAa)
				{
					return briwoQBlgphYFQAnBhUuVoDGABC.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
			briwoQBlgphYFQAnBhUuVoDGABC = new LowLevelInputEventQueue(capacity, buttonCount, axisCount, hatCount);
			AWnjiCfwVvHsRUCDBMVJXNRWHNj = new LowLevelInputEventQueue(capacity, buttonCount, axisCount, hatCount);
			soeOzLJfzmrsOhRwaibZoLuOaAa = new object();
			JnMRmDCEZXWAGFJaxCBtahPwHOic = new vcVTQWyYrihkeTEVgxdhrxraZxj(soeOzLJfzmrsOhRwaibZoLuOaAa);
		}

		public INewEventWrapper T_CreateEvent()
		{
			JnMRmDCEZXWAGFJaxCBtahPwHOic.Lock();
			JnMRmDCEZXWAGFJaxCBtahPwHOic.item = AWnjiCfwVvHsRUCDBMVJXNRWHNj.CreateEvent();
			return JnMRmDCEZXWAGFJaxCBtahPwHOic;
		}

		public void Update()
		{
			lock (soeOzLJfzmrsOhRwaibZoLuOaAa)
			{
				briwoQBlgphYFQAnBhUuVoDGABC.CopyNewEventsFrom(AWnjiCfwVvHsRUCDBMVJXNRWHNj);
			}
		}

		public void Clear()
		{
			lock (soeOzLJfzmrsOhRwaibZoLuOaAa)
			{
				StopProcessingEvents();
				briwoQBlgphYFQAnBhUuVoDGABC.Clear();
				AWnjiCfwVvHsRUCDBMVJXNRWHNj.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (ObrBYtxwJEWTesBoSDpkaRLpPBCj == 0)
			{
				Update();
				int num = briwoQBlgphYFQAnBhUuVoDGABC.FindNextIndex(FwWnYtEQtLhrhcafDCwmajXLVCb);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				ObrBYtxwJEWTesBoSDpkaRLpPBCj = num;
				fqxnoFJibPNPhiYwIJBxlvHKyzl = true;
				JzBAXdQSatxnuXIiglEMnNsKBG = briwoQBlgphYFQAnBhUuVoDGABC.Count;
			}
			if (ObrBYtxwJEWTesBoSDpkaRLpPBCj >= JzBAXdQSatxnuXIiglEMnNsKBG)
			{
				currentEvent = default(LowLevelInputEvent);
				fqxnoFJibPNPhiYwIJBxlvHKyzl = false;
				ObrBYtxwJEWTesBoSDpkaRLpPBCj = 0;
				return false;
			}
			if (briwoQBlgphYFQAnBhUuVoDGABC.TryGetNext(ObrBYtxwJEWTesBoSDpkaRLpPBCj, out currentEvent))
			{
				FwWnYtEQtLhrhcafDCwmajXLVCb = currentEvent.GetId();
				ObrBYtxwJEWTesBoSDpkaRLpPBCj++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			fqxnoFJibPNPhiYwIJBxlvHKyzl = false;
			ObrBYtxwJEWTesBoSDpkaRLpPBCj = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			fqxnoFJibPNPhiYwIJBxlvHKyzl = false;
			ObrBYtxwJEWTesBoSDpkaRLpPBCj = 0;
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
			lock (soeOzLJfzmrsOhRwaibZoLuOaAa)
			{
				lock (other.soeOzLJfzmrsOhRwaibZoLuOaAa)
				{
					briwoQBlgphYFQAnBhUuVoDGABC.CopyAllFrom(other.briwoQBlgphYFQAnBhUuVoDGABC);
					AWnjiCfwVvHsRUCDBMVJXNRWHNj.CopyAllFrom(other.AWnjiCfwVvHsRUCDBMVJXNRWHNj);
					FwWnYtEQtLhrhcafDCwmajXLVCb = other.FwWnYtEQtLhrhcafDCwmajXLVCb;
					fqxnoFJibPNPhiYwIJBxlvHKyzl = other.fqxnoFJibPNPhiYwIJBxlvHKyzl;
					JzBAXdQSatxnuXIiglEMnNsKBG = other.JzBAXdQSatxnuXIiglEMnNsKBG;
					ObrBYtxwJEWTesBoSDpkaRLpPBCj = other.ObrBYtxwJEWTesBoSDpkaRLpPBCj;
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
			if (JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				return;
			}
			if (disposing)
			{
				lock (soeOzLJfzmrsOhRwaibZoLuOaAa)
				{
					briwoQBlgphYFQAnBhUuVoDGABC.Dispose();
					AWnjiCfwVvHsRUCDBMVJXNRWHNj.Dispose();
				}
			}
			JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
		}
	}
}
