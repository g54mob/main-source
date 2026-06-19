using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IWXXXFrame : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string Description { get; set; }

		string Value { get; set; }
	}
}
