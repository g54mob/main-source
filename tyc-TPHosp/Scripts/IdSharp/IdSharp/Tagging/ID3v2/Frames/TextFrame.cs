using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class TextFrame : ITextFrame, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_Value;

		private string m_ID3v24FrameID;

		private string m_ID3v23FrameID;

		private string m_ID3v22FrameID;

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

		public string Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					m_Value = value;
				}
				else
				{
					m_Value = value.Trim();
				}
				FirePropertyChanged("Value");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public TextFrame(string ID3v24FrameID, string ID3v23FrameID, string ID3v22FrameID)
		{
			m_FrameHeader = new FrameHeader();
			m_ID3v24FrameID = ID3v24FrameID;
			m_ID3v23FrameID = ID3v23FrameID;
			m_ID3v22FrameID = ID3v22FrameID;
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			return tagVersion switch
			{
				ID3v2TagVersion.ID3v24 => m_ID3v24FrameID, 
				ID3v2TagVersion.ID3v23 => m_ID3v23FrameID, 
				ID3v2TagVersion.ID3v22 => m_ID3v22FrameID, 
				_ => throw new ArgumentException("Unknown tag version"), 
			};
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			if (m_FrameHeader.FrameSizeExcludingAdditions >= 1)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream);
				Value = Utils.ReadString(m_TextEncoding, stream, m_FrameHeader.FrameSizeExcludingAdditions - 1);
			}
			else
			{
				TextEncoding = EncodingType.ISO88591;
				Value = "";
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (string.IsNullOrEmpty(Value))
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)m_TextEncoding);
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, Value, isTerminated: false));
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
