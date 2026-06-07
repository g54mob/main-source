using System;

namespace AltSerialize
{
	[Flags]
	internal enum SerializedObjectFlags : byte
	{
		None = 0,
		IsNull = 1,
		SetCache = 2,
		CachedItem = 4,
		PropertyName = 8,
		FieldName = 0x10,
		Type = 0x20,
		SystemType = 0x40,
		Array = 0x80,
		Invalid = byte.MaxValue
	}
}
