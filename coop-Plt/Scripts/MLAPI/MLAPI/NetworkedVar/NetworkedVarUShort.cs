using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarUShort : NetworkedVar<ushort>
	{
		public NetworkedVarUShort()
		{
		}

		public NetworkedVarUShort(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarUShort(ushort value)
			: base(value)
		{
		}

		public NetworkedVarUShort(NetworkedVarSettings settings, ushort value)
			: base(settings, value)
		{
		}
	}
}
