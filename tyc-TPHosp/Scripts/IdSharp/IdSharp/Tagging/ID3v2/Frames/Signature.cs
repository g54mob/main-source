using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class Signature : ISignature, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private byte m_GroupSymbol;

		private byte[] m_SignatureData;

		public byte GroupSymbol
		{
			get
			{
				return m_GroupSymbol;
			}
			set
			{
				m_GroupSymbol = value;
				FirePropertyChanged("GroupSymbol");
			}
		}

		public byte[] SignatureData
		{
			get
			{
				if (m_SignatureData == null)
				{
					return null;
				}
				return (byte[])m_SignatureData.Clone();
			}
			set
			{
				if (value == null)
				{
					m_SignatureData = null;
				}
				else
				{
					m_SignatureData = (byte[])value.Clone();
				}
				FirePropertyChanged("SignatureData");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public Signature()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "SIGN";
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
			throw new NotImplementedException();
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
