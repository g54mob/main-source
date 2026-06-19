using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class LinkedInformation : ILinkedInformation, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_FrameIdentifier;

		private string m_Url;

		private byte[] m_AdditionalData;

		public string FrameIdentifier
		{
			get
			{
				return m_FrameIdentifier;
			}
			set
			{
				m_FrameIdentifier = value;
				FirePropertyChanged("FrameIdentifier");
			}
		}

		public string Url
		{
			get
			{
				return m_Url;
			}
			set
			{
				m_Url = value;
				FirePropertyChanged("Url");
			}
		}

		public byte[] AdditionalData
		{
			get
			{
				if (m_AdditionalData == null)
				{
					return null;
				}
				return (byte[])m_AdditionalData.Clone();
			}
			set
			{
				if (value == null)
				{
					m_AdditionalData = null;
				}
				else
				{
					m_AdditionalData = (byte[])value.Clone();
				}
				FirePropertyChanged("AdditionalData");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public LinkedInformation()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "LINK";
			case ID3v2TagVersion.ID3v22:
				return "LNK";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int frameSizeExcludingAdditions = m_FrameHeader.FrameSizeExcludingAdditions;
			int num = ((tagReadingInfo.TagVersion == ID3v2TagVersion.ID3v22) ? 3 : 4);
			if (frameSizeExcludingAdditions > num)
			{
				FrameIdentifier = Utils.ReadString(EncodingType.ISO88591, stream, num);
				frameSizeExcludingAdditions -= num;
				Url = Utils.ReadString(EncodingType.ISO88591, stream, ref frameSizeExcludingAdditions);
				AdditionalData = Utils.Read(stream, frameSizeExcludingAdditions);
			}
			else
			{
				stream.Seek(frameSizeExcludingAdditions, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_AdditionalData == null && m_AdditionalData.Length == 0)
			{
				return new byte[0];
			}
			if (tagVersion == ID3v2TagVersion.ID3v22)
			{
				if (m_FrameIdentifier == null || m_FrameIdentifier.Length != 3)
				{
					return new byte[0];
				}
			}
			else if (m_FrameIdentifier == null || m_FrameIdentifier.Length != 4)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_FrameIdentifier));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, EncodingType.ISO88591, m_Url, isTerminated: true));
			Utils.Write(memoryStream, m_AdditionalData);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
