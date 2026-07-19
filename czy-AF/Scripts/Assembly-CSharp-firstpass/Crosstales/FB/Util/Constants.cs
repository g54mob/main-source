using System;
using Crosstales.Common.Util;

namespace Crosstales.FB.Util
{
	public abstract class Constants : BaseConstants
	{
		public const string ASSET_NAME = "File Browser PRO";

		public const string ASSET_NAME_SHORT = "FB PRO";

		public const string ASSET_VERSION = "2020.2.5";

		public const int ASSET_BUILD = 20200524;

		public static readonly DateTime ASSET_CREATED = new DateTime(2017, 8, 1);

		public static readonly DateTime ASSET_CHANGED = new DateTime(2020, 5, 24);

		public const string ASSET_PRO_URL = "https://assetstore.unity.com/packages/slug/98713?aid=1011lNGT";

		public const string ASSET_UPDATE_CHECK_URL = "https://www.crosstales.com/media/assets/fb_versions.txt";

		public const string ASSET_CONTACT = "fb@crosstales.com";

		public const string ASSET_MANUAL_URL = "https://www.crosstales.com/media/data/assets/FileBrowser/FileBrowser-doc.pdf";

		public const string ASSET_API_URL = "https://www.crosstales.com/media/data/assets/FileBrowser/api/";

		public const string ASSET_FORUM_URL = "https://forum.unity.com/threads/file-browser-native-file-browser-for-standalone.510403/";

		public const string ASSET_WEB_URL = "https://www.crosstales.com/en/portfolio/FileBrowser/";

		public const string KEY_PREFIX = "FILEBROWSER_CFG_";

		public const string KEY_ASSET_PATH = "FILEBROWSER_CFG_ASSET_PATH";

		public const string KEY_DEBUG = "FILEBROWSER_CFG_DEBUG";

		public const string KEY_NATIVE_WINDOWS = "FILEBROWSER_CFG_NATIVE_WINDOWS";

		public const bool DEFAULT_NATIVE_WINDOWS = false;

		public static string TEXT_OPEN_FILE = "Open file";

		public static string TEXT_OPEN_FILES = "Open files";

		public static string TEXT_OPEN_FOLDER = "Open folder";

		public static string TEXT_OPEN_FOLDERS = "Open folders";

		public static string TEXT_SAVE_FILE = "Save file";

		public static string TEXT_ALL_FILES = "All files";

		public static string TEXT_SAVE_FILE_NAME = "MySaveFile";
	}
}
