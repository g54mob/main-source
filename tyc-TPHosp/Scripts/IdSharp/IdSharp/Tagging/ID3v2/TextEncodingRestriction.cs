using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[ComVisible(true)]
	[Guid("84024D1C-4418-4997-8059-432B0C53E7F7")]
	public enum TextEncodingRestriction : byte
	{
		NoRestrictions = 0,
		ISO88591orUTF8 = 1
	}
}
