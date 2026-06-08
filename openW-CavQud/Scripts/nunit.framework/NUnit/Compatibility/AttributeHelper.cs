using System;
using System.Reflection;

namespace NUnit.Compatibility
{
	public static class AttributeHelper
	{
		public static Attribute[] GetCustomAttributes(object actual, Type attributeType, bool inherit)
		{
			return (Attribute[])((actual as ICustomAttributeProvider) ?? throw new ArgumentException($"Actual value {actual} does not implement ICustomAttributeProvider.", "actual")).GetCustomAttributes(attributeType, inherit);
		}
	}
}
