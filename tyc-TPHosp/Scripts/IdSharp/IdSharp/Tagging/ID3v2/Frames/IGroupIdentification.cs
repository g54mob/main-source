using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IGroupIdentification : IFrame, INotifyPropertyChanged
	{
		string OwnerIdentifier { get; set; }

		byte GroupSymbol { get; set; }

		byte[] GroupDependentData { get; set; }
	}
}
