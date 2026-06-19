using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class GroupIdentificationBindingList : BindingList<IGroupIdentification>
	{
		public GroupIdentificationBindingList()
		{
			base.AllowNew = true;
		}

		public GroupIdentificationBindingList(IList<IGroupIdentification> groupIdentificationList)
			: base(groupIdentificationList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IGroupIdentification groupIdentification = new GroupIdentification();
			Add(groupIdentification);
			return groupIdentification;
		}

		protected override void InsertItem(int index, IGroupIdentification item)
		{
			base.InsertItem(index, item);
		}
	}
}
