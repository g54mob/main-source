using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent YcMVezGaIWHsJzgyvbwehxCselME;

		private readonly NativeRingBuffer ohZYRXOWqpAeBLPqVbRQNwylXxoP;

		private readonly int ziOZKsodPKHQIVUabiLjcXNfJcOrA;

		private readonly int aoktSDkQEysBEIIcaNawgxbRoZip;

		private readonly int onOeOxvdCtYNaTulkKCPXXWLCxTH;

		private readonly int RECwUwAquaSmTBthkahzVkLofmrn;

		private readonly int PbgdvwIAoqEKkkUobDvMzCVabpERA;

		private uint mmWBwCGUJqwwDHgVjIJvtNZhVNRr;

		private bool OYfmxcmpABHaGbVnNPhATFcLKars;

		public int Count => ohZYRXOWqpAeBLPqVbRQNwylXxoP.BytesInBuffer / RECwUwAquaSmTBthkahzVkLofmrn;

		public int Capacity => PbgdvwIAoqEKkkUobDvMzCVabpERA;

		public LowLevelInputEvent this[int index] => new LowLevelInputEvent(ohZYRXOWqpAeBLPqVbRQNwylXxoP.GetPointerFromReadPosition(index * RECwUwAquaSmTBthkahzVkLofmrn), ziOZKsodPKHQIVUabiLjcXNfJcOrA, aoktSDkQEysBEIIcaNawgxbRoZip, onOeOxvdCtYNaTulkKCPXXWLCxTH);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
			PbgdvwIAoqEKkkUobDvMzCVabpERA = P_0;
			ziOZKsodPKHQIVUabiLjcXNfJcOrA = P_1;
			aoktSDkQEysBEIIcaNawgxbRoZip = P_2;
			onOeOxvdCtYNaTulkKCPXXWLCxTH = P_3;
			RECwUwAquaSmTBthkahzVkLofmrn = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
			ohZYRXOWqpAeBLPqVbRQNwylXxoP = new NativeRingBuffer(PbgdvwIAoqEKkkUobDvMzCVabpERA * RECwUwAquaSmTBthkahzVkLofmrn);
			YcMVezGaIWHsJzgyvbwehxCselME = new LowLevelInputEvent(IntPtr.Zero, ziOZKsodPKHQIVUabiLjcXNfJcOrA, aoktSDkQEysBEIIcaNawgxbRoZip, P_3);
		}

		public LowLevelInputEvent CreateEvent()
		{
			uint passId;
			IntPtr intPtr = ohZYRXOWqpAeBLPqVbRQNwylXxoP.Allocate(RECwUwAquaSmTBthkahzVkLofmrn, zeroFill: false, out passId);
			LowLevelInputEvent result = new LowLevelInputEvent(intPtr, ziOZKsodPKHQIVUabiLjcXNfJcOrA, aoktSDkQEysBEIIcaNawgxbRoZip, onOeOxvdCtYNaTulkKCPXXWLCxTH);
			result.SetId(mmWBwCGUJqwwDHgVjIJvtNZhVNRr = MiscTools.Tick(mmWBwCGUJqwwDHgVjIJvtNZhVNRr));
			return result;
		}

		public int FindNextIndex(uint id)
		{
			int num = ohZYRXOWqpAeBLPqVbRQNwylXxoP.BytesInBuffer / RECwUwAquaSmTBthkahzVkLofmrn;
			if (num == 0)
			{
				return -1;
			}
			YcMVezGaIWHsJzgyvbwehxCselME._buffer = ohZYRXOWqpAeBLPqVbRQNwylXxoP.GetPointerFromReadPosition(0);
			uint num2 = YcMVezGaIWHsJzgyvbwehxCselME.GetId();
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
			if (index < 0 || index >= ohZYRXOWqpAeBLPqVbRQNwylXxoP.BytesInBuffer / RECwUwAquaSmTBthkahzVkLofmrn)
			{
				@event = default(LowLevelInputEvent);
				return false;
			}
			@event = new LowLevelInputEvent(ohZYRXOWqpAeBLPqVbRQNwylXxoP.GetPointerFromReadPosition(index * RECwUwAquaSmTBthkahzVkLofmrn), ziOZKsodPKHQIVUabiLjcXNfJcOrA, aoktSDkQEysBEIIcaNawgxbRoZip, onOeOxvdCtYNaTulkKCPXXWLCxTH);
			return true;
		}

		public void Clear()
		{
			ohZYRXOWqpAeBLPqVbRQNwylXxoP.Reset();
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			ohZYRXOWqpAeBLPqVbRQNwylXxoP.CopyFrom(other.ohZYRXOWqpAeBLPqVbRQNwylXxoP);
			mmWBwCGUJqwwDHgVjIJvtNZhVNRr = other.mmWBwCGUJqwwDHgVjIJvtNZhVNRr;
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
			uint id = new LowLevelInputEvent(ohZYRXOWqpAeBLPqVbRQNwylXxoP.GetPointerFromReadPosition((count - 1) * RECwUwAquaSmTBthkahzVkLofmrn), ziOZKsodPKHQIVUabiLjcXNfJcOrA, aoktSDkQEysBEIIcaNawgxbRoZip, onOeOxvdCtYNaTulkKCPXXWLCxTH).GetId();
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
					IntPtr buffer = ohZYRXOWqpAeBLPqVbRQNwylXxoP.Allocate(RECwUwAquaSmTBthkahzVkLofmrn, zeroFill: false, out passId);
					other.ohZYRXOWqpAeBLPqVbRQNwylXxoP.RandomRead(buffer, RECwUwAquaSmTBthkahzVkLofmrn, RECwUwAquaSmTBthkahzVkLofmrn, other.ohZYRXOWqpAeBLPqVbRQNwylXxoP.GetOffsetFromReadPosition((num + i) * RECwUwAquaSmTBthkahzVkLofmrn));
				}
				mmWBwCGUJqwwDHgVjIJvtNZhVNRr = other.mmWBwCGUJqwwDHgVjIJvtNZhVNRr;
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
			if (!OYfmxcmpABHaGbVnNPhATFcLKars)
			{
				if (disposing)
				{
					ohZYRXOWqpAeBLPqVbRQNwylXxoP.Dispose();
				}
				OYfmxcmpABHaGbVnNPhATFcLKars = true;
			}
		}
	}
}
