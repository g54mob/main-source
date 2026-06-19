using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IUniqueFileIdentifier : IFrame, INotifyPropertyChanged
	{
		string OwnerIdentifier { get; set; }

		byte[] Identifier { get; set; }
	}
}
