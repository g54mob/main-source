using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface IEventTimingItem : INotifyPropertyChanged
	{
		MusicEvent EventType { get; set; }

		int Timestamp { get; set; }
	}
}
