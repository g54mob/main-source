using System;

namespace GAudio.Attributes
{
	public class BindedObjectProperty : BindedValueProperty
	{
		public BindedObjectProperty(string propertyPath, Type outerType, string toggleName = null)
			: base(propertyPath, outerType, toggleName)
		{
		}
	}
}
