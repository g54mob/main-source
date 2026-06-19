using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class TermsOfUse : ITermsOfUse, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_LanguageCode;

		private string m_Value;

		public EncodingType TextEncoding
		{
			get
			{
				return m_TextEncoding;
			}
			set
			{
				m_TextEncoding = value;
				FirePropertyChanged("TextEncoding");
			}
		}

		public string LanguageCode
		{
			get
			{
				return m_LanguageCode;
			}
			set
			{
				m_LanguageCode = value;
				FirePropertyChanged("LanguageCode");
			}
		}

		public string Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
				FirePropertyChanged("Value");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public TermsOfUse()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "USER";
			case ID3v2TagVersion.ID3v22:
				return null;
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft >= 1)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
				if (bytesLeft >= 3)
				{
					LanguageCode = Utils.ReadString(EncodingType.ISO88591, stream, 3);
					bytesLeft -= 3;
					if (bytesLeft > 0)
					{
						Value = Utils.ReadString(TextEncoding, stream, bytesLeft);
						bytesLeft = 0;
					}
				}
				else
				{
					LanguageCode = "eng";
				}
			}
			else
			{
				TextEncoding = EncodingType.ISO88591;
				LanguageCode = "eng";
			}
			if (bytesLeft > 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (string.IsNullOrEmpty(m_Value))
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)m_TextEncoding);
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_LanguageCode));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, m_TextEncoding, m_Value, isTerminated: false));
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
