using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarLong : NetworkedVar<long>
	{
		public NetworkedVarLong()
		{
		}

		public NetworkedVarLong(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarLong(long value)
			: base(value)
		{
		}

		public NetworkedVarLong(NetworkedVarSettings settings, long value)
			: base(settings, value)
		{
		}
	}
}
