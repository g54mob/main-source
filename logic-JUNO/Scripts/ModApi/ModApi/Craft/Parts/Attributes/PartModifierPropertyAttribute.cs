using System;
using Jundroo.ModTools.Serialization.Xml;
using Jundroo.ModTools.Serialization.Xml.Attributes;

namespace ModApi.Craft.Parts.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
	public class PartModifierPropertyAttribute : CustomSerializeFieldBase
	{
		public bool NeverSerialize { get; set; }

		public bool PreserveState { get; set; }

		public PartModifierPropertyStatePreservationMode PreserveStateMode { get; set; }

		public PartModifierPropertyAttribute(bool preserveState = true, bool neverSerialize = false)
		{
			PreserveState = preserveState;
			NeverSerialize = neverSerialize;
			PreserveStateMode = PartModifierPropertyStatePreservationMode.Default;
			base.SerializationNullValueMode = XmlSerializationNullValueMode.Ignore;
			base.SerializationOptions = XmlSerializationFlags.EmptyStringAsNull | XmlSerializationFlags.NullAsEmptyString;
		}
	}
}
