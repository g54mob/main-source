using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IEncryptedMetaFrame : IFrame, INotifyPropertyChanged
	{
		string OwnerIdentifier { get; set; }

		string ContentExplanation { get; set; }

		byte[] EncryptedData { get; set; }
	}
}
