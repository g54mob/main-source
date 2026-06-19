#define TRACE
using System;
using System.Diagnostics;
using System.IO;

namespace IdSharp.Tagging.ID3v2
{
	internal sealed class ID3v2Header : IID3v2Header
	{
		private ID3v2TagVersion m_TagVersion;

		private byte m_TagVersionRevision;

		private int m_TagSize;

		private bool m_UsesUnsynchronization;

		private bool m_HasExtendedHeader;

		private bool m_IsExperimental;

		private bool m_IsCompressed;

		private bool m_IsFooterPresent;

		public ID3v2TagVersion TagVersion
		{
			get
			{
				return m_TagVersion;
			}
			set
			{
				m_TagVersion = value;
			}
		}

		public byte TagVersionRevision
		{
			get
			{
				return m_TagVersionRevision;
			}
			set
			{
				m_TagVersionRevision = value;
			}
		}

		public int TagSize
		{
			get
			{
				return m_TagSize;
			}
			set
			{
				if (value > 268435455)
				{
					string message = $"Argument 'value' out of range.  Maximum tag size is {268435455}.";
					Trace.WriteLine(message);
					throw new ArgumentOutOfRangeException("value", value, message);
				}
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("value", value, "Value cannot be less than 0");
				}
				m_TagSize = value;
			}
		}

		public bool UsesUnsynchronization
		{
			get
			{
				return m_UsesUnsynchronization;
			}
			set
			{
				m_UsesUnsynchronization = value;
			}
		}

		public bool HasExtendedHeader
		{
			get
			{
				return m_HasExtendedHeader;
			}
			set
			{
				m_HasExtendedHeader = value;
			}
		}

		public bool IsExperimental
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_IsExperimental;
				}
				return false;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_IsExperimental = value;
				}
				else
				{
					m_IsExperimental = false;
				}
			}
		}

		public bool IsCompressed
		{
			get
			{
				if (m_TagVersion == ID3v2TagVersion.ID3v22)
				{
					return m_IsCompressed;
				}
				return false;
			}
			set
			{
				if (m_TagVersion == ID3v2TagVersion.ID3v22)
				{
					m_IsCompressed = value;
				}
				else
				{
					m_IsCompressed = false;
				}
			}
		}

		public bool IsFooterPresent
		{
			get
			{
				if (m_TagVersion == ID3v2TagVersion.ID3v24)
				{
					return m_IsFooterPresent;
				}
				return false;
			}
			set
			{
				if (m_TagVersion == ID3v2TagVersion.ID3v24)
				{
					m_IsFooterPresent = value;
				}
				else
				{
					m_IsFooterPresent = false;
				}
			}
		}

		public ID3v2Header(Stream stream, bool readIdentifier)
		{
			Read(stream, readIdentifier);
		}

		public ID3v2Header()
		{
			Clear();
		}

		private void Clear()
		{
			m_TagVersion = ID3v2TagVersion.ID3v23;
			m_TagVersionRevision = 0;
			m_TagSize = 0;
			m_UsesUnsynchronization = false;
			m_HasExtendedHeader = false;
			m_IsExperimental = false;
		}

		private void Read(Stream stream, bool readIdentifier)
		{
			if (readIdentifier)
			{
				Read(stream);
				return;
			}
			byte[] array = Utils.Read(stream, 7);
			if (array[0] < 2 || array[0] > 4)
			{
				string message = $"ID3 Version '{array[0]}' not recognized (valid versions are 2, 3, and 4)";
				Trace.WriteLine(message);
				throw new InvalidDataException(message);
			}
			m_TagVersion = (ID3v2TagVersion)array[0];
			m_TagVersionRevision = array[1];
			switch (m_TagVersion)
			{
			case ID3v2TagVersion.ID3v23:
				UsesUnsynchronization = (array[2] & 0x80) == 128;
				m_HasExtendedHeader = (array[2] & 0x40) == 64;
				m_IsExperimental = (array[2] & 0x20) == 32;
				m_IsFooterPresent = false;
				m_IsCompressed = false;
				break;
			case ID3v2TagVersion.ID3v22:
				m_UsesUnsynchronization = (array[2] & 0x80) == 128;
				m_IsFooterPresent = false;
				m_IsCompressed = (array[2] & 0x40) == 64;
				break;
			case ID3v2TagVersion.ID3v24:
				m_UsesUnsynchronization = (array[2] & 0x80) == 128;
				m_HasExtendedHeader = (array[2] & 0x40) == 64;
				m_IsExperimental = (array[2] & 0x20) == 32;
				m_IsFooterPresent = (array[2] & 0x10) == 16;
				m_IsCompressed = false;
				break;
			}
			m_TagSize = array[3] << 21;
			m_TagSize += array[4] << 14;
			m_TagSize += array[5] << 7;
			m_TagSize += array[6];
		}

		public void Read(Stream stream)
		{
			byte[] array = Utils.Read(stream, 3);
			if (array[0] != 73 || array[1] != 68 || array[2] != 51)
			{
				string message = "'ID3' marker not found";
				Trace.WriteLine(message);
				throw new InvalidDataException(message);
			}
			Read(stream, readIdentifier: false);
		}

		public byte[] GetBytes()
		{
			byte[] array = new byte[10]
			{
				73,
				68,
				51,
				(byte)m_TagVersion,
				m_TagVersionRevision,
				0,
				0,
				0,
				0,
				0
			};
			if (m_UsesUnsynchronization)
			{
				array[5] += 128;
			}
			if (m_HasExtendedHeader)
			{
				array[5] += 64;
			}
			if (m_IsExperimental)
			{
				array[5] += 32;
			}
			array[6] = (byte)((m_TagSize >> 21) & 0x7F);
			array[7] = (byte)((m_TagSize >> 14) & 0x7F);
			array[8] = (byte)((m_TagSize >> 7) & 0x7F);
			array[9] = (byte)(m_TagSize & 0x7F);
			return array;
		}
	}
}
