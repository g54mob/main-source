using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface ILanguageItem : INotifyPropertyChanged
	{
		string LanguageCode { get; set; }

		string LanguageDisplay { get; }
	}
}
