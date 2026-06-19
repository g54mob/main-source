using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames.Items;
using IdSharp.Tagging.ID3v2.Frames.Lists;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class Commercial : ICommercial, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private PriceInformationBindingList m_PriceList;

		private DateTime m_ValidUntil;

		private string m_ContactUrl;

		private string m_NameOfSeller;

		private ReceivedAs m_ReceivedAs;

		private string m_Description;

		private string m_SellerLogoMimeType;

		private byte[] m_SellerLogo;

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

		public BindingList<IPriceInformation> PriceList => m_PriceList;

		public DateTime ValidUntil
		{
			get
			{
				return m_ValidUntil.Date;
			}
			set
			{
				m_ValidUntil = value.Date;
				FirePropertyChanged("ValidUntil");
			}
		}

		public string ContactUrl
		{
			get
			{
				return m_ContactUrl;
			}
			set
			{
				m_ContactUrl = value;
				FirePropertyChanged("ContactUrl");
			}
		}

		public ReceivedAs ReceivedAs
		{
			get
			{
				return m_ReceivedAs;
			}
			set
			{
				m_ReceivedAs = value;
				FirePropertyChanged("ReceivedAs");
			}
		}

		public string NameOfSeller
		{
			get
			{
				return m_NameOfSeller;
			}
			set
			{
				m_NameOfSeller = value;
				FirePropertyChanged("NameOfSeller");
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

		public string SellerLogoMimeType
		{
			get
			{
				return m_SellerLogoMimeType;
			}
			set
			{
				m_SellerLogoMimeType = value;
				FirePropertyChanged("SellerLogoMimeType");
			}
		}

		public byte[] SellerLogo
		{
			get
			{
				if (m_SellerLogo == null)
				{
					return null;
				}
				return (byte[])m_SellerLogo.Clone();
			}
			set
			{
				if (value == null)
				{
					m_SellerLogo = null;
				}
				else
				{
					m_SellerLogo = (byte[])value.Clone();
				}
				FirePropertyChanged("SellerLogo");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public Commercial()
		{
			m_FrameHeader = new FrameHeader();
			m_PriceList = new PriceInformationBindingList();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "COMR";
			case ID3v2TagVersion.ID3v22:
				return null;
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			Reset();
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft > 1)
			{
				TextEncoding = (EncodingType)Utils.ReadByte(stream, ref bytesLeft);
				string text = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split('/');
					foreach (string text2 in array)
					{
						if (text2.Length > 3)
						{
							string s = text2.Substring(3, text2.Length - 3);
							if (double.TryParse(s, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out var result))
							{
								IPriceInformation priceInformation = new PriceInformation();
								priceInformation.CurrencyCode = text2.Substring(0, 3);
								priceInformation.Price = result;
								m_PriceList.Add(priceInformation);
							}
						}
					}
				}
				if (bytesLeft > 0)
				{
					string text3 = Utils.ReadString(EncodingType.ISO88591, stream, 8);
					bytesLeft -= 8;
					if (text3.Length == 8)
					{
						text3 = $"{text3.Substring(0, 4)}-{text3.Substring(4, 2)}-{text3.Substring(6, 2)}";
						DateTime.TryParse(text3, out m_ValidUntil);
					}
					if (bytesLeft > 0)
					{
						ContactUrl = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
						if (bytesLeft > 0)
						{
							ReceivedAs = (ReceivedAs)Utils.ReadByte(stream, ref bytesLeft);
							NameOfSeller = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
							Description = Utils.ReadString(TextEncoding, stream, ref bytesLeft);
							SellerLogoMimeType = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
							if (bytesLeft > 0)
							{
								SellerLogo = Utils.Read(stream, bytesLeft);
								bytesLeft = 0;
							}
						}
					}
				}
			}
			if (bytesLeft != 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_PriceList.Count == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)m_TextEncoding);
			string text = "";
			foreach (IPriceInformation price in m_PriceList)
			{
				if (price.CurrencyCode != null && price.CurrencyCode.Length == 3)
				{
					if (text != "")
					{
						text += "/";
					}
					text += $"{price.CurrencyCode}{price.Price:0.00}";
				}
			}
			if (text == "")
			{
				return new byte[0];
			}
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(text));
			memoryStream.WriteByte(0);
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_ValidUntil.ToString("yyyyMMdd")));
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_ContactUrl));
			memoryStream.WriteByte(0);
			memoryStream.WriteByte((byte)m_ReceivedAs);
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, m_TextEncoding, m_NameOfSeller, isTerminated: true));
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, m_TextEncoding, m_Description, isTerminated: true));
			if (m_SellerLogo != null && m_SellerLogo.Length != 0)
			{
				Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_SellerLogoMimeType));
				memoryStream.WriteByte(0);
				Utils.Write(memoryStream, m_SellerLogo);
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void Reset()
		{
			TextEncoding = EncodingType.ISO88591;
			PriceList.Clear();
			ValidUntil = DateTime.MinValue;
			ContactUrl = null;
			ReceivedAs = ReceivedAs.Other;
			NameOfSeller = null;
			Description = null;
			SellerLogoMimeType = null;
			SellerLogo = null;
		}
	}
}
