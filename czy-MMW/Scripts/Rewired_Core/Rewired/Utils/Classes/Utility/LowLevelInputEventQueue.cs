using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent ntvkrvFpEZOijihuaakpKQpGIymaA;

		private readonly NativeRingBuffer ZSwnOTDfcafHvGXaCaKHwwoXOlKp;

		private readonly int EtbgMaxRBNjwiUTquGkkklTTsHwG;

		private readonly int VxJySNnXMjeLwFCqbjTtBgrvdFQP;

		private readonly int FDtHYlaHQwMtEWwzjUTUuYUlUQxn;

		private readonly int gpldomXkkldLteQtjymcqeHCmsJXA;

		private readonly int gpJTHaVwqvQfMJkggTcXlYHGTnaw;

		private uint TCpUEUPaDlGTbJYTymEmFWXRvFnGA;

		private bool pOKcEedrKGlmwLobAbANUaifseFBA;

		public int Count => ZSwnOTDfcafHvGXaCaKHwwoXOlKp.BytesInBuffer / gpldomXkkldLteQtjymcqeHCmsJXA;

		public int Capacity => gpJTHaVwqvQfMJkggTcXlYHGTnaw;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(ZSwnOTDfcafHvGXaCaKHwwoXOlKp.GetPointerFromReadPosition(index * gpldomXkkldLteQtjymcqeHCmsJXA), EtbgMaxRBNjwiUTquGkkklTTsHwG, VxJySNnXMjeLwFCqbjTtBgrvdFQP, FDtHYlaHQwMtEWwzjUTUuYUlUQxn);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			gpJTHaVwqvQfMJkggTcXlYHGTnaw = P_0;
			EtbgMaxRBNjwiUTquGkkklTTsHwG = P_1;
			VxJySNnXMjeLwFCqbjTtBgrvdFQP = P_2;
			FDtHYlaHQwMtEWwzjUTUuYUlUQxn = P_3;
			gpldomXkkldLteQtjymcqeHCmsJXA = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			ZSwnOTDfcafHvGXaCaKHwwoXOlKp = new NativeRingBuffer(gpJTHaVwqvQfMJkggTcXlYHGTnaw * gpldomXkkldLteQtjymcqeHCmsJXA);
			ntvkrvFpEZOijihuaakpKQpGIymaA = new LowLevelInputEvent(IntPtr.Zero, EtbgMaxRBNjwiUTquGkkklTTsHwG, VxJySNnXMjeLwFCqbjTtBgrvdFQP, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = ZSwnOTDfcafHvGXaCaKHwwoXOlKp.Allocate(gpldomXkkldLteQtjymcqeHCmsJXA, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, EtbgMaxRBNjwiUTquGkkklTTsHwG, VxJySNnXMjeLwFCqbjTtBgrvdFQP, FDtHYlaHQwMtEWwzjUTUuYUlUQxn);
			result.SetId(TCpUEUPaDlGTbJYTymEmFWXRvFnGA = MiscTools.Tick(TCpUEUPaDlGTbJYTymEmFWXRvFnGA));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = ZSwnOTDfcafHvGXaCaKHwwoXOlKp.BytesInBuffer / gpldomXkkldLteQtjymcqeHCmsJXA;
			if (num == 0)
			{
				return -1;
			}
			ntvkrvFpEZOijihuaakpKQpGIymaA._buffer = ZSwnOTDfcafHvGXaCaKHwwoXOlKp.GetPointerFromReadPosition(0);
			uint num2 = ntvkrvFpEZOijihuaakpKQpGIymaA.GetId();
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
			if (index < 0 || index >= ZSwnOTDfcafHvGXaCaKHwwoXOlKp.BytesInBuffer / gpldomXkkldLteQtjymcqeHCmsJXA)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(ZSwnOTDfcafHvGXaCaKHwwoXOlKp.GetPointerFromReadPosition(index * gpldomXkkldLteQtjymcqeHCmsJXA), EtbgMaxRBNjwiUTquGkkklTTsHwG, VxJySNnXMjeLwFCqbjTtBgrvdFQP, FDtHYlaHQwMtEWwzjUTUuYUlUQxn);
			return true;
		}

		public void Clear()
		{
			ZSwnOTDfcafHvGXaCaKHwwoXOlKp.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			ZSwnOTDfcafHvGXaCaKHwwoXOlKp.CopyFrom(other.ZSwnOTDfcafHvGXaCaKHwwoXOlKp);
			TCpUEUPaDlGTbJYTymEmFWXRvFnGA = other.TCpUEUPaDlGTbJYTymEmFWXRvFnGA;
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
			uint id = new LowLevelInputEvent(ZSwnOTDfcafHvGXaCaKHwwoXOlKp.GetPointerFromReadPosition((count - 1) * gpldomXkkldLteQtjymcqeHCmsJXA), EtbgMaxRBNjwiUTquGkkklTTsHwG, VxJySNnXMjeLwFCqbjTtBgrvdFQP, FDtHYlaHQwMtEWwzjUTUuYUlUQxn).GetId();
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
					IntPtr buffer = ZSwnOTDfcafHvGXaCaKHwwoXOlKp.Allocate(gpldomXkkldLteQtjymcqeHCmsJXA, zeroFill: false, out passId);
					other.ZSwnOTDfcafHvGXaCaKHwwoXOlKp.RandomRead(buffer, gpldomXkkldLteQtjymcqeHCmsJXA, gpldomXkkldLteQtjymcqeHCmsJXA, other.ZSwnOTDfcafHvGXaCaKHwwoXOlKp.GetOffsetFromReadPosition((num + i) * gpldomXkkldLteQtjymcqeHCmsJXA));
				}
				TCpUEUPaDlGTbJYTymEmFWXRvFnGA = other.TCpUEUPaDlGTbJYTymEmFWXRvFnGA;
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

		~LowLevelInputEventQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!pOKcEedrKGlmwLobAbANUaifseFBA)
			{
				if (disposing)
				{
					ZSwnOTDfcafHvGXaCaKHwwoXOlKp.Dispose();
				}
				pOKcEedrKGlmwLobAbANUaifseFBA = true;
			}
		}
	}
}
