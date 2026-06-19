using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IEqualizationList : IFrame, INotifyPropertyChanged
	{
		InterpolationMethod InterpolationMethod { get; set; }

		string Identification { get; set; }

		BindingList<IEqualizationItem> Items { get; }
	}
}
