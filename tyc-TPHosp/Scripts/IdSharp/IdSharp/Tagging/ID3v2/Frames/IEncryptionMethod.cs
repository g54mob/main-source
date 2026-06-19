using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IEncryptionMethod : IFrame, INotifyPropertyChanged
	{
		string OwnerIdentifier { get; set; }

		byte MethodSymbol { get; set; }

		byte[] EncryptionData { get; set; }
	}
}
