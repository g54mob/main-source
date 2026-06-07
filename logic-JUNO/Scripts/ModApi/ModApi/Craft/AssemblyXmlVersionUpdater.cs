using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using UnityEngine;

namespace ModApi.Craft
{
	internal static class AssemblyXmlVersionUpdater
	{
		private static Action<XElement>[] _upgradeActions = new Action<XElement>[15]
		{
			delegate
			{
			},
			UpgradeToVersion2,
			UpgradeToVersion3,
			UpgradeToVersion4,
			UpgradeToVersion5,
			UpgradeToVersion6,
			UpgradeToVersion7,
			UpgradeToVersion8,
			UpgradeToVersion9,
			UpgradeToVersion10,
			UpgradeToVersion11,
			UpgradeToVersion12,
			UpgradeToVersion13,
			UpgradeToVersion14,
			UpgradeToVersion15
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
				Debug.LogError("WARNING: Missing assembly upgrade action(s) used when upgrading from an older craft XML version.");
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

		private static void UpgradeToVersion10(XElement xml)
		{
			foreach (XElement item in xml.Elements("Parts").Elements("Part").Elements("InputController")
				.ToList())
			{
				string text = (string)item.Attribute("input");
				if (text == null || text.Length == 0 || !text.Contains('.'))
				{
					continue;
				}
				char c = text[0];
				if (text.StartsWith("FlightData.", StringComparison.Ordinal) || c == '-' || c == '.' || char.IsNumber(c))
				{
					if (c == '.')
					{
						item.SetAttributeValue("input", "0" + text);
					}
				}
				else
				{
					item.SetAttributeValue("input", "*." + text);
				}
			}
		}

		private static void UpgradeToVersion11(XElement xml)
		{
			foreach (XElement item in xml.Elements("Parts").Elements("Part").Elements("CommandPod")
				.ToList())
			{
				XElement parent = item.Parent;
				bool flag = parent.Attribute("partType").Value == "CommandChip1";
				bool flag2 = parent.Element("CrewCompartment") != null;
				if (parent.Element("Eva") == null && !flag2 && !flag)
				{
					parent.Add(new XElement("CrewCompartment", new XAttribute("autoCalcCpapacity", "false"), new XAttribute("capacity", "3"), new XAttribute("crewExitPosition", "0,0,-1.25"), new XAttribute("crewExitRotation", "0,180,0"), new XAttribute("inspectorEnable", "true"), new XAttribute("partPropertiesEnabled", "true")));
				}
			}
		}

		private static void UpgradeToVersion12(XElement xml)
		{
			IEnumerable<XElement> source = xml.Elements("Parts").Elements("Part");
			foreach (XElement item in source.Elements("CommandPod").ToList())
			{
				item.Add(new XAttribute("useDefaultPilotSeatRotation", "false"));
			}
			foreach (XElement item2 in source.Elements("Parachute").ToList())
			{
				item2.Add(new XAttribute("baseSize", "1"));
			}
		}

		private static void UpgradeToVersion13(XElement xml)
		{
		}

		private static void UpgradeToVersion14(XElement xml)
		{
			foreach (XElement item in (from x in xml.Elements("Parts").Elements("Part")
				where x.Attribute("partType")?.Value == "SolarPanelArray"
				select x).ToList())
			{
				List<int> intListAttribute = Utilities.GetIntListAttribute(item, "materials");
				if (intListAttribute != null && intListAttribute.Count == 5)
				{
					intListAttribute[4] = intListAttribute[2];
					Utilities.SetIntListAttribute(item, "materials", intListAttribute);
				}
			}
		}

		private static void UpgradeToVersion15(XElement xml)
		{
			foreach (XElement item in (from x in xml.Elements("Parts").Elements("Part")
				where x.Attribute("partType")?.Value == "ElectricMotor1"
				select x).Elements("ElectricMotor"))
			{
				item.Name = "ElectricMotorOld";
			}
		}

		private static void UpgradeToVersion2(XElement xml)
		{
			foreach (XElement item in xml.Elements("Parts").Elements("Part").Elements())
			{
				string text = item.Name.LocalName;
				if (text.EndsWith(".State"))
				{
					text = text.Remove(text.Length - 6);
				}
				if (text.EndsWith("Data"))
				{
					text = text.Remove(text.Length - 4);
				}
				item.Name = text;
			}
		}

		private static void UpgradeToVersion3(XElement xml)
		{
			Dictionary<string, string> partTypeLookup = xml.Elements("Parts").Elements("Part").ToDictionary((XElement x) => (string)x.Attribute("id"), (XElement x) => (string)x.Attribute("partType"));
			Action<XAttribute, XAttribute> action = delegate(XAttribute partId, XAttribute colliderName)
			{
				if (!string.IsNullOrEmpty((string)colliderName))
				{
					string value = null;
					if (partTypeLookup.TryGetValue((string)partId, out value))
					{
						switch (value)
						{
						case "Engine2":
						case "FuelAdapter1":
						case "Piston1":
							colliderName.Remove();
							break;
						}
					}
				}
			};
			foreach (XElement item in xml.Elements("Collisions").Elements("Collision"))
			{
				action(item.Attribute("partA"), item.Attribute("colliderNameA"));
				action(item.Attribute("partB"), item.Attribute("colliderNameB"));
			}
		}

		private static void UpgradeToVersion4(XElement xml)
		{
			foreach (XElement item in xml.Elements("Parts").Elements("Part"))
			{
				XElement xElement = new XElement("Config");
				item.Add(xElement);
				xElement.SetAttributeValue("buoyancyUserScale", item.Attribute("buoyancyUserScale")?.Value);
				xElement.SetAttributeValue("fuelLine", item.Attribute("fuelLine")?.Value);
				xElement.SetAttributeValue("partScale", item.Attribute("scale")?.Value);
			}
		}

		private static void UpgradeToVersion5(XElement xml)
		{
			xml.SetAttributeValue("legacyLaunchConfiguration", "true");
			foreach (XElement item in xml.Elements("Parts").Elements("Part").Elements("CommandPod"))
			{
				Vector3 vector3Attribute = item.Parent.GetVector3Attribute("rotation", Vector3.zero);
				if (Mathf.Abs(vector3Attribute.x) > 5f || Mathf.Abs(vector3Attribute.z) > 5f)
				{
					_ = item.Parent.Attribute("partType")?.Value;
					Vector3 eulerAngles = Quaternion.FromToRotation(Quaternion.Euler(vector3Attribute) * Vector3.forward, Vector3.up).eulerAngles;
					item.SetAttribute("headingDirectionRotation", eulerAngles);
				}
			}
		}

		private static void UpgradeToVersion6(XElement xml)
		{
			foreach (XElement item in xml.Elements("Parts").Elements("Part").Elements("CommandPod"))
			{
				Vector3 vector3Attribute = item.GetVector3Attribute("headingDirectionRotation", new Vector3(-90f, 0f, 0f));
				item.SetAttribute("pilotSeatRotation", vector3Attribute);
			}
		}

		private static void UpgradeToVersion7(XElement xml)
		{
			foreach (XElement item in xml.Elements("Parts").Elements("Part").Elements("ReactionControlNozzle"))
			{
				float? num = (float?)item.Attribute("power");
				if (num.HasValue)
				{
					item.Attribute("power").SetValue(num.Value * 100f);
				}
			}
		}

		private static void UpgradeToVersion8(XElement xml)
		{
			List<XElement> list = new List<XElement>();
			list.AddRange(xml.Elements("Parts").Elements("Part").Elements("FuelTank")
				.ToList());
			list.AddRange(xml.Elements("Parts").Elements("Part").Elements("FuelSource")
				.ToList());
			foreach (XElement item in list)
			{
				string stringAttribute = item.GetStringAttribute("fuelType");
				if (stringAttribute != null && stringAttribute == "RP1")
				{
					stringAttribute = "LOX/RP1";
					item.SetAttributeValue("fuelType", stringAttribute);
				}
			}
		}

		private static void UpgradeToVersion9(XElement xml)
		{
			foreach (XElement item in xml.Elements("Parts").Elements("Part").Elements("FuelSource")
				.ToList())
			{
				string value = item.Attribute("fuelType")?.Value;
				if (!string.IsNullOrWhiteSpace(value))
				{
					item.Parent.Element("RocketEngine")?.SetAttributeValue("fuelType", value);
					item.Parent.Element("Engine")?.SetAttributeValue("fuelType", value);
				}
				item.Remove();
			}
		}
	}
}
