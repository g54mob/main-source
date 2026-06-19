using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class EqualizationListBindingList : BindingList<IEqualizationList>
	{
		public EqualizationListBindingList()
		{
			base.AllowNew = true;
		}

		public EqualizationListBindingList(IList<IEqualizationList> equalizationListList)
			: base(equalizationListList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IEqualizationList equalizationList = new EqualizationList();
			Add(equalizationList);
			return equalizationList;
		}

		protected override void InsertItem(int index, IEqualizationList item)
		{
			base.InsertItem(index, item);
		}
	}
}
