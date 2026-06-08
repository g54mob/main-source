using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using Kitchen.Transports;
using Kitchen.Utility;
using Photon.Realtime;
using Platforms;
using Sirenix.Utilities;
using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public class PhotonNetworkService : BaseService<PhotonNetworkTarget, PhotonLobby>, IOnEventCallback, IMatchmakingCallbacks, IErrorInfoCallback
	{
		public static PhotonNetworkService Instance;

		private const byte EventCodeStandardMessage = 1;

		private LoadBalancingClient Client = new LoadBalancingClient();

		private int[] _MessageTarget = new int[1];

		private bool HasCallbacksRegistered;

		private const int TimeoutMs = 5000;

		public override string Name => "Photon";

		public override bool CanAcceptJoinCode => base.State == PlatformState.Ready;

		public override bool IsCrossplay => true;

		public static bool ShouldEnablePhoton
		{
			get
			{
				if (PlatformSettings.IsPhotonCrossplayOnly)
				{
					return NetworkServices.HasCrossplayEnabled;
				}
				return true;
			}
		}

		public override PhotonNetworkTarget Me => new PhotonNetworkTarget(Client.LocalPlayer, is_host_mode: true);

		public override async Task<Result<INetworkTarget>> GetTargetFromJoinCode(JoinCode invite)
		{
			try
			{
				return Result.Succeed((INetworkTarget)new PhotonNetworkTarget(invite.Actual));
			}
			catch (Exception arg)
			{
				Debug.LogWarning($"Attempted to parse Photon join code {invite} but failed with exception {arg}");
			}
			return default(Result<INetworkTarget>);
		}

		public override INetworkTransport GetNewTransport(JoinCode join_code)
		{
			return new PhotonLobbyTransport(join_code);
		}

		public override async Task<Result<INetworkTarget>> CanHandleInvite(NetworkInviteData data)
		{
			string inviteOfPrefix = PlatformHelpers.GetInviteOfPrefix(data.InviteString, "PHOTON_CODE:");
			if (string.IsNullOrEmpty(inviteOfPrefix))
			{
				return default(Result<INetworkTarget>);
			}
			return await GetTargetFromJoinCode(JoinCode.CreateFromRemote(inviteOfPrefix));
		}

		protected override void PerformUpdate()
		{
			if (!HasCallbacksRegistered)
			{
				Client.AddCallbackTarget(this);
				HasCallbacksRegistered = true;
			}
			if (Client.NickName.IsNullOrWhitespace())
			{
				Client.NickName = Platform.Current.GetDisplayName(Platform.Current.PrimaryUser);
			}
			Client.Service();
			if (base.State == PlatformState.Ready && !Client.IsConnected)
			{
				DisconnectCause disconnectedCause = Client.DisconnectedCause;
				if ((uint)(disconnectedCause - 11) <= 2u)
				{
					Platform.Current.GetPhotonAuth(force_skip_cache: true);
				}
				base.Events.Report(NetworkEvent.LostConnection, Client.DisconnectedCause.ToString());
				base.State = PlatformState.Failed;
			}
		}

		private bool PerformSend()
		{
			return Client.LoadBalancingPeer.SendOutgoingCommands();
		}

		private bool PerformReceive()
		{
			return Client.LoadBalancingPeer.DispatchIncomingCommands();
		}

		public void Receive()
		{
			while (PerformReceive())
			{
			}
		}

		public void Send()
		{
			while (PerformSend())
			{
			}
		}

		protected async Task<bool> SearchRegions(CancellationToken token, string join_code)
		{
			await EnsureRegion(token, Client.CloudRegion);
			TaskCompletionSource<RegionHandler> handler = new TaskCompletionSource<RegionHandler>();
			bool success = true;
			if (Client.RegionHandler == null)
			{
				base.Events.Report(NetworkEvent.PhotonFailedToSearch, $"Null region handler {Client.State}");
				return false;
			}
			if (!Client.RegionHandler.PingMinimumOfRegions(handler.SetResult, null))
			{
				bool flag = await UntilTask.WaitForTrue(() => !Client.RegionHandler.IsPinging, TimeSpan.FromSeconds(20.0));
				if (!flag || !Client.RegionHandler.PingMinimumOfRegions(handler.SetResult, null))
				{
					base.Events.Report(NetworkEvent.PhotonFailedToSearch, $"{flag}, {Client.State}, {Client.RegionHandler.EnabledRegions}");
					handler.SetResult(Client.RegionHandler);
					success = false;
				}
			}
			List<Region> enabledRegions = (await handler.Task).EnabledRegions;
			if (success)
			{
				enabledRegions.Sort((Region a, Region b) => a.Ping.CompareTo(b.Ping));
			}
			base.Events.Report(NetworkEvent.PhotonBeginningServerSearch, $"{enabledRegions.Count} regions for {join_code}");
			foreach (Region region in enabledRegions)
			{
				Client.ConnectToRegionMaster(region.Code);
				Task timeout = Task.Delay(5000, token);
				while (Client.State != ClientState.ConnectedToMasterServer)
				{
					await Task.Delay(10, token);
					if (timeout.IsCompleted)
					{
						base.Events.Report(NetworkEvent.JoiningRegionTimeout);
						return false;
					}
				}
				if (!Client.OpJoinRoom(new EnterRoomParams
				{
					RoomName = join_code
				}))
				{
					base.Events.Report(NetworkEvent.PhotonFailedToAttemptJoining, Client.State.ToString());
					continue;
				}
				Task join_timeout = Task.Delay(5000, token);
				bool failed = false;
				while (Client.State != ClientState.Joined)
				{
					if (token.IsCancellationRequested)
					{
						failed = true;
						break;
					}
					await Task.Delay(10, token);
					if (Client.State == ClientState.ConnectedToMasterServer)
					{
						base.Events.Report(NetworkEvent.JoiningRegionNoRoomFound, $"{Client.CloudRegion} => {Client.State}");
						failed = true;
						break;
					}
					if (join_timeout.IsCompleted)
					{
						base.Events.Report(NetworkEvent.JoiningRegionTimeout, Client.CloudRegion);
						failed = true;
						break;
					}
				}
				if (failed)
				{
					continue;
				}
				base.Events.Report(NetworkEvent.PhotonFoundRoom, region.Code);
				return true;
			}
			base.Events.Report(NetworkEvent.PhotonFailedToFindRoom, join_code);
			return false;
		}

		protected async Task<bool> EnsureRegion(CancellationToken token, string region)
		{
			if (Client.CloudRegion == region)
			{
				return true;
			}
			base.Events.Report(NetworkEvent.JoiningRegion);
			Client.Disconnect();
			Task timeout = Task.Delay(5000, token);
			while (Client.State != ClientState.Disconnected)
			{
				await Task.Delay(100, token);
				if (timeout.IsCompleted)
				{
					base.Events.Report(NetworkEvent.JoiningRegionTimeout);
					return false;
				}
			}
			return Client.ConnectUsingSettings(new AppSettings
			{
				AppIdRealtime = PlatformSettings.PhotonAppID,
				FixedRegion = region,
				Protocol = PlatformSettings.PhotonProtocol,
				AppVersion = PlatformSettings.PhotonAppVersion
			});
		}

		protected async Task<LobbyCreationResult> ChangeLobby(CancellationToken token, PhotonNetworkTarget room_data, Func<bool> perform_change)
		{
			if (!(await EnsureRegion(token, room_data.RoomRegion)))
			{
				base.Events.Report(NetworkEvent.ChangingLobbyFailedWrongRegion);
				return LobbyCreationResult.Fail;
			}
			base.Events.Report(NetworkEvent.ChangingLobby);
			if (Client.CurrentRoom != null)
			{
				LeaveLobby(new PhotonLobby(Client.CurrentRoom));
			}
			Task timeout = Task.Delay(5000, token);
			while (Client.State != ClientState.ConnectedToMasterServer)
			{
				await Task.Delay(100, token);
				if (timeout.IsCompleted)
				{
					base.Events.Report(NetworkEvent.FailedToConnectToMasterServer);
					return LobbyCreationResult.Fail;
				}
			}
			if (!perform_change())
			{
				base.Events.Report(NetworkEvent.FailedToPerformLobbyChange);
				return LobbyCreationResult.Fail;
			}
			timeout = Task.Delay(5000, token);
			while (Client.CurrentRoom == null)
			{
				await Task.Delay(100, token);
				if (Client.State == ClientState.ConnectedToMasterServer)
				{
					base.Events.Report(NetworkEvent.AbandoningLobbyChange);
					return LobbyCreationResult.Abandon;
				}
				if (timeout.IsCompleted)
				{
					base.Events.Report(NetworkEvent.TimedOutOnLobbyChange);
					return LobbyCreationResult.Fail;
				}
			}
			if (Client.CurrentRoom.Name != room_data.RoomName)
			{
				base.Events.Report(NetworkEvent.LobbyChangeFailedWrongResult);
				return LobbyCreationResult.Fail;
			}
			base.Events.Report(NetworkEvent.LobbyChangeSuccess);
			return new LobbyCreationResult
			{
				Success = true,
				Lobby = new PhotonLobby(Client.CurrentRoom)
			};
		}

		public override async Task<LobbyCreationResult> CreateNewLobby(JoinCode join_code, CancellationToken token)
		{
			PhotonNetworkTarget room_data = new PhotonNetworkTarget(Client.CloudRegion, join_code.Actual);
			base.Events.Report(NetworkEvent.StartCreateLobby, room_data.RoomName);
			return await ChangeLobby(token, room_data, () => Client.OpCreateRoom(new EnterRoomParams
			{
				RoomName = room_data.RoomName,
				RoomOptions = new RoomOptions
				{
					MaxPlayers = 4,
					IsVisible = false,
					CleanupCacheOnLeave = true
				}
			}));
		}

		public override async Task<LobbyCreationResult> JoinLobby(PhotonNetworkTarget target, CancellationToken token)
		{
			if (target.IsPlayer || !target.IsValid)
			{
				base.Events.Report(NetworkEvent.StartJoinLobbyFailedInvalidLobby);
				return LobbyCreationResult.Abandon;
			}
			base.Events.Report(NetworkEvent.StartJoinLobby);
			if (!(await SearchRegions(token, target.RoomName)))
			{
				return LobbyCreationResult.Abandon;
			}
			if (Client.CurrentRoom.Name != target.RoomName)
			{
				base.Events.Report(NetworkEvent.LobbyChangeFailedWrongResult);
				return LobbyCreationResult.Fail;
			}
			base.Events.Report(NetworkEvent.LobbyChangeSuccess);
			return new LobbyCreationResult
			{
				Success = true,
				Lobby = new PhotonLobby(Client.CurrentRoom)
			};
		}

		public override void LeaveLobby(PhotonLobby lobby)
		{
			if (Client.CurrentRoom != null)
			{
				if (lobby.Room != Client.CurrentRoom)
				{
					base.Events.Report(NetworkEvent.LeaveLobbyFailedWrongLobby);
				}
				else if (!Client.OpLeaveRoom(becomeInactive: false))
				{
					base.Events.Report(NetworkEvent.LeaveLobbyFailed);
				}
			}
		}

		public override void GetOtherLobbyMembers(PhotonLobby lobby, ref List<PhotonNetworkTarget> result)
		{
			result.Clear();
			foreach (KeyValuePair<int, Player> player in lobby.Room.Players)
			{
				if (!Me.Matches(player.Value))
				{
					result.Add(new PhotonNetworkTarget(player.Value));
				}
			}
		}

		public override PhotonNetworkTarget GetLobbyHost(PhotonLobby lobby)
		{
			foreach (KeyValuePair<int, Player> player in lobby.Room.Players)
			{
				if (player.Value.IsMasterClient)
				{
					return new PhotonNetworkTarget(player.Value);
				}
			}
			return default(PhotonNetworkTarget);
		}

		public override void SetLobbyPermission(PhotonLobby lobby, NetworkPermissions perms)
		{
			switch (perms)
			{
			case NetworkPermissions.Private:
				lobby.Room.IsOpen = false;
				lobby.Room.IsVisible = false;
				break;
			case NetworkPermissions.InviteOnly:
				lobby.Room.IsOpen = true;
				lobby.Room.IsVisible = false;
				break;
			case NetworkPermissions.Open:
				lobby.Room.IsOpen = true;
				lobby.Room.IsVisible = true;
				break;
			}
		}

		public override bool IsValidLobby(PhotonLobby lobby)
		{
			return lobby.Room != null;
		}

		public override string GetUsernameInLobby(PhotonLobby lobby, PhotonNetworkTarget user)
		{
			if (!user.IsPlayer || user.Player == null)
			{
				return "";
			}
			return user.Player.NickName;
		}

		public override TransportSendResult SendData(PhotonLobby lobby, PhotonNetworkTarget user, byte[] data)
		{
			if (!user.IsPlayer || data == null || !Client.IsConnectedAndReady)
			{
				return TransportSendResult.FailedMissingArgument;
			}
			_MessageTarget[0] = user.Player.ActorNumber;
			int result = (Client.OpRaiseEvent(1, data, new RaiseEventOptions
			{
				TargetActors = _MessageTarget
			}, new SendOptions
			{
				Encrypt = false,
				DeliveryMode = DeliveryMode.Reliable,
				Reliability = true
			}) ? 1 : 3);
			Send();
			return (TransportSendResult)result;
		}

		public TransportSendResult SendToAllClients(byte[] data)
		{
			if (data == null || !Client.IsConnectedAndReady)
			{
				return TransportSendResult.FailedMissingArgument;
			}
			int result = (Client.OpRaiseEvent(1, data, new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			}, new SendOptions
			{
				Encrypt = false,
				DeliveryMode = DeliveryMode.Reliable,
				Reliability = true
			}) ? 1 : 3);
			Send();
			return (TransportSendResult)result;
		}

		public void OnEvent(EventData photon_event)
		{
			if (photon_event.Code == 1)
			{
				byte[] array = null;
				try
				{
					array = (byte[])photon_event.CustomData;
				}
				catch (Exception message)
				{
					Debug.LogError(message);
					return;
				}
				Player player = Client.CurrentRoom.GetPlayer(photon_event.Sender, findMaster: true);
				HandleNetworkMessage(new PhotonNetworkTarget(player), array);
			}
		}

		protected override void SetSingleton()
		{
			if (PlatformSettings.UsePhotonNetworking)
			{
				NetworkServices.Available.Add(this);
				Instance = this;
			}
		}

		protected override async Task<bool> PerformConnectToService()
		{
			if (!ShouldEnablePhoton)
			{
				return false;
			}
			base.Events.Report(NetworkEvent.StartServiceConnect);
			Result<AuthenticationValues> result = await Platform.Current.GetPhotonAuth();
			if (!result.Success)
			{
				base.Events.Report(NetworkEvent.ServiceConnectFailedToAuthenticate);
				return false;
			}
			base.Events.Report(NetworkEvent.ServiceConnectSuccessfullyAuthenticated);
			Client.AuthValues = result.Value;
			Client.ConnectUsingSettings(new AppSettings
			{
				AppIdRealtime = PlatformSettings.PhotonAppID,
				FixedRegion = "",
				Protocol = PlatformSettings.PhotonProtocol,
				AppVersion = PlatformSettings.PhotonAppVersion
			});
			while (!Client.IsConnectedAndReady)
			{
				await Task.Delay(100);
			}
			if (PlatformSettings.IsEditor)
			{
				Client.LoadBalancingPeer.DisconnectTimeout = 120000;
			}
			base.Events.Report(NetworkEvent.ServiceConnectSuccess);
			return true;
		}

		protected override void PerformDisconnectFromService()
		{
			base.Events.Report(NetworkEvent.StartServiceDisconnect);
			LeaveLobby(new PhotonLobby(Client.CurrentRoom));
			Client.Disconnect();
		}

		public override bool IsInLobby(PhotonLobby lobby)
		{
			if (Client.CurrentRoom != null)
			{
				return lobby.IsEquivalent(Client.CurrentRoom);
			}
			return false;
		}

		public void OnFriendListUpdate(List<FriendInfo> friendList)
		{
		}

		public void OnCreatedRoom()
		{
		}

		public void OnCreateRoomFailed(short returnCode, string message)
		{
			Debug.LogWarning($"Photon Create Failed ({returnCode}: {message})");
		}

		public void OnJoinedRoom()
		{
		}

		public void OnJoinRoomFailed(short returnCode, string message)
		{
			Debug.LogWarning($"Photon Join Failed ({returnCode}: {message})");
		}

		public void OnJoinRandomFailed(short returnCode, string message)
		{
		}

		public void OnLeftRoom()
		{
		}

		public void OnErrorInfo(ErrorInfo errorInfo)
		{
			EventLog.Networking.Report(NetworkEvent.PhotonError, errorInfo.Info);
		}
	}
}
