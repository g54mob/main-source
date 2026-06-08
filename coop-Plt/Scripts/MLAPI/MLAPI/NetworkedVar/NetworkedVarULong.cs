using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarULong : NetworkedVar<ulong>
	{
		public NetworkedVarULong()
		{
		}

		public NetworkedVarULong(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarULong(ulong value)
			: base(value)
		{
		}

		public NetworkedVarULong(NetworkedVarSettings settings, ulong value)
			: base(settings, value)
		{
		}
	}
}
