using Heathen.SteamworksIntegration.API;
using UnityEngine;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/chat-auto-join")]
	[RequireComponent(typeof(ClanChatDirector))]
	public class ChatAutoJoin : MonoBehaviour
	{
		[SerializeField]
		private ulong clanId;

		private void Start()
		{
			if (App.Initialized)
			{
				GetComponent<ClanChatDirector>().Join(clanId);
			}
			else
			{
				App.evtSteamInitialized.AddListener(DelayUpdate);
			}
		}

		private void DelayUpdate()
		{
			GetComponent<ClanChatDirector>().Join(clanId);
			App.evtSteamInitialized.RemoveListener(DelayUpdate);
		}
	}
}
