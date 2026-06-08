using Kitchen.NetworkSupport;
using Platforms;

namespace Kitchen.Transports
{
	public class PhotonLobbyTransport : LobbyNetworkTransport<PhotonNetworkTarget, PhotonLobby>
	{
		public override ConnectionType ConnectionType => ConnectionType.Photon;

		protected override BaseService<PhotonNetworkTarget, PhotonLobby> Service => PhotonNetworkService.Instance;

		public override bool ShouldBeActive => PhotonNetworkService.ShouldEnablePhoton;

		public PhotonLobbyTransport(JoinCode join_code)
			: base(join_code)
		{
		}

		public override void Initialise()
		{
			base.Initialise();
			Service.OnNetworkMessage += HandleMessage;
		}

		public override void Dispose()
		{
			base.Dispose();
			Service.OnNetworkMessage -= HandleMessage;
		}

		protected override bool IsEquivalent(PhotonNetworkTarget target, PhotonLobby lobby)
		{
			if (target.IsPlayer && target.Player.IsLocal)
			{
				if (lobby.Room == null)
				{
					return false;
				}
				if (lobby.Room.Players.TryGetValue(lobby.Room.MasterClientId, out var value))
				{
					return value.IsLocal;
				}
				return false;
			}
			if (!target.IsPlayer)
			{
				return target.IsEquivalent(lobby);
			}
			return false;
		}

		protected override string GetTargetName(PhotonNetworkTarget target)
		{
			return Service.GetUsernameInLobby(base.CurrentLobby, target);
		}

		protected override bool IsValidLobby(PhotonLobby lobby)
		{
			return lobby.Room != null;
		}

		public override PhotonNetworkTarget GetTargetForLobby(PhotonLobby lobby)
		{
			return new PhotonNetworkTarget(lobby);
		}

		protected override TransportSendResult SendToClient(PhotonNetworkTarget client, byte[] data)
		{
			return Service.SendData(base.CurrentLobby, client, data);
		}

		private void HandleMessage(PhotonNetworkTarget source, byte[] data)
		{
			ReceiveData(source, data);
		}

		public override void SupplyInviteData(ref NetworkInviteData invite_data)
		{
			if (base.CurrentLobby.Room != null)
			{
				invite_data.InviteString = PlatformHelpers.AppendToInvite(invite_data.InviteString, "PHOTON_CODE:", base.CurrentLobby.Room.Name);
			}
		}

		protected override TransportSendResult SendToClients(byte[] data)
		{
			bool flag = false;
			foreach (PhotonNetworkTarget lobbyMember in LobbyMembers)
			{
				if (KickedMembers.Contains(lobbyMember) || BannedMembers.Contains(lobbyMember))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return base.SendToClients(data);
			}
			return PhotonNetworkService.Instance.SendToAllClients(data);
		}

		public override bool RequestJoinServer(INetworkTarget target)
		{
			if (!base.RequestJoinServer(target))
			{
				return false;
			}
			if (PlatformSettings.NeedsCrossplayOptIn)
			{
				NetworkServices.HasCrossplayEnabled = true;
			}
			return true;
		}
	}
}
