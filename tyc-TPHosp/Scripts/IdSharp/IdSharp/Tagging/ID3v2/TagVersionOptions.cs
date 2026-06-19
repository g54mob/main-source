using System;
using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[Flags]
	[ComVisible(true)]
	[Guid("82E49486-676F-42d1-8D33-587E4D7CEAC8")]
	public enum TagVersionOptions
	{
		None = 0,
		UseNonSyncSafeFrameSizeID3v24 = 1,
		AddOneByteToSize = 2,
		Unsynchronized = 4
	}
}
