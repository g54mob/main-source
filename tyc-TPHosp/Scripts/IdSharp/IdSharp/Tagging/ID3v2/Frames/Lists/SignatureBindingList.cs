using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class SignatureBindingList : BindingList<ISignature>
	{
		public SignatureBindingList()
		{
			base.AllowNew = true;
		}

		public SignatureBindingList(IList<ISignature> signatureList)
			: base(signatureList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ISignature signature = new Signature();
			Add(signature);
			return signature;
		}

		protected override void InsertItem(int index, ISignature item)
		{
			base.InsertItem(index, item);
		}
	}
}
