using System;
using ModApi.CelestialData;

namespace ModApi.Planet.Modifiers.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class SupportFileReferenceAttribute : Attribute
	{
		public SupportFileType Type { get; }

		public SupportFileReferenceAttribute(SupportFileType type)
		{
			Type = type;
		}
	}
}
