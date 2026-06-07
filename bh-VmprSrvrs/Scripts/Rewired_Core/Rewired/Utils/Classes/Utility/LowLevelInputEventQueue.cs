using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent rqsRZLEaipJlZvEMODMpejcLbKreb;

		private readonly NativeRingBuffer XthVhnYMAUUmJTbOmIoVHntWaTHx;

		private readonly int IqqYTEycxtggARgAAFqyVZOQbIhX;

		private readonly int VvAQjbmWkXnyGCGALRnlcCsuArBW;

		private readonly int FFypiNzEkEEseGDBZHhAaDFficomc;

		private readonly int cseCdGWdSNUuZPzNRWFeToKLAiQK;

		private readonly int eTGbnIAWQJkesDSUYuSDnYMDgDvaA;

		private uint XZwZqyGlfZAORDJnWDkmkfEOlfoxA;

		private bool lRDvuCeVocStAfpHwEcRFCfotOSx;

		public int Count => 0;

		public int Capacity => 0;

		public LowLevelInputEvent this[int index] => default(LowLevelInputEvent);

		public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
		{
		}

		public LowLevelInputEvent CreateEvent()
		{
			return default(LowLevelInputEvent);
		}

		public int FindNextIndex(uint id)
		{
			return 0;
		}

		public bool TryGetNext(int index, out LowLevelInputEvent @event)
		{
			@event = default(LowLevelInputEvent);
			return false;
		}

		public void Clear()
		{
		}

		public void CopyAllFrom(LowLevelInputEventQueue other)
		{
		}

		public void CopyNewEventsFrom(LowLevelInputEventQueue other)
		{
		}

		public void Dispose()
		{
		}

		~LowLevelInputEventQueue()
		{
		}

		protected void Dispose(bool disposing)
		{
		}
	}
}
