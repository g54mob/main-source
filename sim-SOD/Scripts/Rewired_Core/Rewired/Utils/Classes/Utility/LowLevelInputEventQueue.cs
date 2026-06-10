using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent oESDTFfVaEvPjDvtwnhLvFNySdQ;

		private readonly NativeRingBuffer tfufjqCTpYEwMmqJIOibIFCBISwH;

		private readonly int RrYxBmqUSBCLFEwCTngUveIoIMP;

		private readonly int nghLKlaBbOhGsidmJgHBsFfgVzeE;

		private readonly int ytCbcYFzcbeuxEWyOxjxqlFvpeq;

		private readonly int AiMAJyKHcPhghBBSDLUCOptkMrx;

		private readonly int rtqrHvewxklzNjBhCjGqlvHCVXC;

		private uint tYGeTwRaOOggVaajqGIKjjjgKRRr;

		private bool PrvylHtjoIHWmYgGfZyfZonoJFJ;

		public int Count => 0;

		public int Capacity => 0;

		public LowLevelInputEvent this[int index] => default(LowLevelInputEvent);

		public LowLevelInputEventQueue(int capacity, int buttonCount, int axisCount, int hatCount)
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
