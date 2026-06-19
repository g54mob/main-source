using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class EncryptedMetaFrameBindingList : BindingList<IEncryptedMetaFrame>
	{
		public EncryptedMetaFrameBindingList()
		{
			base.AllowNew = true;
		}

		public EncryptedMetaFrameBindingList(IList<IEncryptedMetaFrame> encryptedMetaFrameList)
			: base(encryptedMetaFrameList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IEncryptedMetaFrame encryptedMetaFrame = new EncryptedMetaFrame();
			Add(encryptedMetaFrame);
			return encryptedMetaFrame;
		}

		protected override void InsertItem(int index, IEncryptedMetaFrame item)
		{
			base.InsertItem(index, item);
		}
	}
}
