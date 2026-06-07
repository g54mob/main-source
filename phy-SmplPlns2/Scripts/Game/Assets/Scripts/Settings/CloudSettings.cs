using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class CloudSettings
	{
		private string _filePath;

		private bool _hasUnsavedChanges;

		public ActivitySettings Activities { get; }

		public CraftSettings Crafts { get; }

		public LocationSettings Locations { get; }

		private CloudSettings()
		{
			Activities = new ActivitySettings();
			Crafts = new CraftSettings();
			Locations = new LocationSettings();
		}

		public static CloudSettings Create(string filePath)
		{
			CloudSettings cloudSettings = new CloudSettings();
			cloudSettings.Initialize(filePath);
			return cloudSettings;
		}

		public bool HasAnyUnsavedChanges()
		{
			if (!_hasUnsavedChanges && !Activities.HasUnsavedChanges && !Crafts.HasUnsavedChanges)
			{
				return Locations.HasUnsavedChanges;
			}
			return true;
		}

		public void Reload()
		{
			LoadSettingsFromXml(LoadXml(logFileNotFound: true, logErrors: true)?.Root);
		}

		public void Save()
		{
			new XDocument(new XElement("CloudSettings", Activities.SaveXml(new XElement("Activities")), Crafts.SaveXml(new XElement("Crafts")), Locations.SaveXml(new XElement("Locations")))).Save(_filePath);
			_hasUnsavedChanges = false;
		}

		public void SaveIfNecessary()
		{
			if (HasAnyUnsavedChanges())
			{
				Save();
			}
		}

		private void Initialize(string filePath)
		{
			_filePath = filePath;
			XDocument xDocument = LoadXml(logFileNotFound: false, logErrors: true);
			LoadSettingsFromXml(xDocument?.Root);
			if (xDocument == null)
			{
				Save();
			}
		}

		private void LoadSettingsFromXml(XElement xml)
		{
			Activities.LoadSettingsFromXml(xml?.Element("Activities"));
			Crafts.LoadSettingsFromXml(xml?.Element("Crafts"));
			Locations.LoadSettingsFromXml(xml?.Element("Locations"));
			_hasUnsavedChanges = false;
		}

		private XDocument LoadXml(bool logFileNotFound, bool logErrors)
		{
			XDocument result = null;
			if (File.Exists(_filePath))
			{
				try
				{
					result = XDocument.Load(_filePath);
				}
				catch (Exception exception)
				{
					if (logErrors)
					{
						Debug.LogException(exception);
						Debug.LogError("An error occurred trying to load the cloud settings file: " + _filePath);
					}
				}
			}
			else if (logFileNotFound)
			{
				Debug.LogError("Unable to load the cloud settings file because it could not be found: " + _filePath);
			}
			return result;
		}
	}
}
