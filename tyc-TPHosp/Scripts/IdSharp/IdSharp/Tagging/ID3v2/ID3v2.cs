#define TRACE
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using IdSharp.Tagging.ID3v2.Frames;
using IdSharp.Utils;

namespace IdSharp.Tagging.ID3v2
{
	internal sealed class ID3v2 : FrameContainer, IID3v2, IFrameContainer, INotifyPropertyChanged, INotifyInvalidData
	{
		private ID3v2Header m_ID3v2Header;

		private ID3v2ExtendedHeader m_ID3v2ExtendedHeader;

		public IID3v2Header Header => m_ID3v2Header;

		public IID3v2ExtendedHeader ExtendedHeader => m_ID3v2ExtendedHeader;

		public ID3v2()
		{
			m_ID3v2Header = new ID3v2Header();
			m_ID3v2ExtendedHeader = new ID3v2ExtendedHeader();
		}

		public void Read(string path)
		{
			try
			{
				using Stream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
				if (stream.Length >= 10)
				{
					ReadStream(stream);
				}
			}
			catch (Exception innerException)
			{
				throw new Exception($"Error reading '{path}'", innerException);
			}
		}

		public void SaveEncoding(string path, EncodingType encodingType)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		public void Save(string path)
		{
			int tagSize = ID3v2Helper.GetTagSize(path);
			byte[] bytes = GetBytes(tagSize);
			if (bytes.Length < tagSize)
			{
				throw new ApplicationException("GetBytes() returned a size less than the minimum size");
			}
			if (bytes.Length > tagSize)
			{
				Utils.ReplaceBytes(path, tagSize, bytes);
				return;
			}
			using FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None);
			fileStream.Write(bytes, 0, bytes.Length);
		}

		public byte[] GetBytes(int minimumSize)
		{
			ID3v2TagVersion tagVersion = m_ID3v2Header.TagVersion;
			using MemoryStream memoryStream = new MemoryStream();
			byte[] bytes = GetBytes(tagVersion);
			int num = bytes.Length;
			m_ID3v2Header.UsesUnsynchronization = false;
			m_ID3v2Header.IsExperimental = true;
			if (m_ID3v2Header.HasExtendedHeader)
			{
				num += m_ID3v2ExtendedHeader.SizeExcludingSizeBytes + 4;
			}
			int num2 = minimumSize - (num + 10);
			if (num2 < 0)
			{
				num2 = 2000;
			}
			num += num2;
			m_ID3v2Header.TagSize = num;
			byte[] bytes2 = m_ID3v2Header.GetBytes();
			memoryStream.Write(bytes2, 0, bytes2.Length);
			if (m_ID3v2Header.HasExtendedHeader)
			{
				if (m_ID3v2ExtendedHeader.IsCRCDataPresent)
				{
					m_ID3v2ExtendedHeader.CRC32 = CRC32.CalculateInt32(bytes);
				}
				m_ID3v2ExtendedHeader.PaddingSize = num2;
				byte[] bytes3 = m_ID3v2ExtendedHeader.GetBytes(tagVersion);
				memoryStream.Write(bytes3, 0, bytes3.Length);
			}
			memoryStream.Write(bytes, 0, bytes.Length);
			byte[] buffer = new byte[num2];
			memoryStream.Write(buffer, 0, num2);
			memoryStream.Position = 0L;
			ID3v2 iD3v = new ID3v2();
			iD3v.ReadStream(memoryStream);
			return memoryStream.ToArray();
		}

		public void ReadStream(Stream stream)
		{
			if (Utils.ReadString(EncodingType.ISO88591, stream, 3) != "ID3")
			{
				return;
			}
			m_ID3v2Header = new ID3v2Header(stream, readIdentifier: false);
			TagReadingInfo tagReadingInfo = new TagReadingInfo(m_ID3v2Header.TagVersion);
			if (m_ID3v2Header.UsesUnsynchronization)
			{
				tagReadingInfo.TagVersionOptions = TagVersionOptions.Unsynchronized;
			}
			else
			{
				tagReadingInfo.TagVersionOptions = TagVersionOptions.None;
			}
			if (m_ID3v2Header.HasExtendedHeader)
			{
				m_ID3v2ExtendedHeader = new ID3v2ExtendedHeader(tagReadingInfo, stream);
			}
			int num = ((tagReadingInfo.TagVersion == ID3v2TagVersion.ID3v22) ? 3 : 4);
			int num2;
			if (m_ID3v2Header.TagVersion == ID3v2TagVersion.ID3v24)
			{
				bool flag = true;
				int i = 0;
				num2 = m_ID3v2Header.TagSize - m_ID3v2ExtendedHeader.SizeIncludingSizeBytes - num;
				long position = stream.Position;
				int num3;
				for (; i < num2; i += num3 + 10)
				{
					byte[] array = Utils.Read(stream, num);
					if (array[0] < 48 || array[0] > 90 || array[1] < 48 || array[1] > 90 || array[2] < 48 || array[2] > 90 || array[3] < 48 || array[3] > 90)
					{
						if (array[0] != 0 && array[0] == byte.MaxValue)
						{
						}
						break;
					}
					num3 = Utils.ReadInt32(stream);
					if (num3 > 255)
					{
						if ((num3 & 0x80) == 128)
						{
							flag = false;
							break;
						}
						if ((num3 & 0x8000) == 32768)
						{
							flag = false;
							break;
						}
						if ((num3 & 0x800000) == 8388608)
						{
							flag = false;
							break;
						}
						if (i + num3 + 10 == m_ID3v2Header.TagSize)
						{
							flag = false;
							break;
						}
						stream.Seek(-4L, SeekOrigin.Current);
						int num4 = Utils.ReadInt32SyncSafe(stream);
						long position2 = stream.Position;
						bool flag2 = true;
						bool flag3 = true;
						if (position2 + num3 + 2 >= num2)
						{
							flag = true;
							break;
						}
						stream.Seek(position2 + num3 + 2, SeekOrigin.Begin);
						array = Utils.Read(stream, num);
						if (array[0] < 48 || array[0] > 90 || array[1] < 48 || array[1] > 90 || array[2] < 48 || array[2] > 90 || array[3] < 48 || array[3] > 90)
						{
							flag3 = false;
						}
						stream.Seek(position2 + num4 + 2, SeekOrigin.Begin);
						array = Utils.Read(stream, num);
						if (array[0] < 48 || array[0] > 90 || array[1] < 48 || array[1] > 90 || array[2] < 48 || array[2] > 90 || array[3] < 48 || array[3] > 90)
						{
							flag2 = false;
						}
						if (flag3 != flag2)
						{
							flag = flag2;
						}
						break;
					}
					stream.Seek(num3 + 2, SeekOrigin.Current);
				}
				stream.Position = position;
				if (!flag)
				{
					tagReadingInfo.TagVersionOptions |= TagVersionOptions.UseNonSyncSafeFrameSizeID3v24;
				}
			}
			else if (m_ID3v2Header.TagVersion == ID3v2TagVersion.ID3v22)
			{
				bool flag4 = true;
				int i = 0;
				num2 = m_ID3v2Header.TagSize - m_ID3v2ExtendedHeader.SizeIncludingSizeBytes - num;
				long position3 = stream.Position;
				Utils.Read(stream, num);
				UnknownFrame unknownFrame = new UnknownFrame(null, tagReadingInfo, stream);
				i += unknownFrame.FrameHeader.FrameSizeTotal;
				if (i < num2)
				{
					byte[] array2 = Utils.Read(stream, num);
					if ((array2[0] < 48 || array2[0] > 90) && array2[1] >= 48 && array2[1] <= 90 && array2[2] >= 48 && array2[2] <= 90)
					{
						Trace.WriteLine("ID3v2.2 frame size off by 1 byte");
						flag4 = false;
					}
				}
				stream.Position = position3;
				if (!flag4)
				{
					tagReadingInfo.TagVersionOptions |= TagVersionOptions.AddOneByteToSize;
				}
			}
			num2 = m_ID3v2Header.TagSize - m_ID3v2ExtendedHeader.SizeIncludingSizeBytes - num;
			Read(stream, m_ID3v2Header.TagVersion, tagReadingInfo, num2, num);
		}
	}
}
