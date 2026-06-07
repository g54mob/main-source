using System;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.State
{
	public static class GameStateXmlVersionUpdater
	{
		private static Action<XElement, GameState>[] _upgradeActions = new Action<XElement, GameState>[6]
		{
			delegate
			{
			},
			UpgradeToVersion2,
			UpgradeToVersion3,
			UpgradeToVersion4,
			UpgradeToVersion5,
			UpgradeToVersion6
		};

		public static void Upgrade(GameState gameState, XElement xml, int version)
		{
			XAttribute xAttribute = xml.Attribute("xmlVersion");
			if (xAttribute != null)
			{
				xAttribute.Value = 6.ToString();
			}
			if (_upgradeActions.Length != 6)
			{
				Debug.LogError("WARNING: Missing game state upgrade action(s) used when upgrading from an older game state XML version.");
				Array.Resize(ref _upgradeActions, 6);
				for (int i = 0; i < 6; i++)
				{
					if (_upgradeActions[i] == null)
					{
						_upgradeActions[i] = delegate
						{
						};
					}
				}
			}
			for (int num = version; num < 6; num++)
			{
				_upgradeActions[num](xml, gameState);
			}
			Debug.LogFormat("Upgraded GameState from version {0} to {1}.", version, 6);
		}

		private static void UpgradeToVersion2(XElement xml, GameState gameState)
		{
			foreach (XElement item in xml.Elements("LaunchLocations").Elements("LaunchLocation"))
			{
				string value = item.Attribute("planetName").Value;
				item.Attribute("planetName").SetValue(FlightStateXmlVersionUpdater.UpgradeOriginalPlanetName(value));
			}
		}

		private static void UpgradeToVersion3(XElement xml, GameState gameState)
		{
			foreach (XElement item in xml.GetOrCreateElement("LaunchLocations").Elements())
			{
				LaunchLocation launchLocation = new LaunchLocation(item);
				if (item.GetBoolAttribute("selected"))
				{
					gameState.SelectedLaunchLocation = launchLocation;
				}
				if (!gameState.LaunchLocations.Any((LaunchLocation x) => x.Name == launchLocation.Name))
				{
					gameState.LaunchLocations.Add(launchLocation);
				}
			}
			gameState.SaveLaunchLocations();
		}

		private static void UpgradeToVersion4(XElement xml, GameState gameState)
		{
		}

		private static void UpgradeToVersion5(XElement xml, GameState gameState)
		{
			if (xml.GetEnumAttribute("mode", GameStateMode.Sandbox) == GameStateMode.Career)
			{
				gameState.Mode = GameStateMode.Sandbox;
				xml.SetAttributeValue("mode", GameStateMode.Sandbox);
				Debug.Log("Outdated game state with career mode enabled has been changed to sandbox mode.");
			}
		}

		private static void UpgradeToVersion6(XElement xml, GameState gameState)
		{
			if (xml.GetEnumAttribute("mode", GameStateMode.Sandbox) == GameStateMode.Career)
			{
				xml.SetAttributeValue("notSupported", true);
			}
		}
	}
}
