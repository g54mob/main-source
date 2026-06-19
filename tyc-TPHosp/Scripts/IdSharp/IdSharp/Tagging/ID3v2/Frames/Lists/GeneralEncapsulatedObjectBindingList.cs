using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class GeneralEncapsulatedObjectBindingList : BindingList<IGeneralEncapsulatedObject>
	{
		public GeneralEncapsulatedObjectBindingList()
		{
			base.AllowNew = true;
		}

		public GeneralEncapsulatedObjectBindingList(IList<IGeneralEncapsulatedObject> generalEncapsulatedObjectList)
			: base(generalEncapsulatedObjectList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IGeneralEncapsulatedObject generalEncapsulatedObject = new GeneralEncapsulatedObject();
			Add(generalEncapsulatedObject);
			return generalEncapsulatedObject;
		}

		protected override void InsertItem(int index, IGeneralEncapsulatedObject item)
		{
			base.InsertItem(index, item);
		}
	}
}
