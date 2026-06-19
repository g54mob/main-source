using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ISynchronizedText : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string LanguageCode { get; set; }

		TimestampFormat TimestampFormat { get; set; }

		TextContentType ContentType { get; set; }

		string ContentDescriptor { get; set; }

		BindingList<ISynchronizedTextItem> Items { get; }
	}
}
