using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class MusicianCreditsItemBindingList : BindingList<IMusicianCreditsItem>
	{
		public MusicianCreditsItemBindingList()
		{
			base.AllowNew = true;
		}

		public MusicianCreditsItemBindingList(IList<IMusicianCreditsItem> musicianCreditsItemList)
			: base(musicianCreditsItemList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IMusicianCreditsItem musicianCreditsItem = new MusicianCreditsItem();
			Add(musicianCreditsItem);
			return musicianCreditsItem;
		}

		protected override void InsertItem(int index, IMusicianCreditsItem item)
		{
			base.InsertItem(index, item);
		}
	}
}
