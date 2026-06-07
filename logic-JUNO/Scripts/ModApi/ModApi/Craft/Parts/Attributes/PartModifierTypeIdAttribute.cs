using System;

namespace ModApi.Craft.Parts.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
	public class PartModifierTypeIdAttribute : Attribute
	{
		public string Id { get; private set; }

		public bool IsLegacyId { get; set; }

		public PartModifierTypeIdAttribute(string typeId)
		{
			Id = typeId;
		}
	}
}
