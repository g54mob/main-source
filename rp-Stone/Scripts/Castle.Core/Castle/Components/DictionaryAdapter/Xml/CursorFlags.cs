using System;

namespace Castle.Components.DictionaryAdapter.Xml
{
	[Flags]
	public enum CursorFlags
	{
		None = 0,
		Elements = 1,
		Attributes = 2,
		Multiple = 4,
		Mutable = 8,
		AllNodes = 3
	}
}
