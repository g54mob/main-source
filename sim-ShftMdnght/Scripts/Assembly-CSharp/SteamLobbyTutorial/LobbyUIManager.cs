using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SteamLobbyTutorial
{
	public class LobbyUIManager : NetworkBehaviour
	{
		public GameObject waitingOnHostIndicator;

		public static LobbyUIManager Instance;

		public Transform playerListParent;

		public List<TextMeshProUGUI> playerNameTexts = new List<TextMeshProUGUI>();

		public List<PlayerLobbyHandler> playerLobbyHandlers = new List<PlayerLobbyHandler>();

		public Button playGameButton;

		public TextMeshProUGUI lobbyTitleText;

		public GameObject[] objectsToTurnOffWhenJoiningLobby;

		public GameObject[] objectsToTurnOnWhenJoiningLobby;

		public GameObject lobbyPanel;

		public SteamLobby steamLobby;

		public AudioSource mainMenuTrack;

		public GameObject memberCountWarning;

		public GameObject unableToJoinLobbyHolder;

		public GameObject inviteFriendsButton;

		public CameraTranslation camTranslation;

		public GameObject canvas;

		public GameObject cutsceneObj;

		public MainMenu mainMenu;

		public GameObject fadeOut;

		public bool inCutscene;

		public GameObject settingsMenu;

		private void FixedUpdate()
		{
			if (inCutscene)
			{
				mainMenuTrack.volume = Mathf.Lerp(mainMenuTrack.volume, 0f, Time.deltaTime * 0.6f);
			}
		}

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else if (Instance != this)
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void Start()
		{
			SetLoadingText();
			PlayerPrefs.SetString("SteamName", SteamFriends.GetPersonaName());
			playGameButton.gameObject.SetActive(value: false);
			inviteFriendsButton.SetActive(value: true);
		}

		public void SetLoadingText()
		{
			lobbyTitleText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			lobbyTitleText.text = JSONAccess.Instance.GetMiscText("UI Text", "Loading...");
		}

		public void UpdatePlayerLobbyUI()
		{
			GameObject[] array = objectsToTurnOffWhenJoiningLobby;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
			array = objectsToTurnOnWhenJoiningLobby;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
			playerNameTexts.Clear();
			playerLobbyHandlers.Clear();
			CSteamID steamIDLobby = new CSteamID(SteamLobby.Instance.lobbyID);
			int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(steamIDLobby);
			if (numLobbyMembers > 3)
			{
				memberCountWarning.SetActive(value: true);
			}
			else
			{
				memberCountWarning.SetActive(value: false);
			}
			CSteamID cSteamID = new CSteamID(ulong.Parse(SteamMatchmaking.GetLobbyData(steamIDLobby, "HostAddress")));
			List<CSteamID> list = new List<CSteamID>();
			if (lobbyTitleText != null)
			{
				string friendPersonaName = SteamFriends.GetFriendPersonaName(cSteamID);
				string miscText = JSONAccess.Instance.GetMiscText("UI Text", "[PLAYER]'s Lobby");
				miscText = miscText.Replace("<PLAYER NAME>", friendPersonaName);
				lobbyTitleText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				lobbyTitleText.text = miscText;
				unableToJoinLobbyHolder.SetActive(value: false);
			}
			if (numLobbyMembers == 0)
			{
				Debug.LogWarning("Lobby has no members.. retrying...");
				StartCoroutine(RetryUpdate());
				return;
			}
			list.Add(cSteamID);
			for (int j = 0; j < numLobbyMembers; j++)
			{
				CSteamID lobbyMemberByIndex = SteamMatchmaking.GetLobbyMemberByIndex(steamIDLobby, j);
				if (lobbyMemberByIndex != cSteamID)
				{
					list.Add(lobbyMemberByIndex);
				}
			}
			int num = 0;
			foreach (CSteamID item in list)
			{
				if (num >= playerListParent.childCount)
				{
					Debug.LogWarning("Not enough UI slots.");
					break;
				}
				TextMeshProUGUI component = playerListParent.GetChild(num).GetChild(0).GetComponent<TextMeshProUGUI>();
				PlayerLobbyHandler component2 = playerListParent.GetChild(num).GetComponent<PlayerLobbyHandler>();
				playerLobbyHandlers.Add(component2);
				playerNameTexts.Add(component);
				string friendPersonaName2 = SteamFriends.GetFriendPersonaName(item);
				playerNameTexts[num].font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				playerNameTexts[num].text = friendPersonaName2;
				num++;
			}
		}

		public void OnPlayButtonClicked()
		{
			PlayerPrefs.SetString("SteamName", SteamFriends.GetPersonaName());
			if (NetworkServer.active)
			{
				SteamMatchmaking.SetLobbyType(new CSteamID(steamLobby.lobbyID), ELobbyType.k_ELobbyTypePrivate);
				Invoke("LoadGame", 5.5f);
				StartCutscene();
			}
		}

		public void InviteFriends()
		{
			if (steamLobby.lobbyID != 0L)
			{
				SteamFriends.ActivateGameOverlayInviteDialog(new CSteamID(steamLobby.lobbyID));
			}
		}

		[ClientRpc]
		public void StartCutscene()
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			SendRPCInternal("System.Void SteamLobbyTutorial.LobbyUIManager::StartCutscene()", -1675895816, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		private void FadeOut()
		{
			fadeOut.SetActive(value: true);
		}

		private void LoadGame()
		{
			CustomNetworkManager.singleton.ServerChangeScene("Game");
		}

		public void RegisterPlayer(PlayerLobbyHandler player)
		{
			player.transform.SetParent(playerListParent, worldPositionStays: false);
			UpdatePlayerLobbyUI();
		}

		[Server]
		public void CheckAllPlayersReady()
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void SteamLobbyTutorial.LobbyUIManager::CheckAllPlayersReady()' called when server was not active");
				return;
			}
			foreach (PlayerLobbyHandler playerLobbyHandler in playerLobbyHandlers)
			{
				if (!playerLobbyHandler.isReady)
				{
					RpcSetPlayButtonInteractable(allPlayersReady: false);
					return;
				}
			}
			RpcSetPlayButtonInteractable(allPlayersReady: true);
		}

		[ClientRpc]
		private void RpcSetPlayButtonInteractable(bool allPlayersReady)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteBool(allPlayersReady);
			SendRPCInternal("System.Void SteamLobbyTutorial.LobbyUIManager::RpcSetPlayButtonInteractable(System.Boolean)", 1796089618, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		private IEnumerator RetryUpdate()
		{
			yield return new WaitForSeconds(1f);
			UpdatePlayerLobbyUI();
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_StartCutscene()
		{
			settingsMenu.SetActive(value: false);
			inCutscene = true;
			lobbyPanel.SetActive(value: false);
			mainMenu.started = true;
			cutsceneObj.SetActive(value: true);
			canvas.SetActive(value: false);
			camTranslation.enabled = false;
			Invoke("FadeOut", 4f);
		}

		protected static void InvokeUserCode_StartCutscene(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC StartCutscene called on server.");
			}
			else
			{
				((LobbyUIManager)obj).UserCode_StartCutscene();
			}
		}

		protected void UserCode_RpcSetPlayButtonInteractable__Boolean(bool allPlayersReady)
		{
			PlayerPrefs.SetString("SteamName", SteamFriends.GetPersonaName());
			if (SteamMatchmaking.GetLobbyMemberByIndex(new CSteamID(SteamLobby.Instance.lobbyID), 0) == SteamUser.GetSteamID())
			{
				playGameButton.gameObject.SetActive(allPlayersReady);
				inviteFriendsButton.SetActive(!allPlayersReady);
				waitingOnHostIndicator?.SetActive(value: false);
			}
			else
			{
				playGameButton.gameObject.SetActive(value: false);
				waitingOnHostIndicator?.SetActive(allPlayersReady);
				inviteFriendsButton.SetActive(!allPlayersReady);
			}
		}

		protected static void InvokeUserCode_RpcSetPlayButtonInteractable__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcSetPlayButtonInteractable called on server.");
			}
			else
			{
				((LobbyUIManager)obj).UserCode_RpcSetPlayButtonInteractable__Boolean(reader.ReadBool());
			}
		}

		static LobbyUIManager()
		{
			RemoteProcedureCalls.RegisterRpc(typeof(LobbyUIManager), "System.Void SteamLobbyTutorial.LobbyUIManager::StartCutscene()", InvokeUserCode_StartCutscene);
			RemoteProcedureCalls.RegisterRpc(typeof(LobbyUIManager), "System.Void SteamLobbyTutorial.LobbyUIManager::RpcSetPlayButtonInteractable(System.Boolean)", InvokeUserCode_RpcSetPlayButtonInteractable__Boolean);
		}
	}
}
