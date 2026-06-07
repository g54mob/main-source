using System;

namespace GAudio.Attributes
{
	public class BindedBoolProperty : BindedValueProperty
	{
		public BindedBoolProperty(string propertyPath, Type outerType, string toggleName = null)
			: base(propertyPath, outerType, toggleName)
		{
		}
	}
}
