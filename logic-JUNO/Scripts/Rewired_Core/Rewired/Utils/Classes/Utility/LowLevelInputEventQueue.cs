using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent nPqXitOOZhZHmwqvKsHmiNTXWWYt;

		private readonly NativeRingBuffer HMhmLXCnQOuucIneyxXWQMhCDxaD;

		private readonly int SwczyZeApxKnWWlhSlfJYtuGEEhB;

		private readonly int HrIfITiCJJPHzFydFYsqbAZmfheW;

		private readonly int RaovZfdfPYUwRUgqXirPKEsuamNR;

		private readonly int yikblyUAnLuieCuoDLLxEqxNMZzF;

		private readonly int gSKESkOXvRqKJNPbEAPEBJxFkHGMA;

		private uint HgsiREOgGVFsucEOYCjhQazIdzVUA;

		private bool bILPVomOZecNdkZysppYKXAgBIpx;

		public int Count => HMhmLXCnQOuucIneyxXWQMhCDxaD.BytesInBuffer / yikblyUAnLuieCuoDLLxEqxNMZzF;

		public int Capacity => gSKESkOXvRqKJNPbEAPEBJxFkHGMA;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(HMhmLXCnQOuucIneyxXWQMhCDxaD.GetPointerFromReadPosition(index * yikblyUAnLuieCuoDLLxEqxNMZzF), SwczyZeApxKnWWlhSlfJYtuGEEhB, HrIfITiCJJPHzFydFYsqbAZmfheW, RaovZfdfPYUwRUgqXirPKEsuamNR);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			gSKESkOXvRqKJNPbEAPEBJxFkHGMA = P_0;
			SwczyZeApxKnWWlhSlfJYtuGEEhB = P_1;
			HrIfITiCJJPHzFydFYsqbAZmfheW = P_2;
			RaovZfdfPYUwRUgqXirPKEsuamNR = P_3;
			yikblyUAnLuieCuoDLLxEqxNMZzF = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			HMhmLXCnQOuucIneyxXWQMhCDxaD = new NativeRingBuffer(gSKESkOXvRqKJNPbEAPEBJxFkHGMA * yikblyUAnLuieCuoDLLxEqxNMZzF);
			nPqXitOOZhZHmwqvKsHmiNTXWWYt = new LowLevelInputEvent(IntPtr.Zero, SwczyZeApxKnWWlhSlfJYtuGEEhB, HrIfITiCJJPHzFydFYsqbAZmfheW, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = HMhmLXCnQOuucIneyxXWQMhCDxaD.Allocate(yikblyUAnLuieCuoDLLxEqxNMZzF, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, SwczyZeApxKnWWlhSlfJYtuGEEhB, HrIfITiCJJPHzFydFYsqbAZmfheW, RaovZfdfPYUwRUgqXirPKEsuamNR);
			result.SetId(HgsiREOgGVFsucEOYCjhQazIdzVUA = MiscTools.Tick(HgsiREOgGVFsucEOYCjhQazIdzVUA));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = HMhmLXCnQOuucIneyxXWQMhCDxaD.BytesInBuffer / yikblyUAnLuieCuoDLLxEqxNMZzF;
			if (num == 0)
			{
				return -1;
			}
			nPqXitOOZhZHmwqvKsHmiNTXWWYt._buffer = HMhmLXCnQOuucIneyxXWQMhCDxaD.GetPointerFromReadPosition(0);
			uint num2 = nPqXitOOZhZHmwqvKsHmiNTXWWYt.GetId();
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
			if (index < 0 || index >= HMhmLXCnQOuucIneyxXWQMhCDxaD.BytesInBuffer / yikblyUAnLuieCuoDLLxEqxNMZzF)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(HMhmLXCnQOuucIneyxXWQMhCDxaD.GetPointerFromReadPosition(index * yikblyUAnLuieCuoDLLxEqxNMZzF), SwczyZeApxKnWWlhSlfJYtuGEEhB, HrIfITiCJJPHzFydFYsqbAZmfheW, RaovZfdfPYUwRUgqXirPKEsuamNR);
			return true;
		}

		public void Clear()
		{
			HMhmLXCnQOuucIneyxXWQMhCDxaD.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			HMhmLXCnQOuucIneyxXWQMhCDxaD.CopyFrom(other.HMhmLXCnQOuucIneyxXWQMhCDxaD);
			HgsiREOgGVFsucEOYCjhQazIdzVUA = other.HgsiREOgGVFsucEOYCjhQazIdzVUA;
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
			uint id = new LowLevelInputEvent(HMhmLXCnQOuucIneyxXWQMhCDxaD.GetPointerFromReadPosition((count - 1) * yikblyUAnLuieCuoDLLxEqxNMZzF), SwczyZeApxKnWWlhSlfJYtuGEEhB, HrIfITiCJJPHzFydFYsqbAZmfheW, RaovZfdfPYUwRUgqXirPKEsuamNR).GetId();
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
					IntPtr buffer = HMhmLXCnQOuucIneyxXWQMhCDxaD.Allocate(yikblyUAnLuieCuoDLLxEqxNMZzF, zeroFill: false, out passId);
					other.HMhmLXCnQOuucIneyxXWQMhCDxaD.RandomRead(buffer, yikblyUAnLuieCuoDLLxEqxNMZzF, yikblyUAnLuieCuoDLLxEqxNMZzF, other.HMhmLXCnQOuucIneyxXWQMhCDxaD.GetOffsetFromReadPosition((num + i) * yikblyUAnLuieCuoDLLxEqxNMZzF));
				}
				HgsiREOgGVFsucEOYCjhQazIdzVUA = other.HgsiREOgGVFsucEOYCjhQazIdzVUA;
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
			if (!bILPVomOZecNdkZysppYKXAgBIpx)
			{
				if (disposing)
				{
					HMhmLXCnQOuucIneyxXWQMhCDxaD.Dispose();
				}
				bILPVomOZecNdkZysppYKXAgBIpx = true;
			}
		}
	}
}
