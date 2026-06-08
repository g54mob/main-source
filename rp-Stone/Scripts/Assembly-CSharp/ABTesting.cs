using System.Collections.Generic;

public class ABTesting
{
	public static string CONFIG_RED_VS_BLUE = "config_red_vs_blue";

	public static string CONFIG_ITEM_DROP_SIMPLER = "config_item_drop_simpler";

	public static string CONFIG_FISSURE_INFO_DIALOG = "config_fissure_info_dialog";

	public static string CONFIG_APPSFLYER_ANDROID = "config_appsflyer_android";

	public static string CONFIG_APPSFLYER_IOS = "config_appsflyer_ios";

	public static Dictionary<string, object> GetDefaults()
	{
		return new Dictionary<string, object>
		{
			{ CONFIG_RED_VS_BLUE, "red" },
			{ CONFIG_ITEM_DROP_SIMPLER, "true" },
			{ CONFIG_FISSURE_INFO_DIALOG, "true" },
			{ CONFIG_APPSFLYER_ANDROID, "false" },
			{ CONFIG_APPSFLYER_IOS, "false" }
		};
	}

	public static bool AppsFlyerAndroid()
	{
		return false;
	}

	public static bool AppsFlyerIOS()
	{
		return false;
	}

	public static bool FissureInfoDialog()
	{
		return true;
	}

	public static string RedVsBlue()
	{
		return "red";
	}

	public static bool ItemDropSimpler()
	{
		return true;
	}
}
