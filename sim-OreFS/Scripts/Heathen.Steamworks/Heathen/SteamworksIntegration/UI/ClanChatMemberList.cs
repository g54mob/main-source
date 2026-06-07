using System.Collections.Generic;
using Heathen.SteamworksIntegration.API;
using UnityEngine;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/clan-chat-member-list")]
	public class ClanChatMemberList : MonoBehaviour
	{
		[SerializeField]
		private ulong clanId;

		[SerializeField]
		private Transform content;

		[SerializeField]
		private GameObject template;

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

		private void Start()
		{
			if (clanId != 0)
			{
				Apply(clanId);
			}
		}

		public void Apply(ClanData clan)
		{
			clanId = clan;
			Refresh();
		}

		public void Refresh()
		{
			foreach (GameObject item in content)
			{
				Object.Destroy(item);
			}
			if (clanId == 0 || !Clan.IsValid)
			{
				return;
			}
			List<UserData> list = new List<UserData>();
			list.AddRange(Clans.Client.GetChatMembers(Clan));
			list.Sort((UserData a, UserData b) => a.Nickname.CompareTo(b.Nickname));
			foreach (UserData item2 in list)
			{
				Object.Instantiate(template, content).GetComponent<IUserProfile>().Apply(item2);
			}
		}
	}
}
