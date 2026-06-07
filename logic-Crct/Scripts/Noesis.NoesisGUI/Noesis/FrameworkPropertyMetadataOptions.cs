using System;

namespace Noesis
{
	[Flags]
	public enum FrameworkPropertyMetadataOptions
	{
		None = 0,
		AffectsMeasure = 1,
		AffectsArrange = 2,
		AffectsParentMeasure = 4,
		AffectsParentArrange = 8,
		AffectsRender = 0x10,
		Inherits = 0x20,
		OverridesInheritanceBehavior = 0x40,
		NotDataBindable = 0x80,
		BindsTwoWayByDefault = 0x100,
		Journal = 0x400,
		SubPropertiesDoNotAffectRender = 0x800
	}
}
