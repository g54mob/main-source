using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class EncryptionMethodBindingList : BindingList<IEncryptionMethod>
	{
		public EncryptionMethodBindingList()
		{
			base.AllowNew = true;
		}

		public EncryptionMethodBindingList(IList<IEncryptionMethod> encryptionMethodList)
			: base(encryptionMethodList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IEncryptionMethod encryptionMethod = new EncryptionMethod();
			Add(encryptionMethod);
			return encryptionMethod;
		}

		protected override void InsertItem(int index, IEncryptionMethod item)
		{
			base.InsertItem(index, item);
		}
	}
}
