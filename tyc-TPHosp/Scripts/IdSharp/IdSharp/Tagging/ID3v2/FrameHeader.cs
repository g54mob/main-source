using System;
using System.IO;

namespace IdSharp.Tagging.ID3v2
{
	internal sealed class FrameHeader : IFrameHeader
	{
		private int m_FrameSize;

		private int m_FrameSizeExcludingAdditions;

		private bool m_IsTagAlterPreservation;

		private bool m_IsFileAlterPreservation;

		private bool m_IsReadOnly;

		private bool m_IsCompressed;

		private byte? m_EncryptionMethod;

		private byte? m_GroupingIdentity;

		private int m_DecompressedSize;

		private ID3v2TagVersion m_TagVersion;

		public ID3v2TagVersion TagVersion => m_TagVersion;

		public int FrameSize => m_FrameSize;

		public int FrameSizeTotal => m_FrameSize + ((m_TagVersion == ID3v2TagVersion.ID3v22) ? 6 : 10);

		public int FrameSizeExcludingAdditions => m_FrameSizeExcludingAdditions;

		public bool IsTagAlterPreservation
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_IsTagAlterPreservation;
				}
				return false;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_IsTagAlterPreservation = value;
				}
				else
				{
					m_IsTagAlterPreservation = false;
				}
			}
		}

		public bool IsFileAlterPreservation
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_IsFileAlterPreservation;
				}
				return false;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_IsFileAlterPreservation = value;
				}
				else
				{
					m_IsFileAlterPreservation = false;
				}
			}
		}

		public bool IsReadOnly
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_IsReadOnly;
				}
				return false;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_IsReadOnly = value;
				}
				else
				{
					m_IsReadOnly = false;
				}
			}
		}

		public bool IsCompressed
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_IsCompressed;
				}
				return false;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_IsCompressed = value;
				}
				else
				{
					m_IsCompressed = false;
				}
			}
		}

		public byte? EncryptionMethod
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_EncryptionMethod;
				}
				return null;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_EncryptionMethod = value;
				}
				else
				{
					m_EncryptionMethod = null;
				}
			}
		}

		public byte? GroupingIdentity
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_GroupingIdentity;
				}
				return null;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_GroupingIdentity = value;
				}
				else
				{
					m_GroupingIdentity = null;
				}
			}
		}

		public int DecompressedSize
		{
			get
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					return m_DecompressedSize;
				}
				return 0;
			}
			set
			{
				if (m_TagVersion != ID3v2TagVersion.ID3v22)
				{
					m_DecompressedSize = value;
				}
				else
				{
					m_DecompressedSize = 0;
				}
			}
		}

		public bool UsesUnsynchronization
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

		public void Read(TagReadingInfo tagReadingInfo, ref Stream stream)
		{
			m_TagVersion = tagReadingInfo.TagVersion;
			bool flag = (tagReadingInfo.TagVersionOptions & TagVersionOptions.Unsynchronized) == TagVersionOptions.Unsynchronized;
			if (tagReadingInfo.TagVersion == ID3v2TagVersion.ID3v23)
			{
				if (!flag)
				{
					m_FrameSize = Utils.ReadInt32(stream);
				}
				else
				{
					m_FrameSize = Utils.ReadInt32Unsynchronized(stream);
				}
				m_FrameSizeExcludingAdditions = m_FrameSize;
				byte b = Utils.ReadByte(stream);
				byte b2 = Utils.ReadByte(stream);
				IsTagAlterPreservation = (b & 0x80) == 128;
				IsFileAlterPreservation = (b & 0x40) == 64;
				IsReadOnly = (b & 0x20) == 32;
				IsCompressed = (b2 & 0x80) == 128;
				bool flag2 = (b2 & 0x40) == 64;
				bool flag3 = (b2 & 0x20) == 32;
				if (IsCompressed)
				{
					DecompressedSize = Utils.ReadInt32(stream);
					m_FrameSizeExcludingAdditions -= 4;
				}
				else
				{
					DecompressedSize = 0;
				}
				if (flag2)
				{
					EncryptionMethod = Utils.ReadByte(stream);
					m_FrameSizeExcludingAdditions--;
				}
				else
				{
					EncryptionMethod = null;
				}
				if (flag3)
				{
					GroupingIdentity = Utils.ReadByte(stream);
					m_FrameSizeExcludingAdditions--;
				}
				else
				{
					GroupingIdentity = null;
				}
				if (flag)
				{
					stream = Utils.ReadUnsynchronizedStream(stream, m_FrameSize);
				}
			}
			else if (tagReadingInfo.TagVersion == ID3v2TagVersion.ID3v22)
			{
				if (!flag)
				{
					m_FrameSize = Utils.ReadInt24(stream);
				}
				else
				{
					m_FrameSize = Utils.ReadInt24Unsynchronized(stream);
				}
				if ((tagReadingInfo.TagVersionOptions & TagVersionOptions.AddOneByteToSize) == TagVersionOptions.AddOneByteToSize)
				{
					m_FrameSize++;
				}
				m_FrameSizeExcludingAdditions = m_FrameSize;
				IsTagAlterPreservation = false;
				IsFileAlterPreservation = false;
				IsReadOnly = false;
				IsCompressed = false;
				DecompressedSize = 0;
				EncryptionMethod = null;
				GroupingIdentity = null;
				if (flag)
				{
					stream = Utils.ReadUnsynchronizedStream(stream, m_FrameSize);
				}
			}
			else if (tagReadingInfo.TagVersion == ID3v2TagVersion.ID3v24)
			{
				if ((tagReadingInfo.TagVersionOptions & TagVersionOptions.UseNonSyncSafeFrameSizeID3v24) == TagVersionOptions.UseNonSyncSafeFrameSizeID3v24)
				{
					m_FrameSize = Utils.ReadInt32(stream);
				}
				else
				{
					m_FrameSize = Utils.ReadInt32SyncSafe(stream);
				}
				m_FrameSizeExcludingAdditions = m_FrameSize;
				Utils.ReadByte(stream);
				Utils.ReadByte(stream);
			}
			if (IsCompressed)
			{
				stream = Utils.DecompressFrame(stream, FrameSizeExcludingAdditions);
				IsCompressed = false;
				DecompressedSize = 0;
				m_FrameSizeExcludingAdditions = (int)stream.Length;
			}
		}

		public byte[] GetBytes(MemoryStream frameData, ID3v2TagVersion tagVersion, string frameID)
		{
			m_FrameSizeExcludingAdditions = (int)frameData.Length;
			if (frameID == null)
			{
				return new byte[0];
			}
			byte[] array = Utils.ISO88591GetBytes(frameID);
			byte[] array2;
			switch (tagVersion)
			{
			case ID3v2TagVersion.ID3v22:
				if (array.Length != 3)
				{
					throw new ArgumentException($"FrameID must be 3 bytes from ID3v2.2 ({array.Length} bytes passed)");
				}
				array2 = new byte[6]
				{
					array[0],
					array[1],
					array[2],
					(byte)((m_FrameSizeExcludingAdditions >> 16) & 0xFF),
					(byte)((m_FrameSizeExcludingAdditions >> 8) & 0xFF),
					(byte)(m_FrameSizeExcludingAdditions & 0xFF)
				};
				break;
			case ID3v2TagVersion.ID3v23:
			{
				int num4 = 10;
				byte b3 = (byte)((m_IsTagAlterPreservation ? 128 : 0) + (m_IsFileAlterPreservation ? 64 : 0) + (m_IsReadOnly ? 32 : 0));
				byte b4 = (byte)((m_IsCompressed ? 128 : 0) + (m_EncryptionMethod.HasValue ? 64 : 0) + (m_GroupingIdentity.HasValue ? 32 : 0));
				if (m_IsCompressed)
				{
					num4 += 4;
				}
				if (m_EncryptionMethod.HasValue)
				{
					num4++;
				}
				if (m_GroupingIdentity.HasValue)
				{
					num4++;
				}
				int num5 = m_FrameSizeExcludingAdditions + (num4 - 10);
				array2 = new byte[num4];
				if (array.Length != 4)
				{
					throw new ArgumentException($"FrameID must be 4 bytes ({array.Length} bytes passed)");
				}
				array2[0] = array[0];
				array2[1] = array[1];
				array2[2] = array[2];
				array2[3] = array[3];
				array2[4] = (byte)((num5 >> 24) & 0xFF);
				array2[5] = (byte)((num5 >> 16) & 0xFF);
				array2[6] = (byte)((num5 >> 8) & 0xFF);
				array2[7] = (byte)(num5 & 0xFF);
				array2[8] = b3;
				array2[9] = b4;
				int num6 = 10;
				if (m_IsCompressed)
				{
					array2[num6++] = (byte)(DecompressedSize >> 24);
					array2[num6++] = (byte)(DecompressedSize >> 16);
					array2[num6++] = (byte)(DecompressedSize >> 8);
					array2[num6++] = (byte)DecompressedSize;
				}
				if (m_EncryptionMethod.HasValue)
				{
					array2[num6++] = m_EncryptionMethod.Value;
				}
				if (m_GroupingIdentity.HasValue)
				{
					array2[num6] = m_GroupingIdentity.Value;
				}
				break;
			}
			case ID3v2TagVersion.ID3v24:
			{
				int num = 10;
				byte b = (byte)((m_IsTagAlterPreservation ? 64 : 0) + (m_IsFileAlterPreservation ? 32 : 0) + (m_IsReadOnly ? 16 : 0));
				byte b2 = (byte)((m_GroupingIdentity.HasValue ? 64 : 0) + (m_IsCompressed ? 8 : 0) + (m_EncryptionMethod.HasValue ? 4 : 0));
				if (m_IsCompressed)
				{
					num += 4;
				}
				if (m_EncryptionMethod.HasValue)
				{
					num++;
				}
				if (m_GroupingIdentity.HasValue)
				{
					num++;
				}
				int num2 = m_FrameSizeExcludingAdditions + (num - 10);
				array2 = new byte[num];
				if (array.Length != 4)
				{
					throw new ArgumentException($"FrameID must be 4 bytes ({array.Length} bytes passed)");
				}
				array2[0] = array[0];
				array2[1] = array[1];
				array2[2] = array[2];
				array2[3] = array[3];
				array2[4] = (byte)((num2 >> 21) & 0x7F);
				array2[5] = (byte)((num2 >> 14) & 0x7F);
				array2[6] = (byte)((num2 >> 7) & 0x7F);
				array2[7] = (byte)(num2 & 0x7F);
				array2[8] = b;
				array2[9] = b2;
				int num3 = 10;
				if (m_GroupingIdentity.HasValue)
				{
					array2[num3++] = m_GroupingIdentity.Value;
				}
				if (m_IsCompressed)
				{
					array2[num3++] = (byte)(DecompressedSize >> 24);
					array2[num3++] = (byte)(DecompressedSize >> 16);
					array2[num3++] = (byte)(DecompressedSize >> 8);
					array2[num3++] = (byte)DecompressedSize;
				}
				if (m_EncryptionMethod.HasValue)
				{
					array2[num3++] = m_EncryptionMethod.Value;
				}
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("tagVersion", tagVersion, "Unknown tag version");
			}
			using MemoryStream memoryStream = new MemoryStream();
			Utils.Write(memoryStream, array2);
			Utils.Write(memoryStream, frameData.ToArray());
			return memoryStream.ToArray();
		}
	}
}
