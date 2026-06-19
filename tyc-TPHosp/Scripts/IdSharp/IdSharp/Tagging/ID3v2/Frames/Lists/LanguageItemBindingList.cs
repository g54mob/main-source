using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class LanguageItemBindingList : BindingList<ILanguageItem>
	{
		public LanguageItemBindingList()
		{
			base.AllowNew = true;
		}

		public LanguageItemBindingList(IList<ILanguageItem> languageItemList)
			: base(languageItemList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ILanguageItem languageItem = new LanguageItem();
			Add(languageItem);
			return languageItem;
		}

		protected override void InsertItem(int index, ILanguageItem item)
		{
			base.InsertItem(index, item);
		}
	}
}
