using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class Popularimeter : IPopularimeter, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_UserEmail;

		private byte m_Rating;

		private long m_PlayCount;

		public string UserEmail
		{
			get
			{
				return m_UserEmail;
			}
			set
			{
				m_UserEmail = value;
				FirePropertyChanged("UserEmail");
			}
		}

		public byte Rating
		{
			get
			{
				return m_Rating;
			}
			set
			{
				m_Rating = value;
				FirePropertyChanged("Rating");
			}
		}

		public long PlayCount
		{
			get
			{
				return m_PlayCount;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Value cannot be less than 0");
				}
				m_PlayCount = value;
				FirePropertyChanged("PlayCount");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public Popularimeter()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "POPM";
			case ID3v2TagVersion.ID3v22:
				return "POP";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft > 0)
			{
				UserEmail = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
				if (bytesLeft > 0)
				{
					Rating = Utils.ReadByte(stream, ref bytesLeft);
					if (bytesLeft > 0)
					{
						byte[] byteArray = Utils.Read(stream, bytesLeft);
						PlayCount = Utils.ConvertToInt64(byteArray);
					}
					else
					{
						PlayCount = 0L;
					}
				}
				else
				{
					Rating = 0;
					PlayCount = 0L;
				}
			}
			else
			{
				UserEmail = null;
				Rating = 0;
				PlayCount = 0L;
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_Rating == 0 && m_PlayCount == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, EncodingType.ISO88591, m_UserEmail, isTerminated: true));
			memoryStream.WriteByte(m_Rating);
			Utils.Write(memoryStream, Utils.GetBytesMinimal(m_PlayCount));
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
