using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IComments : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string LanguageCode { get; set; }

		string Description { get; set; }

		string Value { get; set; }
	}
}
