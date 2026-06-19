using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class EqualizationItemBindingList : BindingList<IEqualizationItem>
	{
		public EqualizationItemBindingList()
		{
			base.AllowNew = true;
		}

		public EqualizationItemBindingList(IList<IEqualizationItem> equalizationItemList)
			: base(equalizationItemList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IEqualizationItem equalizationItem = new EqualizationItem();
			Add(equalizationItem);
			return equalizationItem;
		}

		protected override void InsertItem(int index, IEqualizationItem item)
		{
			base.InsertItem(index, item);
		}
	}
}
