using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IMpegLookupTable : IFrame, INotifyPropertyChanged
	{
		int FramesBetweenReference { get; set; }

		int BytesBetweenReference { get; set; }

		int MillisecondsBetweenReference { get; set; }

		BindingList<IMpegLookupTableItem> Items { get; }
	}
}
