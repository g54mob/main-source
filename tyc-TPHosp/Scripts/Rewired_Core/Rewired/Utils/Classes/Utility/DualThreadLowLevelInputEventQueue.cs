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

		private class NpfGzeVqMjjBigIvtMjyFjSAVHVN : LockedObject<LowLevelInputEvent>, IDisposable, INewEventWrapper
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

			public NpfGzeVqMjjBigIvtMjyFjSAVHVN(object lockObject)
				: base(lockObject)
			{
			}
		}

		private readonly LowLevelInputEventQueue PAUiJaeNNkqhVRpTUHStFpqcPLo;

		private readonly LowLevelInputEventQueue iTPXJyKqmwjLZJyvIbTYPMakUZZ;

		private readonly object SbScWpaWQhCZYeRWtdxCcoRkhOGe;

		private uint zKMGmqtTdeCNtnbQaCbbgcMtILg;

		private bool ZFMArQyuZKkJJxCsVPdUdDCeieN;

		private int bHDlBdxovnQSnQwutjDDdeeCFEk;

		private int wuLfYREmlHozunKLLfajTgiJLts;

		private NpfGzeVqMjjBigIvtMjyFjSAVHVN ndmIHhjliEvfSMSAcnXycwkYpCWj;

		public LowLevelInputEvent currentEvent;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public uint lastProcessedEventId => zKMGmqtTdeCNtnbQaCbbgcMtILg;

		public int count
		{
			get
			{
				lock (SbScWpaWQhCZYeRWtdxCcoRkhOGe)
				{
					return PAUiJaeNNkqhVRpTUHStFpqcPLo.Count;
				}
			}
		}

		public DualThreadLowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
			PAUiJaeNNkqhVRpTUHStFpqcPLo = new LowLevelInputEventQueue(capacity, buttonCount, axisCount, hatCount);
			iTPXJyKqmwjLZJyvIbTYPMakUZZ = new LowLevelInputEventQueue(capacity, buttonCount, axisCount, hatCount);
			SbScWpaWQhCZYeRWtdxCcoRkhOGe = new object();
			ndmIHhjliEvfSMSAcnXycwkYpCWj = new NpfGzeVqMjjBigIvtMjyFjSAVHVN(SbScWpaWQhCZYeRWtdxCcoRkhOGe);
		}

		public INewEventWrapper T_CreateEvent()
		{
			ndmIHhjliEvfSMSAcnXycwkYpCWj.Lock();
			ndmIHhjliEvfSMSAcnXycwkYpCWj.item = iTPXJyKqmwjLZJyvIbTYPMakUZZ.CreateEvent();
			return ndmIHhjliEvfSMSAcnXycwkYpCWj;
		}

		public void Update()
		{
			lock (SbScWpaWQhCZYeRWtdxCcoRkhOGe)
			{
				PAUiJaeNNkqhVRpTUHStFpqcPLo.CopyNewEventsFrom(iTPXJyKqmwjLZJyvIbTYPMakUZZ);
			}
		}

		public void Clear()
		{
			lock (SbScWpaWQhCZYeRWtdxCcoRkhOGe)
			{
				StopProcessingEvents();
				PAUiJaeNNkqhVRpTUHStFpqcPLo.Clear();
				iTPXJyKqmwjLZJyvIbTYPMakUZZ.Clear();
			}
		}

		public bool ProcessNewEvents()
		{
			if (wuLfYREmlHozunKLLfajTgiJLts == 0)
			{
				Update();
				int num = PAUiJaeNNkqhVRpTUHStFpqcPLo.FindNextIndex(zKMGmqtTdeCNtnbQaCbbgcMtILg);
				if (num < 0)
				{
					currentEvent = default(LowLevelInputEvent);
					return false;
				}
				wuLfYREmlHozunKLLfajTgiJLts = num;
				ZFMArQyuZKkJJxCsVPdUdDCeieN = true;
				bHDlBdxovnQSnQwutjDDdeeCFEk = PAUiJaeNNkqhVRpTUHStFpqcPLo.Count;
			}
			if (wuLfYREmlHozunKLLfajTgiJLts >= bHDlBdxovnQSnQwutjDDdeeCFEk)
			{
				currentEvent = default(LowLevelInputEvent);
				ZFMArQyuZKkJJxCsVPdUdDCeieN = false;
				wuLfYREmlHozunKLLfajTgiJLts = 0;
				return false;
			}
			if (PAUiJaeNNkqhVRpTUHStFpqcPLo.TryGetNext(wuLfYREmlHozunKLLfajTgiJLts, out currentEvent))
			{
				zKMGmqtTdeCNtnbQaCbbgcMtILg = currentEvent.GetId();
				wuLfYREmlHozunKLLfajTgiJLts++;
				return true;
			}
			currentEvent = default(LowLevelInputEvent);
			ZFMArQyuZKkJJxCsVPdUdDCeieN = false;
			wuLfYREmlHozunKLLfajTgiJLts = 0;
			return false;
		}

		public void StopProcessingEvents()
		{
			ZFMArQyuZKkJJxCsVPdUdDCeieN = false;
			wuLfYREmlHozunKLLfajTgiJLts = 0;
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
			lock (SbScWpaWQhCZYeRWtdxCcoRkhOGe)
			{
				lock (other.SbScWpaWQhCZYeRWtdxCcoRkhOGe)
				{
					PAUiJaeNNkqhVRpTUHStFpqcPLo.CopyAllFrom(other.PAUiJaeNNkqhVRpTUHStFpqcPLo);
					iTPXJyKqmwjLZJyvIbTYPMakUZZ.CopyAllFrom(other.iTPXJyKqmwjLZJyvIbTYPMakUZZ);
					zKMGmqtTdeCNtnbQaCbbgcMtILg = other.zKMGmqtTdeCNtnbQaCbbgcMtILg;
					ZFMArQyuZKkJJxCsVPdUdDCeieN = other.ZFMArQyuZKkJJxCsVPdUdDCeieN;
					bHDlBdxovnQSnQwutjDDdeeCFEk = other.bHDlBdxovnQSnQwutjDDdeeCFEk;
					wuLfYREmlHozunKLLfajTgiJLts = other.wuLfYREmlHozunKLLfajTgiJLts;
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
			if (jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				return;
			}
			if (disposing)
			{
				lock (SbScWpaWQhCZYeRWtdxCcoRkhOGe)
				{
					PAUiJaeNNkqhVRpTUHStFpqcPLo.Dispose();
					iTPXJyKqmwjLZJyvIbTYPMakUZZ.Dispose();
				}
			}
			jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
		}
	}
}
