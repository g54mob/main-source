using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarShort : NetworkedVar<short>
	{
		public NetworkedVarShort()
		{
		}

		public NetworkedVarShort(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarShort(short value)
			: base(value)
		{
		}

		public NetworkedVarShort(NetworkedVarSettings settings, short value)
			: base(settings, value)
		{
		}
	}
}
