using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Planet
{
	internal static class PlanetarySystemXmlVersionUpdater
	{
		private static Action<XElement>[] _upgradeActions = new Action<XElement>[1] { UpgradeToVersion1 };

		public static void Upgrade(XElement xml, int version)
		{
			xml.SetAttributeValue("xmlVersion", 1);
			if (_upgradeActions.Length != 1)
			{
				Debug.LogError("WARNING: Missing upgrade action(s) used when upgrading from an older planetary system XML version.");
				Array.Resize(ref _upgradeActions, 1);
				for (int i = 0; i < 1; i++)
				{
					if (_upgradeActions[i] == null)
					{
						_upgradeActions[i] = delegate
						{
						};
					}
				}
			}
			for (int num = version; num < 1; num++)
			{
				_upgradeActions[num](xml);
			}
		}

		private static void UpgradeToVersion1(XElement xml)
		{
			foreach (XElement item in xml.Elements("CelestialBodies").Elements("CelestialBody").Elements("Orbit"))
			{
				XElement parent = item.Parent;
				item.Remove();
				XElement content = new XElement("Data", item);
				parent.Add(content);
			}
		}
	}
}
