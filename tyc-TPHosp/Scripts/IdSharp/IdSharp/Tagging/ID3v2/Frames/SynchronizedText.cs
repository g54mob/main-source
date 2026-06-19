using System;
using System.ComponentModel;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames.Items;
using IdSharp.Tagging.ID3v2.Frames.Lists;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class SynchronizedText : ISynchronizedText, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private string m_LanguageCode;

		private TimestampFormat m_TimestampFormat;

		private TextContentType m_ContentType;

		private string m_ContentDescriptor;

		private SynchronizedTextItemBindingList m_SynchronizedTextItemBindingList;

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

		public TextContentType ContentType
		{
			get
			{
				return m_ContentType;
			}
			set
			{
				m_ContentType = value;
				FirePropertyChanged("ContentType");
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

		public BindingList<ISynchronizedTextItem> Items => m_SynchronizedTextItemBindingList;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public SynchronizedText()
		{
			m_FrameHeader = new FrameHeader();
			m_SynchronizedTextItemBindingList = new SynchronizedTextItemBindingList();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "SYLT";
			case ID3v2TagVersion.ID3v22:
				return "SLT";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			Items.Clear();
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft >= 1)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
				if (bytesLeft >= 3)
				{
					LanguageCode = Utils.ReadString(EncodingType.ISO88591, stream, 3);
					bytesLeft -= 3;
					if (bytesLeft >= 2)
					{
						TimestampFormat = (TimestampFormat)Utils.ReadByte(stream, ref bytesLeft);
						ContentType = (TextContentType)Utils.ReadByte(stream, ref bytesLeft);
						if (bytesLeft > 0)
						{
							ContentDescriptor = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
							while (bytesLeft > 0)
							{
								string text = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
								if (bytesLeft >= 4)
								{
									SynchronizedTextItem synchronizedTextItem = new SynchronizedTextItem();
									synchronizedTextItem.Text = text;
									synchronizedTextItem.Timestamp = Utils.ReadInt32(stream);
									bytesLeft -= 4;
									Items.Add(synchronizedTextItem);
								}
							}
						}
						else
						{
							ContentDescriptor = "";
						}
					}
					else
					{
						TimestampFormat = TimestampFormat.Milliseconds;
						ContentType = TextContentType.Other;
						ContentDescriptor = "";
					}
				}
				else
				{
					LanguageCode = "eng";
					TimestampFormat = TimestampFormat.Milliseconds;
					ContentType = TextContentType.Other;
					ContentDescriptor = "";
				}
			}
			else
			{
				TextEncoding = EncodingType.ISO88591;
				LanguageCode = "eng";
				TimestampFormat = TimestampFormat.Milliseconds;
				ContentType = TextContentType.Other;
				ContentDescriptor = "";
			}
			if (bytesLeft > 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (Items.Count == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)TextEncoding);
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(LanguageCode));
			memoryStream.WriteByte((byte)TimestampFormat);
			memoryStream.WriteByte((byte)ContentType);
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, ContentDescriptor, isTerminated: true));
			foreach (ISynchronizedTextItem item in Items)
			{
				Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, TextEncoding, item.Text, isTerminated: true));
				Utils.Write(memoryStream, Utils.Get4Bytes(item.Timestamp));
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
