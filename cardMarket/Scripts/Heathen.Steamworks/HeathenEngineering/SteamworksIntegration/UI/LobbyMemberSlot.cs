using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/programming-tools/lobbymemberslot")]
	public abstract class LobbyMemberSlot : MonoBehaviour
	{
		public UnityEvent InviteUserRequest;

		public UnityEvent RemoveUserRequest;

		public abstract bool Interactable { get; set; }

		public abstract void SetUser(LobbyMemberData user);

		public abstract LobbyMemberData GetUser();

		public abstract void ClearUser();
	}
}
