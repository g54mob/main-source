using System;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarRay : NetworkedVar<Ray>
	{
		public NetworkedVarRay()
		{
		}

		public NetworkedVarRay(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarRay(Ray value)
			: base(value)
		{
		}

		public NetworkedVarRay(NetworkedVarSettings settings, Ray value)
			: base(settings, value)
		{
		}
	}
}
