using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface IMpegLookupTableItem : INotifyPropertyChanged
	{
		long DeviationInBytes { get; set; }

		long DeviationInMilliseconds { get; set; }
	}
}
