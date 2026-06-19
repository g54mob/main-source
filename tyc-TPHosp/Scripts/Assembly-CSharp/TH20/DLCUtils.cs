namespace TH20
{
	public static class DLCUtils
	{
		public static bool IsDLCOwned(DLCItemDefinition dlcItem)
		{
			if (dlcItem == null)
			{
				return true;
			}
			if (!OSManager.IsInitialised())
			{
				return false;
			}
			return OSManager.IsDlcOwned(dlcItem.AppID);
		}

		public static bool IsDLCInstalled(DLCItemDefinition dlcItem)
		{
			if (dlcItem == null)
			{
				return true;
			}
			if (!OSManager.IsInitialised())
			{
				return false;
			}
			return OSManager.IsDlcInstalled(dlcItem.AppID);
		}

		public static bool IsDLCInstalled(uint appID)
		{
			if (!OSManager.IsInitialised())
			{
				return false;
			}
			return OSManager.IsDlcInstalled(appID);
		}
	}
}
