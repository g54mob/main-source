using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Mods;
using Jundroo.Common.Settings;
using Jundroo.SocialPlatforms.Steam;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class ApplicationSettings
	{
		private const int _CurrentXmlVersion = 1;

		private static XDocument _resourceBundleSettingsDoc;

		private string _filePath;

		private string _gameStateId;

		private bool _hasUnsavedChanges;

		private List<string> _seenNotifications = new List<string>();

		public Version AppVersionLastRun { get; set; }

		public string ClientToken { get; set; }

		public int CurrentXmlVersion => 1;

		public bool DevConsoleTapEnabled { get; set; }

		public string DeviceId { get; set; }

		public List<EnabledMod> EnabledMods { get; set; }

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

		public bool IsLoggedIn
		{
			get
			{
				if (!string.IsNullOrWhiteSpace(UserName))
				{
					return !string.IsNullOrWhiteSpace(ClientToken);
				}
				return false;
			}
		}

		public bool ModSupportEnabled { get; set; }

		public bool NewWorkshopContentInstalled { get; set; }

		public int NumberOfApplicationRuns { get; set; }

		public IReadOnlyList<string> SeenNotifications => _seenNotifications;

		public bool ShowWhatsNew { get; set; }

		public Dictionary<ulong, uint> SteamWorkshopTimestamps { get; private set; }

		public bool UserIsCurator { get; set; }

		public string UserName { get; set; }

		public UserPreferences UserPrefs { get; }

		public static event Action<ApplicationSettings> Loaded;

		private ApplicationSettings(string filePath)
		{
			_filePath = filePath;
			EnabledMods = new List<EnabledMod>();
			SteamWorkshopTimestamps = new Dictionary<ulong, uint>();
			GameStateId = string.Empty;
			ModSupportEnabled = true;
			ShowWhatsNew = true;
			UserPrefs = new UserPreferences();
			_hasUnsavedChanges = false;
		}

		public static ApplicationSettings Create(string filePath)
		{
			ApplicationSettings applicationSettings = new ApplicationSettings(filePath);
			try
			{
				applicationSettings.LoadSettingsFromFile();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Failed to load settings");
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
			if (!_hasUnsavedChanges)
			{
				return UserPrefs.HasUnsavedChanges;
			}
			return true;
		}

		public void Save()
		{
			SaveXml().Save(_filePath);
			_hasUnsavedChanges = false;
		}

		public void SaveIfNecessary()
		{
			if (HasAnyUnsavedChanges())
			{
				Debug.Log("Saving pending changes to settings.");
				Save();
			}
		}

		public XDocument SaveXml()
		{
			return new XDocument(new XElement("Settings", new XAttribute("xmlVersion", CurrentXmlVersion), new XAttribute("numberOfApplicationRuns", NumberOfApplicationRuns), new XAttribute("hasOpenedControlSettings", HasOpenedControlSettings), new XAttribute("appVersionLastRun", Game.Version.ToString(4)), new XAttribute("gameStateId", GameStateId), (!DevConsoleTapEnabled) ? null : new XAttribute("devConsoleTapEnabled", DevConsoleTapEnabled), new XElement("User", new XAttribute("x", DeviceId), string.IsNullOrEmpty(UserName) ? null : new XAttribute("userName", UserName), string.IsNullOrEmpty(UserName) ? null : new XAttribute("clientToken", ClientToken), (!UserIsCurator) ? null : new XAttribute("userIsCurator", UserIsCurator)), SaveNotifications(), UserPrefs.Save(new XElement("UserPrefs")), SaveCoreModSettings()));
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
			if (AppVersionLastRun != Game.Version)
			{
				ShowWhatsNew = true;
			}
		}

		private void LoadSettingsFromFile()
		{
			bool flag = Application.isEditor;
			XDocument xDocument = null;
			if (File.Exists(_filePath))
			{
				try
				{
					xDocument = XDocument.Load(_filePath);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("Unable to load the application settings file: " + _filePath);
				}
			}
			if (xDocument == null)
			{
				Debug.Log("Creating default applications settings: " + _filePath);
				xDocument = new XDocument(new XElement("Settings", new XAttribute("xmlVersion", CurrentXmlVersion)));
				flag = true;
			}
			int intAttribute = xDocument.Root.GetIntAttribute("xmlVersion", 1);
			if (intAttribute < CurrentXmlVersion)
			{
				xDocument = UpgradeXml(xDocument, intAttribute);
				xDocument.Root.SetAttributeValue("xmlVersion", CurrentXmlVersion);
				flag = true;
			}
			XElement xElement = xDocument.Element("Settings");
			if (xElement == null)
			{
				xDocument.Root.ReplaceWith(new XElement("Settings"));
			}
			NumberOfApplicationRuns = xElement.GetIntAttribute("numberOfApplicationRuns");
			HasOpenedControlSettings = xElement.GetBoolAttribute("hasOpenedControlSettings");
			AppVersionLastRun = xElement.GetVersionAttribute("appVersionLastRun", Game.Version);
			_gameStateId = xElement.GetStringAttribute("gameStateId", string.Empty);
			DevConsoleTapEnabled = xElement.GetBoolAttribute("devConsoleTapEnabled");
			XElement orCreateElement = xElement.GetOrCreateElement("User");
			DeviceId = orCreateElement.GetStringAttribute("x", Guid.NewGuid().ToString());
			UserName = orCreateElement.GetStringAttribute("userName", string.Empty);
			ClientToken = orCreateElement.GetStringAttribute("clientToken", string.Empty);
			UserIsCurator = orCreateElement.GetBoolAttribute("userIsCurator");
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
			return xml;
		}
	}
}
