using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class UniqueFileIdentifierBindingList : BindingList<IUniqueFileIdentifier>
	{
		public UniqueFileIdentifierBindingList()
		{
			base.AllowNew = true;
		}

		public UniqueFileIdentifierBindingList(IList<IUniqueFileIdentifier> uniqueFileIdentifierList)
			: base(uniqueFileIdentifierList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IUniqueFileIdentifier uniqueFileIdentifier = new UniqueFileIdentifier();
			Add(uniqueFileIdentifier);
			return uniqueFileIdentifier;
		}

		protected override void InsertItem(int index, IUniqueFileIdentifier item)
		{
			base.InsertItem(index, item);
		}
	}
}
