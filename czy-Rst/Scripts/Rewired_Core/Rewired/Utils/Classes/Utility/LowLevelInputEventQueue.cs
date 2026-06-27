using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent uqVcgWEPQYzwxSepyGkTDGRjrAoiB;

		private readonly NativeRingBuffer ATCmaFBqOzXbMIxbACrVkQnqNWLB;

		private readonly int JnHjqJbTDQfrwYbwyOoKcttoCmeD;

		private readonly int KhpxiIrUovqaiDlfEbLFHXFEhIlc;

		private readonly int WcNhVUfyIddlYHYyArBczkcmAirgc;

		private readonly int nKFrRHFiuxFxEWwrUgYYwvhJEXZ;

		private readonly int jTpoSDXxcufhULwvsfyhtkflaZcs;

		private uint IyTRRhNbJaOXxSTAwnKQEifqGnpFA;

		private bool iraKLZbeGHDguisaCfYboXQAASZcA;

		public int Count => ATCmaFBqOzXbMIxbACrVkQnqNWLB.BytesInBuffer / nKFrRHFiuxFxEWwrUgYYwvhJEXZ;

		public int Capacity => jTpoSDXxcufhULwvsfyhtkflaZcs;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(ATCmaFBqOzXbMIxbACrVkQnqNWLB.GetPointerFromReadPosition(index * nKFrRHFiuxFxEWwrUgYYwvhJEXZ), JnHjqJbTDQfrwYbwyOoKcttoCmeD, KhpxiIrUovqaiDlfEbLFHXFEhIlc, WcNhVUfyIddlYHYyArBczkcmAirgc);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			jTpoSDXxcufhULwvsfyhtkflaZcs = P_0;
			JnHjqJbTDQfrwYbwyOoKcttoCmeD = P_1;
			KhpxiIrUovqaiDlfEbLFHXFEhIlc = P_2;
			WcNhVUfyIddlYHYyArBczkcmAirgc = P_3;
			nKFrRHFiuxFxEWwrUgYYwvhJEXZ = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			ATCmaFBqOzXbMIxbACrVkQnqNWLB = new NativeRingBuffer(jTpoSDXxcufhULwvsfyhtkflaZcs * nKFrRHFiuxFxEWwrUgYYwvhJEXZ);
			uqVcgWEPQYzwxSepyGkTDGRjrAoiB = new LowLevelInputEvent(IntPtr.Zero, JnHjqJbTDQfrwYbwyOoKcttoCmeD, KhpxiIrUovqaiDlfEbLFHXFEhIlc, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = ATCmaFBqOzXbMIxbACrVkQnqNWLB.Allocate(nKFrRHFiuxFxEWwrUgYYwvhJEXZ, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, JnHjqJbTDQfrwYbwyOoKcttoCmeD, KhpxiIrUovqaiDlfEbLFHXFEhIlc, WcNhVUfyIddlYHYyArBczkcmAirgc);
			result.SetId(IyTRRhNbJaOXxSTAwnKQEifqGnpFA = MiscTools.Tick(IyTRRhNbJaOXxSTAwnKQEifqGnpFA));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = ATCmaFBqOzXbMIxbACrVkQnqNWLB.BytesInBuffer / nKFrRHFiuxFxEWwrUgYYwvhJEXZ;
			if (num == 0)
			{
				return -1;
			}
			uqVcgWEPQYzwxSepyGkTDGRjrAoiB._buffer = ATCmaFBqOzXbMIxbACrVkQnqNWLB.GetPointerFromReadPosition(0);
			uint num2 = uqVcgWEPQYzwxSepyGkTDGRjrAoiB.GetId();
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
			if (index < 0 || index >= ATCmaFBqOzXbMIxbACrVkQnqNWLB.BytesInBuffer / nKFrRHFiuxFxEWwrUgYYwvhJEXZ)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(ATCmaFBqOzXbMIxbACrVkQnqNWLB.GetPointerFromReadPosition(index * nKFrRHFiuxFxEWwrUgYYwvhJEXZ), JnHjqJbTDQfrwYbwyOoKcttoCmeD, KhpxiIrUovqaiDlfEbLFHXFEhIlc, WcNhVUfyIddlYHYyArBczkcmAirgc);
			return true;
		}

		public void Clear()
		{
			ATCmaFBqOzXbMIxbACrVkQnqNWLB.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			ATCmaFBqOzXbMIxbACrVkQnqNWLB.CopyFrom(other.ATCmaFBqOzXbMIxbACrVkQnqNWLB);
			IyTRRhNbJaOXxSTAwnKQEifqGnpFA = other.IyTRRhNbJaOXxSTAwnKQEifqGnpFA;
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
			uint id = new LowLevelInputEvent(ATCmaFBqOzXbMIxbACrVkQnqNWLB.GetPointerFromReadPosition((count - 1) * nKFrRHFiuxFxEWwrUgYYwvhJEXZ), JnHjqJbTDQfrwYbwyOoKcttoCmeD, KhpxiIrUovqaiDlfEbLFHXFEhIlc, WcNhVUfyIddlYHYyArBczkcmAirgc).GetId();
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
					IntPtr buffer = ATCmaFBqOzXbMIxbACrVkQnqNWLB.Allocate(nKFrRHFiuxFxEWwrUgYYwvhJEXZ, zeroFill: false, out passId);
					other.ATCmaFBqOzXbMIxbACrVkQnqNWLB.RandomRead(buffer, nKFrRHFiuxFxEWwrUgYYwvhJEXZ, nKFrRHFiuxFxEWwrUgYYwvhJEXZ, other.ATCmaFBqOzXbMIxbACrVkQnqNWLB.GetOffsetFromReadPosition((num + i) * nKFrRHFiuxFxEWwrUgYYwvhJEXZ));
				}
				IyTRRhNbJaOXxSTAwnKQEifqGnpFA = other.IyTRRhNbJaOXxSTAwnKQEifqGnpFA;
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
			if (!iraKLZbeGHDguisaCfYboXQAASZcA)
			{
				if (disposing)
				{
					ATCmaFBqOzXbMIxbACrVkQnqNWLB.Dispose();
				}
				iraKLZbeGHDguisaCfYboXQAASZcA = true;
			}
		}
	}
}
