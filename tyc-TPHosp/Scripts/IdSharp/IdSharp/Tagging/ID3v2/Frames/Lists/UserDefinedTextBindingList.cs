using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class UserDefinedTextBindingList : BindingList<ITXXXFrame>
	{
		public UserDefinedTextBindingList()
		{
			base.AllowNew = true;
		}

		public UserDefinedTextBindingList(IList<ITXXXFrame> userDefineTextList)
			: base(userDefineTextList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ITXXXFrame iTXXXFrame = new TXXXFrame();
			Add(iTXXXFrame);
			return iTXXXFrame;
		}

		protected override void InsertItem(int index, ITXXXFrame item)
		{
			foreach (ITXXXFrame item2 in base.Items)
			{
				_ = item2;
			}
			base.InsertItem(index, item);
		}
	}
}
