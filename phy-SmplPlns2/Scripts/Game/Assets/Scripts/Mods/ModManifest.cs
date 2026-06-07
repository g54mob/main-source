using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.SocialPlatforms.Steam;

namespace Assets.Scripts.Mods
{
	public class ModManifest
	{
		private XElement _mod;

		private XDocument _root;

		private XElement _steam;

		public IEnumerable<string> AssemblyPaths => from x in _mod.Elements("Assemblies").Elements("Assembly")
			select (string)x.Attribute("path");

		public string Author => (string)_mod.Attribute("author");

		public Version BuildGameVersion
		{
			get
			{
				XAttribute xAttribute = _mod.Attribute("buildGameVersion");
				if (xAttribute != null)
				{
					return new Version((string)xAttribute);
				}
				return null;
			}
		}

		public Guid? BuildID => (Guid?)_root.Root.Attribute("buildID");

		public string BuildOperatingSystem => (string)_mod.Attribute("buildOperatingSystem");

		public string BuildUnityVersion => (string)_mod.Attribute("buildUnityVersion");

		public string Description => (string)_mod.Attribute("description");

		public bool HasSteamInfo { get; private set; }

		public DateTime LastUpdated
		{
			get
			{
				DateTime dateTime = (DateTime)_mod.Attribute("lastUpdated");
				return dateTime.AddTicks(-(dateTime.Ticks % 10000000));
			}
		}

		public int LoadPriority => ((int?)_mod.Attribute("loadPriority")) ?? 1000;

		public Dictionary<string, string> MaterialShaderMap => _mod.Elements("MaterialShaderMap").Elements("Material").ToDictionary((XElement x) => (string)x.Attribute("name"), (XElement x) => (string)x.Attribute("shader"));

		public string Name => (string)_mod.Attribute("name");

		public IEnumerable<string> OtherAssetPaths => from x in _mod.Elements("OtherAssets").Elements("Asset")
			select (string)x.Attribute("path");

		public IEnumerable<string> PrefabPaths => from x in _mod.Elements("Prefabs").Elements("Prefab")
			select (string)x.Attribute("path");

		public string SteamDescription => (string)_steam.Element("description");

		public string SteamLanguage => (string)_steam.Attribute("language");

		public string SteamPreviewPath => (string)_steam.Attribute("previewPath");

		public List<string> SteamTags
		{
			get
			{
				List<string> list = new List<string>();
				string[] array = (((string)_steam.Attribute("tags")) ?? string.Empty).Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i].Trim();
					if (!string.IsNullOrEmpty(text) && !list.Contains(text))
					{
						list.Add(text);
					}
				}
				return list;
			}
		}

		public string SteamTitle => (string)_steam.Attribute("title");

		public SteamVisibility SteamVisibility
		{
			get
			{
				string text = (string)_steam.Attribute("visibility");
				if (text != null)
				{
					return (SteamVisibility)Enum.Parse(typeof(SteamVisibility), text);
				}
				return SteamVisibility.Private;
			}
		}

		public Version Version => new Version((int)_mod.Attribute("versionMajor"), (int)_mod.Attribute("versionMinor"));

		public ModManifest(XDocument xml)
		{
			_root = xml;
			_mod = _root.Elements("ModManifest").Elements("Mod").Single();
			_steam = _mod.Element("Steam");
			HasSteamInfo = _steam != null;
			if (!HasSteamInfo)
			{
				_steam = new XElement("Steam");
			}
		}

		public Version GetApiVersion()
		{
			return new Version((string)_mod.Attribute("apiVersion"));
		}

		public XElement GetElement(string elementName)
		{
			return _mod.Element(elementName);
		}
	}
}
