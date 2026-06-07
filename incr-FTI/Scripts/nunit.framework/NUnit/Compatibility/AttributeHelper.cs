using System;
using System.Reflection;

namespace NUnit.Compatibility
{
	public static class AttributeHelper
	{
		public static Attribute[] GetCustomAttributes(object actual, Type attributeType, bool inherit)
		{
			if (!(actual is ICustomAttributeProvider customAttributeProvider))
			{
				throw new ArgumentException($"Actual value {actual} does not implement ICustomAttributeProvider.", "actual");
			}
			return (Attribute[])customAttributeProvider.GetCustomAttributes(attributeType, inherit);
		}
	}
}
