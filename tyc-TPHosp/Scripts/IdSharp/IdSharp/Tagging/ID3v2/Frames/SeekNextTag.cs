using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class SeekNextTag : ISeekNextTag, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private int m_MinimumOffsetToNextTag;

		public int MinimumOffsetToNextTag
		{
			get
			{
				return m_MinimumOffsetToNextTag;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_MinimumOffsetToNextTag = value;
				FirePropertyChanged("MinimumOffsetToNextTag");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public SeekNextTag()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "SEEK";
			case ID3v2TagVersion.ID3v22:
				return null;
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
			if (m_MinimumOffsetToNextTag == 0)
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
