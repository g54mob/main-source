using System;
using UnityEngine.Networking;

namespace MLAPI.Transports
{
	[Serializable]
	public class UnetChannel
	{
		public string Name;

		public QosType Type;
	}
}
