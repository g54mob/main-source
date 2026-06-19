using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2.Frames
{
	[Guid("566A1DEE-D0F6-45a0-A215-0769893E5410")]
	[ComVisible(true)]
	public interface IFrame : INotifyPropertyChanged
	{
		[DispId(1000)]
		IFrameHeader FrameHeader { get; }

		[DispId(1001)]
		string GetFrameID(ID3v2TagVersion tagVersion);

		[DispId(1002)]
		void Read(TagReadingInfo tagReadingInfo, Stream stream);

		[DispId(1003)]
		byte[] GetBytes(ID3v2TagVersion tagVersion);
	}
}
