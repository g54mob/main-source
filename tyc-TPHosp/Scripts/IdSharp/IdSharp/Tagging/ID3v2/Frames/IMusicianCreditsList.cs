using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IMusicianCreditsList : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		BindingList<IMusicianCreditsItem> Items { get; }
	}
}
