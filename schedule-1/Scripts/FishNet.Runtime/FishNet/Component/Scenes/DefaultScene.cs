using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Scened;
using FishNet.Transporting;
using GameKit.Utilities.Types;
using UnityEngine;
using UnityEngine.Serialization;

namespace FishNet.Component.Scenes
{
	[AddComponentMenu("FishNet/Component/DefaultScene")]
	public class DefaultScene : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("True to enable use of this component.")]
		private bool _enabled;

		[Tooltip("True to load the online scene as global, false to load it as connection.")]
		[FormerlySerializedAs("_useGlobalScenes")]
		[SerializeField]
		private bool _enableGlobalScenes;

		[Tooltip("True to replace all scenes with the offline scene immediately.")]
		[SerializeField]
		private bool _startInOffline;

		[Tooltip("Scene to load when disconnected. Server and client will load this scene.")]
		[SerializeField]
		[Scene]
		private string _offlineScene;

		[Scene]
		[SerializeField]
		[Tooltip("Scene to load when connected. Server and client will load this scene.")]
		private string _onlineScene;

		[SerializeField]
		[Tooltip("Which scenes to replace when loading into OnlineScene.")]
		private ReplaceOption _replaceScenes;

		private NetworkManager _networkManager;

		public void SetOfflineScene(string sceneName)
		{
		}

		public string GetOfflineScene()
		{
			return null;
		}

		public void SetOnlineScene(string sceneName)
		{
		}

		public string GetOnlineScene()
		{
			return null;
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitializeOnce()
		{
		}

		private void SceneManager_OnLoadEnd(SceneLoadEndEventArgs obj)
		{
		}

		private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
		{
		}

		private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
		{
		}

		private void ServerManager_OnAuthenticationResult(NetworkConnection arg1, bool authenticated)
		{
		}

		private void LoadOfflineScene()
		{
		}

		private void UnloadOfflineScene()
		{
		}

		private string GetSceneName(string fullPath)
		{
			return null;
		}
	}
}
