using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarString : NetworkedVar<string>
	{
		public NetworkedVarString()
			: base(string.Empty)
		{
		}

		public NetworkedVarString(NetworkedVarSettings settings)
			: base(settings, string.Empty)
		{
		}

		public NetworkedVarString(string value)
			: base(value)
		{
		}

		public NetworkedVarString(NetworkedVarSettings settings, string value)
			: base(settings, value)
		{
		}
	}
}
