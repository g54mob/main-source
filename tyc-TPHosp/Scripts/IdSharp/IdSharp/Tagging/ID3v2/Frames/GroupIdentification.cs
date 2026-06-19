using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class GroupIdentification : IGroupIdentification, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_OwnerIdentifier;

		private byte m_GroupSymbol;

		private byte[] m_GroupDependentData;

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

		public byte[] GroupDependentData
		{
			get
			{
				if (m_GroupDependentData == null)
				{
					return null;
				}
				return (byte[])m_GroupDependentData.Clone();
			}
			set
			{
				if (value == null)
				{
					m_GroupDependentData = null;
				}
				else
				{
					m_GroupDependentData = (byte[])value.Clone();
				}
				FirePropertyChanged("GroupDependentData");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public GroupIdentification()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "GRID";
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
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.GetStringBytes(tagVersion, EncodingType.ISO88591, m_OwnerIdentifier, isTerminated: true));
			memoryStream.WriteByte(m_GroupSymbol);
			if (m_GroupDependentData != null)
			{
				Utils.Write(memoryStream, m_GroupDependentData);
			}
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
