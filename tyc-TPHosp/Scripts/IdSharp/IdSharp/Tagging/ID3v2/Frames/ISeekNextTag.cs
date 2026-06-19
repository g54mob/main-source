using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ISeekNextTag : IFrame, INotifyPropertyChanged
	{
		int MinimumOffsetToNextTag { get; set; }
	}
}
