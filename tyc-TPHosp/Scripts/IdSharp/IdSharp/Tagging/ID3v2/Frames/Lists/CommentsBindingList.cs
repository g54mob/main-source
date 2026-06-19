using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class CommentsBindingList : BindingList<IComments>
	{
		public CommentsBindingList()
		{
			base.AllowNew = true;
		}

		public CommentsBindingList(IList<IComments> commentList)
			: base(commentList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IComments comments = new Comments();
			Add(comments);
			return comments;
		}

		protected override void InsertItem(int index, IComments item)
		{
			foreach (IComments item2 in base.Items)
			{
				_ = item2;
			}
			base.InsertItem(index, item);
		}
	}
}
