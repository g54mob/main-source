using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class PrivateFrame : IPrivateFrame, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_OwnerIdentifier;

		private byte[] m_PrivateData;

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

		public byte[] PrivateData
		{
			get
			{
				if (m_PrivateData == null)
				{
					return null;
				}
				return (byte[])m_PrivateData.Clone();
			}
			set
			{
				if (value == null)
				{
					m_PrivateData = null;
				}
				else
				{
					m_PrivateData = (byte[])value.Clone();
				}
				FirePropertyChanged("PrivateData");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public PrivateFrame()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "PRIV";
			case ID3v2TagVersion.ID3v22:
				return null;
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
				if (bytesLeft > 0)
				{
					PrivateData = Utils.Read(stream, bytesLeft);
				}
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_PrivateData == null || m_PrivateData.Length == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(OwnerIdentifier));
			memoryStream.WriteByte(0);
			Utils.Write(memoryStream, m_PrivateData);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
