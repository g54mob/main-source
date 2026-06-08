using System;
using Kitchen.NetworkSupport;
using Platforms;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

namespace Kitchen.Transports
{
	public class SteamLobbyTransport : LobbyNetworkTransport<SteamNetworkTarget, Lobby>
	{
		public override ConnectionType ConnectionType => ConnectionType.Steam;

		private SteamNetworkService Steam => SteamNetworkService.Steam;

		protected override BaseService<SteamNetworkTarget, Lobby> Service => Steam;

		public SteamLobbyTransport(JoinCode join_code)
			: base(join_code)
		{
		}

		public override void Initialise()
		{
			base.Initialise();
			SteamNetworking.OnP2PSessionRequest = (Action<SteamId>)Delegate.Combine(SteamNetworking.OnP2PSessionRequest, new Action<SteamId>(OnP2PSessionRequest));
			Service.OnNetworkMessage += HandleMessage;
		}

		public override void SupplyInviteData(ref NetworkInviteData invite_data)
		{
			if (base.CurrentLobby.Id.IsValid)
			{
				invite_data.InviteString = PlatformHelpers.AppendToInvite(invite_data.InviteString, "STEAM_LOBBY:", base.CurrentLobby.Id.ToString());
				if (NetworkHelpers.CurrentNetworkPermissions == NetworkPermissions.Open)
				{
					string data = base.CurrentLobby.GetData(JoinCodeHelpers.DataKey);
					invite_data.InviteString = PlatformHelpers.AppendToInvite(invite_data.InviteString, "STEAM_CODE:", data);
				}
			}
		}

		public override void Dispose()
		{
			SteamNetworking.OnP2PSessionRequest = (Action<SteamId>)Delegate.Remove(SteamNetworking.OnP2PSessionRequest, new Action<SteamId>(OnP2PSessionRequest));
			Service.OnNetworkMessage -= HandleMessage;
			base.Dispose();
		}

		private void OnP2PSessionRequest(SteamId steam_id)
		{
			UpdateLobbyMembers();
			if (LobbyMembers.Contains(steam_id))
			{
				SteamNetworking.AcceptP2PSessionWithUser(steam_id);
				Debug.LogWarning($"Accepted P2P with {steam_id}");
			}
			else
			{
				Debug.LogWarning($"Rejected P2P with {steam_id} (not in my lobby)");
			}
		}

		protected override TransportSendResult SendToClient(SteamNetworkTarget client, byte[] data)
		{
			return Steam.SendData(base.CurrentLobby, client, data);
		}

		private void HandleMessage(SteamNetworkTarget source, byte[] data)
		{
			ReceiveData(source, data);
		}

		protected override bool IsEquivalent(SteamNetworkTarget target, Lobby lobby)
		{
			if (target == null)
			{
				return false;
			}
			if ((ulong)target.ID != (ulong)lobby.Owner.Id)
			{
				return (ulong)target.ID == (ulong)lobby.Id;
			}
			return true;
		}

		protected override string GetTargetName(SteamNetworkTarget target)
		{
			return Steam.GetUsernameInLobby(base.CurrentLobby, target);
		}

		protected override bool IsValidLobby(Lobby lobby)
		{
			return lobby.Id.IsValid;
		}

		public override SteamNetworkTarget GetTargetForLobby(Lobby lobby)
		{
			return new SteamNetworkTarget(lobby.Owner.Id);
		}
	}
}
