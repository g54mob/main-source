using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface IMusicianCreditsItem : INotifyPropertyChanged
	{
		string Instrument { get; set; }

		string Artists { get; set; }
	}
}
