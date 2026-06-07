using System;

namespace Sirenix.OdinInspector
{
	public class OdinRegisterAttributeAttribute : Attribute
	{
		public Type AttributeType;

		public string Categories;

		public string Description;

		public string DocumentationUrl;

		public bool IsEnterprise;

		public OdinRegisterAttributeAttribute(Type attributeType, string category, string description, bool isEnterprise)
		{
		}

		public OdinRegisterAttributeAttribute(Type attributeType, string category, string description, bool isEnterprise, string url)
		{
		}
	}
}
