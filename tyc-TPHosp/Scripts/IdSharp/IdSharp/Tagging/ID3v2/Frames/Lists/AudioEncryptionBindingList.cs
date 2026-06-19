using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class AudioEncryptionBindingList : BindingList<IAudioEncryption>
	{
		public AudioEncryptionBindingList()
		{
			base.AllowNew = true;
		}

		public AudioEncryptionBindingList(IList<IAudioEncryption> audioEncryptionList)
			: base(audioEncryptionList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IAudioEncryption audioEncryption = new AudioEncryption();
			Add(audioEncryption);
			return audioEncryption;
		}

		protected override void InsertItem(int index, IAudioEncryption item)
		{
			base.InsertItem(index, item);
		}
	}
}
