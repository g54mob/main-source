using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ISynchronizedTempoCodes : IFrame, INotifyPropertyChanged
	{
		TimestampFormat TimestampFormat { get; set; }

		BindingList<ITempoData> Items { get; }
	}
}
