using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarDouble : NetworkedVar<double>
	{
		public NetworkedVarDouble()
		{
		}

		public NetworkedVarDouble(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarDouble(double value)
			: base(value)
		{
		}

		public NetworkedVarDouble(NetworkedVarSettings settings, double value)
			: base(settings, value)
		{
		}
	}
}
