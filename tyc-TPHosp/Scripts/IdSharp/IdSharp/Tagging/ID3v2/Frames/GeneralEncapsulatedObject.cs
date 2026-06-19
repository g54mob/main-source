using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class GeneralEncapsulatedObject : IGeneralEncapsulatedObject, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_MimeType;

		private string m_FileName;

		private string m_Description;

		private byte[] m_EncapsulatedObject;

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

		public string MimeType
		{
			get
			{
				return m_MimeType;
			}
			set
			{
				m_MimeType = value;
				FirePropertyChanged("MimeType");
			}
		}

		public string FileName
		{
			get
			{
				return m_FileName;
			}
			set
			{
				m_FileName = value;
				FirePropertyChanged("FileName");
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

		public byte[] EncapsulatedObject
		{
			get
			{
				if (m_EncapsulatedObject == null)
				{
					return null;
				}
				return (byte[])m_EncapsulatedObject.Clone();
			}
			set
			{
				if (value == null)
				{
					m_EncapsulatedObject = null;
				}
				else
				{
					m_EncapsulatedObject = (byte[])value.Clone();
				}
				FirePropertyChanged("EncapsulatedObject");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public GeneralEncapsulatedObject()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "GEOB";
			case ID3v2TagVersion.ID3v22:
				return "GEO";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft >= 4)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
				MimeType = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
				if (bytesLeft > 0)
				{
					FileName = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
					if (bytesLeft > 0)
					{
						Description = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
						if (bytesLeft > 0)
						{
							EncapsulatedObject = Utils.Read(stream, bytesLeft);
							bytesLeft = 0;
						}
					}
				}
			}
			if (bytesLeft > 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_EncapsulatedObject == null || m_EncapsulatedObject.Length == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)TextEncoding);
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, EncodingType.ISO88591, MimeType, isTerminated: true));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, FileName, isTerminated: true));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, Description, isTerminated: true));
			memoryStream.Write(m_EncapsulatedObject, 0, m_EncapsulatedObject.Length);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
