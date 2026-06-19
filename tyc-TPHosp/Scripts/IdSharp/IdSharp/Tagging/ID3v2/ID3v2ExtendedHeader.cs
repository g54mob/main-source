#define TRACE
using System;
using System.Diagnostics;
using System.IO;

namespace IdSharp.Tagging.ID3v2
{
	internal sealed class ID3v2ExtendedHeader : IID3v2ExtendedHeader
	{
		private bool m_IsCRCDataPresent;

		private int m_PaddingSize;

		private int m_TotalFrameCRC;

		public int SizeExcludingSizeBytes
		{
			get
			{
				if (!m_IsCRCDataPresent)
				{
					return 6;
				}
				return 10;
			}
		}

		public int SizeIncludingSizeBytes => (m_IsCRCDataPresent ? 10 : 6) + 4;

		public bool IsCRCDataPresent
		{
			get
			{
				return m_IsCRCDataPresent;
			}
			set
			{
				if (m_IsCRCDataPresent != value)
				{
					m_IsCRCDataPresent = value;
					if (!value)
					{
						CRC32 = 0;
					}
				}
			}
		}

		public int PaddingSize
		{
			get
			{
				return m_PaddingSize;
			}
			set
			{
				if (m_PaddingSize != value)
				{
					m_PaddingSize = value;
				}
			}
		}

		public int CRC32
		{
			get
			{
				return m_TotalFrameCRC;
			}
			set
			{
				if (m_TotalFrameCRC != value)
				{
					m_TotalFrameCRC = value;
				}
			}
		}

		public bool IsTagAnUpdate
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public bool IsTagRestricted
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public ITagRestrictions TagRestrictions
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ID3v2ExtendedHeader(TagReadingInfo tagReadingInfo, Stream stream)
		{
			ReadFrom(tagReadingInfo, stream);
		}

		public ID3v2ExtendedHeader()
		{
			Clear();
		}

		private void Clear()
		{
			m_IsCRCDataPresent = false;
			m_PaddingSize = 0;
			m_TotalFrameCRC = 0;
		}

		public void ReadFrom(TagReadingInfo tagReadingInfo, Stream stream)
		{
			int num = Utils.ReadInt32(stream);
			_ = tagReadingInfo.TagVersion;
			_ = 3;
			if (num >= 1090519040)
			{
				string message = $"FrameID found when expected extended header at position {stream.Position - 4}";
				Trace.WriteLine(message);
				stream.Seek(-4L, SeekOrigin.Current);
				m_IsCRCDataPresent = false;
				m_PaddingSize = 0;
				m_TotalFrameCRC = 0;
				return;
			}
			byte b = Utils.ReadByte(stream);
			Utils.ReadByte(stream);
			m_IsCRCDataPresent = (b & 0x80) == 128;
			m_PaddingSize = Utils.ReadInt32(stream);
			if (m_IsCRCDataPresent)
			{
				m_TotalFrameCRC = Utils.ReadInt32(stream);
			}
			else
			{
				m_TotalFrameCRC = 0;
			}
		}

		public byte[] GetBytes(ID3v2TagVersion tagVersion)
		{
			byte[] array = new byte[m_IsCRCDataPresent ? 14 : 10];
			array[0] = 0;
			array[1] = 0;
			array[2] = 0;
			array[3] = (byte)(m_IsCRCDataPresent ? 10u : 6u);
			array[4] = (byte)(m_IsCRCDataPresent ? 128u : 0u);
			array[5] = 0;
			array[6] = (byte)((m_PaddingSize >> 24) & 0xFF);
			array[7] = (byte)((m_PaddingSize >> 16) & 0xFF);
			array[8] = (byte)((m_PaddingSize >> 8) & 0xFF);
			array[9] = (byte)(m_PaddingSize & 0xFF);
			if (m_IsCRCDataPresent)
			{
				array[10] = (byte)((m_TotalFrameCRC >> 24) & 0xFF);
				array[11] = (byte)((m_TotalFrameCRC >> 16) & 0xFF);
				array[12] = (byte)((m_TotalFrameCRC >> 8) & 0xFF);
				array[13] = (byte)(m_TotalFrameCRC & 0xFF);
			}
			return array;
		}
	}
}
