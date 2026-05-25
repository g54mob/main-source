using UnityEngine;

public static class Installation
{
	public enum InstallationType
	{
		ItchDemo = 0,
		ItchFull = 1,
		SteamDemo = 2,
		SteamFull = 3,
		ArmorGame = 4,
		NewGrounds = 5,
		Kongregate = 6,
		PokiDemo = 7,
		IndieDbDemo = 8
	}

	public static InstallationType CurrentInstallation = InstallationType.SteamDemo;

	public static string GetVersionString()
	{
		string text = "abcdefghijklmnopqrstuvwxyz";
		return Application.version.ToString() + text[(int)CurrentInstallation];
	}

	public static bool IsDemo()
	{
		if (CurrentInstallation == InstallationType.ItchDemo)
		{
			return true;
		}
		if (CurrentInstallation == InstallationType.SteamDemo)
		{
			return true;
		}
		if (CurrentInstallation == InstallationType.ArmorGame)
		{
			return true;
		}
		if (CurrentInstallation == InstallationType.NewGrounds)
		{
			return true;
		}
		if (CurrentInstallation == InstallationType.Kongregate)
		{
			return true;
		}
		if (CurrentInstallation == InstallationType.PokiDemo)
		{
			return true;
		}
		if (CurrentInstallation == InstallationType.IndieDbDemo)
		{
			return true;
		}
		return false;
	}

	public static bool IsWeb()
	{
		if (CurrentInstallation == InstallationType.SteamDemo)
		{
			return false;
		}
		if (CurrentInstallation == InstallationType.SteamFull)
		{
			return false;
		}
		if (CurrentInstallation == InstallationType.IndieDbDemo)
		{
			return false;
		}
		return true;
	}

	public static bool SkipMainMenu()
	{
		if (CurrentInstallation == InstallationType.PokiDemo)
		{
			return true;
		}
		return false;
	}

	public static bool CanSeeSteamLogo()
	{
		return IsDemo();
	}

	public static bool CanSeeItchLogo()
	{
		if (CurrentInstallation == InstallationType.ItchDemo)
		{
			return true;
		}
		if (CurrentInstallation == InstallationType.IndieDbDemo)
		{
			return true;
		}
		return false;
	}

	public static bool CanGenerateEvilGarbage()
	{
		return !IsDemo();
	}

	public static bool CanGenerateBook()
	{
		return !IsDemo();
	}

	public static int GetDemoMaxPrestige()
	{
		if (CurrentInstallation == InstallationType.SteamDemo)
		{
			return 2;
		}
		return 3;
	}

	public static bool IsSteamConnected()
	{
		if (CurrentInstallation == InstallationType.SteamDemo || CurrentInstallation == InstallationType.SteamFull)
		{
			return true;
		}
		return false;
	}

	public static bool IsNewgroundsConnected()
	{
		if (CurrentInstallation == InstallationType.NewGrounds)
		{
			return true;
		}
		return false;
	}

	public static bool IsKongregateConnected()
	{
		if (CurrentInstallation == InstallationType.Kongregate)
		{
			return true;
		}
		return false;
	}
}
