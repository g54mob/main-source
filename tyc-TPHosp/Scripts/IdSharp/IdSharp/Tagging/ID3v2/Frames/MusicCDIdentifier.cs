using System;
using System.ComponentModel;
using System.IO;

namespace IdSharp.Tagging.ID3v2.Frames
{
	internal sealed class MusicCDIdentifier : IMusicCDIdentifier, IFrame, INotifyPropertyChanged
	{
		private FrameHeader m_FrameHeader;

		private byte[] m_TOC;

		public byte[] TOC
		{
			get
			{
				if (m_TOC == null)
				{
					return null;
				}
				return (byte[])m_TOC.Clone();
			}
			set
			{
				if (value == null)
				{
					m_TOC = null;
				}
				else
				{
					m_TOC = (byte[])value.Clone();
				}
				FirePropertyChanged("TOC");
			}
		}

		public IFrameHeader FrameHeader => m_FrameHeader;

		public event PropertyChangedEventHandler PropertyChanged;

		public MusicCDIdentifier()
		{
			m_FrameHeader = new FrameHeader();
		}

		public string GetFrameID(ID3v2TagVersion tagVersion)
		{
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v23:
			case ID3v2TagVersion.ID3v24:
				return "MCDI";
			case ID3v2TagVersion.ID3v22:
				return "MCI";
			default:
				throw new ArgumentException("Unknown tag version");
			}
		}

		public void Read(TagReadingInfo tagReadingInfo, Stream stream)
		{
			m_FrameHeader.Read(tagReadingInfo, ref stream);
			if (m_FrameHeader.FrameSizeExcludingAdditions > 0)
			{
				TOC = Utils.Read(stream, m_FrameHeader.FrameSizeExcludingAdditions);
			}
			else
			{
				TOC = null;
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			if (TOC == null || TOC.Length == 0)
			{
				return new byte[0];
			}
			using MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(TOC, 0, TOC.Length);
			return m_FrameHeader.GetBytes(memoryStream, tagVersion, GetFrameID(tagVersion));
		}

		private void FirePropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
