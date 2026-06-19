using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent pPawYWwjGYEYkhDjOOrwaUSrhRZD;

		private readonly NativeRingBuffer NMtQosulPrFtyANNqUyAMSNqUungA;

		private readonly int WPcinVGrkMADpVFJYGelCSykJtRGb;

		private readonly int LKGObcIdjmOYvGgHVmLcdyQIWQdU;

		private readonly int FAsDwIZotnRJVRRKRbHLYhbAFDQu;

		private readonly int gooLdVwETmmnqBqCJaYjMmuvxlwT;

		private readonly int eMACVWuJvoBVjUFTAKWVRobpmTwB;

		private uint JgkBEnkeOabCcJiHEyezqcigMEAl;

		private bool voFZdHIedJUOzxfGgHoWIoTQBtkT;

		public int Count => NMtQosulPrFtyANNqUyAMSNqUungA.BytesInBuffer / gooLdVwETmmnqBqCJaYjMmuvxlwT;

		public int Capacity => eMACVWuJvoBVjUFTAKWVRobpmTwB;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(NMtQosulPrFtyANNqUyAMSNqUungA.GetPointerFromReadPosition(index * gooLdVwETmmnqBqCJaYjMmuvxlwT), WPcinVGrkMADpVFJYGelCSykJtRGb, LKGObcIdjmOYvGgHVmLcdyQIWQdU, FAsDwIZotnRJVRRKRbHLYhbAFDQu);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			eMACVWuJvoBVjUFTAKWVRobpmTwB = P_0;
			WPcinVGrkMADpVFJYGelCSykJtRGb = P_1;
			LKGObcIdjmOYvGgHVmLcdyQIWQdU = P_2;
			FAsDwIZotnRJVRRKRbHLYhbAFDQu = P_3;
			gooLdVwETmmnqBqCJaYjMmuvxlwT = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			NMtQosulPrFtyANNqUyAMSNqUungA = new NativeRingBuffer(eMACVWuJvoBVjUFTAKWVRobpmTwB * gooLdVwETmmnqBqCJaYjMmuvxlwT);
			pPawYWwjGYEYkhDjOOrwaUSrhRZD = new LowLevelInputEvent(IntPtr.Zero, WPcinVGrkMADpVFJYGelCSykJtRGb, LKGObcIdjmOYvGgHVmLcdyQIWQdU, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = NMtQosulPrFtyANNqUyAMSNqUungA.Allocate(gooLdVwETmmnqBqCJaYjMmuvxlwT, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, WPcinVGrkMADpVFJYGelCSykJtRGb, LKGObcIdjmOYvGgHVmLcdyQIWQdU, FAsDwIZotnRJVRRKRbHLYhbAFDQu);
			result.SetId(JgkBEnkeOabCcJiHEyezqcigMEAl = MiscTools.Tick(JgkBEnkeOabCcJiHEyezqcigMEAl));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = NMtQosulPrFtyANNqUyAMSNqUungA.BytesInBuffer / gooLdVwETmmnqBqCJaYjMmuvxlwT;
			if (num == 0)
			{
				return -1;
			}
			pPawYWwjGYEYkhDjOOrwaUSrhRZD._buffer = NMtQosulPrFtyANNqUyAMSNqUungA.GetPointerFromReadPosition(0);
			uint num2 = pPawYWwjGYEYkhDjOOrwaUSrhRZD.GetId();
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
			if (index < 0 || index >= NMtQosulPrFtyANNqUyAMSNqUungA.BytesInBuffer / gooLdVwETmmnqBqCJaYjMmuvxlwT)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(NMtQosulPrFtyANNqUyAMSNqUungA.GetPointerFromReadPosition(index * gooLdVwETmmnqBqCJaYjMmuvxlwT), WPcinVGrkMADpVFJYGelCSykJtRGb, LKGObcIdjmOYvGgHVmLcdyQIWQdU, FAsDwIZotnRJVRRKRbHLYhbAFDQu);
			return true;
		}

		public void Clear()
		{
			NMtQosulPrFtyANNqUyAMSNqUungA.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			NMtQosulPrFtyANNqUyAMSNqUungA.CopyFrom(other.NMtQosulPrFtyANNqUyAMSNqUungA);
			JgkBEnkeOabCcJiHEyezqcigMEAl = other.JgkBEnkeOabCcJiHEyezqcigMEAl;
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
			uint id = new LowLevelInputEvent(NMtQosulPrFtyANNqUyAMSNqUungA.GetPointerFromReadPosition((count - 1) * gooLdVwETmmnqBqCJaYjMmuvxlwT), WPcinVGrkMADpVFJYGelCSykJtRGb, LKGObcIdjmOYvGgHVmLcdyQIWQdU, FAsDwIZotnRJVRRKRbHLYhbAFDQu).GetId();
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
					IntPtr buffer = NMtQosulPrFtyANNqUyAMSNqUungA.Allocate(gooLdVwETmmnqBqCJaYjMmuvxlwT, zeroFill: false, out passId);
					other.NMtQosulPrFtyANNqUyAMSNqUungA.RandomRead(buffer, gooLdVwETmmnqBqCJaYjMmuvxlwT, gooLdVwETmmnqBqCJaYjMmuvxlwT, other.NMtQosulPrFtyANNqUyAMSNqUungA.GetOffsetFromReadPosition((num + i) * gooLdVwETmmnqBqCJaYjMmuvxlwT));
				}
				JgkBEnkeOabCcJiHEyezqcigMEAl = other.JgkBEnkeOabCcJiHEyezqcigMEAl;
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
			if (!voFZdHIedJUOzxfGgHoWIoTQBtkT)
			{
				if (disposing)
				{
					NMtQosulPrFtyANNqUyAMSNqUungA.Dispose();
				}
				voFZdHIedJUOzxfGgHoWIoTQBtkT = true;
			}
		}
	}
}
