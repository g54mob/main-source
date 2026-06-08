using System;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarVector3 : NetworkedVar<Vector3>
	{
		public NetworkedVarVector3()
		{
		}

		public NetworkedVarVector3(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarVector3(Vector3 value)
			: base(value)
		{
		}

		public NetworkedVarVector3(NetworkedVarSettings settings, Vector3 value)
			: base(settings, value)
		{
		}
	}
}
