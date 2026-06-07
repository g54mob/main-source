using System;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft
{
	internal static class CraftXmlVersionUpdater
	{
		private static Action<XElement>[] _upgradeActions = new Action<XElement>[15]
		{
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			},
			delegate
			{
			}
		};

		public static void Upgrade(XElement xml, int version)
		{
			XAttribute xAttribute = xml.Attribute("xmlVersion");
			if (xAttribute != null)
			{
				xAttribute.Value = 15.ToString();
			}
			if (_upgradeActions.Length != 15)
			{
				Debug.LogError("WARNING: Missing craft upgrade action(s) used when upgrading from an older craft XML version.");
				Array.Resize(ref _upgradeActions, 15);
				for (int i = 0; i < 15; i++)
				{
					if (_upgradeActions[i] == null)
					{
						_upgradeActions[i] = delegate
						{
						};
					}
				}
			}
			for (int num = version; num < 15; num++)
			{
				_upgradeActions[num](xml);
			}
		}
	}
}
