using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarUInt : NetworkedVar<uint>
	{
		public NetworkedVarUInt()
		{
		}

		public NetworkedVarUInt(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarUInt(uint value)
			: base(value)
		{
		}

		public NetworkedVarUInt(NetworkedVarSettings settings, uint value)
			: base(settings, value)
		{
		}
	}
}
