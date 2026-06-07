using System;

namespace Coherence.Toolkit
{
	public class UniqueObjectReplacement
	{
		public ICoherenceSync localObject;

		internal Action<ICoherenceSync> localObjectInit;

		public CoherenceSync Sync => null;

		internal bool ReplaceReady => false;

		internal UniqueObjectReplacement()
		{
		}
	}
}
