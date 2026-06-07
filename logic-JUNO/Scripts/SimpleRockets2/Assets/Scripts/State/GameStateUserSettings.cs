using System;
using System.IO;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.State
{
	public class GameStateUserSettings
	{
		private string _filePath;

		public Version PlanetarySystemDeclinedUpgradeVersion { get; set; }

		public GameStateUserSettings(string filePath)
		{
			_filePath = filePath;
			if (File.Exists(filePath))
			{
				try
				{
					XDocument xml = XDocument.Load(filePath);
					LoadSettingsFromXml(xml);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void Save()
		{
			XDocument xDocument = new XDocument(new XElement("GameStateUserSettings"));
			if (PlanetarySystemDeclinedUpgradeVersion != null)
			{
				xDocument.Root.SetAttributeValue("planetarySystemDeclinedUpgradeVersion", PlanetarySystemDeclinedUpgradeVersion.ToString());
			}
			xDocument.Save(_filePath);
		}

		private void LoadSettingsFromXml(XDocument xml)
		{
			PlanetarySystemDeclinedUpgradeVersion = xml.Root.GetVersionAttribute("planetarySystemDeclinedUpgradeVersion");
		}
	}
}
