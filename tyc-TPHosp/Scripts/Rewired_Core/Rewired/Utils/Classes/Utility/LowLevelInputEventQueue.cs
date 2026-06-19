using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent UJWaLOTJmJGrsedrDwOZlHJZJSlx;

		private readonly NativeRingBuffer JhuxGljjlZWxNKFLpJDlpCWbpkZ;

		private readonly int rVYednFAWMyyCdseuzQUGHWBwloT;

		private readonly int RJpArmCUtRiPnVeoaamBjjbTBEHe;

		private readonly int SCZmXOZoaMKuAqgrKAbzOTWDVFF;

		private readonly int kgIFCxciLUEDcfjIimsSLsjmXfCF;

		private readonly int VEmNteWmpdRTYXxUtdCoLGPlsxd;

		private uint FACMknjKALKKOGRtBQnCVorVskk;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public int Count => JhuxGljjlZWxNKFLpJDlpCWbpkZ.BytesInBuffer / kgIFCxciLUEDcfjIimsSLsjmXfCF;

		public int Capacity => VEmNteWmpdRTYXxUtdCoLGPlsxd;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(JhuxGljjlZWxNKFLpJDlpCWbpkZ.GetPointerFromReadPosition(index * kgIFCxciLUEDcfjIimsSLsjmXfCF), rVYednFAWMyyCdseuzQUGHWBwloT, RJpArmCUtRiPnVeoaamBjjbTBEHe, SCZmXOZoaMKuAqgrKAbzOTWDVFF);

		public LowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
			VEmNteWmpdRTYXxUtdCoLGPlsxd = capacity;
			rVYednFAWMyyCdseuzQUGHWBwloT = buttonCount;
			RJpArmCUtRiPnVeoaamBjjbTBEHe = axisCount;
			SCZmXOZoaMKuAqgrKAbzOTWDVFF = hatCount;
			kgIFCxciLUEDcfjIimsSLsjmXfCF = LowLevelInputEvent.GetReportSize(buttonCount, axisCount, hatCount);
			JhuxGljjlZWxNKFLpJDlpCWbpkZ = new NativeRingBuffer(VEmNteWmpdRTYXxUtdCoLGPlsxd * kgIFCxciLUEDcfjIimsSLsjmXfCF);
			UJWaLOTJmJGrsedrDwOZlHJZJSlx = new LowLevelInputEvent(IntPtr.Zero, rVYednFAWMyyCdseuzQUGHWBwloT, RJpArmCUtRiPnVeoaamBjjbTBEHe, hatCount);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr buffer = JhuxGljjlZWxNKFLpJDlpCWbpkZ.Allocate(kgIFCxciLUEDcfjIimsSLsjmXfCF, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(buffer, rVYednFAWMyyCdseuzQUGHWBwloT, RJpArmCUtRiPnVeoaamBjjbTBEHe, SCZmXOZoaMKuAqgrKAbzOTWDVFF);
			result.SetId(FACMknjKALKKOGRtBQnCVorVskk = MiscTools.Tick(FACMknjKALKKOGRtBQnCVorVskk));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = JhuxGljjlZWxNKFLpJDlpCWbpkZ.BytesInBuffer / kgIFCxciLUEDcfjIimsSLsjmXfCF;
			if (num == 0)
			{
				return -1;
			}
			UJWaLOTJmJGrsedrDwOZlHJZJSlx._buffer = JhuxGljjlZWxNKFLpJDlpCWbpkZ.GetPointerFromReadPosition(0);
			uint num2 = UJWaLOTJmJGrsedrDwOZlHJZJSlx.GetId();
			int num3 = 0;
			if (MiscTools.IsTickNewer(id, num2))
			{
				num3 = (int)MiscTools.TickDifference(id, num2) + 1;
				num2 = MiscTools.Tick(id);
			}
			for (int i = num3; i < num; i++)
			{
				if (!MiscTools.IsTickNewer(num2, id))
				{
					num2 = MiscTools.Tick(num2);
					continue;
				}
				return i;
			}
			return -1;
		}

		public bool TryGetNext(int index, out LowLevelInputEvent @event)
		{
			if (index < 0 || index >= JhuxGljjlZWxNKFLpJDlpCWbpkZ.BytesInBuffer / kgIFCxciLUEDcfjIimsSLsjmXfCF)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(JhuxGljjlZWxNKFLpJDlpCWbpkZ.GetPointerFromReadPosition(index * kgIFCxciLUEDcfjIimsSLsjmXfCF), rVYednFAWMyyCdseuzQUGHWBwloT, RJpArmCUtRiPnVeoaamBjjbTBEHe, SCZmXOZoaMKuAqgrKAbzOTWDVFF);
			return true;
		}

		public void Clear()
		{
			JhuxGljjlZWxNKFLpJDlpCWbpkZ.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			JhuxGljjlZWxNKFLpJDlpCWbpkZ.CopyFrom(other.JhuxGljjlZWxNKFLpJDlpCWbpkZ);
			FACMknjKALKKOGRtBQnCVorVskk = other.FACMknjKALKKOGRtBQnCVorVskk;
		}

		public void CopyNewEventsFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			int count = Count;
			int count2 = other.Count;
			if (count2 == 0)
			{
				return;
			}
			if (count == 0)
			{
				CopyAllFrom(other);
				return;
			}
			uint id = new LowLevelInputEvent(JhuxGljjlZWxNKFLpJDlpCWbpkZ.GetPointerFromReadPosition((count - 1) * kgIFCxciLUEDcfjIimsSLsjmXfCF), rVYednFAWMyyCdseuzQUGHWBwloT, RJpArmCUtRiPnVeoaamBjjbTBEHe, SCZmXOZoaMKuAqgrKAbzOTWDVFF).GetId();
			int num = other.FindNextIndex(id);
			if (num < 0)
			{
				return;
			}
			int num2 = count2 - num;
			if (num2 != 0)
			{
				for (int i = 0; i < num2; i++)
				{
					uint passId;
					IntPtr buffer = JhuxGljjlZWxNKFLpJDlpCWbpkZ.Allocate(kgIFCxciLUEDcfjIimsSLsjmXfCF, zeroFill: false, out passId);
					other.JhuxGljjlZWxNKFLpJDlpCWbpkZ.RandomRead(buffer, kgIFCxciLUEDcfjIimsSLsjmXfCF, kgIFCxciLUEDcfjIimsSLsjmXfCF, other.JhuxGljjlZWxNKFLpJDlpCWbpkZ.GetOffsetFromReadPosition((num + i) * kgIFCxciLUEDcfjIimsSLsjmXfCF));
				}
				FACMknjKALKKOGRtBQnCVorVskk = other.FACMknjKALKKOGRtBQnCVorVskk;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~LowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				if (disposing)
				{
					JhuxGljjlZWxNKFLpJDlpCWbpkZ.Dispose();
				}
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}
	}
}
