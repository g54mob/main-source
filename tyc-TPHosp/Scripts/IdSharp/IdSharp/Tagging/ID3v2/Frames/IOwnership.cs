using System;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IOwnership : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		double PricePaid { get; set; }

		string CurrencyCode { get; set; }

		DateTime DateOfPurchase { get; set; }

		string Seller { get; set; }
	}
}
