using System;

namespace ProtoBuf.Meta
{
	[Flags]
	public enum SchemaGenerationFlags
	{
		None = 0,
		MultipleNamespaceSupport = 1,
		PreserveSubType = 2,
		IncludeEnumNamePrefix = 4
	}
}
