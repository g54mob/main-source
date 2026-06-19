using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class CommercialBindingList : BindingList<ICommercial>
	{
		public CommercialBindingList()
		{
			base.AllowNew = true;
		}

		public CommercialBindingList(IList<ICommercial> commercialInfoList)
			: base(commercialInfoList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ICommercial commercial = new Commercial();
			Add(commercial);
			return commercial;
		}

		protected override void InsertItem(int index, ICommercial item)
		{
			base.InsertItem(index, item);
		}
	}
}
