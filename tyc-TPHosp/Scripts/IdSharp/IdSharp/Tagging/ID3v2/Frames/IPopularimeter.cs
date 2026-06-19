using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IPopularimeter : IFrame, INotifyPropertyChanged
	{
		string UserEmail { get; set; }

		byte Rating { get; set; }

		long PlayCount { get; set; }
	}
}
