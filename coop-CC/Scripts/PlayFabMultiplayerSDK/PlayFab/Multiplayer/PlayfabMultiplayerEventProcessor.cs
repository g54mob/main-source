using PlayFab.Internal;
using UnityEngine;

namespace PlayFab.Multiplayer
{
	public class PlayfabMultiplayerEventProcessor : MonoBehaviour
	{
		private void Awake()
		{
			Object.DontDestroyOnLoad(this);
			if (!PlayFabMultiplayer.IsInitialized)
			{
				PlayFabMultiplayer.Initialize();
			}
		}

		private void Update()
		{
			PlayFabMultiplayer.ProcessLobbyStateChanges();
			PlayFabMultiplayer.ProcessMatchmakingStateChanges();
			if (PlayFabMultiplayer.IsInitialized)
			{
				SingletonMonoBehaviour<PlayFabMultiplayerEventTracer>.instance.DoWork();
			}
		}

		private void OnDestroy()
		{
			PlayFabMultiplayer.Uninitialize();
		}
	}
}
