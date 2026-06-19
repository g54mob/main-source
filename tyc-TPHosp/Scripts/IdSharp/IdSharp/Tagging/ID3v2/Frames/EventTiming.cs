using System;
using System.ComponentModel;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames.Items;
using IdSharp.Tagging.ID3v2.Frames.Lists;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class EventTiming : IEventTiming, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private TimestampFormat m_TimestampFormat;

		private EventTimingItemBindingList m_EventTimingItemBindingList;

		public TimestampFormat TimestampFormat
		{
			get
			{
				return m_TimestampFormat;
			}
			set
			{
				m_TimestampFormat = value;
				FirePropertyChanged("TimestampFormat");
			}
		}

		public BindingList<IEventTimingItem> Items => m_EventTimingItemBindingList;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public EventTiming()
		{
			m_FrameHeader = new FrameHeader();
			m_EventTimingItemBindingList = new EventTimingItemBindingList();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "ETCO";
			case ID3v2TagVersion.ID3v22:
				return "ETC";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_EventTimingItemBindingList.Clear();
			throw new NotImplementedException();
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (Items.Count == 0)
			{
				return new byte[0];
			}
			throw new NotImplementedException();
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
