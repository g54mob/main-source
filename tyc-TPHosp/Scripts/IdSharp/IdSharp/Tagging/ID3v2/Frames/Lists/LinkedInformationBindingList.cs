using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class LinkedInformationBindingList : BindingList<ILinkedInformation>
	{
		public LinkedInformationBindingList()
		{
			base.AllowNew = true;
		}

		public LinkedInformationBindingList(IList<ILinkedInformation> linkedInformationList)
			: base(linkedInformationList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ILinkedInformation linkedInformation = new LinkedInformation();
			Add(linkedInformation);
			return linkedInformation;
		}

		protected override void InsertItem(int index, ILinkedInformation item)
		{
			base.InsertItem(index, item);
		}
	}
}
