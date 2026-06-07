using System.Collections.Generic;

namespace Coherence.RSL.Transport
{
	public class IDSource
	{
		private ushort lastAllocatedConnectionIDValue;

		private HashSet<ConnectionID> connections;

		private ushort maxCount;

		public IDSource()
		{
		}

		public IDSource(int count)
		{
		}

		public ConnectionID FindFreeConnectionID()
		{
			return default(ConnectionID);
		}

		public void ReturnConnectionID(ConnectionID id)
		{
		}
	}
}
