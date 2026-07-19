using UnityEngine;

namespace Crosstales.Common.Util
{
	public abstract class BaseConstants
	{
		public const string ASSET_AUTHOR = "crosstales LLC";

		public const string ASSET_AUTHOR_URL = "https://www.crosstales.com";

		public const string ASSET_CT_URL = "https://assetstore.unity.com/lists/crosstales-42213?aid=1011lNGT";

		public const string ASSET_SOCIAL_DISCORD = "https://discord.gg/ZbZ2sh4";

		public const string ASSET_SOCIAL_FACEBOOK = "https://www.facebook.com/crosstales/";

		public const string ASSET_SOCIAL_TWITTER = "https://twitter.com/crosstales";

		public const string ASSET_SOCIAL_YOUTUBE = "https://www.youtube.com/c/Crosstales";

		public const string ASSET_SOCIAL_LINKEDIN = "https://www.linkedin.com/company/crosstales";

		public const string ASSET_3P_PLAYMAKER = "https://assetstore.unity.com/packages/slug/368?aid=1011lNGT";

		public const string ASSET_BWF = "https://assetstore.unity.com/packages/slug/26255?aid=1011lNGT";

		public const string ASSET_DJ = "https://assetstore.unity.com/packages/slug/41993?aid=1011lNGT";

		public const string ASSET_FB = "https://assetstore.unity.com/packages/slug/98713?aid=1011lNGT";

		public const string ASSET_OC = "https://assetstore.unity.com/packages/slug/74688?aid=1011lNGT";

		public const string ASSET_RADIO = "https://assetstore.unity.com/packages/slug/32034?aid=1011lNGT";

		public const string ASSET_RTV = "https://assetstore.unity.com/packages/slug/41068?aid=1011lNGT";

		public const string ASSET_TB = "https://assetstore.unity.com/packages/slug/98711?aid=1011lNGT";

		public const string ASSET_TPB = "https://assetstore.unity.com/packages/slug/98714?aid=1011lNGT";

		public const string ASSET_TPS = "https://assetstore.unity.com/packages/slug/60040?aid=1011lNGT";

		public const string ASSET_TR = "https://assetstore.unity.com/packages/slug/61617?aid=1011lNGT";

		public const int FACTOR_KB = 1024;

		public const int FACTOR_MB = 1048576;

		public const int FACTOR_GB = 1073741824;

		public const float FLOAT_32768 = 32768f;

		public const float FLOAT_TOLERANCE = 0.0001f;

		public const string FORMAT_TWO_DECIMAL_PLACES = "0.00";

		public const string FORMAT_NO_DECIMAL_PLACES = "0";

		public const string FORMAT_PERCENT = "0%";

		public const bool DEFAULT_DEBUG = false;

		public const string PATH_DELIMITER_WINDOWS = "\\";

		public const string PATH_DELIMITER_UNIX = "/";

		public static bool DEV_DEBUG = false;

		public static string TEXT_TOSTRING_START = " {";

		public static string TEXT_TOSTRING_END = "}";

		public static string TEXT_TOSTRING_DELIMITER = "', ";

		public static string TEXT_TOSTRING_DELIMITER_END = "'";

		public static string PREFIX_HTTP = "http://";

		public static string PREFIX_HTTPS = "https://";

		public static int PROCESS_KILL_TIME = 5000;

		public static string CMD_WINDOWS_PATH = "C:\\Windows\\system32\\cmd.exe";

		public static bool SHOW_BWF_BANNER = true;

		public static bool SHOW_DJ_BANNER = true;

		public static bool SHOW_FB_BANNER = true;

		public static bool SHOW_OC_BANNER = true;

		public static bool SHOW_RADIO_BANNER = true;

		public static bool SHOW_RTV_BANNER = true;

		public static bool SHOW_TB_BANNER = true;

		public static bool SHOW_TPB_BANNER = true;

		public static bool SHOW_TPS_BANNER = true;

		public static bool SHOW_TR_BANNER = true;

		public static string PREFIX_FILE
		{
			get
			{
				if ((BaseHelper.isWindowsBasedPlatform || BaseHelper.isWindowsEditor) && !BaseHelper.isMacOSEditor && !BaseHelper.isLinuxEditor)
				{
					return "file:///";
				}
				return "file://";
			}
		}

		public static string APPLICATION_PATH => BaseHelper.ValidatePath(Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/') + 1));
	}
}
