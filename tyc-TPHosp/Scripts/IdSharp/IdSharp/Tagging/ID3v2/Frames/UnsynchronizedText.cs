#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class UnsynchronizedText : IUnsynchronizedText, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_LanguageCode;

		private string m_ContentDescriptor;

		private string m_Text;

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

		public string ContentDescriptor
		{
			get
			{
				return m_ContentDescriptor;
			}
			set
			{
				m_ContentDescriptor = value;
				FirePropertyChanged("ContentDescriptor");
			}
		}

		public string Text
		{
			get
			{
				return m_Text;
			}
			set
			{
				m_Text = value;
				FirePropertyChanged("Text");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public UnsynchronizedText()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "USLT";
			case ID3v2TagVersion.ID3v22:
				return "ULT";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			if (m_FrameHeader.FrameSizeExcludingAdditions >= 4)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream);
				LanguageCode = Utils.ReadString(EncodingType.ISO88591, stream, 3);
				int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions - 1 - 3;
				ContentDescriptor = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
				Text = Utils.ReadString(m_TextEncoding, stream, bytesLeft);
			}
			else
			{
				string message = $"Under-sized ({m_FrameHeader.FrameSizeExcludingAdditions} bytes) unsynchronized text frame at position {stream.Position}";
				Trace.WriteLine(message);
				LanguageCode = "eng";
				ContentDescriptor = "";
				Text = "";
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (string.IsNullOrEmpty(Text))
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)TextEncoding);
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(LanguageCode));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, ContentDescriptor, isTerminated: true));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, Text, isTerminated: false));
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
