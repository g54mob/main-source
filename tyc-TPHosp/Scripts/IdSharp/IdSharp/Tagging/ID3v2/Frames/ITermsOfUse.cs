using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ITermsOfUse : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string LanguageCode { get; set; }

		string Value { get; set; }
	}
}
