using Steamworks;
using UnityEngine;

public class WishlistButton : MonoBehaviour
{
	[SerializeField]
	private string windowsLink = "steam://store/2666510";

	[SerializeField]
	private string macosLink = "https://store.steampowered.com/app/2666510?utm_source=ingame&utm_content=wishlistbutton";

	public void ClickedOnButton()
	{
		Application.OpenURL(windowsLink);
	}

	private void CheckHaikuTheRobot()
	{
		if (SteamManager.Initialized)
		{
			SteamApps.BIsSubscribedApp(new AppId_t(1231880u));
		}
	}
}
