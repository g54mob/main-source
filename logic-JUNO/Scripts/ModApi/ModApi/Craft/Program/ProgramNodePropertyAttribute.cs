using System;
using Jundroo.ModTools.Serialization.Xml;
using Jundroo.ModTools.Serialization.Xml.Attributes;

namespace ModApi.Craft.Program
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class ProgramNodePropertyAttribute : CustomSerializeFieldBase
	{
		public ProgramNodePropertyAttribute()
		{
			base.SerializationNullValueMode = XmlSerializationNullValueMode.Ignore;
			base.SerializationOptions = XmlSerializationFlags.EmptyStringAsNull | XmlSerializationFlags.NullAsEmptyString;
		}
	}
}
