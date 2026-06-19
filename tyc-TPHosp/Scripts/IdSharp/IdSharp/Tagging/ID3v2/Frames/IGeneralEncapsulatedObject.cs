using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IGeneralEncapsulatedObject : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string MimeType { get; set; }

		string FileName { get; set; }

		string Description { get; set; }

		byte[] EncapsulatedObject { get; set; }
	}
}
