using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames.Lists
{
	internal sealed class UrlBindingList : BindingList<IUrlFrame>
	{
		private string m_ID3v24FrameID;

		private string m_ID3v23FrameID;

		private string m_ID3v22FrameID;

		public UrlBindingList(string ID3v24FrameID, string ID3v23FrameID, string ID3v22FrameID)
		{
			base.AllowNew = true;
			m_ID3v24FrameID = ID3v24FrameID;
			m_ID3v23FrameID = ID3v23FrameID;
			m_ID3v22FrameID = ID3v22FrameID;
		}

		public UrlBindingList(string ID3v24FrameID, string ID3v23FrameID, string ID3v22FrameID, IList<IUrlFrame> urlList)
			: base(urlList)
		{
			base.AllowNew = true;
			m_ID3v24FrameID = ID3v24FrameID;
			m_ID3v23FrameID = ID3v23FrameID;
			m_ID3v22FrameID = ID3v22FrameID;
		}

		public UrlBindingList()
		{
			throw new NotSupportedException("Use constructor with ID3v2 FrameID's");
		}

		public UrlBindingList(IList<IUrlFrame> urlList)
			: base(urlList)
		{
			throw new NotSupportedException("Use constructor with ID3v2 FrameID's");
		}

		protected override object AddNewCore()
		{
			IUrlFrame urlFrame = new UrlFrame(m_ID3v24FrameID, m_ID3v23FrameID, m_ID3v22FrameID);
			Add(urlFrame);
			return urlFrame;
		}

		protected override void InsertItem(int index, IUrlFrame item)
		{
			base.InsertItem(index, item);
		}
	}
}
