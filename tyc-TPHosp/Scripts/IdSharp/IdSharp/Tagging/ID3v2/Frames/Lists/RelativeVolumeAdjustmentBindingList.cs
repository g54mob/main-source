using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class RelativeVolumeAdjustmentBindingList : BindingList<IRelativeVolumeAdjustment>
	{
		public RelativeVolumeAdjustmentBindingList()
		{
			base.AllowNew = true;
		}

		public RelativeVolumeAdjustmentBindingList(IList<IRelativeVolumeAdjustment> relativeVolumeAdjustmentList)
			: base(relativeVolumeAdjustmentList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IRelativeVolumeAdjustment relativeVolumeAdjustment = new RelativeVolumeAdjustment();
			Add(relativeVolumeAdjustment);
			return relativeVolumeAdjustment;
		}

		protected override void InsertItem(int index, IRelativeVolumeAdjustment item)
		{
			base.InsertItem(index, item);
		}
	}
}
