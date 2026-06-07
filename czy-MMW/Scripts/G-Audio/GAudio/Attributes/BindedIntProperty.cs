using System;

namespace GAudio.Attributes
{
	public class BindedIntProperty : BindedValueProperty
	{
		public BindedIntProperty(string propertyPath, Type outerType, string toggleName = null)
			: base(propertyPath, outerType, toggleName)
		{
		}
	}
}
