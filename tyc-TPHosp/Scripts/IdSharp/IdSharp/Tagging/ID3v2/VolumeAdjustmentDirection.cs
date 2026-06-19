using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[ComVisible(true)]
	[Guid("9EA88264-E7EF-4025-9308-AFC2A7B09D02")]
	public enum VolumeAdjustmentDirection : byte
	{
		Decrement = 0,
		Increment = 1
	}
}
