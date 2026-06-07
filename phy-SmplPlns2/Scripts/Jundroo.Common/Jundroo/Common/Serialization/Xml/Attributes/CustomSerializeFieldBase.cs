using System;

namespace Jundroo.Common.Serialization.Xml.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public abstract class CustomSerializeFieldBase : Attribute
	{
		public XmlSerializationNullValueMode SerializationNullValueMode { get; set; }

		public XmlSerializationFlags SerializationOptions { get; set; }

		public CustomSerializeFieldBase()
		{
		}
	}
}
