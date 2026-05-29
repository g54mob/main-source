using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class LowLevelInputEventQueue : IDisposable
	{
		private LowLevelInputEvent qtRBEfkAnBVPJgTYxpaoSWsoNMwU;

		private readonly NativeRingBuffer MGCEODqGPkFqXEwCJyCQiHrvgXMT;

		private readonly int FgVRNiOQkHAEMEJMtDAjDmSdnSahb;

		private readonly int OBlJBPADjhOXOPmUcnliXSoZtrSu;

		private readonly int AJPjUvLwtoOJcAVTkJtJyNJTuZrF;

		private readonly int nYRjDeeBTlmkJQmRqAujaTSwwKNT;

		private readonly int fKzujcqDOhUcsNjEvixCbtUqHHah;

		private uint IkHhdGkcepwKBMHdhWrrMTOtfIti;

		private bool mupjcCAfiETQiuHgLIIYcjfJYILf;

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
