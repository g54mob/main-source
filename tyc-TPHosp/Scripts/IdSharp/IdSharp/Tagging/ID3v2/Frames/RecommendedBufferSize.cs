using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class RecommendedBufferSize : IRecommendedBufferSize, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private int m_BufferSize;

		private bool m_EmbeddedInfo;

		private int? m_OffsetToNextTag;

		public int BufferSize
		{
			get
			{
				return m_BufferSize;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_BufferSize = value;
				FirePropertyChanged("BufferSize");
			}
		}

		public bool EmbeddedInfo
		{
			get
			{
				return m_EmbeddedInfo;
			}
			set
			{
				m_EmbeddedInfo = value;
				FirePropertyChanged("EmbeddedInfo");
			}
		}

		public int? OffsetToNextTag
		{
			get
			{
				return m_OffsetToNextTag;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_OffsetToNextTag = value;
				FirePropertyChanged("OffsetToNextTag");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public RecommendedBufferSize()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "RBUF";
			case ID3v2TagVersion.ID3v22:
				return "BUF";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			throw new NotImplementedException();
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (BufferSize == 0)
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
