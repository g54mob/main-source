using System;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarVector4 : NetworkedVar<Vector4>
	{
		public NetworkedVarVector4()
		{
		}

		public NetworkedVarVector4(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarVector4(Vector4 value)
			: base(value)
		{
		}

		public NetworkedVarVector4(NetworkedVarSettings settings, Vector4 value)
			: base(settings, value)
		{
		}
	}
}
