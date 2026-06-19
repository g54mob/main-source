using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ITextFrame : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string Value { get; set; }
	}
}
