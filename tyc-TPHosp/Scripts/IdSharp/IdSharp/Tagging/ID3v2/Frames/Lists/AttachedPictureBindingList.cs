using System.Collections.Generic;
using System.ComponentModel;
using IdSharp.ComInterop;
using IdSharp.Utils;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class AttachedPictureBindingList : BindingList<IAttachedPicture>, IFrameList
	{
		object IFrameList.this[int index]
		{
			get
			{
				return base[index];
			}
			set
			{
				base[index] = (IAttachedPicture)value;
			}
		}

		int IFrameList.Count => base.Count;

		public AttachedPictureBindingList()
		{
			base.AllowNew = true;
		}

		public AttachedPictureBindingList(IList<IAttachedPicture> attachedPictureList)
			: base(attachedPictureList)
		{
			base.AllowNew = true;
		}

		protected override object AddNewCore()
		{
			IAttachedPicture attachedPicture = new AttachedPicture();
			Add(attachedPicture);
			return attachedPicture;
		}

		private void AttachedPicture_PictureTypeChanging(object sender, CancelDataEventArgs<PictureType> e)
		{
			foreach (IAttachedPicture item in base.Items)
			{
				if ((e.Data == PictureType.OtherFileIcon && item.PictureType == PictureType.OtherFileIcon) || (e.Data == PictureType.FileIcon32x32Png && item.PictureType == PictureType.FileIcon32x32Png))
				{
					break;
				}
			}
		}

		private void AttachedPicture_DescriptionChanging(object sender, CancelDataEventArgs<string> e)
		{
			if (string.IsNullOrEmpty(e.Data))
			{
				return;
			}
			foreach (IAttachedPicture item in base.Items)
			{
				if (item != sender && !string.IsNullOrEmpty(item.Description) && string.Compare(item.Description, e.Data, ignoreCase: false) == 0)
				{
					break;
				}
			}
		}

		protected override void InsertItem(int index, IAttachedPicture item)
		{
			base.InsertItem(index, item);
		}

		object IFrameList.AddNew()
		{
			return AddNew();
		}

		int IFrameList.Add(object value)
		{
			IAttachedPicture item = (IAttachedPicture)value;
			Add(item);
			return IndexOf(item);
		}

		void IFrameList.Clear()
		{
			Clear();
		}

		void IFrameList.Remove(object value)
		{
			Remove((IAttachedPicture)value);
		}

		void IFrameList.RemoveAt(int index)
		{
			RemoveAt(index);
		}
	}
}
