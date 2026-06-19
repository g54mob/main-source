using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ILanguageFrame : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		BindingList<ILanguageItem> Items { get; }
	}
}
