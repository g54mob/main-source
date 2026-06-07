using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SINetworking
{
	public class SteamLayer : NetworkLayer
	{
		public static ELobbyType LobbyType = ELobbyType.k_ELobbyTypePublic;

		private CallResult<LobbyCreated_t> _lobbyCreatedResult;

		private CallResult<LobbyEnter_t> _lobbyEnterResult;

		private CallResult<LobbyMatchList_t> _lobbyMatchResult;

		private Callback<LobbyChatMsg_t> _lobbyChatResult;

		private Callback<SteamNetworkingMessagesSessionRequest_t> _sessionRequest;

		private Callback<LobbyDataUpdate_t> _lobbyDataUpdate;

		private Callback<GameLobbyJoinRequested_t> _lobbyRequest;

		private HashSet<CSteamID> _enumeratedLobbies = new HashSet<CSteamID>();

		private static byte[] _lobbyData = new byte[1024];

		private float _lobbyPingTimer;

		protected override void Start()
		{
			base.Start();
			_lobbyCreatedResult = new CallResult<LobbyCreated_t>(LobbyCreatedResult);
			_lobbyEnterResult = new CallResult<LobbyEnter_t>(LobbyEnterResult);
			_lobbyMatchResult = new CallResult<LobbyMatchList_t>(LobbyMatchResult);
			_lobbyChatResult = Callback<LobbyChatMsg_t>.Create(LobbyChatResult);
			_sessionRequest = Callback<SteamNetworkingMessagesSessionRequest_t>.Create(SessionRequestResult);
			_lobbyDataUpdate = Callback<LobbyDataUpdate_t>.Create(LobbyDataUpdate);
			_lobbyRequest = Callback<GameLobbyJoinRequested_t>.Create(LobbyRequest);
		}

		private void LobbyRequest(GameLobbyJoinRequested_t param)
		{
			if (!NetworkManager.IsConnected && !SceneManager.GetActiveScene().name.Equals("LoadingScene"))
			{
				string friendPersonaName = SteamFriends.GetFriendPersonaName(param.m_steamIDFriend);
				WindowManager.Instance.ShowMessageBox("SteamRequest".Loc(friendPersonaName), true, DialogWindow.DialogType.Question, delegate
				{
					JoinLobbyNow(param.m_steamIDLobby);
				});
			}
		}

		public void JoinLobbyNow(CSteamID lobbyID)
		{
			NetworkLobby networkLobby = new NetworkLobby(SteamMatchmaking.GetLobbyData(lobbyID, "Name"), lobbyID, lobbyID.ToString());
			UpdateAllMeta(networkLobby);
			Lobbies.Add(networkLobby);
			NetworkManager.Instance.HandleJoinLobby(networkLobby);
		}

		private void LobbyDataUpdate(LobbyDataUpdate_t data)
		{
			NetworkLobby networkLobby = Lobbies.FirstOrDefault((NetworkLobby x) => ((CSteamID)x.ConnectionObject).m_SteamID == data.m_ulSteamIDLobby);
			if (networkLobby == null)
			{
				return;
			}
			CSteamID steamID = SteamUser.GetSteamID();
			if (steamID.m_SteamID == data.m_ulSteamIDMember && SteamMatchmaking.GetLobbyOwner((CSteamID)networkLobby.ConnectionObject) == steamID)
			{
				NetworkManager.Instance.UpdateAllMeta();
				return;
			}
			UpdateAllMeta(networkLobby);
			if (networkLobby != CurrentLobby)
			{
				InvokeLobbyQuery();
			}
		}

		private void UpdateAllMeta(NetworkLobby l)
		{
			CSteamID steamIDLobby = (CSteamID)l.ConnectionObject;
			l.Name = SteamMatchmaking.GetLobbyData(steamIDLobby, "Name");
			l.UpdateLobbyMeta("AvailableSpots", SteamMatchmaking.GetLobbyData(steamIDLobby, "AvailableSpots"));
			l.UpdateLobbyMeta("Players", SteamMatchmaking.GetLobbyData(steamIDLobby, "Players"));
			l.UpdateLobbyMeta("CurrentYear", SteamMatchmaking.GetLobbyData(steamIDLobby, "CurrentYear"));
			l.UpdateLobbyMeta("SaveIDs", SteamMatchmaking.GetLobbyData(steamIDLobby, "SaveIDs"));
			l.UpdateLobbyMeta("ProtocolVersion", SteamMatchmaking.GetLobbyData(steamIDLobby, "ProtocolVersion"));
			l.UpdateLobbyMeta("DataMods", SteamMatchmaking.GetLobbyData(steamIDLobby, "DataMods"));
			l.UpdateLobbyMeta("Difficulty", SteamMatchmaking.GetLobbyData(steamIDLobby, "Difficulty"));
			l.UpdateLobbyMeta("DaysPerMonth", SteamMatchmaking.GetLobbyData(steamIDLobby, "DaysPerMonth"));
			l.UpdateLobbyMeta("ForcedIPO", SteamMatchmaking.GetLobbyData(steamIDLobby, "ForcedIPO"));
			l.UpdateLobbyMeta("RoundLimit", SteamMatchmaking.GetLobbyData(steamIDLobby, "RoundLimit"));
			l.UpdateLobbyMeta("RoundType", SteamMatchmaking.GetLobbyData(steamIDLobby, "RoundType"));
			l.UpdateLobbyMeta("Host", SteamMatchmaking.GetLobbyData(steamIDLobby, "Host"));
			l.UpdateLobbyMeta("PasswordProtected", SteamMatchmaking.GetLobbyData(steamIDLobby, "PasswordProtected"));
			l.UpdateLobbyMeta("CodeMods", SteamMatchmaking.GetLobbyData(steamIDLobby, "CodeMods"));
			l.UpdateLobbyMeta("FurnitureMods", SteamMatchmaking.GetLobbyData(steamIDLobby, "FurnitureMods"));
		}

		public override void SetLobbyMeta(NetworkLobby lobby, string var, string value)
		{
			SteamMatchmaking.SetLobbyData((CSteamID)lobby.ConnectionObject, var, value);
		}

		public override void CreateLobby(NetworkLobby lobby)
		{
			CurrentLobby = lobby;
			SteamAPICall_t hAPICall = SteamMatchmaking.CreateLobby(LobbyType, 4);
			_lobbyCreatedResult.Set(hAPICall);
		}

		public override void CleanPlayer(NetworkPlayer player)
		{
			object connectionObject;
			if (NetworkManager.IsHost && (connectionObject = player.ConnectionObject) is SteamNetworkingIdentity)
			{
				SteamNetworkingIdentity steamNetworkingIdentity = (SteamNetworkingIdentity)connectionObject;
				SendLobbyMessage(CurrentLobby, "DisconnectMe|" + steamNetworkingIdentity.GetSteamID64());
			}
		}

		public override void JoinLobby(NetworkLobby lobby)
		{
			NetworkManager.Instance.Host = false;
			SteamAPICall_t hAPICall = SteamMatchmaking.JoinLobby((CSteamID)lobby.ConnectionObject);
			_lobbyEnterResult.Set(hAPICall);
		}

		public override void LeaveLobby()
		{
			if (CurrentLobby != null && CurrentLobby.ConnectionObject != null)
			{
				SteamMatchmaking.LeaveLobby((CSteamID)CurrentLobby.ConnectionObject);
				InvokeLobbyJoined(null);
			}
		}

		public override void UpdateNewPlayer(NetworkPlayer player)
		{
			ulong result;
			if (player.ReconnectionData != null && ulong.TryParse(player.ReconnectionData, out result))
			{
				SteamFriends.SetPlayedWith(new CSteamID(result));
			}
		}

		public override bool SendData(NetworkPlayer player, byte[] data, bool now)
		{
			lock (this)
			{
				SteamNetworkingIdentity identityRemote = (SteamNetworkingIdentity)player.ConnectionObject;
				GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
				IntPtr pubData = gCHandle.AddrOfPinnedObject();
				int nSendFlags = 8;
				EResult eResult = SteamNetworkingMessages.SendMessageToUser(ref identityRemote, pubData, (uint)data.Length, nSendFlags, 0);
				gCHandle.Free();
				switch (eResult)
				{
				case EResult.k_EResultLimitExceeded:
				case EResult.k_EResultIgnored:
					return true;
				default:
					throw new Exception(string.Concat("Got ", eResult, " when trying to send steam network message"));
				case EResult.k_EResultOK:
					return false;
				}
			}
		}

		public override byte[] ReceiveData(out NetworkPlayer from)
		{
			lock (this)
			{
				from = null;
				IntPtr[] array = new IntPtr[1];
				if (SteamNetworkingMessages.ReceiveMessagesOnChannel(0, array, 1) > 0)
				{
					SteamNetworkingMessage_t steamNetworkingMessage_t = Marshal.PtrToStructure<SteamNetworkingMessage_t>(array[0]);
					from = NetworkManager.GetPlayer(steamNetworkingMessage_t.m_identityPeer);
					if (from == null)
					{
						Debug.Log("Got message from disconnected user: " + steamNetworkingMessage_t.m_identityPeer.GetSteamID());
						bool flag = true;
						if (steamNetworkingMessage_t.m_cbSize == 9)
						{
							try
							{
								byte[] array2 = new byte[steamNetworkingMessage_t.m_cbSize];
								Marshal.Copy(steamNetworkingMessage_t.m_pData, array2, 0, array2.Length);
								if (array2[4] == 6)
								{
									flag = false;
									Debug.Log("Player was sending disconnect message, ignored");
								}
							}
							catch (Exception ex)
							{
								Debug.Log("Failed understanding disconnected users message:\n" + ex.ToString());
							}
						}
						SteamNetworkingMessage_t.Release(array[0]);
						if (flag)
						{
							try
							{
								NetworkPlayer player = new NetworkPlayer(steamNetworkingMessage_t.m_identityPeer);
								byte[] sendData = NetworkMessaging.GetSendData(byte.MaxValue, NetworkMessaging.MessageType.DisconnectPlayer, new byte[1], NetworkMessaging.MessageTarget.Everyone, 0);
								SendData(player, sendData, true);
								Debug.Log("Sent disconnect message to disconnected user");
							}
							catch (Exception ex2)
							{
								Debug.Log("Failed sending disconnect message to disconnected user:\n" + ex2.ToString());
							}
						}
						return null;
					}
					byte[] array3 = new byte[steamNetworkingMessage_t.m_cbSize];
					Marshal.Copy(steamNetworkingMessage_t.m_pData, array3, 0, array3.Length);
					SteamNetworkingMessage_t.Release(array[0]);
					return array3;
				}
				return null;
			}
		}

		public override int GetMaxPacketSize()
		{
			return 8192;
		}

		public override string Diagnostics(NetworkPlayer player)
		{
			StringBuilder stringBuilder = new StringBuilder();
			object connectionObject;
			if ((connectionObject = player.ConnectionObject) is SteamNetworkingIdentity)
			{
				SteamNetworkingIdentity identityRemote = (SteamNetworkingIdentity)connectionObject;
				SteamNetConnectionInfo_t pConnectionInfo;
				SteamNetConnectionRealTimeStatus_t pQuickStatus;
				stringBuilder.AppendLine(SteamNetworkingMessages.GetSessionConnectionInfo(ref identityRemote, out pConnectionInfo, out pQuickStatus).ToString());
				stringBuilder.AppendLine(pConnectionInfo.m_szConnectionDescription);
				stringBuilder.AppendLine("Relay status: " + pConnectionInfo.m_idPOPRelay.m_SteamNetworkingPOPID);
				stringBuilder.AppendLine("Ping: " + pQuickStatus.m_nPing);
				if (CurrentLobby != null)
				{
					stringBuilder.AppendLine((SteamMatchmaking.GetLobbyOwner((CSteamID)CurrentLobby.ConnectionObject) == identityRemote.GetSteamID()) ? "Lobby owner" : "Not lobby owner");
				}
			}
			SteamRelayNetworkStatus_t pDetails;
			SteamNetworkingUtils.GetRelayNetworkStatus(out pDetails);
			stringBuilder.AppendLine("Relay status: " + pDetails.m_debugMsg);
			return stringBuilder.ToString().TrimEnd();
		}

		public override bool IsLobbyValid()
		{
			if (CurrentLobby != null && !NetworkManager.IsHost)
			{
				return SteamMatchmaking.GetNumLobbyMembers((CSteamID)CurrentLobby.ConnectionObject) > 1;
			}
			return true;
		}

		public override Texture2D GetPlayerAvatar(NetworkPlayer player, out bool completed)
		{
			ulong result = 0uL;
			completed = player.ReconnectionData != null && ulong.TryParse(player.ReconnectionData, out result);
			if (!completed)
			{
				return null;
			}
			int mediumFriendAvatar = SteamFriends.GetMediumFriendAvatar(new CSteamID(result));
			if (mediumFriendAvatar == 0)
			{
				return null;
			}
			uint pnWidth;
			uint pnHeight;
			SteamUtils.GetImageSize(mediumFriendAvatar, out pnWidth, out pnHeight);
			byte[] array = new byte[4 * pnWidth * pnHeight];
			if (SteamUtils.GetImageRGBA(mediumFriendAvatar, array, array.Length))
			{
				Texture2D texture2D = new Texture2D((int)pnWidth, (int)pnHeight, TextureFormat.RGBA32, false, true);
				texture2D.LoadRawTextureData(FlipImage(array, pnWidth, pnHeight));
				texture2D.Apply(false);
				return texture2D;
			}
			return null;
		}

		private static byte[] FlipImage(byte[] image, uint w, uint h)
		{
			byte[] array = new byte[image.Length];
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					for (int k = 0; k < 4; k++)
					{
						long num = (i + j * w) * 4;
						long num2 = (i + (h - j - 1) * w) * 4;
						array[num2] = image[num];
						array[num2 + 1] = image[num + 1];
						array[num2 + 2] = image[num + 2];
						array[num2 + 3] = image[num + 3];
					}
				}
			}
			return array;
		}

		public override NetworkPlayer HandleReconnection(NetworkPlayer player, byte id)
		{
			SteamNetworkingIdentity steamNetworkingIdentity = default(SteamNetworkingIdentity);
			steamNetworkingIdentity.SetSteamID64(ulong.Parse(player.ReconnectionData));
			player.ConnectionObject = steamNetworkingIdentity;
			return player;
		}

		public override void UpdatePing(NetworkPlayer player)
		{
			object connectionObject;
			if (!player.Self && (NetworkManager.IsHost || player.Host) && (connectionObject = player.ConnectionObject) is SteamNetworkingIdentity)
			{
				SteamNetworkingIdentity identityRemote = (SteamNetworkingIdentity)connectionObject;
				SteamNetConnectionInfo_t pConnectionInfo;
				SteamNetConnectionRealTimeStatus_t pQuickStatus;
				if (SteamNetworkingMessages.GetSessionConnectionInfo(ref identityRemote, out pConnectionInfo, out pQuickStatus) == ESteamNetworkingConnectionState.k_ESteamNetworkingConnectionState_Connected)
				{
					player.Ping = pQuickStatus.m_nPing;
				}
				else
				{
					player.Ping = null;
				}
			}
			else
			{
				player.Ping = null;
			}
		}

		public override string GetBanInfo(NetworkPlayer player)
		{
			return player.ReconnectionData;
		}

		public override string FilterMessage(string message, NetworkPlayer player)
		{
			if (player == null)
			{
				return message;
			}
			ulong result = 0uL;
			if (player.ReconnectionData == null || !ulong.TryParse(player.ReconnectionData, out result))
			{
				return message;
			}
			string pchOutFilteredText;
			if (SteamUtils.FilterText(ETextFilteringContext.k_ETextFilteringContextChat, new CSteamID(result), message, out pchOutFilteredText, (uint)(message.Length * 4 + 1)) < 0)
			{
				return message;
			}
			return pchOutFilteredText;
		}

		public override string FilterName(string name, NetworkPlayer player)
		{
			if (player == null)
			{
				return name;
			}
			ulong result = 0uL;
			if (player.ReconnectionData == null || !ulong.TryParse(player.ReconnectionData, out result))
			{
				return name;
			}
			string pchOutFilteredText;
			if (SteamUtils.FilterText(ETextFilteringContext.k_ETextFilteringContextName, new CSteamID(result), name, out pchOutFilteredText, (uint)(name.Length * 4 + 1)) < 0)
			{
				return name;
			}
			return pchOutFilteredText;
		}

		public override bool FilterName(string name)
		{
			string pchOutFilteredText;
			return SteamUtils.FilterText(ETextFilteringContext.k_ETextFilteringContextName, new CSteamID(0uL), name, out pchOutFilteredText, (uint)(name.Length * 4 + 1)) <= 0;
		}

		public string FilterText(string text, CSteamID player, ETextFilteringContext context)
		{
			string pchOutFilteredText;
			if (SteamUtils.FilterText(context, player, text, out pchOutFilteredText, (uint)(text.Length * 4 + 1)) < 0)
			{
				return text;
			}
			return pchOutFilteredText;
		}

		public static List<ValueTuple<string, CSteamID>> GetInvitables()
		{
			HashSet<ulong> hashSet = new HashSet<ulong>();
			if (NetworkLayer.Active.CurrentLobby != null)
			{
				CSteamID steamIDLobby = (CSteamID)NetworkLayer.Active.CurrentLobby.ConnectionObject;
				int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(steamIDLobby);
				for (int i = 0; i < numLobbyMembers; i++)
				{
					hashSet.Add(SteamMatchmaking.GetLobbyMemberByIndex(steamIDLobby, i).m_SteamID);
				}
			}
			List<ValueTuple<string, CSteamID>> list = new List<ValueTuple<string, CSteamID>>();
			int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
			for (int j = 0; j < friendCount; j++)
			{
				CSteamID friendByIndex = SteamFriends.GetFriendByIndex(j, EFriendFlags.k_EFriendFlagImmediate);
				if (!hashSet.Contains(friendByIndex.m_SteamID))
				{
					EPersonaState friendPersonaState = SteamFriends.GetFriendPersonaState(friendByIndex);
					if (friendPersonaState != EPersonaState.k_EPersonaStateOffline && friendPersonaState != EPersonaState.k_EPersonaStateBusy)
					{
						list.Add(new ValueTuple<string, CSteamID>(SteamFriends.GetFriendPersonaName(friendByIndex), friendByIndex));
					}
				}
			}
			return list;
		}

		public override void QueryLobbies()
		{
			base.QueryLobbies();
			_enumeratedLobbies.Clear();
			int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
			for (int i = 0; i < friendCount; i++)
			{
				FriendGameInfo_t pFriendGameInfo;
				if (SteamFriends.GetFriendGamePlayed(SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate), out pFriendGameInfo) && pFriendGameInfo.m_gameID.AppID().m_AppId == 362620 && pFriendGameInfo.m_steamIDLobby.IsValid() && _enumeratedLobbies.Add(pFriendGameInfo.m_steamIDLobby))
				{
					NetworkLobby item = new NetworkLobby(SteamMatchmaking.GetLobbyData(pFriendGameInfo.m_steamIDLobby, "Name"), pFriendGameInfo.m_steamIDLobby, pFriendGameInfo.m_steamIDLobby.ToString());
					Lobbies.Add(item);
					SteamMatchmaking.RequestLobbyData(pFriendGameInfo.m_steamIDLobby);
				}
			}
			if (MainMenuController.Instance != null)
			{
				NetworkStartWindow networkWindow = MainMenuController.Instance.NetworkWindow;
				if (networkWindow.Year.SelectedItem != null)
				{
					SteamMatchmaking.AddRequestLobbyListNumericalFilter("CurrentYear", (int)networkWindow.Year.SelectedItem, networkWindow.GetComp(networkWindow.YearAB));
				}
				if (networkWindow.DPM.SelectedItem != null)
				{
					SteamMatchmaking.AddRequestLobbyListNumericalFilter("DaysPerMonth", (int)networkWindow.DPM.SelectedItem, ELobbyComparison.k_ELobbyComparisonEqual);
				}
				if (networkWindow.Difficulty.SelectedItem != null)
				{
					SteamMatchmaking.AddRequestLobbyListNumericalFilter("Difficulty", networkWindow.Difficulty.Selected, networkWindow.GetComp(networkWindow.DifficultyAB));
				}
				if (networkWindow.ForcedIPO.CurrentState != ThreeStateCheck.State.Unknown)
				{
					SteamMatchmaking.AddRequestLobbyListStringFilter("ForcedIPO", "0", (networkWindow.ForcedIPO.CurrentState == ThreeStateCheck.State.On) ? ELobbyComparison.k_ELobbyComparisonNotEqual : ELobbyComparison.k_ELobbyComparisonEqual);
				}
				if (networkWindow.Modded.CurrentState != ThreeStateCheck.State.Unknown)
				{
					SteamMatchmaking.AddRequestLobbyListNumericalFilter("DataMods", (networkWindow.Modded.CurrentState == ThreeStateCheck.State.On) ? 1 : 0, ELobbyComparison.k_ELobbyComparisonEqual);
				}
				if (networkWindow.PasswordProtected.CurrentState != ThreeStateCheck.State.Unknown)
				{
					SteamMatchmaking.AddRequestLobbyListNumericalFilter("PasswordProtected", (networkWindow.PasswordProtected.CurrentState == ThreeStateCheck.State.On) ? 1 : 0, ELobbyComparison.k_ELobbyComparisonEqual);
				}
				if (networkWindow.CodeMods.CurrentState != ThreeStateCheck.State.Unknown)
				{
					SteamMatchmaking.AddRequestLobbyListNumericalFilter("CodeMods", (networkWindow.CodeMods.CurrentState == ThreeStateCheck.State.On) ? 1 : 0, ELobbyComparison.k_ELobbyComparisonEqual);
				}
				if (networkWindow.FurnitureMods.CurrentState != ThreeStateCheck.State.Unknown)
				{
					SteamMatchmaking.AddRequestLobbyListNumericalFilter("FurnitureMods", (networkWindow.FurnitureMods.CurrentState == ThreeStateCheck.State.On) ? 1 : 0, ELobbyComparison.k_ELobbyComparisonEqual);
				}
				SteamMatchmaking.AddRequestLobbyListDistanceFilter((ELobbyDistanceFilter)networkWindow.SteamLatency.Selected);
			}
			else
			{
				SteamMatchmaking.AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter.k_ELobbyDistanceFilterDefault);
			}
			_lobbyMatchResult.Set(SteamMatchmaking.RequestLobbyList());
		}

		public override string GetLocalConnectionData()
		{
			return SteamUser.GetSteamID().ToString();
		}

		public override bool TryReconnection(NetworkPlayer newHost)
		{
			NetworkPlayer networkPlayer = (NetworkManager.Instance.HostPlayer = newHost);
			networkPlayer.Host = true;
			SteamNetworkingIdentity steamNetworkingIdentity = default(SteamNetworkingIdentity);
			ulong num = ulong.Parse(newHost.ReconnectionData);
			steamNetworkingIdentity.SetSteamID64(num);
			networkPlayer.ConnectionObject = steamNetworkingIdentity;
			bool num2 = NetworkMessaging.ReconnectMessage(newHost);
			if (num2)
			{
				CSteamID steamIDLobby = (CSteamID)CurrentLobby.ConnectionObject;
				if (SteamMatchmaking.GetLobbyOwner(steamIDLobby) == SteamUser.GetSteamID())
				{
					SteamMatchmaking.SetLobbyOwner(steamIDLobby, new CSteamID(num));
				}
			}
			return num2;
		}

		public override void MakeHost()
		{
			foreach (NetworkPlayer player in NetworkManager.Instance.Players)
			{
				if (!player.Self)
				{
					SteamNetworkingIdentity steamNetworkingIdentity = default(SteamNetworkingIdentity);
					steamNetworkingIdentity.SetSteamID64(ulong.Parse(player.ReconnectionData));
					player.ConnectionObject = steamNetworkingIdentity;
				}
			}
		}

		public override ValueTuple<string, string> GetNameAndIdentifier()
		{
			return new ValueTuple<string, string>(SteamFriends.GetPersonaName(), SteamUser.GetSteamID().ToString());
		}

		private void LobbyCreatedResult(LobbyCreated_t result, bool failure)
		{
			if (!failure)
			{
				CSteamID cSteamID = new CSteamID(result.m_ulSteamIDLobby);
				SteamMatchmaking.SetLobbyData(cSteamID, "Name", CurrentLobby.Name);
				CurrentLobby.ConnectionObject = cSteamID;
				CurrentLobby.UniqueID = result.m_ulSteamIDLobby.ToString();
				InvokeLobbyCreated();
			}
			else
			{
				CurrentLobby = null;
				Debug.Log("Failed to create lobby");
			}
		}

		private void LobbyEnterResult(LobbyEnter_t result, bool failure)
		{
			if (!failure)
			{
				CurrentLobby = Lobbies.FirstOrDefault((NetworkLobby x) => result.m_ulSteamIDLobby == ((CSteamID)x.ConnectionObject).m_SteamID);
				if (CurrentLobby != null)
				{
					CSteamID steamIDLobby = (CSteamID)CurrentLobby.ConnectionObject;
					CSteamID lobbyOwner = SteamMatchmaking.GetLobbyOwner(steamIDLobby);
					if (!NetworkManager.Instance.Host && (lobbyOwner == SteamUser.GetSteamID() || SteamMatchmaking.GetNumLobbyMembers(steamIDLobby) <= 1))
					{
						LeaveLobby();
						WindowManager.Instance.ShowMessageBox("FailedJoiningGame".Loc(), true, DialogWindow.DialogType.Error);
					}
					else
					{
						SendLobbyMessage(CurrentLobby, "ConnectMe" + Versioning.SimpleNetworkVersionString);
					}
				}
				else
				{
					WindowManager.Instance.ShowMessageBox("FailedJoiningGame".Loc(), true, DialogWindow.DialogType.Error);
					InvokeLobbyJoined(null);
					Debug.Log("Failed to join missing lobby");
				}
			}
			else
			{
				WindowManager.Instance.ShowMessageBox("FailedJoiningGame".Loc(), true, DialogWindow.DialogType.Error);
				InvokeLobbyJoined(null);
				Debug.Log("Failed to join lobby");
			}
		}

		private void SendLobbyMessage(NetworkLobby lobby, string msg)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(msg);
			SteamMatchmaking.SendLobbyChatMsg((CSteamID)lobby.ConnectionObject, bytes, bytes.Length);
		}

		private void LobbyMatchResult(LobbyMatchList_t result, bool failure)
		{
			if (!failure)
			{
				for (int i = 0; i < result.m_nLobbiesMatching; i++)
				{
					CSteamID lobbyByIndex = SteamMatchmaking.GetLobbyByIndex(i);
					if (_enumeratedLobbies.Add(lobbyByIndex))
					{
						NetworkLobby networkLobby = new NetworkLobby(FilterText(SteamMatchmaking.GetLobbyData(lobbyByIndex, "Name"), SteamMatchmaking.GetLobbyOwner(lobbyByIndex), ETextFilteringContext.k_ETextFilteringContextName), lobbyByIndex, lobbyByIndex.ToString());
						UpdateAllMeta(networkLobby);
						Lobbies.Add(networkLobby);
					}
				}
				_enumeratedLobbies.Clear();
				InvokeLobbyQuery();
			}
			else
			{
				Debug.Log("Failed to request lobbies");
			}
		}

		private void LobbyChatResult(LobbyChatMsg_t result)
		{
			CSteamID user;
			EChatEntryType peChatEntryType;
			int lobbyChatEntry = SteamMatchmaking.GetLobbyChatEntry((CSteamID)result.m_ulSteamIDLobby, (int)result.m_iChatID, out user, _lobbyData, _lobbyData.Length, out peChatEntryType);
			if (user == SteamUser.GetSteamID())
			{
				return;
			}
			string text = Encoding.UTF8.GetString(_lobbyData, 0, lobbyChatEntry);
			if (text.StartsWith("ConnectMe") && NetworkManager.IsHost)
			{
				string value = text.Substring(9);
				NetworkPlayer networkPlayer = NetworkManager.Instance.Players.FirstOrDefault((NetworkPlayer x) =>
				{
					object connectionObject;
					return (connectionObject = x.ConnectionObject) is SteamNetworkingIdentity && ((SteamNetworkingIdentity)connectionObject).GetSteamID64() == user.m_SteamID;
				});
				if (networkPlayer != null)
				{
					NetworkMessaging.Disconnect(networkPlayer, false, false);
					if (networkPlayer.HandshakeComplete)
					{
						NetworkMessaging.SendData(networkPlayer.ID, NetworkMessaging.MessageType.DisconnectPlayer, new byte[1], false, NetworkMessaging.MessageTarget.EveryoneExcept, networkPlayer.ID);
					}
				}
				if (!Versioning.SimpleNetworkVersionString.Equals(value))
				{
					SendLobbyMessage(CurrentLobby, "DisconnectMe|" + user.m_SteamID);
					return;
				}
				if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.BanList.Contains(user.m_SteamID.ToString()))
				{
					SendLobbyMessage(CurrentLobby, "DisconnectMe|" + user.m_SteamID);
					return;
				}
				SteamNetworkingIdentity steamNetworkingIdentity = default(SteamNetworkingIdentity);
				steamNetworkingIdentity.SetSteamID64(result.m_ulSteamIDUser);
				NetworkPlayer networkPlayer2 = new NetworkPlayer(steamNetworkingIdentity);
				networkPlayer2.UniqueID = result.m_ulSteamIDUser.ToString();
				NetworkManager.Instance.Players.Add(networkPlayer2);
				string text2 = "Host|" + user.m_SteamID + "|" + SteamUser.GetSteamID().m_SteamID;
				if (!GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.SteamInvitedToGame.Contains(user.m_SteamID))
				{
					text2 += "|skipPass";
				}
				SendLobbyMessage(CurrentLobby, text2);
				NetworkManager.SetLobbyMetaData("Players", NetworkManager.Instance.Players.Count.ToString());
			}
			else if (text.StartsWith("DisconnectMe"))
			{
				string[] array = text.Split('|');
				if (array.Length > 1)
				{
					if (array[1].Equals(NetworkManager.Self.UniqueID))
					{
						Debug.Log("Got specifically kicked from lobby by owner");
						LeaveLobby();
					}
				}
				else
				{
					Debug.Log("Everyone was kicked by lobby owner");
					LeaveLobby();
				}
			}
			else
			{
				if (!text.StartsWith("Host|"))
				{
					return;
				}
				string[] array2 = text.Split('|');
				if (array2[1].Equals(NetworkManager.Self.UniqueID))
				{
					Debug.Log("Host accepted lobby connect request");
					CSteamID steamID = new CSteamID(ulong.Parse(array2[2]));
					SteamNetworkingIdentity steamNetworkingIdentity2 = default(SteamNetworkingIdentity);
					steamNetworkingIdentity2.SetSteamID(steamID);
					NetworkPlayer networkPlayer3 = (NetworkManager.Instance.HostPlayer = new NetworkPlayer(steamNetworkingIdentity2));
					networkPlayer3.Host = true;
					networkPlayer3.ID = 1;
					networkPlayer3.UniqueID = steamID.ToString();
					NetworkManager.Instance.Players.Add(networkPlayer3);
					if (array2.Length > 3 && array2[3].Equals("skipPass"))
					{
						NetworkManager.CanSkipPassword = true;
					}
					InvokeLobbyJoined(CurrentLobby);
				}
			}
		}

		private void SessionRequestResult(SteamNetworkingMessagesSessionRequest_t result)
		{
			if (CurrentLobby != null)
			{
				CSteamID steamIDLobby = (CSteamID)CurrentLobby.ConnectionObject;
				int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(steamIDLobby);
				bool flag = false;
				for (int i = 0; i < numLobbyMembers; i++)
				{
					if (SteamMatchmaking.GetLobbyMemberByIndex(steamIDLobby, i) == result.m_identityRemote.GetSteamID())
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					SteamNetworkingMessages.AcceptSessionWithUser(ref result.m_identityRemote);
				}
				else
				{
					Debug.Log("User tried to start session but was not in same lobby: " + result.m_identityRemote.GetSteamID());
				}
			}
			else
			{
				Debug.Log("User tried to start session but we are not in any lobby: " + result.m_identityRemote.GetSteamID());
			}
		}

		private void Update()
		{
			if (NetworkManager.IsHost)
			{
				_lobbyPingTimer += Time.deltaTime;
				if (_lobbyPingTimer > 300f)
				{
					_lobbyPingTimer = 0f;
					SendLobbyMessage(CurrentLobby, "Just a quick ping");
				}
			}
		}

		public override object TransformConnection(object c)
		{
			object obj;
			if ((obj = c) is SteamNetworkingIdentity)
			{
				return ((SteamNetworkingIdentity)obj).GetSteamID();
			}
			return c;
		}
	}
}
