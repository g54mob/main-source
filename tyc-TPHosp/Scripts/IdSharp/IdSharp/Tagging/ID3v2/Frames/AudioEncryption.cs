using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class AudioEncryption : IAudioEncryption, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_OwnerIdentifier;

		private short m_PreviewStart;

		private short m_PreviewLength;

		private byte[] m_EncryptionInfo;

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

		public short PreviewStart
		{
			get
			{
				return m_PreviewStart;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", value, "Value cannot be less than 0");
				}
				m_PreviewStart = value;
				FirePropertyChanged("PreviewStart");
			}
		}

		public short PreviewLength
		{
			get
			{
				return m_PreviewLength;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", value, "Value cannot be less than 0");
				}
				m_PreviewLength = value;
				FirePropertyChanged("PreviewLength");
			}
		}

		public byte[] EncryptionInfo
		{
			get
			{
				if (m_EncryptionInfo == null)
				{
					return null;
				}
				return (byte[])m_EncryptionInfo.Clone();
			}
			set
			{
				if (value == null)
				{
					m_EncryptionInfo = null;
				}
				else
				{
					m_EncryptionInfo = (byte[])value.Clone();
				}
				FirePropertyChanged("EncryptionInfo");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public AudioEncryption()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "AENC";
			case ID3v2TagVersion.ID3v22:
				return "CRA";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			int bytesLeft = m_FrameHeader.FrameSizeExcludingAdditions;
			if (bytesLeft > 0)
			{
				OwnerIdentifier = Utils.ReadString(EncodingType.ISO88591, stream, ref bytesLeft);
				if (bytesLeft >= 4)
				{
					PreviewStart = Utils.ReadInt16(stream, ref bytesLeft);
					PreviewLength = Utils.ReadInt16(stream, ref bytesLeft);
					if (bytesLeft > 0)
					{
						EncryptionInfo = Utils.Read(stream, bytesLeft);
						bytesLeft = 0;
					}
					else
					{
						EncryptionInfo = null;
					}
				}
				else
				{
					PreviewStart = 0;
					PreviewLength = 0;
					EncryptionInfo = null;
				}
			}
			else
			{
				OwnerIdentifier = null;
				PreviewStart = 0;
				PreviewLength = 0;
				EncryptionInfo = null;
			}
			if (bytesLeft != 0)
			{
				stream.Seek(bytesLeft, SeekOrigin.Current);
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, EncodingType.ISO88591, OwnerIdentifier, isTerminated: true));
			Utils.Write(memoryStream, Utils.Get2Bytes(PreviewStart));
			Utils.Write(memoryStream, Utils.Get2Bytes(PreviewLength));
			if (m_EncryptionInfo != null)
			{
				Utils.Write(memoryStream, m_EncryptionInfo);
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
