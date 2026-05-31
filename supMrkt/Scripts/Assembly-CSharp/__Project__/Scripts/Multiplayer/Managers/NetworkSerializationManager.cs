using UnityEngine;

namespace __Project__.Scripts.Multiplayer.Managers
{
	public class NetworkSerializationManager : NoktaSingletonPunCallbacks<NetworkSerializationManager>
	{
		private static bool m_Registered;

		[RuntimeInitializeOnLoadMethod]
		private void Reset()
		{
		}

		private void Awake()
		{
		}
	}
}
