using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent fQWfOfxkJSVeJUMVGiQIQPqWnMls;

		private readonly NativeRingBuffer ZjNdAHzyxnGHHwwBqtqiyvpDgPRy;

		private readonly int INGJMqZWAEnuYaiVEqRRcIKNIBhk;

		private readonly int FKkXSVNcHuCmMpRNFFHOPtmhtvLX;

		private readonly int VaWkbtSLLvPvyqlEHDptsCHpowat;

		private readonly int gNIBQmlHruaBPuJYBTMPsSYUCKAm;

		private readonly int wRyyeqnBrazzelmFCmYijNQCHtxk;

		private uint XjSxhMvvEclJRkHuYHkNSHKLdfsZ;

		private bool xuncdwBJDBeqIEMWqSueXglhoQSKA;

		public int Count => 0;

		public int Capacity => 0;

		public int CapacityBytes => 0;

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
