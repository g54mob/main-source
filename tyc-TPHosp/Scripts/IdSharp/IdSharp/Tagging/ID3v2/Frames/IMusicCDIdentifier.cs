using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IMusicCDIdentifier : IFrame, INotifyPropertyChanged
	{
		byte[] TOC { get; set; }
	}
}
