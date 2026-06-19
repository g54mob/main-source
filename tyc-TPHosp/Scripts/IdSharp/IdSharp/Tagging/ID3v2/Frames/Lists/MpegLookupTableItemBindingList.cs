using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class MpegLookupTableItemBindingList : BindingList<IMpegLookupTableItem>
	{
		public MpegLookupTableItemBindingList()
		{
			base.AllowNew = true;
		}

		public MpegLookupTableItemBindingList(IList<IMpegLookupTableItem> mpegLookupTableItemList)
			: base(mpegLookupTableItemList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IMpegLookupTableItem mpegLookupTableItem = new MpegLookupTableItem();
			Add(mpegLookupTableItem);
			return mpegLookupTableItem;
		}

		protected override void InsertItem(int index, IMpegLookupTableItem item)
		{
			base.InsertItem(index, item);
		}
	}
}
