using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class SynchronizedTextItemBindingList : BindingList<ISynchronizedTextItem>
	{
		public SynchronizedTextItemBindingList()
		{
			base.AllowNew = true;
		}

		public SynchronizedTextItemBindingList(IList<ISynchronizedTextItem> synchronizedTextItemList)
			: base(synchronizedTextItemList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ISynchronizedTextItem synchronizedTextItem = new SynchronizedTextItem();
			Add(synchronizedTextItem);
			return synchronizedTextItem;
		}

		protected override void InsertItem(int index, ISynchronizedTextItem item)
		{
			base.InsertItem(index, item);
		}
	}
}
