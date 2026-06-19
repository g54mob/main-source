using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class UserDefinedUrlBindingList : BindingList<IWXXXFrame>
	{
		public UserDefinedUrlBindingList()
		{
			base.AllowNew = true;
		}

		public UserDefinedUrlBindingList(IList<IWXXXFrame> userDefineUrlList)
			: base(userDefineUrlList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IWXXXFrame iWXXXFrame = new WXXXFrame();
			Add(iWXXXFrame);
			return iWXXXFrame;
		}

		protected override void InsertItem(int index, IWXXXFrame item)
		{
			base.InsertItem(index, item);
		}
	}
}
