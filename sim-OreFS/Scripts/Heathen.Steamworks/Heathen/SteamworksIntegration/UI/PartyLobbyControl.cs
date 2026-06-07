using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Heathen.SteamworksIntegration.API;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/party-lobby-control")]
	public class PartyLobbyControl : MonoBehaviour
	{
		[Header("Local User Features")]
		public GameObject userOwnerPip;

		public Button readyButton;

		public Button notReadyButton;

		public Button leaveButton;

		[Header("Configuration")]
		public bool autoJoinOnInvite;

		public RectTransform invitePanel;

		public FriendInviteDropDown inviteDropdown;

		public LobbyMemberSlot[] slots;

		public bool updateRichPresenceGroupData = true;

		[Header("Chat")]
		public int maxMessages = 200;

		public GameObject chatPanel;

		public TMP_InputField inputField;

		public ScrollRect scrollView;

		public Transform messageRoot;

		public GameObject myChatTemplate;

		public GameObject theirChatTemplate;

		[Header("Events")]
		public LobbyDataEvent evtSessionLobbyInvite;

		public GameLobbyJoinRequestedEvent evtGroupLobbyInvite;

		private readonly List<IChatMessage> chatMessages = new List<IChatMessage>();

		private LobbyData inviteLobbyData;

		private LobbyData loadingLobbyData;

		private UserData groupInviteFrom;

		private Canvas canvas;

		public LobbyData Lobby { get; set; }

		public bool HasLobby
		{
			get
			{
				if (Lobby != CSteamID.Nil.m_SteamID)
				{
					return SteamMatchmaking.GetNumLobbyMembers(Lobby) > 0;
				}
				return false;
			}
		}

		public bool IsPlayerOwner => Lobby.IsOwner;

		public bool AllPlayersReady => Lobby.AllPlayersReady;

		public bool IsPlayerReady
		{
			get
			{
				return Matchmaking.Client.GetLobbyMemberData(Lobby, User.Client.Id, "z_heathenReady") == "true";
			}
			set
			{
				Matchmaking.Client.SetLobbyMemberData(Lobby, "z_heathenReady", value.ToString().ToLower());
			}
		}

		private void Start()
		{
			canvas = GetComponentInParent<Canvas>();
			inviteDropdown.Invited.AddListener(InvitedUserToLobby);
			if (readyButton != null)
			{
				readyButton.onClick.AddListener(HandleReadyClicked);
			}
			if (notReadyButton != null)
			{
				notReadyButton.onClick.AddListener(HandleNotReadyClicked);
			}
			leaveButton.onClick.AddListener(HandleLeaveClicked);
			LobbyData lobby = Matchmaking.Client.memberOfLobbies.FirstOrDefault((LobbyData p) => p.IsGroup);
			if (lobby.IsValid)
			{
				Lobby = lobby;
			}
			Overlay.Client.EventGameLobbyJoinRequested.AddListener(HandleLobbyJoinRequest);
			Matchmaking.Client.EventLobbyChatMsg.AddListener(HandleChatMessage);
			Matchmaking.Client.EventLobbyEnterSuccess.AddListener(HandleLobbyEnterSuccess);
			Matchmaking.Client.EventLobbyAskedToLeave.AddListener(HandleLobbyKickRequest);
			Matchmaking.Client.EventLobbyDataUpdate.AddListener(HandleLobbyDataUpdated);
			Matchmaking.Client.EventLobbyChatUpdate.AddListener(HandleChatUpdate);
			if (App.Initialized)
			{
				RefreshUI();
			}
			else
			{
				App.evtSteamInitialized.AddListener(HandleSteamInitialization);
			}
		}

		private void HandleSteamInitialization()
		{
			RefreshUI();
			App.evtSteamInitialized.RemoveListener(HandleSteamInitialization);
		}

		private void OnDestroy()
		{
			Overlay.Client.EventGameLobbyJoinRequested.RemoveListener(HandleLobbyJoinRequest);
			Matchmaking.Client.EventLobbyChatMsg.RemoveListener(HandleChatMessage);
			Matchmaking.Client.EventLobbyEnterSuccess.RemoveListener(HandleLobbyEnterSuccess);
			Matchmaking.Client.EventLobbyAskedToLeave.RemoveListener(HandleLobbyKickRequest);
			Matchmaking.Client.EventLobbyDataUpdate.RemoveListener(HandleLobbyDataUpdated);
			Matchmaking.Client.EventLobbyChatUpdate.RemoveListener(HandleChatUpdate);
		}

		private void Update()
		{
			if (invitePanel.gameObject.activeSelf && !inviteDropdown.IsExpanded && ((Mouse.current.leftButton.wasPressedThisFrame && !RectTransformUtility.RectangleContainsScreenPoint(invitePanel, Mouse.current.position.ReadValue(), (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay) ? canvas.worldCamera : null)) || Keyboard.current.escapeKey.wasPressedThisFrame))
			{
				inviteDropdown.gameObject.SetActive(value: false);
				inviteDropdown.InputText = string.Empty;
			}
			if (EventSystem.current.currentSelectedGameObject == inputField.gameObject && (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame))
			{
				OnSendChatMessage();
			}
		}

		private void HandleChatUpdate(LobbyChatUpdate_t arg0)
		{
			if (arg0.m_ulSteamIDLobby == Lobby)
			{
				if (arg0.m_rgfChatMemberStateChange == 1)
				{
					Friends.Client.SetPlayedWith(arg0.m_ulSteamIDUserChanged);
				}
				RefreshUI();
			}
		}

		private void OnSendChatMessage()
		{
			if (HasLobby && !string.IsNullOrEmpty(inputField.text))
			{
				Lobby.SendChatMessage(inputField.text);
				inputField.text = string.Empty;
				StartCoroutine(SelectInputField());
			}
		}

		private void HandleLeaveClicked()
		{
			if (HasLobby)
			{
				Lobby.Leave();
				Lobby = default(LobbyData);
				RefreshUI();
			}
		}

		private void HandleNotReadyClicked()
		{
			IsPlayerReady = false;
			RefreshUI();
		}

		private void HandleReadyClicked()
		{
			IsPlayerReady = true;
			RefreshUI();
		}

		private void HandleLobbyDataUpdated(LobbyDataUpdateEventData arg0)
		{
			if (arg0.lobby == Lobby)
			{
				RefreshUI();
			}
			else if (arg0.lobby == inviteLobbyData && inviteLobbyData.IsGroup)
			{
				if (autoJoinOnInvite)
				{
					if (HasLobby && Lobby != inviteLobbyData)
					{
						Lobby.Leave();
					}
					Lobby = inviteLobbyData;
					inviteLobbyData.Join(delegate(LobbyEnter result, bool error)
					{
						if (result.Response == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
						{
							RefreshUI();
						}
						else
						{
							inviteLobbyData.Leave();
							Lobby = default(LobbyData);
						}
					});
				}
				evtGroupLobbyInvite?.Invoke(loadingLobbyData, groupInviteFrom);
			}
			else
			{
				if (!(arg0.lobby == loadingLobbyData) || !loadingLobbyData.IsSession)
				{
					return;
				}
				if (LobbyData.SessionLobby(out var lobby))
				{
					if (lobby != loadingLobbyData)
					{
						lobby.Leave();
						loadingLobbyData.Join(delegate(LobbyEnter result, bool error)
						{
							if (result.Response == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
							{
								RefreshUI();
								evtSessionLobbyInvite.Invoke(loadingLobbyData);
							}
							else
							{
								loadingLobbyData.Leave();
							}
						});
					}
				}
				else
				{
					loadingLobbyData.Join(delegate(LobbyEnter result, bool error)
					{
						if (result.Response == EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
						{
							RefreshUI();
							evtSessionLobbyInvite.Invoke(loadingLobbyData);
						}
						else
						{
							loadingLobbyData.Leave();
						}
					});
				}
				loadingLobbyData = default(LobbyData);
			}
		}

		public void InvitedUserToLobby(UserData user)
		{
			if (!HasLobby)
			{
				Matchmaking.Client.CreateLobby(ELobbyType.k_ELobbyTypeInvisible, slots.Length + 1, delegate(EResult result, LobbyData lobby, bool error)
				{
					if (result == EResult.k_EResultOK && !error)
					{
						lobby.IsGroup = true;
						Lobby = lobby;
						Lobby.InviteUserToLobby(user);
					}
				});
			}
			else
			{
				Lobby.InviteUserToLobby(user);
			}
		}

		private void HandleLobbyKickRequest(LobbyData arg0)
		{
			if (arg0 == Lobby)
			{
				Lobby.Leave();
				Lobby = default(LobbyData);
				RefreshUI();
			}
		}

		private void HandleLobbyJoinRequest(LobbyData lobby, UserData user)
		{
			inviteLobbyData = lobby;
			groupInviteFrom = user;
			Matchmaking.Client.RequestLobbyData(lobby);
		}

		private void HandleLobbyEnterSuccess(LobbyEnter_t arg0)
		{
			LobbyData lobby = arg0.m_ulSteamIDLobby;
			if (lobby.IsGroup)
			{
				Lobby = lobby;
				RefreshUI();
			}
		}

		private void HandleChatMessage(LobbyChatMsg message)
		{
			if (!(message.lobby == Lobby))
			{
				return;
			}
			if (message.Message.StartsWith("[SessionId]"))
			{
				if (ulong.TryParse(message.Message.Substring(11), out var result))
				{
					loadingLobbyData = result;
					Matchmaking.Client.RequestLobbyData(loadingLobbyData);
				}
				return;
			}
			if (chatMessages.Count == maxMessages)
			{
				Object.Destroy(chatMessages[0].GameObject);
				chatMessages.RemoveAt(0);
			}
			if (message.sender == UserData.Me)
			{
				GameObject obj = Object.Instantiate(myChatTemplate, messageRoot);
				obj.transform.SetAsLastSibling();
				IChatMessage component = obj.GetComponent<IChatMessage>();
				if (component != null)
				{
					component.Initialize(message);
					if (chatMessages.Count > 0 && chatMessages[chatMessages.Count - 1].User == component.User)
					{
						component.IsExpanded = false;
					}
					chatMessages.Add(component);
				}
			}
			else
			{
				GameObject obj2 = Object.Instantiate(theirChatTemplate, messageRoot);
				obj2.transform.SetAsLastSibling();
				IChatMessage component2 = obj2.GetComponent<IChatMessage>();
				if (component2 != null)
				{
					component2.Initialize(message);
					if (chatMessages[chatMessages.Count - 1].User == component2.User)
					{
						component2.IsExpanded = false;
					}
					chatMessages.Add(component2);
				}
			}
			StartCoroutine(ForceScrollDown());
		}

		private IEnumerator SelectInputField()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			inputField.Select();
		}

		private IEnumerator ForceScrollDown()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			scrollView.verticalNormalizedPosition = 0f;
		}

		public void RefreshUI()
		{
			if (!HasLobby)
			{
				if (updateRichPresenceGroupData)
				{
					UserData.SetRichPresence("steam_player_group", string.Empty);
					UserData.SetRichPresence("steam_player_group_size", string.Empty);
				}
				LobbyMemberSlot[] array = slots;
				foreach (LobbyMemberSlot obj in array)
				{
					obj.ClearUser();
					obj.Interactable = true;
				}
				userOwnerPip.SetActive(value: false);
				if (readyButton != null)
				{
					readyButton.gameObject.SetActive(value: false);
				}
				if (notReadyButton != null)
				{
					notReadyButton.gameObject.SetActive(value: false);
				}
				leaveButton.gameObject.SetActive(value: false);
				chatPanel.SetActive(value: false);
				return;
			}
			if (updateRichPresenceGroupData)
			{
				UserData.SetRichPresence("steam_player_group", Lobby.ToString());
				UserData.SetRichPresence("steam_player_group_size", (slots.Length + 1).ToString());
			}
			leaveButton.gameObject.SetActive(value: true);
			userOwnerPip.SetActive(IsPlayerOwner);
			if (readyButton != null)
			{
				readyButton.gameObject.SetActive(!IsPlayerReady);
			}
			if (notReadyButton != null)
			{
				notReadyButton.gameObject.SetActive(IsPlayerReady);
			}
			LobbyMemberData[] members = Lobby.Members;
			if (members.Length > 1)
			{
				chatPanel.SetActive(value: true);
			}
			else
			{
				chatPanel.SetActive(value: false);
			}
			members = members.Where((LobbyMemberData p) => p.user != UserData.Me).ToArray();
			for (int num = 0; num < slots.Length; num++)
			{
				LobbyMemberSlot lobbyMemberSlot = slots[num];
				lobbyMemberSlot.Interactable = Lobby.IsOwner;
				if (members.Length > num)
				{
					lobbyMemberSlot.SetUser(members[num]);
				}
				else
				{
					lobbyMemberSlot.ClearUser();
				}
			}
		}
	}
}
