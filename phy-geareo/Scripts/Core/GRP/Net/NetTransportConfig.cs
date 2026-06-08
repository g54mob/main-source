using UnityEngine;

namespace GRP.Net
{
	public abstract class NetTransportConfig : ScriptableObject
	{
		public abstract NetTransport CreateTransport();
	}
}
