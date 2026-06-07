using System;

namespace ModApi.Planet.Modifiers.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class PlanetModifierInfoAttribute : Attribute
	{
		public string Description { get; }

		public string DisplayName { get; set; }

		public bool IsHidden { get; set; }

		public PlanetModifierInfoAttribute(string description)
		{
			Description = description;
		}

		public PlanetModifierInfoAttribute(string displayName, string description)
		{
			DisplayName = displayName;
			Description = description;
		}
	}
}
