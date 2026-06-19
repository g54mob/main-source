using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class InvolvedPersonBindingList : BindingList<IInvolvedPerson>
	{
		public InvolvedPersonBindingList()
		{
			base.AllowNew = true;
		}

		public InvolvedPersonBindingList(IList<IInvolvedPerson> involvedPersonList)
			: base(involvedPersonList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IInvolvedPerson involvedPerson = new InvolvedPerson();
			Add(involvedPerson);
			return involvedPerson;
		}

		protected override void InsertItem(int index, IInvolvedPerson item)
		{
			base.InsertItem(index, item);
		}
	}
}
