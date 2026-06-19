using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class WXXXFrame : IWXXXFrame, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_Description;

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

		public WXXXFrame()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "WXXX";
			case ID3v2TagVersion.ID3v22:
				return "WXX";
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
			if (string.IsNullOrEmpty(Value))
			{
				return new byte[0];
			}
			byte[] array = new byte[1] { (byte)TextEncoding };
			byte[] stringBytes = Utils.GetStringBytes(tagVersion, TextEncoding, Description, isTerminated: true);
			byte[] array2 = Utils.ISO88591GetBytes(Value);
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(array, 0, array.Length);
			memoryStream.Write(stringBytes, 0, stringBytes.Length);
			memoryStream.Write(array2, 0, array2.Length);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
