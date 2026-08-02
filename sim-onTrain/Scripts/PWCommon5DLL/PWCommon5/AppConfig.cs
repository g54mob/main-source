using UnityEngine;

namespace PWCommon5
{
	public class AppConfig
	{
		public const string VERSION = "1";

		public readonly string CfgVersion;

		public readonly double LastUpdated;

		public readonly string MinUnity;

		public readonly string Name;

		public readonly Texture2D Logo;

		public readonly string NameSpace;

		public readonly string Folder;

		public readonly string ScriptsFolder;

		public readonly string EditorScriptsFolder;

		public readonly string DocsFolder;

		public readonly string DocsFolderSpaced;

		public readonly string MajorVersion;

		public readonly string MinorVersion;

		public readonly string PatchVersion;

		public readonly string Version;

		public readonly SystemLanguage[] AvailableLanguages;

		public readonly string TutorialsLink;

		public readonly string DiscordLink;

		public readonly string SupportLink;

		public readonly string ASLink;

		public readonly string NewsURLStripped;

		public readonly bool HasWelcome;

		public string NewsURL => NewsURLStripped;

		public AppConfig(string minUnity, string name, SystemLanguage[] availableLanguages)
		{
			CfgVersion = "1";
			LastUpdated = 0.0;
			MinUnity = minUnity;
			Name = name;
			Logo = null;
			NameSpace = name.Replace(" ", "");
			NameSpace = NameSpace.Replace("-", "");
			NameSpace = NameSpace.Replace(".", "");
			Folder = name;
			ScriptsFolder = "Scripts";
			EditorScriptsFolder = ScriptsFolder + "/Editor";
			DocsFolder = "Documentation";
			DocsFolderSpaced = DocsFolder.Replace("/", " / ");
			MajorVersion = "0";
			MinorVersion = "0";
			PatchVersion = "0";
			Version = "0.0.0";
			AvailableLanguages = availableLanguages;
			TutorialsLink = "http://www.procedural-worlds.com/" + NameSpace.ToLower() + "/?section=tutorials";
			DiscordLink = "https://discord.gg/TggjQNN";
			SupportLink = "https://proceduralworlds.freshdesk.com/support/home";
			ASLink = "https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:15277";
			NewsURLStripped = "http://www.procedural-worlds.com/gaiajson.php";
			HasWelcome = true;
			Debug.LogWarning("Created a blank config for " + name);
		}

		public AppConfig(string cfgVersion, double lastUpdated, string minUnity, string name, Texture2D logo, string nameSpace, string folder, string scriptsFolder, string editorScriptsFolder, string docsFolder, string majorVer, string minorVer, string patchVer, SystemLanguage[] availableLang, string tutorialsLink, string discordLink, string supportLink, string asLink, string newsURL, bool hasWelcome)
		{
			CfgVersion = cfgVersion;
			LastUpdated = lastUpdated;
			MinUnity = minUnity;
			Name = name;
			Logo = logo;
			NameSpace = nameSpace;
			Folder = folder;
			ScriptsFolder = scriptsFolder;
			EditorScriptsFolder = editorScriptsFolder;
			DocsFolder = docsFolder;
			DocsFolderSpaced = DocsFolder.Replace("/", " / ");
			MajorVersion = majorVer.ToString();
			MinorVersion = minorVer.ToString();
			PatchVersion = patchVer.ToString();
			Version = MajorVersion + "." + MinorVersion + "." + PatchVersion;
			AvailableLanguages = availableLang;
			TutorialsLink = tutorialsLink;
			DiscordLink = discordLink;
			SupportLink = supportLink;
			ASLink = asLink;
			NewsURLStripped = newsURL;
			HasWelcome = hasWelcome;
		}
	}
}
