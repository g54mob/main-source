using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class SynchronizedTextBindingList : BindingList<ISynchronizedText>
	{
		public SynchronizedTextBindingList()
		{
			base.AllowNew = true;
		}

		public SynchronizedTextBindingList(IList<ISynchronizedText> synchronizedTextList)
			: base(synchronizedTextList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ISynchronizedText synchronizedText = new SynchronizedText();
			Add(synchronizedText);
			return synchronizedText;
		}

		protected override void InsertItem(int index, ISynchronizedText item)
		{
			base.InsertItem(index, item);
		}
	}
}
