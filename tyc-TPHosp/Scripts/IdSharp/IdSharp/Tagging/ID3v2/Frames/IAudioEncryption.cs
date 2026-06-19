using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IAudioEncryption : IFrame, INotifyPropertyChanged
	{
		string OwnerIdentifier { get; set; }

		short PreviewStart { get; set; }

		short PreviewLength { get; set; }

		byte[] EncryptionInfo { get; set; }
	}
}
