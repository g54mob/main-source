using System;
using KitchenData;
using Platforms;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class PlayerRowElement : Element
	{
		[Header("References")]
		[SerializeField]
		private TextMeshPro PlayerName;

		[SerializeField]
		private ButtonElement Kick;

		[SerializeField]
		private ButtonElement RemovePlayer;

		[SerializeField]
		private ButtonElement OpenPlatformProfile;

		private PlayerInfo PlayerInfo;

		public override bool IsSelectable => false;

		public override Bounds BoundingBox => new Bounds
		{
			center = ((this != null) ? base.transform.localPosition : Vector3.zero),
			size = new Vector3(6f, 0.6f, 0.1f)
		};

		public event Action OnKick = delegate
		{
		};

		public event Action OnRemovePlayer = delegate
		{
		};

		public override void Initialise()
		{
			base.Initialise();
			Kick.Initialise();
			RemovePlayer.Initialise();
			OpenPlatformProfile.Initialise();
			Kick.OnActivate += delegate
			{
				this.OnKick();
			};
			RemovePlayer.OnActivate += delegate
			{
				this.OnRemovePlayer();
			};
			OpenPlatformProfile.OnActivate += OpenProfileCard;
			Kick.SetLabel(GameData.Main.GlobalLocalisation["MENU_KICK_PLAYER"]);
			RemovePlayer.SetLabel(GameData.Main.GlobalLocalisation["MENU_REMOVE_INPUT"]);
		}

		public void AddSubmodules(ModuleSet set)
		{
			set.AddModule(OpenPlatformProfile, base.Position + OpenPlatformProfile.Position);
			set.AddModule(Kick, base.Position + Kick.Position);
			set.AddModule(RemovePlayer, base.Position + RemovePlayer.Position);
		}

		public void SetPeer(string username)
		{
			Kick.SetSelectable(Session.NetworkedPlayState.IsOwnGame());
			RemovePlayer.SetSelectable(selectable: false);
			OpenPlatformProfile.SetLabel(username);
			OpenPlatformProfile.SetSelectable(PlatformSettings.SupportsUsernameLookup, keep_full_alpha: true);
		}

		public void SetPlayer(string username, PlayerInfo player)
		{
			PlayerInfo = player;
			Kick.SetSelectable(!player.IsLocalUser && Session.NetworkedPlayState.IsOwnGame());
			RemovePlayer.SetSelectable(!player.IsLocalUser && Session.NetworkedPlayState.IsOwnGame());
			OpenPlatformProfile.SetLabel(player.PrimaryName);
			OpenPlatformProfile.SetColour(player.Profile.Colour);
			OpenPlatformProfile.SetSelectable(PlatformSettings.SupportsUsernameLookup, keep_full_alpha: true);
		}

		public void OpenProfileCard()
		{
		}
	}
}
