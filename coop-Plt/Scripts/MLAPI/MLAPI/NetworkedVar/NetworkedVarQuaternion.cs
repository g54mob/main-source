using System;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarQuaternion : NetworkedVar<Quaternion>
	{
		public NetworkedVarQuaternion()
		{
		}

		public NetworkedVarQuaternion(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarQuaternion(Quaternion value)
			: base(value)
		{
		}

		public NetworkedVarQuaternion(NetworkedVarSettings settings, Quaternion value)
			: base(settings, value)
		{
		}
	}
}
