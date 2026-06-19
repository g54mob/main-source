using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class PlayCount : IPlayCount, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private long? m_Value;

		public long? Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_Value = value;
				FirePropertyChanged("Value");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public PlayCount()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "PCNT";
			case ID3v2TagVersion.ID3v22:
				return "CNT";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			long num = 0L;
			while (bytesLeft > 0)
			{
				num <<= 8;
				num += Utils.ReadByte(stream, ref bytesLeft);
			}
			Value = num;
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (!m_Value.HasValue)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			if (Value <= uint.MaxValue)
			{
				Utils.Write(memoryStream, Utils.Get4Bytes((uint)Value.Value));
			}
			else
			{
				Utils.Write(memoryStream, Utils.GetBytesMinimal(Value.Value));
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
