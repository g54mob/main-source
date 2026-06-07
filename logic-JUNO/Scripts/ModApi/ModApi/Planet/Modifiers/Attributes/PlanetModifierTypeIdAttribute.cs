using System;

namespace ModApi.Planet.Modifiers.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public class PlanetModifierTypeIdAttribute : Attribute
	{
		public string Id { get; private set; }

		public PlanetModifierTypeIdAttribute(string typeId)
		{
			Id = typeId;
		}
	}
}
