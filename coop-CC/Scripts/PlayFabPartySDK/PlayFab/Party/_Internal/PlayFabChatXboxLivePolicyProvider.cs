using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using PartyCSharpSDK;
using PartyXBLCSharpSDK;
using PlayFab.ClientModels;
using Unity.XGamingRuntime;

namespace PlayFab.Party._Internal
{
	internal class PlayFabChatXboxLivePolicyProvider : IPlayFabChatPlatformPolicyProvider
	{
		private class PlayerComparator : IEqualityComparer<PlayFabPlayer>
		{
			public bool Equals(PlayFabPlayer a, PlayFabPlayer b)
			{
				if (!(a.EntityKey.Id == b.EntityKey.Id))
				{
					return false;
				}
				return true;
			}

			public int GetHashCode(PlayFabPlayer player)
			{
				return player.GetHashCode();
			}
		}

		private class TrackableGetXTokenCompletedWrapper
		{
			public uint correlationId;

			public string method;

			public string url;

			public byte[] body;

			public PARTY_XBL_HTTP_HEADER[] headers;

			private static bool _pendingResolveIssueWithUICallback;

			public void CompleteGetXToken(int hresult, XUserGetTokenAndSignatureUtf16Data tokenData)
			{
				PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:CompleteGetXToken(), hr: " + hresult);
				if (hresult >= 0)
				{
					Get().Succeeded(XBLSDK.PartyXblCompleteGetTokenAndSignatureRequest(Get()._xblPartyHandle, correlationId, succeeded: true, tokenData.Token, tokenData.Signature));
				}
				else if (hresult == -1994108670)
				{
					Unity.XGamingRuntime.SDK.XUserResolveIssueWithUiUtf16Async(Get()._xblLocalUserHandle, url, _ResolveUserIssueWithUICompleted);
				}
				else
				{
					PlayFabMultiplayerManager._LogError("Could not get an Xbox Live token.");
				}
			}

			private void _ResolveUserIssueWithUICompleted(int hresult)
			{
				PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:_ResolveUserIssueWithUICompleted(), hr: " + hresult);
				if (!_pendingResolveIssueWithUICallback)
				{
					_pendingResolveIssueWithUICallback = true;
					if (Get().HrSucceeded(hresult))
					{
						Get().SignIn();
					}
				}
			}
		}

		private class QueuedCreateRemoteXboxLiveChatUserOp
		{
			public PlayFabPlayer otherPlayer;

			public ulong xuid;
		}

		private struct QueuedUpdateChatPermissionsOp
		{
			public bool queued;

			public PARTY_XBL_CHAT_USER_HANDLE localXblChatUser;

			public PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser;
		}

		private enum XboxPolicyMessageType : sbyte
		{
			Unset = 0,
			XuidExchangeRequest = 1,
			XuidExchangeResponse = 2
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		private struct XboxPolicyXuidExchangeResponseMessage
		{
			private XboxPolicyMessageType type;

			private ushort xuid;
		}

		private PARTY_XBL_HANDLE _xblPartyHandle;

		private PlayFabMultiplayerManager _multiplayerManager;

		private PARTY_XBL_CHAT_USER_HANDLE _xblLocalChatUserHandle;

		private static PlayFabChatXboxLivePolicyProvider _xblPolicyProvider;

		private QueuedUpdateChatPermissionsOp _queuedUpdateChatPermissionsOp;

		private XUserHandle _xblLocalUserHandle;

		private Dictionary<PlayFabPlayer, PARTY_XBL_CHAT_PERMISSION_INFO> _playerChatPermissions;

		private List<QueuedCreateRemoteXboxLiveChatUserOp> _queuedCreateRemoteXboxLiveChatUserOps;

		private List<PARTY_XBL_STATE_CHANGE> _xblStateChanges;

		private byte[] _internalXuidExchangeMessageBuffer;

		private byte[] _XUID_EXCHANGE_REQUEST_AS_BYTES;

		private byte[] _XUID_EXCHANGE_RESPONSE_AS_BYTES;

		private const PARTY_CHAT_PERMISSION_OPTIONS _CHAT_PERMISSIONS_ALL = (PARTY_CHAT_PERMISSION_OPTIONS)31u;

		private const uint _INTERNAL_XUID_EXCHANGE_MESSAGE_BUFFER_SIZE = 128u;

		private const string _XUID_EXCHANGE_REQUEST_MESSAGE_PREFIX = "PFP-XBL-XUID-REQUEST";

		private const string _XUID_EXCHANGE_RESPONSE_MESSAGE_PREFIX = "PFP-XBL-XUID-RESPONSE";

		private const int _E_GAMEUSER_RESOLVE_USER_ISSUE_REQUIRED = -1994108670;

		private const string _ErrorMessageGamingRuntimeNotInitialized = "Gaming Runtime not initialized. You need to call SDK.XGameRuntimeInitialize()";

		private const string _ErrorMessageCouldNotGetXuid = "Could not get a XUID.";

		private const string _ErrorMessageCouldNotGetXboxLiveToken = "Could not get an Xbox Live token.";

		private const string _ErrorMessageXboxLiveSignInFailed = "Xbox Live sign in failed.";

		public static PlayFabChatXboxLivePolicyProvider Get()
		{
			if (_xblPolicyProvider == null)
			{
				_xblPolicyProvider = new PlayFabChatXboxLivePolicyProvider();
			}
			return _xblPolicyProvider;
		}

		public PlayFabChatXboxLivePolicyProvider()
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:PlayFabChatXboxLivePolicyProvider()");
			_multiplayerManager = PlayFabMultiplayerManager.Get();
			string titleId = PlayFabSettings.staticSettings.TitleId;
			_playerChatPermissions = new Dictionary<PlayFabPlayer, PARTY_XBL_CHAT_PERMISSION_INFO>(new PlayerComparator());
			_queuedCreateRemoteXboxLiveChatUserOps = new List<QueuedCreateRemoteXboxLiveChatUserOp>();
			_xblStateChanges = new List<PARTY_XBL_STATE_CHANGE>();
			_internalXuidExchangeMessageBuffer = new byte[128];
			Succeeded(XBLSDK.PartyXblInitialize(titleId, out _xblPartyHandle));
			_XUID_EXCHANGE_REQUEST_AS_BYTES = Encoding.ASCII.GetBytes("PFP-XBL-XUID-REQUEST");
			_XUID_EXCHANGE_RESPONSE_AS_BYTES = Encoding.ASCII.GetBytes("PFP-XBL-XUID-RESPONSE");
		}

		public bool CleanUp()
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:CleanUp()");
			bool result = Succeeded(XBLSDK.PartyXblCleanup(_xblPartyHandle));
			_xblPolicyProvider = null;
			_playerChatPermissions = null;
			_xblStateChanges = null;
			_queuedCreateRemoteXboxLiveChatUserOps = null;
			_internalXuidExchangeMessageBuffer = null;
			_XUID_EXCHANGE_REQUEST_AS_BYTES = null;
			_XUID_EXCHANGE_RESPONSE_AS_BYTES = null;
			_xblLocalChatUserHandle = null;
			_xblPartyHandle = null;
			return result;
		}

		public void SignIn()
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:SignIn()");
			try
			{
				Unity.XGamingRuntime.SDK.XUserAddAsync(XUserAddOptions.AddDefaultUserSilently, SignInSilentlyComplete);
			}
			catch (NullReferenceException)
			{
				PlayFabMultiplayerManager._LogError("Gaming Runtime not initialized. You need to call SDK.XGameRuntimeInitialize()");
			}
			catch (Exception ex2)
			{
				PlayFabMultiplayerManager._LogError(ex2.Message);
			}
		}

		public void CreateOrUpdatePlatformUser(PlayFabPlayer player, bool isLocal)
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:CreateOrUpdatePlatformUser()");
			if (isLocal)
			{
				if (HrSucceeded(Unity.XGamingRuntime.SDK.XUserGetId(_xblLocalUserHandle, out var userId)))
				{
					player._platformSpecificUserId = userId.ToString();
				}
			}
			else
			{
				TryCreateRemoteXboxLiveChatUser(player);
			}
		}

		public PARTY_CHAT_PERMISSION_OPTIONS GetChatPermissions(PlayFabPlayer targetPlayer)
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:GetChatPermissions()");
			PARTY_CHAT_PERMISSION_OPTIONS result = (PARTY_CHAT_PERMISSION_OPTIONS)31u;
			if (_playerChatPermissions.ContainsKey(targetPlayer))
			{
				result = _playerChatPermissions[targetPlayer].ChatPermissionMask;
			}
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:get chat permissions for EntityId: " + targetPlayer.EntityKey.Id + ", chat permissions: " + result);
			return result;
		}

		public void ProcessEndpointMessage(PlayFabPlayer fromPlayer, IntPtr messageBuffer, uint messageSize, out bool isInternalMessage)
		{
			isInternalMessage = false;
			if (messageSize == 0 || messageSize >= 128)
			{
				return;
			}
			Marshal.Copy(messageBuffer, _internalXuidExchangeMessageBuffer, 0, (int)messageSize);
			if (!_multiplayerManager._StartsWithSequence(_internalXuidExchangeMessageBuffer, _XUID_EXCHANGE_REQUEST_AS_BYTES))
			{
				return;
			}
			isInternalMessage = true;
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider: received remote XUID.");
			uint num = (uint)((int)messageSize - _XUID_EXCHANGE_REQUEST_AS_BYTES.Length - 1);
			if (num < 0)
			{
				return;
			}
			byte[] array = new byte[num];
			Array.Copy(_internalXuidExchangeMessageBuffer, _XUID_EXCHANGE_REQUEST_AS_BYTES.Length + 1, array, 0, array.Length);
			fromPlayer._platformSpecificUserId = Encoding.ASCII.GetString(array);
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider: sent XUID exchange response message.");
			for (int i = 0; i < _queuedCreateRemoteXboxLiveChatUserOps.Count; i++)
			{
				if (_queuedCreateRemoteXboxLiveChatUserOps[i].otherPlayer.EntityKey.Id == fromPlayer.EntityKey.Id)
				{
					ulong xuid = Convert.ToUInt64(fromPlayer._platformSpecificUserId);
					_queuedCreateRemoteXboxLiveChatUserOps[i].xuid = xuid;
					break;
				}
			}
		}

		public PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS GetPlatformUserChatTranscriptionPreferences()
		{
			PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS result = PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS.PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS_NONE;
			Succeeded(XBLSDK.PartyXblLocalChatUserGetAccessibilitySettings(_xblLocalChatUserHandle, out var settings));
			if (settings != null && settings.SpeechToTextEnabled != 0)
			{
				result = (PARTY_VOICE_CHAT_TRANSCRIPTION_OPTIONS)3u;
			}
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:GetPlatformUserChatTranscriptionPreferences(), transcription options: " + result);
			return result;
		}

		public bool IsTextToSpeechEnabled()
		{
			bool result = false;
			Succeeded(XBLSDK.PartyXblLocalChatUserGetAccessibilitySettings(_xblLocalChatUserHandle, out var settings));
			if (settings != null && settings.TextToSpeechEnabled != 0)
			{
				result = true;
			}
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:IsTextToSpeechEnabled(), value: " + result);
			return result;
		}

		public void SendPlatformSpecificUserId(List<PlayFabPlayer> targetPlayers)
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:SendPlatformSpecificUserId()");
			if (HrSucceeded(Unity.XGamingRuntime.SDK.XUserGetId(_xblLocalUserHandle, out var userId)))
			{
				string s = "PFP-XBL-XUID-REQUEST:" + userId;
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				_multiplayerManager._SendDataMessage(bytes, targetPlayers, DeliveryOption.Guaranteed);
			}
			else
			{
				PlayFabMultiplayerManager._LogError("Could not get a XUID.");
			}
		}

		public void ProcessQueuedOperations()
		{
			if (_queuedUpdateChatPermissionsOp.queued && IsReadyToSetChatPermissions(_queuedUpdateChatPermissionsOp.localXblChatUser, _queuedUpdateChatPermissionsOp.targetXblChatUser))
			{
				UpdateChatPermissionInfoComplete(_queuedUpdateChatPermissionsOp.localXblChatUser, _queuedUpdateChatPermissionsOp.targetXblChatUser);
			}
			for (int num = _queuedCreateRemoteXboxLiveChatUserOps.Count - 1; num >= 0; num--)
			{
				if (_queuedCreateRemoteXboxLiveChatUserOps[num].xuid != 0L)
				{
					TryCreateRemoteXboxLiveChatUser(_queuedCreateRemoteXboxLiveChatUserOps[num].otherPlayer);
				}
			}
		}

		public void ProcessStateChanges()
		{
			if (!Succeeded(XBLSDK.PartyXblStartProcessingStateChanges(_xblPartyHandle, out _xblStateChanges)))
			{
				return;
			}
			foreach (PARTY_XBL_STATE_CHANGE xblStateChange in _xblStateChanges)
			{
				PlayFabMultiplayerManager._LogInfo("XBL State change: " + xblStateChange.StateChangeType);
				switch (xblStateChange.StateChangeType)
				{
				case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_TOKEN_AND_SIGNATURE_REQUESTED:
				{
					PARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE = (PARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE)xblStateChange;
					TrackableGetXTokenCompletedWrapper trackableGetXTokenCompletedWrapper = new TrackableGetXTokenCompletedWrapper();
					trackableGetXTokenCompletedWrapper.correlationId = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.correlationId;
					trackableGetXTokenCompletedWrapper.url = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.url;
					trackableGetXTokenCompletedWrapper.method = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.method;
					trackableGetXTokenCompletedWrapper.headers = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.headers;
					trackableGetXTokenCompletedWrapper.body = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.body;
					XUserGetTokenAndSignatureOptions xUserGetTokenAndSignatureOptions = XUserGetTokenAndSignatureOptions.None;
					if (pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.allUsers)
					{
						xUserGetTokenAndSignatureOptions |= XUserGetTokenAndSignatureOptions.AllUsers;
					}
					if (pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.forceRefresh)
					{
						xUserGetTokenAndSignatureOptions |= XUserGetTokenAndSignatureOptions.ForceRefresh;
					}
					XUserGetTokenAndSignatureUtf16HttpHeader[] array = new XUserGetTokenAndSignatureUtf16HttpHeader[pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.headers.Length];
					for (uint num = 0u; num < pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.headers.Length; num++)
					{
						string name = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.headers[num].name;
						string value = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.headers[num].value;
						array[num] = new XUserGetTokenAndSignatureUtf16HttpHeader();
						array[num].Name = name;
						array[num].Value = value;
					}
					XUserGetTokenAndSignatureUtf16HttpHeader[] headers = array;
					if (pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.headers.Length == 0)
					{
						headers = null;
					}
					byte[] bodyBuffer = pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.body;
					if (pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.body.Length == 0)
					{
						bodyBuffer = null;
					}
					Unity.XGamingRuntime.SDK.XUserGetTokenAndSignatureUtf16Async(_xblLocalUserHandle, xUserGetTokenAndSignatureOptions, pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.method, pARTY_XBL_TOKEN_AND_SIGNATURE_REQUESTED_STATE_CHANGE.url, headers, bodyBuffer, trackableGetXTokenCompletedWrapper.CompleteGetXToken);
					break;
				}
				case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_CREATE_LOCAL_CHAT_USER_COMPLETED:
				{
					PARTY_XBL_CREATE_LOCAL_CHAT_USER_COMPLETED_STATE_CHANGE pARTY_XBL_CREATE_LOCAL_CHAT_USER_COMPLETED_STATE_CHANGE = (PARTY_XBL_CREATE_LOCAL_CHAT_USER_COMPLETED_STATE_CHANGE)xblStateChange;
					_multiplayerManager.InternalCheckStateChangeSucceededOrLogErrorIfFailed(pARTY_XBL_CREATE_LOCAL_CHAT_USER_COMPLETED_STATE_CHANGE.result, pARTY_XBL_CREATE_LOCAL_CHAT_USER_COMPLETED_STATE_CHANGE.errorDetail);
					break;
				}
				case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_LOGIN_TO_PLAYFAB_COMPLETED:
				{
					PARTY_XBL_LOGIN_TO_PLAYFAB_COMPLETED_STATE_CHANGE pARTY_XBL_LOGIN_TO_PLAYFAB_COMPLETED_STATE_CHANGE = (PARTY_XBL_LOGIN_TO_PLAYFAB_COMPLETED_STATE_CHANGE)xblStateChange;
					if (_multiplayerManager.InternalCheckStateChangeSucceededOrLogErrorIfFailed(pARTY_XBL_LOGIN_TO_PLAYFAB_COMPLETED_STATE_CHANGE.result, pARTY_XBL_LOGIN_TO_PLAYFAB_COMPLETED_STATE_CHANGE.errorDetail))
					{
						OnPlayFabLoginSuccess(pARTY_XBL_LOGIN_TO_PLAYFAB_COMPLETED_STATE_CHANGE);
						break;
					}
					_multiplayerManager._SetPlayFabMultiplayerManagerInternalState(PlayFabMultiplayerManager._InternalPlayFabMultiplayerManagerState.Initialized);
					_multiplayerManager.DropCurrentQueuedOps();
					break;
				}
				case PARTY_XBL_STATE_CHANGE_TYPE.PARTY_XBL_STATE_CHANGE_TYPE_REQUIRED_CHAT_PERMISSION_INFO_CHANGED:
				{
					PARTY_XBL_REQUIRED_CHAT_PERMISSION_INFO_CHANGED_STATE_CHANGE obj = (PARTY_XBL_REQUIRED_CHAT_PERMISSION_INFO_CHANGED_STATE_CHANGE)xblStateChange;
					PARTY_XBL_CHAT_USER_HANDLE localChatUser = obj.localChatUser;
					PARTY_XBL_CHAT_USER_HANDLE targetChatUser = obj.targetChatUser;
					UpdateChatPermissionInfoStart(localChatUser, targetChatUser);
					break;
				}
				}
			}
			Succeeded(XBLSDK.PartyXblFinishProcessingStateChanges(_xblPartyHandle, _xblStateChanges));
		}

		private void UpdateChatPermissionInfoStart(PARTY_XBL_CHAT_USER_HANDLE localXblChatUser, PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser)
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:UpdateChatPermissionInfoStart()");
			if (IsReadyToSetChatPermissions(localXblChatUser, targetXblChatUser))
			{
				UpdateChatPermissionInfoComplete(localXblChatUser, targetXblChatUser);
				return;
			}
			_queuedUpdateChatPermissionsOp = new QueuedUpdateChatPermissionsOp
			{
				queued = true,
				localXblChatUser = localXblChatUser,
				targetXblChatUser = targetXblChatUser
			};
		}

		private bool IsReadyToSetChatPermissions(PARTY_XBL_CHAT_USER_HANDLE localXblChatUser, PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser)
		{
			if (!Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(localXblChatUser, out var xboxUserId)))
			{
				return false;
			}
			if (!Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(targetXblChatUser, out var xboxUserId2)))
			{
				return false;
			}
			if (GetPlayerByXuid(xboxUserId) != null)
			{
				return GetPlayerByXuid(xboxUserId2) != null;
			}
			return false;
		}

		private void UpdateChatPermissionInfoComplete(PARTY_XBL_CHAT_USER_HANDLE localXblChatUser, PARTY_XBL_CHAT_USER_HANDLE targetXblChatUser)
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:UpdateChatPermissionInfoComplete()");
			if (_queuedUpdateChatPermissionsOp.queued)
			{
				_queuedUpdateChatPermissionsOp = default(QueuedUpdateChatPermissionsOp);
			}
			if (!Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(localXblChatUser, out var xboxUserId)) || !Succeeded(XBLSDK.PartyXblChatUserGetXboxUserId(targetXblChatUser, out var xboxUserId2)))
			{
				return;
			}
			PlayFabPlayer playerByXuid = GetPlayerByXuid(xboxUserId);
			PlayFabPlayer playerByXuid2 = GetPlayerByXuid(xboxUserId2);
			if (playerByXuid == null || playerByXuid2 == null)
			{
				return;
			}
			Succeeded(XBLSDK.PartyXblLocalChatUserGetRequiredChatPermissionInfo(localXblChatUser, targetXblChatUser, out var chatPermissionInfo));
			Succeeded(PartyCSharpSDK.SDK.PartyChatControlSetPermissions(playerByXuid._chatControlHandle, playerByXuid2._chatControlHandle, chatPermissionInfo.ChatPermissionMask));
			bool flag = chatPermissionInfo.ChatPermissionMask != (PARTY_CHAT_PERMISSION_OPTIONS)31u;
			foreach (PlayFabPlayer remotePlayer in _multiplayerManager.RemotePlayers)
			{
				if (remotePlayer.EntityKey.Id == playerByXuid2.EntityKey.Id)
				{
					remotePlayer._mutedByPlatform = flag;
					remotePlayer.IsMuted = flag;
					break;
				}
			}
			if (!_playerChatPermissions.ContainsKey(playerByXuid2))
			{
				_playerChatPermissions.Add(playerByXuid2, chatPermissionInfo);
			}
		}

		private void OnPlayFabLoginSuccess(PARTY_XBL_LOGIN_TO_PLAYFAB_COMPLETED_STATE_CHANGE loginResult)
		{
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:OnPlayFabLoginSuccess(), EntityId: " + loginResult.entityId);
			EntityKey entityKey = new EntityKey
			{
				Id = loginResult.entityId,
				Type = "title_player_account"
			};
			_multiplayerManager._CreateLocalUser(entityKey, loginResult.titlePlayerEntityToken);
		}

		private void SignInSilentlyComplete(int hresult, XUserHandle userHandle)
		{
			if (HrSucceeded(hresult))
			{
				_xblLocalUserHandle = userHandle;
			}
			else
			{
				PlayFabMultiplayerManager._LogError("Xbox Live sign in failed.");
			}
			Unity.XGamingRuntime.SDK.XUserGetId(_xblLocalUserHandle, out var userId);
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:SignInSilentlyComplete(), XUID: " + userId);
			if (HrSucceeded(hresult))
			{
				if (_xblLocalChatUserHandle == null)
				{
					Succeeded(XBLSDK.PartyXblCreateLocalChatUser(_xblPartyHandle, userId, null, out _xblLocalChatUserHandle));
				}
				Succeeded(XBLSDK.PartyXblLoginToPlayFab(_xblLocalChatUserHandle, null));
			}
			else
			{
				PlayFabMultiplayerManager._LogError("Could not get a XUID.");
			}
		}

		private void TryCreateRemoteXboxLiveChatUser(PlayFabPlayer otherPlayer)
		{
			if (string.IsNullOrEmpty(otherPlayer._platformSpecificUserId))
			{
				_queuedCreateRemoteXboxLiveChatUserOps.Add(new QueuedCreateRemoteXboxLiveChatUserOp
				{
					otherPlayer = otherPlayer
				});
				return;
			}
			ulong num = Convert.ToUInt64(otherPlayer._platformSpecificUserId);
			PlayFabMultiplayerManager._LogInfo("PlayFabChatXboxLivePolicyProvider:TryCreateRemoteXboxLiveChatUser(), XUID: " + num);
			if (!Succeeded(XBLSDK.PartyXblCreateRemoteChatUser(_xblPartyHandle, num, out otherPlayer._xblChatUserHandle)))
			{
				return;
			}
			for (int i = 0; i < _queuedCreateRemoteXboxLiveChatUserOps.Count; i++)
			{
				if (num == _queuedCreateRemoteXboxLiveChatUserOps[i].xuid)
				{
					_queuedCreateRemoteXboxLiveChatUserOps.RemoveAt(i);
					break;
				}
			}
		}

		private PlayFabPlayer GetPlayerByXuid(ulong xuid)
		{
			if (xuid == 0L)
			{
				return null;
			}
			if (_multiplayerManager.LocalPlayer != null && !string.IsNullOrEmpty(_multiplayerManager.LocalPlayer._platformSpecificUserId) && Convert.ToUInt64(_multiplayerManager.LocalPlayer._platformSpecificUserId) == xuid)
			{
				return _multiplayerManager.LocalPlayer;
			}
			PlayFabPlayer result = null;
			foreach (PlayFabPlayer remotePlayer in _multiplayerManager.RemotePlayers)
			{
				if (!string.IsNullOrEmpty(remotePlayer._platformSpecificUserId) && Convert.ToUInt64(remotePlayer._platformSpecificUserId) == xuid)
				{
					result = remotePlayer;
					break;
				}
			}
			return result;
		}

		private bool Succeeded(uint errorCode)
		{
			return _multiplayerManager.PartySucceeded(errorCode);
		}

		private bool HrSucceeded(int hresult)
		{
			return hresult >= 0;
		}
	}
}
