using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarSByte : NetworkedVar<sbyte>
	{
		public NetworkedVarSByte()
		{
		}

		public NetworkedVarSByte(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarSByte(sbyte value)
			: base(value)
		{
		}

		public NetworkedVarSByte(NetworkedVarSettings settings, sbyte value)
			: base(settings, value)
		{
		}
	}
}
