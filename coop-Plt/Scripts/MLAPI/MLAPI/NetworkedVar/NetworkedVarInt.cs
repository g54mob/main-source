using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarInt : NetworkedVar<int>
	{
		public NetworkedVarInt()
		{
		}

		public NetworkedVarInt(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarInt(int value)
			: base(value)
		{
		}

		public NetworkedVarInt(NetworkedVarSettings settings, int value)
			: base(settings, value)
		{
		}
	}
}
