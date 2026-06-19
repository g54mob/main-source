using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface IInvolvedPerson : INotifyPropertyChanged
	{
		string Name { get; set; }

		string Involvement { get; set; }
	}
}
