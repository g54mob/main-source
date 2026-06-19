using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class UrlFrame : IUrlFrame, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private string m_Value;

		private string m_ID3v24FrameID;

		private string m_ID3v23FrameID;

		private string m_ID3v22FrameID;

		public string Value
		{
			get
			{
				return m_Value;
			}
			set
			{
				m_Value = value;
				FirePropertyChanged("Value");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public UrlFrame(string ID3v24FrameID, string ID3v23FrameID, string ID3v22FrameID)
		{
			m_FrameHeader = new FrameHeader();
			m_ID3v24FrameID = ID3v24FrameID;
			m_ID3v23FrameID = ID3v23FrameID;
			m_ID3v22FrameID = ID3v22FrameID;
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			return tagVersion switch
			{
				ID3v2TagVersion.ID3v24 => m_ID3v24FrameID, 
				ID3v2TagVersion.ID3v23 => m_ID3v23FrameID, 
				ID3v2TagVersion.ID3v22 => m_ID3v22FrameID, 
				_ => throw new ArgumentException("Unknown tag version"), 
			};
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			Value = Utils.ReadString(EncodingType.ISO88591, stream, m_FrameHeader.FrameSizeExcludingAdditions);
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (string.IsNullOrEmpty(m_Value))
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, Utils.ISO88591GetBytes(m_Value));
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
