using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class TermsOfUseBindingList : BindingList<ITermsOfUse>
	{
		public TermsOfUseBindingList()
		{
			base.AllowNew = true;
		}

		public TermsOfUseBindingList(IList<ITermsOfUse> urlList)
			: base(urlList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ITermsOfUse termsOfUse = new TermsOfUse();
			Add(termsOfUse);
			return termsOfUse;
		}

		protected override void InsertItem(int index, ITermsOfUse item)
		{
			base.InsertItem(index, item);
		}
	}
}
