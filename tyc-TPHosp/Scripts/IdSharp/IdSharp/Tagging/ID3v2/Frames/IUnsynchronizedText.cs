using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IUnsynchronizedText : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string LanguageCode { get; set; }

		string ContentDescriptor { get; set; }

		string Text { get; set; }
	}
}
