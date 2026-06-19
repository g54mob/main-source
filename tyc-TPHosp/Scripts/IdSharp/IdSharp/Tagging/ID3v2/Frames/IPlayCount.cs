using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IPlayCount : IFrame, INotifyPropertyChanged
	{
		long? Value { get; set; }
	}
}
