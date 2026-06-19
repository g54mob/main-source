using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class PriceInformationBindingList : BindingList<IPriceInformation>
	{
		public PriceInformationBindingList()
		{
			base.AllowNew = true;
		}

		public PriceInformationBindingList(IList<IPriceInformation> priceInformationList)
			: base(priceInformationList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IPriceInformation priceInformation = new PriceInformation();
			Add(priceInformation);
			return priceInformation;
		}

		protected override void InsertItem(int index, IPriceInformation item)
		{
			base.InsertItem(index, item);
		}
	}
}
