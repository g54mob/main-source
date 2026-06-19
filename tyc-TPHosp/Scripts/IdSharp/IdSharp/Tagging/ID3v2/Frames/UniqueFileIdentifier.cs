using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class UniqueFileIdentifier : IUniqueFileIdentifier, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_OwnerIdentifier;

		private byte[] m_Identifier;

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

		public byte[] Identifier
		{
			get
			{
				if (m_Identifier == null)
				{
					return null;
				}
				return (byte[])m_Identifier.Clone();
			}
			set
			{
				if (value == null)
				{
					m_Identifier = null;
				}
				else
				{
					m_Identifier = (byte[])value.Clone();
				}
				FirePropertyChanged("Identifier");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public UniqueFileIdentifier()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "UFID";
			case ID3v2TagVersion.ID3v22:
				return "UFI";
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
					Identifier = Utils.Read(stream, bytesLeft);
				}
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_Identifier == null || m_Identifier.Length == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_OwnerIdentifier));
			memoryStream.WriteByte(0);
			Utils.Write(memoryStream, m_Identifier);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
