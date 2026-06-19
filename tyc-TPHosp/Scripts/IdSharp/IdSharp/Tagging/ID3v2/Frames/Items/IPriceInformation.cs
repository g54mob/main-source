using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Items
{
	public interface IPriceInformation : INotifyPropertyChanged
	{
		string CurrencyCode { get; set; }

		double Price { get; set; }
	}
}
