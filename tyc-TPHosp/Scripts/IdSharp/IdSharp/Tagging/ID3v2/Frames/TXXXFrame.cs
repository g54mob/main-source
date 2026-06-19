using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class TXXXFrame : ITXXXFrame, ITextFrame, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_Description;

		private string m_Value;

		public string Description
		{
			get
			{
				return m_Description;
			}
			set
			{
				m_Description = value;
				FirePropertyChanged("Description");
			}
		}

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
				m_Value = value;
				FirePropertyChanged("Value");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public TXXXFrame()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "TXXX";
			case ID3v2TagVersion.ID3v22:
				return "TXX";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			if (m_FrameHeader.FrameSizeExcludingAdditions > 0)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream);
				int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions - 1;
				Description = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
				Value = Utils.ReadString(EncodingType.ISO88591, stream, bytesLeft);
			}
			else
			{
				Description = "";
				Value = "";
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (string.IsNullOrEmpty(m_Value))
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)TextEncoding);
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, Description, isTerminated: true));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, Value, isTerminated: false));
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
