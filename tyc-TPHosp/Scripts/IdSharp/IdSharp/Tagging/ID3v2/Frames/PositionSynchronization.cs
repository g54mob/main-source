using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class PositionSynchronization : IPositionSynchronization, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private TimestampFormat m_TimestampFormat;

		private int m_Position;

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

		public int Position
		{
			get
			{
				return m_Position;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_Position = value;
				FirePropertyChanged("Position");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public PositionSynchronization()
		{
			m_FrameHeader = new FrameHeader();
			m_TimestampFormat = TimestampFormat.Milliseconds;
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "POSS";
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
			if (Position == 0)
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
