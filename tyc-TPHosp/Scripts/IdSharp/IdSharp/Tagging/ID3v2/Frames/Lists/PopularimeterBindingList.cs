using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class PopularimeterBindingList : BindingList<IPopularimeter>
	{
		public PopularimeterBindingList()
		{
			base.AllowNew = true;
		}

		public PopularimeterBindingList(IList<IPopularimeter> popularimeterList)
			: base(popularimeterList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IPopularimeter popularimeter = new Popularimeter();
			Add(popularimeter);
			return popularimeter;
		}

		protected override void InsertItem(int index, IPopularimeter item)
		{
			base.InsertItem(index, item);
		}
	}
}
