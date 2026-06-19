using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class EventTimingItemBindingList : BindingList<IEventTimingItem>
	{
		public EventTimingItemBindingList()
		{
			base.AllowNew = true;
		}

		public EventTimingItemBindingList(IList<IEventTimingItem> eventTimingItemList)
			: base(eventTimingItemList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IEventTimingItem eventTimingItem = new EventTimingItem();
			Add(eventTimingItem);
			return eventTimingItem;
		}

		protected override void InsertItem(int index, IEventTimingItem item)
		{
			base.InsertItem(index, item);
		}
	}
}
