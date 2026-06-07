using UnityEngine;
using UnityEngine.UI;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/programming-tools/lobbymemberslot")]
	public class BasicLobbyMemberSlot : LobbyMemberSlot
	{
		[Tooltip("The user's avatar")]
		public SetUserAvatar avatar;

		[Tooltip("A button that can be pressed to start the invite process")]
		public Button inviteButton;

		[Tooltip("A button that can be pressed to ask the user in this slot to leave")]
		public Button removeButton;

		[Tooltip("An icon to display if this user is the owner of the lobby")]
		public GameObject ownerPip;

		[Tooltip("An icon to display if the user in this slot has indicated they are ready")]
		public GameObject readyPip;

		[Tooltip("An icon to display if the user not yet indicated they are ready to play")]
		public GameObject waitingPip;

		private LobbyMemberData member;

		public override bool Interactable
		{
			get
			{
				if (inviteButton != null)
				{
					return inviteButton.interactable;
				}
				if (removeButton != null)
				{
					return removeButton.interactable;
				}
				return false;
			}
			set
			{
				if (inviteButton != null)
				{
					inviteButton.interactable = value;
				}
				if (removeButton != null)
				{
					removeButton.interactable = value;
				}
			}
		}

		public override void ClearUser()
		{
			member = default(LobbyMemberData);
			if (avatar != null)
			{
				avatar.gameObject.SetActive(value: false);
			}
			if (inviteButton != null)
			{
				inviteButton.gameObject.SetActive(value: true);
			}
			if (removeButton != null)
			{
				removeButton.gameObject.SetActive(value: false);
			}
			if (ownerPip != null)
			{
				ownerPip.SetActive(value: false);
			}
			if (readyPip != null)
			{
				readyPip.SetActive(value: false);
			}
			if (waitingPip != null)
			{
				waitingPip.SetActive(value: false);
			}
		}

		public override LobbyMemberData GetUser()
		{
			return member;
		}

		public override void SetUser(LobbyMemberData member)
		{
			this.member = member;
			if (avatar != null)
			{
				avatar.UserData = member.user;
				avatar.gameObject.SetActive(value: true);
			}
			if (inviteButton != null)
			{
				inviteButton.gameObject.SetActive(value: false);
			}
			if (removeButton != null)
			{
				removeButton.gameObject.SetActive(value: true);
			}
			if (ownerPip != null)
			{
				ownerPip.SetActive(member.IsOwner);
			}
			if (readyPip != null)
			{
				readyPip.SetActive(member.IsReady);
			}
			if (waitingPip != null)
			{
				waitingPip.SetActive(!member.IsReady);
			}
		}
	}
}
