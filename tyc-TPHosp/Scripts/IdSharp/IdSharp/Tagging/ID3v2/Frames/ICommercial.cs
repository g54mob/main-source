using System;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface ICommercial : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		BindingList<IPriceInformation> PriceList { get; }

		DateTime ValidUntil { get; set; }

		string ContactUrl { get; set; }

		ReceivedAs ReceivedAs { get; set; }

		string NameOfSeller { get; set; }

		string Description { get; set; }

		string SellerLogoMimeType { get; set; }

		byte[] SellerLogo { get; set; }
	}
}
