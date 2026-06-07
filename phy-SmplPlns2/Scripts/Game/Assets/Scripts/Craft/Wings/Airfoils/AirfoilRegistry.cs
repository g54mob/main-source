using System;
using System.Collections.Generic;

namespace Assets.Scripts.Craft.Wings.Airfoils
{
	public static class AirfoilRegistry
	{
		private static List<Func<string, IAirfoil>> _parsers;

		public static Dictionary<string, IAirfoil> SimpleAirfoilPresets { get; private set; }

		public static event Func<string, IAirfoil> ParseAirfoilHook
		{
			add
			{
				if (!_parsers.Contains(value))
				{
					_parsers.Add(value);
				}
			}
			remove
			{
				if (_parsers.Contains(value))
				{
					_parsers.Remove(value);
				}
			}
		}

		static AirfoilRegistry()
		{
			_parsers = new List<Func<string, IAirfoil>>();
			SimpleAirfoilPresets = new Dictionary<string, IAirfoil>();
			ParseAirfoilHook += NACAFoils.ParseNACA;
			ParseAirfoilHook += BiconvexFoils.Parse;
			SimpleAirfoilPresets.Add("Symmetric", NACAFoils.ParseNACA("NACA0012"));
			SimpleAirfoilPresets.Add("Semi-Symmetric", NACAFoils.ParseNACA("NACA3412"));
			SimpleAirfoilPresets.Add("Flat Bottom", NACAFoils.ParseNACA("NACA3311"));
		}

		public static IAirfoil ParseAirfoil(string name)
		{
			if (SimpleAirfoilPresets.TryGetValue(name, out var value))
			{
				return value;
			}
			foreach (Func<string, IAirfoil> parser in _parsers)
			{
				IAirfoil airfoil = parser(name);
				if (airfoil != null)
				{
					return airfoil;
				}
			}
			return null;
		}
	}
}
