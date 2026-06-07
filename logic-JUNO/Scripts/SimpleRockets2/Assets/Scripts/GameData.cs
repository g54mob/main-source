using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts
{
	internal static class GameData
	{
		public static string ModSettingsFileRelativePath => "ModSettings.xml";

		public static string ModsPath => Path.Combine(PersistentDataPath, "Mods");

		public static string PersistentDataPath => Application.persistentDataPath;

		public static string SettingsFileRelativePath => "Settings.xml";

		public static XDocument LoadXml(string relativePath, bool throwFileNotFoundException = true)
		{
			string text = Path.Combine(PersistentDataPath, relativePath);
			if (!throwFileNotFoundException && !File.Exists(text))
			{
				return null;
			}
			return XDocument.Load(text);
		}

		public static void SaveXml(XDocument xmlDocument, string relativePath)
		{
			string fileName = Path.Combine(PersistentDataPath, relativePath);
			xmlDocument.Save(fileName);
		}
	}
}
