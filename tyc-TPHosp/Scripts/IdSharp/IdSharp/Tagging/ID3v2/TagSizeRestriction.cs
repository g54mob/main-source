using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[ComVisible(true)]
	[Guid("4AAE3FCC-84F3-4e77-A821-C88A9399930C")]
	public enum TagSizeRestriction : byte
	{
		NoMore128Frames1MBTotal = 0,
		NoMore64Frames128KBTotal = 1,
		NoMore32Frames40KBTotal = 2,
		NoMore32Frames4KBTotal = 3
	}
}
