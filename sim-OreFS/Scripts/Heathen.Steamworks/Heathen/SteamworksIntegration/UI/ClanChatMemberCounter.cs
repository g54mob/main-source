using Heathen.SteamworksIntegration.API;
using TMPro;
using UnityEngine;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/clan-chat-member-counter")]
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ClanChatMemberCounter : MonoBehaviour
	{
		[SerializeField]
		private ulong clanId;

		[SerializeField]
		internal string prefix;

		[SerializeField]
		internal string suffix;

		private TextMeshProUGUI label;

		public ClanData Clan
		{
			get
			{
				return clanId;
			}
			set
			{
				Apply(value);
			}
		}

		private void OnEnable()
		{
			label = GetComponent<TextMeshProUGUI>();
			Clans.Client.EventGameConnectedChatJoin.AddListener(HandleJoin);
			Clans.Client.EventGameConnectedChatLeave.AddListener(HandleLeve);
		}

		private void Start()
		{
			if (App.Initialized)
			{
				if (clanId != 0)
				{
					Refresh();
				}
			}
			else
			{
				App.evtSteamInitialized.AddListener(DelayUpdate);
			}
		}

		private void DelayUpdate()
		{
			if (clanId != 0)
			{
				Refresh();
			}
			App.evtSteamInitialized.RemoveListener(DelayUpdate);
		}

		private void HandleLeve(UserLeaveData data)
		{
			if (data.room.clan == clanId)
			{
				Refresh();
			}
		}

		private void HandleJoin(ChatRoom room, UserData user)
		{
			if (room.clan == clanId)
			{
				Refresh();
			}
		}

		public void Apply(ClanData clan)
		{
			clanId = clan;
			Refresh();
		}

		public void Refresh()
		{
			if (clanId != 0)
			{
				label.text = prefix + Clans.Client.GetChatMemberCount(Clan) + suffix;
			}
		}
	}
}
