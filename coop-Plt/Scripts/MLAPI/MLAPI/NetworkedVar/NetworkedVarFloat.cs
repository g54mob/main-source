using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarFloat : NetworkedVar<float>
	{
		public NetworkedVarFloat()
		{
		}

		public NetworkedVarFloat(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarFloat(float value)
			: base(value)
		{
		}

		public NetworkedVarFloat(NetworkedVarSettings settings, float value)
			: base(settings, value)
		{
		}
	}
}
