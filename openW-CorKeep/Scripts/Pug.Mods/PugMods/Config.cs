using System.Collections.Generic;
using UnityEngine;

namespace PugMods
{
	public static class Config
	{
		public static List<string> ConfFolders = new List<string> { Application.streamingAssetsPath + "/Conf" };

		public static List<string> LocalizationFolders = new List<string> { Application.streamingAssetsPath + "/Localization" };

		public static bool ExtraLog = false;
	}
}
