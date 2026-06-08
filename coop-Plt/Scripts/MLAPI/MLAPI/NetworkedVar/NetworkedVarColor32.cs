using System;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarColor32 : NetworkedVar<Color32>
	{
		public NetworkedVarColor32()
		{
		}

		public NetworkedVarColor32(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarColor32(Color32 value)
			: base(value)
		{
		}

		public NetworkedVarColor32(NetworkedVarSettings settings, Color32 value)
			: base(settings, value)
		{
		}
	}
}
