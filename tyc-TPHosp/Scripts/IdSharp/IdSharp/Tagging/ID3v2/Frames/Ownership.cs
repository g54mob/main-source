using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class Ownership : IOwnership, IFrame, INotifyPropertyChanged, ITextEncoding
	{
		private FrameHeader m_FrameHeader;

		private EncodingType m_TextEncoding;

		private double m_PricePaid;

		private string m_CurrencyCode;

		private DateTime m_DateOfPurchase;

		private string m_Seller;

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

		public double PricePaid
		{
			get
			{
				return m_PricePaid;
			}
			set
			{
				m_PricePaid = value;
				FirePropertyChanged("PricePaid");
			}
		}

		public string CurrencyCode
		{
			get
			{
				return m_CurrencyCode;
			}
			set
			{
				m_CurrencyCode = value;
				FirePropertyChanged("CurrencyCode");
			}
		}

		public DateTime DateOfPurchase
		{
			get
			{
				return m_DateOfPurchase.Date;
			}
			set
			{
				m_DateOfPurchase = value.Date;
				FirePropertyChanged("DateOfPurchase");
			}
		}

		public string Seller
		{
			get
			{
				return m_Seller;
			}
			set
			{
				m_Seller = value;
				FirePropertyChanged("Seller");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public Ownership()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "OWNE";
			case ID3v2TagVersion.ID3v22:
				return null;
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			throw new NotImplementedException();
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (PricePaid == 0.0 && string.IsNullOrEmpty(CurrencyCode) && DateOfPurchase == DateTime.MinValue && string.IsNullOrEmpty(Seller))
			{
				return new byte[0];
			}
			throw new NotImplementedException();
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
