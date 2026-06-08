using System;
using UnityEngine;

namespace MLAPI.NetworkedVar
{
	[Serializable]
	public class NetworkedVarVector2 : NetworkedVar<Vector2>
	{
		public NetworkedVarVector2()
		{
		}

		public NetworkedVarVector2(NetworkedVarSettings settings)
			: base(settings)
		{
		}

		public NetworkedVarVector2(Vector2 value)
			: base(value)
		{
		}

		public NetworkedVarVector2(NetworkedVarSettings settings, Vector2 value)
			: base(settings, value)
		{
		}
	}
}
