using System;

namespace Jundroo.ModTools.Serialization.Xml
{
	[Flags]
	public enum XmlSerializationFlags
	{
		Default = 0,
		EnumsAsValues = 1,
		SingleAttribute = 2,
		EmptyStringAsNull = 4,
		NullAsEmptyString = 8,
		KeepEmptyEntries = 0x10
	}
}
