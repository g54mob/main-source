using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarBool : NetworkedVar<bool>
	{
		public NetworkedVarBool()
		{
		}

		public NetworkedVarBool(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarBool(bool value)
			: base(value)
		{
		}

		public NetworkedVarBool(NetworkedVarSettings settings, bool value)
			: base(settings, value)
		{
		}
	}
}
