using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using IdSharp.Utils;

namespace IdSharp.Tagging.ID3v2
{
	[Guid("2E3A01D6-C3DE-4e43-B67F-F3E067C7FF23")]
	[ComVisible(true)]
	public interface IID3v2 : IFrameContainer, INotifyPropertyChanged, INotifyInvalidData
	{
		[DispId(101)]
		IID3v2Header Header { get; }

		[DispId(102)]
		IID3v2ExtendedHeader ExtendedHeader { get; }

		[DispId(103)]
		void Read(string path);

		[DispId(104)]
		void ReadStream(Stream stream);

		[DispId(105)]
		void Save(string path);

		[DispId(106)]
		void SaveEncoding(string path, EncodingType encodingType);

		[DispId(107)]
		byte[] GetBytes(int minimumSize);
	}
}
