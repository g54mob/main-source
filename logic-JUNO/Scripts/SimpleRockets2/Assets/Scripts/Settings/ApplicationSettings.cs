using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Steam;
using Jundroo.ModTools;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Settings;
using ModApi.Settings.Core;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class ApplicationSettings : IApplicationSettings
	{
		private const int _CurrentXmlVersion = 5;

		private string _gameStateId;

		private bool _hasUnsavedChanges;

		private List<string> _seenNotifications = new List<string>();

		public Version AppVersionLastRun { get; set; }

		public string ClientToken { get; set; }

		public int CurrentXmlVersion => 5;

		public string DeviceId { get; set; }

		public List<EnabledMod> EnabledMods { get; set; }

		IReadOnlyList<EnabledMod> IApplicationSettings.EnabledMods => EnabledMods;

		public GameSettings Game { get; private set; }

		IGameSettings IApplicationSettings.Game => Game;

		public string GameStateId
		{
			get
			{
				return _gameStateId;
			}
			set
			{
				if (_gameStateId != value)
				{
					_gameStateId = value;
					_hasUnsavedChanges = true;
				}
			}
		}

		public bool HasOpenedControlSettings { get; set; }

		public bool IgnoreModVersionMismatches { get; private set; }

		public IModSettings ModSettings { get; }

		public bool ModSupportEnabled { get; set; }

		public bool NewWorkshopContentInstalled { get; set; }

		public int NumberOfApplicationRuns { get; set; }

		public GameQualitySettings Quality { get; private set; }

		IGameQualitySettings IApplicationSettings.Quality => Quality;

		public IReadOnlyList<string> SeenNotifications => _seenNotifications;

		public bool ShowWhatsNew { get; set; }

		public Dictionary<ulong, uint> SteamWorkshopTimestamps { get; private set; }

		public string UserName { get; set; }

		public UserPreferences UserPrefs { get; }

		public static event Action<ApplicationSettings> Loaded;

		private ApplicationSettings()
		{
			EnabledMods = new List<EnabledMod>();
			ModSettings = new ModSettings();
			SteamWorkshopTimestamps = new Dictionary<ulong, uint>();
			GameStateId = string.Empty;
			ModSupportEnabled = true;
			ShowWhatsNew = true;
			UserPrefs = new UserPreferences();
			_hasUnsavedChanges = false;
		}

		public static ApplicationSettings Load()
		{
			ApplicationSettings applicationSettings = new ApplicationSettings();
			try
			{
				applicationSettings.LoadSettingsFromFile();
			}
			catch (Exception exception)
			{
				UnityEngine.Debug.LogException(exception);
				UnityEngine.Debug.LogError("Failed to load settings");
			}
			try
			{
				applicationSettings.ModSettings.LoadSettings();
			}
			catch (Exception exception2)
			{
				UnityEngine.Debug.LogException(exception2);
				UnityEngine.Debug.LogError("Failed to load mod settings");
			}
			ApplicationSettings.Loaded?.Invoke(applicationSettings);
			return applicationSettings;
		}

		public bool AddNotification(string notification)
		{
			if (!_seenNotifications.Contains(notification))
			{
				_seenNotifications.Add(notification);
				_hasUnsavedChanges = true;
				return true;
			}
			return false;
		}

		public bool HasAnyUnsavedChanges()
		{
			if (!_hasUnsavedChanges && !Game.Categories.HasUnsavedChanges() && !Quality.Categories.HasUnsavedChanges() && !ModSettings.Categories.HasUnsavedChanges())
			{
				return UserPrefs.HasUnsavedChanges;
			}
			return true;
		}

		public void Save()
		{
			GameData.SaveXml(SaveXml(), GameData.SettingsFileRelativePath);
			ModSettings.SaveSettings();
			_hasUnsavedChanges = false;
		}

		public void SaveIfNecessary()
		{
			if (HasAnyUnsavedChanges())
			{
				UnityEngine.Debug.Log("Saving pending changes to settings.");
				Save();
			}
		}

		public XDocument SaveXml()
		{
			XDocument xDocument = new XDocument(new XElement("Settings", new XAttribute("xmlVersion", CurrentXmlVersion), new XAttribute("numberOfApplicationRuns", NumberOfApplicationRuns), new XAttribute("hasOpenedControlSettings", HasOpenedControlSettings), new XAttribute("appVersionLastRun", Assets.Scripts.Game.Version.ToString(4)), new XAttribute("gameStateId", GameStateId), new XElement("User", new XAttribute("x", DeviceId), string.IsNullOrEmpty(UserName) ? null : new XAttribute("userName", UserName), string.IsNullOrEmpty(UserName) ? null : new XAttribute("clientToken", ClientToken)), SaveNotifications(), UserPrefs.Save(new XElement("UserPrefs")), SaveCoreModSettings()));
			Game.SaveToXml(xDocument.Root);
			Quality.SaveToXml(xDocument.Root);
			return xDocument;
		}

		public bool UpdateEnabledMods(List<ModInfo> list)
		{
			if (EnabledMods.Count == list.Count && EnabledMods.All((EnabledMod x) => list.Any((ModInfo y) => x.IsExactMatch(y))))
			{
				return false;
			}
			EnabledMods = new List<EnabledMod>(list.Select((ModInfo x) => new EnabledMod(x.Name, x.Version, x.LastUpdated, x.Path)));
			return true;
		}

		public void UpdateWorkshopTimestamps(IEnumerable<SubscribedWorkshopItemInfo> workshopItems)
		{
			foreach (SubscribedWorkshopItemInfo workshopItem in workshopItems)
			{
				if (SteamWorkshopTimestamps.ContainsKey(workshopItem.Id))
				{
					uint num = SteamWorkshopTimestamps[workshopItem.Id];
					if (workshopItem.Timestamp > num)
					{
						NewWorkshopContentInstalled = true;
					}
				}
				else
				{
					NewWorkshopContentInstalled = true;
				}
			}
			SteamWorkshopTimestamps = workshopItems.ToDictionary((SubscribedWorkshopItemInfo x) => x.Id, (SubscribedWorkshopItemInfo x) => x.Timestamp);
		}

		public void UserLogOut()
		{
			UserName = string.Empty;
			ClientToken = string.Empty;
		}

		private static XDocument LoadOverrideSettings()
		{
			XDocument result = null;
			try
			{
				string text = Path.Combine(new FileInfo(Process.GetCurrentProcess().MainModule.FileName).Directory.FullName, "Settings.xml");
				if (File.Exists(text))
				{
					UnityEngine.Debug.Log("Loading settings override file: " + text);
					result = XDocument.Load(text);
				}
			}
			catch (Exception exception)
			{
				result = null;
				UnityEngine.Debug.LogError("Could not load override settings.");
				UnityEngine.Debug.LogException(exception);
			}
			return result;
		}

		private void LoadCoreModSettings(XElement modsElement)
		{
			ModSupportEnabled = ((bool?)modsElement.Attribute("modSupportEnabled")) ?? true;
			IgnoreModVersionMismatches = (bool?)modsElement.Attribute("ignoreVersionMismatch") == true;
			modsElement.Elements("WorkshopMods").Elements("WorkshopMod").ToList()
				.ForEach(delegate(XElement x)
				{
					SteamWorkshopTimestamps.Add(DataIO.ParseULong((string)x.Attribute("id")), (uint)x.Attribute("timestamp"));
				});
			foreach (XElement item in modsElement.Elements("EnabledMods").Elements("EnabledMod"))
			{
				EnabledMods.Add(EnabledMod.ReadXml(item));
			}
		}

		private void LoadNotifications(XElement notificationsElement)
		{
			foreach (XAttribute item2 in notificationsElement.Elements("Notification").Attributes("name"))
			{
				string item = (string)item2;
				if (!_seenNotifications.Contains(item))
				{
					_seenNotifications.Add(item);
				}
			}
			ShowWhatsNew = notificationsElement.GetBoolAttribute("showWhatsNew", defaultValue: true);
			if (AppVersionLastRun != Assets.Scripts.Game.Version)
			{
				ShowWhatsNew = true;
			}
		}

		private void LoadSettingsFromFile()
		{
			bool flag = Application.isEditor;
			XDocument xDocument = null;
			try
			{
				if (!Device.IsMobileBuild && !Device.IsUnityEditor)
				{
					xDocument = LoadOverrideSettings();
				}
				if (xDocument == null)
				{
					xDocument = GameData.LoadXml(GameData.SettingsFileRelativePath);
				}
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogWarning("Unable to load settings. Restoring default settings. Exception: " + ex.ToString());
				flag = true;
				xDocument = new XDocument(new XElement("Settings", new XAttribute("xmlVersion", CurrentXmlVersion)));
			}
			int intAttribute = xDocument.Root.GetIntAttribute("xmlVersion", 1);
			xDocument = UpgradeXml(xDocument, intAttribute);
			flag = flag || intAttribute != xDocument.Root.GetIntAttribute("xmlVersion", 1);
			XElement xElement = xDocument.Element("Settings");
			if (xElement == null)
			{
				xDocument.Root.ReplaceWith(new XElement("Settings"));
			}
			NumberOfApplicationRuns = xElement.GetIntAttribute("numberOfApplicationRuns");
			HasOpenedControlSettings = xElement.GetBoolAttribute("hasOpenedControlSettings");
			AppVersionLastRun = xElement.GetVersionAttribute("appVersionLastRun", Assets.Scripts.Game.Version);
			_gameStateId = xElement.GetStringAttribute("gameStateId", string.Empty);
			XElement orCreateElement = xElement.GetOrCreateElement("User");
			DeviceId = orCreateElement.GetStringAttribute("x", Guid.NewGuid().ToString());
			UserName = orCreateElement.GetStringAttribute("userName", string.Empty);
			ClientToken = orCreateElement.GetStringAttribute("clientToken", string.Empty);
			Game = GameSettings.CreateFromXml(xElement);
			Quality = GameQualitySettings.CreateFromXml(xElement);
			if (Device.IsIosBuild)
			{
				Quality.Water.Waves.Value = false;
			}
			LoadNotifications(xElement.GetOrCreateElement("Notifications"));
			UserPrefs.Load(xElement.GetOrCreateElement("UserPrefs"));
			LoadCoreModSettings(xElement.GetOrCreateElement("Mods"));
			if (flag)
			{
				Save();
			}
		}

		private XElement SaveCoreModSettings()
		{
			XElement[] array = EnabledMods.Select((EnabledMod x) => x.GenerateXml()).ToArray();
			XElement[] array2 = SteamWorkshopTimestamps.Select((KeyValuePair<ulong, uint> x) => new XElement("WorkshopMod", new XAttribute("id", x.Key), new XAttribute("timestamp", x.Value))).ToArray();
			XName name = "Mods";
			object[] obj = new object[4]
			{
				new XAttribute("modSupportEnabled", ModSupportEnabled),
				new XAttribute("ignoreVersionMismatch", IgnoreModVersionMismatches),
				null,
				null
			};
			XName name2 = "EnabledMods";
			object[] content = ((array.Length == 0) ? null : array);
			obj[2] = new XElement(name2, content);
			XName name3 = "WorkshopMods";
			content = ((array2.Length == 0) ? null : array2);
			obj[3] = new XElement(name3, content);
			return new XElement(name, obj);
		}

		private XElement SaveNotifications()
		{
			return new XElement("Notifications", new XAttribute("showWhatsNew", ShowWhatsNew), (_seenNotifications.Count == 0) ? null : _seenNotifications.Select((string x) => new XElement("Notification", new XAttribute("name", x))));
		}

		private XDocument UpgradeXml(XDocument xml, int xmlVersion)
		{
			xml.Root.SetAttributeValue("xmlVersion", CurrentXmlVersion);
			if (xmlVersion == 1)
			{
				XElement xElement = xml.Root.Element("Quality");
				if (xElement != null)
				{
					xElement.Name = "Quality_Old";
				}
			}
			if (xmlVersion <= 2)
			{
				xml.Root.Elements("Quality").Elements("Display").Attributes("anti-Aliasing")
					.FirstOrDefault()?.Remove();
			}
			if (xmlVersion <= 3)
			{
				(xml.Root.Element("Game")?.Element("General")?.Attribute("useDirectInput"))?.SetValue(false);
			}
			if (xmlVersion <= 4)
			{
				(xml.Root.Element("Game")?.Element("General")?.Attribute("userInterfaceSize"))?.SetValue(1f);
			}
			return xml;
		}
	}
}
