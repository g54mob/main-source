using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IPositionSynchronization : IFrame, INotifyPropertyChanged
	{
		TimestampFormat TimestampFormat { get; set; }

		int Position { get; set; }
	}
}
