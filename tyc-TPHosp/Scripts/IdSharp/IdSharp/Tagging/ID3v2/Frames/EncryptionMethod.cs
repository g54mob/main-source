using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class EncryptionMethod : IEncryptionMethod, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_OwnerIdentifier;

		private byte m_MethodSymbol;

		private byte[] m_EncryptionData;

		public string OwnerIdentifier
		{
			get
			{
				return m_OwnerIdentifier;
			}
			set
			{
				m_OwnerIdentifier = value;
				FirePropertyChanged("OwnerIdentifier");
			}
		}

		public byte MethodSymbol
		{
			get
			{
				return m_MethodSymbol;
			}
			set
			{
				m_MethodSymbol = value;
				FirePropertyChanged("MethodSymbol");
			}
		}

		public byte[] EncryptionData
		{
			get
			{
				if (m_EncryptionData == null)
				{
					return null;
				}
				return (byte[])m_EncryptionData.Clone();
			}
			set
			{
				if (value == null)
				{
					m_EncryptionData = null;
				}
				else
				{
					m_EncryptionData = (byte[])value.Clone();
				}
				FirePropertyChanged("EncryptionData");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public EncryptionMethod()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "ENCR";
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
			if (bytesLeft > 0)
			{
				OwnerIdentifier = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
				if (bytesLeft > 0)
				{
					MethodSymbol = Utils.ReadByte(stream, ref bytesLeft);
					if (bytesLeft > 0)
					{
						EncryptionData = Utils.Read(stream, bytesLeft);
						bytesLeft = 0;
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
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_OwnerIdentifier));
			memoryStream.WriteByte(0);
			memoryStream.WriteByte(m_MethodSymbol);
			if (m_EncryptionData != null)
			{
				Utils.Write(memoryStream, m_EncryptionData);
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void Reset()
		{
			OwnerIdentifier = null;
			MethodSymbol = 0;
			EncryptionData = null;
		}
	}
}
