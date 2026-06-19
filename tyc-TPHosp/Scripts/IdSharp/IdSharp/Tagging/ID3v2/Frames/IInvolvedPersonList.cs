using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IInvolvedPersonList : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		BindingList<IInvolvedPerson> Items { get; }
	}
}
