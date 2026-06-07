using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Math
{
	public class UnitSystem
	{
		public class Unit
		{
			public string Abbreviation { get; }

			public string AbbreviationRT { get; }

			public float Factor { get; }

			public string Name { get; }

			public Unit(string name, string abbreviation, float factor, string abbreviationRtf = null)
			{
				Name = name;
				Abbreviation = abbreviation;
				Factor = factor;
				AbbreviationRT = abbreviationRtf;
			}
		}

		public static readonly UnitSystem Imperial = new UnitSystem
		{
			Name = "Imperial",
			IsBuiltIn = true,
			_units = new Dictionary<UnitType, Unit>
			{
				{
					UnitType.LongDistance,
					new Unit("miles", "mi", 0.000621371f)
				},
				{
					UnitType.ShortDistance,
					new Unit("feet", "ft", 3.28084f)
				},
				{
					UnitType.TinyDistance,
					new Unit("inches", "in", 39.37008f)
				},
				{
					UnitType.Speed,
					new Unit("miles per hour", "mph", 2.23694f)
				},
				{
					UnitType.Mass,
					new Unit("pounds", "lbs", 2.20462f)
				},
				{
					UnitType.Force,
					new Unit("pounds force", "lbf", 0.22480895f)
				},
				{
					UnitType.Volume,
					new Unit("US gallons", "gal", 0.264172f)
				},
				{
					UnitType.Area,
					new Unit("feet squared", "ft^2", 10.76391f, "ft<sup>2</sup>")
				},
				{
					UnitType.WingLoading,
					new Unit("pounds per foot squared", "lbs/ft^2", 0.20481615f, "lbs/ft<sup>2</sup>")
				}
			}
		};

		public static readonly UnitSystem Metric = new UnitSystem
		{
			Name = "Metric",
			IsBuiltIn = true,
			_units = new Dictionary<UnitType, Unit>
			{
				{
					UnitType.LongDistance,
					new Unit("kilometers", "km", 0.001f)
				},
				{
					UnitType.ShortDistance,
					new Unit("meters", "m", 1f)
				},
				{
					UnitType.TinyDistance,
					new Unit("millimeters", "mm", 1000f)
				},
				{
					UnitType.Speed,
					new Unit("kilometers per hour", "km/h", 3.6f)
				},
				{
					UnitType.Mass,
					new Unit("kilograms", "kg", 1f)
				},
				{
					UnitType.Force,
					new Unit("newtons", "N", 1f)
				},
				{
					UnitType.Volume,
					new Unit("liters", "L", 1f)
				},
				{
					UnitType.Area,
					new Unit("meters squared", "m^2", 1f, "m<sup>2</sup>")
				},
				{
					UnitType.WingLoading,
					new Unit("kilograms per meter squared", "kg/m^2", 1f, "kg/m<sup>2</sup>")
				}
			}
		};

		public static readonly UnitSystem Nautical = new UnitSystem
		{
			Name = "Nautical",
			IsBuiltIn = true,
			_units = new Dictionary<UnitType, Unit>
			{
				{
					UnitType.LongDistance,
					new Unit("nautical miles", "nm", 0.0005399565f)
				},
				{
					UnitType.ShortDistance,
					new Unit("feet", "ft", 3.28084f)
				},
				{
					UnitType.TinyDistance,
					new Unit("inches", "in", 39.37008f)
				},
				{
					UnitType.Speed,
					new Unit("knots", "kt", 1.943844f)
				},
				{
					UnitType.Mass,
					new Unit("pounds", "lbs", 2.20462f)
				},
				{
					UnitType.Force,
					new Unit("pounds force", "lbf", 0.22480895f)
				},
				{
					UnitType.Volume,
					new Unit("US gallons", "gal", 0.264172f)
				},
				{
					UnitType.Area,
					new Unit("feet squared", "ft^2", 10.76391f, "ft<sup>2</sup>")
				},
				{
					UnitType.WingLoading,
					new Unit("pounds per foot squared", "lbs/ft^2", 0.20481615f, "lbs/ft<sup>2</sup>")
				}
			}
		};

		private Dictionary<UnitType, Unit> _units = new Dictionary<UnitType, Unit>();

		public bool IsBuiltIn { get; private set; }

		public string Name { get; private set; }

		public IReadOnlyDictionary<UnitType, Unit> Units => _units;

		public static UnitSystem Load(XElement element, UnitSystem defaultSystem = null)
		{
			UnitSystem unitSystem = new UnitSystem
			{
				Name = element.Name.LocalName
			};
			foreach (UnitType value2 in Enum.GetValues(typeof(UnitType)))
			{
				XElement xElement = element.Element(value2.ToString());
				if (xElement == null)
				{
					if (defaultSystem == null || !defaultSystem.Units.ContainsKey(value2))
					{
						Debug.LogError($"Could not load unit system: {unitSystem.Name}. Could not find unit for {value2}.");
						return null;
					}
					unitSystem._units.Add(value2, defaultSystem.Units[value2]);
				}
				else
				{
					Unit value = new Unit(((string)xElement.Attribute("name")) ?? "?", ((string)xElement.Attribute("abbreviation")) ?? "?", ((float?)xElement.Attribute("factor")) ?? 1f, (string)xElement.Attribute("abbreviationRTF"));
					unitSystem._units.Add(value2, value);
				}
			}
			return unitSystem;
		}

		public XElement Save()
		{
			XElement xElement = new XElement(Name);
			foreach (KeyValuePair<UnitType, Unit> unit in Units)
			{
				xElement.Add(new XElement(unit.Key.ToString(), new XAttribute("name", unit.Value.Name), new XAttribute("abbreviation", unit.Value.Abbreviation), new XAttribute("factor", unit.Value.Factor), (unit.Value.AbbreviationRT != null) ? new XAttribute("abbreviationRTF", unit.Value.AbbreviationRT) : null));
			}
			return xElement;
		}
	}
}
