using System;

namespace UI.Xml
{
	[AttributeUsage(AttributeTargets.Field)]
	public class XmlFieldName : Attribute
	{
		public string fieldName;

		public XmlFieldName(string fieldName)
		{
			this.fieldName = fieldName;
		}
	}
}
