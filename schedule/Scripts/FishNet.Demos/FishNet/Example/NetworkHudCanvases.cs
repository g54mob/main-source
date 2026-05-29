using FishNet.Managing;
using FishNet.Transporting;
using UnityEngine;
using UnityEngine.UI;

namespace FishNet.Example
{
	public class NetworkHudCanvases : MonoBehaviour
	{
		private enum AutoStartType
		{
			Disabled = 0,
			Host = 1,
			Server = 2,
			Client = 3
		}

		[SerializeField]
		[Tooltip("What connections to automatically start on play.")]
		private AutoStartType _autoStartType;

		[Tooltip("Color when socket is stopped.")]
		[SerializeField]
		private Color _stoppedColor;

		[Tooltip("Color when socket is changing.")]
		[SerializeField]
		private Color _changingColor;

		[Tooltip("Color when socket is started.")]
		[SerializeField]
		private Color _startedColor;

		[Header("Indicators")]
		[SerializeField]
		[Tooltip("Indicator for server state.")]
		private Image _serverIndicator;

		[Tooltip("Indicator for client state.")]
		[SerializeField]
		private Image _clientIndicator;

		[SerializeField]
		private bool DrawGUI;

		private NetworkManager _networkManager;

		private LocalConnectionState _clientState;

		private LocalConnectionState _serverState;

		private void OnGUI()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdateColor(LocalConnectionState state, ref Image img)
		{
		}

		private void ClientManager_OnClientConnectionState(ClientConnectionStateArgs obj)
		{
		}

		private void ServerManager_OnServerConnectionState(ServerConnectionStateArgs obj)
		{
		}

		public void OnClick_Server()
		{
		}

		public void OnClick_Client()
		{
		}

		private void SetEventSystem()
		{
		}

		private void DeselectButtons()
		{
		}
	}
}
