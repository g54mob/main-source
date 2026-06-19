using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class UnknownFrame : IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private byte[] m_FrameData;

		private string m_FrameID;

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public UnknownFrame(string frameID, TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameID = frameID;
			m_FrameHeader = new FrameHeader();
			Read(tagReadingInfo, stream);
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				if (m_FrameID.Length == 4)
				{
					return m_FrameID;
				}
				return null;
			case ID3v2TagVersion.ID3v22:
				if (m_FrameID.Length == 3)
				{
					return m_FrameID;
				}
				return null;
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			m_FrameData = Utils.Read(stream, m_FrameHeader.FrameSizeExcludingAdditions);
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (m_FrameData == null || m_FrameData.Length == 0)
			{
				return new byte[0];
			}
			using MemoryStream frameData = new MemoryStream(m_FrameData);
			return m_FrameHeader.GetBytes(frameData, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
