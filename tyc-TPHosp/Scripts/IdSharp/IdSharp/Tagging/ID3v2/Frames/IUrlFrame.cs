using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IUrlFrame : IFrame, INotifyPropertyChanged
	{
		string Value { get; set; }
	}
}
