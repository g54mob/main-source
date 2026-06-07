using System;

namespace FuryStudios.FurySDK.Internal
{
	[Flags]
	public enum StorageAccessMode
	{
		None = 0,
		Read = 1,
		Write = 2,
		ReadWrite = 3
	}
}
