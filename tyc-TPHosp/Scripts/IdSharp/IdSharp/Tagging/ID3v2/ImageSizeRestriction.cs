using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[Guid("3A66EE62-F5EE-41b4-A11F-AC16602AB26F")]
	[ComVisible(true)]
	public enum ImageSizeRestriction : byte
	{
		NoRestrictions = 0,
		Max256x256 = 1,
		Max64x64 = 2,
		Exactly64x64 = 3
	}
}
