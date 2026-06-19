using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface ITempoData : INotifyPropertyChanged
	{
		short TempoCode { get; set; }

		int Timestamp { get; set; }
	}
}
