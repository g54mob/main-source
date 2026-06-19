using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class AudioTextBindingList : BindingList<IAudioText>
	{
		public AudioTextBindingList()
		{
			base.AllowNew = true;
		}

		public AudioTextBindingList(IList<IAudioText> audioTextList)
			: base(audioTextList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IAudioText audioText = new AudioText();
			Add(audioText);
			return audioText;
		}

		protected override void InsertItem(int index, IAudioText item)
		{
			base.InsertItem(index, item);
		}
	}
}
