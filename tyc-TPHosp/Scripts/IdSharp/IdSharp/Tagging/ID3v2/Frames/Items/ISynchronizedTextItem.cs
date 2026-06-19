using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface ISynchronizedTextItem : INotifyPropertyChanged
	{
		string Text { get; set; }

		int Timestamp { get; set; }
	}
}
