using System;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.State
{
	public static class FlightStateXmlVersionUpdater
	{
		private static Action<XElement>[] _upgradeActions = new Action<XElement>[3]
		{
			delegate
			{
			},
			UpgradeToVersion2,
			UpgradeToVersion3
		};

		public static void Upgrade(XElement xml, int version)
		{
			XAttribute xAttribute = xml.Attribute("xmlVersion");
			if (xAttribute != null)
			{
				xAttribute.Value = 3.ToString();
			}
			if (_upgradeActions.Length != 3)
			{
				Debug.LogError("WARNING: Missing flight state upgrade action(s) used when upgrading from an older flight state XML version.");
				Array.Resize(ref _upgradeActions, 3);
				for (int i = 0; i < 3; i++)
				{
					if (_upgradeActions[i] == null)
					{
						_upgradeActions[i] = delegate
						{
						};
					}
				}
			}
			for (int num = version; num < 3; num++)
			{
				_upgradeActions[num](xml);
			}
			Debug.LogFormat("Upgraded FlightState from version {0} to {1}.", version, 3);
		}

		public static string UpgradeOriginalPlanetName(string planetName)
		{
			return planetName switch
			{
				"Smearth" => "Droo", 
				"Smoon" => "Luna", 
				"Smars" => "Cylero", 
				"Smupiter" => "Tydos", 
				"Uranus" => "Urados", 
				_ => planetName, 
			};
		}

		private static void UpgradeToVersion2(XElement xml)
		{
			foreach (XElement item in xml.Elements("Nodes").Elements("Planet"))
			{
				string value = item.Attribute("name").Value;
				item.Attribute("name").SetValue(UpgradeOriginalPlanetName(value));
			}
			foreach (XElement item2 in xml.Elements("Nodes").Elements("Craft"))
			{
				string value2 = item2.Attribute("parent").Value;
				item2.Attribute("parent").SetValue(UpgradeOriginalPlanetName(value2));
			}
		}

		private static void UpgradeToVersion3(XElement xml)
		{
			string text = (string)xml.Element("PlanetarySystem")?.Attribute("hash");
			string text2 = (string)xml.Attribute("solarSystemId");
			if (!(text == "8ae8de91-31dc-159a-b75f-e9054f101495") && !(text == "8db287f0-a818-7290-16d8-ff6529be6018") && !(text2 == "__default__"))
			{
				return;
			}
			foreach (XElement item in xml.Elements("Nodes").Elements("Planet"))
			{
				if (item.Attribute("name").Value == "Sun")
				{
					item.Attribute("name").SetValue("Juno");
				}
			}
			foreach (XElement item2 in xml.Elements("Nodes").Elements("Craft"))
			{
				if (item2.Attribute("parent").Value == "Sun")
				{
					item2.Attribute("parent").SetValue("Juno");
				}
			}
		}
	}
}
