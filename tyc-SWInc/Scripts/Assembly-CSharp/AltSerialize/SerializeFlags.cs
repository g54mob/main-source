using System;

namespace AltSerialize
{
	[Flags]
	public enum SerializeFlags
	{
		None = 0,
		SerializePropertyNames = 1,
		SerializationCache = 2,
		SerializeProperties = 0x10,
		All = 3
	}
}
