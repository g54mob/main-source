using System;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarColor : NetworkedVar<Color>
	{
		public NetworkedVarColor()
		{
		}

		public NetworkedVarColor(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarColor(Color value)
			: base(value)
		{
		}

		public NetworkedVarColor(NetworkedVarSettings settings, Color value)
			: base(settings, value)
		{
		}
	}
}
