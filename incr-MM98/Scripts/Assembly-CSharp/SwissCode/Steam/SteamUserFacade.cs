using Steamworks;

namespace SwissCode.Steam
{
	public class SteamUserFacade : SteamFacade
	{
		public CSteamID Id()
		{
			if (Initialized)
			{
				return SteamUser.GetSteamID();
			}
			return default(CSteamID);
		}

		public string Name()
		{
			if (Initialized)
			{
				return SteamFriends.GetPersonaName();
			}
			return null;
		}

		public bool AppInstalled(uint appId)
		{
			if (Initialized)
			{
				return SteamApps.BIsAppInstalled(new AppId_t(appId));
			}
			return false;
		}

		public bool DlcInstalled(uint dlcId)
		{
			if (Initialized)
			{
				return SteamApps.BIsDlcInstalled(new AppId_t(dlcId));
			}
			return false;
		}
	}
}
