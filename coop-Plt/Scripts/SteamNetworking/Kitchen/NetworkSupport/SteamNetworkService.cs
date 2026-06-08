using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kitchen.Transports;
using Platforms;
using Platforms.Steam;
using Steamworks;
using Steamworks.Data;

namespace Kitchen.NetworkSupport
{
	public class SteamNetworkService : BaseService<SteamNetworkTarget, Lobby>
	{
		public static SteamNetworkService Steam;

		private HashSet<SteamId> CurrentP2PUsers = new HashSet<SteamId>();

		private HashSet<Lobby> CurrentLobbies = new HashSet<Lobby>();

		private const int TimeoutMs = 5000;

		private bool HasSetListeners;

		public override string Name => "Steam";

		public override bool CanAcceptJoinCode => base.State == PlatformState.Ready;

		public bool IsOverlayOpen { get; private set; }

		public override SteamNetworkTarget Me => new SteamNetworkTarget(SteamClient.SteamId);

		public override async Task<Result<INetworkTarget>> GetTargetFromJoinCode(JoinCode invite)
		{
			SteamId steamId = await Steam.GetLobbyFromCode(invite);
			if ((ulong)steamId == 0L)
			{
				return Result.Fail<INetworkTarget>();
			}
			return Result.Succeed((INetworkTarget)new SteamNetworkTarget(steamId));
		}

		private void Log(string msg)
		{
			KitchenLogger.Log("SteamNetworkService", msg);
		}

		protected override void SetSingleton()
		{
			if (PlatformSettings.UseSteamNetworking)
			{
				NetworkServices.Available.Add(this);
				Steam = this;
			}
		}

		public void AcceptP2PUser(SteamId user)
		{
			CurrentP2PUsers.Add(user);
			SteamNetworking.AcceptP2PSessionWithUser(user);
		}

		public void CloseAllP2P()
		{
			foreach (SteamId currentP2PUser in CurrentP2PUsers)
			{
				SteamNetworking.CloseP2PSessionWithUser(currentP2PUser);
			}
		}

		protected void UpdateOverlayState(bool active)
		{
			IsOverlayOpen = active;
		}

		protected override void PerformConnectedUpdate()
		{
			while (SteamNetworking.IsP2PPacketAvailable())
			{
				P2Packet? p2Packet = SteamNetworking.ReadP2PPacket();
				if (p2Packet.HasValue && p2Packet.Value.Data.Length != 0)
				{
					SteamNetworkTarget t = p2Packet.Value.SteamId;
					HandleNetworkMessage(t, p2Packet.Value.Data);
				}
			}
		}

		protected override Task<bool> PerformConnectToService()
		{
			if (Platform.Current is SteamPlatform steamPlatform)
			{
				bool initialized = steamPlatform.Initialized;
				if (initialized)
				{
					if (!HasSetListeners)
					{
						HasSetListeners = true;
						SteamFriends.OnGameOverlayActivated += UpdateOverlayState;
						SteamMatchmaking.OnLobbyEntered += OnJoinLobby;
					}
					base.State = PlatformState.Ready;
				}
				return Task.FromResult(initialized);
			}
			return Task.FromResult(result: false);
		}

		private void OnJoinLobby(Lobby lobby)
		{
			CurrentLobbies.Add(lobby);
		}

		protected override void PerformDisconnectFromService()
		{
			ClearConnections();
			base.State = PlatformState.NotStarted;
		}

		private void ClearConnections()
		{
			CloseAllP2P();
			foreach (Lobby currentLobby in CurrentLobbies)
			{
				if (IsValidLobby(currentLobby) && IsInLobby(currentLobby))
				{
					currentLobby.Leave();
				}
			}
			CurrentLobbies.Clear();
		}

		public override bool IsInLobby(Lobby lobby)
		{
			if (lobby.Members == null)
			{
				return false;
			}
			foreach (Friend member in lobby.Members)
			{
				if (member.IsMe)
				{
					return true;
				}
			}
			return false;
		}

		public override INetworkTransport GetNewTransport(JoinCode join_code)
		{
			return new SteamLobbyTransport(join_code);
		}

		public override async Task<Result<INetworkTarget>> CanHandleInvite(NetworkInviteData data)
		{
			SteamId steamLobbyFromInvite = SteamPlatform.GetSteamLobbyFromInvite(data);
			if ((ulong)steamLobbyFromInvite != 0L)
			{
				return Result.Succeed((INetworkTarget)new SteamNetworkTarget(steamLobbyFromInvite));
			}
			string steamJoinCodeFromInvite = SteamPlatform.GetSteamJoinCodeFromInvite(data);
			if (steamJoinCodeFromInvite != null)
			{
				return Result.Succeed((INetworkTarget)new SteamNetworkTarget(await GetLobbyFromCode(JoinCode.CreateFromRemote(steamJoinCodeFromInvite))));
			}
			return default(Result<INetworkTarget>);
		}

		public override void GetOtherLobbyMembers(Lobby lobby, ref List<SteamNetworkTarget> result)
		{
			result.Clear();
			foreach (Friend member in lobby.Members)
			{
				if (!member.IsMe)
				{
					result.Add(member);
				}
			}
		}

		public override SteamNetworkTarget GetLobbyHost(Lobby lobby)
		{
			return new SteamNetworkTarget(lobby.Owner.Id);
		}

		public override async Task<LobbyCreationResult> CreateNewLobby(JoinCode join_code, CancellationToken token)
		{
			ClearConnections();
			Task timeout = Task.Delay(5000, token);
			while (base.State != PlatformState.Ready)
			{
				await Task.Delay(100, token);
				if (timeout.IsCompleted)
				{
					return LobbyCreationResult.Fail;
				}
			}
			Lobby? result = await SteamMatchmaking.CreateLobbyAsync(4);
			if (!result.HasValue)
			{
				return new LobbyCreationResult
				{
					Success = false
				};
			}
			if (!(await SetLobbyJoinCode(result.Value, join_code.Actual)))
			{
				LeaveLobby(result.GetValueOrDefault());
				return new LobbyCreationResult
				{
					Success = false
				};
			}
			return new LobbyCreationResult
			{
				Success = true,
				Lobby = result.GetValueOrDefault()
			};
		}

		public override async Task<LobbyCreationResult> JoinLobby(SteamNetworkTarget target, CancellationToken token)
		{
			ClearConnections();
			Task timeout = Task.Delay(5000, token);
			while (base.State != PlatformState.Ready)
			{
				await Task.Delay(100, token);
				if (timeout.IsCompleted)
				{
					return LobbyCreationResult.Fail;
				}
			}
			Lobby? lobby = await SteamMatchmaking.JoinLobbyAsync(target.ID);
			if (!lobby.HasValue)
			{
				return new LobbyCreationResult
				{
					Success = false
				};
			}
			return new LobbyCreationResult
			{
				Success = true,
				Lobby = lobby.GetValueOrDefault()
			};
		}

		private async Task<bool> SetLobbyJoinCode(Lobby lobby, string join_code)
		{
			Lobby[] array = await SteamMatchmaking.LobbyList.WithMaxResults(1).FilterDistanceWorldwide().WithKeyValue(JoinCodeHelpers.DataKey, join_code)
				.RequestAsync();
			if (array == null || !array.Any())
			{
				if (!lobby.SetData(JoinCodeHelpers.DataKey, join_code))
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public async Task<SteamId> GetLobbyFromCode(JoinCode code)
		{
			Task timeout = Task.Delay(5000);
			while (base.State != PlatformState.Ready)
			{
				await Task.Delay(100);
				if (timeout.IsCompleted)
				{
					return default(SteamId);
				}
			}
			Lobby[] array = await SteamMatchmaking.LobbyList.WithMaxResults(1).FilterDistanceWorldwide().WithKeyValue(JoinCodeHelpers.DataKey, code.Actual)
				.RequestAsync();
			if (array == null || array.Length == 0)
			{
				return default(SteamId);
			}
			return array[0].Id;
		}

		public override void LeaveLobby(Lobby lobby)
		{
			if (base.State != PlatformState.Ready)
			{
				return;
			}
			try
			{
				lobby.Leave();
			}
			catch
			{
				Log("Did not leave lobby cleanly");
			}
		}

		public override string GetUsernameInLobby(Lobby lobby, SteamNetworkTarget id)
		{
			if ((ulong)id.ID == (ulong)SteamClient.SteamId)
			{
				return SteamClient.Name;
			}
			if ((ulong)lobby.Id == 0L)
			{
				return "Steam User";
			}
			foreach (Friend member in lobby.Members)
			{
				if (member.Id == id)
				{
					return member.Name;
				}
			}
			return "Steam User";
		}

		public override TransportSendResult SendData(Lobby lobby, SteamNetworkTarget user, byte[] data)
		{
			if (user == null || data == null)
			{
				return TransportSendResult.FailedMissingArgument;
			}
			if (base.State != PlatformState.Ready)
			{
				return TransportSendResult.FailedNotConnected;
			}
			SteamNetworking.SendP2PPacket(user.ID, data);
			return TransportSendResult.Success;
		}

		public override void SetLobbyPermission(Lobby lobby, NetworkPermissions perms)
		{
			if ((ulong)lobby.Id != 0L)
			{
				switch (perms)
				{
				case NetworkPermissions.Private:
					lobby.SetPrivate();
					break;
				case NetworkPermissions.InviteOnly:
					lobby.SetPrivate();
					break;
				case NetworkPermissions.Open:
					lobby.SetPublic();
					break;
				}
			}
		}

		public override bool IsValidLobby(Lobby lobby)
		{
			return (ulong)lobby.Id != 0;
		}
	}
}
