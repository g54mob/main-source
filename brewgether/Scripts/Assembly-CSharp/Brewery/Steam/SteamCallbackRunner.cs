using Steamworks;
using UnityEngine;

namespace Brewery.Steam
{
	public class SteamCallbackRunner : MonoBehaviour
	{
		private Callback<GameLobbyJoinRequested_t> earlyJoinCallback;

		public static CSteamID PendingJoinLobbyId { get; set; }

		private void Awake()
		{
		}

		private void OnEarlyGameLobbyJoinRequested(GameLobbyJoinRequested_t callback)
		{
		}

		private void CheckCommandLineJoinEarly()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnApplicationQuit()
		{
		}
	}
}
