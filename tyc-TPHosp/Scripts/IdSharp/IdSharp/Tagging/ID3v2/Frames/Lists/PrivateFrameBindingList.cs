using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class PrivateFrameBindingList : BindingList<IPrivateFrame>
	{
		public PrivateFrameBindingList()
		{
			base.AllowNew = true;
		}

		public PrivateFrameBindingList(IList<IPrivateFrame> privateFrameList)
			: base(privateFrameList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IPrivateFrame privateFrame = new PrivateFrame();
			Add(privateFrame);
			return privateFrame;
		}

		protected override void InsertItem(int index, IPrivateFrame item)
		{
			base.InsertItem(index, item);
		}
	}
}
