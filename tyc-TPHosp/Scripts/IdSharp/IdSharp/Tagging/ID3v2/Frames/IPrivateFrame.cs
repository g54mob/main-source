using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IPrivateFrame : IFrame, INotifyPropertyChanged
	{
		string OwnerIdentifier { get; set; }

		byte[] PrivateData { get; set; }
	}
}
