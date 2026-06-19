using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ITXXXFrame : ITextFrame, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string Description { get; set; }
	}
}
