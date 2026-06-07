using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent JLIBTNJmAaiadaotUbfiigZabYZab;

		private readonly NativeRingBuffer GGkrkdxDMgDKYZNAkyAhQYvSppnc;

		private readonly int sqOAjqiYgpyrLlQchddtcgIsmpGfb;

		private readonly int KkbOXxEuXwhRkKpefZpsKkvoQFpI;

		private readonly int FVQafKJYWTPLttkpgxhUfJgzZmve;

		private readonly int zFYBIafkjzxMbxgEdPJxHHresjuOb;

		private readonly int WjcVbvWkFCKGROUlyUKFoxBEwNHJ;

		private uint SgUgckhhguGRJgRxSNUnjsxouwULA;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

		public int Count => GGkrkdxDMgDKYZNAkyAhQYvSppnc.BytesInBuffer / zFYBIafkjzxMbxgEdPJxHHresjuOb;

		public int Capacity => WjcVbvWkFCKGROUlyUKFoxBEwNHJ;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(GGkrkdxDMgDKYZNAkyAhQYvSppnc.GetPointerFromReadPosition(index * zFYBIafkjzxMbxgEdPJxHHresjuOb), sqOAjqiYgpyrLlQchddtcgIsmpGfb, KkbOXxEuXwhRkKpefZpsKkvoQFpI, FVQafKJYWTPLttkpgxhUfJgzZmve);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			WjcVbvWkFCKGROUlyUKFoxBEwNHJ = P_0;
			sqOAjqiYgpyrLlQchddtcgIsmpGfb = P_1;
			KkbOXxEuXwhRkKpefZpsKkvoQFpI = P_2;
			FVQafKJYWTPLttkpgxhUfJgzZmve = P_3;
			zFYBIafkjzxMbxgEdPJxHHresjuOb = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			GGkrkdxDMgDKYZNAkyAhQYvSppnc = new NativeRingBuffer(WjcVbvWkFCKGROUlyUKFoxBEwNHJ * zFYBIafkjzxMbxgEdPJxHHresjuOb);
			JLIBTNJmAaiadaotUbfiigZabYZab = new LowLevelInputEvent(IntPtr.Zero, sqOAjqiYgpyrLlQchddtcgIsmpGfb, KkbOXxEuXwhRkKpefZpsKkvoQFpI, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = GGkrkdxDMgDKYZNAkyAhQYvSppnc.Allocate(zFYBIafkjzxMbxgEdPJxHHresjuOb, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, sqOAjqiYgpyrLlQchddtcgIsmpGfb, KkbOXxEuXwhRkKpefZpsKkvoQFpI, FVQafKJYWTPLttkpgxhUfJgzZmve);
			result.SetId(SgUgckhhguGRJgRxSNUnjsxouwULA = MiscTools.Tick(SgUgckhhguGRJgRxSNUnjsxouwULA));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = GGkrkdxDMgDKYZNAkyAhQYvSppnc.BytesInBuffer / zFYBIafkjzxMbxgEdPJxHHresjuOb;
			if (num == 0)
			{
				return -1;
			}
			JLIBTNJmAaiadaotUbfiigZabYZab._buffer = GGkrkdxDMgDKYZNAkyAhQYvSppnc.GetPointerFromReadPosition(0);
			uint num2 = JLIBTNJmAaiadaotUbfiigZabYZab.GetId();
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
			if (index < 0 || index >= GGkrkdxDMgDKYZNAkyAhQYvSppnc.BytesInBuffer / zFYBIafkjzxMbxgEdPJxHHresjuOb)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(GGkrkdxDMgDKYZNAkyAhQYvSppnc.GetPointerFromReadPosition(index * zFYBIafkjzxMbxgEdPJxHHresjuOb), sqOAjqiYgpyrLlQchddtcgIsmpGfb, KkbOXxEuXwhRkKpefZpsKkvoQFpI, FVQafKJYWTPLttkpgxhUfJgzZmve);
			return true;
		}

		public void Clear()
		{
			GGkrkdxDMgDKYZNAkyAhQYvSppnc.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			GGkrkdxDMgDKYZNAkyAhQYvSppnc.CopyFrom(other.GGkrkdxDMgDKYZNAkyAhQYvSppnc);
			SgUgckhhguGRJgRxSNUnjsxouwULA = other.SgUgckhhguGRJgRxSNUnjsxouwULA;
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
			uint id = new LowLevelInputEvent(GGkrkdxDMgDKYZNAkyAhQYvSppnc.GetPointerFromReadPosition((count - 1) * zFYBIafkjzxMbxgEdPJxHHresjuOb), sqOAjqiYgpyrLlQchddtcgIsmpGfb, KkbOXxEuXwhRkKpefZpsKkvoQFpI, FVQafKJYWTPLttkpgxhUfJgzZmve).GetId();
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
					IntPtr buffer = GGkrkdxDMgDKYZNAkyAhQYvSppnc.Allocate(zFYBIafkjzxMbxgEdPJxHHresjuOb, zeroFill: false, out passId);
					other.GGkrkdxDMgDKYZNAkyAhQYvSppnc.RandomRead(buffer, zFYBIafkjzxMbxgEdPJxHHresjuOb, zFYBIafkjzxMbxgEdPJxHHresjuOb, other.GGkrkdxDMgDKYZNAkyAhQYvSppnc.GetOffsetFromReadPosition((num + i) * zFYBIafkjzxMbxgEdPJxHHresjuOb));
				}
				SgUgckhhguGRJgRxSNUnjsxouwULA = other.SgUgckhhguGRJgRxSNUnjsxouwULA;
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
			if (!wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				if (disposing)
				{
					GGkrkdxDMgDKYZNAkyAhQYvSppnc.Dispose();
				}
				wFtxnVROnubhehGUBaPWAtQsiPAD = true;
			}
		}
	}
}
