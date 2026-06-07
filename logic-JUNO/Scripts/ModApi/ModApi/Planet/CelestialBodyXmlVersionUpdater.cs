using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Planet
{
	internal static class CelestialBodyXmlVersionUpdater
	{
		private static Action<XElement>[] _upgradeActions = new Action<XElement>[2] { UpgradeToVersion1, UpgradeToVersion2 };

		public static void Upgrade(XElement xml, int version)
		{
			xml.SetAttributeValue("xmlVersion", 2);
			if (_upgradeActions.Length != 2)
			{
				Debug.LogError("WARNING: Missing upgrade action(s) used when upgrading from an older celestial body XML version.");
				Array.Resize(ref _upgradeActions, 2);
				for (int i = 0; i < 2; i++)
				{
					if (_upgradeActions[i] == null)
					{
						_upgradeActions[i] = delegate
						{
						};
					}
				}
			}
			for (int num = version; num < 2; num++)
			{
				_upgradeActions[num](xml);
			}
		}

		private static void UpgradeToVersion1(XElement xml)
		{
		}

		private static void UpgradeToVersion2(XElement xml)
		{
			XElement xElement = xml.Element("SkyShaderData").Element("PlanetShaderData").Element("options");
			xElement.Attribute("scaleDepthAuto").Value = "false";
			xElement.Add(new XAttribute("legacySkyShader", "true"));
			bool boolAttribute = Utilities.GetBoolAttribute(xml, "skyShaderEnabled", defaultValue: false);
			xml.Add(new XAttribute("skyboxFadeDuringDaytime", boolAttribute));
		}
	}
}
