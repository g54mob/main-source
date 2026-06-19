using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2.Frames
{
	[ComVisible(true)]
	[Guid("6748D4CF-AD6E-4319-A44A-785F7ACD9867")]
	public interface ITextEncoding
	{
		[DispId(1100)]
		EncodingType TextEncoding { get; set; }
	}
}
