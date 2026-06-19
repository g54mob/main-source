using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ILinkedInformation : IFrame, INotifyPropertyChanged
	{
		string FrameIdentifier { get; set; }

		string Url { get; set; }

		byte[] AdditionalData { get; set; }
	}
}
