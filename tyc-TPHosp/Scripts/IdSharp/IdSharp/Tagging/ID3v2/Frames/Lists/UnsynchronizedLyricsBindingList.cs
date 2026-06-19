using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class UnsynchronizedLyricsBindingList : BindingList<IUnsynchronizedText>
	{
		public UnsynchronizedLyricsBindingList()
		{
			base.AllowNew = true;
		}

		public UnsynchronizedLyricsBindingList(IList<IUnsynchronizedText> urlList)
			: base(urlList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IUnsynchronizedText unsynchronizedText = new UnsynchronizedText();
			Add(unsynchronizedText);
			return unsynchronizedText;
		}

		protected override void InsertItem(int index, IUnsynchronizedText item)
		{
			base.InsertItem(index, item);
		}
	}
}
