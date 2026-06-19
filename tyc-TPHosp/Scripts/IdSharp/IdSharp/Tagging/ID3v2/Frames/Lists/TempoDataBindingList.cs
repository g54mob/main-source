using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.Tagging.ID3v2.Frames.Items;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class TempoDataBindingList : BindingList<ITempoData>
	{
		public TempoDataBindingList()
		{
			base.AllowNew = true;
		}

		public TempoDataBindingList(IList<ITempoData> tempoDataList)
			: base(tempoDataList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			ITempoData tempoData = new TempoData();
			Add(tempoData);
			return tempoData;
		}

		protected override void InsertItem(int index, ITempoData item)
		{
			base.InsertItem(index, item);
		}
	}
}
