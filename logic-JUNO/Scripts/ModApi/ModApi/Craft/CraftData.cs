using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Parts;
using ModApi.Mods;
using UnityEngine;

namespace ModApi.Craft
{
	public class CraftData
	{
		public const int CurrentXmlVersion = 15;

		public const string RemoveInvalidPartsAttributeName = "removeInvalidParts";

		private List<ThemeData> _themes = new List<ThemeData>();

		public int ActiveCommandPodId { get; set; }

		public Assembly Assembly { get; set; }

		public DesignerSettingsData DesignerSettings { get; private set; }

		public Vector3 InitialBoundsMax { get; set; }

		public Vector3 InitialBoundsMin { get; set; }

		public bool LegacyLaunchConfiguration { get; set; }

		public Vector3? LocalCenterOfMass { get; set; }

		public string Name { get; set; }

		public string ParentAncestryId { get; set; }

		public long Price { get; set; }

		public bool RemoveInvalidParts { get; set; } = true;

		public Vector3 Size => InitialBoundsMax - InitialBoundsMin;

		public IReadOnlyList<ThemeData> Themes => _themes;

		public int XmlVersion { get; set; }

		public CraftData(XElement xml, CraftThemes themes, PartTypeList partTypes)
		{
			if (xml == null)
			{
				throw new ArgumentNullException("xml", "Attempting to instantiate a CraftData with a null XElement");
			}
			XmlVersion = GetXmlVersion(xml);
			if (XmlVersion < 15)
			{
				CraftXmlVersionUpdater.Upgrade(xml, XmlVersion);
			}
			Name = GetCraftName(xml);
			InitialBoundsMin = Utilities.GetVectorAttribute(xml, "initialBoundsMin", Vector3.zero);
			InitialBoundsMax = Utilities.GetVectorAttribute(xml, "initialBoundsMax", Vector3.zero);
			LocalCenterOfMass = xml.GetVector3AttributeOrNull("localCenterOfMass");
			Price = GetPrice(xml);
			ParentAncestryId = Utilities.GetStringAttribute(xml, "parent", string.Empty);
			LegacyLaunchConfiguration = Utilities.GetBoolAttribute(xml, "legacyLaunchConfiguration", defaultValue: false);
			RemoveInvalidParts = xml.GetBoolAttribute("removeInvalidParts", defaultValue: true);
			ActiveCommandPodId = xml.GetIntAttribute("activeCommandPod");
			XElement xml2 = xml.Element("DesignerSettings");
			DesignerSettings = new DesignerSettingsData(xml2, XmlVersion, themes);
			XElement xElement = xml.Element("Themes");
			if (xElement != null)
			{
				foreach (XElement item2 in xElement.Elements("Theme"))
				{
					ThemeData item = new ThemeData(item2, XmlVersion);
					_themes.Add(item);
				}
			}
			if (_themes.Count == 0)
			{
				_themes.Add(DesignerSettings.CustomTheme.Duplicate());
			}
			XElement assemblyElement = xml.Element("Assembly");
			Assembly = new Assembly(assemblyElement, XmlVersion, partTypes);
			XmlVersion = 15;
		}

		private CraftData()
		{
		}

		public static CraftData CreateEmptyCraftDataFromSource(CraftData source, Assembly assembly)
		{
			return new CraftData
			{
				XmlVersion = 15,
				Name = string.Empty,
				InitialBoundsMin = Vector3.zero,
				InitialBoundsMax = Vector3.zero,
				ParentAncestryId = string.Empty,
				DesignerSettings = new DesignerSettingsData(null, 15, null),
				RemoveInvalidParts = source.RemoveInvalidParts,
				Assembly = assembly
			};
		}

		public static string GetCraftName(XElement xml)
		{
			return ((string)xml.Attribute("name")) ?? string.Empty;
		}

		public static long GetPrice(XElement xml)
		{
			return xml.GetLongAttribute("price", 0L);
		}

		public static RequiredModsData GetRequiredMods(XElement xml)
		{
			return new RequiredModsData(xml.Element("RequiredMods"));
		}

		public static int GetXmlVersion(XElement xml)
		{
			return Utilities.GetIntAttribute(xml, "xmlVersion", 15);
		}

		public static RequiredModsCheck VerifyRequiredMods(XElement xml)
		{
			return new RequiredModsCheck(GetRequiredMods(xml));
		}

		public void AddTheme(ThemeData themeData)
		{
			foreach (ThemeData theme in _themes)
			{
				if (theme.Id == themeData.Id)
				{
					Debug.LogErrorFormat("Craft already contains theme '{0}' with ID: {1}", themeData.Name, themeData.Id);
				}
			}
			_themes.Add(themeData);
		}

		public PartModifierData FindModifierById(string id)
		{
			foreach (PartData part in Assembly.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					if (modifier.Id == id)
					{
						return modifier;
					}
				}
			}
			return null;
		}

		public XElement GenerateXml(Transform craftTransform, bool optimizeXml, bool generateRequiredMods)
		{
			int num = 15;
			XElement xElement = new XElement("Craft", new XAttribute("name", Name), new XAttribute("parent", ParentAncestryId), new XAttribute("initialBoundsMin", Utilities.Vector3ToString(InitialBoundsMin)), new XAttribute("initialBoundsMax", Utilities.Vector3ToString(InitialBoundsMax)), new XAttribute("removeInvalidParts", RemoveInvalidParts), new XAttribute("price", Price), new XAttribute("xmlVersion", num), new XAttribute("activeCommandPod", ActiveCommandPodId), Assembly.GenerateXml(craftTransform, subAssembly: false, optimizeXml), DesignerSettings.GenerateXml(optimizeXml));
			if (LocalCenterOfMass.HasValue)
			{
				xElement.Add(new XAttribute("localCenterOfMass", Utilities.Vector3ToString(LocalCenterOfMass.Value)));
			}
			XElement xElement2 = new XElement("Themes");
			xElement.Add(xElement2);
			foreach (ThemeData theme in Themes)
			{
				xElement2.Add(theme.GenerateXml(optimizeXml));
			}
			if (generateRequiredMods)
			{
				RequiredModsData requiredModsData = new RequiredModsData(GetRequiredMods());
				xElement.Add(requiredModsData.GenerateXml());
			}
			return xElement;
		}

		public RequiredMods GetRequiredMods()
		{
			IModManager modManager = Game.Instance.ModManager;
			if (modManager.LoadedMods.Count == 0)
			{
				return new RequiredMods();
			}
			RequiredMods requiredMods = new RequiredMods();
			foreach (PartData part in Assembly.Parts)
			{
				foreach (PartModifierData modifier in part.Modifiers)
				{
					modifier.GetModRequirements(requiredMods.Add);
				}
				if (part.PartType.Mod != null)
				{
					requiredMods.Add(part.PartType.Mod.ModInfo, requiresCodeExecution: false);
				}
			}
			foreach (GameMod gameMod in modManager.GameMods)
			{
				if (gameMod.IsModRequiredForCraft(this))
				{
					requiredMods.Add(gameMod.ModInfo, requiresCodeExecution: true);
				}
			}
			return requiredMods;
		}

		public ThemeData GetTheme(Guid themeId)
		{
			foreach (ThemeData theme in _themes)
			{
				if (theme.Id == themeId)
				{
					return theme;
				}
			}
			return null;
		}

		public void RemoveTheme(ThemeData themeData)
		{
			if (!_themes.Remove(themeData))
			{
				Debug.LogErrorFormat("Craft {0} does not have theme {1}, so it could not be removed.", Name, themeData.Id);
			}
		}
	}
}
