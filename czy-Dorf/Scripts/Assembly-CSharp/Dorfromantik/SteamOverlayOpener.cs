using Steamworks;
using UnityEngine;

namespace Dorfromantik
{
	public class SteamOverlayOpener : MonoBehaviour
	{
		public static void OpenURLInSteamOverlay(string url)
		{
			if (SteamManager.Initialized)
			{
				SteamFriends.ActivateGameOverlayToWebPage(url);
			}
		}
	}
}
