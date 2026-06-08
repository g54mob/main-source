using System;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarByte : NetworkedVar<byte>
	{
		public NetworkedVarByte()
		{
		}

		public NetworkedVarByte(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarByte(byte value)
			: base(value)
		{
		}

		public NetworkedVarByte(NetworkedVarSettings settings, byte value)
			: base(settings, value)
		{
		}
	}
}
