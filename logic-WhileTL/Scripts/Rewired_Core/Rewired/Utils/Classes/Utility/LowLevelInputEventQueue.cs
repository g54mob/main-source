using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent wUSDGOEtmkkXTFFFvjJOazghQGZjA;

		private readonly NativeRingBuffer hqufqxRejmzmuqNpNpGeRCbTDzhaA;

		private readonly int BhCbgrefAhFSrJIISsNLWhvlnnANA;

		private readonly int hTtWFqoKfkIVSdGOWffSHmWvCWjfA;

		private readonly int afMIxBrXmXrqVGpSHUPmcKwoLJjm;

		private readonly int YwEPlbADLhkpTXngEdhZEVSbcnaM;

		private readonly int ngsUIyottIhptdyVRpkhbNqZCuLV;

		private uint hSwrrRPSemgnsQVpssHhySveqQF;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public int Count => hqufqxRejmzmuqNpNpGeRCbTDzhaA.BytesInBuffer / YwEPlbADLhkpTXngEdhZEVSbcnaM;

		public int Capacity => ngsUIyottIhptdyVRpkhbNqZCuLV;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(hqufqxRejmzmuqNpNpGeRCbTDzhaA.GetPointerFromReadPosition(index * YwEPlbADLhkpTXngEdhZEVSbcnaM), BhCbgrefAhFSrJIISsNLWhvlnnANA, hTtWFqoKfkIVSdGOWffSHmWvCWjfA, afMIxBrXmXrqVGpSHUPmcKwoLJjm);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			ngsUIyottIhptdyVRpkhbNqZCuLV = P_0;
			BhCbgrefAhFSrJIISsNLWhvlnnANA = P_1;
			hTtWFqoKfkIVSdGOWffSHmWvCWjfA = P_2;
			afMIxBrXmXrqVGpSHUPmcKwoLJjm = P_3;
			YwEPlbADLhkpTXngEdhZEVSbcnaM = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			hqufqxRejmzmuqNpNpGeRCbTDzhaA = new NativeRingBuffer(ngsUIyottIhptdyVRpkhbNqZCuLV * YwEPlbADLhkpTXngEdhZEVSbcnaM);
			wUSDGOEtmkkXTFFFvjJOazghQGZjA = new LowLevelInputEvent(IntPtr.Zero, BhCbgrefAhFSrJIISsNLWhvlnnANA, hTtWFqoKfkIVSdGOWffSHmWvCWjfA, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = hqufqxRejmzmuqNpNpGeRCbTDzhaA.Allocate(YwEPlbADLhkpTXngEdhZEVSbcnaM, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, BhCbgrefAhFSrJIISsNLWhvlnnANA, hTtWFqoKfkIVSdGOWffSHmWvCWjfA, afMIxBrXmXrqVGpSHUPmcKwoLJjm);
			result.SetId(hSwrrRPSemgnsQVpssHhySveqQF = MiscTools.Tick(hSwrrRPSemgnsQVpssHhySveqQF));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = hqufqxRejmzmuqNpNpGeRCbTDzhaA.BytesInBuffer / YwEPlbADLhkpTXngEdhZEVSbcnaM;
			if (num == 0)
			{
				return -1;
			}
			wUSDGOEtmkkXTFFFvjJOazghQGZjA._buffer = hqufqxRejmzmuqNpNpGeRCbTDzhaA.GetPointerFromReadPosition(0);
			uint num2 = wUSDGOEtmkkXTFFFvjJOazghQGZjA.GetId();
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
			if (index < 0 || index >= hqufqxRejmzmuqNpNpGeRCbTDzhaA.BytesInBuffer / YwEPlbADLhkpTXngEdhZEVSbcnaM)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(hqufqxRejmzmuqNpNpGeRCbTDzhaA.GetPointerFromReadPosition(index * YwEPlbADLhkpTXngEdhZEVSbcnaM), BhCbgrefAhFSrJIISsNLWhvlnnANA, hTtWFqoKfkIVSdGOWffSHmWvCWjfA, afMIxBrXmXrqVGpSHUPmcKwoLJjm);
			return true;
		}

		public void Clear()
		{
			hqufqxRejmzmuqNpNpGeRCbTDzhaA.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			hqufqxRejmzmuqNpNpGeRCbTDzhaA.CopyFrom(other.hqufqxRejmzmuqNpNpGeRCbTDzhaA);
			hSwrrRPSemgnsQVpssHhySveqQF = other.hSwrrRPSemgnsQVpssHhySveqQF;
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
			uint id = new LowLevelInputEvent(hqufqxRejmzmuqNpNpGeRCbTDzhaA.GetPointerFromReadPosition((count - 1) * YwEPlbADLhkpTXngEdhZEVSbcnaM), BhCbgrefAhFSrJIISsNLWhvlnnANA, hTtWFqoKfkIVSdGOWffSHmWvCWjfA, afMIxBrXmXrqVGpSHUPmcKwoLJjm).GetId();
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
					IntPtr buffer = hqufqxRejmzmuqNpNpGeRCbTDzhaA.Allocate(YwEPlbADLhkpTXngEdhZEVSbcnaM, zeroFill: false, out passId);
					other.hqufqxRejmzmuqNpNpGeRCbTDzhaA.RandomRead(buffer, YwEPlbADLhkpTXngEdhZEVSbcnaM, YwEPlbADLhkpTXngEdhZEVSbcnaM, other.hqufqxRejmzmuqNpNpGeRCbTDzhaA.GetOffsetFromReadPosition((num + i) * YwEPlbADLhkpTXngEdhZEVSbcnaM));
				}
				hSwrrRPSemgnsQVpssHhySveqQF = other.hSwrrRPSemgnsQVpssHhySveqQF;
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
			if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				if (disposing)
				{
					hqufqxRejmzmuqNpNpGeRCbTDzhaA.Dispose();
				}
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}
	}
}
