using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IAudioSeekPointIndex : IFrame, INotifyPropertyChanged
	{
		int IndexedDataStart { get; set; }

		int IndexedDataLength { get; set; }

		byte BitsPerIndexPoint { get; set; }

		BindingList<short> FractionAtIndex { get; }
	}
}
