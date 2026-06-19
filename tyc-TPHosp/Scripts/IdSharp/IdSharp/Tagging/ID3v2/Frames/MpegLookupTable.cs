using System;
using System.ComponentModel;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames.Items;
using IdSharp.Tagging.ID3v2.Frames.Lists;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class MpegLookupTable : IMpegLookupTable, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private int m_FramesBetweenReference;

		private int m_BytesBetweenReference;

		private int m_MillisecondsBetweenReference;

		private MpegLookupTableItemBindingList m_MpegLookupTableItemBindingList;

		public int FramesBetweenReference
		{
			get
			{
				return m_FramesBetweenReference;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				if (value > 65535)
				{
					throw new ArgumentOutOfRangeException("Value cannot be greater than 0xFFFF");
				}
				m_FramesBetweenReference = value;
				FirePropertyChanged("FramesBetweenReference");
			}
		}

		public int BytesBetweenReference
		{
			get
			{
				return m_BytesBetweenReference;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				if (value > 16777215)
				{
					throw new ArgumentOutOfRangeException("Value cannot be greater than 0xFFFFFF");
				}
				m_BytesBetweenReference = value;
				FirePropertyChanged("BytesBetweenReference");
			}
		}

		public int MillisecondsBetweenReference
		{
			get
			{
				return m_MillisecondsBetweenReference;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				if (value > 16777215)
				{
					throw new ArgumentOutOfRangeException("Value cannot be greater than 0xFFFFFF");
				}
				m_MillisecondsBetweenReference = value;
				FirePropertyChanged("MillisecondsBetweenReference");
			}
		}

		public BindingList<IMpegLookupTableItem> Items => m_MpegLookupTableItemBindingList;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public MpegLookupTable()
		{
			m_FrameHeader = new FrameHeader();
			m_MpegLookupTableItemBindingList = new MpegLookupTableItemBindingList();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "MLLT";
			case ID3v2TagVersion.ID3v22:
				return "MLL";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_MpegLookupTableItemBindingList.Clear();
			throw new NotImplementedException();
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (FramesBetweenReference == 0 || BytesBetweenReference == 0 || MillisecondsBetweenReference == 0 || Items.Count == 0)
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
