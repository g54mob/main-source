using System;

namespace Pug.Properties
{
	public class PropertyIDGeneratorAttribute : Attribute
	{
		public int PropertyArgumentIndex { get; }

		public PropertyIDGeneratorAttribute(int propertyArgumentIndex = 0)
		{
			PropertyArgumentIndex = propertyArgumentIndex;
		}
	}
}
