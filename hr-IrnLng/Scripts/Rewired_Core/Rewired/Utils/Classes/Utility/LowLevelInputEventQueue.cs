using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent sdusgqoiTOYkiwFXKCsABjytAKF;

		private readonly NativeRingBuffer tXOYZNOpQQloVVvloZikrrrFhHh;

		private readonly int BIqrSHxnfVeJEnjKdnGBTolrmbG;

		private readonly int hdPfWCbEBCXchGQqzkLUjCOtChr;

		private readonly int wluJKdumRlvAwdKGuMIsACqyRqz;

		private readonly int SzwnnVNkyHaaeqdodCsTGkErVhyE;

		private readonly int doAsGrtKlisSXEPfwnlOTedRuDB;

		private uint hnezHPSCfYvtQBKJAxbDTZAdGuQ;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public int Count => tXOYZNOpQQloVVvloZikrrrFhHh.BytesInBuffer / SzwnnVNkyHaaeqdodCsTGkErVhyE;

		public int Capacity => doAsGrtKlisSXEPfwnlOTedRuDB;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(tXOYZNOpQQloVVvloZikrrrFhHh.GetPointerFromReadPosition(index * SzwnnVNkyHaaeqdodCsTGkErVhyE), BIqrSHxnfVeJEnjKdnGBTolrmbG, hdPfWCbEBCXchGQqzkLUjCOtChr, wluJKdumRlvAwdKGuMIsACqyRqz);

		public LowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
		{
			doAsGrtKlisSXEPfwnlOTedRuDB = capacity;
			BIqrSHxnfVeJEnjKdnGBTolrmbG = buttonCount;
			hdPfWCbEBCXchGQqzkLUjCOtChr = axisCount;
			wluJKdumRlvAwdKGuMIsACqyRqz = hatCount;
			SzwnnVNkyHaaeqdodCsTGkErVhyE = LowLevelInputEvent.GetReportSize(buttonCount, axisCount, hatCount);
			tXOYZNOpQQloVVvloZikrrrFhHh = new NativeRingBuffer(doAsGrtKlisSXEPfwnlOTedRuDB * SzwnnVNkyHaaeqdodCsTGkErVhyE);
			sdusgqoiTOYkiwFXKCsABjytAKF = new LowLevelInputEvent(IntPtr.Zero, BIqrSHxnfVeJEnjKdnGBTolrmbG, hdPfWCbEBCXchGQqzkLUjCOtChr, hatCount);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr buffer = tXOYZNOpQQloVVvloZikrrrFhHh.Allocate(SzwnnVNkyHaaeqdodCsTGkErVhyE, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(buffer, BIqrSHxnfVeJEnjKdnGBTolrmbG, hdPfWCbEBCXchGQqzkLUjCOtChr, wluJKdumRlvAwdKGuMIsACqyRqz);
			result.SetId(hnezHPSCfYvtQBKJAxbDTZAdGuQ = MiscTools.Tick(hnezHPSCfYvtQBKJAxbDTZAdGuQ));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = tXOYZNOpQQloVVvloZikrrrFhHh.BytesInBuffer / SzwnnVNkyHaaeqdodCsTGkErVhyE;
			if (num == 0)
			{
				return -1;
			}
			sdusgqoiTOYkiwFXKCsABjytAKF._buffer = tXOYZNOpQQloVVvloZikrrrFhHh.GetPointerFromReadPosition(0);
			uint num2 = sdusgqoiTOYkiwFXKCsABjytAKF.GetId();
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
			if (index < 0 || index >= tXOYZNOpQQloVVvloZikrrrFhHh.BytesInBuffer / SzwnnVNkyHaaeqdodCsTGkErVhyE)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(tXOYZNOpQQloVVvloZikrrrFhHh.GetPointerFromReadPosition(index * SzwnnVNkyHaaeqdodCsTGkErVhyE), BIqrSHxnfVeJEnjKdnGBTolrmbG, hdPfWCbEBCXchGQqzkLUjCOtChr, wluJKdumRlvAwdKGuMIsACqyRqz);
			return true;
		}

		public void Clear()
		{
			tXOYZNOpQQloVVvloZikrrrFhHh.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			tXOYZNOpQQloVVvloZikrrrFhHh.CopyFrom(other.tXOYZNOpQQloVVvloZikrrrFhHh);
			hnezHPSCfYvtQBKJAxbDTZAdGuQ = other.hnezHPSCfYvtQBKJAxbDTZAdGuQ;
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
			uint id = new LowLevelInputEvent(tXOYZNOpQQloVVvloZikrrrFhHh.GetPointerFromReadPosition((count - 1) * SzwnnVNkyHaaeqdodCsTGkErVhyE), BIqrSHxnfVeJEnjKdnGBTolrmbG, hdPfWCbEBCXchGQqzkLUjCOtChr, wluJKdumRlvAwdKGuMIsACqyRqz).GetId();
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
					IntPtr buffer = tXOYZNOpQQloVVvloZikrrrFhHh.Allocate(SzwnnVNkyHaaeqdodCsTGkErVhyE, zeroFill: false, out passId);
					other.tXOYZNOpQQloVVvloZikrrrFhHh.RandomRead(buffer, SzwnnVNkyHaaeqdodCsTGkErVhyE, SzwnnVNkyHaaeqdodCsTGkErVhyE, other.tXOYZNOpQQloVVvloZikrrrFhHh.GetOffsetFromReadPosition((num + i) * SzwnnVNkyHaaeqdodCsTGkErVhyE));
				}
				hnezHPSCfYvtQBKJAxbDTZAdGuQ = other.hnezHPSCfYvtQBKJAxbDTZAdGuQ;
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
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				if (disposing)
				{
					tXOYZNOpQQloVVvloZikrrrFhHh.Dispose();
				}
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}
	}
}
