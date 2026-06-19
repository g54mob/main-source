using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ISignature : IFrame, INotifyPropertyChanged
	{
		byte GroupSymbol { get; set; }

		byte[] SignatureData { get; set; }
	}
}
