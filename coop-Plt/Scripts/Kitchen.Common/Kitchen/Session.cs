using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;
using WebSocketSharp;

namespace Kitchen
{
	public static class Session
	{
		public static GameCreator GameCreator;

		public static List<(SourceIdentifier, NetworkPeerInformation)> NetworkPeers = new List<(SourceIdentifier, NetworkPeerInformation)>();

		public static SourceIdentifier HostIdentifier;

		public static HashSet<SourceIdentifier> KickRequests = new HashSet<SourceIdentifier>();

		public static NetworkedPlayState NetworkedPlayState = NetworkedPlayState.NotInGame;

		public static List<RetainedPlayer> RetainedPlayers = new List<RetainedPlayer>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void InitOnLoad()
		{
			PostLoadingInstructionManager.RegisterPostLoadingTasks(InstructionGroup.NonDependent, (delegate
			{
				GameCreator = null;
				NetworkPeers.Clear();
				KickRequests.Clear();
				NetworkedPlayState = NetworkedPlayState.NotInGame;
				RetainedPlayers.Clear();
				return Task.CompletedTask;
			}, "Reset Session"));
		}

		public static bool GetPeerInfo(SourceIdentifier source, out NetworkPeerInformation result)
		{
			foreach (var networkPeer in NetworkPeers)
			{
				if (networkPeer.Item1 == source)
				{
					result = networkPeer.Item2;
					return true;
				}
			}
			result = default(NetworkPeerInformation);
			return false;
		}

		public static bool GetPeerInfo(INetworkTarget target, out (SourceIdentifier, NetworkPeerInformation) result)
		{
			foreach (var networkPeer in NetworkPeers)
			{
				if (networkPeer.Item2.Target.IsEquivalent(target))
				{
					result = networkPeer;
					return true;
				}
			}
			result = default((SourceIdentifier, NetworkPeerInformation));
			return false;
		}

		public static void SetPeerInfo(SourceIdentifier source, INetworkTarget target, Func<NetworkPeerInformation> create_info)
		{
			for (int i = 0; i < NetworkPeers.Count; i++)
			{
				(SourceIdentifier, NetworkPeerInformation) tuple = NetworkPeers[i];
				bool flag = tuple.Item1 == source;
				bool flag2 = target.IsEquivalent(tuple.Item2.Target);
				if (!flag && !flag2)
				{
					continue;
				}
				string name = tuple.Item2.Name;
				if (!flag || !flag2 || name.IsNullOrEmpty())
				{
					NetworkPeers[i] = (source, create_info());
					if (!flag)
					{
						EventLog.Networking.Report(NetworkEvent.PeerInfo, $"Target match but not source match ({source}, {tuple.Item1})");
					}
					if (!flag2)
					{
						EventLog.Networking.Report(NetworkEvent.PeerInfo, $"Source match but not target match ({target}, {tuple.Item2.Target})");
					}
					if (name.IsNullOrEmpty())
					{
						EventLog.Networking.Report(NetworkEvent.PeerInfo, $"Adding missing name ({NetworkPeers[i].Item2.Name}, for {source}, {target})");
					}
				}
				return;
			}
			NetworkPeers.Add((source, create_info()));
		}

		private static void RetainPlayers()
		{
			RetainedPlayers.Clear();
			foreach (PlayerInfo item in from p in Players.Main.All()
				orderby p.Index
				select p)
			{
				if (item.IsLocalUser)
				{
					RetainedPlayers.Add(new RetainedPlayer
					{
						PlayerProfile = item.Profile.Identifier,
						InputPlayerID = item.ID
					});
				}
			}
		}

		public static NetworkInviteData GetInvite()
		{
			if (!GameCreator || GameCreator.CurrentWorld == null)
			{
				return default(NetworkInviteData);
			}
			RouterManager existingSystem = GameCreator.CurrentWorld.GetExistingSystem<RouterManager>();
			if (existingSystem == null)
			{
				return default(NetworkInviteData);
			}
			NetworkRouter router = existingSystem.GetRouter<NetworkRouter>();
			if (router == null)
			{
				return default(NetworkInviteData);
			}
			NetworkInviteData inviteData = router.GetInviteData();
			inviteData.AvailableSlots = Mathf.Min(3, 4 - Players.Main.All().Count);
			return inviteData;
		}

		public static async void CheckForPlatformConnectionRequest()
		{
			if (Platform.Current == null || Platform.Current.QueuedJoinTarget.InviteString == null)
			{
				return;
			}
			NetworkInviteData queuedJoinTarget = Platform.Current.QueuedJoinTarget;
			Platform.Current.QueuedJoinTarget = default(NetworkInviteData);
			INetworkTarget networkTarget = await NetworkServices.GetTargetForInvite(queuedJoinTarget);
			if (networkTarget == null)
			{
				return;
			}
			if ((bool)GameCreator && GameCreator.CurrentWorld != null)
			{
				RouterManager existingSystem = GameCreator.CurrentWorld.GetExistingSystem<RouterManager>();
				if (existingSystem != null && existingSystem.GetRouter<NetworkRouter>().IsConnectedTo(networkTarget))
				{
					return;
				}
			}
			JoinGame(networkTarget);
		}

		public static void JoinGame(INetworkTarget target, bool retain_players = true)
		{
			EventLog.Session.Report(SessionEvent.JoiningRemoteGame, target.ToString());
			if (retain_players)
			{
				RetainPlayers();
			}
			GameCreator.JoinOtherWorld(target);
		}

		public static void ResetGame()
		{
			CreateGame(NetworkedPlayState.IsNetworked());
		}

		public static void CreateGame(bool allow_networking = true, bool retain_players = true)
		{
			EventLog.Session.Report(SessionEvent.StartingHostedGame, allow_networking.ToString());
			if (retain_players)
			{
				RetainPlayers();
			}
			GameCreator.JoinOwnWorld(allow_networking);
		}

		public static void SwitchToLocalOnlySession()
		{
			switch (NetworkedPlayState)
			{
			case NetworkedPlayState.Host:
				EventLog.Session.Report(SessionEvent.SwitchingToLocalOnly);
				NetworkedPlayState = NetworkedPlayState.NotNetworked;
				break;
			case NetworkedPlayState.Client:
				EventLog.Session.Report(SessionEvent.SwitchingToLocalOnly);
				CreateGame(allow_networking: false);
				break;
			}
		}

		public static void SwitchToOnlineSession()
		{
			if (NetworkedPlayState == NetworkedPlayState.NotNetworked)
			{
				EventLog.Session.Report(SessionEvent.SwitchingToOnline);
				NetworkedPlayState = NetworkedPlayState.Host;
			}
		}

		[Cert(new TRC[] { TRC.R5093 })]
		public static void SoftExit()
		{
			if (NetworkedPlayState.IsOwnGame() || NetworkedPlayState == NetworkedPlayState.NotInGame)
			{
				Debug.LogWarning("Quitting: User request");
				if (!Application.isEditor && PlatformSettings.CurrentPlatformType != PlatformType.PS5 && PlatformSettings.CurrentPlatformType != PlatformType.PS4)
				{
					if (Platform.Current == null)
					{
						Application.Quit(0);
					}
					else
					{
						Platform.Current.Quit();
					}
				}
			}
			else
			{
				CreateGame();
			}
		}

		public static void GetConnectedPlayers(ref List<NetworkTargetDescription> users)
		{
			users.Clear();
			if ((bool)GameCreator && GameCreator.CurrentWorld != null)
			{
				GameCreator.CurrentWorld.GetExistingSystem<RouterManager>()?.GetConnectedPlayers(ref users);
			}
		}

		public static void CleanUp()
		{
			GameCreator = null;
			NetworkPeers = new List<(SourceIdentifier, NetworkPeerInformation)>();
			KickRequests = new HashSet<SourceIdentifier>();
			RetainedPlayers = new List<RetainedPlayer>();
		}
	}
}
