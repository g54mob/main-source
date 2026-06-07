using System;

namespace GAudio.Attributes
{
	public class BindedFloatProperty : BindedValueProperty
	{
		public BindedFloatProperty(string propertyPath, Type outerType, string toggleName = null)
			: base(propertyPath, outerType, toggleName)
		{
		}
	}
}
