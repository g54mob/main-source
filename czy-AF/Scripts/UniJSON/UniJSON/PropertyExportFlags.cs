using System;

namespace UniJSON
{
	[Flags]
	public enum PropertyExportFlags
	{
		None = 0,
		PublicFields = 1,
		PublicProperties = 2,
		Default = 3
	}
}
