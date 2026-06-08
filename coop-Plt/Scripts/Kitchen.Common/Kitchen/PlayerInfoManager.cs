using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Kitchen.Modules;
using Platforms;
using UnityEngine;
using WebSocketSharp;

namespace Kitchen
{
	[Serializable]
	public class PlayerInfoManager : ResponsiveObjectView<InfoManagerViewData, InfoManagerResponseData>
	{
		[Header("Configuration")]
		public static float DisplayJoinGrace;

		[Header("References")]
		[SerializeField]
		public Transform Container;

		[Header("State")]
		private Dictionary<SourceIdentifier, PlayerElement> PeerModules = new Dictionary<SourceIdentifier, PlayerElement>();

		private Dictionary<(SourceIdentifier, int), PlayerElement> PlayerModules = new Dictionary<(SourceIdentifier, int), PlayerElement>();

		private HashSet<int> RemoveList = new HashSet<int>();

		private InfoManagerViewData ViewDataCache;

		private PlayerElement JoinPrompt;

		private List<InfoManagerPeerDetail> _PeerCacheMissing = new List<InfoManagerPeerDetail>();

		private List<SourceIdentifier> _PeerCacheExtra = new List<SourceIdentifier>();

		private List<(SourceIdentifier, int)> _PlayerCacheMissing = new List<(SourceIdentifier, int)>();

		private List<(SourceIdentifier, int)> _PlayerCacheExtra = new List<(SourceIdentifier, int)>();

		private InfoManagerResponseData Response;

		public override void Initialise()
		{
			base.Initialise();
			Players.Main.OnPlayerInfoChanged += UpdateDisplay;
			Players.Main.OnBroadcastLocalPlayerChange += PlayersOnBroadcastLocalPlayerChange;
			foreach (PlayerInfo item in Players.Main.All())
			{
				if (item.IsLocalUser)
				{
					PlayersOnBroadcastLocalPlayerChange(item.ID);
				}
			}
			JoinPrompt = UnityEngine.Object.Instantiate(ModuleDirectory.Main.GetPrefab<PlayerElement>(), Container, worldPositionStays: true);
			JoinPrompt.transform.localRotation = Quaternion.identity;
			JoinPrompt.SetJoinPrompt();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			Players.Main.OnPlayerInfoChanged -= UpdateDisplay;
			Players.Main.OnBroadcastLocalPlayerChange -= PlayersOnBroadcastLocalPlayerChange;
		}

		protected override void UpdateData(InfoManagerViewData view_data)
		{
			ViewDataCache = view_data;
			Players.Main.ReceiveRemoteUpdate(view_data.Players.Select((InfoManagerPlayerDetail i) => new PlayerInfo
			{
				ID = i.ID,
				Identifier = i.Identifier,
				Username = i.MainName,
				Profile = new PlayerProfile
				{
					Name = i.SubName,
					Colour = i.Colour,
					Cosmetics = i.Cosmetics
				},
				JoinProgress = i.JoinProgress,
				Index = i.Index
			}).ToList());
			UpdateDisplay();
			foreach (InfoManagerPlayerDetail player in view_data.Players)
			{
				if (player.IsLocalUser)
				{
					PlatformUser platformUser = InputSourceIdentifier.Default.GetPlatformUser(player.ID);
					Platform.Current.ReportUserColour(platformUser, player.Colour);
				}
			}
		}

		protected void UpdateDisplay()
		{
			if (ViewDataCache.Players != null && ViewDataCache.Peers != null)
			{
				EnsureCorrectModules();
				ConfigureModules();
				ArrangeModules();
				PushData();
			}
		}

		private void PushData()
		{
			Players.Main.PeerData.Clear();
			foreach (KeyValuePair<SourceIdentifier, PlayerElement> peer in PeerModules)
			{
				try
				{
					InfoManagerPeerDetail value = ViewDataCache.Peers.First((InfoManagerPeerDetail p) => p.Identifier == peer.Key);
					Players.Main.PeerData.Add(peer.Key, value);
				}
				catch (KeyNotFoundException)
				{
				}
			}
		}

		protected void EnsureCorrectModules()
		{
			SetMatcher.Difference(ViewDataCache.Peers.Where((InfoManagerPeerDetail p) => !p.HasPlayers), PeerModules.Keys, ref _PeerCacheMissing, ref _PeerCacheExtra, (InfoManagerPeerDetail x, SourceIdentifier y) => x.Identifier == y);
			foreach (SourceIdentifier item in _PeerCacheExtra)
			{
				if (PeerModules.TryGetValue(item, out var value))
				{
					value.Destroy();
					PeerModules.Remove(item);
				}
			}
			foreach (InfoManagerPeerDetail item2 in _PeerCacheMissing)
			{
				if (!PeerModules.ContainsKey(item2.Identifier))
				{
					PlayerElement playerElement = UnityEngine.Object.Instantiate(ModuleDirectory.Main.GetPrefab<PlayerElement>(), Container, worldPositionStays: true);
					playerElement.transform.localRotation = Quaternion.identity;
					PeerModules[item2.Identifier] = playerElement;
				}
			}
			SetMatcher.Difference<(SourceIdentifier, int), (SourceIdentifier, int)>(ViewDataCache.Players.Select((InfoManagerPlayerDetail k) => (Identifier: k.Identifier, ID: k.ID)), PlayerModules.Keys, ref _PlayerCacheMissing, ref _PlayerCacheExtra, ((SourceIdentifier, int) x, (SourceIdentifier, int) y) => x.Item1 == y.Item1 && x.Item2 == y.Item2);
			foreach (var item3 in _PlayerCacheExtra)
			{
				if (PlayerModules.TryGetValue(item3, out var value2))
				{
					value2.Destroy();
					PlayerModules.Remove(item3);
				}
			}
			foreach (var item4 in _PlayerCacheMissing)
			{
				PlayerElement playerElement2 = UnityEngine.Object.Instantiate(ModuleDirectory.Main.GetPrefab<PlayerElement>(), Container, worldPositionStays: true);
				playerElement2.transform.localRotation = Quaternion.identity;
				PlayerModules.Add(item4, playerElement2);
			}
			JoinPrompt.SetVisible(PlayerModules.Count < 4);
		}

		protected void ConfigureModules()
		{
			foreach (KeyValuePair<(SourceIdentifier, int), PlayerElement> playerModule in PlayerModules)
			{
				playerModule.Value.SetPlayer(playerModule.Key.Item2);
			}
			foreach (KeyValuePair<SourceIdentifier, PlayerElement> module in PeerModules)
			{
				InfoManagerPeerDetail infoManagerPeerDetail = ViewDataCache.Peers.FirstOrDefault((InfoManagerPeerDetail p) => p.Identifier == module.Key);
				string peer = (infoManagerPeerDetail.MainName.IsNullOrEmpty() ? "--" : infoManagerPeerDetail.MainName);
				module.Value.SetPeer(peer);
			}
		}

		protected void ArrangeModules()
		{
			int num = ((PlayerModules.Count < 4) ? 1 : 0) + PlayerModules.Count + PeerModules.Count;
			Vector2 vector = new Vector2(0f, 0f);
			Vector2 vector2 = new Vector2(2.2f, 0f);
			Vector2 vector3 = vector - (num - 1) * vector2 / 2f;
			int num2 = 0;
			foreach (KeyValuePair<SourceIdentifier, PlayerElement> item in PeerModules.OrderBy((KeyValuePair<SourceIdentifier, PlayerElement> a) => a.Key.Value))
			{
				Vector2 vector4 = vector3 + num2++ * vector2;
				if (!item.Value.HasBeenPositioned)
				{
					item.Value.Position = vector4 + new Vector2(0f, -1f);
				}
				item.Value.MoveAnimated(vector4);
			}
			foreach (KeyValuePair<(SourceIdentifier, int), PlayerElement> item2 in PlayerModules.OrderBy((KeyValuePair<(SourceIdentifier, int), PlayerElement> a) => Players.Main.Get(a.Key.Item2).Index))
			{
				Vector2 vector5 = vector3 + num2++ * vector2;
				if (!item2.Value.HasBeenPositioned)
				{
					item2.Value.Position = vector5 + new Vector2(0f, -1f);
				}
				item2.Value.MoveAnimated(vector5);
			}
			JoinPrompt.MoveAnimated(vector3 + num2++ * vector2);
		}

		private void PlayersOnBroadcastLocalPlayerChange(int id)
		{
			ref List<InfoManagerResponseUpdate> updates = ref Response.Updates;
			if (updates == null)
			{
				updates = new List<InfoManagerResponseUpdate>();
			}
			PlayerInfo playerInfo = Players.Main.Get(id);
			if (!playerInfo.IsLocalUser)
			{
				Debug.LogWarning("Sending update not about me!");
				return;
			}
			Response.Updates.Add(new InfoManagerResponseUpdate
			{
				PlayerID = id,
				Profile = playerInfo.Profile
			});
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (Response.Updates != null)
			{
				state = Response;
				Response = default(InfoManagerResponseData);
				return true;
			}
			return false;
		}
	}
}
